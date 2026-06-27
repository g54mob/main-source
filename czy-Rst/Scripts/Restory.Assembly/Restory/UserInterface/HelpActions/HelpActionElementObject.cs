using System;
using Restory.Data.Remapping;
using Rewired;
using UnityEngine;

namespace Restory.UserInterface.HelpActions
{
	[Serializable]
	public class HelpActionElementObject
	{
		[SerializeField]
		private Restory.Data.Remapping.InputAction inputAction;

		[SerializeField]
		private AxisRange axisRange = AxisRange.Positive;

		[SerializeField]
		private bool hold;

		public Restory.Data.Remapping.InputAction InputAction => inputAction;

		public AxisRange AxisRange => axisRange;

		public bool Hold => hold;

		public HelpActionElementObject(Restory.Data.Remapping.InputAction inputAction, AxisRange axisRange, bool hold)
		{
			this.inputAction = inputAction;
			this.axisRange = axisRange;
			this.hold = hold;
		}
	}
}
