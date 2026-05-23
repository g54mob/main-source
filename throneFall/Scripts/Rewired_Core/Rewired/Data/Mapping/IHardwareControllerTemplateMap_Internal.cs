using System;
using Rewired.Interfaces;

namespace Rewired.Data.Mapping
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IHardwareControllerTemplateMap_Internal
	{
		string name { get; }

		Guid typeGuid { get; }

		string typeKey { get; }

		int GetElementIdentifierCount();

		IControllerTemplateElementIdentifier GetTemplateElementIdentifier(int index);

		IControllerTemplateElementIdentifier GetTemplateElementIdentifierById(int elementIdentifierId);

		IControllerTemplateMapSpecialElement_Internal GetSpecialTemplateElementByElementIdentifierId(int id);

		JuxAmvlvwOWoqJaGcoORwookXVmr GetAxisTarget(Controller controller, int elementIdentifierId);

		JuxAmvlvwOWoqJaGcoORwookXVmr GetButtonTarget(Controller controller, int elementIdentifierId);
	}
}
