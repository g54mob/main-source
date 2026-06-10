using NSMedieval.Components;
using UnityEngine;

namespace NSMedieval.StructurePresets
{
	public class StructurePresetInputListener : InputListener
	{
		private Vector3 dragStartPos;

		private bool dragSelectionStarted;

		public StructurePresetInputListener()
			: base(InputListenerType.StructurePreset)
		{
		}
	}
}
