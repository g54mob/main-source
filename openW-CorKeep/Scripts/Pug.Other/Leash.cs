using System;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class Leash : PoolableSimple
{
	private const float FLOOR_Y = 0.001f;

	[NonSerialized]
	public EntityMonoBehaviour leashOwner;

	[NonSerialized]
	public EntityMonoBehaviour leashTarget;

	public LineRenderer leashLine;

	public LineRenderer leashLineShadow;

	public AnimationCurve slackingLeashLineCurve;

	public AnimationCurve straightLeashLineCurve;

	private const float MAX_DISTANCE_SQ_TO_SHOW_LEASH = 144f;

	private Vector3 m_slackPoint;

	private Vector3 m_slackPointVelocity;

	private Vector3[] m_pointArray;

	private Vector3[] m_pointArrayTmp;

	private void Awake()
	{
		leashLine.positionCount = 10;
		leashLineShadow.positionCount = 10;
		m_pointArray = new Vector3[leashLine.positionCount];
		m_pointArrayTmp = new Vector3[leashLine.positionCount];
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		leashLine.gameObject.SetActive(value: false);
	}

	private void FixedUpdate()
	{
		if (leashTarget == null || leashOwner == null)
		{
			leashLine.gameObject.SetActive(value: false);
		}
		else if (EntityUtility.EntityExists(leashOwner.entity, leashOwner.world) && EntityUtility.EntityExists(leashTarget.entity, leashTarget.world))
		{
			float fixedDeltaTime = Time.fixedDeltaTime;
			Vector3 vector = leashOwner.WorldPosition + Vector3.up * 0.5f;
			Vector3 vector2 = leashTarget.WorldPosition + Vector3.up * 0.5f;
			PlayerController playerController = leashOwner as PlayerController;
			if (playerController != null)
			{
				Vector3 vector3 = (Vector3)EntityUtility.GetComponentData<EffectiveVelocityCD>(playerController.entity, playerController.world).Value.ToFloat3() * (fixedDeltaTime * 2f);
				vector3 = math.normalizesafe(vector3) * math.min(math.length(vector3), 0.5f);
				vector = playerController.WorldPosition + playerController.GetLeashPoint() + vector3;
			}
			Cattle cattle = leashTarget as Cattle;
			if (cattle != null)
			{
				vector2 = leashTarget.WorldPosition + cattle.GetLeashPoint();
			}
			Vector3 vector4 = (vector + vector2) / 2f;
			if (!leashLine.gameObject.activeInHierarchy)
			{
				m_slackPoint = vector4;
				m_slackPointVelocity = Vector3.zero;
				leashLine.gameObject.SetActive(value: true);
			}
			float magnitude = (vector2 - vector).magnitude;
			float num = ((!(magnitude > 3f)) ? Mathf.Sqrt(Mathf.Pow(1.5f, 2f) - Mathf.Pow(magnitude * 0.5f, 2f)) : 0f);
			float num2 = 1f;
			float num3 = 9.81f;
			if (m_slackPoint.y < 0f)
			{
				num2 = 10f;
				num3 = 0f;
			}
			m_slackPointVelocity *= Mathf.Clamp01(1f - fixedDeltaTime * num2);
			m_slackPointVelocity += fixedDeltaTime * num3 * Vector3.down;
			Vector3 vector5 = vector - m_slackPoint;
			Vector3 vector6 = vector2 - m_slackPoint;
			float magnitude2 = vector5.magnitude;
			float magnitude3 = vector6.magnitude;
			vector5 = math.normalizesafe(vector5);
			vector6 = math.normalizesafe(vector6);
			m_slackPointVelocity += GetSpringForce(Mathf.Max(0f, magnitude2 - 1.5f), 10f) * 1f * fixedDeltaTime * vector5;
			m_slackPointVelocity += GetSpringForce(Mathf.Max(0f, magnitude3 - 1.5f), 10f) * 1f * fixedDeltaTime * vector6;
			m_slackPointVelocity = math.normalizesafe(m_slackPointVelocity) * math.min(math.length(m_slackPointVelocity), 5f);
			m_slackPoint += m_slackPointVelocity * fixedDeltaTime;
			Vector3 vector7 = vector4 - m_slackPoint;
			float magnitude4 = vector7.magnitude;
			if (magnitude4 > Mathf.Epsilon)
			{
				vector7 /= magnitude4;
			}
			if (magnitude4 > num)
			{
				float num4 = magnitude4 - num;
				m_slackPoint += vector7 * num4 * Mathf.Clamp01(Time.deltaTime * 100f);
				m_slackPointVelocity = Vector3.ProjectOnPlane(m_slackPointVelocity, vector7);
				m_slackPointVelocity += GetSpringForce(magnitude4 - num, 100f) * 1f * fixedDeltaTime * vector7;
				_ = m_slackPoint.y;
				_ = 0f;
			}
			m_slackPointVelocity = math.normalizesafe(m_slackPointVelocity) * math.min(math.length(m_slackPointVelocity), 5f);
			SetLeashPoints(vector, vector2, vector7, magnitude4);
		}
	}

	private float GetSpringForce(float distance, float springConstant)
	{
		return distance * springConstant;
	}

	private void SetLeashPoints(Vector3 ownerPos, Vector3 targetPos, Vector3 dirToCenter, float distToCenter)
	{
		m_pointArray[0] = ownerPos;
		for (int i = 1; i < m_pointArray.Length - 1; i++)
		{
			float num = (float)i / ((float)m_pointArray.Length - 1f);
			Vector3 vector;
			if (num < 0.5f)
			{
				float num2 = Mathf.Clamp01(num * 2f);
				vector = Vector3.Lerp(ownerPos, m_slackPoint, num2) - dirToCenter * distToCenter * (0.5f - Mathf.Abs(num2 - 0.5f)) * 0.5f;
			}
			else
			{
				float num3 = Mathf.Clamp01(num * 2f - 1f);
				vector = Vector3.Lerp(m_slackPoint, targetPos, num3) - dirToCenter * distToCenter * (0.5f - Mathf.Abs(num3 - 0.5f)) * 0.5f;
			}
			vector.y = Mathf.Max(vector.y, 0.002f);
			m_pointArray[i] = vector;
		}
		m_pointArray[m_pointArray.Length - 1] = targetPos;
	}

	private void LateUpdate()
	{
		if (leashLine.gameObject.activeInHierarchy)
		{
			for (int i = 0; i < m_pointArray.Length; i++)
			{
				m_pointArrayTmp[i] = EntityMonoBehaviour.ToRenderFromWorld(m_pointArray[i]);
			}
			leashLine.SetPositions(m_pointArrayTmp);
			for (int j = 0; j < m_pointArray.Length; j++)
			{
				Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(m_pointArray[j]);
				vector.y = 0.001f;
				m_pointArrayTmp[j] = vector;
			}
			leashLineShadow.SetPositions(m_pointArrayTmp);
		}
	}
}
