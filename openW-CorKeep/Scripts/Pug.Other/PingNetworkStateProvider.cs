using System;
using System.Collections;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using PlayFab;
using UnityEngine;
using UnityEngine.Networking;

public class PingNetworkStateProvider : INetworkStateProvider
{
	private bool _hasNetwork;

	public bool HasNetworkConnection => _hasNetwork;

	public void HasNetworkConnectionWithCallback(Action<bool> callback)
	{
		UnityMainThreadDispatcher.Instance().StartCoroutine(HasNetworkConnectionWithCallbackIEnumerator(callback));
	}

	public async Task<bool> HasNetworkConnectionAsync()
	{
		bool hasFinishedNetworkCheck = false;
		await UnityMainThreadDispatcher.Instance().EnqueueAsync(delegate
		{
			UnityMainThreadDispatcher.Instance().StartCoroutine(HasNetworkConnectionWithCallbackIEnumerator(delegate
			{
				hasFinishedNetworkCheck = true;
			}));
		});
		while (!hasFinishedNetworkCheck)
		{
			await Task.Delay(200);
		}
		return _hasNetwork;
	}

	private IEnumerator HasNetworkConnectionWithCallbackIEnumerator(Action<bool> callback)
	{
		_hasNetwork = false;
		Ping cloudFlarePing = new Ping("1.1.1.1");
		Ping googlePing = new Ping("8.8.8.8");
		string url = "https://" + PlayFabSettings.staticSettings.TitleId + ".playfabapi.com";
		UnityWebRequest request = UnityWebRequest.Head(url);
		UnityWebRequestAsyncOperation requestOp = request.SendWebRequest();
		for (float timer = 0f; timer < 1f; timer += Time.deltaTime)
		{
			yield return null;
			if (requestOp.isDone)
			{
				if (request.result == UnityWebRequest.Result.ConnectionError)
				{
					Debug.LogWarning("Connection Error: " + request.error);
				}
				else if (request.result == UnityWebRequest.Result.DataProcessingError)
				{
					Debug.LogWarning("Data Processing Error: " + request.error);
				}
				else
				{
					if (request.result != UnityWebRequest.Result.ProtocolError)
					{
						Debug.Log("HEAD " + url + " succeeded");
						_hasNetwork = true;
						break;
					}
					Debug.LogWarning("HTTP Error: " + request.error);
				}
			}
			if (cloudFlarePing.isDone && cloudFlarePing.time >= 0)
			{
				Debug.Log("Ping to 1.1.1.1 succeeded");
				_hasNetwork = true;
				break;
			}
			if (googlePing.isDone && googlePing.time >= 0)
			{
				Debug.Log("ping 8.8.8.8 succeeded");
				_hasNetwork = true;
				break;
			}
		}
		cloudFlarePing.DestroyPing();
		googlePing.DestroyPing();
		request.Abort();
		callback?.Invoke(_hasNetwork);
	}
}
