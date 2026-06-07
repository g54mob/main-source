using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	public class PropellerPrefabs : ScriptableObject
	{
		[Serializable]
		public class HubPrefab
		{
			public float baseScale = 1f;

			public string name;

			public GameObject prefab;

			[NonSerialized]
			public string Id;
		}

		[Serializable]
		public class PropellerPrefab
		{
			public string name;

			public GameObject prefab;

			[NonSerialized]
			public string Id;
		}

		[SerializeField]
		private HubPrefab[] _hubs;

		[SerializeField]
		private PropellerPrefab[] _propellers;

		public HubPrefab[] Hubs => _hubs;

		public PropellerPrefab[] Propellers => _propellers;

		public HubPrefab GetHub(string id)
		{
			HubPrefab hubPrefab = _hubs.Where((HubPrefab x) => x.Id == id).FirstOrDefault();
			if (hubPrefab == null)
			{
				return _hubs.First();
			}
			return hubPrefab;
		}

		public PropellerPrefab GetPropeller(string id)
		{
			PropellerPrefab propellerPrefab = _propellers.Where((PropellerPrefab x) => x.Id == id).FirstOrDefault();
			if (propellerPrefab == null)
			{
				return _propellers.First();
			}
			return propellerPrefab;
		}

		public void Initialize()
		{
			HubPrefab[] hubs = _hubs;
			foreach (HubPrefab obj in hubs)
			{
				obj.Id = obj.prefab.name;
			}
			PropellerPrefab[] propellers = _propellers;
			foreach (PropellerPrefab obj2 in propellers)
			{
				obj2.Id = obj2.prefab.name;
			}
			List<HubPrefab> source = (from r in _hubs
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, HubPrefab> g) => g).ToList();
			List<PropellerPrefab> source2 = (from t in _propellers
				group t by t.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, PropellerPrefab> g) => g).ToList();
			if (source.Any())
			{
				Debug.LogWarning("Duplicate Hub IDs found: " + string.Join(", ", source.Select((HubPrefab r) => r.Id).Distinct()));
			}
			if (source2.Any())
			{
				Debug.LogWarning("Duplicate Propeller IDs found: " + string.Join(", ", source2.Select((PropellerPrefab t) => t.Id).Distinct()));
			}
		}
	}
}
