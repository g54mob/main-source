using UnityEngine;

namespace TH20
{
	public interface ISilverUnlockable
	{
		ISilverUnlockToken SilverUnlockToken { get; }

		int SilverCost();

		LocalisedString GetUnlockName();

		LocalisedString GetUnlockMessage();

		Sprite GetUnlockIcon();

		ESandboxCheckType GetSandboxCheckType();
	}
}
