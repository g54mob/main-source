using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(LocalizeStringHandler))]
public class RefreshLocalizedString : MonoBehaviour
{
	[SerializeField]
	private float interval = 1f;

	private LocalizeStringHandler _handler;

	private CancellationTokenSource _cts;

	private void Awake()
	{
		_handler = GetComponent<LocalizeStringHandler>();
	}

	private void OnEnable()
	{
		RefreshInterval(this.GenerateToken(ref _cts)).Forget();
	}

	private void OnDisable()
	{
		this.CancelToken(ref _cts);
	}

	private async UniTaskVoid RefreshInterval(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			_handler.AssetReference.RefreshString();
			await UniTask.WaitForSeconds(interval, ignoreTimeScale: false, PlayerLoopTiming.Update, token, cancelImmediately: true);
		}
	}
}
