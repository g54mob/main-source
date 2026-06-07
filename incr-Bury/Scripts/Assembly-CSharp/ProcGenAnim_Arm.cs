using System;
using UnityEngine;

public class ProcGenAnim_Arm : MonoBehaviour
{
	[Header("Body")]
	[SerializeField]
	private ProcGenAnim_Body body;

	[Header("Reciprical Foot")]
	[SerializeField]
	private ProcGenAnim_Foot recipricalFoot;

	[SerializeField]
	private ProcGenAnim_Foot sameSideFoot;

	[Header("Placement")]
	[SerializeField]
	private float footMatchDistanceReach;

	private Vector3 startingLocalPosition;

	[SerializeField]
	private float handHeight;

	[SerializeField]
	private float handSwingDip;

	public Vector3 currPosition;

	public Vector3 newPosition;

	public Vector3 oldPosition;

	[SerializeField]
	private float handX;

	[Header("Animation Curves")]
	[SerializeField]
	private AnimationCurve armSwingCurve_Y;

	[SerializeField]
	private float yCurveScale;

	[SerializeField]
	private AnimationCurve armSwingCurve_Z;

	[SerializeField]
	private float zCurveScale;

	private void Awake()
	{
		ProcGenAnim_Foot procGenAnim_Foot = recipricalFoot;
		procGenAnim_Foot.OnNewPositionChosen = (Action)Delegate.Combine(procGenAnim_Foot.OnNewPositionChosen, new Action(NewFootSpotWasChosen));
	}

	private void OnDestroy()
	{
		ProcGenAnim_Foot procGenAnim_Foot = recipricalFoot;
		procGenAnim_Foot.OnNewPositionChosen = (Action)Delegate.Remove(procGenAnim_Foot.OnNewPositionChosen, new Action(NewFootSpotWasChosen));
	}

	private void Start()
	{
		currPosition = (newPosition = (oldPosition = base.transform.position));
		startingLocalPosition = base.transform.localPosition;
	}

	private void Update()
	{
		PlaceArmBasedOnAnimCurveAndFootLerp();
	}

	private void PlaceArmBasedOnAnimCurveAndFootLerp()
	{
		base.transform.localPosition = new Vector3(handX, armSwingCurve_Y.Evaluate(recipricalFoot.GetLerpValue()) * yCurveScale, armSwingCurve_Z.Evaluate(recipricalFoot.GetLerpValue()) * zCurveScale);
	}

	private void HandleProcGenArmMatchFootSwing()
	{
		base.transform.position = currPosition;
		float lerpValue = recipricalFoot.GetLerpValue();
		if (lerpValue < 1f)
		{
			Vector3 vector = Vector3.Lerp(oldPosition, newPosition, lerpValue);
			vector.y += Mathf.Sin(lerpValue * MathF.PI) * (0f - handSwingDip);
			currPosition = vector;
		}
		else
		{
			oldPosition = newPosition;
		}
	}

	private void NewFootSpotWasChosen()
	{
		newPosition = CalculateNewArmPosition(recipricalFoot.newPosition);
	}

	private Vector3 CalculateNewArmPosition(Vector3 _referencePos)
	{
		Vector3 vector = new Vector3(_referencePos.x, 0f, _referencePos.z);
		Vector3 vector2 = new Vector3(body.transform.position.x, 0f, body.transform.position.z);
		Vector3 normalized = (vector - vector2).normalized;
		Vector3 vector3 = new Vector3(body.transform.position.x, body.transform.position.y + handHeight, body.transform.position.z);
		Vector3 vector4 = body.transform.TransformVector(new Vector3(handX, 0f, 0f));
		return vector3 + vector4 + normalized * footMatchDistanceReach;
	}
}
