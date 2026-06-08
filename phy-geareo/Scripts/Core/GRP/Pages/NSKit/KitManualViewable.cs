using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Pages.NSKit
{
	public class KitManualViewable : Viewable
	{
		[ViewCrew(typeof(KitStepView))]
		public StateSelector<KitStepViewable> step;

		[TextCrew]
		public StateSelector<string> stepText;

		[SliderCrew]
		public State<float> progress;

		public State<int> stepIndex;

		public Project project;

		public List<KitStepViewable> steps;

		public Kit kit;

		public KitManualViewable(Kit kit)
		{
		}

		[CrewMethod]
		public void Next()
		{
		}

		[CrewMethod]
		public void Previous()
		{
		}
	}
}
