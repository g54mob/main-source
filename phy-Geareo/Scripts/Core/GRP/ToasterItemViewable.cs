using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class ToasterItemViewable : Viewable
	{
		[TextCrew]
		public string toastMessage;

		public State<float> closeAt;

		public readonly float startTime;

		public float leftTime => 0f;

		public ToasterItemViewable(string message, float duration = 2f)
		{
		}

		[CrewMethod]
		public void Close()
		{
		}
	}
}
