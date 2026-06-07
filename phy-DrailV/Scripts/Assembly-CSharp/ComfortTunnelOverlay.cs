using DV;
using UnityEngine;
using VRTK;

public class ComfortTunnelOverlay : VRTK_TunnelOverlay
{
	protected int shaderPropertyFarPlaneMultiplier;

	protected int shaderPropertyRadiusMultiplier;

	[Range(1f, 30f)]
	public float farPlaneMulti = 16.7f;

	[Range(0.1f, 3f)]
	public float radiusMultiplier = 1.4f;

	private bool lostParent;

	protected override void Awake()
	{
		base.Awake();
		shaderPropertyFarPlaneMultiplier = Shader.PropertyToID("_FarPlaneMultiplier");
		shaderPropertyRadiusMultiplier = Shader.PropertyToID("_RadiusMultiplier");
		matCameraEffect = Resources.Load<Material>("TunnelOverlay_v2");
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		lostParent = false;
	}

	private void Update()
	{
		if (!TimeUtil.IsFlowing)
		{
			return;
		}
		if ((bool)playarea.parent)
		{
			Vector3 forward = playarea.forward;
			Vector3 localPosition = playarea.parent.localPosition;
			if (lostParent)
			{
				lastPosition = localPosition;
			}
			float num = Vector3.Angle(lastForward, forward) / Time.deltaTime;
			num = (num - minimumRotation) / (maximumRotation - minimumRotation);
			if (maximumSpeed > 0f)
			{
				float num2 = (localPosition - lastPosition).magnitude / Time.deltaTime;
				num2 = (num2 - minimumSpeed) / (maximumSpeed - minimumSpeed);
				if (num2 > num)
				{
					num = num2;
				}
			}
			float num3 = initialEffectSize * maximumEffectCoverage;
			float num4 = maximumEffectSize * maximumEffectCoverage - num3;
			num = Mathf.Clamp01(num) * num4;
			angularVelocity = Mathf.SmoothDamp(angularVelocity, num, ref angularVelocitySlew, smoothingTime);
			SetShaderFeather(effectColor, angularVelocity + num3, featherSize);
			lastForward = forward;
			lastPosition = localPosition;
			if (effectSkybox != null)
			{
				matCameraEffect.SetMatrixArray("_EyeToWorld", new Matrix4x4[2]
				{
					headsetCamera.GetStereoViewMatrix(Camera.StereoscopicEye.Left).inverse,
					headsetCamera.GetStereoViewMatrix(Camera.StereoscopicEye.Right).inverse
				});
				Matrix4x4[] array = new Matrix4x4[2];
				array[0] = headsetCamera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left);
				array[1] = headsetCamera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right);
				array[0] = GL.GetGPUProjectionMatrix(array[0], renderIntoTexture: true).inverse;
				array[1] = GL.GetGPUProjectionMatrix(array[1], renderIntoTexture: true).inverse;
				array[0][1, 1] *= -1f;
				array[1][1, 1] *= -1f;
				matCameraEffect.SetMatrixArray("_EyeProjection", array);
			}
			matCameraEffect.SetFloat(shaderPropertyFarPlaneMultiplier, farPlaneMulti);
			matCameraEffect.SetFloat(shaderPropertyRadiusMultiplier, radiusMultiplier);
			lostParent = false;
		}
		else
		{
			lostParent = true;
		}
	}

	protected override void FixedUpdate()
	{
	}
}
