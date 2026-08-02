using System.Collections;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(Animator))]
	public class ButtonFrame : MonoBehaviour
	{
		public enum ButtonType
		{
			ButtonManager = 0,
			PanelButton = 1
		}

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private ButtonManager buttonManager;

		[SerializeField]
		private PanelButton panelButton;

		[SerializeField]
		private ButtonType buttonType;

		private void Start()
		{
			if ((buttonType == ButtonType.ButtonManager && buttonManager == null) || (buttonType == ButtonType.PanelButton && panelButton == null))
			{
				return;
			}
			if (animator == null)
			{
				animator = GetComponent<Animator>();
			}
			if (buttonType == ButtonType.ButtonManager)
			{
				buttonManager.onHover.AddListener(delegate
				{
					DoIn();
				});
				buttonManager.onLeave.AddListener(delegate
				{
					DoOut();
				});
				buttonManager.onSelect.AddListener(delegate
				{
					DoIn();
				});
				buttonManager.onDeselect.AddListener(delegate
				{
					DoOut();
				});
			}
			else if (buttonType == ButtonType.PanelButton)
			{
				panelButton.onHover.AddListener(delegate
				{
					DoIn();
				});
				panelButton.onLeave.AddListener(delegate
				{
					DoOut();
				});
				panelButton.onSelect.AddListener(delegate
				{
					DoOut();
				});
			}
			animator.enabled = false;
		}

		public void DoIn()
		{
			animator.enabled = true;
			animator.CrossFade("In", 0.15f);
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		public void DoOut()
		{
			animator.enabled = true;
			animator.CrossFade("Out", 0.15f);
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSecondsRealtime(HeatUIInternalTools.GetAnimatorClipLength(animator, "ButtonFrame_In"));
			animator.enabled = false;
		}
	}
}
