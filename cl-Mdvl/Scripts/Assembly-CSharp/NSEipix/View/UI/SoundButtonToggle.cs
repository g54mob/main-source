using TMPro;
using UnityEngine;

namespace NSEipix.View.UI
{
	[RequireComponent(typeof(SoundButton))]
	public class SoundButtonToggle : MonoBehaviour
	{
		[SerializeField]
		private GameObject imageInactive;

		[SerializeField]
		private GameObject imageActive;

		private bool stateActive;

		private SoundButton button;

		public SoundButton Button
		{
			get
			{
				if (button == null)
				{
					button = GetComponent<SoundButton>();
				}
				return button;
			}
		}

		public bool StateActive => stateActive;

		public void IsOn(bool active)
		{
			stateActive = active;
			SetToggle();
		}

		public void SwitchState()
		{
			stateActive = !StateActive;
			SetToggle();
		}

		public void SetLabels(string labelText)
		{
			imageInactive.GetComponentInChildren<TMP_Text>().text = labelText;
			imageActive.GetComponentInChildren<TMP_Text>().text = labelText;
		}

		private void SetToggle()
		{
			imageActive.SetActive(StateActive);
			imageInactive.SetActive(!StateActive);
			Button.interactable = !StateActive;
		}
	}
}
