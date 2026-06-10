using UnityEngine;

namespace NSMedieval
{
	public class CameraCull : MonoBehaviour
	{
		private void Start()
		{
			Camera component = GetComponent<Camera>();
			float[] array = new float[32];
			array[12] = 70f;
			component.layerCullDistances = array;
		}
	}
}
