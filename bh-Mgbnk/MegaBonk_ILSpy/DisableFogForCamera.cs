using UnityEngine;

public class DisableFogForCamera : MonoBehaviour
{
	private bool originalFogState;

	private void OnPreRender()
	{
		bool fog = RenderSettings.fog;
		originalFogState = fog;
		RenderSettings.fog = false;
	}

	private void OnPostRender()
	{
		RenderSettings.fog = originalFogState;
	}
}
