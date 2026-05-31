using System;
using CTS.Core;
using CTS.UI;

namespace CTS
{
	public class FinancialUI : CTSBehaviour
	{
		[Inject(false)]
		private CanvasGroupController _canvasGroupController;

		public static event Action FinancialUIOpened;

		protected override void OnDisabled()
		{
			_canvasGroupController.CanvasShowned -= OnCanvasShowned;
		}

		protected override void OnEnabled()
		{
			_canvasGroupController.CanvasShowned += OnCanvasShowned;
		}

		private void OnCanvasShowned(bool value)
		{
			if (value)
			{
				FinancialUI.FinancialUIOpened?.Invoke();
			}
		}
	}
}
