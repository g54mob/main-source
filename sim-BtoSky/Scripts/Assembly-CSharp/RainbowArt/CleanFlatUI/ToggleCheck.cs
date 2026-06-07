using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ToggleCheck : MonoBehaviour
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private Animator animator;

		private void Start()
		{
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			if (animator != null)
			{
				animator.enabled = false;
			}
			if (toggle == null)
			{
				toggle = GetComponent<Toggle>();
			}
			toggle.onValueChanged.AddListener(ToggleValueChanged);
		}

		private void ToggleValueChanged(bool value)
		{
			if (value && animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				animator.Play("Transition", 0, 0f);
			}
		}
	}
}
