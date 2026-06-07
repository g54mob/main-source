using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class MissilePartPrefabs : ScriptableObject
	{
		public enum AttachmentType
		{
			Center = 0,
			Radial = 1
		}

		[Serializable]
		public class PartPrefab
		{
			public float areaMultiplier;

			public AttachmentType attachmentType = AttachmentType.Radial;

			public float massMultiplier;

			public string name;

			public GameObject prefab;

			[NonSerialized]
			public string Id;
		}

		[Serializable]
		public class PartPrefabCategory
		{
			public Vector3 baseSize = new Vector3(0.25f, 0.25f, 0.25f);

			public PartPrefabOptions options;

			public PartPrefab[] prefabs;
		}

		[Serializable]
		public class PartPrefabOptions
		{
			public float maxHeight = 2.5f;

			public float maxLength = 2.5f;

			public float maxRadialOffset = 2f;

			public float maxSize = 2.5f;

			public float maxThickness = 2.5f;

			public float minHeight = 0.25f;

			public float minLength = 0.25f;

			public float minSize = 0.25f;

			public float minThickness = 0.25f;

			public int[] symmetries = new int[3] { -2, 1, 2 };
		}

		public PartPrefabCategory fins;

		[FormerlySerializedAs("greeble")]
		public PartPrefabCategory greebleMissile;

		public PartPrefabCategory greebleFin;

		public PartPrefabCategory inlets;

		public PartPrefabCategory wings;

		public void Initialize()
		{
			PartPrefab[] prefabs = fins.prefabs;
			foreach (PartPrefab obj in prefabs)
			{
				obj.Id = obj.prefab.name;
			}
			prefabs = greebleMissile.prefabs;
			foreach (PartPrefab obj2 in prefabs)
			{
				obj2.Id = obj2.prefab.name;
			}
			prefabs = greebleFin.prefabs;
			foreach (PartPrefab obj3 in prefabs)
			{
				obj3.Id = obj3.prefab.name;
			}
			prefabs = inlets.prefabs;
			foreach (PartPrefab obj4 in prefabs)
			{
				obj4.Id = obj4.prefab.name;
			}
			prefabs = wings.prefabs;
			foreach (PartPrefab obj5 in prefabs)
			{
				obj5.Id = obj5.prefab.name;
			}
			List<PartPrefab> source = (from r in fins.prefabs
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, PartPrefab> g) => g).ToList();
			if (source.Any())
			{
				Debug.LogWarning("Duplicate fin IDs found: " + string.Join(", ", source.Select((PartPrefab r) => r.Id).Distinct()));
			}
		}
	}
}
