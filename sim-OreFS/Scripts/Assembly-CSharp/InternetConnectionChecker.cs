using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class InternetConnectionChecker : MonoBehaviour
{
	[Header("Settings")]
	[Tooltip("Bağlantı kontrol aralığı (saniye)")]
	public float checkInterval = 5f;

	[Tooltip("Ping timeout süresi (saniye)")]
	public float pingTimeout = 3f;

	[Tooltip("Test için kullanılacak URL")]
	public string testUrl = "https://www.google.com";

	[Header("Status")]
	[SerializeField]
	private bool _hasInternet;

	private Coroutine checkRoutine;

	public static InternetConnectionChecker Instance { get; private set; }

	public bool HasInternet => _hasInternet;

	public event Action<bool> OnConnectionStatusChanged;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		StartCoroutine(CheckConnectionOnce(null));
		checkRoutine = StartCoroutine(PeriodicCheck());
	}

	private void OnDestroy()
	{
		if (checkRoutine != null)
		{
			StopCoroutine(checkRoutine);
		}
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void CheckNow(Action<bool> callback = null)
	{
		StartCoroutine(CheckConnectionOnce(callback));
	}

	private IEnumerator PeriodicCheck()
	{
		while (true)
		{
			yield return new WaitForSeconds(checkInterval);
			yield return CheckConnectionOnce(null);
		}
	}

	private IEnumerator CheckConnectionOnce(Action<bool> callback)
	{
		bool previousStatus = _hasInternet;
		bool result = false;
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			result = false;
		}
		else
		{
			yield return TestConnection(delegate(bool success)
			{
				result = success;
			});
		}
		_hasInternet = result;
		if (previousStatus != _hasInternet)
		{
			Debug.Log($"[InternetConnectionChecker] Bağlantı durumu değişti: {_hasInternet}");
			this.OnConnectionStatusChanged?.Invoke(_hasInternet);
		}
		callback?.Invoke(_hasInternet);
	}

	private IEnumerator TestConnection(Action<bool> callback)
	{
		using UnityWebRequest request = UnityWebRequest.Head(testUrl);
		request.timeout = (int)pingTimeout;
		yield return request.SendWebRequest();
		bool obj = request.result == UnityWebRequest.Result.Success;
		callback?.Invoke(obj);
	}

	public static bool IsConnected()
	{
		if (Instance != null)
		{
			return Instance.HasInternet;
		}
		return Application.internetReachability != NetworkReachability.NotReachable;
	}
}
