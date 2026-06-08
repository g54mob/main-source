using System;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class UnityServicesInitializer : MonoBehaviour
{
	public abstract class SSRPGService : MonoBehaviour
	{
		public abstract bool IsInitialized();

		public abstract void Initialize();
	}

	private float lastTimeInitialized;

	private void Initialize()
	{
		SSRPGService[] components = GetComponents<SSRPGService>();
		for (int i = 0; i < components.Length; i++)
		{
			if (!components[i].IsInitialized())
			{
				components[i].Initialize();
			}
		}
		lastTimeInitialized = Time.realtimeSinceStartup;
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus && Time.realtimeSinceStartup - lastTimeInitialized > 10f)
		{
			Initialize();
		}
	}

	private async void Start()
	{
		int num;
		if ((uint)num <= 1u)
		{
			try
			{
				await UnityServices.InitializeAsync();
				await AnalyticsService.Instance.CheckForRequiredConsents();
				Initialize();
			}
			catch (Exception ex)
			{
				Utils.LogError("Problem starting UnityServicesInitializer: " + ex.ToString());
			}
		}
	}
}
