using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Car;
using NWH.Common.Vehicles;
using UnityEngine;

namespace Assets.Scripts.Craft.CraftResourceData
{
	public class WheelPrefabs : ScriptableObject
	{
		[Serializable]
		public class FrictionPreset
		{
			public NWH.Common.Vehicles.FrictionPreset frictionPreset;

			public string id;

			public string name;
		}

		[Serializable]
		public class RimPrefab
		{
			public GameObject barrelPrefab;

			[NonSerialized]
			public string Id;

			public string name;

			public GameObject prefab;
		}

		[Serializable]
		public class TirePrefab
		{
			public TireCategory category;

			[NonSerialized]
			public string Id;

			public string name;

			public GameObject prefab;

			public float rimScale = 0.5f;

			public TireProfile tireProfile;
		}

		[SerializeField]
		private FrictionPreset[] _frictionPresets;

		[SerializeField]
		private RimPrefab[] _rims;

		[SerializeField]
		private TirePrefab[] _tires;

		public FrictionPreset[] FrictionPresets => _frictionPresets;

		public RimPrefab[] Rims => _rims;

		public TirePrefab[] Tires => _tires;

		public FrictionPreset GetFrictionPreset(string id)
		{
			FrictionPreset frictionPreset = _frictionPresets.Where((FrictionPreset x) => x.id == id).FirstOrDefault();
			if (frictionPreset == null)
			{
				return _frictionPresets.First();
			}
			return frictionPreset;
		}

		public RimPrefab GetRim(string id)
		{
			RimPrefab rimPrefab = _rims.Where((RimPrefab x) => x.Id == id).FirstOrDefault();
			if (rimPrefab == null)
			{
				return _rims.First();
			}
			return rimPrefab;
		}

		public TirePrefab GetTire(string id)
		{
			TirePrefab tirePrefab = _tires.Where((TirePrefab x) => x.Id == id).FirstOrDefault();
			if (tirePrefab == null)
			{
				return _tires.First();
			}
			return tirePrefab;
		}

		public TirePrefab GetTire(TireCategory category, string name)
		{
			TirePrefab tirePrefab = _tires.Where((TirePrefab x) => x.category == category && x.name == name).FirstOrDefault();
			if (tirePrefab == null)
			{
				return _tires.First();
			}
			return tirePrefab;
		}

		public void Initialize()
		{
			RimPrefab[] rims = _rims;
			foreach (RimPrefab obj in rims)
			{
				obj.Id = obj.prefab.name;
			}
			TirePrefab[] tires = _tires;
			foreach (TirePrefab obj2 in tires)
			{
				obj2.Id = obj2.prefab.name;
			}
			List<RimPrefab> source = (from r in _rims
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, RimPrefab> g) => g).ToList();
			List<TirePrefab> source2 = (from t in _tires
				group t by t.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, TirePrefab> g) => g).ToList();
			if (source.Any())
			{
				Debug.LogWarning("Duplicate Rim IDs found: " + string.Join(", ", source.Select((RimPrefab r) => r.Id).Distinct()));
			}
			if (source2.Any())
			{
				Debug.LogWarning("Duplicate Tire IDs found: " + string.Join(", ", source2.Select((TirePrefab t) => t.Id).Distinct()));
			}
		}
	}
}
