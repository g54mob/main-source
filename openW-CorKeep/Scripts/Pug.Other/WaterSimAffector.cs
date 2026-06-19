using System;
using System.Collections.Generic;
using UnityEngine;

public class WaterSimAffector : MonoBehaviour
{
	[Serializable]
	public enum Type
	{
		Circle = 0,
		Square = 1
	}

	public static readonly List<WaterSimAffector> instances = new List<WaterSimAffector>();

	public Type type;

	[Min(0f)]
	public float movement = 1f;

	[Min(0f)]
	public float bobFrequency = 4f;

	[Min(0f)]
	public float bobAmplitudeStill = 0.5f;

	[Min(0f)]
	public float bobAmplitudeMovement = 1f;

	public bool smoothBobbing;

	[HideInInspector]
	public bool includedInSim;

	[HideInInspector]
	public Matrix4x4 prevLocalToWorld;

	[HideInInspector]
	public Vector3 prevPosition;

	private float m_randomOffset;

	public float randomOffset => m_randomOffset;

	private void OnEnable()
	{
		instances.Add(this);
		prevLocalToWorld = base.transform.localToWorldMatrix;
		prevPosition = base.transform.position + WaterSim.GetRenderOrigin();
		includedInSim = false;
		m_randomOffset = UnityEngine.Random.value;
	}

	private void OnDisable()
	{
		instances.Remove(this);
	}

	private void OnDrawGizmosSelected()
	{
		if (Application.isPlaying)
		{
			Gizmos.color = (includedInSim ? Color.green : Color.red);
		}
		else
		{
			Gizmos.color = Color.white;
		}
		Gizmos.matrix = base.transform.localToWorldMatrix;
		switch (type)
		{
		case Type.Circle:
		{
			for (int i = 0; i < 16; i++)
			{
				float f = (float)i / 16f * MathF.PI * 2f;
				float f2 = ((float)i + 1f) / 16f * MathF.PI * 2f;
				Gizmos.DrawLine(new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f)) / 2f, new Vector3(Mathf.Cos(f2), 0f, Mathf.Sin(f2)) / 2f);
			}
			break;
		}
		case Type.Square:
			Gizmos.DrawLine(new Vector3(-0.5f, 0f, -0.5f), new Vector3(0.5f, 0f, -0.5f));
			Gizmos.DrawLine(new Vector3(0.5f, 0f, -0.5f), new Vector3(0.5f, 0f, 0.5f));
			Gizmos.DrawLine(new Vector3(0.5f, 0f, 0.5f), new Vector3(-0.5f, 0f, 0.5f));
			Gizmos.DrawLine(new Vector3(-0.5f, 0f, 0.5f), new Vector3(-0.5f, 0f, -0.5f));
			break;
		}
	}
}
