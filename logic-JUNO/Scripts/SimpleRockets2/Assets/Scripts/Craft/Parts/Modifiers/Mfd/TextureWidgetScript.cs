using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Craft;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class TextureWidgetScript : WidgetScript, ITextureWidget, IFlightLateUpdate, IGameLoopItem
	{
		private bool _applyPending;

		private RawImage _image;

		private int _maxSize;

		private Texture2D _texture;

		protected override Color WidgetColor
		{
			get
			{
				return _image.color;
			}
			set
			{
				_image.color = value;
			}
		}

		public override void Destroy()
		{
			UnityEngine.Object.Destroy(_texture);
			base.Destroy();
			_applyPending = false;
		}

		public void DrawBox(int x1, int y1, int x2, int y2, Vector3 c)
		{
			Color32 value = new Color32((byte)(255f * c.x), (byte)(255f * c.y), (byte)(255f * c.z), byte.MaxValue);
			x1 = Math.Clamp(x1, 1, _texture.width);
			x2 = Math.Clamp(x2, 1, _texture.width);
			if (x2 < x1)
			{
				int num = x2;
				int num2 = x1;
				x1 = num;
				x2 = num2;
			}
			y1 = Math.Clamp(y1, 1, _texture.height);
			y2 = Math.Clamp(y2, 1, _texture.height);
			if (y2 < y1)
			{
				int num3 = y1;
				int num2 = y2;
				y2 = num3;
				y1 = num2;
			}
			int num4 = x2 - x1 + 1;
			int num5 = y2 - y1 + 1;
			Color32[] array = new Color32[num4 * num5];
			Array.Fill(array, value);
			_texture.SetPixels32(x1 - 1, y1 - 1, num4, num5, array);
			_applyPending = true;
		}

		public void DrawLine(int x1, int y1, int x2, int y2, Vector3 c)
		{
			Color32 value = new Color32((byte)(255f * c.x), (byte)(255f * c.y), (byte)(255f * c.z), byte.MaxValue);
			int width = _texture.width;
			int height = _texture.height;
			NativeArray<Color32> pixelData = _texture.GetPixelData<Color32>(0);
			int num = Math.Abs(x2 - x1);
			int num2 = Math.Abs(y2 - y1);
			int num3 = ((x1 < x2) ? 1 : (-1));
			int num4 = ((y1 < y2) ? 1 : (-1));
			int num5 = num - num2;
			bool flag = false;
			while (true)
			{
				if (x1 > 0 && x1 <= width && y1 > 0 && y1 <= height)
				{
					flag = true;
					pixelData[(y1 - 1) * width + (x1 - 1)] = value;
				}
				else if (flag)
				{
					break;
				}
				if (x1 == x2 && y1 == y2)
				{
					break;
				}
				int num6 = 2 * num5;
				if (num6 > -num2)
				{
					num5 -= num2;
					x1 += num3;
				}
				if (num6 < num)
				{
					num5 += num;
					y1 += num4;
				}
			}
			_applyPending = true;
		}

		public void DrawTri(Vector3 x, Vector3 y, Vector3 c)
		{
			Color32 color = new Color32((byte)(255f * c.x), (byte)(255f * c.y), (byte)(255f * c.z), byte.MaxValue);
			int width = _texture.width;
			int height = _texture.height;
			NativeArray<Color32> pixelData = _texture.GetPixelData<Color32>(0);
			if (y.x > y.y)
			{
				ref float x2 = ref x.x;
				ref float x3 = ref y.x;
				ref float y2 = ref x.y;
				ref float y3 = ref y.y;
				float y4 = x.y;
				float y5 = y.y;
				float x4 = x.x;
				float x5 = y.x;
				x2 = y4;
				x3 = y5;
				y2 = x4;
				y3 = x5;
			}
			if (y.x > y.z)
			{
				ref float y2 = ref x.x;
				ref float x3 = ref y.x;
				ref float x2 = ref x.z;
				ref float z = ref y.z;
				float x5 = x.z;
				float x4 = y.z;
				float y5 = x.x;
				float y4 = y.x;
				y2 = x5;
				x3 = x4;
				x2 = y5;
				z = y4;
			}
			if (y.y > y.z)
			{
				ref float x2 = ref x.y;
				ref float x3 = ref y.y;
				ref float y2 = ref x.z;
				ref float z2 = ref y.z;
				float y4 = x.z;
				float y5 = y.z;
				float x4 = x.y;
				float x5 = y.y;
				x2 = y4;
				x3 = y5;
				y2 = x4;
				z2 = x5;
			}
			float num = y.z - y.x;
			if (num != 0f)
			{
				float num2 = y.y - y.x;
				float num3 = (x.z - x.x) / num;
				if (num2 != 0f)
				{
					float num4 = (x.y - x.x) / num2;
					for (int i = (int)y.x; (float)i <= y.y; i++)
					{
						DrawSpan(pixelData, color, width, height, i, x.x + ((float)i - y.x) * num4, x.x + ((float)i - y.x) * num3);
					}
				}
				float num5 = y.z - y.y;
				if (num5 != 0f)
				{
					float num6 = (x.z - x.y) / num5;
					for (int j = (int)y.y; (float)j <= y.z; j++)
					{
						DrawSpan(pixelData, color, width, height, j, x.y + ((float)j - y.y) * num6, x.x + ((float)j - y.x) * num3);
					}
				}
			}
			_applyPending = true;
			static void DrawSpan(NativeArray<Color32> pixels, Color32 value, int texWidth, int texHeight, int num7, float startX, float endX)
			{
				if (num7 >= 1 && num7 <= texHeight)
				{
					if (startX > endX)
					{
						float num8 = startX;
						float num9 = endX;
						endX = num8;
						startX = num9;
					}
					int num10 = Math.Max(1, (int)startX);
					int num11 = Math.Min(texWidth, (int)endX);
					for (int k = num10; k <= num11; k++)
					{
						pixels[(num7 - 1) * texWidth + (k - 1)] = value;
					}
				}
			}
		}

		void IFlightLateUpdate.FlightLateUpdate(in FlightFrameData frame)
		{
			if (_applyPending)
			{
				_applyPending = false;
				_texture?.Apply();
			}
		}

		public Vector3 GetPixel(int x, int y)
		{
			if (x >= 1 && x <= _texture.width && y >= 1 && y <= _texture.height)
			{
				if (_applyPending)
				{
					_applyPending = false;
					_texture?.Apply();
				}
				Color pixel = _texture.GetPixel(x - 1, y - 1);
				return new Vector3(pixel.r, pixel.g, pixel.b);
			}
			return default(Vector3);
		}

		public override void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			base.Initialize(mfdScript, name, widgetType);
			_image = GetComponent<RawImage>();
			_maxSize = mfdScript.Data.MaxTextureSize;
		}

		public void Initialize(int width, int height)
		{
			if (width > _maxSize || height > _maxSize)
			{
				throw new Exception($"Texture cannot exceed maximum edge size of {_maxSize}");
			}
			_texture = new Texture2D(width, height);
			_texture.wrapMode = TextureWrapMode.Clamp;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					_texture.SetPixel(i, j, UnityEngine.Color.white);
				}
			}
			_applyPending = true;
			_image.texture = _texture;
		}

		public override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			int intAttribute = xml.GetIntAttribute("width");
			int intAttribute2 = xml.GetIntAttribute("height");
			if (intAttribute > 0 && intAttribute2 > 0)
			{
				Initialize(intAttribute, intAttribute2);
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			if (_texture != null)
			{
				WidgetScript.SetAttribute(xml, "width", _texture.width);
				WidgetScript.SetAttribute(xml, "height", _texture.height);
			}
		}

		public void SetPixel(int x, int y, Vector3 c)
		{
			if (x >= 1 && x <= _texture.width && y >= 1 && y <= _texture.height)
			{
				_texture.SetPixel(x - 1, y - 1, new Color(c.x, c.y, c.z));
				_applyPending = true;
			}
		}

		protected override void SetRaycastTarget(bool enabled)
		{
			base.SetRaycastTarget(enabled);
			_image.raycastTarget = enabled;
		}
	}
}
