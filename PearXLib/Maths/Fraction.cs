﻿namespace PearXLib.Maths
{
	/// <summary>
	/// A fraction class.
	/// </summary>
	public class Fraction
	{
		/// <summary>
		/// A numerator of the fraction.
		/// </summary>
		public long Numerator { get; set; }

		/// <summary>
		/// A denominator of the fraction.
		/// </summary>
		public long Denominator { get; set; }

		/// <summary>
		/// Initializes a new fraction
		/// </summary>
		/// <param name="num">Numerator</param>
		/// <param name="den">Denominator</param>
		public Fraction(long num, long den = 1)
		{
			Numerator = num;
			Denominator = den;
		}

		/// <summary>
		/// *
		/// </summary>
		public static Fraction operator *(Fraction left, Fraction right)
		{
			var fract = new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
		    return fract;
		}

		/// <summary>
		/// /
		/// </summary>
		public static Fraction operator /(Fraction left, Fraction right)
		{
			var fract = new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
		    return fract;
		}

		/// <summary>
		/// Reduces this fraction.
		/// </summary>
		/// <returns>The reduced fraction</returns>
		public Fraction Reduce()
		{
			var gcd = MathUtils.GetGcd(Numerator, Denominator);
			var fract = new Fraction(Numerator / gcd, Denominator / gcd);
			return fract;
		}

	    /// <summary>
	    /// Converts a fraction to double.
	    /// </summary>
	    /// <returns>Double.</returns>
	    public double ToDouble()
	    {
	        return (double) Numerator / Denominator;
	    }

	    /// <summary>
	    /// Converts a fraction to float.
	    /// </summary>
	    public float ToFloat()
	    {
	        return (float) Numerator / Denominator;
	    }
	}
}