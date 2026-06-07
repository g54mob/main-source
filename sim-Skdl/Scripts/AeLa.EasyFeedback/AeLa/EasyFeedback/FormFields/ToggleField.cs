using UnityEngine;
using UnityEngine.UI;

namespace AeLa.EasyFeedback.FormFields
{
	[RequireComponent(typeof(Toggle))]
	internal class ToggleField : FormField
	{
		[Tooltip("The label to prepend to this field on the report (won't be included if left blank)")]
		public string Label;

		[Tooltip("The default value of the toggle")]
		public bool Default;

		private Toggle sourceField;

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
