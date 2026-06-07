using System;
using ModApi.CelestialData;

namespace ModApi.Ui.Inspector
{
	public class TextureModel : ValueModel<string>
	{
		public string Label { get; set; }

		public Func<SupportFileData, bool> TextureFilter { get; set; }

		public ITextureSelector TextureSelector { get; set; }

		public TextureModel(string label, ITextureSelector textureSelector, Func<string> valueGetter, Action<string> valueSetter, Func<SupportFileData, bool> filter = null)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			TextureSelector = textureSelector;
			TextureFilter = filter;
		}
	}
}
