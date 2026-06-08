using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class FranchiseUpgradeSubview : MonoBehaviour, INewsItemSubview
	{
		public GameObject Container;

		public GameObject NoPrefab;

		private int CurrentID;

		private GameObject Prefab;

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
				if (prefab == null)
				{
					NoPrefab.SetActive(value: true);
					return;
				}
				NoPrefab.SetActive(value: false);
				Prefab = Object.Instantiate(prefab, Container.transform);
				Prefab.transform.localPosition = Vector3.zero;
			}
		}
	}
}
