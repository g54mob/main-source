using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonNavigationBackdropAndText : MonoBehaviour, IButton, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public MaskableGraphic overlay;

	public MaskableGraphic overlay_disabled;

	public MaskableGraphic text;

	public GameObject associatedContent;

	public bool isTabSelectable;

	public float overlayMultiplier;

	private Vector3 desiredScale;

	private Color textDefaultColor;

	private Color textSelectedColor;

	private Color c_overlayDefault;

	private Color c_overlayHover;

	private Color c_overlaySelected;

	private bool selected;

	private Button button;

	public unsafe void Select()
	{
		//IL_0082: Expected O, but got Ref
		//IL_0096: Expected O, but got Ref
		if (associatedContent != null)
		{
			associatedContent.SetActive(value: true);
		}
		if (isTabSelectable)
		{
			selected = true;
			float num = default(float);
			text.color = (Color)(&num);
			overlay.color = (Color)(&num);
		}
	}

	public unsafe void Deselect(IButton newButton)
	{
		//IL_00a1: Expected O, but got Ref
		//IL_00b5: Expected O, but got Ref
		if (associatedContent != null)
		{
			GameObject gameObject = newButton.GetAssociatedContent();
			if (gameObject != null)
			{
				associatedContent.SetActive(value: false);
			}
		}
		selected = false;
		Color color = default(Color);
		text.color = (Color)(&color);
		overlay.color = (Color)(&color);
	}

	public Button GetButton()
	{
		if (button == null)
		{
			Button component = GetComponent<Button>();
			button = component;
		}
		return button;
	}

	public GameObject GetAssociatedContent()
	{
		return associatedContent;
	}

	public bool IsTabSelectable()
	{
		return isTabSelectable;
	}

	public unsafe void OnPointerEnter(PointerEventData eventData)
	{
		//IL_0031: Expected O, but got Ref
		//IL_0045: Expected I, but got O
		if (!selected)
		{
			object obj = default(object);
			overlay.color = (Color)(&obj);
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num3 = 0f * 1.05f;
			Vector3 vector = default(Vector3);
			desiredScale = vector;
		}
	}

	public unsafe void OnPointerExit(PointerEventData eventData)
	{
		//IL_0031: Expected O, but got Ref
		//IL_0045: Expected I, but got O
		if (!selected)
		{
			object obj = default(object);
			overlay.color = (Color)(&obj);
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			desiredScale = Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			_ = 0;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	private unsafe void Update()
	{
		//IL_0061: Invalid comparison between I4 and F4
		//IL_00ac: Expected F4, but got I4
		//IL_00be: Expected O, but got Ref
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 18f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
	}

	public void Enable()
	{
		Button button = GetButton();
		button.interactable = true;
		if ((bool)overlay_disabled)
		{
			overlay_disabled.enabled = false;
		}
	}

	public void Disable()
	{
		Button button = GetButton();
		button.interactable = false;
		if ((bool)overlay_disabled)
		{
			overlay_disabled.enabled = true;
		}
	}

	public bool IsEnabled()
	{
		//IL_003f: Expected I4, but got O
		Button button = GetButton();
		if ((object)button != null)
		{
			return ((Selectable)button).m_Interactable;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public ButtonNavigationBackdropAndText()
	{
		//IL_0029: Expected I, but got O
		//IL_005c: Expected O, but got I4
		isTabSelectable = true;
		overlayMultiplier = 1f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		desiredScale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		textDefaultColor = (Color)1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1048576000;
		_ = 0;
		_ = 1058642330;
		base._002Ector();
	}
}
