using System;
using Rewired.Interfaces;

namespace Rewired.Data.Mapping
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IHardwareControllerTemplateMap_Internal
	{
		string name { get; }

		Guid typeGuid { get; }

		int GetElementIdentifierCount();

		IControllerTemplateElementIdentifier GetTemplateElementIdentifier(int index);

		IControllerTemplateElementIdentifier GetTemplateElementIdentifierById(int elementIdentifierId);

		IControllerTemplateMapSpecialElement_Internal GetSpecialTemplateElementByElementIdentifierId(int id);

		ZLAHcRAlswBmLISIGDdywYeRahfS GetAxisTarget(Controller controller, int elementIdentifierId);

		ZLAHcRAlswBmLISIGDdywYeRahfS GetButtonTarget(Controller controller, int elementIdentifierId);
	}
}
