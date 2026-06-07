using System;

namespace ModApi.Ui.Inspector
{
	public interface ITextureSelector
	{
		void SelectTexture(TextureModel model, Action<string> onComplete);
	}
}
