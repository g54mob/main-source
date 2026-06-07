using System;
using System.Collections.Generic;
using PajamaLlama;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Serialization;

public class WorldMapTownheart : SceneBehaviour
{
	[Serializable]
	private struct Visual
	{
		public BuildableProperties BuildableProperties;

		public GameObject GameObject;

		public Animator Animator;
	}

	[SerializeField]
	[NamedArrayElement(new string[] { "BuildableProperties" })]
	private Visual[] _visuals;

	[SerializeField]
	[FormerlySerializedAs("DirectionIndicator")]
	private Transform _directionIndicator;

	[SerializeField]
	private WorldMapConstruction _worldMapConstruction;

	[Range(0.1f, 1f)]
	[SerializeField]
	private float _physicsPositionLerp = 0.9f;

	[SerializeField]
	private Transform _movementRangeTransform;

	[SerializeField]
	private GameObject _ozoneShield;

	[Header("Audio")]
	public FMODEventEmitter FMODEventEmitter;

	[FormerlySerializedAs("_engineAudio")]
	public AudioClipProperties EngineAudio;

	[FormerlySerializedAs("_movingAudio")]
	public AudioClipProperties MovingAudio;

	private Visual _visual;

	private Engine _engine;

	private List<WorldMapConstruction> _constructions;

	private WorldMapTownheartPhycis2D _physics;

	private Vector3 _targetPosition;

	private Quaternion _targetRotation;

	private ObjectPool<WorldMapConstruction> _worldMapConstructionPool;

	public Transform DirectionIndicator => _directionIndicator;

	public Vector3 Position { get; private set; }

	public bool Initialized { get; private set; }

	public bool IsMoving { get; private set; }

	public bool DidMove { get; private set; }

	private void OnEnable()
	{
		OnEnergyUpdate();
		_ozoneShield.SetActive(GameManager.WorldManager.World.HasEndTile);
	}

	private void LateUpdate()
	{
		float num = Engine.ReturnRange() * 2f;
		_movementRangeTransform.localScale = new Vector3(num, 1f, num);
		if (!(1f <= _physicsPositionLerp) && (!_targetPosition.Approximately(Position) || !_targetRotation.eulerAngles.Approximately(base.transform.rotation.eulerAngles)))
		{
			SetPositionAndRotation(Vector3.Slerp(Position, _targetPosition, _physicsPositionLerp), Quaternion.Slerp(base.transform.rotation, _targetRotation, _physicsPositionLerp));
		}
	}

	private void OnDisable()
	{
		FMODEventEmitter.Stop();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyConsumed, OnEnergyUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyProduced, OnEnergyUpdate);
	}

	public void Initialize(Engine engine, WorldMapTownheartPhycis2D physics = null)
	{
		_engine = engine;
		_physics = physics;
		InitializeVisual();
		GameEventDispatcher.AddListener(GameEventType.EnergyConsumed, OnEnergyUpdate);
		GameEventDispatcher.AddListener(GameEventType.EnergyProduced, OnEnergyUpdate);
		DidMove = false;
		Position = (_targetPosition = GameManager.WorldManager.World.TownheartWorldPosition);
		_targetRotation = GameManager.WorldManager.World.TownheartRotation;
		base.transform.SetPositionAndRotation(Position, _targetRotation);
		if ((bool)_physics)
		{
			InitializeWorldMapConstructions();
		}
		Initialized = true;
	}

	public void Teleport(Vector3 position, Quaternion rotation)
	{
		if (_physics != null)
		{
			_physics.SetPositionAndRotation(position, rotation);
		}
		_targetPosition = position;
		_targetRotation = rotation;
		SetPositionAndRotation(position, rotation);
	}

	private void OnEnergyUpdate(GameEvent gameEvent = null)
	{
		_visual.Animator.SetBool("IsBatteryEmpty", _engine.EnergyGrid.IsEmpty || Engine.IsCoolingDown);
	}

	public void OnStartMove()
	{
		if (!IsMoving)
		{
			_visual.Animator.SetBool("IsMoving", value: true);
			FMODEventEmitter.StopAllAndPlay(MovingAudio);
			IsMoving = true;
			DidMove = true;
		}
	}

	public void OnEndMove()
	{
		if (IsMoving)
		{
			_visual.Animator.SetBool("IsMoving", value: false);
			FMODEventEmitter.StopAllAndPlay(EngineAudio);
			IsMoving = false;
		}
	}

	private void InitializeVisual()
	{
		bool flag = false;
		if ((bool)Construction.Townheart)
		{
			Visual[] visuals = _visuals;
			for (int i = 0; i < visuals.Length; i++)
			{
				Visual visual = visuals[i];
				if (visual.BuildableProperties == Construction.Townheart.Buildable.Properties)
				{
					_visual = visual;
					_visual.GameObject.SetActive(value: true);
					flag = true;
				}
				else
				{
					visual.GameObject.SetActive(value: false);
				}
			}
		}
		if (!flag)
		{
			_visual = _visuals[0];
			_visual.GameObject.SetActive(value: true);
		}
	}

	private void InitializeWorldMapConstructions()
	{
		_worldMapConstructionPool = new ObjectPool<WorldMapConstruction>(() => UnityEngine.Object.Instantiate(_worldMapConstruction, base.transform));
		_constructions = new List<WorldMapConstruction>();
		if (Community.PlayerCommunity != null)
		{
			foreach (Construction construction in Community.PlayerCommunity.Constructions)
			{
				AddConstruction(construction);
			}
		}
		GameEventDispatcher.AddListener(GameEventType.ConstructionAddedToCommunity, OnConstructionAddedToCommunity);
		GameEventDispatcher.AddListener(GameEventType.ConstructionRemovedFromCommunity, OnConstructionRemovedFromCommunity);
	}

	private void OnConstructionAddedToCommunity(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && buildableEvent.Buildable.TryReturnBuildableExtendable<Construction>(out var buildableExtendable) && buildableEvent.Buildable.Community == Community.PlayerCommunity)
		{
			AddConstruction(buildableExtendable);
		}
	}

	private void OnConstructionRemovedFromCommunity(GameEvent gameEvent)
	{
		if (!(gameEvent is BuildableEvent buildableEvent) || buildableEvent.Buildable.Community != Community.PlayerCommunity)
		{
			return;
		}
		int count = _constructions.Count;
		while (0 < count--)
		{
			WorldMapConstruction worldMapConstruction = _constructions[count];
			if (worldMapConstruction.Construction.Buildable == buildableEvent.Buildable)
			{
				_physics.RemoveConstruction(worldMapConstruction);
				worldMapConstruction.gameObject.SetActive(value: false);
				_worldMapConstructionPool.Return(worldMapConstruction);
				_constructions.RemoveAt(count);
				break;
			}
		}
	}

	private void AddConstruction(Construction constructionToAdd)
	{
		foreach (WorldMapConstruction construction in _constructions)
		{
			if (construction.Construction == constructionToAdd)
			{
				return;
			}
		}
		constructionToAdd.Buildable.OutlinePolygon.Update();
		WorldMapConstruction worldMapConstruction = _worldMapConstructionPool.Get();
		worldMapConstruction.Initialize(constructionToAdd);
		worldMapConstruction.gameObject.SetActive(value: true);
		_constructions.Add(worldMapConstruction);
		_physics.AddConstruction(worldMapConstruction);
	}

	public void SetTargetPositionAndRotation(Vector3 position, Quaternion rotation)
	{
		_targetPosition = position;
		_targetRotation = rotation;
		if (_physicsPositionLerp == 1f)
		{
			SetPositionAndRotation(position, rotation);
		}
	}

	private void SetPositionAndRotation(Vector3 position, Quaternion rotation)
	{
		Transform obj = base.transform;
		Vector3 position2 = (Position = position);
		obj.SetPositionAndRotation(position2, rotation);
	}
}
