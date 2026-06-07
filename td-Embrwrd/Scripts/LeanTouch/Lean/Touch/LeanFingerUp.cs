using System.Collections.Generic;
using UnityEngine;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanFingerUp")]
	[AddComponentMenu("Lean/Touch/Lean Finger Up")]
	public class LeanFingerUp : LeanFingerDown
	{
		[SerializeField]
		private bool ignoreIsOverGui;

		private List<LeanFinger> fingers;

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

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override bool UseFinger(LeanFinger finger)
		{
			return false;
		}

		protected override void HandleFingerDown(LeanFinger finger)
		{
		}

		protected virtual void HandleFingerUp(LeanFinger finger)
		{
		}
	}
}
