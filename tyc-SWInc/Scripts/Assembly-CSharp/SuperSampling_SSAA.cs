using SSAA;
using UnityEngine;

public class SuperSampling_SSAA : MonoBehaviour
{
	public float Scale;

	public bool unlocked;

	public SSAAFilter Filter = SSAAFilter.BilinearDefault;

	public bool UseDynamicOutputResolution;

	private void OnEnable()
	{
		base.gameObject.AddComponent<internal_SSAA>().hideFlags = HideFlags.HideAndDontSave | HideFlags.HideInInspector;
		internal_SSAA.UseDynamicOutputResolution = UseDynamicOutputResolution;
		internal_SSAA.Filter = Filter;
		internal_SSAA.ChangeScale(Scale);
	}

	private void OnDisable()
	{
		internal_SSAA component = base.gameObject.GetComponent<internal_SSAA>();
		if (component != null)
		{
			Object.Destroy(component);
		}
	}
}
