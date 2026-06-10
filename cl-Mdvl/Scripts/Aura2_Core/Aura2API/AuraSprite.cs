using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Aura2API
{
	[Serializable]
	[AddComponentMenu("Aura 2/Aura Sprite", 3)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteRenderer))]
	public class AuraSprite : MonoBehaviour
	{
		public ShadowCastingMode shadowCastingMode = ShadowCastingMode.TwoSided;

		public bool receiveShadows = true;

		private SpriteRenderer _spriteRenderer;

		public SpriteRenderer SpriteRenderer
		{
			get
			{
				if (_spriteRenderer == null)
				{
					_spriteRenderer = GetComponent<SpriteRenderer>();
					SetLitShader();
				}
				return _spriteRenderer;
			}
		}

		public Sprite Sprite
		{
			get
			{
				return SpriteRenderer.sprite;
			}
			set
			{
				SpriteRenderer.sprite = value;
			}
		}

		private void OnEnable()
		{
			if (!Aura.IsCompatible)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			SetValuesToSpriteRenderer();
		}

		private void Reset()
		{
			_spriteRenderer = null;
			shadowCastingMode = ShadowCastingMode.TwoSided;
			receiveShadows = true;
			SetValuesToSpriteRenderer();
			if (Sprite == null)
			{
				Sprite = Aura.ResourcesCollection.defaultSprite;
			}
		}

		private void SetValuesToSpriteRenderer()
		{
			SpriteRenderer.shadowCastingMode = shadowCastingMode;
			SpriteRenderer.receiveShadows = receiveShadows;
		}

		public void SetLitShader()
		{
			_spriteRenderer.sharedMaterial.shader = Aura.ResourcesCollection.spriteLitShader;
		}

		public void SetUnlitShader()
		{
			_spriteRenderer.sharedMaterial.shader = Aura.ResourcesCollection.spriteUnlitShader;
		}

		public static GameObject CreateGameObject(string name, Sprite sprite)
		{
			GameObject obj = new GameObject(name);
			obj.transform.localScale = Vector3.one * 3f;
			obj.AddComponent<AuraSprite>().Sprite = sprite;
			return obj;
		}
	}
}
