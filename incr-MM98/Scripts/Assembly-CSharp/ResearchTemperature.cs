using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(LocalizeStringHandler))]
public class ResearchTemperature : MonoBehaviour
{
	[SerializeField]
	private float interval = 3f;

	private void Awake()
	{
		ChangeTemperature(this.GetCancellationTokenOnDestroy()).Forget();
	}

	private async UniTaskVoid ChangeTemperature(CancellationToken token)
	{
		LocalizeStringHandler handler = GetComponent<LocalizeStringHandler>();
		while (true)
		{
			await UniTask.WaitForSeconds(interval, ignoreTimeScale: false, PlayerLoopTiming.Update, token, cancelImmediately: true);
			handler.RefreshString();
		}
	}
}
