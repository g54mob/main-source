using System;
using System.Collections.Generic;
using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarSDKManager : MonoBehaviour
{
	public struct AvatarSpecRequestParams
	{
		public ulong _userId;

		public specificationCallback _callback;

		public bool _useCombinedMesh;

		public ovrAvatarAssetLevelOfDetail _lod;

		public bool _forceMobileTextureFormat;

		public ovrAvatarLookAndFeelVersion _lookVersion;

		public ovrAvatarLookAndFeelVersion _fallbackVersion;

		public bool _enableExpressive;

		public AvatarSpecRequestParams(ulong userId, specificationCallback callback, bool useCombinedMesh, ovrAvatarAssetLevelOfDetail lod, bool forceMobileTextureFormat, ovrAvatarLookAndFeelVersion lookVersion, ovrAvatarLookAndFeelVersion fallbackVersion, bool enableExpressive)
		{
			_userId = userId;
			_callback = callback;
			_useCombinedMesh = useCombinedMesh;
			_lod = lod;
			_forceMobileTextureFormat = forceMobileTextureFormat;
			_lookVersion = lookVersion;
			_fallbackVersion = fallbackVersion;
			_enableExpressive = enableExpressive;
		}
	}

	private static OvrAvatarSDKManager _instance;

	private bool initialized;

	private Dictionary<ulong, HashSet<specificationCallback>> specificationCallbacks;

	private Dictionary<ulong, HashSet<assetLoadedCallback>> assetLoadedCallbacks;

	private Dictionary<IntPtr, combinedMeshLoadedCallback> combinedMeshLoadedCallbacks;

	private Dictionary<ulong, OvrAvatarAsset> assetCache;

	private OvrAvatarTextureCopyManager textureCopyManager;

	public ovrAvatarLogLevel LoggingLevel = ovrAvatarLogLevel.Info;

	private Queue<AvatarSpecRequestParams> avatarSpecificationQueue;

	private List<int> loadingAvatars;

	private bool avatarSpecRequestAvailable = true;

	private float lastDispatchedAvatarSpecRequestTime;

	private const float AVATAR_SPEC_REQUEST_TIMEOUT = 5f;

	public static OvrAvatarSDKManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType<OvrAvatarSDKManager>();
				if (_instance == null)
				{
					GameObject gameObject = new GameObject("OvrAvatarSDKManager");
					_instance = gameObject.AddComponent<OvrAvatarSDKManager>();
					_instance.textureCopyManager = gameObject.AddComponent<OvrAvatarTextureCopyManager>();
					_instance.initialized = _instance.Initialize();
				}
			}
			if (!_instance.initialized)
			{
				return null;
			}
			return _instance;
		}
	}

	private bool Initialize()
	{
		CAPI.Initialize();
		string text = GetAppId();
		if (text == "")
		{
			text = "0";
		}
		CAPI.ovrAvatar_Initialize(text);
		CAPI.SendEvent("initialize", text);
		specificationCallbacks = new Dictionary<ulong, HashSet<specificationCallback>>();
		assetLoadedCallbacks = new Dictionary<ulong, HashSet<assetLoadedCallback>>();
		combinedMeshLoadedCallbacks = new Dictionary<IntPtr, combinedMeshLoadedCallback>();
		assetCache = new Dictionary<ulong, OvrAvatarAsset>();
		avatarSpecificationQueue = new Queue<AvatarSpecRequestParams>();
		loadingAvatars = new List<int>();
		CAPI.ovrAvatar_SetLoggingLevel(LoggingLevel);
		CAPI.ovrAvatar_RegisterLoggingCallback(CAPI.LoggingCallback);
		return true;
	}

	private void OnDestroy()
	{
		CAPI.Shutdown();
		CAPI.ovrAvatar_RegisterLoggingCallback(null);
		CAPI.ovrAvatar_Shutdown();
	}

	private void Update()
	{
		if (Instance == null)
		{
			return;
		}
		if (avatarSpecificationQueue.Count > 0 && (avatarSpecRequestAvailable || Time.time - lastDispatchedAvatarSpecRequestTime >= 5f))
		{
			avatarSpecRequestAvailable = false;
			AvatarSpecRequestParams avatarSpecRequest = avatarSpecificationQueue.Dequeue();
			DispatchAvatarSpecificationRequest(avatarSpecRequest);
			lastDispatchedAvatarSpecRequestTime = Time.time;
		}
		IntPtr intPtr = CAPI.ovrAvatarMessage_Pop();
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		ovrAvatarMessageType ovrAvatarMessageType2 = CAPI.ovrAvatarMessage_GetType(intPtr);
		switch (ovrAvatarMessageType2)
		{
		case ovrAvatarMessageType.AssetLoaded:
		{
			ovrAvatarMessage_AssetLoaded ovrAvatarMessage_AssetLoaded2 = CAPI.ovrAvatarMessage_GetAssetLoaded(intPtr);
			IntPtr asset = ovrAvatarMessage_AssetLoaded2.asset;
			ulong assetID = ovrAvatarMessage_AssetLoaded2.assetID;
			ovrAvatarAssetType ovrAvatarAssetType2 = CAPI.ovrAvatarAsset_GetType(asset);
			OvrAvatarAsset ovrAvatarAsset = null;
			IntPtr key = IntPtr.Zero;
			switch (ovrAvatarAssetType2)
			{
			case ovrAvatarAssetType.Mesh:
				ovrAvatarAsset = new OvrAvatarAssetMesh(assetID, asset, ovrAvatarAssetType.Mesh);
				break;
			case ovrAvatarAssetType.Texture:
				ovrAvatarAsset = new OvrAvatarAssetTexture(assetID, asset);
				break;
			case ovrAvatarAssetType.Material:
				ovrAvatarAsset = new OvrAvatarAssetMaterial(assetID, asset);
				break;
			case ovrAvatarAssetType.CombinedMesh:
				key = CAPI.ovrAvatarAsset_GetAvatar(asset);
				ovrAvatarAsset = new OvrAvatarAssetMesh(assetID, asset, ovrAvatarAssetType.CombinedMesh);
				break;
			default:
				throw new NotImplementedException($"Unsupported asset type format {ovrAvatarAssetType2.ToString()}");
			case ovrAvatarAssetType.FailedLoad:
				break;
			}
			if (ovrAvatarAssetType2 == ovrAvatarAssetType.CombinedMesh)
			{
				if (!assetCache.ContainsKey(assetID))
				{
					assetCache.Add(assetID, ovrAvatarAsset);
				}
				if (combinedMeshLoadedCallbacks.TryGetValue(key, out var value2))
				{
					value2(asset);
					combinedMeshLoadedCallbacks.Remove(key);
				}
			}
			else
			{
				if (ovrAvatarAsset == null || !assetLoadedCallbacks.TryGetValue(ovrAvatarMessage_AssetLoaded2.assetID, out var value3))
				{
					break;
				}
				assetCache.Add(assetID, ovrAvatarAsset);
				foreach (assetLoadedCallback item in value3)
				{
					item(ovrAvatarAsset);
				}
				assetLoadedCallbacks.Remove(ovrAvatarMessage_AssetLoaded2.assetID);
			}
			break;
		}
		case ovrAvatarMessageType.AvatarSpecification:
		{
			avatarSpecRequestAvailable = true;
			ovrAvatarMessage_AvatarSpecification ovrAvatarMessage_AvatarSpecification2 = CAPI.ovrAvatarMessage_GetAvatarSpecification(intPtr);
			if (!specificationCallbacks.TryGetValue(ovrAvatarMessage_AvatarSpecification2.oculusUserID, out var value))
			{
				break;
			}
			foreach (specificationCallback item2 in value)
			{
				item2(ovrAvatarMessage_AvatarSpecification2.avatarSpec);
			}
			specificationCallbacks.Remove(ovrAvatarMessage_AvatarSpecification2.oculusUserID);
			break;
		}
		default:
			throw new NotImplementedException("Unhandled ovrAvatarMessageType: " + ovrAvatarMessageType2);
		}
		CAPI.ovrAvatarMessage_Free(intPtr);
	}

	public bool IsAvatarSpecWaiting()
	{
		return avatarSpecificationQueue.Count > 0;
	}

	public bool IsAvatarLoading()
	{
		return loadingAvatars.Count > 0;
	}

	public void AddLoadingAvatar(int gameobjectID)
	{
		loadingAvatars.Add(gameobjectID);
	}

	public void RemoveLoadingAvatar(int gameobjectID)
	{
		loadingAvatars.Remove(gameobjectID);
	}

	public void RequestAvatarSpecification(AvatarSpecRequestParams avatarSpecRequest)
	{
		avatarSpecificationQueue.Enqueue(avatarSpecRequest);
	}

	private void DispatchAvatarSpecificationRequest(AvatarSpecRequestParams avatarSpecRequest)
	{
		textureCopyManager.CheckFallbackTextureSet(avatarSpecRequest._lod);
		CAPI.ovrAvatar_SetForceASTCTextures(avatarSpecRequest._forceMobileTextureFormat);
		if (!specificationCallbacks.TryGetValue(avatarSpecRequest._userId, out var value))
		{
			value = new HashSet<specificationCallback>();
			specificationCallbacks.Add(avatarSpecRequest._userId, value);
			IntPtr specificationRequest = CAPI.ovrAvatarSpecificationRequest_Create(avatarSpecRequest._userId);
			CAPI.ovrAvatarSpecificationRequest_SetLookAndFeelVersion(specificationRequest, avatarSpecRequest._lookVersion);
			CAPI.ovrAvatarSpecificationRequest_SetFallbackLookAndFeelVersion(specificationRequest, avatarSpecRequest._fallbackVersion);
			CAPI.ovrAvatarSpecificationRequest_SetLevelOfDetail(specificationRequest, avatarSpecRequest._lod);
			CAPI.ovrAvatarSpecificationRequest_SetCombineMeshes(specificationRequest, avatarSpecRequest._useCombinedMesh);
			CAPI.ovrAvatarSpecificationRequest_SetExpressiveFlag(specificationRequest, avatarSpecRequest._enableExpressive);
			CAPI.ovrAvatar_RequestAvatarSpecificationFromSpecRequest(specificationRequest);
			CAPI.ovrAvatarSpecificationRequest_Destroy(specificationRequest);
		}
		value.Add(avatarSpecRequest._callback);
	}

	public void BeginLoadingAsset(ulong assetId, ovrAvatarAssetLevelOfDetail lod, assetLoadedCallback callback)
	{
		if (!assetLoadedCallbacks.TryGetValue(assetId, out var value))
		{
			value = new HashSet<assetLoadedCallback>();
			assetLoadedCallbacks.Add(assetId, value);
		}
		CAPI.ovrAvatarAsset_BeginLoadingLOD(assetId, lod);
		value.Add(callback);
	}

	public void RegisterCombinedMeshCallback(IntPtr sdkAvatar, combinedMeshLoadedCallback callback)
	{
		if (!combinedMeshLoadedCallbacks.TryGetValue(sdkAvatar, out var _))
		{
			combinedMeshLoadedCallbacks.Add(sdkAvatar, callback);
			return;
		}
		throw new Exception("Adding second combind mesh callback for same avatar");
	}

	public OvrAvatarAsset GetAsset(ulong assetId)
	{
		if (assetCache.TryGetValue(assetId, out var value))
		{
			return value;
		}
		return null;
	}

	public void DeleteAssetFromCache(ulong assetId)
	{
		if (assetCache.ContainsKey(assetId))
		{
			assetCache.Remove(assetId);
		}
	}

	public string GetAppId()
	{
		if (Application.platform != RuntimePlatform.Android)
		{
			return OvrAvatarSettings.AppID;
		}
		return OvrAvatarSettings.MobileAppID;
	}

	public OvrAvatarTextureCopyManager GetTextureCopyManager()
	{
		if (textureCopyManager != null)
		{
			return textureCopyManager;
		}
		return null;
	}
}
