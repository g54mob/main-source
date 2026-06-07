using System;
using System.IO;
using System.Linq;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Next Save Slot")]
	[Category("NanoSave/Next Save Slot")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Gets the next available save slot")]
	public class GetDecimalNextSaveSlot : PropertyTypeGetDecimal
	{
		[SerializeField]
		private PropertyGetDecimal m_MaxSlots = new PropertyGetDecimal(9999f);

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalNextSaveSlot());

		public override string String => "Next Save Slot";

		public override double Get(Args args)
		{
			return GetNextSlot(args);
		}

		public override double Get(GameObject gameObject)
		{
			return GetNextSlot(Args.EMPTY);
		}

		private double GetNextSlot(Args args)
		{
			string path = Path.Combine(Application.persistentDataPath, "Saves");
			if (!Directory.Exists(path))
			{
				return 1.0;
			}
			string[] directories = Directory.GetDirectories(path);
			int maxSlots = (int)m_MaxSlots.Get(args);
			int[] array = (from result in (from folder in directories
					select Path.GetFileName(folder) into name
					select name.Substring(name.Length - 4) into s
					where int.TryParse(s, out var result) && result > 0 && result <= maxSlots
					select s).Select(int.Parse)
				orderby result
				select result).ToArray();
			int num = ((array.Length == 0) ? 1 : (array.Last() + 1));
			if (num > maxSlots)
			{
				return 1.0;
			}
			return num;
		}
	}
}
