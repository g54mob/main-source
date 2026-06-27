using System;
using System.Collections.Generic;
using Restory.Data.Localization;
using Restory.Gameplay.Elements;
using Restory.UI.Presenters.InventoryNotification;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InventoryNotification
{
	public sealed class InventoryNotificationService : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		[Min(1f)]
		private int maxNotificationsPerBatch = 5;

		[SerializeField]
		private string andOthersLocalizationKey = "INVENTORY_NOTIFICATION_AND_OTHERS";

		private GUI_InventoryNotificationCanvas notificationCanvas;

		private LocalizationSystem localizationSystem;

		[Inject]
		private void Construct(GUI_InventoryNotificationCanvas notificationCanvas, LocalizationSystem localizationSystem)
		{
			this.notificationCanvas = notificationCanvas;
			this.localizationSystem = localizationSystem;
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
			notificationCanvas = null;
		}

		public void ShowElements(IEnumerable<HeldElement> heldElements)
		{
			if (notificationCanvas.HasActiveNotifications)
			{
				notificationCanvas.Hide();
			}
			notificationCanvas.Show(GetItems(heldElements));
		}

		private IEnumerable<string> GetItems(IEnumerable<HeldElement> heldElements)
		{
			int count = 0;
			foreach (HeldElement heldElement in heldElements)
			{
				if (count >= maxNotificationsPerBatch)
				{
					yield return localizationSystem.GetTranslation(andOthersLocalizationKey);
					yield break;
				}
				string translation = localizationSystem.GetTranslation(heldElement.ElementData.Info.NameLocalizationKey);
				translation = localizationSystem.GetTranslation(heldElement.ElementData.Info.SourceDevice.NameLocalizationKey) + ": " + translation;
				if (heldElement.HeldAmount > 1)
				{
					translation = $"{translation} {heldElement.HeldAmount:+0;-0;0}";
				}
				yield return translation;
				count++;
			}
		}
	}
}
