using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine;

namespace AeLa.EasyFeedback.FormFields
{
	internal class TextField : FormField
	{
		[Tooltip("The label to prepend to this field on the report (won't be included if left blank)")]
		public string Label;

		private IInputField sourceField;

		private string lastValue;

		public override void Awake()
		{
		}

		private void OnValueChanged(string val)
		{
		}

		protected override void FormClosed()
		{
		}

		protected override void FormOpened()
		{
		}

		protected override void FormSubmitted()
		{
		}
	}
}
