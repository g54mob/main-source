using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

namespace PugWorldGen
{
	[CreateAssetMenu(fileName = "SpawnTemplate", menuName = "Pug/WorldGen/Spawn Template", order = 2)]
	public class SpawnTemplate : ScriptableObject
	{
		[Serializable]
		public class SpawnEntry
		{
			[SerializeField]
			private bool show;

			[SerializeField]
			private bool objectDataFoldout;

			[SerializeField]
			private bool algorithmFoldout;

			public bool disable;

			public ObjectID objectID;

			[MinMax(0f, 1000f)]
			public Pug.UnityExtensions.RangeInt objectAmount = new Pug.UnityExtensions.RangeInt
			{
				min = 1,
				max = 1
			};

			public bool advancedVariationControl;

			[MinMax(0f, 10f)]
			public Pug.UnityExtensions.RangeInt variation;

			public List<ValueWithWeight<int>> weightedVariations;

			[Range(0f, 1f)]
			public float chanceToAppearAtAll = 1f;

			public List<ObjectID> canSpawnOn = new List<ObjectID>();

			public List<ObjectID> canSpawnNextTo = new List<ObjectID>();

			public bool cannotSpawnOnAnyPreviousObject;

			public List<ObjectID> canNotSpawnOn = new List<ObjectID>();

			public LootTableID containLoot;

			public SpawnAlgorithm algorithm = SpawnAlgorithm.Circle;

			public PlacementAlignment placementAlignement;

			public bool randomPlacement;

			[Range(0f, 1f)]
			public float randomChance = 1f;

			public Pug.UnityExtensions.Range shapeSize = new Pug.UnityExtensions.Range
			{
				min = 1f,
				max = 1f
			};

			[MinMax(1f, 100f)]
			public Pug.UnityExtensions.RangeInt amount = new Pug.UnityExtensions.RangeInt
			{
				min = 1,
				max = 1
			};

			public Pug.UnityExtensions.Range placementRadius;

			public bool rotateTowardsCenter;

			[MinMax(0f, 360f)]
			public Pug.UnityExtensions.Range tilt;

			[MinMax(0f, 1f)]
			public Pug.UnityExtensions.Range oblongness;

			public string helpNotes;
		}

		[HideInInspector]
		public Unity.Entities.Hash128 guid;

		[Range(0f, 10f)]
		public float shapeAmplitude;

		[Range(0.1f, 10f)]
		public float shapeFrequency = 1f;

		public List<SpawnEntry> spawnEntries;

		public void UpdateGuid()
		{
			guid = PugRandom.GenerateGuid();
		}
	}
}
