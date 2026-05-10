using UnityEngine;

public class OscillateLightBrightness : MonoBehaviour
{
	private Light lightComponent;

	[Range(0f, 10f)]
	[SerializeField]
	private float lower;

	[Range(0f, 10f)]
	[SerializeField]
	private float upper;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
