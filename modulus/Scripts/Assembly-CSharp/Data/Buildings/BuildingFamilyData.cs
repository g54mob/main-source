using System;
using UnityEngine;

namespace Data.Buildings
{
	[Serializable]
	[CreateAssetMenu(menuName = "UI/Toolbar/BuildingFamilyData", fileName = "BuildingFamilyData", order = 0)]
	public class BuildingFamilyData : ScriptableObject
	{
		[SerializeField]
		private int _id;

		[SerializeField]
		private string _nameLocalizationId;

		[SerializeField]
		private Color _color;

		public int ID => _id;

		public string NameLocalizationId => _nameLocalizationId;

		public Color Color => _color;
	}
}
