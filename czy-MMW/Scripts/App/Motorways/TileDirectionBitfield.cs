using System;
using System.Collections.Generic;
using Factory;

namespace Motorways
{
	public struct TileDirectionBitfield : IEquatable<TileDirectionBitfield>
	{
		public struct Enumerator
		{
			private readonly int _bitfield;

			private int _currentDirection;

			public TileDirection Current => (TileDirection)_currentDirection;

			public Enumerator(int bitfield)
			{
				_bitfield = bitfield;
				_currentDirection = -1;
			}

			public bool MoveNext()
			{
				do
				{
					_currentDirection++;
				}
				while (_currentDirection < 8 && (_bitfield & (1 << _currentDirection)) == 0);
				return _currentDirection < 8;
			}
		}

		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is TileDirectionBitfield)
				{
					int bitfield = ((TileDirectionBitfield)obj)._bitfield;
					context.Writer.Write(bitfield);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return new TileDirectionBitfield(context.Reader.ReadInt32());
			}
		}

		public static readonly TileDirectionBitfield All = new TileDirectionBitfield(255);

		public static readonly TileDirectionBitfield None = new TileDirectionBitfield(0);

		private int _bitfield;

		public int Count
		{
			get
			{
				int num = 0;
				for (int i = 0; i < 8; i++)
				{
					if ((_bitfield & (1 << i)) != 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		public TileDirection this[int index]
		{
			get
			{
				int num = index + 1;
				for (int i = 0; i < 8; i++)
				{
					if ((_bitfield & (1 << i)) != 0)
					{
						num--;
					}
					if (num == 0)
					{
						return (TileDirection)i;
					}
				}
				return TileDirection.None;
			}
		}

		public bool this[TileDirection direction]
		{
			get
			{
				return (_bitfield & (1 << (int)direction)) != 0;
			}
			set
			{
				if (value)
				{
					_bitfield |= 1 << (int)direction;
				}
				else
				{
					_bitfield &= ~(1 << (int)direction);
				}
			}
		}

		public int Bits => _bitfield;

		public TileDirectionBitfield(TileDirection direction)
		{
			_bitfield = 0;
			this[direction] = true;
		}

		public TileDirectionBitfield(IEnumerable<TileDirection> directions)
		{
			_bitfield = 0;
			foreach (TileDirection direction in directions)
			{
				this[direction] = true;
			}
		}

		public TileDirectionBitfield(int bitfield)
		{
			_bitfield = bitfield;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(_bitfield);
		}

		public void Clear()
		{
			_bitfield = 0;
		}

		public bool Equals(IEnumerable<TileDirection> directions)
		{
			return Equals(new TileDirectionBitfield(directions));
		}

		public override string ToString()
		{
			List<string> list = new List<string>();
			Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				list.Add(enumerator.Current.ToString());
			}
			return string.Format("TileDirectionBitfield[{0}]", string.Join(", ", list));
		}

		public static TileDirectionBitfield operator ~(TileDirectionBitfield bitfield)
		{
			return new TileDirectionBitfield(~bitfield._bitfield);
		}

		public bool Equals(TileDirectionBitfield other)
		{
			return _bitfield == other._bitfield;
		}

		public override bool Equals(object obj)
		{
			if (obj is TileDirectionBitfield other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _bitfield;
		}

		public static bool operator ==(TileDirectionBitfield left, TileDirectionBitfield right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(TileDirectionBitfield left, TileDirectionBitfield right)
		{
			return !left.Equals(right);
		}
	}
}
