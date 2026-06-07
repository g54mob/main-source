using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ButtonTransition : MonoBehaviour
	{
		private Button button;

		[SerializeField]
		private Animator animator;

		private void Start()
		{
			if (button == null)
			{
				button = base.gameObject.GetComponent<Button>();
			}
			button.onClick.AddListener(OnButtonClick);
			if (animator != null)
			{
				animator.enabled = false;
			}
		}

		public void OnButtonClick()
		{
			if (animator != null)
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
