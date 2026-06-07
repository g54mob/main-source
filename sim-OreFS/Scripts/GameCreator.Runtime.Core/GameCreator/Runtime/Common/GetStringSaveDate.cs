using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Slot Save Date")]
	[Category("Storage/Slot Save Date")]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Green)]
	[Description("Returns the save date of a slot in the specified format")]
	[Example("General: 01/28/1990 00:01")]
	[Example("Short Date: 01/28/1990")]
	[Example("Long Date: Sunday, 28 January 1990")]
	public class GetStringSaveDate : PropertyTypeGetString
	{
		private enum DateFormat
		{
			General = 0,
			ShortDate = 1,
			LongDate = 2
		}

		[SerializeField]
		private PropertyGetInteger m_Slot = new PropertyGetInteger(1);

		[SerializeField]
		private DateFormat m_Format;

		public static PropertyGetString Create => new PropertyGetString(new GetStringSaveDate());

		public override string String => $"Slot {m_Slot} Date";

		public override string Get(Args args)
		{
			int slot = (int)m_Slot.Get(args);
			string saveDate = Singleton<SaveLoadManager>.Instance.GetSaveDate(slot);
			if (string.IsNullOrEmpty(saveDate))
			{
				return string.Empty;
			}
			DateTime dateTime = DateTime.Parse(saveDate);
			return m_Format switch
			{
				DateFormat.General => dateTime.ToString("g"), 
				DateFormat.ShortDate => dateTime.ToString("d"), 
				DateFormat.LongDate => dateTime.ToString("D"), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
