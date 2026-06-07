using System.Text;

namespace Mystery.Graphing
{
	public abstract class ValueRange<T> : IValueRange
	{
		public abstract T Min { get; set; }

		public abstract T Max { get; set; }

		object IValueRange.Min
		{
			get
			{
				return Min;
			}
			set
			{
				Min = (T)value;
			}
		}

		object IValueRange.Max
		{
			get
			{
				return Max;
			}
			set
			{
				Max = (T)value;
			}
		}

		void IValueRange.UpdateMin(object value)
		{
			UpdateMin((T)value);
		}

		void IValueRange.UpdateMax(object value)
		{
			UpdateMax((T)value);
		}

		void IValueRange.UpdateMinMax(object value)
		{
			UpdateMinMax((T)value);
		}

		public abstract void UpdateMin(T value);

		public abstract void UpdateMax(T value);

		public void UpdateMinMax(T value)
		{
			UpdateMin(value);
			UpdateMax(value);
		}

		public T GetSearchValue(ValueTransformer<T> transfomer, float xOffset)
		{
			return transfomer.Lerp(Min, Max, xOffset);
		}

		public abstract void Reset();

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Min: ");
			stringBuilder.Append(Min);
			stringBuilder.Append(" Max: ");
			stringBuilder.Append(Max);
			return stringBuilder.ToString();
		}
	}
}
