using System;
using System.Collections;
using UnityEngine;

[HelpURL("https://nvjob.github.io/unity/nvjob-water-shaders-v2")]
[AddComponentMenu("#NVJOB/Water Shaders V2")]
[ExecuteInEditMode]
public class NVWaterShaders : MonoBehaviour
{
	public Vector2 rotateSpeed = new Vector2(0.4f, 0.4f);

	public Vector2 rotateDistance = new Vector2(2f, 2f);

	public bool depthTextureModeOn = true;

	public bool waterSyncWind;

	public Transform windZone;

	public bool mirrorOn;

	public bool mirrorBackSide;

	public int textureSize = 1024;

	public Vector3 clipPlaneOffset = new Vector3(0.1f, 0.1f, 10f);

	public LayerMask reflectLayers = -1;

	public bool garbageCollection;

	private Transform thisTransform;

	private Vector2 wVectorX;

	private Vector2 wVectorY;

	private Vector3 ccLastpos;

	private Renderer thisRenderer;

	private Camera currentCamera;

	private Camera reflectionCamera;

	private Hashtable reflectionCameras = new Hashtable();

	private RenderTexture reflectionTexture;

	private int oldReflectionTextureSize;

	private static bool insideRendering;

	private void OnEnable()
	{
		thisTransform = base.transform;
		thisRenderer = GetComponent<Renderer>();
		wVectorX = Vector2.zero;
		wVectorY = Vector2.zero;
		if (depthTextureModeOn)
		{
			Camera.main.depthTextureMode = DepthTextureMode.Depth;
		}
	}

	private void OnWillRenderObject()
	{
		if (mirrorOn)
		{
			MirrorReflection();
		}
	}

	private void OnDisable()
	{
		if (mirrorOn)
		{
			if ((bool)reflectionTexture)
			{
				UnityEngine.Object.DestroyImmediate(reflectionTexture);
				reflectionTexture = null;
			}
			foreach (DictionaryEntry reflectionCamera in reflectionCameras)
			{
				UnityEngine.Object.DestroyImmediate(((Camera)reflectionCamera.Value).gameObject);
			}
			reflectionCameras.Clear();
		}
		if (garbageCollection)
		{
			GC.Collect();
			Resources.UnloadUnusedAssets();
		}
	}

	private void LateUpdate()
	{
		if (!waterSyncWind)
		{
			wVectorX = Quaternion.AngleAxis(Time.time * rotateSpeed.x, Vector3.forward) * Vector2.one * rotateDistance.x;
			wVectorY = Quaternion.AngleAxis(Time.time * rotateSpeed.y, Vector3.forward) * Vector2.one * rotateDistance.y;
			if (windZone != null)
			{
				windZone.rotation = Quaternion.LookRotation(new Vector3(wVectorY.x, 0f, wVectorY.y), Vector3.zero) * Quaternion.Euler(0f, -90f, 0f);
			}
		}
		else if (windZone != null)
		{
			Vector3 vector = new Quaternion(windZone.rotation.x, windZone.rotation.z, windZone.rotation.y, 0f - windZone.rotation.w) * Vector3.up * 0.2f;
			wVectorX = vector * Time.time * rotateSpeed.x;
			wVectorY = vector * Time.time * rotateSpeed.y;
		}
		Shader.SetGlobalVector("_NvWatersMovement", new Vector4(wVectorX.x, wVectorX.y, wVectorY.x, wVectorY.y));
	}

	private void MirrorReflection()
	{
		if (!base.enabled || !thisRenderer.enabled || !thisRenderer || !thisRenderer.sharedMaterial)
		{
			return;
		}
		currentCamera = Camera.current;
		if (!currentCamera || insideRendering)
		{
			return;
		}
		insideRendering = true;
		Transform transform = currentCamera.transform;
		ccLastpos = transform.position;
		CreateMirrorObjects(currentCamera, out reflectionCamera);
		Vector3 position = thisTransform.position;
		Vector3 vector = thisTransform.up;
		if (mirrorBackSide)
		{
			vector = -vector;
		}
		UpdateCamera(currentCamera, reflectionCamera);
		float w = 0f - Vector3.Dot(vector, position) - clipPlaneOffset.x;
		Matrix4x4 reflectionMat = Matrix4x4.zero;
		CalculateReflectionMatrix(ref reflectionMat, new Vector4(vector.x, vector.y, vector.z, w));
		Vector3 position2 = reflectionMat.MultiplyPoint(ccLastpos);
		reflectionCamera.worldToCameraMatrix = currentCamera.worldToCameraMatrix * reflectionMat;
		Matrix4x4 projection = currentCamera.projectionMatrix;
		CalculateObliqueMatrix(ref projection, ClipPlane(reflectionCamera, position, vector, 1f, clipPlaneOffset.x));
		reflectionCamera.projectionMatrix = projection;
		reflectionCamera.cullingMask = -17 & reflectLayers.value;
		reflectionCamera.targetTexture = reflectionTexture;
		GL.invertCulling = true;
		reflectionCamera.transform.position = position2;
		Vector3 eulerAngles = transform.eulerAngles;
		reflectionCamera.transform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
		reflectionCamera.Render();
		reflectionCamera.transform.position = ccLastpos;
		GL.invertCulling = false;
		Material[] sharedMaterials = thisRenderer.sharedMaterials;
		foreach (Material material in sharedMaterials)
		{
			if (material.HasProperty("_MirrorReflectionTex"))
			{
				material.SetTexture("_MirrorReflectionTex", reflectionTexture);
			}
		}
		insideRendering = false;
	}

	private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
	{
		reflectionCamera = null;
		if (!reflectionTexture || oldReflectionTextureSize != textureSize)
		{
			if ((bool)reflectionTexture)
			{
				UnityEngine.Object.DestroyImmediate(reflectionTexture);
			}
			reflectionTexture = new RenderTexture(textureSize, textureSize, 16)
			{
				name = "__MirrorReflection" + GetInstanceID(),
				isPowerOfTwo = true,
				hideFlags = HideFlags.DontSave
			};
			oldReflectionTextureSize = textureSize;
		}
		reflectionCamera = reflectionCameras[currentCamera] as Camera;
		GameObject gameObject = new GameObject("Mirror Refl Camera id" + GetInstanceID() + " for " + currentCamera.GetInstanceID(), typeof(Camera), typeof(Skybox));
		reflectionCamera = gameObject.GetComponent<Camera>();
		reflectionCamera.enabled = false;
		reflectionCamera.transform.SetPositionAndRotation(thisTransform.position, thisTransform.rotation);
		reflectionCamera.gameObject.AddComponent<FlareLayer>();
		gameObject.hideFlags = HideFlags.HideAndDontSave;
		reflectionCameras[currentCamera] = reflectionCamera;
	}

	private void UpdateCamera(Camera src, Camera dest)
	{
		if (dest == null)
		{
			return;
		}
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		if (src.clearFlags == CameraClearFlags.Skybox)
		{
			Skybox skybox = src.GetComponent(typeof(Skybox)) as Skybox;
			Skybox skybox2 = dest.GetComponent(typeof(Skybox)) as Skybox;
			if (!skybox || !skybox.material)
			{
				skybox2.enabled = false;
			}
			else
			{
				skybox2.enabled = true;
				skybox2.material = skybox.material;
			}
		}
		dest.farClipPlane = clipPlaneOffset.z;
		dest.nearClipPlane = clipPlaneOffset.y;
		dest.orthographic = src.orthographic;
		dest.fieldOfView = src.fieldOfView;
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
		dest.renderingPath = src.renderingPath;
	}

	private static Vector4 ClipPlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign, float clipPlaneOffset)
	{
		Vector3 point = pos + normal * clipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
	}

	private static void CalculateObliqueMatrix(ref Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 b = projection.inverse * new Vector4(Sgn(clipPlane.x), Sgn(clipPlane.y), 1f, 1f);
		Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
		projection[2] = vector.x - projection[3];
		projection[6] = vector.y - projection[7];
		projection[10] = vector.z - projection[11];
		projection[14] = vector.w - projection[15];
	}

	private static float Sgn(float a)
	{
		float result = 0f;
		if (a > 0f)
		{
			result = 1f;
		}
		if (a < 0f)
		{
			result = -1f;
		}
		return result;
	}

	private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		float num = 2f * plane[0];
		float num2 = 2f * plane[1];
		float num3 = 2f * plane[2];
		float num4 = 2f * plane[3];
		reflectionMat.m00 = 1f - num * plane[0];
		reflectionMat.m01 = (0f - num) * plane[1];
		reflectionMat.m02 = (0f - num) * plane[2];
		reflectionMat.m03 = (0f - num4) * plane[0];
		reflectionMat.m10 = (0f - num2) * plane[0];
		reflectionMat.m11 = 1f - num2 * plane[1];
		reflectionMat.m12 = (0f - num2) * plane[2];
		reflectionMat.m13 = (0f - num4) * plane[1];
		reflectionMat.m20 = (0f - num3) * plane[0];
		reflectionMat.m21 = (0f - num3) * plane[1];
		reflectionMat.m22 = 1f - num3 * plane[2];
		reflectionMat.m23 = (0f - num4) * plane[2];
		reflectionMat.m30 = (reflectionMat.m31 = (reflectionMat.m32 = 0f));
		reflectionMat.m33 = 1f;
	}
}
