using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class DisableNavigationOnChildren : MonoBehaviour
{
	private unsafe void Awake()
	{
		//IL_002f: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0074: Expected O, but got Ref
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_008b: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		Selectable[] componentsInChildren = gameObject.GetComponentsInChildren<Selectable>(includeInactive: true);
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj < componentsInChildren.Length)
		{
			componentsInChildren[obj2].navigation = (Navigation)(&obj3);
			obj2++;
			obj3 = 0;
			obj = obj2;
		}
	}

	public DisableNavigationOnChildren()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
