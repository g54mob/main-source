using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class DishUpgradeSubview : MonoBehaviour, INewsItemSubview
	{
		public GameObject Container;

		public TextMeshPro Text;

		private int CurrentID;

		private GameObject Prefab;

		private void Awake()
		{
			Text.text = GameData.Main.GlobalLocalisation["REWARD_NEW_DISH"];
		}

		public void SetItem(int id)
		{
			if (CurrentID != id)
			{
				if (Prefab != null)
				{
					Object.Destroy(Prefab);
				}
				CurrentID = id;
				if (CurrentID != 0 && GameData.Main.TryGet<Dish>(id, out var output, warn_if_fail: true))
				{
					GameObject original = ((output.DisplayPrefab == null) ? output.IconPrefab : output.DisplayPrefab);
					Prefab = Object.Instantiate(original, Container.transform);
					Prefab.transform.localPosition = Vector3.zero;
				}
			}
		}
	}
}
