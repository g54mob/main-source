using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Themes
{
	[CreateAssetMenu(menuName = "Motorways/Themes/DeleteModeOverrideList")]
	public class DeleteModeOverrideList : ScriptableObject
	{
		public List<ThemedMaterialType> themeTypesToOverride = new List<ThemedMaterialType>();
	}
}
