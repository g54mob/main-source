using UnityEngine;

public class SetRedTopWallsCameraRendering : MonoBehaviour
{
	private void Start()
	{
		if (base.gameObject.GetComponent<Camera>() == null)
		{
			Debug.Log("No Camera Found");
		}
	}

	private void OnPreRender()
	{
		Shader.SetGlobalInt("TopWallRed", 1);
	}

	private void OnPostRender()
	{
		Shader.SetGlobalInt("TopWallRed", 0);
	}
}
