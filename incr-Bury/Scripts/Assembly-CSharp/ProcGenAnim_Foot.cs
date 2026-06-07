using System;
using UnityEngine;

public class ProcGenAnim_Foot : MonoBehaviour
{
	[Header("Walk Params")]
	[SerializeField]
	private float stepDistance;

	private float stepDistance_ScaledByVelo;

	[SerializeField]
	private float stepPredictionOffset;

	[SerializeField]
	private float stepHeight;

	[SerializeField]
	private float footSpacingX;

	[SerializeField]
	private float groundDetectRange;

	[SerializeField]
	private float groundHeightOffset;

	[SerializeField]
	private float catchUpBoost;

	[SerializeField]
	private float catchUpThreshold;

	[Header("Parts")]
	[SerializeField]
	private ProcGenAnim_Body body;

	[SerializeField]
	private ProcGenAnim_Foot otherFoot;

	[Header("Collision")]
	[SerializeField]
	private LayerMask groundRayMask;

	[Header("Smoothing")]
	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Vector2 minMaxLerpSpeedMultis;

	private float posLerp;

	public Vector3 currPosition;

	public Vector3 newPosition;

	public Vector3 oldPosition;

	private float zxVeloAtStepPrediction;

	private float lerpSpeedByVelocity;

	public Action OnNewPositionChosen;

	private bool agentIsMoving;

	private bool agentIsMoving_LastFrame;

	private float agentStoppedMoving_BufferTime_Curr;

	[SerializeField]
	private float agentStoppedMoving_Buffer = 0.25f;

	private bool justStoppedMoving;

	private void Start()
	{
		currPosition = (newPosition = (oldPosition = base.transform.position));
		CalculateLerpSpeedWhenFootPlacementIsChosen();
	}

	private void Update()
	{
		CalculateStepDistanceFromBodyVelocity();
		HandleProcGenWalk();
	}

	private void HandleProcGenWalk()
	{
		base.transform.position = currPosition;
		agentIsMoving = body.GetNormalizedVelocity() > 0f;
		if (agentIsMoving)
		{
			agentStoppedMoving_BufferTime_Curr = agentStoppedMoving_Buffer;
		}
		else if (agentStoppedMoving_BufferTime_Curr > 0f)
		{
			agentStoppedMoving_BufferTime_Curr -= Time.deltaTime;
			agentIsMoving = true;
			if (agentStoppedMoving_BufferTime_Curr <= 0f)
			{
				justStoppedMoving = true;
				agentIsMoving = false;
			}
		}
		else
		{
			agentIsMoving = false;
		}
		if (agentIsMoving)
		{
			if (Physics.Raycast(new Ray(body.transform.position + body.transform.right * footSpacingX, Vector3.down), out var hitInfo, groundDetectRange, groundRayMask))
			{
				Vector3 b = new Vector3(hitInfo.point.x, hitInfo.point.y + groundHeightOffset, hitInfo.point.z) + GetPredictionFootPlacementOffset();
				if (Vector3.Distance(newPosition, b) > stepDistance && !otherFoot.IsMoving() && posLerp >= 1f)
				{
					posLerp = 0f;
					newPosition = b;
					zxVeloAtStepPrediction = body.GetBodyVelocity().magnitude;
					CalculateLerpSpeedWhenFootPlacementIsChosen();
					if (OnNewPositionChosen != null)
					{
						OnNewPositionChosen();
					}
				}
			}
		}
		else if (justStoppedMoving)
		{
			justStoppedMoving = false;
			if (Physics.Raycast(new Ray(body.transform.position + body.transform.right * footSpacingX, Vector3.down), out var hitInfo2, groundDetectRange, groundRayMask))
			{
				Vector3 vector = new Vector3(hitInfo2.point.x, hitInfo2.point.y + groundHeightOffset, hitInfo2.point.z);
				posLerp = 0f;
				newPosition = vector;
				zxVeloAtStepPrediction = body.GetBodyVelocity().magnitude;
				CalculateLerpSpeedWhenFootPlacementIsChosen();
				if (OnNewPositionChosen != null)
				{
					OnNewPositionChosen();
				}
			}
		}
		if (posLerp < 1f)
		{
			Vector3 vector2 = Vector3.Lerp(oldPosition, newPosition, posLerp);
			vector2.y += Mathf.Sin(posLerp * MathF.PI) * stepHeight;
			currPosition = vector2;
			posLerp += Time.deltaTime * (lerpSpeed + AdditionalLerpSpeedByDistance());
		}
		else
		{
			oldPosition = newPosition;
		}
		agentIsMoving_LastFrame = agentIsMoving;
	}

	public bool IsMoving()
	{
		return posLerp < 1f;
	}

	private float AdditionalLerpSpeedByDistance()
	{
		float num = Vector3.Distance(body.transform.position, newPosition);
		if (num > stepDistance + catchUpThreshold + stepPredictionOffset)
		{
			float num2 = num - stepDistance;
			Debug.Log("ZOOPIN");
			return num2 * (lerpSpeed / stepDistance) * catchUpBoost + 1f;
		}
		return 1f;
	}

	private void CalculateLerpSpeedWhenFootPlacementIsChosen()
	{
		float num = Mathf.Clamp(body.GetBodyVelocity().magnitude, minMaxLerpSpeedMultis.x, minMaxLerpSpeedMultis.y);
		lerpSpeedByVelocity = lerpSpeed * num;
	}

	private Vector3 GetPredictionFootPlacementOffset()
	{
		return body.GetBodyVelocity().normalized * stepPredictionOffset;
	}

	public float GetLerpValue()
	{
		return posLerp;
	}

	private void CalculateStepDistanceFromBodyVelocity()
	{
		stepDistance_ScaledByVelo = stepDistance * body.GetNormalizedVelocity();
	}
}
