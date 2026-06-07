using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void PlayFadeOut()
	{
		_animator.SetTrigger("FadeOut");
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
