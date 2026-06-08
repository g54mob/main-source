using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class GarageUpgradeSubview : MonoBehaviour, INewsItemSubview
	{
		public GameObject Container;

		public CrateView Crate;

		public TextMeshPro Text;

		private int CurrentID;

		private GameObject Prefab;

		private void Awake()
		{
			Text.text = GameData.Main.GlobalLocalisation["REWARD_NEW_GARAGE"];
		}

		public void SetItem(int id)
		{
			if (CurrentID == id)
			{
				return;
			}
			if (Prefab != null)
			{
				Object.Destroy(Prefab);
			}
			CurrentID = id;
			if (CurrentID != 0)
			{
				GameObject prefab = GameData.Main.GetPrefab(id);
				Prefab = Object.Instantiate(prefab, Container.transform);
				Prefab.transform.localPosition = Vector3.zero;
				if (Crate != null)
				{
					Crate.UpdateData(new CrateView.ViewData
					{
						Prefab = CurrentID
					});
				}
			}
		}
	}
}
