using System;
using System.IO;
using System.Linq;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Total Save Slot Count")]
	[Category("NanoSave/Total Save Slots Count")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Returns the number of save slots.")]
	public class GetDecimalSaveSlotCount : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalSaveSlotCount());

		public override string String => "Save Slot Count";

		public override double Get(Args args)
		{
			return GetSlotCount();
		}

		public override double Get(GameObject gameObject)
		{
			return GetSlotCount();
		}

		private double GetSlotCount()
		{
			string path = Path.Combine(Application.persistentDataPath, "Saves");
			if (!Directory.Exists(path))
			{
				return 0.0;
			}
			return (from folder in Directory.GetDirectories(path)
				select Path.GetFileName(folder) into name
				select name.Substring(name.Length - 4)).Count((string num) => int.TryParse(num, out var result) && result > 0);
		}
	}
}
