using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
[AddComponentMenu("Tasharen/Water")]
public class TasharenWater : MonoBehaviour
{
	public enum Quality
	{
		Fastest = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		Uber = 4
	}

	public static TasharenWater instance;

	public Quality quality = Quality.High;

	public LayerMask highReflectionMask = -1;

	public LayerMask mediumReflectionMask = -1;

	public bool keepUnderCamera = true;

	public bool automaticQuality;

	private Transform mTrans;

	private Hashtable mCameras = new Hashtable();

	private RenderTexture mTex;

	private RenderTexture mTexStereo;

	private int mTexSize;

	private Renderer mRen;

	private bool mIntelGPU;

	private Color mSpecular;

	private bool mStreamingWater;

	private Vector4 mReflectionPlane;

	private List<XRNodeState> mXRNodeStates = new List<XRNodeState>();

	private static bool mIsRendering = false;

	private static Vector3 mTemp = Vector4.one;

	public int reflectionTextureSize => quality switch
	{
		Quality.Uber => 1024, 
		Quality.High => 1024, 
		Quality.Medium => 512, 
		_ => 0, 
	};

	public LayerMask reflectionMask
	{
		get
		{
			switch (quality)
			{
			case Quality.High:
			case Quality.Uber:
				return highReflectionMask;
			case Quality.Medium:
				return mediumReflectionMask;
			default:
				return 0;
			}
		}
	}

	public bool useRefraction => quality > Quality.Fastest;

	private static float SignExt(float a)
	{
		if (a > 0f)
		{
			return 1f;
		}
		if (a < 0f)
		{
			return -1f;
		}
		return 0f;
	}

	private static void CalculateObliqueMatrix(ref Matrix4x4 projection, Vector4 clipPlane)
	{
		mTemp.x = SignExt(clipPlane.x);
		mTemp.y = SignExt(clipPlane.y);
		Vector4 b = projection.inverse * mTemp;
		Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
		projection[2] = vector.x - projection[3];
		projection[6] = vector.y - projection[7];
		projection[10] = vector.z - projection[11];
		projection[14] = vector.w - projection[15];
	}

	private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
		reflectionMat.m01 = -2f * plane[0] * plane[1];
		reflectionMat.m02 = -2f * plane[0] * plane[2];
		reflectionMat.m03 = -2f * plane[3] * plane[0];
		reflectionMat.m10 = -2f * plane[1] * plane[0];
		reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
		reflectionMat.m12 = -2f * plane[1] * plane[2];
		reflectionMat.m13 = -2f * plane[3] * plane[1];
		reflectionMat.m20 = -2f * plane[2] * plane[0];
		reflectionMat.m21 = -2f * plane[2] * plane[1];
		reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
		reflectionMat.m23 = -2f * plane[3] * plane[2];
		reflectionMat.m30 = 0f;
		reflectionMat.m31 = 0f;
		reflectionMat.m32 = 0f;
		reflectionMat.m33 = 1f;
	}

	public static Quality GetQuality()
	{
		return (Quality)PlayerPrefs.GetInt("Water", 3);
	}

	public static void SetQuality(Quality q)
	{
		TasharenWater[] array = Object.FindObjectsByType(typeof(TasharenWater), FindObjectsSortMode.None) as TasharenWater[];
		if (array.Length != 0)
		{
			TasharenWater[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].quality = Quality.High;
			}
		}
	}

	private void Awake()
	{
		mTrans = base.transform;
		mRen = GetComponent<Renderer>();
		mSpecular = new Color32(147, 147, 147, byte.MaxValue);
		if (Application.platform == RuntimePlatform.LinuxPlayer && (SystemInfo.graphicsShaderLevel < 20 || SystemInfo.graphicsDeviceVendor.Contains("Intel") || SystemInfo.graphicsDeviceVendor.Contains("INTEL")))
		{
			mIntelGPU = true;
		}
	}

	private void OnEnable()
	{
		instance = this;
	}

	private void OnDisable()
	{
		Clear();
		foreach (DictionaryEntry mCamera in mCameras)
		{
			Object.DestroyImmediate(((Camera)mCamera.Value).gameObject);
		}
		mCameras.Clear();
		if (instance == this)
		{
			instance = null;
		}
	}

	private void Clear()
	{
		if ((bool)mTex)
		{
			Object.DestroyImmediate(mTex);
			mTex = null;
		}
		if ((bool)mTexStereo)
		{
			Object.DestroyImmediate(mTexStereo);
			mTexStereo = null;
		}
	}

	private void CopyCamera(Camera src, Camera dest)
	{
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		dest.farClipPlane = src.farClipPlane;
		dest.nearClipPlane = src.nearClipPlane;
		dest.orthographic = src.orthographic;
		if (!src.stereoEnabled)
		{
			dest.fieldOfView = src.fieldOfView;
		}
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
		dest.depthTextureMode = DepthTextureMode.None;
		dest.renderingPath = RenderingPath.Forward;
	}

	private Camera GetReflectionCamera(Camera current, Material mat, int textureSize)
	{
		if (!mTex || mTexSize != textureSize)
		{
			if ((bool)mTex)
			{
				Object.DestroyImmediate(mTex);
			}
			mTex = new RenderTexture(textureSize, textureSize, 16);
			mTex.name = "__MirrorReflection" + GetInstanceID();
			mTex.isPowerOfTwo = true;
			mTex.hideFlags = HideFlags.DontSave;
			mTex.dimension = TextureDimension.Tex2DArray;
			mTex.volumeDepth = 1;
			mTexSize = textureSize;
		}
		bool stereoEnabled = current.stereoEnabled;
		if (stereoEnabled && (!mTexStereo || mTexStereo.width != textureSize))
		{
			if ((bool)mTexStereo)
			{
				Object.DestroyImmediate(mTexStereo);
			}
			mTexStereo = new RenderTexture(textureSize, textureSize, 16);
			mTexStereo.name = "__MirrorReflectionStereo" + GetInstanceID();
			mTexStereo.isPowerOfTwo = true;
			mTexStereo.hideFlags = HideFlags.DontSave;
			mTexStereo.dimension = TextureDimension.Tex2DArray;
			mTexStereo.volumeDepth = 2;
		}
		Camera camera = mCameras[current] as Camera;
		if (!camera)
		{
			camera = new GameObject("Mirror Refl Camera id" + GetInstanceID() + " for " + current.GetInstanceID(), typeof(Camera), typeof(Skybox))
			{
				hideFlags = HideFlags.HideAndDontSave
			}.GetComponent<Camera>();
			camera.enabled = false;
			Transform obj = camera.transform;
			obj.position = mTrans.position;
			obj.rotation = mTrans.rotation;
			camera.gameObject.AddComponent<FlareLayer>();
			mCameras[current] = camera;
		}
		if (mat.HasProperty("_ReflectionTex"))
		{
			mat.SetTexture("_ReflectionTex", stereoEnabled ? mTexStereo : mTex);
		}
		return camera;
	}

	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(pos);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
	}

	private void LateUpdate()
	{
		if (!keepUnderCamera)
		{
			return;
		}
		Camera main = Camera.main;
		if (!(main == null))
		{
			Vector3 position = main.transform.position;
			position.y = mTrans.position.y;
			if (mTrans.position != position)
			{
				mTrans.position = position;
			}
		}
	}

	private void OnWillRenderObject()
	{
		if (mIsRendering)
		{
			return;
		}
		if (!base.enabled || !mRen || !mRen.enabled)
		{
			Clear();
			return;
		}
		Material sharedMaterial = mRen.sharedMaterial;
		if (!sharedMaterial)
		{
			return;
		}
		if (mIntelGPU)
		{
			quality = Quality.Fastest;
			sharedMaterial.shader.maximumLOD = 100;
			return;
		}
		Camera current = Camera.current;
		if (!current)
		{
			return;
		}
		if (mStreamingWater)
		{
			sharedMaterial.SetColor("_Specular", Color.black);
		}
		else
		{
			sharedMaterial.SetColor("_Specular", mSpecular);
		}
		bool flag = true;
		current.depthTextureMode |= DepthTextureMode.Depth;
		if (!useRefraction || Camera.current.gameObject.name.StartsWith("Reflection"))
		{
			sharedMaterial.shader.maximumLOD = (flag ? 200 : 100);
			Clear();
			return;
		}
		LayerMask layerMask = reflectionMask;
		int num = reflectionTextureSize;
		if ((int)layerMask == 0 || num < 512)
		{
			sharedMaterial.shader.maximumLOD = 300;
			Clear();
			return;
		}
		sharedMaterial.shader.maximumLOD = 400;
		mIsRendering = true;
		Camera reflectionCamera = GetReflectionCamera(current, sharedMaterial, num);
		Vector3 position = mTrans.position;
		Vector3 up = mTrans.up;
		CopyCamera(current, reflectionCamera);
		float w = 0f - Vector3.Dot(up, position);
		mReflectionPlane.x = up.x;
		mReflectionPlane.y = up.y;
		mReflectionPlane.z = up.z;
		mReflectionPlane.w = w;
		Matrix4x4 reflectionMat = Matrix4x4.zero;
		CalculateReflectionMatrix(ref reflectionMat, mReflectionPlane);
		if (current.stereoEnabled)
		{
			RenderEye(current, layerMask, reflectionCamera, position, up, reflectionMat, Camera.StereoscopicEye.Left);
			RenderEye(current, layerMask, reflectionCamera, position, up, reflectionMat, Camera.StereoscopicEye.Right);
		}
		else
		{
			RenderEye(current, layerMask, reflectionCamera, position, up, reflectionMat, null);
		}
		mIsRendering = false;
	}

	private void RenderEye(Camera cam, LayerMask mask, Camera reflectionCamera, Vector3 pos, Vector3 normal, Matrix4x4 reflection, Camera.StereoscopicEye? stereoEye)
	{
		Vector3 position = cam.transform.position;
		if (cam.stereoEnabled)
		{
			reflectionCamera.worldToCameraMatrix = cam.GetStereoViewMatrix(stereoEye.Value) * reflection;
			mXRNodeStates.Clear();
			InputTracking.GetNodeStates(mXRNodeStates);
			XRNode xRNode = ((cam.stereoActiveEye != Camera.MonoOrStereoscopicEye.Left) ? XRNode.RightEye : XRNode.LeftEye);
			for (int i = 0; i < mXRNodeStates.Count; i++)
			{
				if (mXRNodeStates[i].nodeType == xRNode)
				{
					if (mXRNodeStates[i].TryGetPosition(out var position2))
					{
						position2.z = 0f;
						position += cam.transform.TransformVector(position2);
					}
					break;
				}
			}
		}
		else
		{
			reflectionCamera.worldToCameraMatrix = cam.worldToCameraMatrix * reflection;
		}
		Vector3 position3 = reflection.MultiplyPoint(position);
		Vector4 clipPlane = CameraSpacePlane(reflectionCamera, pos, normal, 1f);
		Matrix4x4 projection = (cam.stereoEnabled ? cam.GetStereoProjectionMatrix(stereoEye.Value) : cam.projectionMatrix);
		CalculateObliqueMatrix(ref projection, clipPlane);
		reflectionCamera.projectionMatrix = projection;
		reflectionCamera.cullingMask = -17 & mask.value;
		reflectionCamera.targetTexture = mTex;
		bool num = Shader.IsKeywordEnabled("TOD_OUTPUT_HDR");
		if (num)
		{
			Shader.DisableKeyword("TOD_OUTPUT_HDR");
		}
		GL.invertCulling = true;
		reflectionCamera.transform.position = position3;
		reflectionCamera.transform.rotation = cam.transform.rotation;
		reflectionCamera.Render();
		reflectionCamera.transform.position = position;
		GL.invertCulling = false;
		if (num)
		{
			Shader.EnableKeyword("TOD_OUTPUT_HDR");
		}
		if (cam.stereoEnabled)
		{
			Graphics.Blit(mTex, mTexStereo, 0, (int)stereoEye.GetValueOrDefault());
		}
	}

	public void UpdateFloatingOriginOffset(Vector3 newOffset)
	{
		newOffset.x %= 500000f;
		newOffset.y %= 500000f;
		newOffset.z %= 500000f;
		mRen.material.SetVector("_FloatingOriginOffset", newOffset);
	}

	private void Start()
	{
	}

	[Conditional("A_Fake_Condition_That_Should_Never_Happen")]
	private void DummyMethodToReferenceSomeVariablesToAvoidWarningsInUnityOnMobilePlatforms()
	{
		UnityEngine.Debug.LogFormat("{0}, {1}, {2}", mIntelGPU, mSpecular, mStreamingWater);
	}
}
