﻿using System;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;

namespace PearXLib
{
	/// <summary>
	/// PearXLib Computer Utilities.
	/// </summary>
	public static class PcUtils
	{
		/// <summary>
		/// Is current OS - Windows
		/// </summary>
		/// <returns>If current OS is Windows, returns true.</returns>
		public static bool IsWindows()
		{
			return Environment.OSVersion.ToString().ToLower().StartsWith("microsoft windows", StringComparison.Ordinal);
		}

		/// <summary>
		/// Starts an executable file.
		/// </summary>
		/// <param name="path">Path to .exe</param>
		/// <param name="args">Arguments.</param>
		public static void RunExe(string path, string args = "")
		{
			ProcessStartInfo inf = new ProcessStartInfo();

			if (IsWindows())
			{
				inf.FileName = path;
				inf.Arguments = args;
			}
			else
			{
				inf.FileName = "mono";
				inf.Arguments = path + " " + args;
			}
			Process.Start(inf);
		}

		/// <summary>
		/// Gets a Windows info. https://msdn.microsoft.com/en-us/library/windows/desktop/aa394239(v=vs.85).aspx - docs.
		/// </summary>
		/// <param name="what">Caption</param>
		/// <returns>Result</returns>
		public static string GetFromWindows(string what)
		{
			using (var ser = new ManagementObjectSearcher("SELECT " + what + " FROM Win32_OperatingSystem"))
			{
				foreach (ManagementBaseObject mo in ser.Get())
				{
					return mo[what].ToString();
				}
			}
			return null;
		}

		/// <summary>
		/// Gets a path to the Java directory.
		/// </summary>
		/// <param name="javaw">Use javaw.exe instead of java.exe in Windows?</param>
		/// <returns>A path to the Java folder.</returns>
		public static string GetJavaPath(bool javaw = true)
		{
		    if (IsWindows())
		    {
		        using (var v = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
		            .OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment"))
		        {
		            if (v == null)
		                return "";
		            string ver = v.GetValue("CurrentVersion").ToString();
		            using (var w = v.OpenSubKey(ver))
		            {
		                if (w == null)
		                    return "";
		                return w.GetValue("JavaHome") + $"\\bin\\java{(javaw ? "w" : "")}.exe";
		            }
		        }
		    }
		    else
		    {
		        return GetCommandOutput("which", "java");
		    }
		}

		/// <summary>
		/// Gets an information about PC's memory.
		/// </summary>
		/// <returns>An information about PC's memory.</returns>
		public static RamInfo GetRamInfo()
		{
			RamInfo ram = new RamInfo();
			if (IsWindows())
			{
				long total = Convert.ToInt64(GetFromWindows("TotalVisibleMemorySize"));
				long available = Convert.ToInt64(GetFromWindows("FreePhysicalMemory"));
				ram.Total = total;
				ram.Available = available;
				ram.Used = total - available;
			}
			else
			{
				MemInfo info = new MemInfo();
				long total = info.Get("MemTotal");
				long available = info.Get("MemAvailable");
				ram.Total = total;
				ram.Available = available;
				ram.Used = total - available;
			}
			return ram;
		}

		/// <summary>
		/// Gets the output of the command.
		/// </summary>
		/// <returns>The command stdout.</returns>
		/// <param name="cmd">Command name.</param>
		/// <param name="args">Command arguments.</param>
		public static string GetCommandOutput(string cmd, string args)
		{
			using (Process p = new Process())
			{
				p.StartInfo = new ProcessStartInfo
				{
					FileName = cmd,
					Arguments = args,
					RedirectStandardOutput = true,
					UseShellExecute = false
				};
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.Start();
				p.WaitForExit();
				return p.StandardOutput.ReadToEnd().Trim();
			}
		}
	}
}
