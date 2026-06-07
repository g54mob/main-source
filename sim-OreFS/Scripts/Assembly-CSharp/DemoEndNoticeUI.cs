using System.Collections;
using UnityEngine;

public class DemoEndNoticeUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private GameObject panelObject;

	[SerializeField]
	private LevelUpPanel levelUpPanel;

	[Header("Settings")]
	[Tooltip("Level up paneli kapandıktan sonra bu kadar saniye bekler")]
	[SerializeField]
	private float delayAfterLevelUpPanel = 2f;

	private bool isSubscribed;

	private readonly WaitForSeconds waitInterval = new WaitForSeconds(0.1f);

	private void Start()
	{
		if (panelObject != null)
		{
			panelObject.SetActive(value: false);
		}
		StartCoroutine(WaitForFactoryManager());
	}

	private IEnumerator WaitForFactoryManager()
	{
		while (FactoryManager.Instance == null)
		{
			yield return waitInterval;
		}
		isSubscribed = true;
	}

	private void OnDestroy()
	{
		if (isSubscribed)
		{
			_ = FactoryManager.Instance != null;
		}
	}

	private void OnRealLevelUp(int newLevel)
	{
		if (newLevel >= 3 && SteamAppChecker.Instance != null && SteamAppChecker.Instance.IsDemo)
		{
			if (levelUpPanel != null && levelUpPanel.IsOpen)
			{
				StartCoroutine(WaitForLevelUpPanelThenShow());
			}
			else
			{
				StartCoroutine(ShowAfterDelay(delayAfterLevelUpPanel));
			}
		}
	}

	private IEnumerator WaitForLevelUpPanelThenShow()
	{
		while (levelUpPanel != null && levelUpPanel.IsOpen)
		{
			yield return null;
		}
		yield return new WaitForSeconds(delayAfterLevelUpPanel);
	}

	private IEnumerator ShowAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
	}

	private void ShowPanel()
	{
		if (panelObject != null)
		{
			panelObject.SetActive(value: true);
			Debug.Log("[DemoEndNoticeUI] Demo End Notice paneli açıldı.");
		}
	}

	public void ClosePanel()
	{
		if (panelObject != null)
		{
			panelObject.SetActive(value: false);
			Debug.Log("[DemoEndNoticeUI] Demo End Notice paneli kapatıldı.");
		}
	}
}
