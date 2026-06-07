using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class FastTravelCanvasHelper : MonoBehaviour
	{
		[NullCheck]
		public FastTravelUIController uiController;

		private void Start()
		{
			uiController.CloseRequested += delegate
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.FastTravel, on: false);
			};
		}
	}
}
