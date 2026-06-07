using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Component Selector")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/utilities/component-selector")]
	public class ComponentSelector : MonoBehaviour
	{
		public List<ComponentSet> internalComponents;

		public bool edit = true;

		public ComponentSet this[int index] => internalComponents[index];

		[ContextMenu("Show|Hide Editor")]
		private void ShowHideEditor()
		{
			edit = !edit;
		}

		private void Reset()
		{
			internalComponents = new List<ComponentSet>();
		}
	}
}
