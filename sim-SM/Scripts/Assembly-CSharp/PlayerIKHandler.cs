using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerIKHandler : MonoBehaviour
{
	[SerializeField]
	private TwoBoneIKConstraint m_LeftHandRig;

	private Transform m_LeftHandTarget;

	private Transform m_LeftHandHint;

	[SerializeField]
	private TwoBoneIKConstraint m_RightHandRig;

	private Transform m_RightHandTarget;

	private Transform m_RightHandHint;

	[SerializeField]
	private TwoBoneIKConstraint m_RightLegRig;

	private Transform m_RightLegTarget;

	private Transform m_RightLegHint;

	[SerializeField]
	private TwoBoneIKConstraint m_LeftLegRig;

	private Transform m_LeftLegTarget;

	private Transform m_LeftLegHint;

	private RigBuilder m_RigBuilder;

	private void Awake()
	{
	}

	public void SetLeftHand(Transform target, Transform hint)
	{
	}

	public void SetRightHand(Transform target, Transform hint)
	{
	}

	public void SetLeftLeg(Transform target, Transform hint)
	{
	}

	public void SetRightLeg(Transform target, Transform hint)
	{
	}

	public void SetWeight(string ikName, float weight)
	{
	}

	private void ApplyTransform(TwoBoneIKConstraint ik, Transform target, Transform hint)
	{
	}

	private void UpdatePartWeights()
	{
	}

	private void Update()
	{
	}
}
