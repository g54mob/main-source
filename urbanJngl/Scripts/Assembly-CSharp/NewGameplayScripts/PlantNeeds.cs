using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NewGameplayScripts
{
	public class PlantNeeds : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI plantName;

		[SerializeField]
		private NeedsInfo sunlightInfo;

		[SerializeField]
		private NeedsInfo noSunlightInfo;

		[SerializeField]
		private NeedsInfo humidityInfo;

		[SerializeField]
		private NeedsInfo noHumidityInfo;

		[SerializeField]
		private Transform iconStar;

		[SerializeField]
		private TextMeshProUGUI tipText;

		[SerializeField]
		private Image plantImage;

		[SerializeField]
		private Color blockedColor;

		[SerializeField]
		private Color mainColor;

		private ObjectSO objectSO;

		private int variantIndex;

		private TextMeshProUGUI activeSunlightText;

		private TextMeshProUGUI activeHumidityText;

		private Plant plant;

		private Sequence showAnimation;

		private Sequence hideAnimation;

		private float yOffset = 200f;

		private Vector3 position;

		private Transform activeSunlightIcon;

		private Transform activeHumidityIcon;

		public static PlantNeeds Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
			position = base.transform.position;
		}

		private void Start()
		{
			Hide();
		}

		private void OnDestroy()
		{
			showAnimation.Kill();
			hideAnimation.Kill();
		}

		private void Update()
		{
			if (plant != null)
			{
				if (plant.PlantHasBonusStar())
				{
					iconStar.gameObject.SetActive(value: true);
					tipText.color = mainColor;
				}
				else
				{
					iconStar.gameObject.SetActive(value: false);
					tipText.color = blockedColor;
				}
			}
		}

		public void Show(ObjectSO objectSO, int variantIndex, Plant plant)
		{
			this.objectSO = objectSO;
			this.variantIndex = variantIndex;
			this.plant = plant;
			SetupVisual();
			base.gameObject.SetActive(value: true);
			ShowAnimation();
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void SetupVisual()
		{
			plantImage.sprite = objectSO.variantsList[variantIndex].variantSprite;
			plantName.text = CollectionManager.Instance.GetPlantNameLocalize(objectSO.objectName);
			if (objectSO.sunlight == EnvironmentSunlight.Sunlight.Low)
			{
				activeSunlightText = noSunlightInfo.text;
				activeSunlightIcon = noSunlightInfo.icon;
				sunlightInfo.Hide();
				noSunlightInfo.Show();
			}
			else
			{
				activeSunlightText = sunlightInfo.text;
				activeSunlightIcon = sunlightInfo.icon;
				sunlightInfo.Show();
				noSunlightInfo.Hide();
			}
			if (objectSO.humidity == EnvironmentHumidity.Humidity.Low)
			{
				activeHumidityText = noHumidityInfo.text;
				activeHumidityIcon = noHumidityInfo.icon;
				humidityInfo.Hide();
				noHumidityInfo.Show();
			}
			else
			{
				activeHumidityText = humidityInfo.text;
				activeHumidityIcon = humidityInfo.icon;
				humidityInfo.Show();
				noHumidityInfo.Hide();
			}
			activeSunlightText.color = blockedColor;
			activeHumidityText.color = blockedColor;
			tipText.color = blockedColor;
			tipText.text = CollectionManager.Instance.GetPlantTipLocalize(objectSO.objectName);
		}

		public void UpdateVisual(EnvironmentSunlight.Sunlight sunlight, EnvironmentHumidity.Humidity humidity)
		{
			if (objectSO != null)
			{
				activeSunlightIcon.gameObject.SetActive(objectSO.sunlight == sunlight);
				activeHumidityIcon.gameObject.SetActive(objectSO.humidity == humidity);
				if (objectSO.sunlight == sunlight)
				{
					activeSunlightText.color = mainColor;
				}
				else
				{
					activeSunlightText.color = blockedColor;
				}
				if (objectSO.humidity == humidity)
				{
					activeHumidityText.color = mainColor;
				}
				else
				{
					activeHumidityText.color = blockedColor;
				}
			}
		}

		private void ShowAnimation()
		{
			showAnimation = DOTween.Sequence();
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - yOffset, base.transform.position.z);
			showAnimation.Append(base.transform.DOMoveY(position.y + 10f, 0.2f).SetEase(Ease.OutSine)).Append(base.transform.DOMoveY(position.y, 0.1f).SetEase(Ease.InOutSine)).Play();
		}

		public void HideAnimation()
		{
			hideAnimation = DOTween.Sequence();
			hideAnimation.Append(base.transform.DOMoveY(base.transform.position.y + 10f, 0.1f).SetEase(Ease.InOutSine)).Append(base.transform.DOMoveY(base.transform.position.y - yOffset, 0.2f).SetEase(Ease.InSine)).AppendCallback(delegate
			{
				Hide();
			})
				.Play();
		}
	}
}
