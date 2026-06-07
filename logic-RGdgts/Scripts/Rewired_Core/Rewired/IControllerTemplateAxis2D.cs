using UnityEngine;

namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IControllerTemplateAxis2D : IControllerTemplateElement
	{
		Vector2 value { get; }

		Vector2 valuePrev { get; }

		IControllerTemplateAxis horizontal { get; }

		IControllerTemplateAxis vertical { get; }
	}
}
