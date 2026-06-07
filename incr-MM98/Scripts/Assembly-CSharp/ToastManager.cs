using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;

public class ToastManager : MonoSingleton<ToastManager>
{
	[SerializeField]
	private Transform toastParent;

	[SerializeField]
	private Toast toastPrefab;

	private BehaviourPool<Toast> _toastPool;

	private void Awake()
	{
		_toastPool = new BehaviourPool<Toast>(toastPrefab, toastParent);
		_toastPool.Prewarm(3);
	}

	public Toast ShowToast(LocalizedString title, LocalizedString description, Sprite sprite, Action callback, float autoDismissDuration = -1f)
	{
		Toast toast = _toastPool.Rent();
		toast.Setup(title, description, sprite, callback);
		toast.transform.SetAsLastSibling();
		if (autoDismissDuration > 0f)
		{
			UniTaskUtility.Delayed(autoDismissDuration, delegate
			{
				_toastPool.Return(toast);
			}, this.GetCancellationTokenOnDestroy()).Forget();
		}
		return toast;
	}

	public void HideToast(Toast toast)
	{
		_toastPool.Return(toast);
	}
}
