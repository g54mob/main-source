using System;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class OVRCameraComposition : OVRComposition
{
	public class OVRCameraFrameCompositionManager : MonoBehaviour
	{
		public OVRMixedRealityCaptureConfiguration configuration;

		public GameObject cameraFrameGameObj;

		public OVRCameraComposition composition;

		public RenderTexture boundaryMeshMaskTexture;

		private Material cameraFrameMaterial;

		private Material whiteMaterial;

		private Camera mixedRealityCamera;

		private void Start()
		{
			Shader shader = Shader.Find("Oculus/Unlit");
			if (!shader)
			{
				Debug.LogError("Oculus/Unlit shader does not exist");
				return;
			}
			whiteMaterial = new Material(shader);
			whiteMaterial.color = Color.white;
			if (GraphicsSettings.renderPipelineAsset != null)
			{
				RenderPipelineManager.beginCameraRendering += OnCameraBeginRendering;
				RenderPipelineManager.endCameraRendering += OnCameraEndRendering;
				mixedRealityCamera = GetComponent<Camera>();
			}
		}

		private void OnPreRender()
		{
			if (configuration != null && configuration.virtualGreenScreenType != OVRManager.VirtualGreenScreenType.Off && boundaryMeshMaskTexture != null && composition.boundaryMesh != null)
			{
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = boundaryMeshMaskTexture;
				GL.PushMatrix();
				GL.LoadProjectionMatrix(GetComponent<Camera>().projectionMatrix);
				GL.Clear(clearDepth: false, clearColor: true, Color.black);
				for (int i = 0; i < whiteMaterial.passCount; i++)
				{
					if (whiteMaterial.SetPass(i))
					{
						Graphics.DrawMeshNow(composition.boundaryMesh, composition.cameraRig.ComputeTrackReferenceMatrix());
					}
				}
				GL.PopMatrix();
				RenderTexture.active = active;
			}
			if ((bool)cameraFrameGameObj)
			{
				if (cameraFrameMaterial == null)
				{
					cameraFrameMaterial = cameraFrameGameObj.GetComponent<MeshRenderer>().material;
				}
				cameraFrameMaterial.SetFloat("_Visible", 1f);
			}
		}

		private void OnPostRender()
		{
			if ((bool)cameraFrameGameObj)
			{
				cameraFrameMaterial.SetFloat("_Visible", 0f);
			}
		}

		private void OnCameraBeginRendering(ScriptableRenderContext renderContext, Camera camera)
		{
			if (mixedRealityCamera != null && mixedRealityCamera == camera)
			{
				OnPreRender();
			}
		}

		private void OnCameraEndRendering(ScriptableRenderContext renderContext, Camera camera)
		{
			if (mixedRealityCamera != null && mixedRealityCamera == camera)
			{
				OnPostRender();
			}
		}
	}

	protected GameObject cameraFramePlaneObject;

	protected float cameraFramePlaneDistance;

	protected readonly bool hasCameraDeviceOpened;

	internal readonly OVRPlugin.CameraDevice cameraDevice = OVRPlugin.CameraDevice.WebCamera0;

	private Mesh boundaryMesh;

	private float boundaryMeshTopY;

	private float boundaryMeshBottomY;

	private OVRManager.VirtualGreenScreenType boundaryMeshType;

	private OVRCameraFrameCompositionManager cameraFrameCompositionManager;

	private bool nullcameraRigWarningDisplayed;

	protected OVRCameraComposition(GameObject parentObject, Camera mainCamera, OVRMixedRealityCaptureConfiguration configuration)
		: base(parentObject, mainCamera, configuration)
	{
		cameraDevice = OVRCompositionUtil.ConvertCameraDevice(configuration.capturingCameraDevice);
		hasCameraDeviceOpened = false;
		bool flag = OVRPlugin.DoesCameraDeviceSupportDepth(cameraDevice);
		if (configuration.useDynamicLighting && !flag)
		{
			Debug.LogWarning("The camera device doesn't support depth. The result of dynamic lighting might not be correct");
		}
		if (!OVRPlugin.IsCameraDeviceAvailable(cameraDevice))
		{
			return;
		}
		if (OVRPlugin.GetExternalCameraCount() > 0 && OVRPlugin.GetMixedRealityCameraInfo(0, out var _, out var cameraIntrinsics))
		{
			OVRPlugin.SetCameraDevicePreferredColorFrameSize(cameraDevice, cameraIntrinsics.ImageSensorPixelResolution.w, cameraIntrinsics.ImageSensorPixelResolution.h);
		}
		if (configuration.useDynamicLighting)
		{
			OVRPlugin.SetCameraDeviceDepthSensingMode(cameraDevice, OVRPlugin.CameraDeviceDepthSensingMode.Fill);
			OVRPlugin.CameraDeviceDepthQuality depthQuality = OVRPlugin.CameraDeviceDepthQuality.Medium;
			if (configuration.depthQuality == OVRManager.DepthQuality.Low)
			{
				depthQuality = OVRPlugin.CameraDeviceDepthQuality.Low;
			}
			else if (configuration.depthQuality == OVRManager.DepthQuality.Medium)
			{
				depthQuality = OVRPlugin.CameraDeviceDepthQuality.Medium;
			}
			else if (configuration.depthQuality == OVRManager.DepthQuality.High)
			{
				depthQuality = OVRPlugin.CameraDeviceDepthQuality.High;
			}
			else
			{
				Debug.LogWarning("Unknown depth quality");
			}
			OVRPlugin.SetCameraDevicePreferredDepthQuality(cameraDevice, depthQuality);
		}
		Debug.LogFormat("Opening camera device {0}", cameraDevice);
		OVRPlugin.OpenCameraDevice(cameraDevice);
		if (OVRPlugin.HasCameraDeviceOpened(cameraDevice))
		{
			Debug.LogFormat("Opened camera device {0}", cameraDevice);
			hasCameraDeviceOpened = true;
		}
	}

	public override void Cleanup()
	{
		OVRCompositionUtil.SafeDestroy(ref cameraFramePlaneObject);
		if (hasCameraDeviceOpened)
		{
			Debug.LogFormat("Close camera device {0}", cameraDevice);
			OVRPlugin.CloseCameraDevice(cameraDevice);
		}
	}

	public override void RecenterPose()
	{
		boundaryMesh = null;
	}

	protected void RefreshCameraFramePlaneObject(GameObject parentObject, Camera mixedRealityCamera, OVRMixedRealityCaptureConfiguration configuration)
	{
		OVRCompositionUtil.SafeDestroy(ref cameraFramePlaneObject);
		cameraFramePlaneObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		cameraFramePlaneObject.name = "OculusMRC_CameraFrame";
		cameraFramePlaneObject.transform.parent = (cameraInTrackingSpace ? cameraRig.trackingSpace : parentObject.transform);
		cameraFramePlaneObject.GetComponent<Collider>().enabled = false;
		cameraFramePlaneObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
		Material material = new Material(Shader.Find(configuration.useDynamicLighting ? "Oculus/OVRMRCameraFrameLit" : "Oculus/OVRMRCameraFrame"));
		cameraFramePlaneObject.GetComponent<MeshRenderer>().material = material;
		material.SetColor("_Color", Color.white);
		material.SetFloat("_Visible", 0f);
		cameraFramePlaneObject.transform.localScale = new Vector3(4f, 4f, 4f);
		cameraFramePlaneObject.SetActive(value: true);
		cameraFrameCompositionManager = mixedRealityCamera.gameObject.AddComponent<OVRCameraFrameCompositionManager>();
		cameraFrameCompositionManager.configuration = configuration;
		cameraFrameCompositionManager.cameraFrameGameObj = cameraFramePlaneObject;
		cameraFrameCompositionManager.composition = this;
	}

	protected void UpdateCameraFramePlaneObject(Camera mainCamera, Camera mixedRealityCamera, OVRMixedRealityCaptureConfiguration configuration, RenderTexture boundaryMeshMaskTexture)
	{
		cameraFrameCompositionManager.configuration = configuration;
		bool flag = false;
		Material material = cameraFramePlaneObject.GetComponent<MeshRenderer>().material;
		Texture2D texture2D = Texture2D.blackTexture;
		Texture2D value = Texture2D.whiteTexture;
		if (OVRPlugin.IsCameraDeviceColorFrameAvailable(cameraDevice))
		{
			texture2D = OVRPlugin.GetCameraDeviceColorFrameTexture(cameraDevice);
		}
		else
		{
			Debug.LogWarning("Camera: color frame not ready");
			flag = true;
		}
		bool flag2 = OVRPlugin.DoesCameraDeviceSupportDepth(cameraDevice);
		if (configuration.useDynamicLighting && flag2)
		{
			if (OVRPlugin.IsCameraDeviceDepthFrameAvailable(cameraDevice))
			{
				value = OVRPlugin.GetCameraDeviceDepthFrameTexture(cameraDevice);
			}
			else
			{
				Debug.LogWarning("Camera: depth frame not ready");
				flag = true;
			}
		}
		if (flag)
		{
			return;
		}
		Vector3 rhs = mainCamera.transform.position - mixedRealityCamera.transform.position;
		float num = (cameraFramePlaneDistance = Vector3.Dot(mixedRealityCamera.transform.forward, rhs));
		cameraFramePlaneObject.transform.position = mixedRealityCamera.transform.position + mixedRealityCamera.transform.forward * num;
		cameraFramePlaneObject.transform.rotation = mixedRealityCamera.transform.rotation;
		float num2 = Mathf.Tan(mixedRealityCamera.fieldOfView * ((float)Math.PI / 180f) * 0.5f);
		cameraFramePlaneObject.transform.localScale = new Vector3(num * mixedRealityCamera.aspect * num2 * 2f, num * num2 * 2f, 1f);
		float num3 = num * num2 * 2f;
		float x = num3 * mixedRealityCamera.aspect;
		float cullingDistance = float.MaxValue;
		if (OVRManager.instance.virtualGreenScreenType != OVRManager.VirtualGreenScreenType.Off)
		{
			RefreshBoundaryMesh(mixedRealityCamera, configuration, out cullingDistance);
		}
		material.mainTexture = texture2D;
		material.SetTexture("_DepthTex", value);
		material.SetVector("_FlipParams", new Vector4(configuration.flipCameraFrameHorizontally ? 1f : 0f, configuration.flipCameraFrameVertically ? 1f : 0f, 0f, 0f));
		material.SetColor("_ChromaKeyColor", configuration.chromaKeyColor);
		material.SetFloat("_ChromaKeySimilarity", configuration.chromaKeySimilarity);
		material.SetFloat("_ChromaKeySmoothRange", configuration.chromaKeySmoothRange);
		material.SetFloat("_ChromaKeySpillRange", configuration.chromaKeySpillRange);
		material.SetVector("_TextureDimension", new Vector4(texture2D.width, texture2D.height, 1f / (float)texture2D.width, 1f / (float)texture2D.height));
		material.SetVector("_TextureWorldSize", new Vector4(x, num3, 0f, 0f));
		material.SetFloat("_SmoothFactor", configuration.dynamicLightingSmoothFactor);
		material.SetFloat("_DepthVariationClamp", configuration.dynamicLightingDepthVariationClampingValue);
		material.SetFloat("_CullingDistance", cullingDistance);
		if (configuration.virtualGreenScreenType == OVRManager.VirtualGreenScreenType.Off || boundaryMesh == null || boundaryMeshMaskTexture == null)
		{
			material.SetTexture("_MaskTex", Texture2D.whiteTexture);
		}
		else if (cameraRig == null)
		{
			if (!nullcameraRigWarningDisplayed)
			{
				Debug.LogWarning("Could not find the OVRCameraRig/CenterEyeAnchor object. Please check if the OVRCameraRig has been setup properly. The virtual green screen has been temporarily disabled");
				nullcameraRigWarningDisplayed = true;
			}
			material.SetTexture("_MaskTex", Texture2D.whiteTexture);
		}
		else
		{
			if (nullcameraRigWarningDisplayed)
			{
				Debug.Log("OVRCameraRig/CenterEyeAnchor object found. Virtual green screen is activated");
				nullcameraRigWarningDisplayed = false;
			}
			material.SetTexture("_MaskTex", boundaryMeshMaskTexture);
		}
	}

	protected void RefreshBoundaryMesh(Camera camera, OVRMixedRealityCaptureConfiguration configuration, out float cullingDistance)
	{
		float num = (configuration.virtualGreenScreenApplyDepthCulling ? configuration.virtualGreenScreenDepthTolerance : float.PositiveInfinity);
		cullingDistance = OVRCompositionUtil.GetMaximumBoundaryDistance(camera, OVRCompositionUtil.ToBoundaryType(configuration.virtualGreenScreenType)) + num;
		if (boundaryMesh == null || boundaryMeshType != configuration.virtualGreenScreenType || boundaryMeshTopY != configuration.virtualGreenScreenTopY || boundaryMeshBottomY != configuration.virtualGreenScreenBottomY)
		{
			boundaryMeshTopY = configuration.virtualGreenScreenTopY;
			boundaryMeshBottomY = configuration.virtualGreenScreenBottomY;
			boundaryMesh = OVRCompositionUtil.BuildBoundaryMesh(OVRCompositionUtil.ToBoundaryType(configuration.virtualGreenScreenType), boundaryMeshTopY, boundaryMeshBottomY);
			boundaryMeshType = configuration.virtualGreenScreenType;
		}
	}
}
