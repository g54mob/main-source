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

		int GetElementIdentifierCount();

		IControllerTemplateElementIdentifier GetTemplateElementIdentifier(int index);

		IControllerTemplateElementIdentifier GetTemplateElementIdentifierById(int elementIdentifierId);

		IControllerTemplateMapSpecialElement_Internal GetSpecialTemplateElementByElementIdentifierId(int id);

		ZsogrZyhQfaSnqVtBlGOmbxOuQc GetAxisTarget(Controller controller, int elementIdentifierId);

		ZsogrZyhQfaSnqVtBlGOmbxOuQc GetButtonTarget(Controller controller, int elementIdentifierId);
	}
}
