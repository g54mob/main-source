using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.UI.Overlays
{
	public abstract class UIModalDialog : MonoBehaviour
	{
		public abstract void ShowModal(AbstractUIModalDialogData menuData);

		public abstract void HideModal();

		public abstract bool TryCanCancel();
	}
}
