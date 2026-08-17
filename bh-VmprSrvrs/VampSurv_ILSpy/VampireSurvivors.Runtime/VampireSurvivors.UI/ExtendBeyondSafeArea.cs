using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.UI;

public class ExtendBeyondSafeArea : MonoBehaviour
{
	private RectTransform _rectTransform;

	private void Awake()
	{
		RectTransform component = GetComponent<RectTransform>();
		_rectTransform = component;
	}

	private void Start()
	{
		//IL_001e: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		object obj = Screen.width;
		object obj2 = Screen.height;
		Vector2 sizeDelta = default(Vector2);
		_rectTransform.sizeDelta = sizeDelta;
	}

	public ExtendBeyondSafeArea()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
