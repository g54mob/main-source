using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Tools;

public class Rotate : MonoBehaviour
{
	private float _Speed;

	private Vector3 _Axis;

	private unsafe void Update()
	{
		//IL_0040: Expected O, but got F4
		//IL_0036: Expected O, but got Ref
		Transform transform = base.transform;
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float angle = (float)obj2 * _Speed;
		object obj3 = default(object);
		transform.Rotate((Vector3)(&obj3), angle, Space.Self);
	}

	public Rotate()
	{
		//IL_0020: Expected I, but got O
		_Speed = 10f;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
