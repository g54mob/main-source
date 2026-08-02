using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	public class NavigationBar : MonoBehaviour
	{
		public enum UpdateMode
		{
			DeltaTime = 0,
			UnscaledTime = 1
		}

		public enum BarDirection
		{
			Top = 0,
			Bottom = 1
		}

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private UpdateMode updateMode;

		[SerializeField]
		private BarDirection barDirection;

		[SerializeField]
		private bool fadeButtons;

		[SerializeField]
		private Transform buttonParent;

		private float cachedStateLength = 0.4f;

		private List<PanelButton> buttons = new List<PanelButton>();

		private void Awake()
		{
			if (animator == null)
			{
				GetComponent<Animator>();
			}
			if (canvasGroup == null)
			{
				GetComponent<CanvasGroup>();
			}
			if (fadeButtons && buttonParent != null)
			{
				FetchButtons();
			}
			cachedStateLength = HeatUIInternalTools.GetAnimatorClipLength(animator, "NavigationBar_TopShow") + 0.02f;
		}

		private void OnEnable()
		{
			Show();
		}

		public void FetchButtons()
		{
			buttons.Clear();
			foreach (Transform item in buttonParent)
			{
				if (item.GetComponent<PanelButton>() != null)
				{
					PanelButton component = item.GetComponent<PanelButton>();
					component.navbar = this;
					buttons.Add(component);
				}
			}
		}

		public void LitButtons(PanelButton source = null)
		{
			foreach (PanelButton button in buttons)
			{
				if (!button.isSelected && (!(source != null) || !(button == source)))
				{
					button.IsInteractable(value: true);
				}
			}
		}

		public void DimButtons(PanelButton source)
		{
			foreach (PanelButton button in buttons)
			{
				if (!button.isSelected && !(button == source))
				{
					button.IsInteractable(value: false);
				}
			}
		}

		public void Show()
		{
			animator.enabled = true;
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
			if (barDirection == BarDirection.Top)
			{
				animator.Play("Top Show");
			}
			else if (barDirection == BarDirection.Bottom)
			{
				animator.Play("Bottom Show");
			}
		}

		public void Hide()
		{
			animator.enabled = true;
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
			if (barDirection == BarDirection.Top)
			{
				animator.Play("Top Hide");
			}
			else if (barDirection == BarDirection.Bottom)
			{
				animator.Play("Bottom Hide");
			}
		}

		private IEnumerator DisableAnimator()
		{
			if (updateMode == UpdateMode.DeltaTime)
			{
				yield return new WaitForSeconds(cachedStateLength);
			}
			else
			{
				yield return new WaitForSecondsRealtime(cachedStateLength);
			}
			animator.enabled = false;
		}
	}
}
