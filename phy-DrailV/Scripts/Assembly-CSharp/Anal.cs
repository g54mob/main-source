using System;
using System.Collections;
using System.Collections.Generic;
using DV;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Anal : MonoBehaviour
{
	private static Anal _inst;

	private const int SEND_PREFERRED_TRACKING_MODE_TIMEOUT_SECONDS = 120;

	private int usedCoupleButton;

	private int usedDecoupleButton;

	private IEnumerator trackingModeCoro;

	[NonSerialized]
	public bool loggingEnabled;

	[NonSerialized]
	public bool sendingEnabled;

	public static Anal instance
	{
		get
		{
			if (_inst == null)
			{
				_inst = UnityEngine.Object.FindObjectOfType<Anal>();
				if (_inst == null)
				{
					GameObject obj = new GameObject("[Analytics]");
					_inst = obj.AddComponent<Anal>();
					UnityEngine.Object.DontDestroyOnLoad(obj);
				}
			}
			return _inst;
		}
	}

	private IEnumerator Start()
	{
		yield return WaitFor.SecondsRealtime(5f);
		SendStats();
		if (VRManager.IsVREnabled())
		{
			EnqueueSendPreferredTrackingMode();
		}
		sendingEnabled = true;
		loggingEnabled = false;
		if (DevUtil.IsDevMachine())
		{
			sendingEnabled = false;
		}
	}

	public static void EnqueueSendPreferredTrackingMode()
	{
		if (instance.trackingModeCoro != null)
		{
			instance.StopCoroutine(instance.trackingModeCoro);
		}
		instance.trackingModeCoro = SendPreferredTrackingModeCoro();
		instance.StartCoroutine(instance.trackingModeCoro);
	}

	private static IEnumerator SendPreferredTrackingModeCoro()
	{
		Log("enqueued SendPreferredTrackingModeCoro for seated=" + GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType));
		yield return WaitFor.SecondsRealtime(120f);
		Send("trackingMode", new Dictionary<string, object> { 
		{
			"seated",
			GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType)
		} });
	}

	public static void SendStats()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string model = XRDevice.model;
		string value = (string.IsNullOrEmpty(model) ? "notfound" : model);
		dictionary.Add("gpu", SystemInfo.graphicsDeviceName);
		dictionary.Add("gpuVendor", SystemInfo.graphicsDeviceVendor);
		dictionary.Add("gpuRam", SystemInfo.graphicsMemorySize);
		dictionary.Add("os", SystemInfo.operatingSystem);
		dictionary.Add("cpuFreq", SystemInfo.processorFrequency);
		dictionary.Add("cpu", SystemInfo.processorType);
		dictionary.Add("ram", SystemInfo.systemMemorySize);
		dictionary.Add("hmd", value);
		dictionary.Add("buildDest", BuildInfo.BUILD_DESTINATION);
		dictionary.Add("buildVer", BuildInfo.BUILD_VERSION_STR);
		Send("envStats", dictionary);
	}

	public static void Derailed(TrainCar car)
	{
		Vector3 velocity = car.GetComponent<Rigidbody>().velocity;
		Send("derailed", new Dictionary<string, object>
		{
			{
				"carType",
				car.carType.ToString()
			},
			{
				"position",
				car.gameObject.transform.position
			},
			{ "velocity", velocity },
			{
				"kmh",
				velocity.magnitude * 3.6f
			}
		});
	}

	public static void Coupled()
	{
		instance.usedCoupleButton++;
		if (instance.usedCoupleButton == 1 || instance.usedCoupleButton == 10 || instance.usedCoupleButton == 50)
		{
			Send("coupleButtonUsed", new Dictionary<string, object> { { "timesUsed", instance.usedCoupleButton } });
		}
	}

	public static void Decoupled()
	{
		instance.usedDecoupleButton++;
		if (instance.usedDecoupleButton == 1 || instance.usedDecoupleButton == 10 || instance.usedDecoupleButton == 50)
		{
			Send("decoupleButtonUsed", new Dictionary<string, object> { { "timesUsed", instance.usedDecoupleButton } });
		}
	}

	public static void GoalReached(bool success, string goalId)
	{
		string value = SceneManager.GetActiveScene().name;
		Send("goalReached", new Dictionary<string, object>
		{
			{ "success", success },
			{ "goalId", goalId },
			{ "mapName", value }
		});
	}

	public static void MissionEnded(bool success)
	{
		string value = SceneManager.GetActiveScene().name;
		Send("missionEnded", new Dictionary<string, object>
		{
			{ "success", success },
			{ "mapName", value }
		});
	}

	public static void CoupleBroken(Coupler coupler)
	{
		int num = -1;
		try
		{
			num = (coupler.train.derailed ? 1 : 0) + (coupler.GetOppositeCoupler().train.derailed ? 1 : 0);
		}
		catch (Exception message)
		{
			Debug.LogError(message);
		}
		Send("coupleBroken", new Dictionary<string, object> { { "attachedCarsDerailed", num } });
	}

	public static void UsedDerailerScript()
	{
		Send("usedDerailerScript");
	}

	public static void UsedPerfTogglerScript()
	{
		Send("usedPerfTogglerScript");
	}

	public static void UsedSpotTeleporterScript()
	{
		Send("usedSpotTeleporterScript");
	}

	private static void Log(string firstLine, Dictionary<string, object> data = null)
	{
		if (!instance.loggingEnabled)
		{
			return;
		}
		string text = "";
		if (data != null)
		{
			foreach (KeyValuePair<string, object> datum in data)
			{
				text = text + "\n  " + datum.Key + ": " + datum.Value;
			}
		}
		Debug.Log("[ANALYTICS] " + firstLine + text);
	}

	private static void Send(string eventName, Dictionary<string, object> data = null)
	{
	}
}
