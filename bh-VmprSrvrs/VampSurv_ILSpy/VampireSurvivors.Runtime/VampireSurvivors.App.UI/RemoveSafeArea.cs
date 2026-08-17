using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.UI;

public class RemoveSafeArea : MonoBehaviour
{
	private RectTransform _NoSafeAreaReference;

	private void Start()
	{
		UpdateToExtendSafeArea();
	}

	private void OnEnable()
	{
		UpdateToExtendSafeArea();
	}

	private void UpdateToExtendSafeArea()
	{
		if ((object)_NoSafeAreaReference == null)
		{
		}
	}

	public RemoveSafeArea()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
