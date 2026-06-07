using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIProgressBar : MaskableGraphic
{
	private enum Slice
	{
		Top = 0,
		TopRight = 1,
		TopLeft = 2,
		MiddleRight = 3,
		Middle = 4,
		MiddleLeft = 5,
		Bottom = 6,
		BottomRight = 7,
		BottomLeft = 8
	}

	[SerializeField]
	private float _value = 0.5f;

	[SerializeField]
	private float _lowValue;

	[SerializeField]
	private bool _hasLowValue;

	[NonSerialized]
	private float? _altValue;

	[NonSerialized]
	private float? _indValue;

	public Color StartColor;

	public Color EndColor;

	public Color EndExt;

	public Color IndColor;

	public bool FromCenter;

	public bool NoCenterColor;

	public bool StartMidColor;

	public bool OnlyUseStart;

	public bool LerpFull;

	public bool Animated;

	[NonSerialized]
	private float _currentValue;

	[NonSerialized]
	private bool _first = true;

	[NonSerialized]
	private bool _dirty = true;

	[NonSerialized]
	private List<UIVertex> _cache = new List<UIVertex>();

	[NonSerialized]
	private Vector2 _lastSize;

	[SerializeField]
	private Sprite MainTex;

	private static Vector2[] _slicePos = new Vector2[9]
	{
		new Vector2(0f, -1f),
		new Vector2(1f, -1f),
		new Vector2(-1f, -1f),
		new Vector2(1f, 0f),
		new Vector2(0f, 0f),
		new Vector2(-1f, 0f),
		new Vector2(0f, 1f),
		new Vector2(1f, 1f),
		new Vector2(-1f, 1f)
	};

	public float Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (_first)
			{
				_first = false;
			}
			else if (_value == value)
			{
				return;
			}
			_value = Mathf.Clamp(value, FromCenter ? (-1) : 0, 1f);
			_dirty = true;
			SetVerticesDirty();
		}
	}

	public float? LowValue
	{
		get
		{
			if (!_hasLowValue)
			{
				return null;
			}
			return _lowValue;
		}
		set
		{
			if (value.HasValue)
			{
				if (_hasLowValue && _lowValue == value.Value)
				{
					return;
				}
				_lowValue = value.Value;
				_hasLowValue = true;
			}
			else
			{
				_lowValue = 0f;
				if (!_hasLowValue)
				{
					return;
				}
				_hasLowValue = false;
			}
			_dirty = true;
			SetVerticesDirty();
		}
	}

	public float? AltValue
	{
		get
		{
			return _altValue;
		}
		set
		{
			_altValue = value;
			_dirty = true;
			SetVerticesDirty();
		}
	}

	public float? IndValue
	{
		get
		{
			return _indValue;
		}
		set
		{
			_indValue = value;
			_dirty = true;
			SetVerticesDirty();
		}
	}

	public Sprite MySprite
	{
		get
		{
			return MainTex;
		}
		set
		{
			MainTex = value;
			_dirty = true;
			SetMaterialDirty();
			SetVerticesDirty();
		}
	}

	public override Texture mainTexture
	{
		get
		{
			if (!(MainTex != null))
			{
				return base.mainTexture;
			}
			return MainTex.texture;
		}
	}

	public void ResetAnimation(float value = 0f)
	{
		_currentValue = value;
	}

	public void SetDirty()
	{
		_dirty = true;
		SetVerticesDirty();
	}

	public static void Draw9Slice(Vector2 corner1, Vector2 corner2, Vector4 b, Color color, VertexHelper vh)
	{
		float num = corner2.y - corner1.y;
		if (num < b.y + b.w)
		{
			b = new Vector4(num / 2f, num / 2f, num / 2f, num / 2f);
		}
		List<UIVertex> list = new List<UIVertex>();
		DrawEndSlice(new Rect(corner1.x, corner1.y, b.x, num), color, color, true, b, list, true);
		DrawCenterSlice(new Rect(corner1.x + b.x, corner1.y, corner2.x - corner1.x - (b.x + b.z), num), color, color, b, list, true);
		DrawEndSlice(new Rect(corner2.x - b.z, corner1.y, b.z, num), color, color, false, b, list, true);
		Utilities.VBOToHelper(list, vh);
	}

	public Vector4 FixBorder(Vector4 b)
	{
		return new Vector4(b.x, b.w, b.z, b.y);
	}

	protected override void OnRectTransformDimensionsChange()
	{
		if (_lastSize != base.rectTransform.rect.size)
		{
			_dirty = true;
			_lastSize = base.rectTransform.rect.size;
		}
		base.OnRectTransformDimensionsChange();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (!_dirty)
		{
			Utilities.VBOToHelper(_cache, vh);
			return;
		}
		_cache.Clear();
		_dirty = false;
		Vector2 vector = new Vector2((0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
		Vector2 vector2 = new Vector2((1f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (1f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
		Vector4 b = ((MainTex != null) ? FixBorder(MainTex.border) : Vector4.zero);
		float num = vector2.y - vector.y;
		if (num < b.y + b.w)
		{
			float num2 = num / (b.y + b.w);
			b = new Vector4(b.x * num2, b.y, b.z * num2, b.w);
		}
		DrawEndSlice(new Rect(vector.x, vector.y, b.x, num), this.color, this.color, true, b, _cache, false);
		DrawCenterSlice(new Rect(vector.x + b.x, vector.y, vector2.x - vector.x - (b.x + b.z), num), this.color, this.color, b, _cache, false);
		DrawEndSlice(new Rect(vector2.x - b.z, vector.y, b.z, num), this.color, this.color, false, b, _cache, false);
		float num3 = (Animated ? _currentValue : Value);
		vector = new Vector2(vector.x + 2f, vector.y + 2f);
		vector2 = new Vector2(vector2.x - 2f, vector2.y - 2f);
		float num4 = vector2.x - vector.x;
		bool flag = Mathf.Approximately(num3, 0f);
		if (!flag || (!FromCenter && AltValue.HasValue && !Mathf.Approximately(AltValue.Value, 0f)))
		{
			if (FromCenter)
			{
				if (num3 < 0f)
				{
					float t = 1f + num3;
					DrawRectSlice(new Rect(vector.x, vector.y, num4 / 2f, vector2.y - vector.y), NoCenterColor ? StartColor : Color.Lerp(EndExt, StartColor, t), StartColor, 0f - num3, 0f, true, false, true);
				}
				else
				{
					DrawRectSlice(new Rect(vector.x + num4 / 2f, vector.y, num4 / 2f, vector2.y - vector.y), NoCenterColor ? EndColor : StartColor, NoCenterColor ? EndColor : Color.Lerp(StartColor, EndColor, num3), num3, 0f, false, true);
				}
			}
			else
			{
				if (!flag || _hasLowValue)
				{
					if (OnlyUseStart)
					{
						DrawRectSlice(new Rect(vector.x, vector.y, num4, vector2.y - vector.y), StartColor, StartColor, num3, _lowValue, true, true);
					}
					else if (LerpFull)
					{
						DrawRectSlice(new Rect(vector.x, vector.y, num4, vector2.y - vector.y), Color.Lerp(StartColor, EndColor, _lowValue), Color.Lerp(StartColor, EndColor, num3), num3, _lowValue, true, true);
					}
					else
					{
						Color color = Color.Lerp(StartColor, EndColor, _hasLowValue ? ((_lowValue + num3) * 0.5f) : num3);
						DrawRectSlice(new Rect(vector.x, vector.y, num4, vector2.y - vector.y), color, color, num3, _lowValue, true, true);
					}
				}
				if (AltValue.HasValue && !Mathf.Approximately(AltValue.Value, 0f))
				{
					if (AltValue.Value > num3)
					{
						Color color2 = new Color(0.8f, 0.8f, 0.8f, 0.8f);
						DrawRect(new Vector2(vector.x + num4 * num3, vector.y + 4f), new Vector2(vector.x + num4 * AltValue.Value, vector2.y - 4f), Slice.Middle, 1f, color2, color2, _cache, 1f, 1f, true);
					}
					else
					{
						Color color3 = new Color(1f, 1f, 1f, 0.8f);
						DrawRect(new Vector2(vector.x, vector.y + 4f), new Vector2(vector.x + num4 * AltValue.Value, vector2.y - 4f), Slice.Middle, 1f, color3, color3, _cache, 1f, 1f, true);
					}
				}
			}
		}
		if (IndValue.HasValue)
		{
			DrawRect(new Vector2(vector.x + num4 * IndValue.Value - 2f, vector.y), new Vector2(vector.x + num4 * IndValue.Value + 2f, vector2.y), Slice.Middle, 1f, IndColor, IndColor, _cache, 1f, 1f, true);
		}
		Utilities.VBOToHelper(_cache, vh);
	}

	private void DrawRectSlice(Rect r, Color c, Color c2, float p, float lowP, bool start, bool end, bool reverse = false)
	{
		p = Mathf.Clamp01(p);
		lowP = Mathf.Clamp(lowP, 0f, p);
		float num = (p - lowP) * r.width;
		float num2 = r.xMin + r.width * lowP;
		float num3 = num2 + num;
		float num4 = 0f;
		if (lowP > 0f && num < 6f)
		{
			num = 6f;
			num2 = Mathf.Max(r.xMin, num2 - 3f);
			if (num2 + num > r.xMax)
			{
				num2 = r.xMax - 6f;
			}
		}
		if (MainTex == null)
		{
			if (reverse)
			{
				DrawCenterSlice(new Rect(num2 + (r.width - num), r.y, num, r.height), c, c2, Vector4.zero, _cache, true);
			}
			else
			{
				DrawCenterSlice(new Rect(num2, r.y, num, r.height), c, c2, Vector4.zero, _cache, true);
			}
			return;
		}
		Vector4 b = FixBorder(MainTex.border);
		float height = r.height;
		if (height < b.y + b.w)
		{
			float num5 = height / (b.y + b.w);
			b = new Vector4(b.x * num5, b.y, b.z * num5, b.w);
		}
		if (start)
		{
			if (lowP > 0f)
			{
				if (num2 - r.xMin < b.x)
				{
					float t = b.x / num;
					Color color = Color.Lerp(c, c2, t);
					DrawEndSlice(new Rect(num2, r.y, b.x - (num2 - r.xMin), r.height), c, color, true, b, _cache, true, true);
					num -= b.x - (num2 - r.xMin);
					num2 = r.xMin + b.x;
					c = color;
				}
				if (num3 - r.xMin < b.x)
				{
					return;
				}
			}
			else if (!reverse)
			{
				if (num < b.x)
				{
					DrawEndSlice(new Rect(r.x, r.y, num, r.height), c, c2, true, b, _cache, true);
					return;
				}
				num4 += b.x;
				float t2 = b.x / num;
				Color color2 = Color.Lerp(c, c2, t2);
				DrawEndSlice(new Rect(r.x, r.y, b.x, r.height), c, color2, true, b, _cache, true);
				num2 += b.x;
				c = color2;
			}
		}
		if (end && lowP > 0f && r.xMax - num2 < b.z)
		{
			DrawEndSlice(new Rect(num2, r.y, r.xMax - num2, r.height), c, c2, false, b, _cache, true, true);
		}
		else if (reverse)
		{
			if (start && r.width - num < b.x)
			{
				float num6 = b.x - (r.width - num);
				float num7 = r.width - b.x;
				Color color3 = Color.Lerp(c, c2, num6 / num);
				DrawEndSlice(new Rect(r.x + (b.x - num6), r.y, num6, r.height), c, color3, true, b, _cache, true, true);
				c = color3;
				DrawCenterSlice(new Rect(r.xMax - num7, r.y, num7, r.height), c, c2, b, _cache, true);
			}
			else
			{
				DrawCenterSlice(new Rect(r.xMax - num, r.y, num - num4, r.height), c, c2, b, _cache, true);
			}
		}
		else if (end && r.xMax - num3 < b.z)
		{
			float num8 = b.z - (r.xMax - num3);
			Color color4 = Color.Lerp(c, c2, 1f - num8 / num);
			float num9 = ((lowP > 0f) ? (num2 - r.xMin) : 0f);
			DrawCenterSlice(new Rect(num2, r.y, r.width - b.z - num4 - num9, r.height), c, color4, b, _cache, true);
			c = color4;
			DrawEndSlice(new Rect(r.xMax - b.z, r.y, num8, r.height), c, c2, false, b, _cache, true);
		}
		else
		{
			DrawCenterSlice(new Rect(num2, r.y, num - num4, r.height), c, c2, b, _cache, true);
		}
	}

	private static void DrawEndSlice(Rect r, Color c, Color c2, bool left, Vector4 b, List<UIVertex> cache, bool disableGrad, bool reverse = false)
	{
		float num = (left ? b.x : b.z);
		float p = r.width / num;
		if (r.height < b.y + b.w)
		{
			float num2 = b.w / (b.y + b.w);
			DrawRect(new Vector2(r.xMin, r.yMin), new Vector2(r.xMax, r.yMin + r.height * num2), (!left) ? Slice.TopRight : Slice.TopLeft, p, c, c2, cache, 0f, num2, disableGrad, reverse);
			DrawRect(new Vector2(r.xMin, r.yMin + r.height * num2), new Vector2(r.xMax, r.yMax), left ? Slice.BottomLeft : Slice.BottomRight, p, c, c2, cache, num2, 1f, disableGrad, reverse);
			return;
		}
		if (b.w > 0f)
		{
			DrawRect(new Vector2(r.xMin, r.yMin), new Vector2(r.xMax, r.yMin + b.w), (!left) ? Slice.TopRight : Slice.TopLeft, p, c, c2, cache, 0f, b.w / r.height, disableGrad, reverse);
		}
		DrawRect(new Vector2(r.xMin, r.yMin + b.w), new Vector2(r.xMax, r.yMax - b.y), left ? Slice.MiddleLeft : Slice.MiddleRight, p, c, c2, cache, b.w / r.height, (r.height - b.y) / r.height, disableGrad, reverse);
		if (b.y > 0f)
		{
			DrawRect(new Vector2(r.xMin, r.yMax - b.y), new Vector2(r.xMax, r.yMax), left ? Slice.BottomLeft : Slice.BottomRight, p, c, c2, cache, (r.height - b.y) / r.height, 1f, disableGrad, reverse);
		}
	}

	private static void DrawCenterSlice(Rect r, Color c, Color c2, Vector4 b, List<UIVertex> cache, bool disableGrad)
	{
		if (r.height < b.y + b.w)
		{
			float num = b.w / (b.y + b.w);
			DrawRect(new Vector2(r.xMin, r.yMin), new Vector2(r.xMax, r.yMin + r.height * num), Slice.Top, 1f, c, c2, cache, 0f, num, disableGrad);
			DrawRect(new Vector2(r.xMin, r.yMin + r.height * num), new Vector2(r.xMax, r.yMax), Slice.Bottom, 1f, c, c2, cache, num, 1f, disableGrad);
			return;
		}
		if (b.w > 0f)
		{
			DrawRect(new Vector2(r.xMin, r.yMin), new Vector2(r.xMax, r.yMin + b.w), Slice.Top, 1f, c, c2, cache, 0f, b.w / r.height, disableGrad);
		}
		DrawRect(new Vector2(r.xMin, r.yMin + b.w), new Vector2(r.xMax, r.yMax - b.y), Slice.Middle, 1f, c, c2, cache, b.w / r.height, (r.height - b.y) / r.height, disableGrad);
		if (b.y > 0f)
		{
			DrawRect(new Vector2(r.xMin, r.yMax - b.y), new Vector2(r.xMax, r.yMax), Slice.Bottom, 1f, c, c2, cache, (r.height - b.y) / r.height, 1f, disableGrad);
		}
	}

	private static void DrawRect(Vector2 a, Vector2 b, Color c, List<UIVertex> cache)
	{
		cache.Add(new UIVertex
		{
			color = c,
			position = new Vector3(a.x, a.y, 0f)
		});
		cache.Add(new UIVertex
		{
			color = c,
			position = new Vector3(a.x, b.y, 0f)
		});
		cache.Add(new UIVertex
		{
			color = c,
			position = new Vector3(b.x, b.y, 0f)
		});
		cache.Add(new UIVertex
		{
			color = c,
			position = new Vector3(b.x, a.y, 0f)
		});
	}

	private static void DrawRect(Vector2 a, Vector2 b, Slice slice, float p, Color c, Color c2, List<UIVertex> cache, float top, float bottom, bool disableGrad, bool reverse = false)
	{
		Vector2 vector = _slicePos[(int)slice];
		float num = 1f / 6f;
		Vector2 vector2 = (vector + Vector2.one) * (1f / 3f) + new Vector2(num, num);
		float x = 0f - num;
		float x2 = 0f - num + num * 2f * p;
		if (reverse)
		{
			x = 0f - num + num * 2f * (1f - p);
			x2 = num;
		}
		float v = (disableGrad ? 1f : Mathf.Lerp(0.85f, 1f, top));
		float v2 = (disableGrad ? 1f : Mathf.Lerp(0.85f, 1f, bottom));
		cache.Add(new UIVertex
		{
			color = c.MultColorPart(v),
			position = new Vector3(a.x, a.y, 0f),
			uv0 = vector2 + new Vector2(x, 0f - num)
		});
		cache.Add(new UIVertex
		{
			color = c.MultColorPart(v2),
			position = new Vector3(a.x, b.y, 0f),
			uv0 = vector2 + new Vector2(x, num)
		});
		cache.Add(new UIVertex
		{
			color = c2.MultColorPart(v2),
			position = new Vector3(b.x, b.y, 0f),
			uv0 = vector2 + new Vector2(x2, num)
		});
		cache.Add(new UIVertex
		{
			color = c2.MultColorPart(v),
			position = new Vector3(b.x, a.y, 0f),
			uv0 = vector2 + new Vector2(x2, 0f - num)
		});
	}

	private void DrawRect(Vector2 a, Vector2 b, Color c, Color c2, List<UIVertex> cache)
	{
		cache.Add(new UIVertex
		{
			color = c,
			position = new Vector3(a.x, a.y, 0f)
		});
		cache.Add(new UIVertex
		{
			color = c,
			position = new Vector3(a.x, b.y, 0f)
		});
		cache.Add(new UIVertex
		{
			color = c2,
			position = new Vector3(b.x, b.y, 0f)
		});
		cache.Add(new UIVertex
		{
			color = c2,
			position = new Vector3(b.x, a.y, 0f)
		});
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		_currentValue = 0f;
	}

	private void FixedUpdate()
	{
		if (Animated && _currentValue != Value)
		{
			_currentValue = Mathf.Lerp(_currentValue, Value, Time.deltaTime * 8f);
			if (_currentValue.Appx(Value, 0.01f))
			{
				_currentValue = Value;
			}
			_dirty = true;
			SetVerticesDirty();
		}
	}
}
