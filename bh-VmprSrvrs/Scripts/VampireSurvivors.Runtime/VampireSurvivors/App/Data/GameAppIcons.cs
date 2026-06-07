using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data
{
	[CreateAssetMenu(fileName = "GameAppIcons", menuName = "VampireSurvivors/New GameAppIcons")]
	public class GameAppIcons : ScriptableObject
	{
		[SerializeField]
		private AppIconData _IOSAppIcons;

		[SerializeField]
		private AppIconData _ArcadeAppIcons;

		public AppIconData IOSAppIcons => null;

		public AppIconData ArcadeAppIcons => null;
	}
}
