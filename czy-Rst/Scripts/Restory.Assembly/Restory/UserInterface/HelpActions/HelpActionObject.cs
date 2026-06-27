using System.Collections.Generic;
using Restory.Data.Remapping;
using Rewired;
using UnityEngine;

namespace Restory.UserInterface.HelpActions
{
	[CreateAssetMenu(menuName = "Restory/HelpActions/HelpActionButtonObject", fileName = "HelpActionButtonObject", order = 0)]
	public class HelpActionObject : ScriptableObject
	{
		[SerializeField]
		private List<HelpActionElementObject> inputActionButtons = new List<HelpActionElementObject>();

		[SerializeField]
		private Restory.Data.Remapping.InputAction inputAction;

		[SerializeField]
		private AxisRange axisRange;

		[SerializeField]
		private string nameLocalizationID;

		public List<HelpActionElementObject> InputActionButtons => inputActionButtons;

		public string LocalizationNameKey => nameLocalizationID;
	}
}
