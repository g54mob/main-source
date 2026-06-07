using UnityEngine;

public class ISAdQualityInitCallbackWrapper : MonoBehaviour
{
	private ISAdQualityInitCallback mCallback;

	public ISAdQualityInitCallback AdQualityInitCallback
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void adQualitySdkInitSuccess()
	{
	}

	private void onAdQualitySdkInitFailed(ISAdQualityInitError sdkInitError, string errorMsg)
	{
	}
}
