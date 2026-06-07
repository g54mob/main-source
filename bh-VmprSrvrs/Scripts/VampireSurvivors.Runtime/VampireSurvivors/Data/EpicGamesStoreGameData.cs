using System;
using UnityEngine;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class EpicGamesStoreGameData
	{
		[SerializeField]
		private string _ArtifactId;

		[SerializeField]
		private bool _BundledDlcInBuild;

		public string ArtifactId => null;

		public bool BundledDlcInBuild
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
	}
}
