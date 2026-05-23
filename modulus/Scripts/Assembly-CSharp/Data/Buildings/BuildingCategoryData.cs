using System;
using UnityEngine;

namespace Data.Buildings
{
	[Serializable]
	[CreateAssetMenu(menuName = "UI/Toolbar/BuildingCategoryData", fileName = "BuildingCategoryData", order = 0)]
	public class BuildingCategoryData : ScriptableObject
	{
		[SerializeField]
		private BuildingCategoryType _type;

		[SerializeField]
		private Sprite[] _icon;

		public BuildingCategoryType Type => _type;

		public Sprite[] Icon => _icon;
	}
}
