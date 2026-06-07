using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class MonoBehaviourTokenExtensions
{
	public static CancellationToken GenerateToken(this MonoBehaviour behaviour, ref CancellationTokenSource source)
	{
		source?.Cancel();
		source?.Dispose();
		source = new CancellationTokenSource();
		return CancellationTokenSource.CreateLinkedTokenSource(source.Token, behaviour.GetCancellationTokenOnDestroy()).Token;
	}

	public static void CancelToken(this MonoBehaviour _, ref CancellationTokenSource source)
	{
		source?.Cancel();
		source?.Dispose();
		source = null;
	}
}
