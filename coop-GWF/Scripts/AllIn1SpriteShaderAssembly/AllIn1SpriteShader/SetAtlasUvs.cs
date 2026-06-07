using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	public class SetAtlasUvs : MonoBehaviour
	{
		[SerializeField]
		private bool updateEveryFrame;

		[Tooltip("If using a Sprite Renderer it will use the material property instead of sharedMaterial")]
		[SerializeField]
		private bool useMaterialInstanceIfPossible;

		private Renderer render;

		private SpriteRenderer spriteRender;

		private Image uiImage;

		private bool isUI;

		private readonly int minXuv = Shader.PropertyToID("_MinXUV");

		private readonly int maxXuv = Shader.PropertyToID("_MaxXUV");

		private readonly int minYuv = Shader.PropertyToID("_MinYUV");

		private readonly int maxYuv = Shader.PropertyToID("_MaxYUV");

		private void Start()
		{
			Setup();
		}

		private void Reset()
		{
			Setup();
		}

		private void Setup()
		{
			if (GetRendererReferencesIfNeeded())
			{
				GetAndSetUVs();
			}
			if (!updateEveryFrame && Application.isPlaying && this != null)
			{
				base.enabled = false;
			}
		}

		private void LateUpdate()
		{
			if (updateEveryFrame)
			{
				GetAndSetUVs();
			}
		}

		public bool GetAndSetUVs()
		{
			if (!GetRendererReferencesIfNeeded())
			{
				return false;
			}
			if (!isUI)
			{
				Sprite sprite = spriteRender.sprite;
				Rect textureRect = sprite.textureRect;
				textureRect.x /= sprite.texture.width;
				textureRect.width /= sprite.texture.width;
				textureRect.y /= sprite.texture.height;
				textureRect.height /= sprite.texture.height;
				if (useMaterialInstanceIfPossible && Application.isPlaying)
				{
					render.material.SetFloat(minXuv, textureRect.xMin);
					render.material.SetFloat(maxXuv, textureRect.xMax);
					render.material.SetFloat(minYuv, textureRect.yMin);
					render.material.SetFloat(maxYuv, textureRect.yMax);
				}
				else
				{
					render.sharedMaterial.SetFloat(minXuv, textureRect.xMin);
					render.sharedMaterial.SetFloat(maxXuv, textureRect.xMax);
					render.sharedMaterial.SetFloat(minYuv, textureRect.yMin);
					render.sharedMaterial.SetFloat(maxYuv, textureRect.yMax);
				}
			}
			else
			{
				Rect textureRect2 = uiImage.sprite.textureRect;
				textureRect2.x /= uiImage.sprite.texture.width;
				textureRect2.width /= uiImage.sprite.texture.width;
				textureRect2.y /= uiImage.sprite.texture.height;
				textureRect2.height /= uiImage.sprite.texture.height;
				uiImage.material.SetFloat(minXuv, textureRect2.xMin);
				uiImage.material.SetFloat(maxXuv, textureRect2.xMax);
				uiImage.material.SetFloat(minYuv, textureRect2.yMin);
				uiImage.material.SetFloat(maxYuv, textureRect2.yMax);
			}
			return true;
		}

		public void ResetAtlasUvs()
		{
			if (!GetRendererReferencesIfNeeded())
			{
				return;
			}
			if (!isUI)
			{
				if (useMaterialInstanceIfPossible && Application.isPlaying)
				{
					render.material.SetFloat(minXuv, 0f);
					render.material.SetFloat(maxXuv, 1f);
					render.material.SetFloat(minYuv, 0f);
					render.material.SetFloat(maxYuv, 1f);
				}
				else
				{
					render.sharedMaterial.SetFloat(minXuv, 0f);
					render.sharedMaterial.SetFloat(maxXuv, 1f);
					render.sharedMaterial.SetFloat(minYuv, 0f);
					render.sharedMaterial.SetFloat(maxYuv, 1f);
				}
			}
			else
			{
				uiImage.material.SetFloat(minXuv, 0f);
				uiImage.material.SetFloat(maxXuv, 1f);
				uiImage.material.SetFloat(minYuv, 0f);
				uiImage.material.SetFloat(maxYuv, 1f);
			}
		}

		public void UpdateEveryFrame(bool everyFrame)
		{
			updateEveryFrame = everyFrame;
		}

		private bool GetRendererReferencesIfNeeded()
		{
			if (spriteRender == null)
			{
				spriteRender = GetComponent<SpriteRenderer>();
			}
			if (spriteRender != null)
			{
				if (spriteRender.sprite == null)
				{
					Object.DestroyImmediate(this);
					return false;
				}
				if (render == null)
				{
					render = GetComponent<Renderer>();
				}
				isUI = false;
			}
			else
			{
				if (uiImage == null)
				{
					uiImage = GetComponent<Image>();
					if (!(uiImage != null))
					{
						Object.DestroyImmediate(this);
						return false;
					}
				}
				if (render == null)
				{
					render = GetComponent<Renderer>();
				}
				isUI = true;
			}
			if (spriteRender == null && uiImage == null)
			{
				Object.DestroyImmediate(this);
				return false;
			}
			return true;
		}
	}
}
