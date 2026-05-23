using UnityEngine;

namespace Data.Progression
{
	[CreateAssetMenu(fileName = "ProgressionManagerLocator", menuName = "Locators/ProgressionManagerLocator")]
	public class ProgressionManagerLocator : ScriptableObject
	{
		[HideInInspector]
		public ProgressionMonumentsManager ProgressionMonuments;

		[HideInInspector]
		public ProgressionModulesManager ProgressionModules;
	}
}
