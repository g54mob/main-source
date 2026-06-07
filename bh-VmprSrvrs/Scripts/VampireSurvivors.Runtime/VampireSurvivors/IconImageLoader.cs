using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors
{
	public class IconImageLoader : MonoBehaviour
	{
		private struct SpriteTextureDataInternal
		{
			public string Texture;

			public string Sprite;

			public Sprite SpriteRef;

			public SpriteTextureDataInternal(string texture, string sprite, Sprite spriteRef)
			{
				Texture = null;
				Sprite = null;
				SpriteRef = null;
			}
		}

		[SerializeField]
		private string _filterTextures;

		private SpriteTextureDataInternal _spriteTextureData;

		[SerializeField]
		private string _texture;

		[SerializeField]
		private string _sprite;

		private Sprite _spritePreview;

		private Image _image;

		private void Awake()
		{
		}

		public void OnEnable()
		{
		}
	}
}
