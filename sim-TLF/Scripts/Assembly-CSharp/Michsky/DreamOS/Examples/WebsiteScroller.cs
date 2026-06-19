using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS.Examples
{
	public class WebsiteScroller : MonoBehaviour
	{
		public Scrollbar scrollbar;

		[Range(0.01f, 0.1f)]
		public float scrollSmooth = 0.01f;

		[Range(0.005f, 0.1f)]
		public float scrollHelper = 0.01f;

		private float scrollTo;

		private float scrollToHelper;

		private bool isHigher;

		private void Start()
		{
			base.enabled = false;
		}

		private void Update()
		{
			if (scrollbar.value != scrollTo)
			{
				scrollbar.value = Mathf.Lerp(scrollbar.value, scrollTo, scrollSmooth);
			}
			if ((isHigher && scrollbar.value >= scrollToHelper) || (!isHigher && scrollbar.value <= scrollToHelper))
			{
				base.enabled = false;
			}
		}

		public void ScrollTo(float value)
		{
			base.enabled = true;
			scrollTo = value;
			if (scrollbar.value >= scrollTo)
			{
				scrollToHelper = scrollTo + scrollHelper;
				isHigher = false;
			}
			else if (scrollbar.value <= scrollTo)
			{
				scrollToHelper = scrollTo - scrollHelper;
				isHigher = true;
			}
		}
	}
}
