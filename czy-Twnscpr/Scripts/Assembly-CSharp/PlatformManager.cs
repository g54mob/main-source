using FuryStudios.FurySDK.Settings;
using UnityEngine;

public sealed class PlatformManager : MonoBehaviour
{
	[SerializeField]
	private PlatformSettings settings;

	public static long? LastSignedInUserID;

	private bool pausingWhileConstrained;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void SDK_OnResumed()
	{
	}

	private void SignIn()
	{
	}
}
