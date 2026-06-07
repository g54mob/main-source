using System;
using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class Playstation4PlatformSettings
	{
		[SerializeField]
		private string defaultSaveIconPath;

		[SerializeField]
		private bool usesOnlineFeatures;

		[SerializeField]
		private int defaultAgeRestriction;

		[SerializeField]
		private List<Playstation4AgeRestriction> ageRestrictions;

		public string DefaultSaveIconPath => null;

		public bool UsesOnlineFeatures => false;

		public int DefaultAgeRestriction => 0;

		public IReadOnlyList<Playstation4AgeRestriction> AgeRestrictions => null;
	}
}
