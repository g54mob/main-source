using System;
using UnityEngine;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	[CreateAssetMenu(fileName = "DlcData", menuName = "VampireSurvivors/New VersionData")]
	public class VersionData : ScriptableObject
	{
		public string _BuildId;

		public string _BuildTime;

		private static VersionData _instance;

		public static VersionData Instance => null;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public string GetFormattedBuildId()
		{
			return null;
		}
	}
}
