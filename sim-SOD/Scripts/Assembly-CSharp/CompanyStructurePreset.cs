using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "company_structure_data", menuName = "Database/Company/Structure Preset")]
public class CompanyStructurePreset : SoCustomComparison
{
	[Serializable]
	public class OccupationSettings
	{
		public OccupationPreset occupation;

		public int positionsMinimum;

		public int positionsMaximum;

		[Range(0f, 1f)]
		public float payGrade;
	}

	[Serializable]
	public class BossConfig : OccupationSettings
	{
		[Header("Is Boss Of...")]
		public List<Hierarchy1Config> subordinates;
	}

	[Serializable]
	public class Hierarchy1Config : OccupationSettings
	{
		[Header("Is Boss Of...")]
		public List<Hierarchy2Config> subordinates;
	}

	[Serializable]
	public class Hierarchy2Config : OccupationSettings
	{
		[Header("Is Boss Of...")]
		public List<Hierarchy3Config> subordinates;
	}

	[Serializable]
	public class Hierarchy3Config : OccupationSettings
	{
		[Header("Is Boss Of...")]
		public List<OccupationSettings> subordinates;
	}

	[Serializable]
	public class Hierarchy4Config : OccupationSettings
	{
	}

	[Header("Company Structure")]
	public BossConfig companyStructure;
}
