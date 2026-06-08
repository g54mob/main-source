using System;

namespace Bindito.Core.Internal
{
	public interface IBindingAnalyser
	{
		BindingAnalysis Analyse(Type suspectType, ProvisionBinding suspectProvisionBinding);
	}
}
