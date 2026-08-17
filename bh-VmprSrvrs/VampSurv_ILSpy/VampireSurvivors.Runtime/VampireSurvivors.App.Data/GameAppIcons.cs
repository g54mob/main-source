using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data;

public class GameAppIcons : ScriptableObject
{
	private AppIconData _IOSAppIcons;

	private AppIconData _ArcadeAppIcons;

	public AppIconData IOSAppIcons => _IOSAppIcons;

	public AppIconData ArcadeAppIcons => _ArcadeAppIcons;
}
