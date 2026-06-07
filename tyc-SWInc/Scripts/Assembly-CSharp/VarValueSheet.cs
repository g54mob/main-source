using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VarValueSheet : Graphic, IScrollHandler, IEventSystemHandler, IPointerEnterHandler, IPointerDownHandler, IPointerClickHandler, ICursorOverride
{
	public Text VarText;

	public Text ValueText;

	public Scrollbar Scroll;

	public Color C1;

	public Color C2;

	[NonSerialized]
	public string[] ToolTips;

	[NonSerialized]
	public Action[] Actions;

	[NonSerialized]
	private string[] vars = new string[0];

	[NonSerialized]
	private string[] values = new string[0];

	[NonSerialized]
	private List<UIVertex> MeshData = new List<UIVertex>();

	public float TextHeight = 24f;

	private bool _toolTip;

	[NonSerialized]
	private bool[] _doubleSpace;

	[NonSerialized]
	private int _extraLines;

	[NonSerialized]
	private bool _overAction;

	public string CursorOverrideName
	{
		get
		{
			if (!_overAction)
			{
				return "Default";
			}
			return "Finger";
		}
	}

	private void CalculateExtraLines()
	{
		float num = base.rectTransform.rect.width - Scroll.handleRect.rect.width - 4f * Options.UISize;
		int num2 = Mathf.Max(vars.Length, values.Length);
		if (_doubleSpace == null || _doubleSpace.Length < num2)
		{
			_doubleSpace = new bool[num2];
		}
		_extraLines = 0;
		int num3 = Mathf.Min(vars.Length, values.Length);
		TextGenerationSettings generationSettings = VarText.GetGenerationSettings(new Vector2(999999f, 0f));
		TextGenerationSettings generationSettings2 = ValueText.GetGenerationSettings(new Vector2(999999f, 0f));
		for (int i = 0; i < num3; i++)
		{
			float num4 = ((vars[i] == null) ? 0f : (VarText.cachedTextGeneratorForLayout.GetPreferredWidth(vars[i], generationSettings) / Options.UISize));
			float num5 = ((values[i] == null) ? 0f : (ValueText.cachedTextGeneratorForLayout.GetPreferredWidth(values[i], generationSettings2) / Options.UISize));
			if (num4 + num5 >= num)
			{
				_doubleSpace[i] = true;
				_extraLines++;
			}
			else
			{
				_doubleSpace[i] = false;
			}
		}
	}

	protected override void OnPopulateMesh(VertexHelper h)
	{
		h.Clear();
		Utilities.VBOToHelper(MeshData, h);
	}

	protected override void OnRectTransformDimensionsChange()
	{
		if (Application.isPlaying)
		{
			CalculateExtraLines();
			UpdateScroll();
			UpdateText();
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		_toolTip = false;
	}

	private Action GetAction(int index)
	{
		if (index < 0 || Actions == null || index >= Actions.Length)
		{
			return null;
		}
		return Actions[index];
	}

	private void Update()
	{
		if (_toolTip)
		{
			if (ToolTips == null || Tooltip.CurrentRect != base.rectTransform)
			{
				_toolTip = false;
				return;
			}
			UpdateTooltip();
		}
		if (Actions != null)
		{
			int indexAtMouse = GetIndexAtMouse();
			_overAction = GetAction(indexAtMouse) != null;
		}
	}

	private string GetTip(int i)
	{
		int j = 0;
		int num = 0;
		for (; j < _doubleSpace.Length; j++)
		{
			if (num >= i)
			{
				break;
			}
			num++;
			if (_doubleSpace[j])
			{
				if (num >= i)
				{
					break;
				}
				num++;
			}
		}
		if (j >= 0 && j < ToolTips.Length)
		{
			return ToolTips[j];
		}
		return null;
	}

	private void UpdateTooltip()
	{
		int num = Mathf.Max(MaxItems(), vars.Length + _extraLines);
		int indexAtMouse = GetIndexAtMouse();
		if (indexAtMouse >= 0 && indexAtMouse < num)
		{
			string tip = GetTip(indexAtMouse);
			if (tip != null)
			{
				Tooltip.SetToolTip(null, tip.StartsWith("*") ? tip.Substring(1) : tip.Loc(), base.rectTransform);
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

	private float CorrectHeight(float height)
	{
		if (Options.UISize > 1f && Options.UISize < 2f && Mathf.RoundToInt(Options.UISize * 10f % 2f) == 0)
		{
			return height - 1f;
		}
		return height;
	}

	private void GenerateMesh()
	{
		MeshData.Clear();
		Vector2 vector = Vector2.zero - base.rectTransform.pivot;
		Vector2 vector2 = Vector2.one - base.rectTransform.pivot;
		vector = new Vector2(vector.x * base.rectTransform.rect.width, vector.y * base.rectTransform.rect.height);
		vector2 = new Vector2(vector2.x * base.rectTransform.rect.width, vector2.y * base.rectTransform.rect.height);
		int num = MaxItems();
		int num2 = Mathf.Max(0, vars.Length - num);
		int b = Mathf.FloorToInt(Scroll.value * (float)num2);
		b = Mathf.Min(num2, b);
		float num3 = CorrectHeight(TextHeight);
		for (int i = 0; i < num; i++)
		{
			Color color = (((i + b) % 2 == 0) ? C1 : C2);
			UIVertex item = new UIVertex
			{
				position = new Vector3(vector.x, vector2.y - (float)i * num3, 0f),
				color = color
			};
			MeshData.Add(item);
			item = new UIVertex
			{
				position = new Vector3(vector2.x, vector2.y - (float)i * num3, 0f),
				color = color
			};
			MeshData.Add(item);
			item = new UIVertex
			{
				position = new Vector3(vector2.x, vector2.y - (float)i * num3 - num3, 0f),
				color = color
			};
			MeshData.Add(item);
			item = new UIVertex
			{
				position = new Vector3(vector.x, vector2.y - (float)i * num3 - num3, 0f),
				color = color
			};
			MeshData.Add(item);
		}
		float num4 = base.rectTransform.rect.height % num3;
		if (num4 > 0f)
		{
			Color color2 = (((num + b) % 2 == 0) ? C1 : C2);
			UIVertex item2 = new UIVertex
			{
				position = new Vector3(vector.x, vector2.y - (float)num * num3, 0f),
				color = color2
			};
			MeshData.Add(item2);
			item2 = new UIVertex
			{
				position = new Vector3(vector2.x, vector2.y - (float)num * num3, 0f),
				color = color2
			};
			MeshData.Add(item2);
			item2 = new UIVertex
			{
				position = new Vector3(vector2.x, vector2.y - (float)num * num3 - num4, 0f),
				color = color2
			};
			MeshData.Add(item2);
			item2 = new UIVertex
			{
				position = new Vector3(vector.x, vector2.y - (float)num * num3 - num4, 0f),
				color = color2
			};
			MeshData.Add(item2);
		}
		SetVerticesDirty();
	}

	public void OnScroll()
	{
		UpdateText();
		GenerateMesh();
	}

	public int MaxItems()
	{
		return Mathf.FloorToInt(base.rectTransform.rect.height / CorrectHeight(TextHeight));
	}

	public void SetData(string[] var, string[] value, bool resetScroll = true)
	{
		vars = var;
		values = value;
		CalculateExtraLines();
		UpdateScroll();
		if (resetScroll)
		{
			Scroll.value = 0f;
		}
		UpdateText();
	}

	public void SetData(string data)
	{
		string[][] arr = data.Split('\n').SelectInPlace((string x) => x.Split('\t'));
		vars = arr.SelectInPlace((string[] x) => x[0]);
		values = arr.SelectInPlace((string[] x) => x[1]);
		CalculateExtraLines();
		UpdateScroll();
		Scroll.value = 0f;
		UpdateText();
	}

	public void UpdateValue(int idx, string value, bool updateText = false)
	{
		values[idx] = value;
		if (updateText)
		{
			CalculateExtraLines();
			UpdateText();
		}
	}

	public void UpdateValues(string[] value)
	{
		values = value;
		CalculateExtraLines();
		UpdateText();
	}

	public void UpdateText()
	{
		if (ValueText.rectTransform == null)
		{
			return;
		}
		int num = MaxItems();
		int num2 = Mathf.Max(0, vars.Length + _extraLines - num);
		int b = Mathf.FloorToInt(Scroll.value * (float)num2);
		b = Mathf.Min(num2, b);
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		int num3 = Mathf.Min(vars.Length, values.Length);
		int num4 = 0;
		for (int i = 0; i < num3; i++)
		{
			if (num4 >= b)
			{
				stringBuilder.AppendLine(vars[i]);
			}
			if (_doubleSpace[i])
			{
				if (num4 >= b)
				{
					stringBuilder2.AppendLine("");
				}
				num4++;
				if (num4 >= b + num)
				{
					break;
				}
				if (num4 >= b)
				{
					stringBuilder.AppendLine("");
					stringBuilder2.AppendLine((GetAction(i) != null) ? values[i].BlueHighlight() : values[i]);
				}
			}
			else if (num4 >= b)
			{
				stringBuilder2.AppendLine((GetAction(i) != null) ? values[i].BlueHighlight() : values[i]);
			}
			num4++;
			if (num4 >= b + num)
			{
				break;
			}
		}
		VarText.text = stringBuilder.ToString().TrimEnd();
		ValueText.text = stringBuilder2.ToString().TrimEnd();
		float num5 = base.rectTransform.rect.width % 1f;
		ValueText.rectTransform.anchoredPosition = new Vector2(-7f + num5, ValueText.rectTransform.anchoredPosition.y);
		ValueText.rectTransform.sizeDelta = new Vector2(-23f + num5, ValueText.rectTransform.sizeDelta.y);
	}

	public void UpdateScroll()
	{
		int num = Mathf.Max(0, vars.Length + _extraLines - MaxItems());
		Scroll.numberOfSteps = num + 1;
		Scroll.size = 1f / (float)(num + 1);
		GenerateMesh();
	}

	public void OnScroll(PointerEventData eventData)
	{
		int num = Mathf.Max(0, vars.Length + _extraLines - MaxItems());
		if (num > 0)
		{
			Scroll.value -= eventData.scrollDelta.y * (1f / (float)num);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_toolTip = ToolTips != null;
		if (_toolTip)
		{
			UpdateTooltip();
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Actions != null)
		{
			Action action = GetAction(GetIndexAtMouse());
			if (action != null)
			{
				action();
			}
		}
	}

	private int GetIndexAtMouse()
	{
		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
		float num = base.rectTransform.rect.height * (1f - base.rectTransform.pivot.y) - localPoint.y;
		int num2 = MaxItems();
		int num3 = Mathf.Max(0, vars.Length + _extraLines - num2);
		int b = Mathf.FloorToInt(Scroll.value * (float)num3);
		b = Mathf.Min(num3, b);
		return Mathf.FloorToInt(num / CorrectHeight(TextHeight) + (float)b);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
