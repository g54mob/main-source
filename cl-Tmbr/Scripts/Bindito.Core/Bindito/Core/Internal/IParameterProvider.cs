using System.Reflection;

namespace Bindito.Core.Internal
{
	public interface IParameterProvider
	{
		object[] GetParameters(MethodBase method);
	}
}
