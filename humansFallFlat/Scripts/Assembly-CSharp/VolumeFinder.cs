using UnityEngine;

public class VolumeFinder : MonoBehaviour
{
	private enum VolumeType
	{
		Custom = 0,
		Box = 1,
		Sphere = 2
	}

	[SerializeField]
	public float volume;

	[SerializeField]
	private VolumeType shapeType;

	private void Start()
	{
		if (shapeType != VolumeType.Custom)
		{
			CalculateVolume();
		}
	}

	public void CalculateVolume()
	{
		if (shapeType == VolumeType.Sphere)
		{
			volume = 4.1887903f * Mathf.Pow(base.transform.localScale.x * 0.5f, 3f);
		}
		if (shapeType == VolumeType.Box)
		{
			volume = base.transform.localScale.x * base.transform.localScale.y * base.transform.localScale.z;
		}
	}
}
