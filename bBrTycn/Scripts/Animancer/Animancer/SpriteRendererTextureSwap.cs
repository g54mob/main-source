using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	[AddComponentMenu("Animancer/Sprite Renderer Texture Swap")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/SpriteRendererTextureSwap")]
	[DefaultExecutionOrder(30000)]
	public class SpriteRendererTextureSwap : MonoBehaviour
	{
		public const int DefaultExecutionOrder = 30000;

		[SerializeField]
		[Tooltip("The SpriteRenderer that will have its Sprite modified")]
		private SpriteRenderer _Renderer;

		[SerializeField]
		[Tooltip("The replacement for the original Sprite texture")]
		private Texture2D _Texture;

		private Dictionary<Sprite, Sprite> _SpriteMap;

		private static readonly Dictionary<Texture2D, Dictionary<Sprite, Sprite>> TextureToSpriteMap = new Dictionary<Texture2D, Dictionary<Sprite, Sprite>>();

		public ref SpriteRenderer Renderer => ref _Renderer;

		public Texture2D Texture
		{
			get
			{
				return _Texture;
			}
			set
			{
				_Texture = value;
				RefreshSpriteMap();
			}
		}

		private void RefreshSpriteMap()
		{
			_SpriteMap = GetSpriteMap(_Texture);
		}

		protected virtual void Awake()
		{
			RefreshSpriteMap();
		}

		protected virtual void OnValidate()
		{
			RefreshSpriteMap();
		}

		protected virtual void LateUpdate()
		{
			if (!(_Renderer == null))
			{
				Sprite sprite = _Renderer.sprite;
				if (TrySwapTexture(_SpriteMap, _Texture, ref sprite))
				{
					_Renderer.sprite = sprite;
				}
			}
		}

		public void ClearCache()
		{
			DestroySprites(_SpriteMap);
		}

		public static Dictionary<Sprite, Sprite> GetSpriteMap(Texture2D texture)
		{
			if (texture == null)
			{
				return null;
			}
			if (!TextureToSpriteMap.TryGetValue(texture, out var value))
			{
				TextureToSpriteMap.Add(texture, value = new Dictionary<Sprite, Sprite>());
			}
			return value;
		}

		public static bool TrySwapTexture(Dictionary<Sprite, Sprite> spriteMap, Texture2D texture, ref Sprite sprite)
		{
			if (spriteMap == null || sprite == null || texture == null || sprite.texture == texture)
			{
				return false;
			}
			if (!spriteMap.TryGetValue(sprite, out var value))
			{
				Vector2 pivot = sprite.pivot;
				pivot.x /= sprite.rect.width;
				pivot.y /= sprite.rect.height;
				value = Sprite.Create(texture, sprite.rect, pivot, sprite.pixelsPerUnit, 0u, SpriteMeshType.FullRect, sprite.border, generateFallbackPhysicsShape: false);
				spriteMap.Add(sprite, value);
			}
			sprite = value;
			return true;
		}

		public static void DestroySprites(Dictionary<Sprite, Sprite> spriteMap)
		{
			if (spriteMap == null)
			{
				return;
			}
			foreach (Sprite value in spriteMap.Values)
			{
				Object.Destroy(value);
			}
			spriteMap.Clear();
		}

		public static void DestroySprites(Texture2D texture)
		{
			if (TextureToSpriteMap.TryGetValue(texture, out var value))
			{
				TextureToSpriteMap.Remove(texture);
				DestroySprites(value);
			}
		}
	}
}
