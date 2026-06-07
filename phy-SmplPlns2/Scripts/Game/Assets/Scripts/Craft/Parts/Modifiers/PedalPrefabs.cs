using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PedalPrefabs : ScriptableObject
	{
		[Serializable]
		public class PedalPrefab
		{
			public string name;

			public string pivotPath;

			public Vector3 attachPointNormal;

			public bool swapAngles;

			public string poseRoot;

			public GameObject prefab;

			[NonSerialized]
			public string Id;
		}

		[SerializeField]
		private PedalPrefab[] _pedals;

		public PedalPrefab[] Pedals => _pedals;

		public PedalPrefab GetPedal(string id)
		{
			PedalPrefab pedalPrefab = _pedals.Where((PedalPrefab x) => x.Id == id).FirstOrDefault();
			if (pedalPrefab == null)
			{
				return _pedals.First();
			}
			return pedalPrefab;
		}

		public void Initialize()
		{
			PedalPrefab[] pedals = _pedals;
			foreach (PedalPrefab obj in pedals)
			{
				obj.Id = obj.prefab.name;
			}
			List<PedalPrefab> source = (from r in _pedals
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, PedalPrefab> g) => g).ToList();
			if (source.Any())
			{
				Debug.LogWarning("Duplicate Pedal IDs found: " + string.Join(", ", source.Select((PedalPrefab r) => r.Id).Distinct()));
			}
		}
	}
}
