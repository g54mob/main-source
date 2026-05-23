using System;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour
{
	[Serializable]
	public class StockInfo
	{
		public string name;

		public int[] priceValues;

		public int currentValue;

		public int avgValue;

		public int sharedOwned;

		public List<Vector3> points = new List<Vector3>();
	}

	public static StockManager S;

	public StockInfo[] stockInfos = new StockInfo[5];

	[SerializeField]
	private float[] timeLinePosValues;

	[SerializeField]
	private float[] priceLinePosValues;

	public float stockUpdateTime = 300f;

	private int lastIndex;

	public event Action<StockInfo[]> OnStockUpdate;

	private void SaveStockData()
	{
		ES3.Save("Sm_StockInfos", stockInfos);
		ES3.Save("Sm_StockUpadteTime", stockUpdateTime);
		ES3.Save("Sm_LastIndex", lastIndex);
	}

	private void LoadStockData()
	{
		stockInfos = ES3.Load("Sm_StockInfos", stockInfos);
		stockUpdateTime = ES3.Load("Sm_StockUpadteTime", stockUpdateTime);
		lastIndex = ES3.Load("Sm_LastIndex", lastIndex);
	}

	private void Awake()
	{
		if (S != null && S != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		StockInfo[] array = stockInfos;
		foreach (StockInfo stockInfo in array)
		{
			for (int j = 0; j < 5; j++)
			{
				lastIndex = UnityEngine.Random.Range(0, priceLinePosValues.Length);
				stockInfo.currentValue = stockInfo.priceValues[lastIndex];
				stockInfo.avgValue += stockInfo.currentValue;
				Vector3 item = new Vector3(timeLinePosValues[j], priceLinePosValues[lastIndex], lastIndex);
				stockInfo.points.Add(item);
				stockInfo.avgValue /= 5;
			}
		}
		LoadStockData();
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SaveStockData();
	}

	private void OnDestroy()
	{
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
	}

	private void PauseUI_OnSaveAndQuit()
	{
		SaveStockData();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void UpdateStockInfo()
	{
		StockInfo[] array = stockInfos;
		foreach (StockInfo stockInfo in array)
		{
			stockInfo.points.RemoveAt(0);
			stockInfo.avgValue = 0;
			if (stockInfo.points[stockInfo.points.Count - 1].z > 0f)
			{
				if (stockInfo.points[stockInfo.points.Count - 1].z < (float)(priceLinePosValues.Length - 1))
				{
					lastIndex = UnityEngine.Random.Range((int)stockInfo.points[stockInfo.points.Count - 1].z - 1, (int)stockInfo.points[stockInfo.points.Count - 1].z + 1);
				}
				else
				{
					lastIndex = UnityEngine.Random.Range(priceLinePosValues.Length - 3, priceLinePosValues.Length - 1);
				}
			}
			else
			{
				lastIndex = UnityEngine.Random.Range(0, 2);
			}
			Vector3 item = new Vector3(timeLinePosValues[4], priceLinePosValues[lastIndex], lastIndex);
			stockInfo.points.Add(item);
			for (int j = 0; j < 5; j++)
			{
				stockInfo.points[j] = new Vector3(timeLinePosValues[j], stockInfo.points[j].y, stockInfo.points[j].z);
				stockInfo.currentValue = stockInfo.priceValues[(int)stockInfo.points[j].z];
				stockInfo.avgValue += stockInfo.currentValue;
			}
			stockInfo.avgValue /= stockInfo.points.Count;
		}
		this.OnStockUpdate?.Invoke(stockInfos);
	}

	private void Update()
	{
		stockUpdateTime -= Time.deltaTime;
		if (stockUpdateTime < 0f)
		{
			UpdateStockInfo();
			stockUpdateTime = 300f;
		}
	}
}
