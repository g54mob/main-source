using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class SetupManager : MonoBehaviour
	{
		[Serializable]
		public class StepItem
		{
			public string title = "Step";

			public ImageFading background;

			public Animator indicator;

			public Animator panel;

			public StepContent content;
		}

		public enum StepContent
		{
			Default = 0,
			Information = 1,
			Privacy = 2
		}

		public List<StepItem> steps = new List<StepItem>();

		public UserManager userManager;

		[SerializeField]
		private Animator setupScreen;

		[SerializeField]
		private TMP_InputField firstNameInput;

		[SerializeField]
		private TMP_InputField lastNameInput;

		[SerializeField]
		private TMP_InputField passwordInput;

		[SerializeField]
		private TMP_InputField passwordRetypeInput;

		[SerializeField]
		private TMP_InputField secQuestionInput;

		[SerializeField]
		private TMP_InputField secAnswerInput;

		private int currentStepIndex;

		private int newStepIndex;

		private float cachedSetupLength = 1f;

		private float cachedPanelLength = 1f;

		private float cachedIndicatorLength = 1f;

		private Animator currentIndicator;

		private Animator currentPanel;

		private Animator nextPanel;

		private ImageFading currentBackground;

		private ImageFading nextBackground;

		private string panelFadeIn = "Panel In";

		private string panelFadeOut = "Panel Out";

		private string indicatorCheck = "Check";

		private void Awake()
		{
			cachedSetupLength = DreamOSInternalTools.GetAnimatorClipLength(setupScreen, "SetupScreen_In") + 0.1f;
			cachedPanelLength = DreamOSInternalTools.GetAnimatorClipLength(steps[currentStepIndex].panel, "StepPanel_In") + 0.1f;
			if (steps[currentStepIndex].indicator != null)
			{
				cachedIndicatorLength = DreamOSInternalTools.GetAnimatorClipLength(steps[currentStepIndex].indicator, "StepIndicator_Done") + 0.1f;
			}
		}

		private void OnEnable()
		{
			InitializeSteps();
		}

		public void InitializeSteps()
		{
			setupScreen.enabled = true;
			setupScreen.Play("In");
			currentStepIndex = 0;
			currentPanel = steps[currentStepIndex].panel;
			currentPanel.enabled = true;
			currentPanel.gameObject.SetActive(value: true);
			currentPanel.Play(panelFadeIn);
			if (steps[currentStepIndex].background != null)
			{
				steps[currentStepIndex].background.FadeIn();
			}
			for (int i = 0; i < steps.Count; i++)
			{
				if (steps[i].panel == null)
				{
					continue;
				}
				if (steps[i].indicator != null)
				{
					steps[i].indicator.enabled = true;
				}
				if (i != currentStepIndex)
				{
					steps[i].panel.gameObject.SetActive(value: false);
					if (steps[i].background != null)
					{
						steps[i].background.gameObject.SetActive(value: false);
					}
				}
			}
			StartCoroutine("DisableSetupAnimator");
			StartCoroutine("DisableAnimators");
			StartCoroutine("DisableIndicatorAnimators");
			firstNameInput.text = "";
			lastNameInput.text = "";
			passwordInput.text = "";
			passwordRetypeInput.text = "";
			secQuestionInput.text = "";
			secAnswerInput.text = "";
		}

		private void Update()
		{
			if (userManager == null)
			{
				return;
			}
			if (steps[currentStepIndex].content == StepContent.Information)
			{
				if (firstNameInput.text.Length >= userManager.minNameCharacter && firstNameInput.text.Length <= userManager.maxNameCharacter)
				{
					userManager.nameOK = true;
					if (lastNameInput.text.Length >= userManager.minNameCharacter && lastNameInput.text.Length <= userManager.maxNameCharacter)
					{
						userManager.lastNameOK = true;
					}
					else
					{
						userManager.lastNameOK = false;
					}
				}
				else
				{
					userManager.nameOK = false;
				}
			}
			else
			{
				if (steps[currentStepIndex].content != StepContent.Privacy)
				{
					return;
				}
				if ((passwordInput.text.Length >= userManager.minPasswordCharacter && passwordInput.text.Length <= userManager.maxPasswordCharacter) || passwordInput.text.Length == 0)
				{
					userManager.passwordOK = true;
					if (passwordInput.text != passwordRetypeInput.text)
					{
						userManager.passwordRetypeOK = false;
					}
					else if (passwordInput.text == passwordRetypeInput.text)
					{
						userManager.passwordRetypeOK = true;
					}
				}
				else
				{
					userManager.passwordOK = false;
				}
			}
		}

		public void SetStep(string newStep)
		{
			bool flag = false;
			for (int i = 0; i < steps.Count; i++)
			{
				if (steps[i].title == newStep)
				{
					newStepIndex = i;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Debug.LogWarning("There is no step named '" + newStep + "' in the step list.", this);
			}
			else if (newStepIndex != currentStepIndex)
			{
				currentPanel = steps[currentStepIndex].panel;
				if (steps[currentStepIndex].indicator != null)
				{
					currentIndicator = steps[currentStepIndex].indicator;
					currentIndicator.enabled = true;
					currentIndicator.Play(indicatorCheck);
					StopCoroutine("DisableIndicatorAnimators");
					StartCoroutine("DisableIndicatorAnimators");
				}
				if (steps[currentStepIndex].background != null)
				{
					currentBackground = steps[currentStepIndex].background;
					currentBackground.FadeOut();
				}
				currentStepIndex = newStepIndex;
				nextPanel = steps[currentStepIndex].panel;
				nextPanel.gameObject.SetActive(value: true);
				if (steps[currentStepIndex].background != null)
				{
					nextBackground = steps[currentStepIndex].background;
					nextBackground.FadeIn();
				}
				currentPanel.enabled = true;
				nextPanel.enabled = true;
				currentPanel.Play(panelFadeOut);
				nextPanel.Play(panelFadeIn);
				StopCoroutine("DisablePreviousPanel");
				StartCoroutine("DisablePreviousPanel");
				StopCoroutine("DisableAnimators");
				StartCoroutine("DisableAnimators");
			}
		}

		public void SetStepByIndex(int stepIndex)
		{
			if (stepIndex > steps.Count || stepIndex < 0)
			{
				Debug.LogWarning("Index '" + stepIndex + "' doesn't exist.", this);
				return;
			}
			for (int i = 0; i < steps.Count; i++)
			{
				if (steps[i].title == steps[stepIndex].title)
				{
					SetStep(steps[stepIndex].title);
					break;
				}
			}
		}

		public void NextStep()
		{
			if (currentStepIndex <= steps.Count - 2)
			{
				SetStepByIndex(currentStepIndex + 1);
			}
		}

		public void PrevStep()
		{
			if (currentStepIndex >= 1)
			{
				SetStepByIndex(currentStepIndex - 1);
			}
		}

		public void FinishUp()
		{
			userManager.SetUserCreated(value: true);
			userManager.SetFirstName(firstNameInput);
			userManager.SetLastName(lastNameInput);
			userManager.SetPassword(passwordInput);
			userManager.SetSecurityQuestion(secQuestionInput);
			userManager.SetSecurityAnswer(secAnswerInput);
			currentIndicator = steps[currentStepIndex].indicator;
			currentIndicator.enabled = true;
			currentIndicator.Play(indicatorCheck);
			setupScreen.enabled = true;
			setupScreen.Play("Out");
			userManager.bootManager.Reboot();
		}

		private IEnumerator DisablePreviousPanel()
		{
			yield return new WaitForSeconds(cachedPanelLength + 0.1f);
			for (int i = 0; i < steps.Count; i++)
			{
				if (i != currentStepIndex)
				{
					steps[i].panel.gameObject.SetActive(value: false);
				}
			}
		}

		private IEnumerator DisableSetupAnimator()
		{
			yield return new WaitForSeconds(cachedSetupLength + 0.1f);
			setupScreen.enabled = false;
		}

		private IEnumerator DisableAnimators()
		{
			yield return new WaitForSeconds(cachedPanelLength + 0.1f);
			if (currentPanel != null)
			{
				currentPanel.enabled = false;
			}
			if (nextPanel != null)
			{
				nextPanel.enabled = false;
			}
		}

		private IEnumerator DisableIndicatorAnimators()
		{
			yield return new WaitForSeconds(cachedIndicatorLength + 0.1f);
			for (int i = 0; i < steps.Count; i++)
			{
				if (!(steps[i].indicator == null))
				{
					steps[i].indicator.enabled = false;
				}
			}
		}
	}
}
