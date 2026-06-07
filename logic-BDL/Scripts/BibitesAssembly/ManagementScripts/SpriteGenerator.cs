using System;
using System.IO;
using SettingScripts;
using StandaloneFileBrowser;
using UIScripts;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace ManagementScripts
{
	public class SpriteGenerator : MonoBehaviour
	{
		private ProceduralGenePreviewer preview;

		public static SpriteGenerator instance;

		private string savePath;

		private bool saveImage;

		public Material bodyMat;

		public Material eyeMat;

		[NonSerialized]
		public UnityEvent<string, bool> onSpriteGenerated = new UnityEvent<string, bool>();

		private static readonly Color clear = new Color(0f, 0f, 0f, 0f);

		private Color background;

		private float? imageAspect;

		private int pixelRatio;

		private int padding;

		private SpriteRenderer bodySprite;

		private SpriteRenderer mouthSprite;

		private SpriteRenderer armSprite;

		private SpriteRenderer exoSprite;

		private SpriteRenderer eyeSprite;

		private void Awake()
		{
			instance = this;
		}

		private void OnEnable()
		{
			RenderPipelineManager.endCameraRendering += Render;
		}

		private void OnDisable()
		{
			RenderPipelineManager.endCameraRendering -= Render;
		}

		private void Render(ScriptableRenderContext arg1, Camera arg2)
		{
			if (saveImage)
			{
				BuildAndSaveSprite();
				saveImage = false;
			}
		}

		public void SaveSpriteOfPreview(ProceduralGenePreviewer previewer, string path = null, Color backgroundColor = default(Color), float? aspectRatio = null, int? pixelScale = null, int padd = 0)
		{
			bodySprite = previewer.BodyImage;
			mouthSprite = previewer.MouthImage;
			armSprite = previewer.Arm1Image;
			exoSprite = previewer.ExoskeletonImage;
			eyeSprite = previewer.EyesImage;
			SaveSprite(path, backgroundColor, aspectRatio, pixelScale, padd);
		}

		public void SaveSpriteOfPreview(BibiteTemplateGenePreviewer previewer, string path = null, Color backgroundColor = default(Color), float? aspectRatio = null, int? pixelScale = null, int padd = 0)
		{
			bodySprite = previewer.BodyImage;
			mouthSprite = previewer.MouthImage;
			armSprite = previewer.Arm1Image;
			exoSprite = previewer.ExoskeletonImage;
			eyeSprite = previewer.EyesImage;
			SaveSprite(path, backgroundColor, aspectRatio, pixelScale, padd);
		}

		private void SaveSprite(string path = null, Color backgroundColor = default(Color), float? aspectRatio = null, int? pixelScale = null, int padd = 0)
		{
			if (path == null)
			{
				string text = UserSettings.SpriteGeneratorSavePath.val;
				if (string.IsNullOrEmpty(text))
				{
					text = Application.persistentDataPath;
				}
				savePath = global::StandaloneFileBrowser.StandaloneFileBrowser.SaveFilePanel("Save sprite", text, "bibite_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png", new ExtensionFilter[1]
				{
					new ExtensionFilter("Image file", "png")
				});
				if (savePath == "")
				{
					return;
				}
				int num = savePath.LastIndexOf("\\", StringComparison.InvariantCulture);
				UserSettings.SpriteGeneratorSavePath.SetValue(savePath.Substring(0, num + 1));
			}
			else
			{
				savePath = path;
			}
			background = backgroundColor;
			imageAspect = aspectRatio;
			pixelRatio = pixelScale ?? SpriteGeneratorSettings.ImageRatio.val;
			padding = padd;
			saveImage = true;
		}

		private void BuildAndSaveSprite()
		{
			SpriteRenderer spriteRenderer = bodySprite;
			SpriteRenderer spriteRenderer2 = mouthSprite;
			SpriteRenderer spriteRenderer3 = armSprite;
			SpriteRenderer spriteRenderer4 = eyeSprite;
			SpriteRenderer spriteRenderer5 = exoSprite;
			Vector2Int vector2Int = new Vector2Int((int)spriteRenderer.sprite.rect.width, (int)spriteRenderer.sprite.rect.height);
			Vector2Int vector2Int2 = new Vector2Int((int)spriteRenderer2.sprite.rect.width, (int)spriteRenderer2.sprite.rect.height);
			Vector2Int vector2Int3 = new Vector2Int((int)spriteRenderer3.sprite.rect.width, (int)spriteRenderer3.sprite.rect.height);
			Vector2Int vector2Int4 = new Vector2Int((int)spriteRenderer4.sprite.rect.width, (int)spriteRenderer4.sprite.rect.height);
			Vector2Int vector2Int5 = new Vector2Int((int)spriteRenderer5.sprite.rect.width, (int)spriteRenderer5.sprite.rect.height);
			int num = vector2Int.x + vector2Int2.x;
			int num2 = vector2Int.y + 2 * vector2Int3.y;
			int num3 = padding;
			int num4 = padding;
			if (imageAspect.HasValue)
			{
				float num5 = (float)num / (float)num2;
				float valueOrDefault = imageAspect.GetValueOrDefault();
				if (num5 > imageAspect)
				{
					num3 += Mathf.RoundToInt(((float)num / valueOrDefault - (float)num2) / 2f);
				}
				else
				{
					num4 += Mathf.RoundToInt(((float)num2 * valueOrDefault - (float)num) / 2f);
				}
			}
			num2 += 2 * num3;
			num += 2 * num4;
			Texture2D texture2D = new Texture2D(num, num2, TextureFormat.ARGB32, mipChain: false)
			{
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Clamp
			};
			Color[] array = new Color[num * num2];
			for (int i = 0; i < num * num2; i++)
			{
				array[i] = background;
			}
			texture2D.SetPixels(0, 0, num, num2, array);
			texture2D.SetPixels(num4, vector2Int3.y + num3, vector2Int.x, vector2Int.y, LoadSpritePixels(spriteRenderer));
			texture2D.SetPixels(vector2Int.x + num4, (num2 - vector2Int2.y) / 2, vector2Int2.x, vector2Int2.y, LoadSpritePixels(spriteRenderer2));
			Color[] array2 = LoadSpritePixels(spriteRenderer3);
			texture2D.SetPixels(vector2Int.x - vector2Int3.x + num4, vector2Int.y + vector2Int3.y + num3, vector2Int3.x, vector2Int3.y, array2);
			Color[] array3 = new Color[array2.Length];
			for (int j = 0; j < vector2Int3.y; j++)
			{
				int num6 = vector2Int3.y - 1 - j;
				for (int k = 0; k < vector2Int3.x; k++)
				{
					array3[num6 * vector2Int3.x + k] = array2[j * vector2Int3.x + k];
				}
			}
			texture2D.SetPixels(vector2Int.x - vector2Int3.x + num4, num3, vector2Int3.x, vector2Int3.y, array3);
			texture2D.Apply();
			texture2D.SetPixelsWithAlpha(num4, (num2 - vector2Int5.y) / 2, vector2Int5.x, vector2Int5.y, LoadSpritePixels(spriteRenderer5, clearBG: true));
			texture2D.SetPixelsWithAlpha(num - vector2Int4.x - num4, (num2 - vector2Int4.y) / 2, vector2Int4.x, vector2Int4.y, LoadSpritePixels(spriteRenderer4, clearBG: true));
			byte[] bytes = ScaleTexture2D(texture2D, SpriteGeneratorSettings.ImageRatio.val).EncodeToPNG();
			try
			{
				File.WriteAllBytes(savePath, bytes);
			}
			catch (Exception ex)
			{
				PopupManager.DisplayError("System.IO", ex.Message);
			}
			UnityEngine.Object.DestroyImmediate(texture2D);
		}

		private Color[] LoadSpritePixels(SpriteRenderer sr, bool clearBG = false)
		{
			Sprite sprite = sr.sprite;
			Vector2Int vector2Int = new Vector2Int((int)sprite.textureRect.width, (int)sprite.textureRect.height);
			Material material = (sr.sharedMaterial.HasProperty("_hueShift") ? eyeMat : bodyMat);
			material.CopyMatchingPropertiesFromMaterial(sr.sharedMaterial);
			Color[] pixels = sprite.texture.GetPixels((int)sprite.textureRect.x, (int)sprite.textureRect.y, vector2Int.x, vector2Int.y);
			Texture2D texture2D = new Texture2D(vector2Int.x, vector2Int.y, TextureFormat.RGBA32, mipChain: false);
			texture2D.SetPixels(pixels);
			texture2D.Apply();
			RenderTexture temporary = RenderTexture.GetTemporary(vector2Int.x, vector2Int.y, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
			temporary.dimension = TextureDimension.Tex2D;
			temporary.filterMode = FilterMode.Point;
			temporary.wrapMode = TextureWrapMode.Clamp;
			Graphics.SetRenderTarget(temporary);
			Graphics.Blit(texture2D, temporary, material, 0);
			Texture2D texture2D2 = new Texture2D(vector2Int.x, vector2Int.y, TextureFormat.RGBA32, mipChain: false);
			texture2D2.ReadPixels(new Rect(0f, 0f, vector2Int.x, vector2Int.y), 0, 0, recalculateMipMaps: false);
			texture2D2.Apply();
			Color[] pixels2 = texture2D2.GetPixels();
			for (int i = 0; i < pixels2.Length; i++)
			{
				if (!clearBG && pixels[i].a < 0.01f)
				{
					pixels2[i] = background;
				}
				else
				{
					pixels2[i].a = pixels[i].a;
				}
			}
			RenderTexture.active = null;
			temporary.Release();
			UnityEngine.Object.DestroyImmediate(texture2D);
			return pixels2;
		}

		private Texture2D ScaleTexture2D(Texture2D tex, int scale)
		{
			Color[] pixels = tex.GetPixels();
			int width = tex.width;
			Color[] array = new Color[pixels.Length * scale * scale];
			for (int i = 0; i < pixels.Length; i++)
			{
				for (int j = 0; j < scale; j++)
				{
					for (int k = 0; k < scale; k++)
					{
						array[i % width * scale + i / width * width * scale * scale + j * width * scale + k] = pixels[i];
					}
				}
			}
			Texture2D texture2D = new Texture2D(tex.width * scale, tex.height * scale);
			texture2D.SetPixels(array);
			return texture2D;
		}
	}
}
