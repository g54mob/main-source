using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ProgressBarLoop : MonoBehaviour
	{
		[SerializeField]
		private bool hasBackground;

		[SerializeField]
		private Image background;

		private Animator animator;

		public bool HasBackground
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void UpdateGUI()
		{
		}
	}
}
