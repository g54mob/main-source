using UnityEngine;

public class FadeHelper : MonoBehaviour
{
	public Renderer renderRef;

	private int renderQueuePosition = 2499;

	private void Awake()
	{
		UpdateRenderQueue();
	}

	private void Update()
	{
		if (Application.isEditor)
		{
			UpdateRenderQueue();
		}
	}

	private void UpdateRenderQueue()
	{
		if (renderRef.material.renderQueue != renderQueuePosition)
		{
			renderRef.material.renderQueue = renderQueuePosition;
		}
	}
}
