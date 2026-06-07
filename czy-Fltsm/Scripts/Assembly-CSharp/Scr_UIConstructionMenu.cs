using UnityEngine;

public class Scr_UIConstructionMenu : MonoBehaviour
{
	public enum Type
	{
		None = 0,
		Architect = 1
	}

	private Animator _animator;

	private CanvasGroup _canvasGroup;

	public Type MenuType;

	public bool IsOpen
	{
		get
		{
			return _animator.GetBool("IsOpen");
		}
		set
		{
			_animator.SetBool("IsOpen", value);
		}
	}

	public void Awake()
	{
		_animator = GetComponent<Animator>();
		_canvasGroup = GetComponent<CanvasGroup>();
	}

	public void Update()
	{
		if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
		{
			CanvasGroup canvasGroup = _canvasGroup;
			bool blocksRaycasts = (_canvasGroup.interactable = false);
			canvasGroup.blocksRaycasts = blocksRaycasts;
		}
		else
		{
			CanvasGroup canvasGroup2 = _canvasGroup;
			bool blocksRaycasts = (_canvasGroup.interactable = true);
			canvasGroup2.blocksRaycasts = blocksRaycasts;
		}
	}
}
