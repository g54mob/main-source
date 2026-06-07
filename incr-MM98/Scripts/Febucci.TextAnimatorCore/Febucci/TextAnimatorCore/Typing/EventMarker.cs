namespace Febucci.TextAnimatorCore.Typing
{
	public class EventMarker : MarkerBase
	{
		public EventMarker(int index, string name, string[] parameters, int internalOrder)
			: base(name, index, internalOrder, parameters)
		{
		}
	}
}
