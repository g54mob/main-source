using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class JetEnginePrefabs : ScriptableObject
	{
		[Serializable]
		public class FanPrefab : JetEnginePrefab
		{
		}

		[Serializable]
		public class InletConePrefab : JetEnginePrefab
		{
		}

		[Serializable]
		public class JetEnginePrefab
		{
			public string name;

			public GameObject prefab;

			public JetEngineType supportedJetEngineTypes = JetEngineType.Legacy;

			[NonSerialized]
			public string Id;
		}

		[Serializable]
		public class NozzlePrefab : JetEnginePrefab
		{
			public float gimbalAngle;

			public bool supportsAfterburner;

			public bool supportsNozzleLength;
		}

		[Serializable]
		public class ShroudPrefab : JetEnginePrefab
		{
		}

		[SerializeField]
		private FanPrefab[] _fans;

		[SerializeField]
		private InletConePrefab[] _inletCones;

		[SerializeField]
		private NozzlePrefab[] _nozzles;

		[SerializeField]
		private ShroudPrefab[] _shrouds;

		public FanPrefab[] Fans => _fans;

		public InletConePrefab[] InletCones => _inletCones;

		public NozzlePrefab[] Nozzles => _nozzles;

		public ShroudPrefab[] Shrouds => _shrouds;

		public FanPrefab GetFan(string id, JetEngineType jetEngineType)
		{
			FanPrefab fanPrefab = Fans.Where((FanPrefab x) => x.Id == id).FirstOrDefault();
			if (fanPrefab == null)
			{
				return Fans.Where((FanPrefab x) => x.supportedJetEngineTypes.HasFlag(jetEngineType)).First();
			}
			return fanPrefab;
		}

		public InletConePrefab GetInletCone(string id, JetEngineType jetEngineType)
		{
			InletConePrefab inletConePrefab = InletCones.Where((InletConePrefab x) => x.Id == id).FirstOrDefault();
			if (inletConePrefab == null)
			{
				return InletCones.Where((InletConePrefab x) => x.supportedJetEngineTypes.HasFlag(jetEngineType)).First();
			}
			return inletConePrefab;
		}

		public NozzlePrefab GetNozzle(string id, JetEngineType jetEngineType)
		{
			NozzlePrefab nozzlePrefab = Nozzles.Where((NozzlePrefab x) => x.Id == id).FirstOrDefault();
			if (nozzlePrefab == null)
			{
				return Nozzles.Where((NozzlePrefab x) => x.supportedJetEngineTypes.HasFlag(jetEngineType)).First();
			}
			return nozzlePrefab;
		}

		public ShroudPrefab GetShroud(string id, JetEngineType jetEngineType)
		{
			ShroudPrefab shroudPrefab = Shrouds.Where((ShroudPrefab x) => x.Id == id).FirstOrDefault();
			if (shroudPrefab == null)
			{
				return Shrouds.Where((ShroudPrefab x) => x.supportedJetEngineTypes.HasFlag(jetEngineType)).First();
			}
			return shroudPrefab;
		}

		public void Initialize()
		{
			FanPrefab[] fans = _fans;
			foreach (FanPrefab obj in fans)
			{
				obj.Id = obj.prefab.name;
			}
			InletConePrefab[] inletCones = _inletCones;
			foreach (InletConePrefab obj2 in inletCones)
			{
				obj2.Id = obj2.prefab.name;
			}
			NozzlePrefab[] nozzles = _nozzles;
			foreach (NozzlePrefab obj3 in nozzles)
			{
				obj3.Id = obj3.prefab.name;
			}
			ShroudPrefab[] shrouds = _shrouds;
			foreach (ShroudPrefab obj4 in shrouds)
			{
				obj4.Id = obj4.prefab.name;
			}
			List<NozzlePrefab> source = (from r in Nozzles
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, NozzlePrefab> g) => g).ToList();
			if (source.Any())
			{
				Debug.LogWarning("Duplicate Nozzle IDs found: " + string.Join(", ", source.Select((NozzlePrefab r) => r.Id).Distinct()));
			}
			List<FanPrefab> source2 = (from r in Fans
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, FanPrefab> g) => g).ToList();
			if (source2.Any())
			{
				Debug.LogWarning("Duplicate Fan IDs found: " + string.Join(", ", source2.Select((FanPrefab r) => r.Id).Distinct()));
			}
			List<InletConePrefab> source3 = (from r in InletCones
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, InletConePrefab> g) => g).ToList();
			if (source3.Any())
			{
				Debug.LogWarning("Duplicate Inlet Cone IDs found: " + string.Join(", ", source3.Select((InletConePrefab r) => r.Id).Distinct()));
			}
			List<ShroudPrefab> source4 = (from r in Shrouds
				group r by r.Id into g
				where g.Count() > 1
				select g).SelectMany((IGrouping<string, ShroudPrefab> g) => g).ToList();
			if (source4.Any())
			{
				Debug.LogWarning("Duplicate Shroud IDs found: " + string.Join(", ", source4.Select((ShroudPrefab r) => r.Id).Distinct()));
			}
		}
	}
}
