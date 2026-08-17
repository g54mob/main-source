using Cpp2ILInjected;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
	public float time;

	private void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E79]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("DestroySelf", time);
	}

	private void DestroySelf()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}
}
