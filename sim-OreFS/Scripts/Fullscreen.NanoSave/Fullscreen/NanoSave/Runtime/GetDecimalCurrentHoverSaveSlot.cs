using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Current Hover Save Slot")]
	[Category("NanoSave/Current Hover Save Slot")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Gets the slot number from the current hovered save slot in the component SaveSlotLoaderUI.")]
	public class GetDecimalCurrentHoverSaveSlot : PropertyTypeGetDecimal
	{
		[SerializeField]
		private PropertyGetGameObject m_TargetGameObject = new PropertyGetGameObject();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalCurrentHoverSaveSlot());

		public override string String => "Current Hover Save Slot";

		public override double Get(Args args)
		{
			return GetSlotNumber(m_TargetGameObject.Get(args));
		}

		public override double Get(GameObject gameObject)
		{
			return GetSlotNumber(m_TargetGameObject.Get(gameObject));
		}

		private double GetSlotNumber(GameObject target)
		{
			if (target == null)
			{
				return 0.0;
			}
			SaveSlotLoaderUI component = target.GetComponent<SaveSlotLoaderUI>();
			if (component == null || component.CurrentHoverSaveSlot == null)
			{
				return 0.0;
			}
			if (int.TryParse(component.CurrentHoverSaveSlot.GetSlotNumber(), out var result))
			{
				return result;
			}
			return 0.0;
		}
	}
}
