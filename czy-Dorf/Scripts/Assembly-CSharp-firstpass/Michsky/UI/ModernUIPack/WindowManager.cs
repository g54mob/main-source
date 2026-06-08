using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class WindowManager : MonoBehaviour
	{
		[Serializable]
		public class WindowItem
		{
			public string windowName = "My Window";

			public GameObject windowObject;

			public GameObject buttonObject;
		}

		public List<WindowItem> windows = new List<WindowItem>();

		public int currentWindowIndex;

		private int currentButtonIndex;

		private int newWindowIndex;

		public string windowFadeIn = "Panel In";

		public string windowFadeOut = "Panel Out";

		public string buttonFadeIn = "Normal to Pressed";

		public string buttonFadeOut = "Pressed to Dissolve";

		private bool isFirstTime = true;

		private GameObject currentWindow;

		private GameObject nextWindow;

		private GameObject currentButton;

		private GameObject nextButton;

		private Animator currentWindowAnimator;

		private Animator nextWindowAnimator;

		private Animator currentButtonAnimator;

		private Animator nextButtonAnimator;

		private void Start()
		{
			try
			{
				currentButton = windows[currentWindowIndex].buttonObject;
				currentButtonAnimator = currentButton.GetComponent<Animator>();
				currentButtonAnimator.Play(buttonFadeIn);
			}
			catch
			{
			}
			currentWindow = windows[currentWindowIndex].windowObject;
			currentWindowAnimator = currentWindow.GetComponent<Animator>();
			currentWindowAnimator.Play(windowFadeIn);
			isFirstTime = false;
		}

		private void OnEnable()
		{
			if (!isFirstTime && nextWindowAnimator == null)
			{
				currentWindowAnimator.Play(windowFadeIn);
				currentButtonAnimator.Play(buttonFadeIn);
			}
			else if (!isFirstTime && nextWindowAnimator != null)
			{
				nextWindowAnimator.Play(windowFadeIn);
				nextButtonAnimator.Play(buttonFadeIn);
			}
		}

		public void OpenFirstTab()
		{
			if (currentWindowIndex != 0)
			{
				currentWindow = windows[currentWindowIndex].windowObject;
				currentWindowAnimator = currentWindow.GetComponent<Animator>();
				currentWindowAnimator.Play(windowFadeOut);
				try
				{
					currentButton = windows[currentWindowIndex].buttonObject;
					currentButtonAnimator = currentButton.GetComponent<Animator>();
					currentButtonAnimator.Play(buttonFadeOut);
				}
				catch
				{
				}
				currentWindowIndex = 0;
				currentButtonIndex = 0;
				currentWindow = windows[currentWindowIndex].windowObject;
				currentWindowAnimator = currentWindow.GetComponent<Animator>();
				currentWindowAnimator.Play(windowFadeIn);
				try
				{
					currentButton = windows[currentButtonIndex].buttonObject;
					currentButtonAnimator = currentButton.GetComponent<Animator>();
					currentButtonAnimator.Play(buttonFadeIn);
					return;
				}
				catch
				{
					return;
				}
			}
			if (currentWindowIndex == 0)
			{
				currentWindow = windows[currentWindowIndex].windowObject;
				currentWindowAnimator = currentWindow.GetComponent<Animator>();
				currentWindowAnimator.Play(windowFadeIn);
				try
				{
					currentButton = windows[currentButtonIndex].buttonObject;
					currentButtonAnimator = currentButton.GetComponent<Animator>();
					currentButtonAnimator.Play(buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		public void OpenPanel(string newPanel)
		{
			for (int i = 0; i < windows.Count; i++)
			{
				if (windows[i].windowName == newPanel)
				{
					newWindowIndex = i;
				}
			}
			if (newWindowIndex != currentWindowIndex)
			{
				currentWindow = windows[currentWindowIndex].windowObject;
				try
				{
					currentButton = windows[currentWindowIndex].buttonObject;
				}
				catch
				{
				}
				currentWindowIndex = newWindowIndex;
				nextWindow = windows[currentWindowIndex].windowObject;
				currentWindowAnimator = currentWindow.GetComponent<Animator>();
				nextWindowAnimator = nextWindow.GetComponent<Animator>();
				currentWindowAnimator.Play(windowFadeOut);
				nextWindowAnimator.Play(windowFadeIn);
				try
				{
					currentButtonIndex = newWindowIndex;
					nextButton = windows[currentButtonIndex].buttonObject;
					currentButtonAnimator = currentButton.GetComponent<Animator>();
					nextButtonAnimator = nextButton.GetComponent<Animator>();
					currentButtonAnimator.Play(buttonFadeOut);
					nextButtonAnimator.Play(buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		public void NextPage()
		{
			if (currentWindowIndex <= windows.Count - 2)
			{
				currentWindow = windows[currentWindowIndex].windowObject;
				try
				{
					currentButton = windows[currentButtonIndex].buttonObject;
					nextButton = windows[currentButtonIndex + 1].buttonObject;
					currentButtonAnimator = currentButton.GetComponent<Animator>();
					currentButtonAnimator.Play(buttonFadeOut);
				}
				catch
				{
				}
				currentWindowAnimator = currentWindow.GetComponent<Animator>();
				currentWindowAnimator.Play(windowFadeOut);
				currentWindowIndex++;
				currentButtonIndex++;
				nextWindow = windows[currentWindowIndex].windowObject;
				nextWindowAnimator = nextWindow.GetComponent<Animator>();
				nextWindowAnimator.Play(windowFadeIn);
				try
				{
					nextButtonAnimator = nextButton.GetComponent<Animator>();
					nextButtonAnimator.Play(buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		public void PrevPage()
		{
			if (currentWindowIndex >= 1)
			{
				currentWindow = windows[currentWindowIndex].windowObject;
				try
				{
					currentButton = windows[currentButtonIndex].buttonObject;
					nextButton = windows[currentButtonIndex - 1].buttonObject;
					currentButtonAnimator = currentButton.GetComponent<Animator>();
					currentButtonAnimator.Play(buttonFadeOut);
				}
				catch
				{
				}
				currentWindowAnimator = currentWindow.GetComponent<Animator>();
				currentWindowAnimator.Play(windowFadeOut);
				currentWindowIndex--;
				currentButtonIndex--;
				nextWindow = windows[currentWindowIndex].windowObject;
				nextWindowAnimator = nextWindow.GetComponent<Animator>();
				nextWindowAnimator.Play(windowFadeIn);
				try
				{
					nextButtonAnimator = nextButton.GetComponent<Animator>();
					nextButtonAnimator.Play(buttonFadeIn);
				}
				catch
				{
				}
			}
		}

		public void AddNewItem()
		{
			WindowItem item = new WindowItem();
			windows.Add(item);
		}
	}
}
