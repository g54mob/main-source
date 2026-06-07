using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBadge : MonoBehaviour
{
	private class BadgeItem
	{
		public Achievements.Achievement achievement;

		public bool progressIndicator;

		public int progressCurrent;

		public int progressMax;

		public BadgeItem(Achievements.Achievement achievement, bool progressIndicator, int progressCurrent = 0, int progressMax = 0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}

	public Achievements achievements;

	public Image image;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI titleText;

	public GameObject progressContainer;

	public Image progressBar;

	public TextMeshProUGUI progressText;

	private Queue<BadgeItem> queuedItems;

	public void Show(Achievements.Achievement achievement)
	{
	}

	public void ShowProgress(Achievements.Achievement achievement)
	{
	}

	public void ShowProgress(Achievements.Achievement achievement, int current, int max)
	{
	}

	private void ShowItem(BadgeItem item)
	{
	}

	private void ShowNextItem()
	{
	}

	private void OnDisable()
	{
	}
}
