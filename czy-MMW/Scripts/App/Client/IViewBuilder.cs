using FixMath;
using Server;

namespace Client
{
	public interface IViewBuilder
	{
		void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp);
	}
}
