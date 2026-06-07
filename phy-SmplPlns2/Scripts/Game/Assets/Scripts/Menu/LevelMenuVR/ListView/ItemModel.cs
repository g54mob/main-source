using System;
using System.Collections;
using Jundroo.Common.Coroutines;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class ItemModel
	{
		public enum CheckmarkStyleTypes
		{
			Invisible = 0,
			Success = 1,
			Error = 2
		}

		public Func<CheckmarkStyleTypes> CheckmarkStyle { get; set; } = () => CheckmarkStyleTypes.Invisible;

		public bool IsLocked { get; set; }

		public string Name { get; set; }

		public Sprite Sprite { get; set; }

		public ResourceLocation ThumbnailLocation { get; set; }

		public string ThumbnailPath { get; set; }

		public ItemModel(string name)
		{
			Name = name;
		}

		public static Sprite CreateSpriteFromTexture(Texture2D texture)
		{
			texture.wrapMode = TextureWrapMode.Clamp;
			return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		}

		public IEnumerator LoadSpriteAsync()
		{
			if (ThumbnailPath != null)
			{
				YieldRequest<Texture2D> thumbnailRequest = new YieldRequest<Texture2D>();
				yield return ListViewUtilities.LoadTexture(ThumbnailLocation, ThumbnailPath, thumbnailRequest);
				if (thumbnailRequest.Success)
				{
					Sprite = CreateSpriteFromTexture(thumbnailRequest.Data);
				}
			}
		}
	}
}
