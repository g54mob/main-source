using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(Animator))]
	public class QuestItem : MonoBehaviour
	{
		public enum DefaultState
		{
			Minimized = 0,
			Expanded = 1
		}

		public enum AfterMinimize
		{
			Disable = 0,
			Destroy = 1
		}

		[TextArea]
		public string questText = "Quest text here";

		public string localizationKey;

		[SerializeField]
		private Animator questAnimator;

		[SerializeField]
		private TextMeshProUGUI questTextObj;

		public bool useLocalization = true;

		[SerializeField]
		private bool updateOnAnimate = true;

		[Range(0f, 10f)]
		public float minimizeAfter = 3f;

		public DefaultState defaultState;

		public AfterMinimize afterMinimize;

		public UnityEvent onDestroy;

		private bool isOn;

		private LocalizedObject localizedObject;

		private void Start()
		{
			if (questAnimator == null)
			{
				questAnimator = GetComponent<Animator>();
			}
			if (useLocalization)
			{
				localizedObject = questTextObj.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
				else if (localizedObject != null && !string.IsNullOrEmpty(localizationKey))
				{
					questText = localizedObject.GetKeyOutput(localizationKey);
					localizedObject.onLanguageChanged.AddListener(delegate
					{
						questText = localizedObject.GetKeyOutput(localizationKey);
						UpdateUI();
					});
				}
			}
			if (defaultState == DefaultState.Minimized)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (defaultState == DefaultState.Expanded)
			{
				ExpandQuest();
			}
			UpdateUI();
		}

		public void UpdateUI()
		{
			questTextObj.text = questText;
		}

		public void AnimateQuest()
		{
			ExpandQuest();
		}

		public void ExpandQuest()
		{
			if (isOn)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				if (minimizeAfter != 0f)
				{
					StopCoroutine("MinimizeItem");
					StartCoroutine("MinimizeItem");
				}
				return;
			}
			isOn = true;
			base.gameObject.SetActive(value: true);
			questAnimator.enabled = true;
			questAnimator.Play("In");
			if (updateOnAnimate)
			{
				UpdateUI();
			}
			if (minimizeAfter != 0f)
			{
				StopCoroutine("MinimizeItem");
				StartCoroutine("MinimizeItem");
			}
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		public void MinimizeQuest()
		{
			if (isOn)
			{
				StopCoroutine("DisableAnimator");
				questAnimator.enabled = true;
				questAnimator.Play("Out");
				StopCoroutine("DisableItem");
				StartCoroutine("DisableItem");
			}
		}

		public void CompleteQuest()
		{
			afterMinimize = AfterMinimize.Destroy;
			MinimizeQuest();
		}

		public void DestroyQuest()
		{
			onDestroy.Invoke();
			Object.Destroy(base.gameObject);
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(HeatUIInternalTools.GetAnimatorClipLength(questAnimator, "QuestItem_In"));
			questAnimator.enabled = false;
		}

		private IEnumerator DisableItem()
		{
			yield return new WaitForSeconds(HeatUIInternalTools.GetAnimatorClipLength(questAnimator, "QuestItem_Out"));
			isOn = false;
			if (afterMinimize == AfterMinimize.Disable)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (afterMinimize == AfterMinimize.Destroy)
			{
				DestroyQuest();
			}
		}

		private IEnumerator MinimizeItem()
		{
			yield return new WaitForSeconds(minimizeAfter);
			MinimizeQuest();
		}
	}
}
