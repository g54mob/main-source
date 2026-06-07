using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public struct ElementMultiplier
	{
		[Tooltip("ID of the Element")]
		public StatElement element;

		[Tooltip("Multiplier applied when interacting with other elements.\nGreater than 1 means is weak agains this element.\nLess than one means is resistant to this element")]
		public FloatReference multiplier;

		public ElementMultiplier(StatElement element)
		{
			this.element = element;
			multiplier = new FloatReference(2f);
		}

		public ElementMultiplier(StatElement element, float value)
		{
			this.element = element;
			multiplier = new FloatReference(value);
		}
	}
}
