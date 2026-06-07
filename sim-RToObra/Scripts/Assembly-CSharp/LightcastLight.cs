using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightcastLight : MonoBehaviour
{
	public enum Baked
	{
		None = 0,
		Static = 1,
		DynamicInGroup = 2,
		DynamicIndividually = 3
	}

	[Serializable]
	public class Pose
	{
		public Vector3 position;

		public Quaternion rotation;

		public float runtimeWeight = 1f;
	}

	public string familyId;

	public bool falloff = true;

	public bool createDynamicNearLight;

	public bool testIndividually;

	[NonSerialized]
	public float illum = 1f;

	[LightcastBaked]
	public Baked baked;

	[LightcastBaked]
	public int dynamicLayerIndex = -1;

	[LightcastBaked]
	public List<Pose> poses;

	private Light nearLight;

	private Bounds nearLightBounds;

	private float baseIntensity;

	private Light sourceLight_;

	public Light sourceLight
	{
		get
		{
			if (sourceLight_ == null)
			{
				sourceLight_ = GetComponent<Light>();
			}
			return sourceLight_;
		}
	}

	private void Start()
	{
		baseIntensity = sourceLight.intensity;
		if (baked != Baked.DynamicIndividually)
		{
			return;
		}
		sourceLight.enabled = false;
		if (!createDynamicNearLight)
		{
			return;
		}
		GameObject gameObject = new GameObject();
		nearLight = gameObject.AddComponent<Light>();
		nearLight.name = "Near";
		nearLight.transform.parent = base.transform;
		nearLight.transform.localPosition = Vector3.zero;
		nearLight.transform.localRotation = Quaternion.identity;
		nearLight.transform.localScale = Vector3.one;
		nearLight.type = sourceLight.type;
		nearLight.cookie = sourceLight.cookie;
		nearLight.cookieSize = sourceLight.cookieSize;
		nearLight.color = sourceLight.color;
		nearLight.range = sourceLight.range;
		nearLight.shadows = sourceLight.shadows;
		nearLight.shadowBias = sourceLight.shadowBias;
		nearLight.shadowNormalBias = sourceLight.shadowNormalBias;
		nearLight.shadowStrength = sourceLight.shadowStrength;
		nearLight.shadowNearPlane = sourceLight.shadowNearPlane;
		nearLight.spotAngle = sourceLight.spotAngle;
		nearLight.enabled = false;
		if (nearLight.type == LightType.Spot)
		{
			Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
			nearLightBounds = new Bounds(base.transform.position, Vector3.zero);
			nearLightBounds.Encapsulate(localToWorldMatrix.MultiplyPoint(nearLight.range * Vector3.forward));
			float num = nearLight.range * Mathf.Tan(nearLight.spotAngle * 0.5f);
			for (int i = 0; i < 8; i++)
			{
				float f = (float)Math.PI * 2f * (float)i / 8f;
				nearLightBounds.Encapsulate(localToWorldMatrix.MultiplyPoint(new Vector3(num * Mathf.Cos(f), num * Mathf.Sin(f), nearLight.range)));
			}
		}
		else if (nearLight.type == LightType.Point)
		{
			nearLightBounds = new Bounds(base.transform.position, nearLight.range * Vector3.one);
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		if (baked == Baked.DynamicIndividually && Lightcaster.instance != null)
		{
			Lightcaster.instance.SetDynamicLayerAlpha(dynamicLayerIndex, 0f);
			for (int i = 1; i < poses.Count; i++)
			{
				Lightcaster.instance.SetDynamicLayerAlpha(dynamicLayerIndex + i, 0f);
			}
		}
	}

	private void Update()
	{
		if (Lightcaster.instance == null)
		{
			return;
		}
		if (baked == Baked.DynamicIndividually)
		{
			Vector2 vector = illum * GetNearBlend();
			if (poses.Count > 0)
			{
				UpdatePoseWeights();
				for (int i = 0; i < poses.Count; i++)
				{
					Lightcaster.instance.SetDynamicLayerAlpha(dynamicLayerIndex + i, poses[i].runtimeWeight * vector.y);
				}
			}
			else
			{
				Lightcaster.instance.SetDynamicLayerAlpha(dynamicLayerIndex, vector.y);
			}
			if (nearLight != null)
			{
				nearLight.intensity = baseIntensity * vector.x;
				nearLight.enabled = nearLight.intensity > 0.001f;
			}
		}
		else if (baked == Baked.None)
		{
			if (testIndividually)
			{
				sourceLight.intensity = baseIntensity * Lightcaster.instance.GetDynamicLayerAlpha(dynamicLayerIndex);
				Lightcaster.instance.SetDynamicLayerAlpha(dynamicLayerIndex, illum);
			}
			else
			{
				sourceLight.intensity = baseIntensity * Lightcaster.instance.GetDynamicLayerAlpha(dynamicLayerIndex);
			}
			sourceLight.enabled = sourceLight.intensity > 0.001f;
		}
	}

	private void UpdatePoseWeights()
	{
		float num = 0f;
		foreach (Pose pose in poses)
		{
			float magnitude = (pose.position - base.transform.position).magnitude;
			float num2 = Quaternion.Angle(pose.rotation, base.transform.rotation);
			pose.runtimeWeight = 1f / Mathf.Max(0.001f, magnitude + num2);
			num += pose.runtimeWeight;
		}
		foreach (Pose pose2 in poses)
		{
			pose2.runtimeWeight /= num;
		}
	}

	private Vector2 GetNearBlend()
	{
		if (nearLight == null)
		{
			return Vector2.up;
		}
		Plane[] mainCameraFrustumPlanes = Lightcaster.instance.mainCameraFrustumPlanes;
		if (mainCameraFrustumPlanes == null)
		{
			return Vector2.up;
		}
		if (!GeometryUtility.TestPlanesAABB(mainCameraFrustumPlanes, nearLightBounds))
		{
			return Vector2.zero;
		}
		Vector3 zero = Vector3.zero;
		zero = ((nearLight.type != LightType.Spot) ? base.transform.position : base.transform.localToWorldMatrix.MultiplyPoint(nearLight.range * 0.5f * Vector3.forward));
		Vector3 position = Lightcaster.instance.mainCamera.transform.position;
		float magnitude = (position - zero).magnitude;
		float num = Util.LerpScale(magnitude, sourceLight.range * 0.5f, sourceLight.range, 1f, 0f);
		num *= Util.LerpScale(Mathf.Abs(position.y - GetDeckY(zero)), 0.25f, 2f, 1f, 0f);
		return new Vector2(num, 1f - num);
	}

	private static float GetDeckY(Vector3 pos)
	{
		return (float)Mathf.FloorToInt(pos.y / 2.5f) * 2.5f + 1.8f;
	}
}
