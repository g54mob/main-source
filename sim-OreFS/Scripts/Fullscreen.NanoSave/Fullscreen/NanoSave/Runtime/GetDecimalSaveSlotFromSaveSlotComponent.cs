using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Save Slot From SaveSlotComponent")]
	[Category("NanoSave/Save Slot From SaveSlotComponent")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Extracts the slot number from a SaveSlotComponent.")]
	public class GetDecimalSaveSlotFromSaveSlotComponent : PropertyTypeGetDecimal
	{
		[SerializeField]
		private PropertyGetGameObject m_TargetGameObject = new PropertyGetGameObject();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalSaveSlotFromSaveSlotComponent());

		public override string String => "Save Slot From Component";

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
			SaveSlotComponent component = target.GetComponent<SaveSlotComponent>();
			if (component == null)
			{
				return 0.0;
			}
			if (int.TryParse(component.slotNumber, out var result))
			{
				return result;
			}
			return 0.0;
		}
	}
}
