using System;
using UnityEngine;
using UnityEngine.Serialization;

public class OcclusionController : MonoBehaviour
{
	[Serializable]
	public class OcclusionGroup
	{
		[FormerlySerializedAs("OccludeData")]
		public OccludeeData OccludeeData;

		[NonSerialized]
		public BoundingSphere BoundingSphere;
	}

	[SerializeField]
	private Camera m_TargetCamera;

	[SerializeField]
	private OcclusionGroup[] m_OcclusionGroups;

	private CullingGroup m_Occlusion;

	private BoundingSphere[] m_BoundingSpheres;

	[SerializeField]
	private float m_VisibilityDistance;

	private void Awake()
	{
	}

	private void OnDestroy()
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

	private void OnStateChanged(CullingGroupEvent sphere)
	{
	}
}
