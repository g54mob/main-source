using UnityEngine;
using UnityEngine.Events;

namespace Restory.Utils
{
	public class ApplicationFocusDetectionService : MonoBehaviour
	{
		public readonly UnityEvent OnApplicationGotFocus = new UnityEvent();

		public readonly UnityEvent OnApplicationLostFocus = new UnityEvent();

		[SerializeField]
		private bool turnOffInEditor;

		private bool isApplicationInFocus;

		public bool IsApplicationInFocus
		{
			get
			{
				return isApplicationInFocus;
			}
			private set
			{
				if (isApplicationInFocus != value)
				{
					isApplicationInFocus = value;
					if (value)
					{
						OnApplicationGotFocus?.Invoke();
					}
					else
					{
						OnApplicationLostFocus?.Invoke();
					}
				}
			}
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			IsApplicationInFocus = hasFocus;
		}
	}
}
