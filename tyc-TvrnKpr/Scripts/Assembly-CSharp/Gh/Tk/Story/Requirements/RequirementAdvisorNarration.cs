using System;
using UnityEngine;

namespace Gh.Tk.Story.Requirements
{
	[Serializable]
	public struct RequirementAdvisorNarration
	{
		[TextArea(2, 5)]
		public string text;

		public AdvisorState advisorState;
	}
}
