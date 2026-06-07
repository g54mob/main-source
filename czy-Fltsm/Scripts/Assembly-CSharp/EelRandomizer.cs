using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class EelRandomizer : MonoBehaviour
{
	public float minFrequencyX = 1f;

	public float maxFrequencyX = 3f;

	public float minFrequencyY = 1f;

	public float maxFrequencyY = 3f;

	public float minAmplitudeX = 0.1f;

	public float maxAmplitudeX = 0.3f;

	public float minAmplitudeY = 0.1f;

	public float maxAmplitudeY = 0.3f;

	private Renderer rend;

	private MaterialPropertyBlock block;

	private void Awake()
	{
		rend = GetComponent<Renderer>();
		block = new MaterialPropertyBlock();
		float value = Random.Range(minFrequencyX, maxFrequencyX);
		float value2 = Random.Range(minAmplitudeX, maxAmplitudeX);
		float value3 = Random.Range(minFrequencyY, maxFrequencyY);
		float value4 = Random.Range(minAmplitudeY, maxAmplitudeY);
		block.SetFloat("_FrequencyX", value);
		block.SetFloat("_AmplitudeX", value2);
		block.SetFloat("_FrequencyY", value3);
		block.SetFloat("_AmplitudeY", value4);
		rend.SetPropertyBlock(block);
	}
}
