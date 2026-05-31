using UnityEngine;

public class OxIndicatorScript : MonoBehaviour, ISaveObject
{
	public struct OxData
	{
		public int CurrentIndicator;
	}

	public GameObject[] Indicators;

	public Material[] Mats;

	public AudioSource Sound;

	private Renderer[] Rends;

	public Material OffMat;

	private OxData MyData;

	public string MyID => "Oxygen_Indicator";

	private void Start()
	{
		MyData = default(OxData);
		Rends = new Renderer[Indicators.Length];
		MyData.CurrentIndicator = 3;
		for (int i = 0; i < Indicators.Length; i++)
		{
			Rends[i] = Indicators[i].GetComponent<Renderer>();
		}
		Rends[MyData.CurrentIndicator].material = Mats[MyData.CurrentIndicator];
	}

	public void SetIndicator()
	{
		MyData.CurrentIndicator--;
		if (MyData.CurrentIndicator < 0)
		{
			MyData.CurrentIndicator = 0;
		}
		IndicatorEffects();
	}

	public void DecreaseIndicator()
	{
		int currentIndicator = MyData.CurrentIndicator;
		currentIndicator--;
		if (currentIndicator < 0)
		{
			currentIndicator = 0;
		}
		MyData.CurrentIndicator = currentIndicator;
		IndicatorEffects();
	}

	private void IndicatorEffects()
	{
		for (int i = 0; i < Indicators.Length; i++)
		{
			Rends[i].material = OffMat;
		}
		Rends[MyData.CurrentIndicator].material = Mats[MyData.CurrentIndicator];
		Sound.Play();
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (OxData)dataIn;
		for (int i = 0; i < Indicators.Length; i++)
		{
			Rends[i].material = OffMat;
		}
		Rends[MyData.CurrentIndicator].material = Mats[MyData.CurrentIndicator];
	}
}
