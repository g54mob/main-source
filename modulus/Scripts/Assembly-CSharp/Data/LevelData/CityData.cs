using System.Collections.Generic;
using CustomAttributes;
using Data.SceneManager;
using UnityEngine;

namespace Data.LevelData
{
	[CreateAssetMenu(menuName = "Levels/CityData", fileName = "CityData", order = 0)]
	public class CityData : ScriptableObject
	{
		[SerializeField]
		[ReadOnly]
		private string _guidStr = string.Empty;

		public SceneObject SceneReference;

		public string Name;

		public int RequiredRankForUnlock;

		public List<ExportResource> ExportResourcesAndRequiredRank;

		public string GuidStr => _guidStr;
	}
}
