using System.Collections.Generic;
using System.Linq;
using DV.RenderTextureSystem.BookletRender;
using UnityEngine;

namespace DV.Booklets.Rendered
{
	[DisallowMultipleComponent]
	public class MultipleRenderedTexturesBooklet : MonoBehaviour
	{
		public PageBook pageBook;

		private bool pageBookGenerated;

		private List<BookletTextureRender> textureRenderers = new List<BookletTextureRender>();

		private List<Texture[]> renderedTextures = new List<Texture[]>();

		private int renderersProcessed;

		public bool IsPageBookGenerated()
		{
			return pageBookGenerated;
		}

		public void RegisterTexturesGeneratedEvent(BookletTextureRender bookletTextureGenerator)
		{
			textureRenderers.Add(bookletTextureGenerator);
			renderedTextures.Add(null);
			bookletTextureGenerator.TexturesGenerated += OnBookletTexturesGenerated;
		}

		protected void OnBookletTexturesGenerated(Texture[] generatedTextures, BookletTextureRender sender)
		{
			int num = textureRenderers.IndexOf(sender);
			if (num == -1)
			{
				Debug.LogError("Couldn't match with any renderer from textureRenderers list! Destroying object", sender);
				Object.Destroy(base.gameObject);
				return;
			}
			textureRenderers[num].TexturesGenerated -= OnBookletTexturesGenerated;
			renderedTextures[num] = generatedTextures;
			renderersProcessed++;
			if (renderersProcessed == renderedTextures.Count)
			{
				Texture[] pageTextures = renderedTextures.SelectMany((Texture[] textures) => textures).ToArray();
				pageBook.pageTextures = pageTextures;
				pageBook.Generate();
				pageBookGenerated = true;
				renderedTextures.Clear();
				textureRenderers.Clear();
			}
		}

		protected virtual void OnDestroy()
		{
			foreach (BookletTextureRender textureRenderer in textureRenderers)
			{
				if (textureRenderer != null)
				{
					textureRenderer.TexturesGenerated -= OnBookletTexturesGenerated;
					textureRenderer.RequestRenderCancel();
				}
			}
			Texture[] array;
			foreach (Texture[] renderedTexture in renderedTextures)
			{
				if (renderedTexture != null)
				{
					array = renderedTexture;
					for (int i = 0; i < array.Length; i++)
					{
						Object.Destroy(array[i]);
					}
				}
			}
			array = pageBook.pageTextures;
			for (int i = 0; i < array.Length; i++)
			{
				Object.Destroy(array[i]);
			}
		}
	}
}
