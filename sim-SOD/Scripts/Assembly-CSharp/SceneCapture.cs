using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SceneCapture : MonoBehaviour
{
	[Serializable]
	public class PhotoCache
	{
		public Texture2D img;

		public float lastUsed;

		public List<ActorScreenPosition> actorSP;

		public void Remove()
		{
		}
	}

	[Serializable]
	public class PhotoSaveToDisk
	{
		public byte[] data;

		public Texture2D img;

		public float lastUsed;

		public List<ActorScreenPosition> actorSP;

		public bool readOnly;

		public Texture2D GetImage()
		{
			return null;
		}
	}

	[Serializable]
	public class PhotoCacheLinking
	{
		public List<string> usedInSaveFiles;
	}

	public struct ActorScreenPosition
	{
		public Human human;

		public Vector2 screenPoint;
	}

	public enum PostProcessingProfile
	{
		captureNormal = 0,
		captureCCTV = 1
	}

	[Header("Capture")]
	public RenderTexture evidenceRenderTexturePrefab;

	public RenderTexture surveillanceRenderTexturePrefab;

	public float evidenceFoV;

	public float surveillanceFov;

	[NonSerialized]
	public SceneRecorder.SceneCapture currrentlyViewing;

	[Header("Cache")]
	[Tooltip("The max number of cached evidence photos")]
	public int maxEvidenceCache;

	[ReadOnly]
	public int cachedEvidencePhotos;

	public Dictionary<Evidence, PhotoCache> cachedRenders;

	public Color lastCentrePixel;

	[Space(7f)]
	public int maxSurveillanceCache;

	[ReadOnly]
	public int cachedSurveillancePhotos;

	public Dictionary<SceneRecorder.SceneCapture, PhotoCache> cachedSurveillance;

	[Header("Photo Room")]
	public GameObject photoRoomParent;

	public Transform cameraTransform;

	public Transform itemTransform;

	private static SceneCapture _instance;

	public static SceneCapture Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public Texture2D CapturePhotoOfEvidence(Evidence ev, bool forceNew = false)
	{
		return null;
	}

	public Texture2D GetSurveillanceScene(SceneRecorder.SceneCapture scene, bool saveToCache = true)
	{
		return null;
	}

	public Texture2D CaptureScene(Vector3 pos, Vector3 euler, int layerMask, bool changeTimeOfDay, float decimalClock, RenderTexture renderPrefab, float fov = 70f, List<Interactable> forceHide = null, NewNode passNode = null, bool useCaptureLight = true, bool basicMode = false, bool ignoreEarlyCapError = false, PostProcessingProfile captureProfile = PostProcessingProfile.captureNormal, bool useFlashlight = false, bool useFlash = false, bool readOnly = true, bool sampleCentrePixel = false, SceneRecorder.SceneCapture sceneRef = null, bool saveToDisk = true)
	{
		return null;
	}

	public Texture2D CaptureScene(Vector3 pos, Vector3 euler, int layerMask, bool changeTimeOfDay, float decimalClock, RenderTexture renderPrefab, ref List<SceneRecorder.ActorCapture> humanRef, out List<ActorScreenPosition> actorScreenPointCapture, float fov = 70f, List<Interactable> forceHide = null, NewNode passNode = null, bool useCaptureLight = true, bool basicMode = false, bool ignoreEarlyCapError = false, PostProcessingProfile captureProfile = PostProcessingProfile.captureNormal, bool useFlashlight = false, bool useFlash = false, bool readOnly = true, AirDuctGroup inAirDuctGroup = null, bool sampleCentrePixel = false, SceneRecorder.SceneCapture sceneRef = null, bool saveToDisk = true)
	{
		actorScreenPointCapture = null;
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ClearRenderCache()
	{
	}
}
