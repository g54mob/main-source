using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine;

namespace AeLa.EasyFeedback.FormFields
{
	internal class DropdownField : FormField
	{
		[Tooltip("The label to prepend to this field on the report (won't be included if left blank)")]
		public string Label;

		private IDropdown sourceField;

		public override void Awake()
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
