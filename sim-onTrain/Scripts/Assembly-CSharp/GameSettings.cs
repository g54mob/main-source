using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{
	public int inventorySlotSize = 16;

	[Range(0f, 1f)]
	public float buildItemRemoveRefundPercentage = 0.5f;

	[Header("Remove/Dismantle")]
	public float removeHoldDuration = 1f;

	public float dismantleHoldDuration = 0.5f;

	[Header("Progressive Loot")]
	[Tooltip("Sound play interval while looting progressive items (seconds)")]
	public float progressiveLootSoundInterval = 1f;

	[Header("Grabbable Object Colors")]
	[Tooltip("Yerleştirilebilir alanlar için renk (yeşil)")]
	public Color placeableColor = new Color(0f, 1f, 0f, 0.5f);

	[Tooltip("Yerleştirilemez alanlar için renk (kırmızı)")]
	public Color unplaceableColor = new Color(1f, 0f, 0f, 0.5f);

	[Tooltip("Gece görünürlüğü için emisyon şiddeti")]
	[Range(0f, 5f)]
	public float grabEmissionIntensity = 1.5f;

	[Header("Player Spawn")]
	[Tooltip("Kaydedilen pozisyon trene bu mesafeden uzaksa, oyuncu trende spawn olur")]
	public float maxDistanceFromTrain = 50f;

	[Header("Sleep")]
	[Tooltip("Oyuncunun uyuyabileceği başlangıç saati (örn. 20 = akşam 8)")]
	[Range(0f, 24f)]
	public float sleepStartHour = 20f;

	[Tooltip("Uyku bitiş saati / sabah saati (örn. 6 = sabah 6)")]
	[Range(0f, 24f)]
	public float sleepEndHour = 6f;

	public bool IsNightTime(float hour)
	{
		if (sleepStartHour > sleepEndHour)
		{
			if (!(hour >= sleepStartHour))
			{
				return hour <= sleepEndHour;
			}
			return true;
		}
		if (hour >= sleepStartHour)
		{
			return hour <= sleepEndHour;
		}
		return false;
	}
}
