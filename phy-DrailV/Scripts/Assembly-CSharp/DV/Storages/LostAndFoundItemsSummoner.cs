using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.Storages
{
	public class LostAndFoundItemsSummoner : MonoBehaviour
	{
		public bool summonItemsFromWorld = true;

		public bool summonItemsFromHomeAndVehicles = true;

		public bool summonItemsFromSnapPoints = true;

		private ButtonBase button;

		private void Start()
		{
			button = GetComponent<ButtonBase>();
			if (button == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: LostAndFoundItemsSummoner missing button. Won't function properly");
			}
			else
			{
				button.Used += OnSummonPressed;
			}
		}

		private void OnDestroy()
		{
			if (button != null)
			{
				button.Used -= OnSummonPressed;
			}
		}

		private void OnSummonPressed()
		{
			if (SingletonBehaviour<StorageController>.Instance == null)
			{
				Debug.LogError("StorageController not present. Item summon ignored");
			}
			else
			{
				SingletonBehaviour<StorageController>.Instance.ForceSummonAllWorldItemsToLostAndFound(summonItemsFromWorld, summonItemsFromHomeAndVehicles, summonItemsFromSnapPoints);
			}
		}
	}
}
