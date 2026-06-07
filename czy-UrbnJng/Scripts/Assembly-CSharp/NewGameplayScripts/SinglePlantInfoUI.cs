using System;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace NewGameplayScripts
{
	public class SinglePlantInfoUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI scoreText;

		[SerializeField]
		private Transform icons;

		[SerializeField]
		private Transform iconSunlight;

		[SerializeField]
		private Transform iconNoSunlight;

		[SerializeField]
		private Transform iconHumidity;

		[SerializeField]
		private Transform iconNoHumidity;

		[SerializeField]
		private Transform iconStar;

		[SerializeField]
		private Transform bgSunlight;

		[SerializeField]
		private Transform bgNoSunlight;

		[SerializeField]
		private Transform bgHumidity;

		[SerializeField]
		private Transform bgNoHumidity;

		[SerializeField]
		private Transform bgStar;

		[SerializeField]
		private Plant plant;

		[SerializeField]
		private Transform sunlightTransform;

		[SerializeField]
		private Transform humidityTransform;

		[SerializeField]
		private Transform starTransform;

		private ObjectSO objectSO;

		private EnvironmentSunlight.Sunlight sunlight;

		private EnvironmentHumidity.Humidity humidity;

		private bool isStarActive;

		private int previousScore;

		private Transform activeSunlightIcon;

		private Transform activeHumidityIcon;

		private bool canUpdateStar;

		private bool pauseOn;

		private Sequence sunlightOnAnimation;

		private Sequence sunlightOffAnimation;

		private Sequence humidityOnAnimation;

		private Sequence humidityOffAnimation;

		private Sequence starOnAnimation;

		private Sequence starOffAnimation;

		private void Start()
		{
			MovementSystem.Instance.OnStartMovingPlant += MovementSystem_OnStartMovingPlant;
			MovementSystem.Instance.OnStartMovingLamp_Humidifier += MovementSystem_OnStartMovingLamp_Humidifier;
			MovementSystem.Instance.OnStopMovingPlant += MovementSystem_OnStopMovingPlant;
			MovementSystem.Instance.OnStopMovingLamp_Humidifier += MovementSystem_OnStopMovingLamp_Humidifier;
			plant.OnEnvironmentChanged += Plant_OnEnvironmentChanged;
			objectSO = plant.GetObjectSO();
			previousScore = 0;
			if (InputManager.Instance.gamePause)
			{
				pauseOn = true;
			}
			if (objectSO.sunlight == EnvironmentSunlight.Sunlight.Low)
			{
				activeSunlightIcon = iconNoSunlight;
				iconSunlight.gameObject.SetActive(value: false);
				iconNoSunlight.gameObject.SetActive(value: true);
				bgSunlight.gameObject.SetActive(value: false);
				bgNoSunlight.gameObject.SetActive(value: true);
			}
			else
			{
				activeSunlightIcon = iconSunlight;
				iconSunlight.gameObject.SetActive(value: true);
				iconNoSunlight.gameObject.SetActive(value: false);
				bgSunlight.gameObject.SetActive(value: true);
				bgNoSunlight.gameObject.SetActive(value: false);
			}
			if (objectSO.humidity == EnvironmentHumidity.Humidity.Low)
			{
				activeHumidityIcon = iconNoHumidity;
				iconHumidity.gameObject.SetActive(value: false);
				iconNoHumidity.gameObject.SetActive(value: true);
				bgHumidity.gameObject.SetActive(value: false);
				bgNoHumidity.gameObject.SetActive(value: true);
			}
			else
			{
				activeHumidityIcon = iconHumidity;
				iconHumidity.gameObject.SetActive(value: true);
				iconNoHumidity.gameObject.SetActive(value: false);
				bgHumidity.gameObject.SetActive(value: true);
				bgNoHumidity.gameObject.SetActive(value: false);
			}
			ShowPlantInfo();
			if (!MovementSystem.Instance.IsMoving() || AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				HidePlantInfo();
			}
		}

		private void OnDestroy()
		{
			MovementSystem.Instance.OnStartMovingPlant -= MovementSystem_OnStartMovingPlant;
			MovementSystem.Instance.OnStartMovingLamp_Humidifier -= MovementSystem_OnStartMovingLamp_Humidifier;
			MovementSystem.Instance.OnStopMovingPlant -= MovementSystem_OnStopMovingPlant;
			MovementSystem.Instance.OnStopMovingLamp_Humidifier -= MovementSystem_OnStopMovingLamp_Humidifier;
			plant.OnEnvironmentChanged -= Plant_OnEnvironmentChanged;
		}

		private void Update()
		{
			if (canUpdateStar)
			{
				iconStar.gameObject.SetActive(plant.PlantHasBonusStar());
			}
		}

		private void MovementSystem_OnStopMovingLamp_Humidifier(object sender, EventArgs e)
		{
			HidePlantInfo();
		}

		private void MovementSystem_OnStopMovingPlant(object sender, EventArgs e)
		{
			HidePlantInfo();
		}

		private void MovementSystem_OnStartMovingLamp_Humidifier(object sender, EventArgs e)
		{
			ShowPlantInfo();
		}

		private void MovementSystem_OnStartMovingPlant(object sender, EventArgs e)
		{
			ShowPlantInfo();
		}

		private void Plant_OnEnvironmentChanged(object sender, Plant.OnEnvironmentChangedEventArgs e)
		{
			sunlight = e.sunlight;
			humidity = e.humidity;
			UpdateVisual();
		}

		private void ShowPlantInfo()
		{
			if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				scoreText.gameObject.SetActive(value: true);
				icons.gameObject.SetActive(value: true);
				canUpdateStar = true;
				if (pauseOn && !InputManager.Instance.gamePause)
				{
					pauseOn = false;
					previousScore = plant.GetFinalScore();
				}
				UpdateVisual();
			}
		}

		private void HidePlantInfo()
		{
			UpdateVisual();
			scoreText.gameObject.SetActive(value: false);
			icons.gameObject.SetActive(value: false);
			canUpdateStar = false;
			if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				if (previousScore < plant.GetFinalScore())
				{
					ParticlesManagerUI.Instance.SpawnParticlesAtPlant(plant, plant.GetFinalScore() - previousScore);
				}
				else if (previousScore > plant.GetFinalScore())
				{
					ParticlesManagerUI.Instance.SpawnParticlesAtTarget(plant, previousScore - plant.GetFinalScore());
				}
				previousScore = plant.GetScore();
			}
		}

		private void UpdateVisual()
		{
			scoreText.text = plant.GetScore().ToString();
			if (sunlight == objectSO.sunlight)
			{
				ShowIconAnimation(sunlightOnAnimation, sunlightTransform, activeSunlightIcon);
			}
			else
			{
				HideIconAnimation(sunlightOffAnimation, sunlightTransform, activeSunlightIcon);
			}
			if (humidity == objectSO.humidity)
			{
				ShowIconAnimation(humidityOnAnimation, humidityTransform, activeHumidityIcon);
			}
			else
			{
				HideIconAnimation(humidityOffAnimation, humidityTransform, activeHumidityIcon);
			}
			_ = plant.creativeMode;
		}

		public void UpdateScore()
		{
			scoreText.text = plant.GetScore().ToString();
		}

		private void ShowIconAnimation(Sequence animation, Transform transform, Transform icon)
		{
			animation = DOTween.Sequence();
			animation.Append(transform.DOScale(0.8f, 0.05f).SetEase(Ease.InOutSine)).AppendCallback(delegate
			{
				icon.gameObject.SetActive(value: true);
			}).Append(transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
				.Play();
		}

		private void HideIconAnimation(Sequence animation, Transform transform, Transform icon)
		{
			animation = DOTween.Sequence();
			animation.Append(transform.DOScale(0.8f, 0.05f).SetEase(Ease.InOutSine)).AppendCallback(delegate
			{
				icon.gameObject.SetActive(value: false);
			}).Append(transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
				.Play();
		}
	}
}
