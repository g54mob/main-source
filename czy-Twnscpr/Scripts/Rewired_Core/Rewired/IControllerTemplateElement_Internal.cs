using System.Collections.Generic;

namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IControllerTemplateElement_Internal
	{
		IControllerTemplate parent { get; }

		int elementCount { get; }

		IControllerTemplateElement GetElement(int index);

		int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
	}
}
