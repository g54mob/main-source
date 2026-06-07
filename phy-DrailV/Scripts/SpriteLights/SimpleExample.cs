using UnityEngine;
using UnityEngine.Rendering;

public class SimpleExample : MonoBehaviour
{
	public Material material;

	private void Start()
	{
		int num = 5;
		SpriteLights.Init(0f, 0f, Camera.main.fieldOfView, Screen.height);
		SpriteLights.LightData[] array = new SpriteLights.LightData[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = default(SpriteLights.LightData);
			array[i].size = 1f;
			array[i].frontColor = Color.red;
			array[i].backColor = Color.green;
			array[i].rotation = Quaternion.Euler(new Vector3(0f, 0f, 1f));
			array[i].position = new Vector3(0f, 0f, i);
		}
		SpriteLights.CreateLights("SomeLights", array, material, IndexFormat.UInt16, null);
	}
}
