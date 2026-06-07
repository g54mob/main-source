using System.Globalization;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class ResourcePriceItem : MonoBehaviour
	{
		public UITexture Icon;

		public UILabel AmountLabel;

		private float _value;

		public Color NotAffordableColor;

		public Color AffordableColor;

		internal void Init(ETerrainMaterial mat, int price)
		{
			_value = price;
			ResourceSetting resourceSetting = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.ResourceSettings[mat];
			bool num = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.HasResources(mat, price);
			Icon.mainTexture = resourceSetting.Icon;
			AmountLabel.text = _value.ToString("###0", CultureInfo.InvariantCulture);
			if (num)
			{
				AmountLabel.color = AffordableColor;
			}
			else
			{
				AmountLabel.color = NotAffordableColor;
			}
		}
	}
}
