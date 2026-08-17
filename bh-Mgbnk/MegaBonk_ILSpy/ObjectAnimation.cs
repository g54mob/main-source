using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
	public float scale = 0.2f;

	public float scaleSpeed = 2f;

	private Vector3 defaultScale;

	private void Awake()
	{
		//IL_002b: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 localScale = transform.localScale;
		defaultScale = (Vector3)localScale.x;
		_ = localScale.z;
	}

	private unsafe void Update()
	{
		//IL_0156: Invalid comparison between I4 and F4
		//IL_003a: Expected F4, but got I4
		//IL_0068: Invalid comparison between I4 and F4
		//IL_00b3: Expected F4, but got I4
		//IL_00c5: Expected O, but got Ref
		float num = scale + scale;
		float num2 = MyTime.time * scaleSpeed;
		float num3 = num2 / num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num4 = num3 * num;
		float num5 = num2 - num4;
		if (!(0f > num5))
		{
			if (num5 > num)
			{
				num5 = num;
			}
		}
		else
		{
			num5 = 0f;
		}
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 localScale = transform2.localScale;
		float num6 = MyTime.deltaTime * 10f;
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		float num7 = default(float);
		transform.localScale = (Vector3)(&num7);
	}
}
