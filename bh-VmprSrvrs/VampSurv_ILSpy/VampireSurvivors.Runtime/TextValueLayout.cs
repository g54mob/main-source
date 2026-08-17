using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class TextValueLayout : MonoBehaviour
{
	private float _Spacing;

	private RectTransform _Label;

	private RectTransform _Value;

	private RectTransform _rTrans;

	private void Awake()
	{
		RectTransform component = GetComponent<RectTransform>();
		_rTrans = component;
	}

	private void Update()
	{
		Vector2 sizeDelta = _rTrans.sizeDelta;
		Vector2 sizeDelta2 = _Label.sizeDelta;
		Vector2 sizeDelta3 = _Value.sizeDelta;
		Vector2 vector = default(Vector2);
		_Value.sizeDelta = vector;
		_Value.anchoredPosition = vector;
		Vector2 sizeDelta4 = _rTrans.sizeDelta;
		Vector2 sizeDelta5 = _Value.sizeDelta;
		_rTrans.sizeDelta = vector;
		Transform parent = _rTrans.parent;
		RectTransform component = parent.GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
	}

	public TextValueLayout()
	{
		//IL_0020: Expected I, but got O
		_Spacing = 5f;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
