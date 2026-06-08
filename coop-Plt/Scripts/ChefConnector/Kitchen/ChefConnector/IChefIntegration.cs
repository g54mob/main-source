using System;

namespace Kitchen.ChefConnector
{
	public interface IChefIntegration
	{
		bool Handle(ChefCommandUpdate update);

		void SendMessages(Action<string> send);
	}
}
