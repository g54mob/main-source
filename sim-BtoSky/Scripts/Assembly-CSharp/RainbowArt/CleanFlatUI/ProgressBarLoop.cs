using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ProgressBarLoop : MonoBehaviour
	{
		[SerializeField]
		private bool hasBackground = true;

		[SerializeField]
		private Image background;

		private Animator animator;

		public bool HasBackground
		{
			get
			{
				return hasBackground;
			}
			set
			{
				hasBackground = value;
				if (background != null)
				{
					background.gameObject.SetActive(hasBackground);
				}
			}
		}

		private void Start()
		{
			animator = base.gameObject.GetComponent<Animator>();
			animator.enabled = false;
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			if (!animator.enabled)
			{
				animator.enabled = true;
			}
			animator.Play("Transition", 0, 0f);
		}
	}
}
