using UnityEngine;

public class PrecipitationParticleSystemController : MonoBehaviour
{
	[Header("Components")]
	public ParticleSystem snowSystem;

	public ParticleSystem rainSystem;

	[Header("Settings")]
	public int snowMaxEmissionRate;

	public int rainMaxEmissionRate;

	[Header("State")]
	public bool snowMode;

	private static PrecipitationParticleSystemController _instance;

	public static PrecipitationParticleSystemController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetSnowMode(bool val, bool forceUpdate = false)
	{
	}

	public void SetEnabled(bool val)
	{
	}

	public void AddAreaTrigger(Collider coll)
	{
	}

	public void RemoveAreaTrigger(Collider coll)
	{
	}

	private void Update()
	{
	}
}
