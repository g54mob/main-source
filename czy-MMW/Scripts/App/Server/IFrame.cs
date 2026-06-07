using Factory;

namespace Server
{
	public interface IFrame
	{
		void Reset();

		bool CloneInto(IFrame cloneState, IScope scope);
	}
}
