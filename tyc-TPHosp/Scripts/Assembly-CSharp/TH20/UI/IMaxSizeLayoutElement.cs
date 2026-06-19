namespace TH20.UI
{
	public interface IMaxSizeLayoutElement
	{
		int layoutPriority { get; }

		float maxWidth { get; }

		float maxHeight { get; }
	}
}
