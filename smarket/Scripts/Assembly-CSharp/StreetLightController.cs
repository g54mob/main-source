using UnityEngine;

public class StreetLightController : MonoBehaviour
{
	private CullingGroup m_CullingGroup;

	private Light[] m_Lights;

	private float[] m_LightIntensityBuffer;

	private BoundingSphere[] m_BoundingSpheres;

	[SerializeField]
	private float m_LightMaxDistance;

	[SerializeField]
	private float m_ShadowVisibilityDistance;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnStateChanged(CullingGroupEvent sphere)
	{
	}
}
