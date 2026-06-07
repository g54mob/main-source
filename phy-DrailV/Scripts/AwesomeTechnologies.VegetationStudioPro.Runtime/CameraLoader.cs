using AwesomeTechnologies.VegetationStudio;
using UnityEngine;

public class CameraLoader : MonoBehaviour
{
	public Camera Camera;

	private void OnEnable()
	{
		if (!(Camera == null))
		{
			VegetationStudioManager.AddCamera(Camera, noFrustumCulling: false, renderDirectToCamera: true);
		}
	}

	private void OnDisable()
	{
		if (!(Camera == null))
		{
			VegetationStudioManager.RemoveCamera(Camera);
		}
	}

	private void Reset()
	{
		Camera = GetComponent<Camera>();
	}
}
