using TMPro;
using UnityEngine;

public class TutorialSubStepItemUI : MonoBehaviour
{
	public Color defaultColor;

	public Color completedColor;

	public TextMeshProUGUI descriptionText;

	public TextMeshProUGUI countText;

	public GameObject countObj;

	public GameObject waitingForHost;

	private int targetCount = 1;

	private int currentCount;

	private bool _isHost;

	private bool _canClientComplete;

	public void Initialize(int target, bool canClientComplete = true, bool isHost = true)
	{
		targetCount = Mathf.Max(1, target);
		currentCount = 0;
		_isHost = isHost;
		_canClientComplete = canClientComplete;
		countText.text = $"({currentCount}/{targetCount})";
		countText.color = defaultColor;
		descriptionText.color = defaultColor;
		if (_isHost)
		{
			if (countObj != null)
			{
				countObj.SetActive(value: true);
			}
			if (waitingForHost != null)
			{
				waitingForHost.SetActive(value: false);
			}
			return;
		}
		bool flag = !_canClientComplete;
		if (countObj != null)
		{
			countObj.SetActive(!flag);
		}
		if (waitingForHost != null)
		{
			waitingForHost.SetActive(flag);
		}
	}

	public void SetCount(int current)
	{
		currentCount = current;
		countText.text = $"({currentCount}/{targetCount})";
		if (!_isHost && !_canClientComplete)
		{
			if (waitingForHost != null)
			{
				waitingForHost.SetActive(value: false);
			}
			if (countObj != null)
			{
				countObj.SetActive(value: true);
			}
		}
		if (currentCount >= targetCount)
		{
			SetSubStepDoneColor();
			SetCountTextDoneColor();
		}
	}

	public void SetDefault()
	{
		descriptionText.color = defaultColor;
		countText.text = $"(0/{targetCount})";
		countText.color = defaultColor;
	}

	public void SetSubStepDoneColor()
	{
		descriptionText.color = completedColor;
	}

	public void SetCountText()
	{
		countText.text = $"({targetCount}/{targetCount})";
	}

	public void SetCountTextDoneColor()
	{
		countText.color = completedColor;
	}
}
