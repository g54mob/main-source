using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public static class CanvasControllerExtensions
	{
		public static PopupManager FindPopupManager(this Behaviour searchFrom, ref PopupManager popupManager)
		{
			if (!popupManager)
			{
				if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance != null && SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager != null)
				{
					popupManager = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager;
				}
				else
				{
					popupManager = searchFrom.GetComponentInParent<PopupManager>();
				}
			}
			return popupManager;
		}
	}
}
