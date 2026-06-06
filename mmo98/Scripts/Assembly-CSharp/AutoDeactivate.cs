using System.Threading;
using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
	[SerializeField]
	private float delay;

	private CancellationTokenSource _cts;

	private void OnEnable()
	{
		UniTaskUtility.Delayed(delay, delegate
		{
			base.gameObject.SetActive(value: false);
		}, this.GenerateToken(ref _cts)).Forget();
	}

	private void OnDisable()
	{
		this.CancelToken(ref _cts);
	}
}
