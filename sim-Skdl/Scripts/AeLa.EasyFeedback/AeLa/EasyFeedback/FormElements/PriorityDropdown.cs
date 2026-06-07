using System.Collections.Generic;
using AeLa.EasyFeedback.APIs;
using AeLa.EasyFeedback.UI.Interfaces;

namespace AeLa.EasyFeedback.FormElements
{
	public class PriorityDropdown : FormElement
	{
		private IDropdown priorityDropdown;

		private IEnumerable<Label> labels;

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
