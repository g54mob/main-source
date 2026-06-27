using Restory.Data.SaveLoad.Containers;

namespace Restory.Data.SaveLoad.CustomContextStateResolvers
{
	public interface IContextStateResolver
	{
		void Resolve(ContextState contextState);
	}
}
