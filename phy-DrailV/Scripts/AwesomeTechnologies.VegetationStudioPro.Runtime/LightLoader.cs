using AwesomeTechnologies.VegetationStudio;
using UnityEngine;

public class LightLoader : MonoBehaviour
{
	public Light Light;

	private void OnEnable()
	{
		if (!(Light == null))
		{
			VegetationStudioManager.SetSunDirectionalLight(Light);
		}
	}

	private void OnDisable()
	{
		if (!(Light == null))
		{
			VegetationStudioManager.SetSunDirectionalLight(null);
		}
	}

	private void Reset()
	{
		Light = GetComponent<Light>();
	}
}
