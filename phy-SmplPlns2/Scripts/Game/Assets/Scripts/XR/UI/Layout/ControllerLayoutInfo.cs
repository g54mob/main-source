using System;
using Assets.Scripts.Input.XR;
using UnityEngine;

namespace Assets.Scripts.XR.UI.Layout
{
	[CreateAssetMenu(fileName = "Controller", menuName = "ControllerLayoutInfo", order = 1)]
	public class ControllerLayoutInfo : ScriptableObject
	{
		[Serializable]
		public struct ControlAssignments
		{
			[Serializable]
			public struct Assignment
			{
				public string Id;

				public string Name;
			}

			[SerializeField]
			public Assignment[] Assignments;

			public XRControlGripType GripType;

			public XRHandType HandType;
		}

		[SerializeField]
		private ControlAssignments[] _assignments;
	}
}
