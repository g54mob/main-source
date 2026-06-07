using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Lean.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanSelectableByFinger")]
	[AddComponentMenu("Lean/Touch/Lean Selectable By Finger")]
	public class LeanSelectableByFinger : LeanSelectable
	{
		public enum UseType
		{
			AllFingers = 0,
			OnlySelectingFingers = 1,
			IgnoreSelectingFingers = 2
		}

		public struct SelectedPair
		{
			public LeanSelectByFinger Select;

			public LeanFinger Finger;
		}

		[Serializable]
		public class LeanFingerEvent : UnityEvent<LeanFinger>
		{
		}

		[Serializable]
		public class LeanSelectFingerEvent : UnityEvent<LeanSelectByFinger, LeanFinger>
		{
		}

		[SerializeField]
		private UseType use;

		[SerializeField]
		private LeanFingerEvent onSelectedFinger;

		[SerializeField]
		private LeanFingerEvent onSelectedFingerUp;

		[SerializeField]
		private LeanSelectFingerEvent onSelectedSelectFinger;

		[SerializeField]
		private LeanSelectFingerEvent onSelectedSelectFingerUp;

		[NonSerialized]
		private List<SelectedPair> selectingPairs;

		public UseType Use
		{
			get
			{
				return default(UseType);
			}
			set
			{
			}
		}

		public LeanFingerEvent OnSelectedFinger => null;

		public LeanFingerEvent OnSelectedFingerUp => null;

		public LeanSelectFingerEvent OnSelectedSelectFinger => null;

		public LeanSelectFingerEvent OnSelectedSelectFingerUp => null;

		public LeanFinger SelectingFinger => null;

		public List<SelectedPair> SelectingPairs => null;

		private bool AnyFingersSet => false;

		public static event Action<LeanSelectByFinger, LeanSelectableByFinger, LeanFinger> OnAnySelectedFinger
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

		public void SelectSelf(LeanFinger finger)
		{
		}

		public static List<LeanFinger> GetFingers(bool ignoreIfStartedOverGui, bool ignoreIfOverGui, int requiredFingerCount = 0, LeanSelectable requiredSelectable = null)
		{
			return null;
		}

		public static LeanSelectableByFinger FindSelectable(LeanFinger finger)
		{
			return null;
		}

		public bool IsSelectedBy(LeanFinger finger)
		{
			return false;
		}

		public static void InvokeAnySelectedFinger(LeanSelectByFinger select, LeanSelectableByFinger selectable, LeanFinger finger)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void HandleFingerUp(LeanFinger finger)
		{
		}
	}
}
