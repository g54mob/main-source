using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using PugMod;
using PugTilemap;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

public class EffectsManager : ManagerBase, IEffects
{
	[Serializable]
	public class GlowColor
	{
		public ConditionID glowCondition;

		public Color color;
	}

	private struct ParticleEffectParameters
	{
		public int ParticleEffectID;

		public GameObject FollowGameObject;

		public Vector3 RelativePosition;

		public PugParticleQuality MinimumParticleQuality;

		public float Duration;

		public int DictID;
	}

	private enum ParticleEffectStatus
	{
		Undefined = 0,
		Playing = 1,
		Stopped = 2,
		BlockedByQualitySetting = 3,
		Inactive = 4
	}

	private class ActiveParticleEffectContainer
	{
		public ParticleEffectParameters Parameters;

		public PooledParticleSystem Instance;

		public float TimeAlive;

		public ParticleEffectStatus Status;

		public ActiveParticleEffectContainer(ParticleEffectParameters parameters)
		{
			Parameters = parameters;
			Instance = null;
			TimeAlive = 0f;
			Status = ParticleEffectStatus.Undefined;
		}
	}

	private struct PuffEntry
	{
		public PuffID puff;

		public Vector3 position;

		public int optionalSizeVariation;

		public PuffEntry(PuffID puff, Vector3 position, int optionalSizeVariation)
		{
			this.puff = puff;
			this.position = position;
			this.optionalSizeVariation = optionalSizeVariation;
		}
	}

	private struct WobbleInstance : IEquatable<WobbleInstance>
	{
		public Vector3Int position;

		public Coroutine coroutine;

		public bool flashRed;

		public float timestamp;

		public int arrayIndex;

		public bool Equals(WobbleInstance other)
		{
			return coroutine == other.coroutine;
		}
	}

	private static ProfilerMarker _particleEffectsMarker = new ProfilerMarker("ParticleEffects");

	private const float PLACED_OBJECT_EVENT_DURATION = 5f;

	public WeaponEffectsTable weaponEffectsTable;

	public Color outlineColor;

	public Color discreteOutlineColor;

	public Color cloneEnemyOutlineColor;

	[ArrayElementTitle("glowCondition")]
	public GlowColor[] glowColors;

	private ParticleSystem[] puffMap;

	private bool[] puffHasChildren;

	[Header("Prefab references:")]
	public PooledParticleSystemBank particleEffectBank;

	public SpriteTempEffect spriteTempEffectPrefab;

	[Header("Flash curves:")]
	public AnimationCurve healCurve;

	public AnimationCurve simpleFlashCurve;

	public AnimationCurve brightFlashCurve;

	[Header("Minion Target Effect")]
	public AnimationCurve minionTargetFlashCurve;

	public Color minionTargetFlashColor;

	public float minionTargetFlashDuration;

	[Header("Walls Tiles wobble:")]
	public AnimationCurve wobbleCurve;

	public AnimationCurve flashCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	[Header("Every 5'th upgrade will play the next sound effect in the list")]
	public List<SFXTableIDField> upgradeSounds;

	private PoolSystem spriteTempEffectPool;

	private Dictionary<Vector2Int, ParticleWallCollider> particleWallColliders;

	private Dictionary<int, GameObject> _particleEffectsPrefabMap;

	private Dictionary<int, ActiveParticleEffectContainer> _activeParticleEffectsMap = new Dictionary<int, ActiveParticleEffectContainer>();

	private HashSet<int> _lingeringRemovedParticleEffects = new HashSet<int>();

	private int _particleEffectsCounter;

	private Queue<ParticleEffectParameters> _particleEffectsPlayQueue = new Queue<ParticleEffectParameters>();

	private Transform _prevOriginTransform;

	private List<int> _effectsToRemove = new List<int>();

	private List<int2> _placedObjectEffectPositions = new List<int2>();

	private List<float> _placedObjectEffectTimers = new List<float>();

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("EffectsManager.Init");

	private Queue<PuffEntry> puffPlayQueue = new Queue<PuffEntry>();

	private Coroutine scanCoroutine;

	private const int MAX_WOBBLES = 10;

	private Vector4[] wobbleArray = new Vector4[10];

	private Vector4[] flashArray = new Vector4[10];

	private int wobbleCounter;

	private List<TimerSimple> destroyTileEffectTimers = new List<TimerSimple>();

	private List<Vector3Int> destroyTileEffectTimerPositions = new List<Vector3Int>();

	private static readonly int WobbleArray = Shader.PropertyToID("WobbleArray");

	private static readonly int FlashArray = Shader.PropertyToID("FlashArray");

	private Dictionary<Vector3Int, WobbleInstance> s_activeWobbles = new Dictionary<Vector3Int, WobbleInstance>(10);

	private const float WOBBLE_DURATION = 0.2f;

	private TimerSimple destroyEffectCooldown = new TimerSimple(0.15f);

	private int destroyEffectSpamCounter;

	public PoolSystem SpriteTempEffectPool => spriteTempEffectPool;

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			spriteTempEffectPool = new PoolSystem(spriteTempEffectPrefab.gameObject, typeof(SpriteTempEffect), base.transform, autoEnable: true, 512, 512, -1, "SpriteTempEffect");
			List<GameObject> list = Resources.LoadAll("Puffs", typeof(GameObject)).Cast<GameObject>().ToList();
			List<GameObject> list2 = new List<GameObject>();
			foreach (GameObject item in list)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(item, new Vector3(30f, 0f, 0f), Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.name = item.name;
				list2.Add(gameObject);
			}
			Dictionary<string, int> puffNameToIndex = GetPuffNameToIndex();
			puffMap = new ParticleSystem[puffNameToIndex.Count];
			puffHasChildren = new bool[puffNameToIndex.Count];
			foreach (GameObject item2 in list2)
			{
				ParticleSystem component = item2.GetComponent<ParticleSystem>();
				string text = component.name;
				if (!puffNameToIndex.TryGetValue(text, out var value))
				{
					Debug.LogError("Puff PS '" + text + "' not present in EffectsManager.Puffs enum");
					continue;
				}
				puffMap[value] = component;
				puffHasChildren[value] = component.transform.childCount > 0;
			}
			_particleEffectsPrefabMap = new Dictionary<int, GameObject>();
			foreach (PooledParticleSystemBank.PoolInitializer poolInitializer in particleEffectBank.poolInitializers)
			{
				int persistentHash = poolInitializer.persistentHash;
				if (_particleEffectsPrefabMap.TryGetValue(persistentHash, out var value2))
				{
					Debug.LogError($"ParticleEffectID {persistentHash} for {poolInitializer.prefab.name} is already used by {value2.name}");
				}
				else
				{
					_particleEffectsPrefabMap.Add(persistentHash, poolInitializer.prefab.gameObject);
				}
			}
			particleWallColliders = new Dictionary<Vector2Int, ParticleWallCollider>();
			ResetWobbleShaderData();
			PrefsManager prefs = Manager.prefs;
			prefs.OnParticleQualityChanged = (Action<PugParticleQuality>)Delegate.Combine(prefs.OnParticleQualityChanged, new Action<PugParticleQuality>(UpdateParticleEffectsFromQualitySettings));
			return true;
		}
	}

	private static Dictionary<string, int> GetPuffNameToIndex()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		string[] names = Enum.GetNames(typeof(PuffID));
		for (int i = 0; i < names.Length; i++)
		{
			dictionary.Add(names[i], i);
		}
		return dictionary;
	}

	private void CheckInstantiatedPuffsMatchPuffIDEnum(List<GameObject> instantiatedPuffs, Dictionary<string, int> puffNameToIndex)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (GameObject instantiatedPuff in instantiatedPuffs)
		{
			hashSet.Add(instantiatedPuff.name);
		}
		foreach (string key in puffNameToIndex.Keys)
		{
			if (!hashSet.Contains(key))
			{
				Debug.LogError("Missing particle prefab for " + key);
			}
		}
		foreach (GameObject instantiatedPuff2 in instantiatedPuffs)
		{
			if (!puffNameToIndex.ContainsKey(instantiatedPuff2.name))
			{
				Debug.LogError("Missing id for particle prefab " + instantiatedPuff2);
			}
		}
	}

	public void OnSceneUnload()
	{
		ParticleSystem[] componentsInChildren = Manager.main.gameObject.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			if (!particleSystem.CompareTag("DontClearParticles"))
			{
				particleSystem.Stop();
				particleSystem.Clear();
			}
		}
		spriteTempEffectPool.FreeAll();
		StopAllCoroutines();
		Time.timeScale = 1f;
	}

	public void PlayQueuedPuffs()
	{
		if (puffPlayQueue.Count > 0)
		{
			PuffEntry puffEntry = puffPlayQueue.Dequeue();
			Vector3 position = puffEntry.position - Manager.camera.RenderOrigo;
			PuffTryAddWaterImpulse(puffEntry.puff, position, puffEntry.optionalSizeVariation);
			PlayParticleSystem(puffEntry.puff, position);
		}
	}

	private void LateUpdate()
	{
		if (Manager.sceneHandler == null || !Manager.sceneHandler.isInGame)
		{
			StopAnyScanEffect();
		}
		base.transform.localPosition = -Manager.camera.RenderOrigo;
		UploadWobbleShaderData();
		if (_prevOriginTransform != Manager.camera.VolatileRenderAnchor)
		{
			_prevOriginTransform = Manager.camera.VolatileRenderAnchor;
			foreach (KeyValuePair<int, ActiveParticleEffectContainer> item in _activeParticleEffectsMap)
			{
				ActiveParticleEffectContainer value = item.Value;
				if (value.Instance != null)
				{
					value.Instance.UpdateSimulationSpace(_prevOriginTransform);
				}
			}
		}
		foreach (KeyValuePair<int, ActiveParticleEffectContainer> item2 in _activeParticleEffectsMap)
		{
			int key = item2.Key;
			ActiveParticleEffectContainer value2 = item2.Value;
			value2.TimeAlive += Time.deltaTime;
			ParticleEffectStatus status = value2.Status;
			if ((status == ParticleEffectStatus.Playing || status == ParticleEffectStatus.BlockedByQualitySetting) && value2.TimeAlive > value2.Parameters.Duration)
			{
				value2.Status = ParticleEffectStatus.Stopped;
				value2.Instance.Stop();
			}
			if (value2.Status == ParticleEffectStatus.Playing && value2.Parameters.FollowGameObject != null)
			{
				value2.Instance.transform.position = value2.Parameters.FollowGameObject.transform.position + value2.Parameters.RelativePosition;
			}
			if (value2.Status == ParticleEffectStatus.Stopped && (value2.Instance == null || !value2.Instance.IsAlive()))
			{
				_effectsToRemove.Add(key);
			}
		}
		foreach (int item3 in _effectsToRemove)
		{
			_activeParticleEffectsMap.Remove(item3, out var value3);
			if (value3.Instance != null)
			{
				value3.Instance.Free();
			}
		}
		_effectsToRemove.Clear();
		ParticleEffectParameters result;
		while (_particleEffectsPlayQueue.TryDequeue(out result))
		{
			StartParticleEffectInternal(result);
		}
		_lingeringRemovedParticleEffects.Clear();
		float deltaTime = Time.deltaTime;
		for (int num = _placedObjectEffectPositions.Count - 1; num >= 0; num--)
		{
			_placedObjectEffectTimers[num] -= deltaTime;
			if (_placedObjectEffectTimers[num] <= 0f)
			{
				_placedObjectEffectPositions.RemoveAtSwapBack(num);
				_placedObjectEffectTimers.RemoveAtSwapBack(num);
			}
		}
	}

	public SpriteTempEffect PlayTempSprite(int animHash, Vector3 position, float scale = 1f, float lifetime = 1f, float positionDev = 0f, bool looping = false)
	{
		SpriteTempEffect freeComponent = spriteTempEffectPool.GetFreeComponent<SpriteTempEffect>();
		if (freeComponent == null)
		{
			return null;
		}
		freeComponent.SetSortingLayer(SortingLayerID.Default);
		freeComponent.SetSortingOrder(0);
		freeComponent.gameObject.layer = ObjectLayerID.TransparentFX;
		freeComponent.Play(animHash, position, scale, lifetime, positionDev, looping);
		return freeComponent;
	}

	public void ExploDisc(Vector3 position, float scale = 1f, float positionDev = 0f, float lifetime = 2f / 15f)
	{
		PlayTempSprite(SpriteTempEffectID.ExploDisc, position, scale, lifetime, positionDev);
	}

	public void PlayPuff(PuffParams param, Transform objectTransform)
	{
		PlayPuff(param.puff, objectTransform.position + param.relativePosition, param.particleCount);
	}

	public void PlayPuff(PuffParams param, Vector3 pos)
	{
		PlayPuff(param.puff, pos + param.relativePosition, param.particleCount);
	}

	private void PuffTryAddWaterImpulse(PuffID puff, Vector3 position, int sizeVariation)
	{
		switch (puff)
		{
		case PuffID.SmallWaterSplash:
		case PuffID.WaterRipple:
		case PuffID.SmallYellowWaterSplash:
		case PuffID.YellowWaterRipple:
		case PuffID.SmallMoldWaterSplash:
		case PuffID.MoldWaterRipple:
		case PuffID.WaterImpact:
		{
			bool hasWater;
			TileInfo topTileAndCheckWater = Manager.multiMap.GetTileLayerLookup().GetTopTileAndCheckWater(Manager.camera.RenderOrigo.ToInt2() + position.RoundToInt2(), out hasWater);
			if (hasWater && topTileAndCheckWater.tileType != TileType.bridge)
			{
				float radius = 0.5f;
				float amplitude = 1f;
				if (sizeVariation > 0)
				{
					radius = 1f;
					amplitude = 4f;
				}
				WaterSim.AddImpulse(position, radius, amplitude);
			}
			break;
		}
		}
	}

	public void PlayPuff(PuffID puff, Vector3 position, int particleCount = 10, bool guaranteedToPlay = false, int optionalSizeVariation = 0)
	{
		if ((int)puff >= puffHasChildren.Length)
		{
			Debug.LogError($"Puff {puff} is not in the puffHasChildren array");
			return;
		}
		if (puffHasChildren[(int)puff])
		{
			if (puffPlayQueue.Count < 10 || guaranteedToPlay)
			{
				Vector3 position2 = position + Manager.camera.RenderOrigo;
				puffPlayQueue.Enqueue(new PuffEntry(puff, position2, optionalSizeVariation));
			}
			return;
		}
		ParticleSystem particleSystem = puffMap[(int)puff];
		if (particleSystem == null)
		{
			Debug.LogError($"Couldn't find puff {puff}", this);
			return;
		}
		ParticleSystem.MainModule main = particleSystem.main;
		main.simulationSpace = ParticleSystemSimulationSpace.Custom;
		main.customSimulationSpace = Manager.camera.VolatileRenderAnchor;
		if (!particleSystem.isPlaying)
		{
			particleSystem.randomSeed = (uint)UnityEngine.Random.Range(0, int.MaxValue);
		}
		particleSystem.transform.position = position;
		particleSystem.Emit(particleCount);
		PuffTryAddWaterImpulse(puff, position, optionalSizeVariation);
		if (Manager.DEBUG_MODE && particleSystem.particleCount >= particleSystem.main.maxParticles)
		{
			Debug.LogWarning($"Too many particles in {puff} ({particleCount} / {particleSystem.main.maxParticles})", particleSystem);
		}
	}

	public ParticleSystem PlayPuffOnLayer(PuffID puff, Vector3 position, int layer, int particleCount = 10, int optionalSizeVariation = 0)
	{
		if (puffHasChildren[(int)puff])
		{
			if (puffPlayQueue.Count < 10)
			{
				puffPlayQueue.Enqueue(new PuffEntry(puff, position, optionalSizeVariation));
			}
			return null;
		}
		ParticleSystem particleSystem = puffMap[(int)puff];
		ParticleSystem.MainModule main = particleSystem.main;
		main.simulationSpace = ParticleSystemSimulationSpace.Custom;
		main.customSimulationSpace = Manager.camera.VolatileRenderAnchor;
		if (!particleSystem.isPlaying)
		{
			particleSystem.randomSeed = (uint)UnityEngine.Random.Range(0, int.MaxValue);
		}
		particleSystem.transform.position = position;
		particleSystem.gameObject.layer = layer;
		particleSystem.Emit(particleCount);
		PuffTryAddWaterImpulse(puff, position, optionalSizeVariation);
		if (Manager.DEBUG_MODE && particleSystem.particleCount >= particleSystem.main.maxParticles)
		{
			Debug.LogWarning($"Too many particles in {puff} ({particleCount} / {particleSystem.main.maxParticles})", particleSystem);
		}
		return particleSystem;
	}

	public int StartParticleEffect(int particleEffectID, GameObject followGameObject, float duration = float.PositiveInfinity, Vector3 relativePosition = default(Vector3), PugParticleQuality minimumParticleQuality = PugParticleQuality.Low)
	{
		ParticleEffectParameters item = new ParticleEffectParameters
		{
			ParticleEffectID = particleEffectID,
			FollowGameObject = followGameObject,
			RelativePosition = relativePosition,
			MinimumParticleQuality = minimumParticleQuality,
			Duration = duration,
			DictID = _particleEffectsCounter++
		};
		_particleEffectsPlayQueue.Enqueue(item);
		return item.DictID;
	}

	private void StartParticleEffectInternal(ParticleEffectParameters parameter)
	{
		if (_lingeringRemovedParticleEffects.Contains(parameter.DictID))
		{
			return;
		}
		if (parameter.FollowGameObject == null || !parameter.FollowGameObject.activeInHierarchy)
		{
			Debug.Log("Attached game object went inactive before the effect was spawned");
			return;
		}
		ActiveParticleEffectContainer activeParticleEffectContainer = new ActiveParticleEffectContainer(parameter);
		if ((int)parameter.MinimumParticleQuality > Manager.prefs.particleQuality)
		{
			activeParticleEffectContainer.Status = ParticleEffectStatus.BlockedByQualitySetting;
		}
		else
		{
			AllocateAndStart(activeParticleEffectContainer);
			if (activeParticleEffectContainer.Instance == null)
			{
				return;
			}
		}
		_activeParticleEffectsMap.Add(parameter.DictID, activeParticleEffectContainer);
	}

	private void AllocateAndStart(ActiveParticleEffectContainer container)
	{
		ParticleEffectParameters parameters = container.Parameters;
		GameObject freeObject = Manager.memory.GetFreeObject(_particleEffectsPrefabMap[parameters.ParticleEffectID]);
		if (!(freeObject == null))
		{
			container.Instance = freeObject.GetComponent<PooledParticleSystem>();
			container.Instance.transform.position = parameters.FollowGameObject.transform.position + parameters.RelativePosition;
			container.Instance.UpdateSimulationSpace(Manager.camera.VolatileRenderAnchor);
			container.Instance.Play();
			container.Status = ParticleEffectStatus.Playing;
		}
	}

	public void StopParticleEffect(int dictID, bool clearExistingParticles = false)
	{
		if (_activeParticleEffectsMap.TryGetValue(dictID, out var value))
		{
			if (value.Status == ParticleEffectStatus.Playing)
			{
				value.Instance.Stop((!clearExistingParticles) ? ParticleSystemStopBehavior.StopEmitting : ParticleSystemStopBehavior.StopEmittingAndClear);
			}
			value.Status = ParticleEffectStatus.Stopped;
		}
		else
		{
			_lingeringRemovedParticleEffects.Add(dictID);
		}
	}

	private void UpdateParticleEffectsFromQualitySettings(PugParticleQuality newQuality)
	{
		foreach (KeyValuePair<int, ActiveParticleEffectContainer> item in _activeParticleEffectsMap)
		{
			_ = item.Key;
			ActiveParticleEffectContainer value = item.Value;
			if (value.Status == ParticleEffectStatus.Playing && value.Parameters.MinimumParticleQuality > newQuality)
			{
				value.Instance.Stop(ParticleSystemStopBehavior.StopEmittingAndClear);
				value.Instance.Free();
				value.Instance = null;
				value.Status = ParticleEffectStatus.BlockedByQualitySetting;
			}
			else if (value.Status == ParticleEffectStatus.BlockedByQualitySetting && value.Parameters.MinimumParticleQuality <= newQuality)
			{
				AllocateAndStart(value);
			}
		}
	}

	private static void SetWorldSpaceRecursive(GameObject gameObject)
	{
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
		if (component != null)
		{
			ParticleSystem.MainModule main = component.main;
			main.simulationSpace = ParticleSystemSimulationSpace.Custom;
			main.customSimulationSpace = Manager.camera.VolatileRenderAnchor;
		}
		foreach (Transform item in gameObject.transform)
		{
			SetWorldSpaceRecursive(item.gameObject);
		}
	}

	private ParticleSystem PlayParticleSystem(PuffID puff, Vector3 position)
	{
		ParticleSystem particleSystem = puffMap[(int)puff];
		SetWorldSpaceRecursive(particleSystem.gameObject);
		if (!particleSystem.isPlaying)
		{
			particleSystem.randomSeed = (uint)UnityEngine.Random.Range(0, int.MaxValue);
		}
		particleSystem.transform.position = position;
		particleSystem.Play(withChildren: true);
		return particleSystem;
	}

	private void FreeOldTileColliders()
	{
		float time = Time.time;
		NativeList<Vector2Int> nativeList = new NativeList<Vector2Int>(Allocator.Temp);
		foreach (KeyValuePair<Vector2Int, ParticleWallCollider> particleWallCollider in particleWallColliders)
		{
			if (time > particleWallCollider.Value.TimeToFree)
			{
				particleWallCollider.Value.Free();
				nativeList.Add(particleWallCollider.Key);
			}
		}
		for (int i = 0; i < nativeList.Length; i++)
		{
			particleWallColliders.Remove(nativeList[i]);
		}
		nativeList.Dispose();
	}

	private ParticleWallCollider GetExistingWallCollider(Vector2Int position)
	{
		if (particleWallColliders.TryGetValue(position, out var value))
		{
			return value;
		}
		return null;
	}

	public void WithTileColliders(Vector3 position)
	{
		FreeOldTileColliders();
		Vector2Int vector2Int = position.RoundToInt().To2D();
		bool flag = (new Vector3(vector2Int.x, 0f, vector2Int.y) - new Vector3(position.x, 0f, position.z)).sqrMagnitude > 0.1f;
		if (!flag)
		{
			ParticleWallCollider existingWallCollider = GetExistingWallCollider(vector2Int);
			if (existingWallCollider != null)
			{
				existingWallCollider.Free();
				particleWallColliders.Remove(vector2Int);
			}
		}
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		for (int i = 0; i < Direction.allEightClockwise.Length + (flag ? 1 : 0); i++)
		{
			Vector2Int vector2Int2 = vector2Int;
			if (i != Direction.allEightClockwise.Length)
			{
				Vector2Int vec2i = Direction.allEightClockwise[i].vec2i;
				vector2Int2 += vec2i;
			}
			int2 worldPosition = Manager.camera.RenderOrigo.ToInt2() + vector2Int2.ToInt2();
			foreach (TileInfo tile in tileLayerLookup.GetTiles(worldPosition))
			{
				if (!tile.tileType.IsBlockingParticlesTile())
				{
					continue;
				}
				ParticleWallCollider particleWallCollider = GetExistingWallCollider(vector2Int2);
				if (particleWallCollider == null)
				{
					particleWallCollider = Manager.memory.GetFreeComponent<ParticleWallCollider>();
					if (particleWallCollider == null)
					{
						return;
					}
					particleWallCollider.transform.position = vector2Int2.To3D();
					particleWallColliders.Add(vector2Int2, particleWallCollider);
				}
				particleWallCollider.TimeToFree = Time.time + 0.3f;
			}
		}
	}

	public void PlayScreenEdgePoof(Vector2 position)
	{
		ParticleSystem obj = puffMap[7];
		Vector2 vector = Manager.camera.gameCamera.GetOrthoViewportBounds().ProjectOnEdgeIfOutside(position);
		float z = Direction.FromVector(position - vector).angle + 90f;
		obj.transform.eulerAngles = new Vector3(0f, 0f, z);
		PlayPuff(PuffID.ScreenEdgePoof, vector, 30);
	}

	public Color GetGlowColor(ConditionID glowCondition)
	{
		GlowColor[] array = glowColors;
		foreach (GlowColor glowColor in array)
		{
			if (glowColor.glowCondition == glowCondition)
			{
				return glowColor.color;
			}
		}
		return Color.black;
	}

	public void EnablePlacedObjectEffectsAtPosition(float3 worldPosition, float duration = 5f)
	{
		_placedObjectEffectPositions.Add(worldPosition.RoundToInt2());
		_placedObjectEffectTimers.Add(duration);
	}

	public bool ShouldPlayPlacedObjectEffectAtPosition(float3 worldPosition)
	{
		return _placedObjectEffectPositions.Contains(worldPosition.RoundToInt2());
	}

	public void PlayScanEffect(Vector3 position, float circleWidth, float expandTime)
	{
		StopAnyScanEffect();
		scanCoroutine = StartCoroutine(ScanEffect_Coroutine(EntityMonoBehaviour.ToWorldFromRender(position), circleWidth, expandTime));
	}

	private void StopAnyScanEffect()
	{
		if (scanCoroutine != null)
		{
			SetScanEffectValues(0f, 0f, 0f, Vector3.zero);
			StopCoroutine(scanCoroutine);
			scanCoroutine = null;
		}
	}

	private IEnumerator ScanEffect_Coroutine(Vector3 position, float circleWidth, float expandTime)
	{
		TimerSimple timer = default(TimerSimple);
		timer.Start(expandTime);
		bool soundPlayed = false;
		while (!timer.isTimerElapsed)
		{
			if (!soundPlayed && timer.elapsedRatio > 0.1f)
			{
				soundPlayed = true;
				AudioManager.Sfx(SfxID.Bell, EntityMonoBehaviour.ToRenderFromWorld(position));
			}
			SetScanEffectValues(timer.elapsedRatio, 1f, circleWidth, position);
			yield return null;
		}
		float fadeOutTime = 0.5f;
		timer.Start(fadeOutTime);
		while (!timer.isTimerElapsed)
		{
			SetScanEffectValues(1f + timer.elapsedRatio * fadeOutTime / expandTime, timer.invElapsedRatio, circleWidth, position);
			yield return null;
		}
		SetScanEffectValues(0f, 0f, circleWidth, position);
		scanCoroutine = null;
	}

	public void SetScanEffectValues(float normDistance, float fade, float width, Vector3 position)
	{
		Shader.SetGlobalVector("scanPosition", position);
		Shader.SetGlobalFloat("scanDistance", normDistance);
		Shader.SetGlobalFloat("scanFade", fade);
		Shader.SetGlobalFloat("scanWidth", width);
	}

	public int GetUpgradeSfx(int upgradeLevel)
	{
		if (upgradeSounds.Count <= 0)
		{
			return 0;
		}
		int index = Mathf.Clamp(upgradeLevel / 5, 0, upgradeSounds.Count - 1);
		return upgradeSounds[index].value;
	}

	private void ResetWobbleShaderData()
	{
		for (int i = 0; i < 10; i++)
		{
			wobbleArray[i] = new Vector4(0f, 0f, 0f, 0f);
			flashArray[i] = new Vector4(0f, 0f, 0f, 0f);
		}
	}

	private void UploadWobbleShaderData()
	{
		Shader.SetGlobalVectorArray(WobbleArray, wobbleArray);
		Shader.SetGlobalVectorArray(FlashArray, flashArray);
	}

	public void WobbleAtPosition(Vector3Int position, float wobbleAmountMultiplier = 1f, bool isGround = false, bool flashRed = false, bool positionIsRealWorldSpace = false)
	{
		Vector3Int vector3Int = position;
		if (!positionIsRealWorldSpace)
		{
			position = EntityMonoBehaviour.ToWorldFromRender(position);
		}
		else
		{
			vector3Int = EntityMonoBehaviour.ToRenderFromWorld(position);
		}
		StartWobble(position, wobbleAmountMultiplier, isGround, flashRed);
		if (isGround)
		{
			WaterSim.AddImpulse(vector3Int, 1f, wobbleAmountMultiplier);
		}
	}

	private void StartWobble(Vector3Int position, float wobbleAmountMultiplier = 1f, bool isGround = false, bool flashRed = false)
	{
		if (s_activeWobbles.TryGetValue(position, out var value))
		{
			if (Time.time - value.timestamp < 0.2f && value.flashRed && !flashRed)
			{
				return;
			}
			AbortWobbleInstance(value);
		}
		int num = wobbleCounter;
		wobbleCounter = (wobbleCounter + 1) % 10;
		Coroutine coroutine = StartCoroutine(WobbleSequence(position, wobbleAmountMultiplier, num, isGround, flashRed));
		s_activeWobbles.Add(position, new WobbleInstance
		{
			position = position,
			coroutine = coroutine,
			flashRed = flashRed,
			timestamp = Time.time,
			arrayIndex = num
		});
	}

	private void AbortWobbleInstance(WobbleInstance wobbleInstance)
	{
		wobbleArray[wobbleInstance.arrayIndex] = Vector4.zero;
		flashArray[wobbleInstance.arrayIndex] = Vector4.zero;
		StopCoroutine(wobbleInstance.coroutine);
		s_activeWobbles.Remove(wobbleInstance.position);
	}

	private IEnumerator WobbleSequence(Vector3Int position, float wobbleAmountMultiplier, int index, bool isGround, bool flashRed = false)
	{
		float amount = UnityEngine.Random.Range(0.15f, 0.2f) * wobbleAmountMultiplier;
		Vector4 wobbleElement = new Vector4(position.x, isGround ? (-1) : 0, position.z, 0.5f);
		wobbleArray[index] = wobbleElement;
		if (flashRed)
		{
			flashArray[index] = wobbleElement;
		}
		TimerSimple timer = new TimerSimple(0.2f);
		timer.Start();
		while (!timer.isTimerElapsed)
		{
			float w = wobbleCurve.Evaluate(timer.elapsedRatio) * amount;
			wobbleArray[index] = new Vector4(wobbleElement.x, wobbleElement.y, wobbleElement.z, w);
			if (flashRed)
			{
				float w2 = flashCurve.Evaluate(timer.elapsedRatio);
				flashArray[index] = new Vector4(wobbleElement.x, wobbleElement.y, wobbleElement.z, w2);
			}
			yield return null;
		}
		wobbleArray[index] = new Vector4(wobbleElement.x, wobbleElement.y, wobbleElement.z, 0f);
		if (flashRed)
		{
			flashArray[index] = new Vector4(wobbleElement.x, wobbleElement.y, wobbleElement.z, 0f);
		}
		s_activeWobbles.Remove(position);
	}

	public void PlayDestroyTileEffect(Vector3 pos, TileType tileType, int tileSet, int wallTileset)
	{
		if ((tileType != TileType.wall && tileType != TileType.ground && tileType != TileType.bigRoot && tileType != TileType.floor && tileType != TileType.rug && tileType != TileType.circuitPlate && tileType != TileType.chrysalis && tileType != TileType.groundSlime && tileType != TileType.bridge && tileType != TileType.ore && tileType != TileType.ancientCrystal && tileType != TileType.fence && tileType != TileType.rail && tileType != TileType.litFloor && tileType != TileType.looseFlooring && tileType != TileType.thinWall) || Manager.main.player == null)
		{
			return;
		}
		for (int num = destroyTileEffectTimers.Count - 1; num >= 0; num--)
		{
			if (destroyTileEffectTimers[num].isTimerElapsed)
			{
				destroyTileEffectTimers.RemoveAtSwapBack(num);
				destroyTileEffectTimerPositions.RemoveAtSwapBack(num);
			}
		}
		Vector3Int item = EntityMonoBehaviour.ToWorldFromRender(pos).RoundToInt();
		if (destroyTileEffectTimerPositions.Contains(item))
		{
			return;
		}
		bool isGround = tileType == TileType.ground;
		if (tileType == TileType.wall || tileType == TileType.ground || tileType == TileType.ore || tileType == TileType.ancientCrystal || tileType == TileType.fence || tileType == TileType.thinWall)
		{
			WobbleAtPosition(pos.RoundToInt(), 1f, isGround);
		}
		bool flag = Manager.prefs.particleQuality == 0;
		if (flag)
		{
			destroyEffectSpamCounter++;
			bool flag2 = destroyEffectSpamCounter % 3 == 0;
			if (!(!destroyEffectCooldown.isRunning || destroyEffectCooldown.isTimerElapsed || flag2))
			{
				return;
			}
			destroyEffectCooldown.Start();
		}
		if (tileType == TileType.bridge)
		{
			WaterSim.AddImpulse(pos, 1f, 2f);
		}
		if ((Manager.main.player.transform.position - pos).sqrMagnitude > 200f)
		{
			return;
		}
		TimerSimple item2 = new TimerSimple(1.2f);
		item2.Start();
		destroyTileEffectTimers.Add(item2);
		destroyTileEffectTimerPositions.Add(item);
		ObjectInfo objectInfo = (tileType.IsContainedResource() ? PugDatabase.TryGetTileItemInfo(TileType.wall, wallTileset) : PugDatabase.TryGetTileItemInfo(tileType, tileSet));
		if (objectInfo == null)
		{
			return;
		}
		ObjectDataCD objectData = new ObjectDataCD
		{
			objectID = objectInfo.objectID,
			variation = objectInfo.variation
		};
		if (PugDatabase.HasComponent<TileEffectCD>(objectData))
		{
			TileEffectCD component = PugDatabase.GetComponent<TileEffectCD>(objectData);
			bool playOnGamepad = EffectEventExtensions.ShouldPlayAudioAndRumbleOnGamepad(pos);
			if (component.sfxTableDestroyId != 0)
			{
				AudioManager.Sfx(component.sfxTableDestroyId, pos, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad, null, forceStackable: true);
			}
			else
			{
				AudioManager.Sfx(SfxTableID.defaultTileDestroy, pos, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad, null, forceStackable: true);
			}
			if (PugDatabase.HasComponent<TileEffectPuffsBuffer>(objectData))
			{
				foreach (TileEffectPuffsBuffer item3 in PugDatabase.GetBuffer<TileEffectPuffsBuffer>(objectData))
				{
					PuffParams destroyPuff = item3.destroyPuff;
					destroyPuff.particleCount = (flag ? math.min(10, destroyPuff.particleCount) : destroyPuff.particleCount);
					PlayPuff(destroyPuff, pos);
				}
				WithTileColliders(pos);
			}
			else
			{
				PlayPuff(PuffID.DirtBlockDust, pos, 4);
				PlayPuff(PuffID.DirtBlockDebrisBox, pos, flag ? 10 : 75);
				WithTileColliders(pos);
			}
		}
		if (tileType.IsContainedResource())
		{
			AudioManager.Sfx(SfxTableID.oreHit, pos, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: true);
		}
	}

	public void PlayPuff(int puffId, Vector3 position, int particleCount = 10)
	{
		PlayPuff((PuffID)puffId, position, particleCount);
	}

	void IEffects.PlayTempSprite(int tempSpriteId, Vector3 position, float scale, float lifetime, float positionDev, bool looping)
	{
		PlayTempSprite(tempSpriteId, position, scale, lifetime, positionDev, looping);
	}
}
