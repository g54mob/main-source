namespace Febucci.TextAnimatorCore.Typing
{
	public sealed class ActionMarker : MarkerBase
	{
		public ActionMarker(int index, string name, string[] parameters, int internalOrder)
			: base(name, index, internalOrder, parameters)
		{
		}
	}
}
