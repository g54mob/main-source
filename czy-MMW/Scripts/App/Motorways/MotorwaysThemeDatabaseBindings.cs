using Motorways.Themes;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(menuName = "Motorways/Theme/Theme Database Bindings")]
	public class MotorwaysThemeDatabaseBindings : ScriptableObject
	{
		[SerializeField]
		public PerGroupMaterialBindings perGroupMaterials;

		[SerializeField]
		[Space(20f)]
		public ThemeMaterialCollection materialCollection;

		public Theme colorblindThemeColorful;

		public Theme colorblindThemeDark;

		public int GetPerGroupThemeTargetForMaterial(Material materialToCompare)
		{
			for (int i = 0; i < perGroupMaterials.materialBindings.Length; i++)
			{
				if (materialToCompare == perGroupMaterials.materialBindings[i])
				{
					return i;
				}
			}
			return -1;
		}
	}
}
