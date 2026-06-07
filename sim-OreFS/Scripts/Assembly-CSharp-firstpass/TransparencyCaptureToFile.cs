using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransparencyCaptureToFile : MonoBehaviour
{
	[ContextMenu("Capture Screenshot")]
	public void CaptureFromEditor()
	{
		StartCoroutine(capture());
	}

	private void Update()
	{
		if (Keyboard.current.cKey.wasPressedThisFrame)
		{
			StartCoroutine(capture());
		}
	}

	public IEnumerator capture()
	{
		yield return new WaitForEndOfFrame();
		zzTransparencyCapture.captureScreenshot("capture.png");
		Debug.Log("Screenshot captured");
	}
}
