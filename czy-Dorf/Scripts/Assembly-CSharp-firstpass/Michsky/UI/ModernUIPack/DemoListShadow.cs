using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class DemoListShadow : MonoBehaviour
	{
		public Scrollbar listScrollbar;

		public bool isTop;

		private bool enableAnim;

		private Animator shadowAnimator;

		private void Start()
		{
			shadowAnimator = base.gameObject.GetComponent<Animator>();
			listScrollbar.value = 1f;
			if (!isTop)
			{
				shadowAnimator.Play("Out");
			}
			else
			{
				shadowAnimator.Play("In");
			}
		}

		private void Update()
		{
			if (isTop)
			{
				if (listScrollbar.value != 1f && enableAnim)
				{
					shadowAnimator.Play("In");
					listScrollbar.value = Mathf.Lerp(listScrollbar.value, 1f, 0.25f);
				}
				if (listScrollbar.value == 1f || listScrollbar.value >= 0.99f)
				{
					listScrollbar.value = 1f;
					shadowAnimator.Play("Out");
					enableAnim = false;
				}
				else if (listScrollbar.value != 1f)
				{
					shadowAnimator.Play("In");
				}
			}
			else
			{
				if (listScrollbar.value != 0f && enableAnim)
				{
					shadowAnimator.Play("In");
					listScrollbar.value = Mathf.Lerp(listScrollbar.value, 0f, 0.25f);
				}
				if (listScrollbar.value == 0f || listScrollbar.value <= 0.01f)
				{
					listScrollbar.value = 0f;
					shadowAnimator.Play("Out");
					enableAnim = false;
				}
				else if (listScrollbar.value != 0f)
				{
					shadowAnimator.Play("In");
				}
			}
		}

		public void ScrollUp()
		{
			enableAnim = true;
		}

		public void ScrollDown()
		{
			enableAnim = true;
		}
	}
}
