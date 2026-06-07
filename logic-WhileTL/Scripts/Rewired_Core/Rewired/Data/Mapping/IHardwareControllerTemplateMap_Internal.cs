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

		int GetElementIdentifierCount();

		IControllerTemplateElementIdentifier GetTemplateElementIdentifier(int index);

		IControllerTemplateElementIdentifier GetTemplateElementIdentifierById(int elementIdentifierId);

		IControllerTemplateMapSpecialElement_Internal GetSpecialTemplateElementByElementIdentifierId(int id);

		KpZHreySesbtLKuRdoZrwgpLSyTA GetAxisTarget(Controller controller, int elementIdentifierId);

		KpZHreySesbtLKuRdoZrwgpLSyTA GetButtonTarget(Controller controller, int elementIdentifierId);
	}
}
