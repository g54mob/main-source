using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pug.Sprite
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class SpriteObject : MonoBehaviour
	{
		public struct GroupIdentifier : IEquatable<GroupIdentifier>
		{
			public Material material;

			public int layer;

			private int hashCode;

			public bool castShadows;

			public GroupIdentifier(Material material, int layer)
			{
				this.material = material;
				this.layer = layer;
				hashCode = (material.GetInstanceID(), layer).GetHashCode();
				int num = material.FindPass("ShadowCaster");
				castShadows = num >= 0 && material.GetShaderPassEnabled("ShadowCaster");
			}

			public bool Equals(GroupIdentifier other)
			{
				return hashCode == other.hashCode;
			}

			public override int GetHashCode()
			{
				return hashCode;
			}
		}

		public const bool USE_DIRECT_GPU_MEM_ACCESS = false;

		public static float PixelsPerUnit = 16f;

		public static readonly Dictionary<GroupIdentifier, Dictionary<int, SpriteObject>> instanceLists = new Dictionary<GroupIdentifier, Dictionary<int, SpriteObject>>();

		public static readonly Dictionary<int, SpriteObject> syncInstanceList = new Dictionary<int, SpriteObject>();

		private static readonly Dictionary<Dictionary<int, SpriteObject>, SpriteObject[]> s_arrayCache = new Dictionary<Dictionary<int, SpriteObject>, SpriteObject[]>();

		private static readonly Dictionary<Dictionary<int, SpriteObject>, bool> s_arrayCacheDirty = new Dictionary<Dictionary<int, SpriteObject>, bool>();

		private const int ARRAY_POOL_PADDING_SIZE = 32;

		private static float s_deltaTime;

		[NonSerialized]
		public float animationTime;

		private GameObject cachedGameObject;

		[SerializeField]
		[AllowDirectDataBlockReference]
		[Obsolete]
		private SpriteAsset m_asset;

		[AllowDirectDataBlockReference]
		[Obsolete]
		public SpriteAssetSkin skin;

		[SerializeField]
		private DataBlockRef<SpriteAsset> m_assetRef;

		public DataBlockRef<SpriteAssetSkin> skinRef;

		public Color color = Color.white;

		[ColorUsage(false, true)]
		public Color emissiveColor = Color.white;

		public Color flashColor = Color.clear;

		public Color outlineColor = new Color(1f, 1f, 1f, 0f);

		[Obsolete]
		public Texture2D primaryGradientMap;

		[Obsolete]
		public Texture2D secondaryGradientMap;

		[Obsolete]
		public Texture2D tertiaryGradientMap;

		public DataBlockRef<GradientMapDataBlock> primaryGradientMapRef;

		public DataBlockRef<GradientMapDataBlock> secondaryGradientMapRef;

		public DataBlockRef<GradientMapDataBlock> tertiaryGradientMapRef;

		[Min(0f)]
		[Tooltip("The material used to render the object. Note that this material must use a shader which supports the special type of instancing used by the system.")]
		public Material material;

		[Space(5f)]
		[SerializeField]
		private int m_startAnimationHash;

		[SerializeField]
		private int m_startVariantHash;

		[Tooltip("The playback speed of animations.")]
		public float animationTimescale = 1f;

		[SerializeField]
		[Tooltip("Set the animation time of the start animation to a random value. Good for breaking up looping patterns among multiple instances.")]
		private bool m_randomStartTime;

		[Tooltip("Whether animation events should be processed and triggered or not. Leave off if events are not required (improves performance).")]
		public bool processAnimationEvents;

		public SpriteObject syncSource;

		public bool syncAnimation = true;

		public bool syncVariant = true;

		public bool syncSprite;

		[NonSerialized]
		public int forceRenderingOff;

		[Range(0f, 31f)]
		public int maskChannel;

		public SpriteMaskInteraction maskInteraction;

		private SpriteAsset m_cachedAsset;

		private Coroutine m_awaitAssetLoadingRoutine;

		private Transform m_cachedTransform;

		private Matrix4x4 m_cachedLocalToWorld;

		private int m_currentAnimationHash;

		private int m_currentAnimationIndex = -1;

		private int m_currentVariantHash;

		private int m_currentVariantIndex = -1;

		private FrameAnimation m_currentAnimation;

		private SpriteData m_currentSpriteData;

		private Vector4 m_currentAtlasRect;

		private Vector2 m_currentPivot;

		private int m_prevSrcFrame = -1;

		private Dictionary<int, SpriteObject> m_list;

		private bool m_hasAnimationEvents;

		private int m_queuedAnimationHash;

		private Vector3 m_gradientIndices;

		private bool m_isReady;

		private Vector3 m_transformAnimParams = -Vector3.one;

		private bool m_inSyncList;

		private static SpriteInstancingManager.InstanceData[] s_dataArray;

		private static Matrix4x4[] s_maskMatrices = new Matrix4x4[32];

		private static int _SpriteObjectMaskArray = Shader.PropertyToID("_SpriteObjectMaskArray");

		public SpriteAsset asset
		{
			get
			{
				return _asset;
			}
			set
			{
				_asset = value;
				ApplyVisualChange();
			}
		}

		public DataBlockAddress assetAddress => m_assetRef.address;

		public bool isReady => m_isReady;

		public int startAnimationHash => m_startAnimationHash;

		public int startVariantHash => m_startVariantHash;

		public int currentAnimationHash
		{
			get
			{
				if (!m_isReady)
				{
					return m_startAnimationHash;
				}
				return m_currentAnimationHash;
			}
		}

		public int currentAnimationIndex => m_currentAnimationIndex;

		public int currentVariantHash
		{
			get
			{
				if (!m_isReady)
				{
					return m_startVariantHash;
				}
				return m_currentVariantHash;
			}
		}

		public int currentVariantIndex => m_currentVariantIndex;

		public FrameAnimation currentAnimation => m_currentAnimation;

		public Vector4 currentAtlasRect => m_currentAtlasRect;

		public Vector4 currentPivot => m_currentPivot;

		public Vector3 gradientIndices => m_gradientIndices;

		public Vector3 transformAnimParams => m_transformAnimParams;

		public bool isSlaveSprite
		{
			get
			{
				if (syncSource != null)
				{
					return syncSprite;
				}
				return false;
			}
		}

		public GradientMapDataBlock currentPrimaryGradientMap
		{
			get
			{
				return primaryGradientMapRef.Get();
			}
			set
			{
				primaryGradientMapRef = (value ? value.address : DataBlockAddress.Empty);
				ApplyVisualChange();
			}
		}

		public GradientMapDataBlock currentSecondaryGradientMap
		{
			get
			{
				return secondaryGradientMapRef.Get();
			}
			set
			{
				secondaryGradientMapRef = (value ? value.address : DataBlockAddress.Empty);
				ApplyVisualChange();
			}
		}

		public GradientMapDataBlock currentTertiaryGradientMap
		{
			get
			{
				return tertiaryGradientMapRef.Get();
			}
			set
			{
				tertiaryGradientMapRef = (value ? value.address : DataBlockAddress.Empty);
				ApplyVisualChange();
			}
		}

		private SpriteAsset _asset
		{
			get
			{
				return m_assetRef.Get();
			}
			set
			{
				m_assetRef = value;
			}
		}

		public SpriteAssetSkin currentSkin
		{
			get
			{
				return skinRef.Get();
			}
			set
			{
				skinRef = (value ? value.address : DataBlockAddress.Empty);
				ApplyVisualChange();
			}
		}

		private bool hasPositionalData
		{
			get
			{
				if (_asset != null)
				{
					return _asset.positionalDataCount > 0;
				}
				return false;
			}
		}

		public event Action<int> onAnimationStart;

		public event Action<int> onAnimationEnd;

		public event Action<int> onAnimationEvent;

		public event Action onPositionalDataUpdated;

		private void Awake()
		{
			cachedGameObject = base.gameObject;
			m_isReady = false;
			m_awaitAssetLoadingRoutine = null;
		}

		private void OnEnable()
		{
			if (Application.isPlaying && m_asset != null && !m_assetRef.hasAddress)
			{
				Debug.LogError("SpriteObject " + base.name + " has no asset reference! Please open its inspector outside of play mode to auto-upgrade it (must be saved afterwards).", this);
			}
			if (Application.isPlaying && skin != null && !skinRef.hasAddress)
			{
				Debug.LogError("SpriteObject " + base.name + " has no skin reference! Please open its inspector outside of play mode to auto-upgrade it (must be saved afterwards).", this);
			}
			if (currentSkin != null && currentSkin.targetAsset != asset)
			{
				Debug.LogError("Skin target asset mismatch! Skin will be set to null", this);
				skinRef = DataBlockAddress.Empty;
			}
			Cache();
			AddToInstanceList();
			CheckIsReady();
		}

		private void CheckIsReady()
		{
			if (m_isReady)
			{
				return;
			}
			if (!SpriteAssetManager.isLoaded)
			{
				if (m_awaitAssetLoadingRoutine == null)
				{
					m_awaitAssetLoadingRoutine = StartCoroutine(AwaitAssetLoading());
				}
			}
			else
			{
				OnReady();
			}
		}

		private IEnumerator AwaitAssetLoading()
		{
			while (!SpriteAssetManager.isLoaded)
			{
				yield return null;
			}
			m_awaitAssetLoadingRoutine = null;
			OnReady();
		}

		private void OnReady()
		{
			if (m_isReady)
			{
				Debug.LogError("OnReady called twice!");
				return;
			}
			m_isReady = true;
			if (_asset != null)
			{
				m_currentVariantHash = 0;
				PlayAnimation(m_startAnimationHash, m_startVariantHash, forceResetTime: true);
			}
			if (m_randomStartTime && m_currentAnimation != null)
			{
				animationTime = UnityEngine.Random.value * m_currentAnimation.duration;
			}
			ValidateGradientMaps();
		}

		private void OnDisable()
		{
			RemoveFromInstanceList();
		}

		private void OnValidate()
		{
			if (!(_asset == null) && Application.isPlaying && SpriteAssetManager.isLoaded && _asset.staticAtlasRects != null)
			{
				Cache();
				ApplyVisualChange();
			}
		}

		private void Cache()
		{
			m_cachedTransform = base.transform;
			m_hasAnimationEvents = _asset != null && _asset.eventCount > 0;
		}

		public void PlayAnimation(int animationHash, bool forceResetTime = false, bool skipTransition = false)
		{
			PlayAnimation(animationHash, currentVariantHash, forceResetTime, skipTransition);
		}

		public void PlayAnimation(int animationHash, int variantHash, bool forceResetTime = false, bool skipTransition = false)
		{
			if (!m_isReady)
			{
				m_startAnimationHash = animationHash;
				m_startVariantHash = variantHash;
				return;
			}
			if (animationHash != 0 && !HasAnimation(animationHash))
			{
				animationHash = 0;
			}
			int transitionHash = _asset.GetTransitionHash(m_currentAnimationHash, animationHash);
			if (transitionHash != 0 && !skipTransition)
			{
				m_queuedAnimationHash = animationHash;
				animationHash = transitionHash;
			}
			else
			{
				m_queuedAnimationHash = 0;
			}
			int num = m_currentAnimationHash;
			SetCurrentAnimation(animationHash, variantHash);
			if (num != m_currentAnimationHash || forceResetTime)
			{
				animationTime = 0f;
				m_prevSrcFrame = -1;
			}
			this.onAnimationStart?.Invoke(m_currentAnimationHash);
		}

		public void RandomizeCurrentAnimationTime()
		{
			if (m_currentAnimation != null)
			{
				animationTime = m_currentAnimation.duration * UnityEngine.Random.value;
			}
		}

		public bool HasAnimation(int hash)
		{
			if (_asset == null)
			{
				return false;
			}
			return _asset.HasAnimation(hash);
		}

		public bool HasStaticVariant(int hash)
		{
			if (_asset == null)
			{
				return false;
			}
			return _asset.HasStaticVariant(hash);
		}

		public void StopAnimation()
		{
			PlayAnimation(0);
		}

		public void EndAnimation()
		{
			this.onAnimationEnd?.Invoke(m_currentAnimationHash);
			int num = m_currentAnimation.runtimeExitAnimationHash;
			if (m_queuedAnimationHash != 0)
			{
				num = m_queuedAnimationHash;
				m_queuedAnimationHash = 0;
			}
			if (num == 0)
			{
				StopAnimation();
			}
			else
			{
				PlayAnimation(num, m_currentVariantHash);
			}
		}

		public void SetVariant(int variantHash)
		{
			if (variantHash != currentVariantHash)
			{
				SetVariantInternal(variantHash);
				UpdateAtlasRect();
			}
		}

		public void SetVariantByIndex(int variantIndex)
		{
			variantIndex--;
			int variantInternal = ((m_currentAnimation == null) ? _asset.GetStaticVariantHash(variantIndex) : m_currentAnimation.GetVariantHash(variantIndex));
			SetVariantInternal(variantInternal);
			UpdateAtlasRect();
		}

		public void ResetVariant()
		{
			SetVariant(0);
		}

		public void PlayTransformAnimation(int hash, float duration)
		{
			PlayTransformAnimationInternal(hash, duration);
		}

		public void PlayTransformAnimation(int hash)
		{
			PlayTransformAnimationInternal(hash, -1f);
		}

		private void GetRectAndPivot(FrameAnimation animation, float animationTime, out Vector4 rect, out Vector2 pivot)
		{
			rect = (pivot = Vector4.zero);
			pivot = m_currentSpriteData.pivot;
			int num = 0;
			int num2 = 1;
			if (animation != null)
			{
				int runtimeFrame = animation.GetRuntimeFrame(animationTime);
				num = animation.GetSrcFrame(runtimeFrame);
				num2 = animation.srcFrameCount;
			}
			Texture2D srcTexture = m_currentSpriteData.GetSrcTexture();
			if (srcTexture != null)
			{
				rect = new Vector4(num * srcTexture.width / num2, 0f, srcTexture.width / num2, srcTexture.height);
				pivot.x = Mathf.Round(pivot.x * rect.z) / rect.z;
				pivot.y = Mathf.Round(pivot.y * rect.w) / rect.w;
			}
		}

		public Vector3 GetPositionalData(int nameHash, Space space = Space.World)
		{
			int num = 0;
			if (currentAnimation != null)
			{
				int runtimeFrame = currentAnimation.GetRuntimeFrame(animationTime);
				num = currentAnimation.GetSrcFrame(runtimeFrame);
			}
			GetRectAndPivot(currentAnimation, animationTime, out var rect, out var pivot);
			int positionalDataIndex = asset.GetPositionalDataIndex(nameHash);
			if (positionalDataIndex >= m_currentSpriteData.positionalData.Length)
			{
				string text = ((currentAnimation != null) ? ("Animation '" + currentAnimation.name + "'") : "Static state");
				string positionalDataName = asset.GetPositionalDataName(positionalDataIndex);
				Debug.LogError(text + " on asset '" + asset.name + "' missing '" + positionalDataName + "' data.", this);
				return Vector3.zero;
			}
			if (num >= m_currentSpriteData.positionalData[positionalDataIndex].frames.Length)
			{
				string text2 = ((currentAnimation != null) ? ("Animation '" + currentAnimation.name + "'") : "Static state");
				string positionalDataName2 = asset.GetPositionalDataName(positionalDataIndex);
				Debug.LogError($"{text2} on asset '{asset.name}' missing '{positionalDataName2}' data. srcFrame = {num}", this);
				return Vector3.zero;
			}
			Vector2 vector = m_currentSpriteData.positionalData[positionalDataIndex].frames[num];
			vector -= pivot;
			vector.x *= rect.z / PixelsPerUnit;
			vector.y *= rect.w / PixelsPerUnit;
			Vector3 vector2 = vector;
			if (space == Space.World)
			{
				vector2 = base.transform.TransformPoint(vector2);
			}
			return vector2;
		}

		private void PlayTransformAnimationInternal(int hash, float durationOverride)
		{
			if (TransformAnimation.TryGet(hash, out var result))
			{
				float time = Time.time;
				m_transformAnimParams = new Vector3(result.index, time, (durationOverride > 0f) ? durationOverride : result.duration);
			}
		}

		public void ApplyVisualChange()
		{
			if (base.isActiveAndEnabled)
			{
				UpdateInstanceListIfNeeded();
				if (m_isReady)
				{
					SetCurrentAnimation(m_currentAnimationHash, m_currentVariantHash);
				}
				ValidateGradientMaps();
			}
		}

		private void ValidateGradientMaps()
		{
			SpriteAssetBase spriteAssetBase = (currentSkin ? ((SpriteAssetBase)currentSkin) : ((SpriteAssetBase)asset));
			if (spriteAssetBase != null)
			{
				if (!primaryGradientMapRef.hasAddress && primaryGradientMapRef != spriteAssetBase.defaultPrimaryGradientMapRef)
				{
					primaryGradientMapRef = spriteAssetBase.defaultPrimaryGradientMapRef;
				}
				if (!secondaryGradientMapRef.hasAddress && secondaryGradientMapRef != spriteAssetBase.defaultSecondaryGradientMapRef)
				{
					secondaryGradientMapRef = spriteAssetBase.defaultSecondaryGradientMapRef;
				}
				if (!tertiaryGradientMapRef.hasAddress && tertiaryGradientMapRef != spriteAssetBase.defaultTertiaryGradientMapRef)
				{
					tertiaryGradientMapRef = spriteAssetBase.defaultTertiaryGradientMapRef;
				}
			}
			if (Application.isPlaying)
			{
				CacheGradientIndices();
			}
		}

		public void SyncFromSource()
		{
			int animationHash = m_currentAnimationHash;
			int variantHash = m_currentVariantHash;
			if (syncAnimation)
			{
				m_transformAnimParams = syncSource.m_transformAnimParams;
				animationTime = syncSource.animationTime;
				animationTimescale = syncSource.animationTimescale;
				animationHash = syncSource.currentAnimationHash;
			}
			if (syncVariant)
			{
				variantHash = syncSource.currentVariantHash;
			}
			SetCurrentAnimation(animationHash, variantHash);
		}

		private void CacheGradientIndices()
		{
			m_gradientIndices = new Vector3
			{
				x = SpriteAssetManager.GetGradientIndex(currentPrimaryGradientMap),
				y = SpriteAssetManager.GetGradientIndex(currentSecondaryGradientMap),
				z = SpriteAssetManager.GetGradientIndex(currentTertiaryGradientMap)
			};
			DoGradientMapCheck(currentPrimaryGradientMap, m_gradientIndices.x);
			DoGradientMapCheck(currentSecondaryGradientMap, m_gradientIndices.y);
			DoGradientMapCheck(currentTertiaryGradientMap, m_gradientIndices.z);
		}

		private void DoGradientMapCheck(GradientMapDataBlock gradientMap, float index)
		{
			if (gradientMap != null)
			{
				_ = 0f;
			}
		}

		private void UpdateAnimation()
		{
			float endAnimationTime = animationTime + s_deltaTime * animationTimescale;
			while (ProcessCurrentAnimation(ref endAnimationTime, animationTimescale < 0f))
			{
			}
			animationTime = endAnimationTime;
		}

		private bool ProcessCurrentAnimation(ref float endAnimationTime, bool reversed)
		{
			int runtimeFrameCount = m_currentAnimation.runtimeFrameCount;
			float fps = m_currentAnimation.fps;
			float num = (float)runtimeFrameCount / fps;
			if (m_hasAnimationEvents && processAnimationEvents && m_currentAnimation.runtimeHasEvents)
			{
				int i = (int)(animationTime * fps);
				int num2 = (int)(endAnimationTime * fps);
				if (!m_currentAnimation.loop)
				{
					num2 = ((!reversed) ? Mathf.Min(num2, m_currentAnimation.runtimeFrameCount - 1) : Mathf.Max(num2, 0));
				}
				for (; reversed ? (i >= num2) : (i <= num2); i += ((!reversed) ? 1 : (-1)))
				{
					int srcFrame = m_currentAnimation.GetSrcFrame(i);
					if (srcFrame != m_prevSrcFrame)
					{
						int eventMask = m_currentAnimation.GetEventMask(srcFrame);
						int eventCount = _asset.eventCount;
						if (eventMask != 0)
						{
							for (int j = 0; j < eventCount; j++)
							{
								if ((eventMask & (1 << j)) != 0)
								{
									int eventHash = _asset.GetEventHash(j);
									this.onAnimationEvent?.Invoke(eventHash);
								}
							}
						}
					}
					m_prevSrcFrame = srcFrame;
				}
			}
			if (!reversed && endAnimationTime > num && !m_currentAnimation.loop)
			{
				EndAnimation();
				animationTime = 0f;
				endAnimationTime -= num;
				return m_currentAnimation != null;
			}
			return false;
		}

		private void SetCurrentAnimation(int animationHash, int variantHash)
		{
			if (!m_isReady || isSlaveSprite)
			{
				m_startAnimationHash = animationHash;
				m_startVariantHash = variantHash;
				return;
			}
			m_currentAnimationIndex = _asset.GetAnimationIndex(animationHash);
			if (m_currentAnimationIndex < 0)
			{
				m_currentAnimationHash = 0;
				m_currentAnimation = null;
			}
			else
			{
				m_currentAnimationHash = animationHash;
				m_currentAnimation = _asset.GetAnimationAt(m_currentAnimationIndex);
			}
			SetVariantInternal(variantHash);
			UpdateAtlasRect();
		}

		private void SetVariantInternal(int variantHash)
		{
			if (!m_isReady)
			{
				m_startVariantHash = variantHash;
				return;
			}
			if (variantHash != 0)
			{
				if (m_currentAnimation != null)
				{
					m_currentVariantIndex = m_currentAnimation.GetVariantIndex(variantHash);
				}
				else
				{
					m_currentVariantIndex = _asset.GetStaticVariantIndex(variantHash);
				}
			}
			else
			{
				m_currentVariantIndex = -1;
			}
			if (m_currentVariantIndex > -1)
			{
				m_currentVariantHash = variantHash;
			}
			else
			{
				m_currentVariantHash = 0;
			}
		}

		private void UpdateAtlasRect()
		{
			SpriteAssetBase spriteAssetBase = _asset;
			bool flag = (object)currentSkin != null;
			if (flag)
			{
				spriteAssetBase = currentSkin;
			}
			if ((object)spriteAssetBase != null)
			{
				if (m_currentAnimationIndex < 0)
				{
					m_currentAtlasRect = spriteAssetBase.GetAtlasData(-1, m_currentVariantIndex);
				}
				else
				{
					m_currentAtlasRect = spriteAssetBase.GetAtlasData(m_currentAnimationIndex, m_currentVariantIndex);
				}
				if (flag)
				{
					SpriteAssetSkin.ReplacementData replacementData = ((m_currentAnimationIndex >= 0) ? currentSkin.GetReplacementAt(m_currentAnimationIndex) : currentSkin.staticReplacementData);
					m_currentSpriteData = ((m_currentVariantIndex < 0) ? replacementData.spriteData : replacementData.GetVariant(m_currentVariantIndex));
				}
				else if (m_currentAnimationIndex < 0)
				{
					m_currentSpriteData = ((m_currentVariantIndex < 0) ? _asset.staticSpriteData : _asset.GetStaticVariant(m_currentVariantIndex));
				}
				else
				{
					m_currentSpriteData = ((m_currentVariantIndex < 0) ? m_currentAnimation.spriteData : m_currentAnimation.GetVariant(m_currentVariantIndex));
				}
				m_currentPivot = m_currentSpriteData.pivot;
			}
		}

		private void AddToInstanceList()
		{
			if (m_list != null || material == null || (_asset == null && !isSlaveSprite))
			{
				return;
			}
			if (!IsInstanceListModificationAllowed())
			{
				base.enabled = false;
				return;
			}
			GroupIdentifier key = new GroupIdentifier(material, cachedGameObject.layer);
			if (!instanceLists.TryGetValue(key, out m_list))
			{
				m_list = new Dictionary<int, SpriteObject>(512);
				instanceLists.Add(key, m_list);
			}
			if (syncSource != null)
			{
				syncInstanceList.Add(GetInstanceID(), this);
				m_inSyncList = true;
			}
			m_list.Add(GetInstanceID(), this);
			s_arrayCacheDirty[m_list] = true;
		}

		private void UpdateInstanceListIfNeeded()
		{
			if (m_list == null)
			{
				AddToInstanceList();
				return;
			}
			GroupIdentifier key = new GroupIdentifier(material, cachedGameObject.layer);
			int instanceID = GetInstanceID();
			instanceLists.TryGetValue(key, out var value);
			if (value != m_list)
			{
				m_list.Remove(instanceID);
				s_arrayCacheDirty[m_list] = true;
				m_list = value;
				if (value == null)
				{
					m_list = new Dictionary<int, SpriteObject>(512);
					instanceLists.Add(key, m_list);
				}
				m_list.Add(instanceID, this);
				s_arrayCacheDirty[m_list] = true;
			}
			if (!m_inSyncList && (bool)syncSource)
			{
				syncInstanceList.Add(instanceID, this);
				m_inSyncList = true;
			}
			else if (m_inSyncList && !syncSource)
			{
				syncInstanceList.Remove(instanceID);
				m_inSyncList = false;
			}
		}

		private void RemoveFromInstanceList()
		{
			int instanceID = GetInstanceID();
			if (m_list != null)
			{
				if (!IsInstanceListModificationAllowed())
				{
					return;
				}
				m_list.Remove(instanceID);
				s_arrayCacheDirty[m_list] = true;
				m_list = null;
			}
			if (m_inSyncList)
			{
				syncInstanceList.Remove(instanceID);
				m_inSyncList = false;
			}
		}

		private static bool IsInstanceListModificationAllowed()
		{
			if (SpriteInstancingManager.isIteratingInstanceLists)
			{
				Debug.LogError("Trying to modify SpriteObject instance list while SpriteInstancingManager is iterating. This is not allowed.");
				return false;
			}
			return true;
		}

		private static SpriteObject[] GetSpriteArrayCache(Dictionary<int, SpriteObject> spriteObjects)
		{
			SpriteObject[] value = null;
			if (s_arrayCacheDirty[spriteObjects])
			{
				if (s_arrayCache.TryGetValue(spriteObjects, out value) && value.Length < spriteObjects.Count)
				{
					for (int i = 0; i < value.Length; i++)
					{
						value[i] = null;
					}
					ArrayPool<SpriteObject>.Shared.Return(value);
					value = null;
				}
				if (value == null)
				{
					value = ArrayPool<SpriteObject>.Shared.Rent(spriteObjects.Count + 32);
					s_arrayCache[spriteObjects] = value;
				}
				spriteObjects.Values.CopyTo(value, 0);
				s_arrayCacheDirty[spriteObjects] = false;
			}
			else
			{
				value = s_arrayCache[spriteObjects];
			}
			return value;
		}

		public static void UpdateSpritesAndWriteInstanceData(Dictionary<int, SpriteObject> spriteObjects, ComputeBuffer buffer)
		{
			UpdateMaskData();
			s_deltaTime = Time.deltaTime;
			SpriteObject[] spriteArrayCache = GetSpriteArrayCache(spriteObjects);
			int count = spriteObjects.Count;
			if (s_dataArray == null || s_dataArray.Length < count)
			{
				s_dataArray = new SpriteInstancingManager.InstanceData[count * 2];
			}
			foreach (SpriteObject value in syncInstanceList.Values)
			{
				value.SyncFromSource();
			}
			for (int i = 0; i < count; i++)
			{
				SpriteObject spriteObject = spriteArrayCache[i];
				if (spriteObject.m_currentAnimationIndex > -1)
				{
					spriteObject.UpdateAnimation();
				}
				FrameAnimation frameAnimation = spriteObject.m_currentAnimation;
				if (spriteObject.m_cachedTransform.hasChanged)
				{
					spriteObject.m_cachedLocalToWorld = spriteObject.m_cachedTransform.localToWorldMatrix;
					spriteObject.m_cachedTransform.hasChanged = false;
				}
				Vector4 rect = spriteObject.m_currentAtlasRect;
				Vector2 pivot = spriteObject.m_currentPivot;
				int num = spriteObject.m_currentAnimationHash;
				if (spriteObject.syncSprite && spriteObject.m_inSyncList)
				{
					SpriteObject spriteObject2 = spriteObject.syncSource;
					rect = spriteObject2.m_currentAtlasRect;
					pivot = spriteObject2.m_currentPivot;
					num = spriteObject2.m_currentAnimationHash;
					frameAnimation = spriteObject2.m_currentAnimation;
				}
				if (num != 0)
				{
					int runtimeFrameCount = frameAnimation.runtimeFrameCount;
					int num2 = ((int)(spriteObject.animationTime * frameAnimation.fps) % runtimeFrameCount + runtimeFrameCount) % runtimeFrameCount;
					int num3 = frameAnimation.runtimeFrameRemap[num2 % frameAnimation.runtimeFrameRemap.Length];
					rect.z /= frameAnimation.srcFrameCount;
					rect.x += (float)num3 * rect.z;
				}
				int num4 = ((spriteObject.maskInteraction == SpriteMaskInteraction.VisibleInsideMask) ? 1 : ((spriteObject.maskInteraction == SpriteMaskInteraction.VisibleOutsideMask) ? (-1) : 0));
				if (spriteObject.hasPositionalData)
				{
					spriteObject.onPositionalDataUpdated?.Invoke();
				}
				SpriteInstancingManager.InstanceData instanceData = new SpriteInstancingManager.InstanceData
				{
					localToWorld = ((spriteObject.forceRenderingOff > 0) ? Matrix4x4.zero : spriteObject.m_cachedLocalToWorld),
					rect = rect,
					pivot = pivot,
					color = spriteObject.color.linear,
					emissiveColor = spriteObject.emissiveColor,
					flashColor = spriteObject.flashColor.linear,
					outlineColor = spriteObject.outlineColor.linear,
					gradientIndices = spriteObject.m_gradientIndices,
					transformAnimParams = spriteObject.m_transformAnimParams,
					maskParam = (spriteObject.maskChannel + 1) * num4
				};
				s_dataArray[i] = instanceData;
			}
			buffer.SetData(s_dataArray, 0, 0, count);
		}

		private static void UpdateMaskData()
		{
			for (int i = 0; i < 32; i++)
			{
				s_maskMatrices[i] = Matrix4x4.zero;
			}
			for (int j = 0; j < SpriteObjectMask.instances.Count; j++)
			{
				SpriteObjectMask spriteObjectMask = SpriteObjectMask.instances[j];
				if (s_maskMatrices[spriteObjectMask.channel].m33 != 0f)
				{
					Debug.LogError(string.Format("Mask channel {0} is already defined by another {1} component! Only one components is allowed per-channel.", spriteObjectMask.channel, "SpriteObjectMask"), spriteObjectMask);
				}
				s_maskMatrices[spriteObjectMask.channel] = spriteObjectMask.matrix.inverse;
			}
			Shader.SetGlobalMatrixArray(_SpriteObjectMaskArray, s_maskMatrices);
		}
	}
}
