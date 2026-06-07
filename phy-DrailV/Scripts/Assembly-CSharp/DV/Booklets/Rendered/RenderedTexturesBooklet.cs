using DV.RenderTextureSystem.BookletRender;
using UnityEngine;

namespace DV.Booklets.Rendered
{
	[DisallowMultipleComponent]
	public class RenderedTexturesBooklet : RenderedTexturesBase
	{
		public PageBook pageBook;

		protected override void OnBookletTexturesGenerated(Texture[] generatedTextures, BookletTextureRender _)
		{
			base.OnBookletTexturesGenerated(generatedTextures, _);
			pageBook.pageTextures = generatedTextures;
			pageBook.Generate();
		}
	}
}
