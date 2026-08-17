using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors;

public class AdjustValuePanel : MonoBehaviour
{
	public delegate void OnValueChange(AdjustValuePanel panel, bool positive);

	private Image _Icon;

	private TextMeshProUGUI _ValueText;

	private Button _UpButton;

	private Button _DownButton;

	private float _IncrementAmount;

	private string _Suffix;

	private bool CanGoNegative;

	private OnValueChange m_ValueChanged;

	private float _displayValue;

	private bool _canGoUp;

	private bool _canGoDown;

	private int _pointsAssigned;

	private Color _inactiveColor;

	private Selectable _selectOnRight;

	public event OnValueChange ValueChanged
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_ValueChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChange);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_ValueChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChange);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Start()
	{
		Button upButton = _UpButton;
		UnityAction call = IncrementUp;
		upButton.m_OnClick.AddListener(call);
		Button downButton = _DownButton;
		UnityAction call2 = IncrementDown;
		downButton.m_OnClick.AddListener(call2);
		_UpButton.interactable = true;
		_DownButton.interactable = true;
		Refresh();
	}

	public void Initialize(int pointsAssigned)
	{
		//IL_0020: Expected F4, but got I4
		//IL_0037: Expected F4, but got I4
		//IL_0057: Expected O, but got I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		_pointsAssigned = pointsAssigned;
		bool flag = pointsAssigned >= 1;
		float num = 25f;
		if (!flag)
		{
			num = 0f;
		}
		float num2 = num + 25f;
		if (pointsAssigned < 2)
		{
			num2 = num;
		}
		if (pointsAssigned >= 3)
		{
			object obj = pointsAssigned - 2;
			object obj2 = obj * 25;
			num2 += (float)obj2;
		}
		_displayValue = num2;
		Refresh();
	}

	public void IncrementUp()
	{
		if (_canGoUp)
		{
			int pointsAssigned = _pointsAssigned + 1;
			_pointsAssigned = pointsAssigned;
			OnValueChange valueChanged = this.m_ValueChanged;
			if (this.m_ValueChanged != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v14.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			Refresh();
		}
	}

	public void SetValue(int v)
	{
		//IL_000a: Expected F4, but got I4
		_displayValue = v;
		Refresh();
	}

	public void IncrementDown()
	{
		//IL_000b: Invalid comparison between I4 and F4
		if ((0f < _displayValue || CanGoNegative) && _canGoDown)
		{
			int pointsAssigned = _pointsAssigned - 1;
			_pointsAssigned = pointsAssigned;
			OnValueChange valueChanged = this.m_ValueChanged;
			if (this.m_ValueChanged != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v84.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 63 Invalid \"Jump target not found in method: 0x1872002C0\"");
		}
	}

	public float GetValue()
	{
		return _displayValue;
	}

	public int GetIncrementValue()
	{
		return _pointsAssigned;
	}

	public void SetCanIncrementUp(bool enabled)
	{
		_canGoUp = enabled;
		Refresh();
	}

	public void SetCanIncrementDown(bool enabled)
	{
		_canGoDown = enabled;
		Refresh();
	}

	private unsafe void Refresh()
	{
		//IL_032a: Invalid comparison between F4 and I4
		//IL_004f: Expected Ref, but got F4
		//IL_034c: Invalid comparison between I4 and F4
		//IL_036d: Expected O, but got Ref
		//IL_0137: Expected O, but got I
		//IL_039a: Expected O, but got Ref
		//IL_01f1: Expected O, but got I
		//IL_02d1: Expected O, but got I
		//IL_045f->IL030e: Incompatible stack heights: 1 vs 0
		//IL_02f1->IL030e: Incompatible stack heights: 1 vs 0
		//IL_0436->IL030e: Incompatible stack heights: 2 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187200357h\"");
		if (_displayValue == 0f)
		{
			if ((object)_ValueText == null)
			{
				goto IL_030e;
			}
			_ValueText.text = "-";
		}
		else
		{
			float num = (float)this + 96f;
			string text = ((float*)num)->ToString();
			string text2 = text + _Suffix;
			if ((object)_ValueText == null)
			{
				goto IL_030e;
			}
			_ValueText.text = text2;
		}
		Image component;
		Color ret;
		if ((0f < _displayValue || CanGoNegative) && _canGoDown)
		{
			if ((object)_DownButton != null)
			{
				component = _DownButton.GetComponent<Image>();
				if ((object)component != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					ret = (Color)0;
					goto IL_0360;
				}
			}
		}
		else if ((object)_DownButton != null)
		{
			component = _DownButton.GetComponent<Image>();
			if ((object)component != null)
			{
				ret = _inactiveColor;
				goto IL_0360;
			}
		}
		goto IL_030e;
		IL_0360:
		component.color = (Color)(&ret);
		Image component2;
		if (_canGoUp)
		{
			if ((object)_UpButton != null)
			{
				component2 = _UpButton.GetComponent<Image>();
				if ((object)component2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					ret = (Color)0;
					goto IL_038c;
				}
			}
		}
		else if ((object)_UpButton != null)
		{
			component2 = _UpButton.GetComponent<Image>();
			if ((object)component2 != null)
			{
				ret = _inactiveColor;
				goto IL_038c;
			}
		}
		goto IL_030e;
		IL_030e:
		throw new NullReferenceException();
		IL_038c:
		component2.color = (Color)(&ret);
		if ((object)_Icon != null)
		{
			RectTransform rectTransform = _Icon.rectTransform;
			TextMeshProUGUI icon = (TextMeshProUGUI)(object)_Icon;
			if ((object)_Icon != null)
			{
				TextMeshProUGUI text3 = (TextMeshProUGUI)(object)((TMP_Text)icon).m_text;
				if (((TMP_Text)icon).m_text != null)
				{
					bool flag = ((UnityEngine.Object)text3).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)text3).m_CachedPtr, out Rect _);
					AdjustValuePanel icon2 = (AdjustValuePanel)(object)_Icon;
					if ((object)_Icon != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v6 (VampireSurvivors.AdjustValuePanel)+E0]");
						AdjustValuePanel adjustValuePanel = (AdjustValuePanel)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v6 (VampireSurvivors.AdjustValuePanel)+E0]");
						if ((nint)0 != 0)
						{
							bool flag2 = ((UnityEngine.Object)adjustValuePanel).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)adjustValuePanel).m_CachedPtr, out *(Rect*)(&ret));
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_030e;
	}

	private bool CanDecrease()
	{
		//IL_000b: Invalid comparison between I4 and F4
		if (!(0f < _displayValue) && !CanGoNegative)
		{
			return false;
		}
		bool flag = !_canGoDown;
		return !flag;
	}

	private bool CanIncrease()
	{
		return _canGoUp;
	}

	public Selectable GetUpButton()
	{
		return _UpButton;
	}

	public Selectable GetDownButton()
	{
		return _DownButton;
	}

	public AdjustValuePanel()
	{
		//IL_0045: Expected O, but got I
		//IL_0075: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4930]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_Suffix = "%";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11DE0]");
		_inactiveColor = (Color)0;
		_canGoUp = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
