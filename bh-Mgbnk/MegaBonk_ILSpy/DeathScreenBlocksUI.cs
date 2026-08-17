using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class DeathScreenBlocksUI : MonoBehaviour
{
	public Material material;

	public AudioSource audio;

	private bool started;

	private float transitionTime = 3f;

	private float timer;

	public void StartTransition(float transitionTime)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F98]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		this.transitionTime = transitionTime;
		started = true;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		material.SetFloat("_Progress", 0f);
		audio.Play();
	}

	private void Update()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F99]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (started)
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime / transitionTime;
			float value = Easing.InQuad(timer = num + timer);
			material.SetFloat("_Progress", value);
		}
	}
}
