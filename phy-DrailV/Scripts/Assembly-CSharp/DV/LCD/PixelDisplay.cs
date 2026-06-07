using System;
using UnityEngine;

namespace DV.LCD
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(MeshRenderer))]
	public class PixelDisplay : MonoBehaviour
	{
		public delegate void ColorOperator(int x, int y, ref Color32 pixel);

		private Color32[] pixels;

		[SerializeField]
		private Vector2Int resolution = new Vector2Int(16, 16);

		[SerializeField]
		private FilterMode filterMode;

		[SerializeField]
		private TextureFormat format = TextureFormat.RGBA32;

		[SerializeField]
		private bool mipChain = true;

		public bool autoAssignToRenderer = true;

		[SerializeField]
		private string propertyName = "_EmissionMap";

		[SerializeField]
		private int materialIndex = -1;

		[SerializeField]
		private string colorPropertyToOverride = "_EmissionColor";

		[SerializeField]
		private Color colorOverride = Color.white;

		public bool releaseTextureOnDisabled = true;

		private bool hasChanged = true;

		public Color32[] Pixels => pixels;

		public Vector2Int Resolution => resolution;

		public Texture2D Texture { get; private set; }

		private void Awake()
		{
			pixels = new Color32[resolution.x * resolution.y];
		}

		private void OnEnable()
		{
			if (Texture == null)
			{
				hasChanged = true;
				Texture = new Texture2D(resolution.x, resolution.y, format, mipChain)
				{
					filterMode = filterMode
				};
				if (autoAssignToRenderer && TryGetComponent<Renderer>(out var component))
				{
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					materialPropertyBlock.SetTexture(propertyName, Texture);
					if (!string.IsNullOrEmpty(propertyName))
					{
						materialPropertyBlock.SetColor(colorPropertyToOverride, colorOverride);
					}
					if (materialIndex >= 0)
					{
						component.SetPropertyBlock(materialPropertyBlock, materialIndex);
					}
					else
					{
						component.SetPropertyBlock(materialPropertyBlock);
					}
				}
			}
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(BeforeRender));
		}

		private void OnDisable()
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(BeforeRender));
			if (releaseTextureOnDisabled)
			{
				OnDestroy();
			}
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(Texture);
			Texture = null;
		}

		public void SetResolution(int width, int height)
		{
			if (resolution.x != width || resolution.y != height)
			{
				bool flag = base.enabled;
				base.enabled = false;
				resolution.x = width;
				resolution.y = height;
				pixels = new Color32[width * height];
				OnDestroy();
				base.enabled = flag;
			}
		}

		public void Clear(Color32 color)
		{
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = color;
			}
			MarkChanged();
		}

		public void Fill(int x, int y, int width, int height, Color32 color)
		{
			int num = x + width;
			int num2 = y + height;
			int width2 = Texture.width;
			for (int i = y; i < num2; i++)
			{
				for (int j = x; j < num; j++)
				{
					pixels[j + i * width2] = color;
				}
			}
			MarkChanged();
		}

		public void Fill(int x, int y, int width, int height, ColorOperator color)
		{
			int num = x + width;
			int num2 = y + height;
			int width2 = Texture.width;
			for (int i = y; i < num2; i++)
			{
				for (int j = x; j < num; j++)
				{
					color(j, i, ref pixels[j + i * width2]);
				}
			}
			MarkChanged();
		}

		public void DrawLine(int xStart, int yStart, int xEnd, int yEnd, Color32 color)
		{
			DrawLine(xStart, yStart, xEnd, yEnd, ColorOperator);
			void ColorOperator(int x, int y, ref Color32 pixel)
			{
				pixel = color;
			}
		}

		public void DrawLine(int xStart, int yStart, int xEnd, int yEnd, ColorOperator color)
		{
			int num = Mathf.Abs(xEnd - xStart);
			int num2 = Mathf.Abs(yEnd - yStart);
			int num3 = ((xStart < xEnd) ? 1 : (-1));
			int num4 = ((yStart < yEnd) ? 1 : (-1));
			int num5 = num - num2;
			int width = Texture.width;
			while (true)
			{
				color(xStart, yStart, ref pixels[xStart + yStart * width]);
				if (xStart == xEnd && yStart == yEnd)
				{
					break;
				}
				int num6 = 2 * num5;
				if (num6 >= -num2)
				{
					num5 -= num2;
					xStart += num3;
				}
				if (num6 <= num)
				{
					num5 += num;
					yStart += num4;
				}
			}
			MarkChanged();
		}

		public void DrawImage(int x, int y, Color32[] pixels, int width, int height)
		{
			Fill(x, y, width, height, ColorOperator);
			void ColorOperator(int z, int w, ref Color32 pixel)
			{
				pixel = pixels[z - x + (w - y) * width];
			}
		}

		public void SetOne(int x, int y, Color32 color)
		{
			pixels[x + y * Texture.width] = color;
			MarkChanged();
		}

		public void SetOne(int x, int y, ColorOperator color)
		{
			color(x, y, ref pixels[x + y * Texture.width]);
			MarkChanged();
		}

		public void MarkChanged()
		{
			hasChanged = true;
		}

		private void BeforeRender(object _)
		{
			if (hasChanged)
			{
				ApplyChangesNow();
			}
		}

		public void ApplyChangesNow()
		{
			Texture.SetPixels32(pixels);
			Texture.Apply();
			hasChanged = false;
		}
	}
}
