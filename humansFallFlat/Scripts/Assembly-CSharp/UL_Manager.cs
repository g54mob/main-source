using UnityEngine;

[AddComponentMenu("UPGEN Lighting/UPGEN Lighting Manager")]
[ExecuteInEditMode]
public sealed class UL_Manager : MonoBehaviour
{
	public static UL_Manager instance;

	public LayerMask layersToRayTrace = -5;

	public bool showDebugRays;

	public bool showDebugGUI = true;

	private void OnEnable()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogWarning("There are 2 audio UPGEN Lighting Managers in the scene. Please ensure there is always exactly one Manager in the scene.");
		}
	}

	private void OnDisable()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

	private void OnGUI()
	{
		if (!showDebugGUI)
		{
			return;
		}
		GUILayout.BeginArea(new Rect(0f, 0f, 200f, Screen.height));
		if (UL_Renderer.HasLightsToRender)
		{
			int renderedLightsCount = UL_Renderer.RenderedLightsCount;
			if (renderedLightsCount > 0)
			{
				UL_GUI_Utils.Text(string.Format("Capacity: <b>{0} / {1}</b>", renderedLightsCount, UL_Renderer.MaxRenderingLightsCount));
			}
			renderedLightsCount = UL_FastLight.all.Count;
			if (renderedLightsCount > 0)
			{
				UL_GUI_Utils.Text(string.Format("Fast Lights: <b>{0}</b>", renderedLightsCount));
			}
			renderedLightsCount = UL_FastGI.all.Count;
			if (renderedLightsCount > 0)
			{
				UL_GUI_Utils.Text(string.Format("Fast GI: <b>{0}</b>", renderedLightsCount));
			}
			renderedLightsCount = UL_RayTracedGI.all.Count;
			if (renderedLightsCount > 0)
			{
				UL_GUI_Utils.Text(string.Format("RayTraced GI: <b>{0}</b>", renderedLightsCount));
			}
		}
		GUILayout.EndArea();
	}
}
