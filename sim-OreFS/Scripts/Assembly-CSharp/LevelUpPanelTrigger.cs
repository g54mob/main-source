using System.Collections;
using UnityEngine;

public class LevelUpPanelTrigger : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private LevelUpPanel levelUpPanel;

	private bool isSubscribed;

	private readonly WaitForSeconds waitInterval = new WaitForSeconds(0.1f);

	private void Start()
	{
		StartCoroutine(WaitForFactoryManager());
	}

	private IEnumerator WaitForFactoryManager()
	{
		int attemptCount = 0;
		while (FactoryManager.Instance == null)
		{
			attemptCount++;
			Debug.Log($"[LevelUpPanelTrigger] FactoryManager.Instance bekleniyor... Deneme: {attemptCount}");
			yield return waitInterval;
		}
		FactoryManager.Instance.onRealLevelUp.AddListener(OnRealLevelUp);
		isSubscribed = true;
		Debug.Log($"[LevelUpPanelTrigger] FactoryManager.Instance bulundu ve listener eklendi. (Toplam {attemptCount} deneme)");
	}

	private void OnDestroy()
	{
		if (isSubscribed && FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onRealLevelUp.RemoveListener(OnRealLevelUp);
		}
	}

	private void OnRealLevelUp(int newLevel)
	{
		if (levelUpPanel != null)
		{
			levelUpPanel.Show(newLevel);
		}
	}

	public void TriggerForLevel(int level)
	{
		if (levelUpPanel != null)
		{
			levelUpPanel.Show(level);
		}
	}

	[ContextMenu("Test: Trigger Level 1")]
	private void TestTriggerLevel1()
	{
		TriggerForLevel(1);
	}

	[ContextMenu("Test: Trigger Level 2")]
	private void TestTriggerLevel2()
	{
		TriggerForLevel(2);
	}

	[ContextMenu("Test: Trigger Level 3")]
	private void TestTriggerLevel3()
	{
		TriggerForLevel(3);
	}
}
