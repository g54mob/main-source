using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.UI;

public class PortraitPopupWindow : MonoBehaviour
{
	private CanvasGroup _cg;

	private void Awake()
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		_cg = component;
		_cg.interactable = false;
		_cg.alpha = 0f;
		_cg.blocksRaycasts = false;
	}

	public void Show()
	{
		_cg.interactable = true;
		_cg.alpha = 1f;
		_cg.blocksRaycasts = true;
	}

	public void Hide()
	{
		_cg.interactable = false;
		_cg.alpha = 0f;
		_cg.blocksRaycasts = false;
	}

	private void OnDisable()
	{
		_cg.interactable = false;
		_cg.alpha = 0f;
		_cg.blocksRaycasts = false;
	}

	public PortraitPopupWindow()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
