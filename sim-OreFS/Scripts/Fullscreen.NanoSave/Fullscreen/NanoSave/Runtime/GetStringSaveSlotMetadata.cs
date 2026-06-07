using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Save Slot Metadata")]
	[Category("NanoSave/Save Slot Metadata")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Returns specified metadata from a save game slot")]
	public class GetStringSaveSlotMetadata : PropertyTypeGetString
	{
		public enum MetadataType
		{
			Timestamp = 0,
			Title = 1,
			Location = 2,
			Progression = 3,
			TotalPlaytime = 4,
			CharacterLevel = 5,
			AppVersion = 6
		}

		[SerializeField]
		private MetadataType m_MetadataType = MetadataType.Title;

		[SerializeField]
		private PropertyGetDecimal m_SlotNumber = new PropertyGetDecimal(1f);

		[HideInInspector]
		[SerializeField]
		private NanoSave m_Storage;

		public static PropertyGetString Create => new PropertyGetString(new GetStringSaveSlotMetadata());

		public override string String => $"Slot {m_SlotNumber} {m_MetadataType}";

		public override string Get(Args args)
		{
			if (m_Storage == null)
			{
				return string.Empty;
			}
			string slotNumber = ((int)m_SlotNumber.Get(args)).ToString("D4");
			var (text, text2, text3, text4, text5, text6, text7) = m_Storage.GetMetaDataForSlot(slotNumber);
			return m_MetadataType switch
			{
				MetadataType.Timestamp => text2 ?? "No Save Data", 
				MetadataType.Title => text ?? "Empty Slot", 
				MetadataType.Location => text3 ?? "Unknown Location", 
				MetadataType.Progression => text4 ?? "0%", 
				MetadataType.TotalPlaytime => text5 ?? "0h 0m", 
				MetadataType.CharacterLevel => text6 ?? "Level 1", 
				MetadataType.AppVersion => text7 ?? "0.0.0", 
				_ => string.Empty, 
			};
		}
	}
}
