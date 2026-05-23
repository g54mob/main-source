using System;
using System.Globalization;

namespace Rewired.Libraries.SharpDX
{
	internal struct RectangleF : IEquatable<RectangleF>
	{
		private float _left;

		private float _top;

		private float _right;

		private float _bottom;

		public static readonly RectangleF Empty;

		public static readonly RectangleF Infinite;

		public float Left
		{
			get
			{
				return _left;
			}
			set
			{
				_left = value;
			}
		}

		public float Top
		{
			get
			{
				return _top;
			}
			set
			{
				_top = value;
			}
		}

		public float Right
		{
			get
			{
				return _right;
			}
			set
			{
				_right = value;
			}
		}

		public float Bottom
		{
			get
			{
				return _bottom;
			}
			set
			{
				_bottom = value;
			}
		}

		public float X
		{
			get
			{
				return _left;
			}
			set
			{
				_right = value + Width;
				_left = value;
			}
		}

		public float Y
		{
			get
			{
				return _top;
			}
			set
			{
				_bottom = value + Height;
				_top = value;
			}
		}

		public float Width
		{
			get
			{
				return _right - _left;
			}
			set
			{
				_right = _left + value;
			}
		}

		public float Height
		{
			get
			{
				return _bottom - _top;
			}
			set
			{
				_bottom = _top + value;
			}
		}

		public xMyFYwAcbAMtUwOEeJDvgFFnlCfC Location
		{
			get
			{
				return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(X, Y);
			}
			set
			{
				X = value.xIuDTKizXrGdQWHryFwOfDhIWfYh;
				Y = value.BnoOLWClHLapgAPysAHqWqcOkax;
			}
		}

		public xMyFYwAcbAMtUwOEeJDvgFFnlCfC Center
		{
			get
			{
				return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(X + Width / 2f, Y + Height / 2f);
			}
		}

		public bool IsEmpty
		{
			get
			{
				if (Width == 0f && Height == 0f && X == 0f)
				{
					return Y == 0f;
				}
				return false;
			}
		}

		public Size2F Size
		{
			get
			{
				return new Size2F(Width, Height);
			}
			set
			{
				Width = value.Width;
				Height = value.Height;
			}
		}

		public xMyFYwAcbAMtUwOEeJDvgFFnlCfC TopLeft
		{
			get
			{
				return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(_left, _top);
			}
		}

		public xMyFYwAcbAMtUwOEeJDvgFFnlCfC TopRight
		{
			get
			{
				return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(_right, _top);
			}
		}

		public xMyFYwAcbAMtUwOEeJDvgFFnlCfC BottomLeft
		{
			get
			{
				return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(_left, _bottom);
			}
		}

		public xMyFYwAcbAMtUwOEeJDvgFFnlCfC BottomRight
		{
			get
			{
				return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(_right, _bottom);
			}
		}

		static RectangleF()
		{
			Empty = default(RectangleF);
			Infinite = new RectangleF
			{
				Left = float.NegativeInfinity,
				Top = float.NegativeInfinity,
				Right = float.PositiveInfinity,
				Bottom = float.PositiveInfinity
			};
		}

		public RectangleF(float x, float y, float width, float height)
		{
			_left = x;
			_top = y;
			_right = x + width;
			_bottom = y + height;
		}

		public void Offset(Point amount)
		{
			Offset(amount.X, amount.Y);
		}

		public void Offset(xMyFYwAcbAMtUwOEeJDvgFFnlCfC amount)
		{
			Offset(amount.xIuDTKizXrGdQWHryFwOfDhIWfYh, amount.BnoOLWClHLapgAPysAHqWqcOkax);
		}

		public void Offset(float offsetX, float offsetY)
		{
			X += offsetX;
			Y += offsetY;
		}

		public void Inflate(float horizontalAmount, float verticalAmount)
		{
			X -= horizontalAmount;
			Y -= verticalAmount;
			Width += horizontalAmount * 2f;
			Height += verticalAmount * 2f;
		}

		public void Contains(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC value, out bool result)
		{
			result = X <= value.xIuDTKizXrGdQWHryFwOfDhIWfYh && value.xIuDTKizXrGdQWHryFwOfDhIWfYh < Right && Y <= value.BnoOLWClHLapgAPysAHqWqcOkax && value.BnoOLWClHLapgAPysAHqWqcOkax < Bottom;
		}

		public bool Contains(Rectangle value)
		{
			if (X <= (float)value.X && (float)value.Right <= Right && Y <= (float)value.Y)
			{
				return (float)value.Bottom <= Bottom;
			}
			return false;
		}

		public void Contains(ref RectangleF value, out bool result)
		{
			result = X <= value.X && value.Right <= Right && Y <= value.Y && value.Bottom <= Bottom;
		}

		public bool Contains(float x, float y)
		{
			if (x >= _left && x <= _right && y >= _top)
			{
				return y <= _bottom;
			}
			return false;
		}

		public bool Contains(xMyFYwAcbAMtUwOEeJDvgFFnlCfC vector2D)
		{
			return Contains(vector2D.xIuDTKizXrGdQWHryFwOfDhIWfYh, vector2D.BnoOLWClHLapgAPysAHqWqcOkax);
		}

		public bool Contains(Point point)
		{
			return Contains(point.X, point.Y);
		}

		public bool Intersects(RectangleF value)
		{
			bool result;
			Intersects(ref value, out result);
			return result;
		}

		public void Intersects(ref RectangleF value, out bool result)
		{
			result = value.X < Right && X < value.Right && value.Y < Bottom && Y < value.Bottom;
		}

		public static RectangleF Intersect(RectangleF value1, RectangleF value2)
		{
			RectangleF result;
			Intersect(ref value1, ref value2, out result);
			return result;
		}

		public static void Intersect(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
		{
			float num = ((value1.X > value2.X) ? value1.X : value2.X);
			float num2 = ((value1.Y > value2.Y) ? value1.Y : value2.Y);
			float num3 = ((value1.Right < value2.Right) ? value1.Right : value2.Right);
			float num4 = ((value1.Bottom < value2.Bottom) ? value1.Bottom : value2.Bottom);
			if (num3 > num && num4 > num2)
			{
				result = new RectangleF(num, num2, num3 - num, num4 - num2);
			}
			else
			{
				result = Empty;
			}
		}

		public static RectangleF Union(RectangleF value1, RectangleF value2)
		{
			RectangleF result;
			Union(ref value1, ref value2, out result);
			return result;
		}

		public static void Union(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
		{
			float num = Math.Min(value1.Left, value2.Left);
			float num2 = Math.Max(value1.Right, value2.Right);
			float num3 = Math.Min(value1.Top, value2.Top);
			float num4 = Math.Max(value1.Bottom, value2.Bottom);
			result = new RectangleF(num, num3, num2 - num, num4 - num3);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (obj.GetType() != typeof(RectangleF))
			{
				return false;
			}
			return Equals((RectangleF)obj);
		}

		public bool Equals(RectangleF other)
		{
			if (FpTrbTgRASLmrLSXGJpSPdrcCzX.jGcirjVqFqRRNigbGIZUrCcmHfw(other.Left, Left) && FpTrbTgRASLmrLSXGJpSPdrcCzX.jGcirjVqFqRRNigbGIZUrCcmHfw(other.Right, Right) && FpTrbTgRASLmrLSXGJpSPdrcCzX.jGcirjVqFqRRNigbGIZUrCcmHfw(other.Top, Top))
			{
				return FpTrbTgRASLmrLSXGJpSPdrcCzX.jGcirjVqFqRRNigbGIZUrCcmHfw(other.Bottom, Bottom);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hashCode = _left.GetHashCode();
			hashCode = (hashCode * 397) ^ _top.GetHashCode();
			hashCode = (hashCode * 397) ^ _right.GetHashCode();
			return (hashCode * 397) ^ _bottom.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Width:{2} Height:{3}", X, Y, Width, Height);
		}

		public static bool operator ==(RectangleF left, RectangleF right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(RectangleF left, RectangleF right)
		{
			return !(left == right);
		}

		public static explicit operator Rectangle(RectangleF value)
		{
			return new Rectangle((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
		}
	}
}
