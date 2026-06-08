using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Section_Biome : Section
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Biome, bool> _003C_003E9__6_0;

		internal bool _003CSpecificSetup_003Eb__6_0(Biome x)
		{
			return x.IsUnlocked;
		}
	}

	private Biome _003CBiome_003Ek__BackingField;

	private BiomeSectionManager biomeSectionManager;

	private string biomeName;

	public Biome Biome
	{
		get
		{
			return _003CBiome_003Ek__BackingField;
		}
		private set
		{
			_003CBiome_003Ek__BackingField = value;
		}
	}

	protected override void SpecificSetup()
	{
		biomeSectionManager = (BiomeSectionManager)base.SectionManager;
		List<Biome> list = Enumerable.ToList(Enumerable.Where(biomeSectionManager.currentlyAvailableBiomes, (Biome x) => x.IsUnlocked));
		Biome = list[UnityEngine.Random.Range(0, list.Count)];
	}

	public override void DebugInfluence(float distance, float influence)
	{
		debugLabel.text = $"{biomeName}\n{base.GridPos}\nDist: {distance:0.00}\nInfl: {influence:0.00}";
	}
}
