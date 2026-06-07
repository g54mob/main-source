using System;
using Rewired.Interfaces;

namespace Rewired.Data.Mapping
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IHardwareControllerTemplateMap_Internal
	{
		string name { get; }

		Guid typeGuid { get; }

		string typeKey { get; }

		int GetElementIdentifierCount();

		IControllerTemplateElementIdentifier GetTemplateElementIdentifier(int index);

		IControllerTemplateElementIdentifier GetTemplateElementIdentifierById(int elementIdentifierId);

		IControllerTemplateMapSpecialElement_Internal GetSpecialTemplateElementByElementIdentifierId(int id);

		fMlgSaItucfCTlOMuaOrAzViaQaCA GetAxisTarget(Controller controller, int elementIdentifierId);

		fMlgSaItucfCTlOMuaOrAzViaQaCA GetButtonTarget(Controller controller, int elementIdentifierId);
	}
}
