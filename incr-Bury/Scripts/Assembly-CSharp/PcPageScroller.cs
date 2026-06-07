using UnityEngine;

public class PcPageScroller : MonoBehaviour
{
	[SerializeField]
	private Vector2 yRange;

	[SerializeField]
	private float scrollAmountPerClick = 1f;

	[SerializeField]
	private GameObject upButton;

	[SerializeField]
	private GameObject downButton;

	private bool canAcceptDpad = true;

	private void OnEnable()
	{
		ResetPosition();
	}

	private void Update()
	{
		HandleScrollButtonsVisability();
		HandleScrollAndDPadInputs();
	}

	private void HandleScrollAndDPadInputs()
	{
		float num = InputManager.Singleton.inputActions.PlayerActionMap.ScrollPC.ReadValue<float>();
		if (canAcceptDpad)
		{
			if (num > 0f)
			{
				ScrollClick(_scrollUp: true);
			}
			else if (num < 0f)
			{
				ScrollClick(_scrollUp: false);
			}
			canAcceptDpad = false;
		}
		if (num == 0f)
		{
			canAcceptDpad = true;
		}
	}

	public void ScrollClick(bool _scrollUp)
	{
		float y = ((!_scrollUp) ? scrollAmountPerClick : (scrollAmountPerClick * -1f));
		MoveLocalPosition(y);
		AudioManager.Singleton.PlaySFX_MouseClick();
	}

	public void MoveLocalPosition(float _y)
	{
		Vector3 localPosition = new Vector3(base.transform.localPosition.x, Mathf.Clamp(base.transform.localPosition.y + _y, yRange.x, yRange.y), base.transform.localPosition.z);
		base.transform.localPosition = localPosition;
	}

	private void ResetPosition()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, yRange.x, base.transform.localPosition.z);
	}

	private void HandleScrollButtonsVisability()
	{
		upButton.SetActive(base.transform.localPosition.y > yRange.x);
		downButton.SetActive(base.transform.localPosition.y < yRange.y);
	}
}
