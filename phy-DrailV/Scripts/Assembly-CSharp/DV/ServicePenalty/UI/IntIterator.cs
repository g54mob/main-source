namespace DV.ServicePenalty.UI
{
	public class IntIterator
	{
		public delegate void IntIteratorCurrentUpdatedDelegate(int current);

		public const int INVALID_VALUE = -1;

		private int current;

		public int Length;

		public readonly bool isWrappable;

		public int Current
		{
			get
			{
				return current;
			}
			set
			{
				if (value != current)
				{
					current = value;
					this.CurrentUpdated?.Invoke(current);
				}
			}
		}

		public bool HasElements => Length > 0;

		public bool IsLast
		{
			get
			{
				if (Current == Length - 1)
				{
					return HasElements;
				}
				return false;
			}
		}

		public bool IsFirst
		{
			get
			{
				if (Current == 0)
				{
					return HasElements;
				}
				return false;
			}
		}

		public event IntIteratorCurrentUpdatedDelegate CurrentUpdated;

		public IntIterator(int starting, int length, bool isWrappable)
		{
			if (starting < 0 || starting >= length)
			{
				starting = 0;
			}
			Current = starting;
			Length = length;
			this.isWrappable = isWrappable;
		}

		public void UpdateLength(int newLength)
		{
			Length = newLength;
			if (Current >= Length && Length > 0)
			{
				Current = Length - 1;
			}
		}

		public int Reset()
		{
			return Current = 0;
		}

		public int Next()
		{
			if (!HasElements)
			{
				return -1;
			}
			if (Current == Length - 1)
			{
				if (isWrappable)
				{
					Current = 0;
				}
			}
			else
			{
				Current++;
			}
			return Current;
		}

		public int Previous()
		{
			if (!HasElements)
			{
				return -1;
			}
			if (Current == 0)
			{
				if (isWrappable)
				{
					Current = Length - 1;
				}
			}
			else
			{
				Current--;
			}
			return Current;
		}
	}
}
