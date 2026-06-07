using DV.RenderTextureSystem.BookletRender;
using UnityEngine;

namespace DV.Booklets.Rendered
{
	[DisallowMultipleComponent]
	public abstract class RenderedTexturesBase : MonoBehaviour
	{
		private BookletTextureRender bookletTextureGenerator;

		private Texture[] textures;

		private bool generated;

		public void RegisterTexturesGeneratedEvent(BookletTextureRender bookletTextureGenerator)
		{
			this.bookletTextureGenerator = bookletTextureGenerator;
			this.bookletTextureGenerator.TexturesGenerated += OnBookletTexturesGenerated;
		}

		public bool IsGenerated()
		{
			return generated;
		}

		protected virtual void OnBookletTexturesGenerated(Texture[] generatedTextures, BookletTextureRender _)
		{
			bookletTextureGenerator.TexturesGenerated -= OnBookletTexturesGenerated;
			bookletTextureGenerator = null;
			textures = generatedTextures;
			generated = true;
		}

		protected virtual void OnDestroy()
		{
			if (bookletTextureGenerator != null)
			{
				bookletTextureGenerator.TexturesGenerated -= OnBookletTexturesGenerated;
				bookletTextureGenerator.RequestRenderCancel();
			}
			if (generated && textures != null)
			{
				Texture[] array = textures;
				for (int i = 0; i < array.Length; i++)
				{
					Object.Destroy(array[i]);
				}
			}
		}
	}
}
