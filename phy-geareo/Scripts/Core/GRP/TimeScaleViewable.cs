using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class TimeScaleViewable : Viewable
	{
		[TextCrew]
		public StateSelector<string> value;

		public State<float> timeScale;

		public TimeScaleViewable(State<float> scale)
		{
		}
	}
}
