using System.Collections;
using UnityEngine;

public class RecordTool : MonoBehaviour
{
	public SpriteRenderer buttonLight;

	public Color recordColor;

	public Color waitRecordColor;

	public DraggablePanel panel;

	private bool waitForRecording;

	private float elapsedWaitingTime;

	private Coroutine waitCo;

	public bool isAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void OnOpenFolderButtonDown()
	{
	}

	public void OnOpenFolderButtonUp()
	{
	}

	public void OnRecordButtonDown()
	{
	}

	public void OnRecordButtonUp()
	{
	}

	private void SetRecordButtonColor(Color color)
	{
	}

	public void WaitForRecording()
	{
	}

	public void StartRecording()
	{
	}

	public void StopRecording()
	{
	}

	private void ResetWaiting()
	{
	}

	private IEnumerator WaitCO()
	{
		return null;
	}

	private void StopCoroutines()
	{
	}
}
