using System.Diagnostics;
using System.Text.RegularExpressions;
using PugMod;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Scripting;

public class PreviewVersionText : MonoBehaviour
{
	private static bool _forceVisible;

	private readonly Regex _versionRegex = new Regex("^(\\d+)\\.(\\d+)\\.(\\d+)\\.(\\d+)");

	public PugText text;

	private void Awake()
	{
		string fullVersion = Manager.fullVersion;
		Match match = _versionRegex.Match(Manager.fullVersion);
		fullVersion = ((!match.Success) ? Manager.fullVersion : match.Value);
		text.localize = false;
		text.SetText(fullVersion);
	}

	private void LateUpdate()
	{
		if (!ShouldBeShown())
		{
			text.gameObject.SetActive(value: false);
			return;
		}
		text.gameObject.SetActive(value: true);
		if (Manager.sceneHandler != null && Manager.sceneHandler.isInGame && !Manager.menu.IsAnyMenuActive())
		{
			base.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		}
		else
		{
			base.transform.localScale = Vector3.one;
		}
	}

	private bool ShouldBeShown()
	{
		if (_forceVisible)
		{
			return true;
		}
		if (Manager.menu != null && Manager.menu.IsAnyMenuActive())
		{
			return !(Manager.menu.GetTopMenu() is RadicalMainMenu);
		}
		return false;
	}

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Conditional("PUG_USE_STEAM")]
	[Conditional("UNITY_MICROSOFT_PC")]
	[Conditional("UNITY_EPIC")]
	[CommandWithModSupport("ui.showVersionText", "Enable or disable version text.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetVersionText(bool trueOrFalse)
	{
		_forceVisible = trueOrFalse;
		if (_forceVisible)
		{
			Manager.menu.quantumConsole.LogToConsole("The current version number (" + Manager.fullVersion + ") is now displayed in the top right of the screen.");
		}
	}
}
