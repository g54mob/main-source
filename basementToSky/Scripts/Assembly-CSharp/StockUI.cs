using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StockUI : MonoBehaviour
{
	[SerializeField]
	private int index;

	[SerializeField]
	private GameObject Up;

	[SerializeField]
	private GameObject Down;

	[SerializeField]
	private GameObject Middle;

	[SerializeField]
	private GameObject linePrefab;

	[SerializeField]
	private Transform chartPos;

	[SerializeField]
	private TextMeshProUGUI currentValueText;

	[SerializeField]
	private TextMeshProUGUI avgValueText;

	[SerializeField]
	private TextMeshProUGUI sharedOwnedText;

	[SerializeField]
	private TextMeshProUGUI totalValueText;

	[SerializeField]
	private TextMeshProUGUI timerText;

	private List<GameObject> lineGOs = new List<GameObject>();

	private float timer;

	private StockManager.StockInfo stockInfo = new StockManager.StockInfo();

	private void OnEnable()
	{
		stockInfo = StockManager.S.stockInfos[index];
		UpdateStockInfo();
		timer = StockManager.S.stockUpdateTime;
		int num = (int)(timer / 60f);
		int num2 = (int)(timer % 60f);
		timerText.text = $"{num:00}:{num2:00}";
	}

	private void Start()
	{
		StockManager.S.OnStockUpdate += Sm_OnStockUpdate;
	}

	private void OnDestroy()
	{
		StockManager.S.OnStockUpdate -= Sm_OnStockUpdate;
	}

	private void Sm_OnStockUpdate(StockManager.StockInfo[] obj)
	{
		stockInfo = obj[index];
		UpdateStockInfo();
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		int num = (int)(timer / 60f);
		int num2 = (int)(timer % 60f);
		timerText.text = $"{num:00}:{num2:00}";
		if (timer < 0f)
		{
			timer = 300f;
		}
	}

	private void UpdateStockInfo()
	{
		if (lineGOs.Count > 0)
		{
			foreach (GameObject lineGO in lineGOs)
			{
				Object.Destroy(lineGO);
			}
			lineGOs.Clear();
		}
		for (int i = 0; i < 4; i++)
		{
			GameObject gameObject = Object.Instantiate(linePrefab, chartPos);
			lineGOs.Add(gameObject);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			Vector2 vector = stockInfo.points[i + 1] - stockInfo.points[i];
			float magnitude = vector.magnitude;
			component.pivot = new Vector2(0f, 0.5f);
			component.anchoredPosition = stockInfo.points[i];
			if (i == 3)
			{
				component.sizeDelta = new Vector2(magnitude, 0.003f);
			}
			else
			{
				component.sizeDelta = new Vector2(magnitude + 0.0014f, 0.003f);
			}
			float z = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
			component.localRotation = Quaternion.Euler(0f, 0f, z);
		}
		if (stockInfo.points[4].y - stockInfo.points[3].y == 0f)
		{
			Middle.SetActive(value: true);
			Up.SetActive(value: false);
			Down.SetActive(value: false);
		}
		else if (stockInfo.points[4].y - stockInfo.points[3].y > 0f)
		{
			Middle.SetActive(value: false);
			Up.SetActive(value: true);
			Down.SetActive(value: false);
		}
		else
		{
			Middle.SetActive(value: false);
			Up.SetActive(value: false);
			Down.SetActive(value: true);
		}
		currentValueText.text = $"${stockInfo.currentValue}";
		avgValueText.text = $"${stockInfo.avgValue}";
		sharedOwnedText.text = $"{stockInfo.sharedOwned}";
		int num = stockInfo.sharedOwned * stockInfo.currentValue;
		totalValueText.text = $"${num}";
	}

	public void BuyStock()
	{
		if (FirstPersonController.S.money >= (float)stockInfo.currentValue)
		{
			FirstPersonController.S.MoneyUpdated(-stockInfo.currentValue);
			stockInfo.sharedOwned++;
			sharedOwnedText.text = $"{stockInfo.sharedOwned}";
			int num = stockInfo.sharedOwned * stockInfo.currentValue;
			totalValueText.text = $"${num}";
		}
	}

	public void SellStock()
	{
		if (stockInfo.sharedOwned > 0)
		{
			FirstPersonController.S.MoneyUpdated(stockInfo.currentValue);
			stockInfo.sharedOwned--;
			sharedOwnedText.text = $"{stockInfo.sharedOwned}";
			int num = stockInfo.sharedOwned * stockInfo.currentValue;
			totalValueText.text = $"${num}";
		}
	}
}
