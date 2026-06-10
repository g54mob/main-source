using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "company_open_hours_data", menuName = "Database/Company/Open Hours Preset")]
public class CompanyOpenHoursPreset : SoCustomComparison
{
	[Serializable]
	public class CompanyShift
	{
		public string name;

		public OccupationPreset.ShiftType shiftType;

		public Vector2 decimalHours;

		public bool monday;

		public bool tuesday;

		public bool wednesday;

		public bool thursday;

		public bool friday;

		public bool saturday;

		public bool sunday;

		[NonSerialized]
		public List<Occupation> assigned;

		[ReadOnly]
		public int debugAssigned;
	}

	[Tooltip("Hours of retail opening hours")]
	[Header("Opening Hours")]
	public Vector2 retailOpenHours;

	[Header("Days Open")]
	public bool monday;

	public bool tuesday;

	public bool wednesday;

	public bool thursday;

	public bool friday;

	public bool saturday;

	public bool sunday;

	[Header("Work Hours")]
	[ReorderableList]
	public List<CompanyShift> shifts;
}
