using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1WarehouseSelector : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _statusText;

		private ActiveWorldFrame _parent;

		public T1Warehouse Frame => _parent.ActiveFrame as T1Warehouse;

		private void Awake()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Start()
		{
			UpdateText();
		}

		public void TierSelected(int tier)
		{
			Frame.SetStorageTier(tier);
			UpdateText();
			T1WarehouseButton[] componentsInChildren = GetComponentsInChildren<T1WarehouseButton>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].UpdateHighlight();
			}
		}

		public void UpdateText()
		{
			int storageAmount = Frame.GetStorageAmount();
			_statusText.text = "+" + storageAmount + " storage for " + ((Frame.StorageTier == 0) ? "ALL" : ("Tier " + Frame.StorageTier)) + " items";
		}
	}
}
