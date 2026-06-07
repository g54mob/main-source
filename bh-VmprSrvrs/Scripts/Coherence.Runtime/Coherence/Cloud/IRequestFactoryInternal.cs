using Coherence.Runtime;

namespace Coherence.Cloud
{
	internal interface IRequestFactoryInternal : IRequestFactory
	{
		RequestThrottle Throttle { get; }
	}
}
