using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class TextSizer : MonoBehaviour
{
	public enum Mode
	{
		None,
		Horizontal,
		Vertical,
		Both
	}

	public TMP_Text Text;

	public bool ResizeTextObject;

	public Vector2 Padding;

	public Vector2 MaxSize;

	public Vector2 MinSize;

	public Mode ControlAxes;

	private string _lastText;

	private Mode _lastControlAxes;

	private Vector2 _lastSize;

	private bool _forceRefresh;

	private bool _isTextNull;

	private RectTransform _textRectTransform;

	private RectTransform _selfRectTransform;

	protected virtual float MinX
	{
		get
		{
			//IL_0010: Expected O, but got I4
			//IL_002a: Expected O, but got I4
			//IL_0069: Expected F4, but got O
			object obj = ControlAxes & Mode.Horizontal;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 == null)
			{
				return _selfRectTransform.rect.m_Width - (float)Padding;
			}
			return (float)MinSize;
		}
	}

	protected virtual float MinY
	{
		get
		{
			//IL_0010: Expected O, but got I4
			//IL_002a: Expected O, but got I4
			//IL_0075: Expected F4, but got I
			object obj = ControlAxes & Mode.Vertical;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 == null)
			{
				float num = _selfRectTransform.rect.m_Height;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (TextSizer)+30]");
				return num - 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (TextSizer)+40]");
			return 0f;
		}
	}

	protected virtual float MaxX
	{
		get
		{
			//IL_0010: Expected O, but got I4
			//IL_002a: Expected O, but got I4
			//IL_0069: Expected F4, but got O
			object obj = ControlAxes & Mode.Horizontal;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 == null)
			{
				return _selfRectTransform.rect.m_Width - (float)Padding;
			}
			return (float)MaxSize;
		}
	}

	protected virtual float MaxY
	{
		get
		{
			//IL_0010: Expected O, but got I4
			//IL_002a: Expected O, but got I4
			//IL_0075: Expected F4, but got I
			object obj = ControlAxes & Mode.Vertical;
			bool flag = obj == null;
			object obj2 = !flag;
			if (obj2 == null)
			{
				float num = _selfRectTransform.rect.m_Height;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (TextSizer)+30]");
				return num - 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (TextSizer)+38]");
			return 0f;
		}
	}

	private void Start()
	{
		Refresh();
	}

	protected virtual void Update()
	{
		Recalculate();
	}

	public void Recalculate()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00bf: Invalid comparison between F4 and O
		//IL_00de: Invalid comparison between F4 and I4
		//IL_0107: Expected O, but got I4
		//IL_01cd: Invalid comparison between F4 and O
		//IL_01e9: Invalid comparison between O and F4
		//IL_01fa: Expected F4, but got O
		//IL_03f3: Expected O, but got I4
		//IL_02bf: Expected O, but got I4
		//IL_0364: Expected O, but got F4
		if (_isTextNull)
		{
			return;
		}
		string text = Text.text;
		float num2 = default(float);
		if (text == _lastText)
		{
			Rect rect = _selfRectTransform.rect;
			object obj = _lastSize - rect.m_Width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (TextSizer)+58]");
			object obj2 = 0 - rect.m_Height;
			object obj3 = obj2 * obj2;
			object obj4 = obj * obj;
			object obj5 = obj3 + obj4;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5);
			float num = 9.9999994E-11f - (float)obj5;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj6 = flag4 & flag3;
			bool flag5 = obj6 == null;
			num2 = 9.9999994E-11f;
			if (!flag5)
			{
				bool flag6 = _forceRefresh;
				num2 = 9.9999994E-11f;
				if (!flag6)
				{
					bool flag7 = ControlAxes == _lastControlAxes;
					num2 = 9.9999994E-11f;
					if (flag7)
					{
						return;
					}
				}
			}
		}
		float maxX = MaxX;
		float maxY = MaxY;
		Vector2 preferredValues = Text.GetPreferredValues(num2, num2);
		float minX = MinX;
		float maxX2 = MaxX;
		float num3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref preferredValues))
		{
			bool flag8 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref preferredValues) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2);
			num3 = (float)preferredValues;
			if (!flag8)
			{
				num3 = num2;
			}
		}
		else
		{
			num3 = num2;
		}
		float minY = MinY;
		float maxY2 = MaxY;
		float num4 = default(float);
		float num5;
		if (!(num2 > num4))
		{
			bool flag9 = !(num4 > num2);
			num5 = num4;
			if (!flag9)
			{
				num5 = num2;
			}
		}
		else
		{
			num5 = num2;
		}
		float size = num3 + (float)Padding;
		float num6 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (TextSizer)+30]");
		float size2 = num6 + 0f;
		object obj7 = ControlAxes & Mode.Horizontal;
		if (obj7 != null)
		{
			_selfRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
			if (ResizeTextObject)
			{
				_textRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
			}
		}
		object obj8 = ControlAxes & Mode.Vertical;
		if (obj8 != null)
		{
			_selfRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size2);
			if (ResizeTextObject)
			{
				_textRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size2);
			}
		}
		string text2 = Text.text;
		_lastText = text2;
		Rect rect2 = _selfRectTransform.rect;
		_lastSize = (Vector2)rect2.m_Width;
		_lastControlAxes = ControlAxes;
		_ = rect2.m_Height;
		_forceRefresh = false;
	}

	public virtual void Refresh()
	{
		_forceRefresh = true;
		bool isTextNull = Text == null;
		_isTextNull = isTextNull;
		if ((bool)Text)
		{
			RectTransform component = Text.GetComponent<RectTransform>();
			_textRectTransform = component;
		}
		RectTransform component2 = GetComponent<RectTransform>();
		_selfRectTransform = component2;
	}

	private void OnValidate()
	{
		Refresh();
	}

	public TextSizer()
	{
		//IL_0016: Expected O, but got I4
		ResizeTextObject = true;
		MaxSize = (Vector2)1148846080;
		_ = 2139095040;
		ControlAxes = Mode.Both;
		_isTextNull = true;
		base._002Ector();
	}
}
