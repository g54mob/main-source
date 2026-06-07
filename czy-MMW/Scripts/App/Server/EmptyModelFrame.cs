using Factory;

namespace Server
{
	public class EmptyModelFrame : IFrame
	{
		public void Reset()
		{
		}

		public bool CloneInto(IFrame cloneState, IScope scope)
		{
			return true;
		}
	}
}
