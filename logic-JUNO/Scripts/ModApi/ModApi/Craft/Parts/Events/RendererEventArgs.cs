using System;

namespace ModApi.Craft.Parts.Events
{
	public class RendererEventArgs : EventArgs
	{
		public IRendererMaterialMap Renderer { get; }

		public RendererEventArgs(IRendererMaterialMap renderer)
		{
			Renderer = renderer;
		}
	}
}
