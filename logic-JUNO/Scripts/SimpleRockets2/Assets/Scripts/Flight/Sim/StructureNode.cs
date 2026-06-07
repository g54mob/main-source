using System;
using System.Collections.Generic;
using System.Reflection;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public class StructureNode : Node, IGameViewObject, ICameraTarget, IStructureNode, IStationaryNode
	{
		private IGameView _gameView;

		private int _lod = -1;

		private List<double> _lodSquaredDistances = new List<double>();

		private Vector3d _position;

		private Transform _transform;

		public Transform CameraTarget => _transform;

		public Vector3 CameraTargetPlanetPosition => (Vector3)Position;

		public int CurrentLod => _lod;

		public StructureNodeData Data { get; }

		public bool Enabled { get; set; } = true;

		public Vector3 FramePosition => _transform.position;

		public GameObject GameObject
		{
			get
			{
				if (!IsLoadedInGameView)
				{
					return null;
				}
				return _transform.gameObject;
			}
		}

		public override float GameViewLoadDistance => (float)Data.GameViewLoadDistance;

		public string GameViewName => Name;

		public override IGameViewObject GameViewObject => this;

		Guid IStationaryNode.Id => Data.Id;

		public Guid Id => Data.Id;

		public bool IsLoadedInGameView => _transform != null;

		public bool IsPhysicsEnabled { get; private set; }

		public string MapViewIcon { get; private set; }

		public Color MapViewIconColor { get; set; } = Color.white;

		public string Name => Data.Name;

		IOrbitNode ICameraTarget.OrbitNode => null;

		public override Vector3d Position => _position;

		public string PrefabName { get; private set; }

		public string StructureTypeName => "Structure";

		public Vector3d SurfacePosition { get; private set; }

		public Quaterniond SurfaceRotation { get; private set; }

		public Vector3 TargetRotation => GameObject.transform.eulerAngles;

		public Transform Transform => _transform;

		public event GameViewObjectHandler LoadedIntoGameView;

		public event GameViewObjectHandler UnloadedFromGameView;

		public event GameViewObjectHandler UnloadingFromGameView;

		public StructureNode(StructureNodeData structureNodeData, IPlanetNode planetNode, string icon = null)
		{
			Data = structureNodeData;
			MapViewIcon = (string.IsNullOrEmpty(icon) ? "StructureNode" : icon);
			PrefabName = structureNodeData.PrefabPath;
			SetPosition(structureNodeData, planetNode, AltitudeType.AboveSeaLevel);
		}

		public static void FixNegativeBoxColliderScales(GameObject go)
		{
			BoxCollider[] componentsInChildren = go.GetComponentsInChildren<BoxCollider>();
			foreach (BoxCollider boxCollider in componentsInChildren)
			{
				Vector3 lossyScale = boxCollider.transform.lossyScale;
				Vector3 one = Vector3.one;
				Vector3 size = boxCollider.size;
				bool flag = false;
				if (lossyScale.x * size.x < 0f)
				{
					one.x = 0f - one.x;
					flag = true;
				}
				if (lossyScale.y * size.y < 0f)
				{
					one.y = 0f - one.y;
					flag = true;
				}
				if (lossyScale.z * size.z < 0f)
				{
					one.z = 0f - one.z;
					flag = true;
				}
				if (flag)
				{
					boxCollider.size = Vector3.Scale(size, one);
				}
			}
		}

		public void CreateGameObjects()
		{
			if (_gameView != null)
			{
				if (_transform != null)
				{
					DestroyGameObjects();
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(PrefabName)) as GameObject;
				StructureGameObjectScript structureGameObjectScript = gameObject.AddMissingComponent<StructureGameObjectScript>();
				structureGameObjectScript.StructureNode = this;
				structureGameObjectScript.SubStructure = null;
				_transform = gameObject.transform;
				_transform.localScale = Data.LocalScale;
				ResetLevelOfDetail();
				UpdateSubStructureLod(0);
			}
			RecalculateFrameState(_gameView.ReferenceFrame);
		}

		public void DestroyStructure()
		{
			if (!base.IsDestroyed)
			{
				base.IsDestroyed = true;
				try
				{
					RaiseDestroyedEvent();
					return;
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					return;
				}
			}
			Debug.LogError("Attempting to destroy a structure that has already been destroyed");
		}

		public override void FlightUpdate(double elapsedTime, double currentTime)
		{
			_position = base.Parent.SurfaceVectorToPlanetVector(SurfacePosition);
			if (_gameView != null && !_gameView.ReferenceFrame.IsSurfaceLocked)
			{
				RecalculateFrameState(_gameView.ReferenceFrame);
			}
		}

		public override void Initialize()
		{
			_position = base.Parent.SurfaceVectorToPlanetVector(SurfacePosition);
		}

		public Transform LoadIntoGameView(IGameView gameView)
		{
			_gameView = gameView;
			CreateGameObjects();
			this.LoadedIntoGameView?.Invoke(this);
			return _transform;
		}

		public void OnPositionChanged()
		{
			if (Data.ElevationType != AltitudeType.AboveSeaLevel)
			{
				SetPosition(Data, base.Parent, Data.ElevationType);
			}
		}

		void IGameViewObject.OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
			RecalculateFrameState(referenceFrame);
		}

		public void OnTerrainDataLoaded()
		{
			if (Data.ElevationType != AltitudeType.AboveSeaLevel)
			{
				SetPosition(Data, base.Parent, Data.ElevationType);
			}
		}

		public void OnTerrainDataUnloaded()
		{
		}

		public void RecalculateFrameState(IReferenceFrame referenceFrame)
		{
			if (_transform != null)
			{
				_transform.SetPositionAndRotation(referenceFrame.PlanetToFramePosition(Position), referenceFrame.PlanetToFrameRotation(base.Parent.Rotation * SurfaceRotation));
			}
		}

		public void ResetLevelOfDetail()
		{
			RefreshLodDistances();
			_lod = -1;
		}

		public void SetPhysicsEnabled(bool enabled, PhysicsChangeReason reason)
		{
			IsPhysicsEnabled = enabled;
		}

		public void UnloadFromGameView(bool flightEnd)
		{
			this.UnloadingFromGameView?.Invoke(this);
			DestroyGameObjects();
			this.UnloadedFromGameView?.Invoke(this);
			_gameView = null;
			_lod = -1;
		}

		public void UpdateLevelOfDetail(double distanceSquared)
		{
			if (_lodSquaredDistances != null)
			{
				int lod = _lodSquaredDistances.Count;
				for (int i = 0; i < _lodSquaredDistances.Count; i++)
				{
					if (distanceSquared > _lodSquaredDistances[i])
					{
						lod = i;
						break;
					}
				}
				UpdateSubStructureLod(lod);
			}
			else
			{
				UpdateSubStructureLod(0);
			}
		}

		private static void UnloadSubstructureGameObjects(SubStructure subStructure, bool destroyGameObject)
		{
			if (destroyGameObject && subStructure.LoadedGameObject != null)
			{
				UnityEngine.Object.Destroy(subStructure.LoadedGameObject);
			}
			subStructure.OnGameObjectUnloaded();
			foreach (SubStructure subStructure2 in subStructure.SubStructures)
			{
				UnloadSubstructureGameObjects(subStructure2, destroyGameObject: false);
			}
		}

		private void DestroyGameObjects()
		{
			foreach (SubStructure subStructure in Data.SubStructures)
			{
				UnloadSubstructureGameObjects(subStructure, destroyGameObject: false);
			}
			if (_transform != null)
			{
				UnityEngine.Object.Destroy(_transform.gameObject);
				_transform = null;
			}
		}

		private void InstantiateSubStructures(Transform parent, IEnumerable<SubStructure> subStructures, int lod, bool insideRigidBody)
		{
			TerrainQualitySettings.StructureDetailQuality structureDetailQuality = (Game.InPlanetStudioScene ? TerrainQualitySettings.StructureDetailQuality.High : Game.Instance.QualitySettings.Terrain.StructureDetail.Value);
			foreach (SubStructure subStructure in subStructures)
			{
				try
				{
					if (structureDetailQuality < subStructure.RequiredQuality)
					{
						continue;
					}
					if (subStructure.LevelOfDetail <= lod || insideRigidBody)
					{
						bool flag = false;
						if (subStructure.LoadedGameObject == null)
						{
							GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(subStructure.PrefabPath)) as GameObject;
							StructureGameObjectScript structureGameObjectScript = gameObject.AddMissingComponent<StructureGameObjectScript>();
							structureGameObjectScript.StructureNode = null;
							structureGameObjectScript.SubStructure = subStructure;
							subStructure.OnGameObjectLoaded(gameObject);
							Transform transform = gameObject.transform;
							transform.SetParent(parent, worldPositionStays: false);
							transform.SetLocalPositionAndRotation(subStructure.LocalPosition, Quaternion.Euler(subStructure.LocalRotation));
							transform.localScale = subStructure.LocalScale;
							subStructure.UpdateDynamicMaterials();
							FixNegativeBoxColliderScales(subStructure.LoadedGameObject);
							if (Game.InFlightScene && subStructure.AngularVelocity.HasValue)
							{
								gameObject.AddComponent<SubStructureRotateScript>().Initialize(subStructure.AngularVelocity.Value);
							}
							if (subStructure.CameraCollision == SubStructure.CameraCollisionType.Collide)
							{
								Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 29);
							}
							else if (subStructure.CameraCollision == SubStructure.CameraCollisionType.NoCollide)
							{
								Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 26);
							}
							flag = true;
						}
						bool insideRigidBody2 = insideRigidBody || subStructure.Mass > 0.0;
						InstantiateSubStructures(subStructure.LoadedGameObject.transform, subStructure.SubStructures, lod, insideRigidBody2);
						if (Game.InFlightScene && flag && !insideRigidBody && subStructure.Mass > 0.0)
						{
							subStructure.LoadedGameObject.AddComponent<SubStructureRigidBodyScript>().Initialize(subStructure);
						}
					}
					else if (subStructure.LoadedGameObject != null)
					{
						UnloadSubstructureGameObjects(subStructure, destroyGameObject: true);
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Failed to load sub-structure: " + subStructure.PrefabPath + ". Exception: " + ex.ToString());
				}
			}
		}

		private void RefreshLodDistances()
		{
			_lodSquaredDistances.Clear();
			double[] lodDistanceScalars = Data.LodDistanceScalars;
			for (int i = 0; i < lodDistanceScalars.Length; i++)
			{
				double num = lodDistanceScalars[i] * Data.GameViewLoadDistance;
				_lodSquaredDistances.Add(num * num);
			}
		}

		private void SetPosition(StructureNodeData data, IPlanetNode planetNode, AltitudeType altitudeType)
		{
			SurfacePosition = planetNode.GetSurfacePosition(data.Latitude * 0.01745329238474369, data.Longitude * 0.01745329238474369, altitudeType, data.Elevation);
			SurfaceRotation = data.Rotation;
			if (base.Parent != null)
			{
				_position = base.Parent.SurfaceVectorToPlanetVector(SurfacePosition);
			}
		}

		private void UpdateSubStructureLod(int lod)
		{
			if (_lod != lod)
			{
				InstantiateSubStructures(_transform, Data.SubStructures, lod, insideRigidBody: false);
				_lod = lod;
			}
		}
	}
}
