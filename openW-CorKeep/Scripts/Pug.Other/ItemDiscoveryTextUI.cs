using I2.Loc;
using Pug.UnityExtensions;
using UnityEngine;

public class ItemDiscoveryTextUI : MonoBehaviour
{
	public PugText pugText;

	private TimerSimple activeTimer = new TimerSimple(2f);

	private TimerSimple fadeTimer = new TimerSimple(1f, false, false);

	public LocalizedString newItemTerm = "newItem";

	private Color color;

	public ItemDiscoveryUI itemDiscoveryUI;

	public void Activate(string text, Rarity rarity, ItemDiscoveryUI itemDiscoveryUI)
	{
		this.itemDiscoveryUI = itemDiscoveryUI;
		itemDiscoveryUI.activeTexts.Add(this);
		pugText.formatFields = new string[1] { text };
		pugText.Render(newItemTerm);
		color = Manager.text.rarityTextColors[(int)(rarity + 1)];
		pugText.SetTempColor(color);
		activeTimer.Start();
		base.gameObject.SetActive(value: true);
	}

	private void Update()
	{
		if (!Manager.sceneHandler.isInGame)
		{
			base.gameObject.SetActive(value: false);
			activeTimer.Stop();
			fadeTimer.Stop();
			return;
		}
		if (activeTimer.isRunning && activeTimer.isTimerElapsed && (itemDiscoveryUI.activeTexts.Count == 0 || itemDiscoveryUI.activeTexts[0] == this))
		{
			activeTimer.Stop();
			fadeTimer.Start();
		}
		if (fadeTimer.isRunning)
		{
			if (!fadeTimer.isTimerElapsed)
			{
				Color color = this.color.ColorWithNewAlpha(fadeTimer.invElapsedRatio);
				pugText.SetTempColor(color);
			}
			else
			{
				Stop();
			}
		}
	}

	private void Stop()
	{
		itemDiscoveryUI.activeTexts.Remove(this);
		activeTimer.Stop();
		fadeTimer.Stop();
		base.gameObject.SetActive(value: false);
	}
}
