using System.Threading.Tasks;
using UnityEngine;

public class MicGuideScreen : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	private TaskCompletionSource<bool> _tcs;

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void PlayShowAnim()
	{
		base.gameObject.SetActive(value: true);
		_animator.SetTrigger("Show");
		_tcs = new TaskCompletionSource<bool>();
	}

	public Task WaitForEndMicGuideScreen()
	{
		if (_tcs != null)
		{
			return _tcs?.Task;
		}
		return Task.CompletedTask;
	}

	public void OnEndMicGuideScreen()
	{
		_tcs?.TrySetResult(result: true);
		Hide();
	}
}
