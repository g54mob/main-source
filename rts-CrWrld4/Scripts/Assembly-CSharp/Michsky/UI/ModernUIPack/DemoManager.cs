using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class DemoManager : MonoBehaviour
	{
		public List<GameObject> panels;

		public List<GameObject> buttons;

		public Text topTitleText;

		private string panelFadeIn;

		private string panelFadeOut;

		private string buttonFadeIn;

		private string buttonFadeOut;

		private GameObject currentPanel;

		private GameObject nextPanel;

		private GameObject currentButton;

		private GameObject nextButton;

		public int currentPanelIndex;

		private int currentButtonlIndex;

		private Animator currentPanelAnimator;

		private Animator nextPanelAnimator;

		private Animator currentButtonAnimator;

		private Animator nextButtonAnimator;

		private void Start()
		{
		}

		public void changeTopTitle(string newTitle)
		{
		}

		public void PanelAnim(int newPanel)
		{
		}
	}
}
