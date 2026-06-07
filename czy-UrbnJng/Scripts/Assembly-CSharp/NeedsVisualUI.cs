using DG.Tweening;
using TMPro;
using UnityEngine;

public class NeedsVisualUI : MonoBehaviour
{
	[SerializeField]
	private Transform[] sunlightVisualArray;

	[SerializeField]
	private Transform[] humidityVisualArray;

	[SerializeField]
	private RectTransform sunlightPointer;

	[SerializeField]
	private RectTransform humidityPointer;

	public TextMeshPro SunlightLevel;

	public TextMeshPro HumiditylightLevel;

	private ObjectSO objectSO;

	private EnvironmentSunlight.Sunlight previousSunlight;

	private EnvironmentHumidity.Humidity previousHumidity;

	private void Awake()
	{
		for (int i = 0; i < sunlightVisualArray.Length; i++)
		{
			sunlightVisualArray[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < humidityVisualArray.Length; j++)
		{
			humidityVisualArray[j].gameObject.SetActive(value: false);
		}
		sunlightPointer = base.transform.GetChild(2).GetComponent<RectTransform>();
		humidityPointer = base.transform.GetChild(3).GetComponent<RectTransform>();
	}

	private void Start()
	{
		objectSO = GridPlacementManager.Instance.GetObjectSO();
		if (objectSO != null)
		{
			switch (objectSO.sunlight)
			{
			case EnvironmentSunlight.Sunlight.Low:
				Show(sunlightVisualArray[0]);
				break;
			case EnvironmentSunlight.Sunlight.Middle:
				Show(sunlightVisualArray[1]);
				break;
			case EnvironmentSunlight.Sunlight.High:
				Show(sunlightVisualArray[2]);
				break;
			}
			switch (objectSO.humidity)
			{
			case EnvironmentHumidity.Humidity.Low:
				Show(humidityVisualArray[0]);
				break;
			case EnvironmentHumidity.Humidity.Middle:
				Show(humidityVisualArray[1]);
				break;
			case EnvironmentHumidity.Humidity.High:
				Show(humidityVisualArray[2]);
				break;
			}
		}
	}

	public void RefreshNeeds(EnvironmentSunlight.Sunlight sunlight, EnvironmentHumidity.Humidity humidity)
	{
		Debug.Log(sunlight.ToString() + " / " + humidity);
		if (previousSunlight != sunlight)
		{
			if (previousSunlight == EnvironmentSunlight.Sunlight.High && sunlight == EnvironmentSunlight.Sunlight.Low)
			{
				return;
			}
			switch (sunlight)
			{
			case EnvironmentSunlight.Sunlight.Low:
				sunlightPointer.DORotate(new Vector3(0f, 0f, -60f), 0.5f, RotateMode.LocalAxisAdd);
				break;
			case EnvironmentSunlight.Sunlight.Middle:
				if (previousSunlight == EnvironmentSunlight.Sunlight.High)
				{
					sunlightPointer.DORotate(new Vector3(0f, 0f, -60f), 0.5f, RotateMode.LocalAxisAdd);
				}
				else
				{
					sunlightPointer.DORotate(new Vector3(0f, 0f, 60f), 0.5f, RotateMode.LocalAxisAdd);
				}
				break;
			case EnvironmentSunlight.Sunlight.High:
				sunlightPointer.DORotate(new Vector3(0f, 0f, 60f), 0.5f, RotateMode.LocalAxisAdd);
				break;
			}
			previousSunlight = sunlight;
		}
		if (previousHumidity != humidity)
		{
			if (previousHumidity == EnvironmentHumidity.Humidity.High && humidity == EnvironmentHumidity.Humidity.Low)
			{
				return;
			}
			switch (humidity)
			{
			case EnvironmentHumidity.Humidity.Low:
				humidityPointer.DORotate(new Vector3(0f, 0f, -60f), 0.5f, RotateMode.LocalAxisAdd);
				break;
			case EnvironmentHumidity.Humidity.Middle:
				if (previousHumidity == EnvironmentHumidity.Humidity.High)
				{
					humidityPointer.DORotate(new Vector3(0f, 0f, -60f), 0.5f, RotateMode.LocalAxisAdd);
				}
				else
				{
					humidityPointer.DORotate(new Vector3(0f, 0f, 60f), 0.5f, RotateMode.LocalAxisAdd);
				}
				break;
			case EnvironmentHumidity.Humidity.High:
				humidityPointer.DORotate(new Vector3(0f, 0f, 60f), 0.5f, RotateMode.LocalAxisAdd);
				break;
			}
			previousHumidity = humidity;
		}
		Debug.Log(sunlightPointer?.ToString() + " rotation = " + sunlightPointer.eulerAngles.ToString());
	}

	private void OnDisable()
	{
		DOTween.Clear();
	}

	public void Show(Transform transform)
	{
		transform.gameObject.SetActive(value: true);
	}
}
