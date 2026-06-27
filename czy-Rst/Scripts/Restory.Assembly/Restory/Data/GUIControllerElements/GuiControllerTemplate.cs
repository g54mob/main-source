using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine.Scripting;

namespace Restory.Data.GUIControllerElements
{
	[Preserve]
	public abstract class GuiControllerTemplate : SerializedScriptableObject, IGuiControllerTemplate
	{
		public abstract ControllerId ControllerId { get; }

		public abstract IReadOnlyList<IGuiControllerTemplateElement> Elements { get; }

		public abstract IGuiControllerTemplateElement GetElement(int elementId);

		public abstract bool TryGetElement(int elementId, out IGuiControllerTemplateElement element);
	}
}
