using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class SystemStatusVisual3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private GameObject _redState;

		[SerializeField]
		private GameObject _orangeState;

		[SerializeField]
		private GameObject _greenState;

		public void SetState(SystemStatus.PerformanceState state)
		{
		}
	}
}
