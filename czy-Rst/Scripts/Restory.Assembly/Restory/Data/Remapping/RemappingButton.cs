using System;
using Rewired;
using UnityEngine;

namespace Restory.Data.Remapping
{
	[Serializable]
	public struct RemappingButton
	{
		[SerializeField]
		private InputAction action;

		[SerializeField]
		private AxisRange axisRange;

		[Space]
		[SerializeField]
		private string nameKey;

		public InputAction Action => action;

		public AxisRange AxisRange => axisRange;

		public string NameKey => nameKey;

		public RemappingButton(InputAction action, string nameKey)
			: this(action, AxisRange.Positive, nameKey)
		{
		}

		public RemappingButton(InputAction action, AxisRange axisRange, string nameKey)
		{
			this.action = action;
			this.axisRange = axisRange;
			this.nameKey = nameKey;
		}
	}
}
