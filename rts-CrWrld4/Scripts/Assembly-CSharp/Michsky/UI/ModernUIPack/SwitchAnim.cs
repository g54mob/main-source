using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class SwitchAnim : MonoBehaviour
	{
		public Animator switchAnimator;

		public int switchID;

		public bool isOn;

		public bool saveValue;

		public int playerPrefsHelper;

		public UnityEvent OffEvents;

		public UnityEvent OnEvents;

		private Button offButton;

		private Button onButton;

		private string onTransition;

		private string offTransition;

		private void Start()
		{
		}

		public void AnimateSwitch()
		{
		}
	}
}
