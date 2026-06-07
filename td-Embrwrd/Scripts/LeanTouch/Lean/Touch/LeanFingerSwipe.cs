using Lean.Common;
using UnityEngine;

namespace Lean.Touch
{
	[AddComponentMenu("Lean/Touch/Lean Finger Swipe")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanFingerSwipe")]
	public class LeanFingerSwipe : LeanSwipeBase
	{
		[SerializeField]
		private bool ignoreStartedOverGui;

		[SerializeField]
		private bool ignoreIsOverGui;

		[SerializeField]
		private LeanSelectable requiredSelectable;

		public bool IgnoreStartedOverGui
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IgnoreIsOverGui
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LeanSelectable RequiredSelectable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void HandleFingerSwipe(LeanFinger finger)
		{
		}
	}
}
