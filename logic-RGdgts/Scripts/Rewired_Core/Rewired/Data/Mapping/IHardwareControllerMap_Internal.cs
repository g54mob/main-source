using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired.Data.Mapping
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IHardwareControllerMap_Internal
	{
		IEnumerable<IControllerElementIdentifierCommon_Internal> ElementIdentifiers { get; }

		IControllerElementIdentifierCommon_Internal GetElementIdentifier(int id);
	}
}
