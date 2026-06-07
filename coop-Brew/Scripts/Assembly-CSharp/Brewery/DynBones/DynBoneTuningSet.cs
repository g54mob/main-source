using System;
using UnityEngine;

namespace Brewery.DynBones
{
	[CreateAssetMenu(menuName = "Brewery/DynBones/Tuning Set", order = 151)]
	public class DynBoneTuningSet : ScriptableObject
	{
		[Serializable]
		public class Entry
		{
			[Tooltip("Synty bone prefix BEFORE '_dyn_'. E.g. 'hair', 'abac', 'ashl', 'afac', 'ahed', 'tors'.")]
			public string bonePrefix;

			public DynBoneTuning tuning;
		}

		[Serializable]
		public class SkirtEntry
		{
			[Tooltip("Substring of the source mesh GameObject name that identifies this skirt. E.g. 'CIVL_08_17HIPS' matches 'SK_MDRN_CIVL_08_17HIPS_HU01'.")]
			public string meshNameSubstring;

			[Tooltip("Tuning reused for this skirt's MeshCloth (gravity, damping, stiffness, radius).")]
			public DynBoneTuning tuning;

			[Tooltip("If > 0, vertices with local Y above this value are Fixed (waistband/body) and the rest are Move (swinging fabric). Lets you split a combined body+skirt mesh cleanly with one number. Set to 0 to use automatic bone-based heuristic.")]
			public float waistYThreshold;

			[Tooltip("Optional paint map (red=Fixed, green=Move). Overrides all heuristics when set. Use this when you need per-vertex control — paint in Photoshop using the skirt mesh's UVs. Texture must have Read/Write enabled.")]
			public Texture2D paintMap;
		}

		public Entry[] entries;

		[Tooltip("Hip meshes that should simulate as a skirt via MagicaCloth MeshCloth. Any mesh NOT listed here (body legs, regular trousers) is left alone.")]
		public SkirtEntry[] skirts;

		public DynBoneTuning Lookup(string prefix)
		{
			return null;
		}
	}
}
