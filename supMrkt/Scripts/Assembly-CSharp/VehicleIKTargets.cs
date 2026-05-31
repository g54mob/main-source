using UnityEngine;

public class VehicleIKTargets : MonoBehaviour
{
	[SerializeField]
	private Transform m_LeftHandTargetTransform;

	[SerializeField]
	private Transform m_RightHandTargetTransform;

	[SerializeField]
	private Transform m_LeftHandHintTransform;

	[SerializeField]
	private Transform m_RightHandHintTransform;

	[SerializeField]
	private Transform m_LeftLegTargetTransform;

	[SerializeField]
	private Transform m_LeftLegHintTransform;

	[SerializeField]
	private Transform m_RightLegTargetTransform;

	[SerializeField]
	private Transform m_RightLegHintTransform;

	public Vector3 LeftHandIKTarget => default(Vector3);

	public Vector3 RightHandIKTarget => default(Vector3);

	public Vector3 LeftHandIKHint => default(Vector3);

	public Vector3 RightHandIKHint => default(Vector3);

	public void Apply(PlayerIKHandler playerIK)
	{
	}
}
