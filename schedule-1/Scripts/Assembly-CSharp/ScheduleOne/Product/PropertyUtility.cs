using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using UnityEngine;

namespace ScheduleOne.Product
{
	public class PropertyUtility : Singleton<PropertyUtility>
	{
		[Serializable]
		public class PropertyData
		{
			public EProperty Property;

			public string Name;

			public string Description;

			public Color Color;
		}

		[Serializable]
		public class DrugTypeData
		{
			public EDrugType DrugType;

			public string Name;

			public Color Color;
		}

		public List<PropertyData> PropertyDatas;

		public List<DrugTypeData> DrugTypeDatas;

		public List<Effect> AllProperties;

		[Header("Test Mixing")]
		public List<ProductDefinition> Products;

		public List<PropertyItemDefinition> Properties;

		private Dictionary<string, Effect> PropertiesDict;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public List<Effect> GetProperties(int tier)
		{
			return null;
		}

		public List<Effect> GetProperties(List<string> ids)
		{
			return null;
		}

		public static PropertyData GetPropertyData(EProperty property)
		{
			return null;
		}

		public static DrugTypeData GetDrugTypeData(EDrugType drugType)
		{
			return null;
		}

		public static List<Color32> GetOrderedPropertyColors(List<Effect> properties)
		{
			return null;
		}
	}
}
