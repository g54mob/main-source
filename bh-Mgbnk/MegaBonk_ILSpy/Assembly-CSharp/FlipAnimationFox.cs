using Cpp2ILInjected;
using UnityEngine;

public class FlipAnimationFox : MonoBehaviour
{
	public Animator animator;

	private bool isJumping;

	public Transform flipTransform;

	private float lastAnimationTime;

	private int jumpCount;

	public GameObject[] defaultHandhelds;

	public GameObject[] flippedHandhelds;

	private void Update()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172001]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		AnimatorStateInfo animatorStateInfo = default(AnimatorStateInfo);
		bool flag = animatorStateInfo.IsName("Jump");
		if (!flag)
		{
			if (isJumping != flag)
			{
				isJumping = flag;
				OnJumpAnimationFinishOrInterrupted();
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18225F9B0");
		float num = default(float);
		if (isJumping)
		{
			if (!(lastAnimationTime > num))
			{
				goto IL_0106;
			}
			OnJumpAnimationFinishOrInterrupted();
		}
		else
		{
			isJumping = true;
		}
		OnJumpAnimationStart();
		goto IL_0106;
		IL_0106:
		lastAnimationTime = num;
	}

	private unsafe void OnJumpAnimationStart()
	{
		//IL_0079: Expected O, but got Ref
		//IL_0059: Expected O, but got Ref
		object obj = default(object);
		if ((++jumpCount & 1) != 0)
		{
			flipTransform.localScale = (Vector3)(&obj);
			FlipHandhelds(flip: false);
		}
		else
		{
			flipTransform.localScale = (Vector3)(&obj);
			FlipHandhelds(flip: true);
		}
	}

	private unsafe void OnJumpAnimationFinishOrInterrupted()
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		flipTransform.localScale = (Vector3)(&obj);
		FlipHandhelds(flip: false);
	}

	private void FlipHandhelds(bool flip)
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		GameObject[] array = defaultHandhelds;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			bool active = (byte)((flip ? 1u : 0u) ^ 1u) != 0;
			array[obj2].SetActive(active);
			obj2++;
			obj = obj2;
		}
		GameObject[] array2 = flippedHandhelds;
		object obj3 = 0;
		object obj4 = 0;
		while ((nint)obj3 < array2.Length)
		{
			array2[obj4].SetActive(flip);
			obj4++;
			obj3 = obj4;
		}
	}
}
