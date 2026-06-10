using System.Collections.Generic;
using UnityEngine;

public class DesktopApp : CruncherAppContent
{
	public GameObject desktopIconPrefab;

	public List<DesktopIconController> spawnedIcons;

	public override void OnSetup()
	{
	}

	public void UpdateIcons()
	{
	}

	public void OnDesktopAppSelect(CruncherAppPreset newApp)
	{
	}
}
