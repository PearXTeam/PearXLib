﻿using System;
using System.Drawing;

namespace PearXLib
{
	/// <summary>
	/// PearXLib random utilities.
	/// </summary>
	public static class RandomUtils
	{
		/// <summary>
		/// Generates a random character.
		/// </summary>
		/// <returns>Random character.</returns>
		public static char GenChar(this Random rand, string alphabet = Alphabets.English)
		{
			int i = rand.Next(alphabet.Length);
			return alphabet[i];
		}

		/// <summary>
		/// Generates a random digit.
		/// </summary>
		/// <returns>Random digit</returns>
		public static int GenDigit(this Random rand)
		{
			return rand.Next(0, 10);
		}

		/// <summary>
		/// Generates a random symbol.
		/// </summary>
		/// <param name="rand"></param>
		/// <returns></returns>
		public static char GenSymbol(this Random rand)
		{
			return GenChar(rand, Alphabets.Symbols);
		}

		/// <summary>
		/// Generates a random number/char/symbol.
		/// </summary>
		/// <param name="rand">Your random.</param>
		/// <param name="useSymbols">Use Symbols?</param>
		/// <returns>Random.</returns>
		public static char GenRandom(this Random rand, bool useSymbols)
		{
			if (useSymbols)
				return GenChar(rand, Alphabets.EngAll);
			return GenChar(rand, Alphabets.EngAllWithoutSymbols);
		}

		/// <summary>
		/// Generates a random string by the template.<para/>
		/// Template usage:<para/>
		/// %num% - a random figure, ex. 6 or 7.<para/>
		/// %char% - a random character, ex. b or e.<para/>
		/// %sym% - a random symbol, ex. ~ or +.<para/>
		/// %rand% - a random symbol, character, or figure.<para/>
		/// %randws% - a random character or figure.<para/>
		/// Write in uppercase for uppercase :p.<para/>
		/// Example template: q_%rand%%CHAR%%CHAR%%rand%_p. Example return: q_5FSg_p
		/// </summary>
		/// <param name="template">A template</param>
		/// <param name="rand">Your random</param>
		/// <returns>A random generated by template string.</returns>
		public static string ByTemplate(this Random rand, string template)
		{
			while (template.Contains("%char%"))
			{
				TextUtils.ReplaceFirst(ref template, "%char%", rand.GenChar().ToString());
			}
			while (template.Contains("%CHAR%"))
			{
				TextUtils.ReplaceFirst(ref template, "%CHAR%", rand.GenChar().ToString().ToUpper());
			}
			while (template.Contains("%num%"))
			{
				TextUtils.ReplaceFirst(ref template, "%num%", rand.GenDigit().ToString());
			}
			while (template.Contains("%rand%"))
			{
				TextUtils.ReplaceFirst(ref template, "%rand%", rand.GenRandom(true).ToString());
			}
			while (template.Contains("%randws%"))
			{
				TextUtils.ReplaceFirst(ref template, "%randws%", rand.GenRandom(false).ToString());
			}
			while (template.Contains("%RAND%"))
			{
				TextUtils.ReplaceFirst(ref template, "%RAND%", GenRandom(rand, true).ToString().ToUpper());
			}
			while (template.Contains("%RANDWS%"))
			{
				TextUtils.ReplaceFirst(ref template, "%RANDWS%", rand.GenRandom(false).ToString().ToUpper());
			}
			while (template.Contains("%sym%"))
			{
				TextUtils.ReplaceFirst(ref template, "%sym%", rand.GenSymbol().ToString());
			}
			return template;
		}

		/// <summary>
		/// Generates a random <see cref="long"/>.
		/// </summary>
		/// <returns>A random long.</returns>
		/// <param name="rand">Your random</param>
		/// <param name="max">Inclusive maximum value.</param>
		/// <param name="min">Inclusive minimum value.</param>
		public static long NextLong(this Random rand, long max, long min = 0)
		{
			byte[] buf = new byte[8];
			rand.NextBytes(buf);
			long longRand = BitConverter.ToInt64(buf, 0);

			return (Math.Abs(longRand % ((max + 1) - min)) + min);
		}

		/// <summary>
		/// Generates a random color.
		/// </summary>
		/// <returns>A random color..</returns>
		/// <param name="rand">Your Random.</param>
		/// <param name="maxR">Max Red.</param>
		/// <param name="maxG">Max Green.</param>
		/// <param name="maxB">Max Blue.</param>
		public static Color NextColor(this Random rand, byte maxR = 255, byte maxG = 255, byte maxB = 255)
		{
			return Color.FromArgb(rand.Next(maxR + 1), rand.Next(maxG + 1), rand.Next(maxB + 1));
		}
	}
}
