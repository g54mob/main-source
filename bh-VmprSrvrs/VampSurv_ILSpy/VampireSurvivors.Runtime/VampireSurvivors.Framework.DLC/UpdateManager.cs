using System;

namespace VampireSurvivors.Framework.DLC;

public class UpdateManager
{
	public void CheckForUpdates(Action callback)
	{
		SystemPlatform sInstance = SystemPlatform.sInstance;
		sInstance.m_CurrentSystem.UpdateInstalledDlc(callback);
	}
}
