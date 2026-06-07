using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways.Themes
{
	[CreateAssetMenu(menuName = "Motorways/Themes/ThemeGroup")]
	public class ThemeGroup : ScriptableObject
	{
		[Tooltip("An optional name to help with identifying what this is.")]
		public string title;

		public List<ThemedColor> themedColors;

		public ThemeGroup()
		{
			themedColors = new List<ThemedColor>();
		}

		public ThemedColor ThemeColorFor(ThemedMaterialType colorType)
		{
			return themedColors.Find((ThemedColor col) => col.MaterialType == colorType);
		}

		[Button(null)]
		public void UpdateTheme()
		{
		}
	}
}
