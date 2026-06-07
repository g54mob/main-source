using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_TunnelOverlay")]
	public class VRTK_TunnelOverlay : MonoBehaviour
	{
		[Header("Movement Settings")]
		[Tooltip("Minimum rotation speed for the effect to activate (degrees per second).")]
		public float minimumRotation;

		[Tooltip("Maximum rotation speed for the effect have its max settings applied (degrees per second).")]
		public float maximumRotation = 45f;

		[Tooltip("Minimum movement speed for the effect to activate.")]
		public float minimumSpeed;

		[Tooltip("Maximum movement speed where the effect will have its max settings applied.")]
		public float maximumSpeed = 1f;

		[Header("Effect Settings")]
		[Tooltip("The color to use for the tunnel effect.")]
		public Color effectColor = Color.black;

		[Tooltip("An optional skybox texture to use for the tunnel effect.")]
		public Texture effectSkybox;

		[Tooltip("The initial amount of screen coverage the tunnel to consume without any movement.")]
		[Range(0f, 1f)]
		public float initialEffectSize;

		[Tooltip("Screen coverage at the maximum tracked values.")]
		[Range(0f, 1f)]
		public float maximumEffectSize = 0.65f;

		[Tooltip("Feather effect size around the cut-off as fraction of screen.")]
		[Range(0f, 0.5f)]
		public float featherSize = 0.1f;

		[Tooltip("Smooth out radius over time.")]
		public float smoothingTime = 0.15f;

		protected Transform headset;

		protected Camera headsetCamera;

		protected Transform playarea;

		protected VRTK_TunnelEffect cameraEffect;

		protected float angularVelocity;

		protected float angularVelocitySlew;

		protected Vector3 lastForward;

		protected Vector3 lastPosition;

		protected Material matCameraEffect;

		protected int shaderPropertyColor;

		protected int shaderPropertyAV;

		protected int shaderPropertyFeather;

		protected int shaderPropertySkyboxTexture;

		protected Color originalColor;

		protected float originalAngularVelocity;

		protected float originalFeatherSize;

		protected Texture originalSkyboxTexture;

		protected float maximumEffectCoverage = 1.15f;

		protected bool createEffectSkybox;

		protected virtual void Awake()
		{
			matCameraEffect = Resources.Load<Material>("TunnelOverlay");
			shaderPropertyColor = Shader.PropertyToID("_Color");
			shaderPropertyAV = Shader.PropertyToID("_AngularVelocity");
			shaderPropertyFeather = Shader.PropertyToID("_FeatherSize");
			shaderPropertySkyboxTexture = Shader.PropertyToID("_SecondarySkyBox");
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			headset = VRTK_DeviceFinder.HeadsetCamera();
			if (headset != null)
			{
				headsetCamera = headset.GetComponent<Camera>();
				cameraEffect = headset.GetComponent<VRTK_TunnelEffect>();
			}
			playarea = VRTK_DeviceFinder.PlayAreaTransform();
			originalAngularVelocity = matCameraEffect.GetFloat(shaderPropertyAV);
			originalFeatherSize = matCameraEffect.GetFloat(shaderPropertyFeather);
			originalColor = matCameraEffect.GetColor(shaderPropertyColor);
			CheckSkyboxTexture();
			if (effectSkybox != null)
			{
				originalSkyboxTexture = matCameraEffect.GetTexture(shaderPropertySkyboxTexture);
				matCameraEffect.SetTexture("_SecondarySkyBox", effectSkybox);
			}
			if (cameraEffect == null && headset != null)
			{
				cameraEffect = headset.gameObject.AddComponent<VRTK_TunnelEffect>();
				cameraEffect.SetMaterial(matCameraEffect);
			}
		}

		protected virtual void OnDisable()
		{
			headset = null;
			headsetCamera = null;
			playarea = null;
			if (cameraEffect != null)
			{
				matCameraEffect.SetTexture("_SecondarySkyBox", originalSkyboxTexture);
				originalSkyboxTexture = null;
				SetShaderFeather(originalColor, originalAngularVelocity, originalFeatherSize);
				matCameraEffect.SetColor(shaderPropertyColor, originalColor);
				Object.Destroy(cameraEffect);
			}
			if (createEffectSkybox)
			{
				effectSkybox = null;
				createEffectSkybox = false;
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void FixedUpdate()
		{
			Vector3 forward = playarea.forward;
			Vector3 position = playarea.position;
			float num = Vector3.Angle(lastForward, forward) / Time.fixedDeltaTime;
			num = (num - minimumRotation) / (maximumRotation - minimumRotation);
			if (maximumSpeed > 0f)
			{
				float num2 = (position - lastPosition).magnitude / Time.fixedDeltaTime;
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
			lastPosition = position;
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
		}

		protected virtual void SetShaderFeather(Color givenTunnelColor, float givenAngularVelocity, float givenFeatherSize)
		{
			matCameraEffect.SetColor(shaderPropertyColor, givenTunnelColor);
			matCameraEffect.SetFloat(shaderPropertyAV, givenAngularVelocity);
			matCameraEffect.SetFloat(shaderPropertyFeather, givenFeatherSize);
		}

		protected virtual void CheckSkyboxTexture()
		{
			if (effectSkybox == null)
			{
				Cubemap cubemap = new Cubemap(1, TextureFormat.ARGB32, mipChain: false);
				cubemap.SetPixel(CubemapFace.NegativeX, 0, 0, Color.white);
				cubemap.SetPixel(CubemapFace.NegativeY, 0, 0, Color.white);
				cubemap.SetPixel(CubemapFace.NegativeZ, 0, 0, Color.white);
				cubemap.SetPixel(CubemapFace.PositiveX, 0, 0, Color.white);
				cubemap.SetPixel(CubemapFace.PositiveY, 0, 0, Color.white);
				cubemap.SetPixel(CubemapFace.PositiveZ, 0, 0, Color.white);
				effectSkybox = cubemap;
				createEffectSkybox = true;
			}
			else if (effectColor.r < 0.15f && (double)effectColor.g < 0.15 && (double)effectColor.b < 0.15)
			{
				VRTK_Logger.Warn("`VRTK_TunnelOverlay` has an `Effect Skybox` texture but the `Effect Color` is too dark which will tint the texture so it is not visible.");
			}
		}
	}
}
