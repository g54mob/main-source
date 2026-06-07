using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class MenuButtonAnimationController : MonoBehaviour
	{
		private Animator animator;

		private IClickable clickable;

		[InspectorButton("ResetAnimatorBools", true, true)]
		public bool resetAnimatorBools;

		protected virtual void Start()
		{
			animator = GetComponent<Animator>();
			clickable = GetComponent<IClickable>();
			if (animator == null)
			{
				Debug.LogError("MenuButtonAnimationController requires valid Animator reference to work properly. Disabling Self.", this);
				base.enabled = false;
			}
			else if (clickable == null)
			{
				Debug.LogError("MenuButtonAnimationController requires valid IClickable reference to work properly. Disabling Self.", this);
				base.enabled = false;
			}
			else
			{
				clickable.PressChanged += OnClickablePressed;
				clickable.HoverChanged += OnHoverChanged;
			}
		}

		protected virtual void OnClickablePressed(IClickable clickable)
		{
			if (clickable.IsPressed)
			{
				animator.SetBool("PressedAlt", value: true);
				return;
			}
			animator.SetBool("PressedAlt", value: false);
			animator.SetBool("HighlightedAlt", value: true);
		}

		protected virtual void OnHoverChanged(IHoverable hoverable)
		{
			if (hoverable.IsHovered)
			{
				animator.SetBool("HighlightedAlt", value: true);
			}
			else
			{
				TryResetAnimatorBools();
			}
		}

		public void TryResetAnimatorBools()
		{
			if ((bool)animator && !animator.GetBool("Disabled"))
			{
				ResetAnimatorBools();
			}
		}

		private void ResetAnimatorBools()
		{
			animator.SetBool("HighlightedAlt", value: false);
			animator.SetBool("PressedAlt", value: false);
			animator.SetBool("Normal", value: true);
		}
	}
}
