using System;
using System.Collections.Generic;
using Lean.Common;
using UnityEngine;

namespace Lean.Touch
{
	[Serializable]
	public class LeanFingerFilter
	{
		public enum FilterType
		{
			AllFingers = 0,
			ManuallyAddedFingers = 1
		}

		public FilterType Filter;

		public bool IgnoreStartedOverGui;

		public int RequiredFingerCount;

		public int RequiredMouseButtons;

		public LeanSelectable RequiredSelectable;

		[NonSerialized]
		private List<LeanFinger> fingers;

		[NonSerialized]
		private List<LeanFinger> filteredFingers;

		public LeanFingerFilter(bool newIgnoreStartedOverGui)
		{
		}

		public LeanFingerFilter(FilterType newFilter, bool newIgnoreStartedOverGui, int newRequiredFingerCount, int newRequiredMouseButtons, LeanSelectable newRequiredSelectable)
		{
		}

		public void UpdateRequiredSelectable(GameObject gameObject)
		{
		}

		public void AddFinger(LeanFinger finger)
		{
		}

		public void RemoveFinger(LeanFinger finger)
		{
		}

		public void RemoveAllFingers()
		{
		}

		public List<LeanFinger> UpdateAndGetFingers(bool ignoreUpFingers = false)
		{
			return null;
		}

		private static bool SimulatedFingersExist(List<LeanFinger> fingers)
		{
			return false;
		}
	}
}
