using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.World
{
	[CreateAssetMenu(fileName = "Handmade Tile Generator", menuName = "Flotsam/World/Generator/Handmade")]
	public class HandmadeTileGenerator : TileGeneratorBase
	{
		[Serializable]
		public class Townheart
		{
			[SerializeField]
			internal Vector3 Position;

			[SerializeField]
			internal float SpawnRadius;

			[Header("World Editor References")]
			[SerializeField]
			internal GameplaySettings GameplaySettings;

			[SerializeField]
			internal Sprite EditorIcon;

			public Vector3 GetPosition()
			{
				return Position + (UnityEngine.Random.insideUnitCircle * SpawnRadius).Vector3TopDown();
			}
		}

		[Serializable]
		public class Landmark
		{
			public enum SpawnMode
			{
				RegionProfile = 0,
				LandmarkBehaviourProvider = 1
			}

			[Flags]
			public enum Size
			{
				Small = 8,
				Medium = 0x40,
				Large = 0x200
			}

			[Flags]
			public enum ActionFlags
			{
				RevealMap = 1,
				Salvage = 4,
				RescueDrifter = 8,
				RescueSeagull = 0x10,
				All = 0x1F
			}

			[Flags]
			public enum ResourceFlags
			{
				Water = 1,
				Food = 4,
				Crops = 8,
				Engine = 0x10,
				SolarPanels = 0x20,
				Other = 0x20000000,
				All = 0x3FFFFFFF
			}

			[SerializeField]
			private SpawnMode _spawnMode = SpawnMode.LandmarkBehaviourProvider;

			[SerializeField]
			[InterfaceReference(typeof(ILandmarkBehaviourProvider))]
			[FormerlySerializedAs("LandmarkBehaviour")]
			[ConditionalEnumHide("_spawnMode", 1, false, HideInInspector = true)]
			internal ScriptableObject _landmarkBehaviourProvider;

			[Space]
			[SerializeField]
			internal Vector3 Position;

			[SerializeField]
			internal Quaternion Rotation = Quaternion.identity;

			[SerializeField]
			internal ScoutingState ScoutingState;

			[Header("World Editor Settings")]
			[SerializeField]
			internal bool ShowPreview;

			public ILandmarkBehaviourProvider LandmarkBehaviourProvider => _landmarkBehaviourProvider as ILandmarkBehaviourProvider;

			public bool IsInteractable()
			{
				if (_spawnMode == SpawnMode.LandmarkBehaviourProvider)
				{
					return LandmarkBehaviourProvider.ReturnIsInteractable();
				}
				return true;
			}

			public LandmarkBehaviour ReturnLandmarkBehaviour()
			{
				if (_spawnMode == SpawnMode.LandmarkBehaviourProvider)
				{
					return LandmarkBehaviourProvider.ReturnLandmarkBehaviour(WorldRegionType.Any);
				}
				return null;
			}
		}

		[Serializable]
		internal class PointOfInterest
		{
			[SerializeField]
			internal PointOfInterestProperties PointOfInterestProperties;

			[SerializeField]
			internal Vector3 Position;
		}

		[Serializable]
		internal class Road
		{
			[SerializeField]
			internal string Name;

			[SerializeField]
			internal Color Color;

			[SerializeField]
			internal Vector2[] Nodes;
		}

		[Serializable]
		internal class Region
		{
			[SerializeField]
			internal WorldRegionType Type;

			[SerializeField]
			internal string Name;

			[SerializeField]
			internal Color Color;

			[SerializeField]
			internal List<Vector2> Polygon;
		}

		[SerializeField]
		private Townheart _townheart;

		[SerializeField]
		private List<Landmark> _landmarks;

		[SerializeField]
		private List<PointOfInterest> _pointsOfInterest;

		[SerializeField]
		private List<Road> _roads;

		[SerializeField]
		private List<Region> _regions;

		[SerializeField]
		private Vector2 _minimumSize = new Vector2(10240f, 10240f);

		[SerializeField]
		[Range(0.1f, 10f)]
		private float _scale = 1f;

		public override Rect MinimumBounds => new Rect(-(_minimumSize / 2f), _minimumSize / 2f);

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
			}
		}

		public override void Initialize(bool isStartingTile)
		{
			if (_scale < 1f)
			{
				_scale = 1f;
			}
		}

		public override IEnumerator Generate(IWorldTile worldTile)
		{
			GenerateRegionsAndRoads(worldTile);
			foreach (Landmark landmark in _landmarks)
			{
				worldTile.AddLandmarkSpawner(new LandmarkSpawner(landmark.ReturnLandmarkBehaviour(), landmark.Position * _scale, landmark.Rotation));
			}
			foreach (PointOfInterest item in _pointsOfInterest)
			{
				worldTile.AddPointOfInterestSpawner(new PointOfInterestSpawner(item.PointOfInterestProperties, item.Position * _scale));
			}
			yield break;
		}

		public override void Restore(IWorldTile worldTile)
		{
			GenerateRegionsAndRoads(worldTile);
			foreach (Landmark landmark in _landmarks)
			{
				if (!landmark.IsInteractable())
				{
					worldTile.AddLandmarkSpawner(new LandmarkSpawner(landmark.ReturnLandmarkBehaviour(), landmark.Position * _scale, landmark.Rotation));
				}
			}
		}

		private void GenerateRegionsAndRoads(IWorldTile worldTile)
		{
			foreach (Region region in _regions)
			{
				if (2 < region.Polygon.Count)
				{
					worldTile.AddRegion(new HandMadeWorldRegion(region));
				}
			}
			foreach (Road road in _roads)
			{
				if (1 < road.Nodes.Length)
				{
					worldTile.AddRoadSpawner(new RoadSpawner(road));
				}
			}
		}

		public override bool TryReturnTownheartStartPosition(out Vector3 position)
		{
			position = _townheart.Position;
			return true;
		}
	}
}
