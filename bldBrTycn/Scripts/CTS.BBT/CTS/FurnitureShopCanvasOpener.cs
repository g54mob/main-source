using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class FurnitureShopCanvasOpener : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _canvasGroupController;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_canvasGroupController.CanvasShowning += OnCanvasGroupShowing;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_canvasGroupController.CanvasShowning -= OnCanvasGroupShowing;
		}

		private void OnCanvasGroupShowing(bool obj)
		{
			MonoSingleton<FurnitureShop>.Instance.SetFurnitureShopOpen(obj);
		}
	}
}
