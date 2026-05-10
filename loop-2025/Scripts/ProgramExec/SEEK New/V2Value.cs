// add
using System;
using System.Collections.Generic;

namespace GptDeepResearch
{
	/// <summary>
	/// Represents a 2D vector value in the Python interpreter.
	/// Supports v2(x, y) creation, .x/.y attribute access, and arithmetic operations.
	/// </summary>
	public class V2Value
	{
		public double X { get; set; }
		public double Y { get; set; }

		public V2Value(double x, double y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// Convert from a 2-element list to V2Value
		/// </summary>
		public static V2Value FromList(List<object> list)
		{
			if (list == null || list.Count != 2)
				throw new Exception($"Cannot convert list to v2: expected 2 elements, got {list?.Count}");

			double x = NumericHelpers.ToDouble(list[0]);
			double y = NumericHelpers.ToDouble(list[1]);
			return new V2Value(x, y);
		}

		/// <summary>
		/// Convert to a 2-element list
		/// </summary>
		public List<object> ToList()
		{
			return new List<object> { X, Y };
		}

		/// <summary>
		/// Vector addition
		/// </summary>
		public static V2Value operator +(V2Value a, V2Value b)
		{
			return new V2Value(a.X + b.X, a.Y + b.Y);
		}

		/// <summary>
		/// Vector subtraction
		/// </summary>
		public static V2Value operator -(V2Value a, V2Value b)
		{
			return new V2Value(a.X - b.X, a.Y - b.Y);
		}

		/// <summary>
		/// Unary minus
		/// </summary>
		public static V2Value operator -(V2Value a)
		{
			return new V2Value(-a.X, -a.Y);
		}

		/// <summary>
		/// Vector equality with floating-point tolerance
		/// </summary>
		public static bool operator ==(V2Value a, V2Value b)
		{
			if (ReferenceEquals(a, b)) return true;
			if (a is null || b is null) return false;

			const double tolerance = 0.001; // Same as existing numeric comparison
			return Math.Abs(a.X - b.X) < tolerance && Math.Abs(a.Y - b.Y) < tolerance;
		}

		public static bool operator !=(V2Value a, V2Value b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			return obj is V2Value other && this == other;
		}

		public override int GetHashCode()
		{
			// Unity 2020.3 compatible hash code generation
			unchecked
			{
				int hash = 17;
				hash = hash * 31 + X.GetHashCode();
				hash = hash * 31 + Y.GetHashCode();
				return hash;
			}
		}

		/// <summary>
		/// String representation: v2(x, y)
		/// </summary>
		public override string ToString()
		{
			return $"v2({X}, {Y})";
		}

		/// <summary>
		/// Get attribute value (.x or .y)
		/// </summary>
		public object GetAttribute(string name)
		{
			switch (name.ToLower())
			{
				case "x": return X;
				case "y": return Y;
				default:
					throw new Exception($"V2Value has no attribute '{name}'");
			}
		}

		/// <summary>
		/// Set attribute value (.x or .y)
		/// </summary>
		public void SetAttribute(string name, object value)
		{
			double numValue = NumericHelpers.ToDouble(value);
			switch (name.ToLower())
			{
				case "x": X = numValue; break;
				case "y": Y = numValue; break;
				default:
					throw new Exception($"V2Value has no attribute '{name}'");
			}
		}
	}

	/// <summary>
	/// Helper class for numeric conversions
	/// </summary>
	public static class NumericHelpers
	{
		public static double ToDouble(object obj)
		{
			if (obj == null)
				throw new Exception("Cannot convert null to number");

			if (obj is double d) return d;
			if (obj is float f) return f;
			if (obj is int i) return i;
			if (obj is long l) return l;
			if (obj is bool b) return b ? 1.0 : 0.0;

			if (obj is string str)
			{
				if (double.TryParse(str.Trim(), out double result))
					return result;
				throw new Exception($"Cannot convert string '{str}' to number");
			}

			throw new Exception($"Cannot convert {obj.GetType().Name} to number");
		}

		public static bool IsNumeric(object obj)
		{
			return obj is double || obj is float || obj is int || obj is long || obj is decimal || obj is bool;
		}
	}

	/// <summary>
	/// Helper class for coordinate normalization in builtin functions
	/// </summary>
	public static class CoordinateHelpers
	{
		/// <summary>
		/// Normalize various input types to (x, y) coordinates
		/// Accepts: V2Value, 2-element List, or throws error
		/// </summary>
		public static (double x, double y) NormalizeToXY(object value)
		{
			if (value is V2Value v2)
			{
				return (v2.X, v2.Y);
			}

			if (value is List<object> list)
			{
				if (list.Count != 2)
					throw new Exception($"List must have exactly 2 elements for coordinates, got {list.Count}");

				double x = NumericHelpers.ToDouble(list[0]);
				double y = NumericHelpers.ToDouble(list[1]);
				return (x, y);
			}

			throw new Exception($"Cannot convert {value?.GetType().Name} to coordinates. Expected v2 or 2-element list.");
		}

		/// <summary>
		/// Normalize two separate arguments to (x, y) coordinates
		/// Used for functions that accept either (x, y) or single v2/list argument
		/// </summary>
		public static (double x, double y) NormalizeToXY(object[] args)
		{
			if (args.Length == 1)
			{
				return NormalizeToXY(args[0]);
			}
			else if (args.Length == 2)
			{
				double x = NumericHelpers.ToDouble(args[0]);
				double y = NumericHelpers.ToDouble(args[1]);
				return (x, y);
			}
			else
			{
				throw new Exception($"Expected 1 or 2 arguments for coordinates, got {args.Length}");
			}
		}
	}
}