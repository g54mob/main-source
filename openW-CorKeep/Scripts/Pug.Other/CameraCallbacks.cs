using System;
using UnityEngine;

public class CameraCallbacks : MonoBehaviour
{
	public event Action OnPreRenderEvent;

	public event Action OnPostRenderEvent;

	private void OnPreRender()
	{
		this.OnPreRenderEvent?.Invoke();
	}

	private void OnPostRender()
	{
		this.OnPostRenderEvent?.Invoke();
	}
}
