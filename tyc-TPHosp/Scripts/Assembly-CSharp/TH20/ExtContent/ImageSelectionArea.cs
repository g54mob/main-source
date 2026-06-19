using System;

namespace TH20.ExtContent
{
	[DontSave]
	public class ImageSelectionArea
	{
		private float _centreX;

		private float _centreY;

		private float _W;

		private float _H;

		public float CentreX
		{
			get
			{
				return _centreX;
			}
			set
			{
				_centreX = value;
			}
		}

		public float CentreY
		{
			get
			{
				return _centreY;
			}
			set
			{
				_centreY = value;
			}
		}

		public float W
		{
			get
			{
				return _W;
			}
			set
			{
				_W = value;
			}
		}

		public float H
		{
			get
			{
				return _H;
			}
			set
			{
				_H = value;
			}
		}

		public float AspectRatio => _W / _H;

		public ImageSelectionArea()
		{
			Reset();
		}

		public void Reset()
		{
			Set(0.5f, 0.5f, 1f, 1f);
		}

		public void Set(float centreX, float centreY, float w, float h)
		{
			_centreX = centreX;
			_centreY = centreY;
			_W = w;
			_H = h;
		}

		public void ScaleToFitAspectRatios(float parentAspectRatio, float reqdAspectRatio)
		{
			float outTargetW = 0f;
			float outTargetH = 0f;
			float num = 100f;
			float parentH = num / parentAspectRatio;
			ExtContentTextureUtils.ScaleDimensionsToFitParentMaintainingAspectRatio(reqdAspectRatio, num, parentH, ref outTargetW, ref outTargetH);
			Set(0.5f, 0.5f, outTargetW, outTargetH);
		}

		public void Renormalise(float curParentW, float curParentH, float newParentW, float newParentH)
		{
			float num = curParentW / newParentW;
			float num2 = curParentH / newParentH;
			Set((_centreX - 0.5f) * num + 0.5f, (_centreY - 0.5f) * num2 + 0.5f, _W * num, _H * num2);
		}

		public void RotateWithinParentMaintainingAspectRatio(float parentAspectRatio, int rotationCount)
		{
			float centreX = _centreX;
			float centreY = _centreY;
			float w = _W;
			float h = _H;
			float num = 100f;
			float num2 = num / parentAspectRatio;
			centreX *= num;
			centreY *= num2;
			w *= num;
			h *= num2;
			if (rotationCount != 0 && (_centreX != 0.5f || _centreY != 0.5f))
			{
				float num3 = centreX;
				float num4 = centreY;
				float num5 = num2;
				float num6 = num;
				float num7 = num2;
				float num8 = num * 0.5f;
				float num9 = num5 * 0.5f;
				float num10 = num6 * 0.5f;
				float num11 = num7 * 0.5f;
				float num12 = 0f;
				float num13 = 0f;
				switch (rotationCount)
				{
				case 0:
					num12 = num3;
					num13 = num4;
					break;
				case 1:
					num12 = num4 - num9 + num10;
					num13 = 0f - (num3 - num8) + num11;
					break;
				case 2:
					num12 = 0f - (num3 - num8) + num10;
					num13 = 0f - (num4 - num9) + num11;
					break;
				case 3:
					num12 = 0f - (num4 - num9) + num10;
					num13 = num3 - num8 + num11;
					break;
				}
				centreX = num12;
				centreY = num13;
			}
			if (!IsCentreValidForSize(centreX, centreY, w, h, num, num2))
			{
				ValidatePositionForWidthAndHeight(ref centreX, ref centreY, w, h, num, num2);
			}
			centreX /= num;
			centreY /= num2;
			w /= num;
			h /= num2;
			if (IsCentreValidForSizeNorm(centreX, centreY, w, h))
			{
				Set(centreX, centreY, w, h);
			}
			else
			{
				Invalidate();
			}
		}

		public bool IsFullAreaSelected()
		{
			if (_centreX == 0.5f && _centreY == 0.5f && _W == 1f)
			{
				return _H == 1f;
			}
			return false;
		}

		public void Invalidate()
		{
			Set(0f, 0f, 0f, 0f);
		}

		public bool IsValid()
		{
			if (_W != 0f)
			{
				return _H != 0f;
			}
			return false;
		}

		public bool IsCentreValidForSize()
		{
			return IsCentreValidForSizeNorm(_centreX, _centreY, _W, _H);
		}

		public bool IsCentreValidForSizeNorm(float centreX, float centreY, float W, float H)
		{
			return IsCentreValidForSize(centreX, centreY, W, H, 1f, 1f);
		}

		public bool IsCentreValidForSize(float centreX, float centreY, float W, float H, float parentW, float parentH)
		{
			bool result = true;
			float num = W * 0.5f;
			float num2 = H * 0.5f;
			if (centreX - num < 0f)
			{
				result = false;
			}
			else if (centreX + num > parentW)
			{
				result = false;
			}
			if (centreY - num2 < 0f)
			{
				result = false;
			}
			else if (centreY + num2 > parentH)
			{
				result = false;
			}
			return result;
		}

		private bool ValidatePositionForWidthAndHeight(ref float cx, ref float cy, float selW, float selH, float parentW, float parentH)
		{
			float num = cx;
			float num2 = cy;
			float num3 = selW * 0.5f;
			float num4 = selH * 0.5f;
			if (cx - num3 < 0f)
			{
				cx = num3;
			}
			else if (cx + num3 > parentW)
			{
				cx = parentW - num3;
			}
			if (cy - num4 < 0f)
			{
				cy = num4;
			}
			else if (cy + num4 > parentH)
			{
				cy = parentH - num4;
			}
			if (cx == num)
			{
				return cy != num2;
			}
			return true;
		}

		public string ToParamString()
		{
			return $"X:{_centreX}, Y:{_centreY}, W:{_W}, H:{_H}";
		}

		public void FromParamString(string sourceSelectionAreaStr)
		{
			string[] array = sourceSelectionAreaStr.Split(new string[2] { ", ", ":" }, StringSplitOptions.None);
			if (array.Length >= 8)
			{
				Set((float)Convert.ToDecimal(array[1]), (float)Convert.ToDecimal(array[3]), (float)Convert.ToDecimal(array[5]), (float)Convert.ToDecimal(array[7]));
			}
		}

		public void UpdateFrom(ImageSelectionArea otherSelectionArea)
		{
			Set(otherSelectionArea.CentreX, otherSelectionArea.CentreY, otherSelectionArea.W, otherSelectionArea.H);
		}

		public bool IsEqualTo(ImageSelectionArea other)
		{
			if (MathUtils.Approximately(CentreX, other.CentreX, 0.0001f) && MathUtils.Approximately(CentreY, other.CentreY, 0.0001f) && MathUtils.Approximately(W, other.W, 0.0001f))
			{
				return MathUtils.Approximately(H, other.H, 0.0001f);
			}
			return false;
		}
	}
}
