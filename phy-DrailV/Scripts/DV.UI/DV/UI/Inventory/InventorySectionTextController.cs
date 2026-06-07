using TMPro;
using UnityEngine;

namespace DV.UI.Inventory
{
	public class InventorySectionTextController : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI textComponent;

		private void Awake()
		{
			if (textComponent == null)
			{
				Debug.LogError("InventorySectionTextController: Text component is not set, this should not happen.", this);
			}
		}

		public void UpdateText(string containerLocalizedName)
		{
			textComponent.text = containerLocalizedName;
		}
	}
}
