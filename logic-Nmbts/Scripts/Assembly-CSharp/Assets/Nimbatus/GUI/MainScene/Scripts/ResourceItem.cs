using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ResourceItem : MonoBehaviour
	{
		public UITexture Icon;

		public UILabel AmountLabel;

		private ETerrainMaterial _material;

		private string _toolTip;

		private ResourceSetting _setting;

		private BoxCollider _collider;

		public void Init(ETerrainMaterial material, ResourceSetting setting)
		{
			_material = material;
			_setting = setting;
			Icon.mainTexture = setting.Icon;
			_collider = GetComponent<BoxCollider>();
		}

		public void Update()
		{
			double num = Math.Floor(SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetAvailableResources(_material));
			AmountLabel.text = num.ToString("###0");
			if (_collider != null)
			{
				_collider.size = new Vector3(AmountLabel.width + 30, _collider.size.y, _collider.size.z);
				_collider.center = new Vector3((_collider.size.x - 100f) / 2f, 0f, 0f);
			}
			_toolTip = LabelHelper.LightGrey + _setting.Name.GetTranslation() + ": " + num.ToString("###0");
			_toolTip = _toolTip + LabelHelper.NewLine + LabelHelper.LightGrey;
			_toolTip += ((_material == ETerrainMaterial.CommonOre) ? LocalizationManager.GetTermTranslation("CampaignMode/CommonOreDesc") : LocalizationManager.GetTermTranslation("CampaignMode/RareOreDesc"));
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(show ? _toolTip : null);
		}
	}
}
