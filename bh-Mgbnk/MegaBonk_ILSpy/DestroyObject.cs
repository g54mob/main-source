using System;
using Cpp2ILInjected;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
	public float time;

	public Action OnDestroy;

	private void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E75]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("DestroySelf", time);
	}

	private void DestroySelf()
	{
		Action onDestroy = OnDestroy;
		if (OnDestroy != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v27.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}
}
