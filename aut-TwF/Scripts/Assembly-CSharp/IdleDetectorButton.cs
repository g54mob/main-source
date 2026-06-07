using TMPro;
using UnityEngine;

public class IdleDetectorButton : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI idleAmountText;

	private IdleManager idleManager;

	private int idleAmount;

	private int currentIndex;

	private int IdleAmount
	{
		get
		{
			return idleAmount;
		}
		set
		{
			idleAmount = value;
			idleAmount = Mathf.Max(idleAmount, 0);
			if (idleAmount > 0)
			{
				base.transform.SetChildrenActive(active: true);
				idleAmountText.text = idleAmount.ToString();
			}
			else
			{
				base.transform.SetChildrenActive(active: false);
			}
		}
	}

	private IdleManager IdleManager
	{
		get
		{
			if (!idleManager)
			{
				idleManager = LTFunctionLibrary.GetLTGameManager().IdleManager;
			}
			return idleManager;
		}
	}

	private void OnEnable()
	{
		IdleManager.onDetectorStartIdle += OnDetectorStartIdle;
		IdleManager.onDetectorStopIdle += OnDetectorStopIdle;
		IdleAmount = IdleManager.GetCurrentlyIdleDetectorsAmount();
	}

	private void OnDisable()
	{
		IdleManager.onDetectorStartIdle -= OnDetectorStartIdle;
		IdleManager.onDetectorStopIdle -= OnDetectorStopIdle;
	}

	private void OnDetectorStartIdle(IdleDetector detector)
	{
		IdleAmount++;
	}

	private void OnDetectorStopIdle(IdleDetector detector)
	{
		IdleAmount--;
	}

	public void OnButtonPressed()
	{
		LTFunctionLibrary.GetLTPlayerController().CenterCameraOnNextIdleBuilding();
	}
}
