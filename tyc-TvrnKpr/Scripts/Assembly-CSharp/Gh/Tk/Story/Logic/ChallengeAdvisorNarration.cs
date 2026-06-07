using System;
using UnityEngine;

namespace Gh.Tk.Story.Logic
{
	[Serializable]
	public struct ChallengeAdvisorNarration
	{
		public int progressPercentageThreshold;

		[TextArea(2, 5)]
		public string text;

		public AdvisorState advisorState;
	}
}
