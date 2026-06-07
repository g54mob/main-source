using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class SleepingHelper : MonoBehaviour
	{
		[NullCheck]
		public SleepingUIController uiController;

		private void Start()
		{
			uiController.CloseRequested += delegate
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.BedSleeping, on: false);
			};
		}
	}
}
