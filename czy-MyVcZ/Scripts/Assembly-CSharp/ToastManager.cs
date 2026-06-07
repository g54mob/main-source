using UnityEngine;

public class ToastManager : MonoSingleton<ToastManager>
{
	[SerializeField]
	private ToastMessage _toastPrefab;

	public void ShowToast(string message)
	{
		Object.Instantiate(_toastPrefab, base.transform).SetMessage(message);
	}
}
