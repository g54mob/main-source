using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Modifier Defaults", fileName = "ModifierDefaults")]
public class ModifierDefaults : ScriptableObject
{
	[Serializable]
	public struct Entry
	{
		public ModifierType modifier;

		public double value;

		public ModifierFormat format;

		public int digits;

		public string Preview => LocalizedModifierList.FormatModifier(value, digits, format);

		private Color GetColor()
		{
			if (value != 0.0)
			{
				return Color.skyBlue;
			}
			return Color.white;
		}
	}

	public List<Entry> defaults = new List<Entry>();

	private void LoadModifierTypes()
	{
		List<Entry> old = defaults.ToList();
		defaults.Clear();
		defaults.AddRange(from x in EnumUtility.GetValuesSkipNone<ModifierType>()
			select new Entry
			{
				modifier = x,
				value = old.FirstOrDefault((Entry y) => y.modifier == x).value
			});
	}
}
