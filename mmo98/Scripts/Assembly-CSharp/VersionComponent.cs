using UnityEngine;

[DefaultExecutionOrder(-500)]
public class VersionComponent : MonoBehaviour
{
	[SerializeField]
	private Version.Build hideIn;

	[SerializeField]
	private Version.Dlc requires;

	private void Awake()
	{
		if (hideIn.HasFlag(Version.Build.Full))
		{
			Object.DestroyImmediate(base.gameObject);
		}
		else if (requires.HasFlag(Version.Dlc.Supporter) && !SteamManager.User.DlcInstalled(4510400u))
		{
			Object.DestroyImmediate(base.gameObject);
		}
	}
}
