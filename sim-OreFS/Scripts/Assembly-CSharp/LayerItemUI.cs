using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LayerItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Item ikonu")]
	[SerializeField]
	private Image itemIcon;

	[Tooltip("Item ismi")]
	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[Tooltip("Spawn rate yüzdesi")]
	[SerializeField]
	private TextMeshProUGUI spawnRateText;

	private T_ItemSO _itemSO;

	private float _spawnRate;

	private float _initialSpawnRate;

	public T_ItemSO ItemSO => _itemSO;

	public float SpawnRate => _spawnRate;

	public float InitialSpawnRate => _initialSpawnRate;

	public void Initialize(T_ItemSO itemSO, float normalizedSpawnRate)
	{
		_itemSO = itemSO;
		_spawnRate = normalizedSpawnRate;
		_initialSpawnRate = normalizedSpawnRate;
		UpdateUI();
	}

	public void UpdateSpawnRate(float newRate)
	{
		_spawnRate = newRate;
		if (spawnRateText != null)
		{
			int num = Mathf.RoundToInt(_spawnRate * 100f);
			spawnRateText.text = $"%{num}";
		}
	}

	public void UpdateRemainingCount(int remaining)
	{
		if (!(spawnRateText == null))
		{
			if (remaining <= 0)
			{
				spawnRateText.text = "0";
				return;
			}
			int num = Random.Range(3, 5);
			int num2 = Mathf.Max(0, remaining - num);
			spawnRateText.text = $"~{num2}-{remaining}";
		}
	}

	public void UpdateUI()
	{
		if (_itemSO == null)
		{
			return;
		}
		if (itemIcon != null)
		{
			if (_itemSO.Icon != null)
			{
				itemIcon.sprite = _itemSO.Icon;
				itemIcon.gameObject.SetActive(value: true);
			}
			else
			{
				itemIcon.gameObject.SetActive(value: false);
			}
		}
		if (itemNameText != null)
		{
			string translation = LocalizationManager.GetTranslation(_itemSO.Name);
			itemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : _itemSO.Name);
		}
		if (spawnRateText != null)
		{
			int num = (int)(_spawnRate * 100f);
			spawnRateText.text = $"%{num}";
		}
	}
}
