using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Lean.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanSelectByFinger")]
	[AddComponentMenu("Lean/Touch/Lean Select By Finger")]
	public class LeanSelectByFinger : LeanSelect
	{
		[Serializable]
		public class LeanSelectableLeanFingerEvent : UnityEvent<LeanSelectable, LeanFinger>
		{
		}

		public LeanScreenQuery ScreenQuery;

		[SerializeField]
		private bool deselectWithFingers;

		[SerializeField]
		private LeanSelectableLeanFingerEvent onSelectedFinger;

		public bool DeselectWithFingers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LeanSelectableLeanFingerEvent OnSelectedFinger => null;

		public static event Action<LeanSelectByFinger, LeanSelectable, LeanFinger> OnAnySelectedFinger
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SelectStartScreenPosition(LeanFinger finger)
		{
		}

		public void SelectScreenPosition(LeanFinger finger)
		{
		}

		public void SelectScreenPosition(LeanFinger finger, Vector2 screenPosition)
		{
		}

		public void Select(LeanSelectable selectable, LeanFinger finger)
		{
		}

		protected virtual void Update()
		{
		}

		private bool ShouldRemoveSelectable(LeanSelectable selectable)
		{
			return false;
		}

		public void ReplaceSelection(List<LeanSelectable> newSelectables, LeanFinger finger)
		{
		}
	}
}
