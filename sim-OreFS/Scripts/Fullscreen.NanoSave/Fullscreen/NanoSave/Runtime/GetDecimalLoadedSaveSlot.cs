using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Loaded Save Slot")]
	[Category("NanoSave/Loaded Save Slot")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Returns the currently loaded save slot.")]
	public class GetDecimalLoadedSaveSlot : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalLoadedSaveSlot());

		public override string String => "Loaded Save Slot";

		public override double Get(Args args)
		{
			return GetLoadedSlot();
		}

		public override double Get(GameObject gameObject)
		{
			return GetLoadedSlot();
		}

		private double GetLoadedSlot()
		{
			return Singleton<SaveLoadManager>.Instance?.SlotLoaded ?? (-1);
		}
	}
}
