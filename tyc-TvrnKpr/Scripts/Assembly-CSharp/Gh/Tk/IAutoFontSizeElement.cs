namespace Gh.Tk
{
	public interface IAutoFontSizeElement
	{
		bool EnableAutoSizing { get; set; }

		float FontSize { get; set; }

		float FontSizeWithoutScale { get; set; }

		float MaxFontSizeWithoutScale { get; set; }

		void ForceMeshUpdate();
	}
}
