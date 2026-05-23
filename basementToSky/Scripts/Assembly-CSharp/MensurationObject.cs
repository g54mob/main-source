using UnityEngine;

public class MensurationObject : MonoBehaviour
{
	public int index;

	public float grams;

	private bool touched;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.TryGetComponent<MensurationScale>(out var component))
		{
			Debug.Log("A");
			component.ObjectOnScale(index, grams);
			if (!touched)
			{
				touched = true;
				AudioManager.S.PlayRandomPitch(AudioManager.S.motorIngred);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.transform.TryGetComponent<MensurationScale>(out var component))
		{
			component.ObjectOnScale(index, 0f - grams);
		}
	}
}
