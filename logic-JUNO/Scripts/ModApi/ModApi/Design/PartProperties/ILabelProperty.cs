namespace ModApi.Design.PartProperties
{
	public interface ILabelProperty : IConfigurableProperty
	{
		float FontSize { get; }

		string LabelValue { get; set; }

		void RestoreFontSize();

		void SetFontSize(float size);

		void SetFontSize(float minSize, float maxSize);
	}
}
