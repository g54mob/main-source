using UnityEngine;

namespace Jundroo.Common.Events
{
	public class ApplicationEventNotifier : MonoBehaviour
	{
		public delegate void ApplicationFocusStateChangedDelegate(bool focusState);

		public delegate void ApplicationPauseStateChangedDelegate(bool pauseState);

		public delegate void ApplicationQuitDelegate();

		public event ApplicationFocusStateChangedDelegate Focused;

		public event ApplicationPauseStateChangedDelegate Paused;

		public event ApplicationQuitDelegate Quit;

		protected virtual void OnApplicationFocus(bool focus)
		{
			this.Focused?.Invoke(focus);
		}

		protected virtual void OnApplicationPause(bool pause)
		{
			this.Paused?.Invoke(pause);
		}

		protected virtual void OnApplicationQuit()
		{
			this.Quit?.Invoke();
		}
	}
}
