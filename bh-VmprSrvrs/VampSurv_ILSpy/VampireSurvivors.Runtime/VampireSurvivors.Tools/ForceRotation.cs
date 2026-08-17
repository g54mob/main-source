using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Tools;

public class ForceRotation : MonoBehaviour
{
	private bool _ForceOnUpdate;

	private Vector3 _Rotation;

	private unsafe void Start()
	{
		//IL_001c: Expected O, but got Ref
		Transform transform = base.transform;
		object obj = default(object);
		transform.eulerAngles = (Vector3)(&obj);
	}

	private unsafe void Update()
	{
		//IL_003b: Expected O, but got Ref
		if (_ForceOnUpdate)
		{
			Transform transform = base.transform;
			object obj = default(object);
			transform.eulerAngles = (Vector3)(&obj);
		}
	}

	public ForceRotation()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
