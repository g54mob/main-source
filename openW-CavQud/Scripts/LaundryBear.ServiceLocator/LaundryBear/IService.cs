using System.Collections;

namespace LaundryBear
{
	public interface IService
	{
		string Name { get; }

		ServiceLocator.ServiceInitializationStatus InitializationStatus { get; }

		IEnumerator Initialize(bool sync = false);
	}
}
