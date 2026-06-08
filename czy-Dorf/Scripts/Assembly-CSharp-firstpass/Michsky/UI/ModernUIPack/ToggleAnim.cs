using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class ToggleAnim : MonoBehaviour
	{
		public Toggle toggleObject;

		public Animator toggleAnimator;

		private void Start()
		{
			toggleObject = base.gameObject.GetComponent<Toggle>();
			toggleAnimator = base.gameObject.GetComponent<Animator>();
			toggleObject.onValueChanged.AddListener(TaskOnClick);
			if (toggleObject.isOn)
			{
				toggleAnimator.Play("Toggle On");
			}
			else
			{
				toggleAnimator.Play("Toggle Off");
			}
		}

		private void TaskOnClick(bool value)
		{
			if (toggleObject.isOn)
			{
				toggleAnimator.Play("Toggle On");
			}
			else
			{
				toggleAnimator.Play("Toggle Off");
			}
		}
	}
}
