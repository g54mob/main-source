using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class StarCounter : MaskableGraphic, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, ICursorOverride
{
	[Serializable]
	public class StarClickEvent : UnityEvent<int>
	{
		private int _listenerCount;

		public int ListenerCount
		{
			get
			{
				return _listenerCount;
			}
		}

		public new void AddListener(UnityAction<int> call)
		{
			base.AddListener(call);
			_listenerCount++;
		}

		public new void RemoveListener(UnityAction<int> call)
		{
			base.RemoveListener(call);
			_listenerCount--;
		}
	}

	public int[] Numbers = new int[5] { 5, 22, 0, 120, 0 };

	public string[] Tips;

	public Color ActiveColor;

	public Color NonActiveColor;

	public Color SubActiveColor;

	public Color TextColor;

	public Color BackColor = new Color(0f, 0f, 0f, 0.5f);

	public float NumberCloseness = 0.7f;

	public float NumberRelSize = 0.66f;

	public bool AutoSpace = true;

	public bool DrawBack = true;

	public Texture2D Texture;

	[NonSerialized]
	public int? ForceNum;

	private bool _tipping;

	public StarClickEvent OnPointerDownEvent;

	public override Texture mainTexture
	{
		get
		{
			return Texture;
		}
	}

	public string CursorOverrideName
	{
		get
		{
			Vector2 localPoint;
			if (OnPointerDownEvent.ListenerCount > 0 && Numbers != null && Numbers.Length != 0 && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
			{
				float num = (AutoSpace ? base.rectTransform.rect.width : (base.rectTransform.rect.height * (float)Numbers.Length));
				if (localPoint.x < num)
				{
					int num2 = Mathf.FloorToInt((localPoint.x + base.rectTransform.rect.width * base.rectTransform.pivot.x) / num * (float)Numbers.Length);
					if (num2 >= 0 && num2 < Numbers.Length)
					{
						return "Finger";
					}
				}
			}
			return null;
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (Numbers == null || Numbers.Length == 0)
		{
			return;
		}
		RectTransform rectTransform = base.rectTransform;
		float height = rectTransform.rect.height;
		Vector2 vector = new Vector2((0f - rectTransform.rect.width) * rectTransform.pivot.x, (0f - rectTransform.rect.height) * (rectTransform.pivot.y - 1f) - height);
		int num = Numbers.Length - 1;
		if (ForceNum.HasValue)
		{
			num = ForceNum.Value;
		}
		else
		{
			while (num >= 0 && Numbers[num] <= 0)
			{
				num--;
			}
		}
		if (DrawBack)
		{
			DrawSprite(15, 4, 4, new Rect(vector.x, vector.y, AutoSpace ? rectTransform.rect.width : (height * (float)Numbers.Length), height), BackColor, vh);
		}
		float num2 = (AutoSpace ? (rectTransform.rect.width / (float)Numbers.Length) : height);
		float num3 = (AutoSpace ? (num2 / 2f - height / 2f) : 0f);
		for (int i = 0; i < Numbers.Length; i++)
		{
			DrawStar(new Rect(num3 + vector.x + (float)i * num2, vector.y, height, height), (i <= num) ? ActiveColor : ((Numbers[i] == -99) ? SubActiveColor : NonActiveColor), Numbers[i], vh);
		}
	}

	private void DrawStar(Rect pos, Color c, int num, VertexHelper vh)
	{
		DrawSprite(10, 4, 4, pos, c, vh);
		if (num > 0)
		{
			int num2 = CountDigits(num);
			float num3 = pos.height * NumberRelSize;
			float num4 = num3 * NumberCloseness;
			Vector2 vector = new Vector2(pos.center.x + num4 * (float)(num2 - 1) / 2f - num3 / 2f, pos.center.y - num3 / 2f);
			for (int i = 0; i < num2; i++)
			{
				DrawSprite(num % 10, 4, 4, new Rect(vector.x - num4 * (float)i, vector.y, num3, num3), TextColor, vh);
				num /= 10;
			}
		}
	}

	private int CountDigits(int num)
	{
		int num2 = 1;
		while (num > 9)
		{
			num /= 10;
			num2++;
		}
		return num2;
	}

	private void DrawSprite(int i, int w, int h, Rect pos, Color c, VertexHelper vh)
	{
		float num = (float)(i % w) / (float)w;
		float num2 = (float)(i / w) / (float)h;
		float num3 = num;
		float num4 = 1f - num2;
		float x = num3 + 1f / (float)w;
		float y = num4 - 1f / (float)h;
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = c,
				position = new Vector3(pos.xMin, pos.yMax),
				uv0 = new Vector2(num3, num4)
			},
			new UIVertex
			{
				color = c,
				position = new Vector3(pos.xMax, pos.yMax),
				uv0 = new Vector2(x, num4)
			},
			new UIVertex
			{
				color = c,
				position = new Vector3(pos.xMax, pos.yMin),
				uv0 = new Vector2(x, y)
			},
			new UIVertex
			{
				color = c,
				position = new Vector3(pos.xMin, pos.yMin),
				uv0 = new Vector2(num3, y)
			}
		});
	}

	private void Update()
	{
		if (_tipping)
		{
			if (Tooltip.CurrentRect != base.rectTransform)
			{
				_tipping = false;
			}
			else
			{
				UpdateTooltip();
			}
		}
	}

	protected override void OnDisable()
	{
		_tipping = false;
		base.OnDisable();
	}

	private void UpdateTooltip()
	{
		Vector2 localPoint = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			float num = (AutoSpace ? base.rectTransform.rect.width : (base.rectTransform.rect.height * (float)Numbers.Length));
			if (localPoint.x < num)
			{
				int num2 = Mathf.FloorToInt((localPoint.x + base.rectTransform.rect.width * base.rectTransform.pivot.x) / num * (float)Tips.Length);
				if (num2 >= 0 && num2 < Tips.Length && !string.IsNullOrEmpty(Tips[num2]))
				{
					Tooltip.SetToolTip(null, Tips[num2], base.rectTransform);
					return;
				}
				Tooltip.CurrentRect = base.rectTransform;
				Tooltip.Hide();
			}
			else
			{
				Tooltip.CurrentRect = base.rectTransform;
				Tooltip.Hide();
			}
		}
		else
		{
			Tooltip.Hide();
			_tipping = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Tips != null && Numbers != null && Tips.Length == Numbers.Length)
		{
			_tipping = true;
			UpdateTooltip();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Vector2 localPoint;
		if (Numbers == null || Numbers.Length == 0 || !RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, eventData.position, UICamSize.GetUICam(), out localPoint))
		{
			return;
		}
		float num = (AutoSpace ? base.rectTransform.rect.width : (base.rectTransform.rect.height * (float)Numbers.Length));
		if (localPoint.x < num)
		{
			int num2 = Mathf.FloorToInt((localPoint.x + base.rectTransform.rect.width * base.rectTransform.pivot.x) / num * (float)Numbers.Length);
			if (num2 >= 0 && num2 < Numbers.Length)
			{
				OnPointerDownEvent.Invoke(num2);
			}
		}
	}
}
