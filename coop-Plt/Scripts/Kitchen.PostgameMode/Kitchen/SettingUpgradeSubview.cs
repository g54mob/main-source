using KitchenData;
using KitchenData.Localisations;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class SettingUpgradeSubview : SerializedMonoBehaviour, INewsItemSubview
	{
		[SerializeField]
		private GameObject Container;

		private GameObject SnowGlobe;

		public GenericLocalisation Localisation;

		public TextMeshPro Text;

		private int CurrentID;

		private void Awake()
		{
			Text.text = Localisation.Name;
		}

		public void SetItem(int id)
		{
			if (CurrentID == id)
			{
				return;
			}
			CurrentID = id;
			if (CurrentID != 0 && GameData.Main.TryGet<RestaurantSetting>(id, out var output))
			{
				if (SnowGlobe != null)
				{
					Object.Destroy(SnowGlobe);
				}
				if (!(output.Prefab == null))
				{
					SnowGlobe = Object.Instantiate(output.Prefab);
					SnowGlobe.transform.parent = Container.transform;
					SnowGlobe.transform.Reset();
				}
			}
		}
	}
}
