using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	[RequireComponent(typeof(Image))]
	public class AsyncSpriteLoader : MonoBehaviour
	{
		private Image target;

		private string spriteName;

		public Sprite defaultSprite;

		public Material defaultMaterial;

		public string spritePath;

		public string SpriteName
		{
			get
			{
				return spriteName;
			}
			set
			{
				if (!(spriteName == value))
				{
					spriteName = value;
					if (target != null)
					{
						OnSpriteChanged();
					}
				}
			}
		}

		protected virtual void OnEnable()
		{
			target = GetComponent<Image>();
		}

		protected virtual void OnSpriteChanged()
		{
			if (string.IsNullOrEmpty(spriteName))
			{
				target.sprite = null;
				target.material = null;
			}
			else
			{
				target.sprite = defaultSprite;
				target.material = defaultMaterial;
				StartCoroutine(LoadSprite());
			}
		}

		private IEnumerator LoadSprite()
		{
			yield return new WaitForSeconds(1f);
			Sprite[] array = Resources.LoadAll<Sprite>(spritePath);
			foreach (Sprite sprite in array)
			{
				if (sprite.name.Equals(spriteName))
				{
					target.sprite = sprite;
					target.material = null;
				}
			}
		}
	}
}
