using System;
using System.IO;
using System.Linq;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Highest Save Slot")]
	[Category("NanoSave/Highest Save Slots")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Returns the highest existing save slot number.")]
	public class GetDecimalHighestSaveSlot : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalHighestSaveSlot());

		public override string String => "Highest Save Slot";

		public override double Get(Args args)
		{
			return GetHighestSlot();
		}

		public override double Get(GameObject gameObject)
		{
			return GetHighestSlot();
		}

		private double GetHighestSlot()
		{
			string path = Path.Combine(Application.persistentDataPath, "Saves");
			if (!Directory.Exists(path))
			{
				return 0.0;
			}
			string[] directories = Directory.GetDirectories(path);
			if (directories.Length == 0)
			{
				return 0.0;
			}
			return (from num in (from folder in directories
					select Path.GetFileName(folder) into name
					select name.Substring(name.Length - 4) into num
					where int.TryParse(num, out var result) && result > 0
					select num).Select(int.Parse)
				orderby num descending
				select num).FirstOrDefault();
		}
	}
}
