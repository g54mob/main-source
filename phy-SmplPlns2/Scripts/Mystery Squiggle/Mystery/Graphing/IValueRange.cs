namespace Mystery.Graphing
{
	public interface IValueRange
	{
		object Min { get; set; }

		object Max { get; set; }

		void UpdateMin(object value);

		void UpdateMax(object value);

		void UpdateMinMax(object value);

		void Reset();
	}
}
