using UnityEngine;

public class UnlockContentItemComponent : MonoBehaviour
{
	[SerializeField]
	private UIContentAnimator animator;

	private void Start()
	{
		animator.BeginWithNormalState();
		base.gameObject.SetActive(value: false);
		animator.OnFinishedReverse.AddListener(delegate
		{
			base.gameObject.SetActive(value: false);
		});
	}

	public void AddOffset(Vector3 offset)
	{
		Vector3 targetPosition = animator.GetTargetPosition() + offset;
		animator.SetTargetPosition(targetPosition);
	}

	public void ResetPosition()
	{
		animator.SetTargetPosition(Vector3.zero);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		animator.OnPlay();
	}

	public void Hide()
	{
		if (base.gameObject.activeInHierarchy)
		{
			animator.OnReverse();
		}
	}
}
