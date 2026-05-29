using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class Prestige : MonoSingleton<Prestige>
	{
		[SerializeField]
		private PrestigeLevelsData _prestigeData;

		private float _oldPrestige;

		private PrestigeLevelData _currentPrestigeLevel;

		public static PrestigeLevelsData CurrentPrestigeData { get; private set; }

		public static float MaxPrestigeRequired => CurrentPrestigeData.MaxPrestigeRequired;

		[field: SerializeField]
		[field: ReadOnly]
		public float CurrentPrestige { get; private set; }

		public PrestigeLevelData CurrentPrestigeLevel
		{
			get
			{
				return _currentPrestigeLevel;
			}
			private set
			{
				if (value == _currentPrestigeLevel)
				{
					return;
				}
				if (value != null && _currentPrestigeLevel != null)
				{
					if (value.Level > _currentPrestigeLevel.Level)
					{
						Prestige.PrestigeLevelUp?.Invoke();
					}
					else
					{
						Prestige.PrestigeLevelDown?.Invoke();
					}
				}
				_currentPrestigeLevel = value;
				Prestige.PrestigeLevelChanged?.Invoke(_currentPrestigeLevel);
				Prestige.PrestigeChanged?.Invoke(CurrentPrestigeLevel, CurrentPrestige);
			}
		}

		[field: ShowNonSerializedField]
		public float TotalFurnituresValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalJunkValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalFilthValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalReviewsValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalSuperficyValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalBuildableValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalPaintValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalRewardValue { get; private set; }

		[field: ShowNonSerializedField]
		public float TotalVampiresKilled { get; private set; }

		public float TotalBarPrestige => TotalFurnituresValue + TotalSuperficyValue + TotalBuildableValue + TotalPaintValue;

		public static event Action<float> PrestigeGained;

		public static event Action<PrestigeLevelData, float> PrestigeChanged;

		public static event Action<PrestigeLevelData> PrestigeLevelChanged;

		public static event Action PrestigeLevelUp;

		public static event Action PrestigeLevelDown;

		protected override void SingletonAwake()
		{
			ClearValues();
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Start()
		{
			SetPrestigeData(_prestigeData);
			CurrentPrestigeLevel = CurrentPrestigeData.PrestigeSteps[0];
			UpdatePrestige();
		}

		public static int TotalMaxPopulation(bool isVampire)
		{
			return CurrentPrestigeData.GetTotalMaxPopulation(isVampire);
		}

		private void ClearValues()
		{
			TotalFurnituresValue = 0f;
			TotalJunkValue = 0f;
			TotalReviewsValue = 0f;
			TotalSuperficyValue = 0f;
			TotalBuildableValue = 0f;
			TotalPaintValue = 0f;
			TotalRewardValue = 0f;
			TotalVampiresKilled = 0f;
			CurrentPrestige = 0f;
		}

		private void OnEnable()
		{
			ClearValues();
			SetPrestigeData(_prestigeData);
			CurrentPrestigeLevel = CurrentPrestigeData.PrestigeSteps[0];
			_prestigeData.DataImported += OnDataImported;
			UpdatePrestige();
			Furniture.FurnituresValueInBarChanged += UpdateTotalFurnituresValue;
			JunkObject.OnJunkAdded += OnJunkAdded;
			JunkObject.OnJunkDiscarded += OnJunkDiscarded;
			CleanableObject.FilthLevelChanged += OnCleanableObjectFilthChanged;
			ConstructionSystem.OnPrestigeChanged += ConstructionSystem_BuildGenerated;
			SurfaceObjectPaintingSystem.OnPaintingChanged += OnPaintingChanged;
			BuildablePlacementSystem.OnBuildablePlaced += OnBuildableAdded;
			BuildableElement.Destroyed += OnBuildableRemoved;
			SaveManager.OnLoadingFinished += GameData_OnLoadingFinished;
			AutomaticMapLoader.MapLoaded += OnMapLoaded;
		}

		private void OnDisable()
		{
			if ((bool)_prestigeData)
			{
				_prestigeData.DataImported -= OnDataImported;
			}
			Furniture.FurnituresValueInBarChanged -= UpdateTotalFurnituresValue;
			Furniture.FurnituresValueInBarChanged -= UpdateTotalFurnituresValue;
			JunkObject.OnJunkAdded -= OnJunkAdded;
			JunkObject.OnJunkDiscarded -= OnJunkDiscarded;
			CleanableObject.FilthLevelChanged -= OnCleanableObjectFilthChanged;
			ConstructionSystem.OnPrestigeChanged -= ConstructionSystem_BuildGenerated;
			SurfaceObjectPaintingSystem.OnPaintingChanged -= OnPaintingChanged;
			BuildablePlacementSystem.OnBuildablePlaced -= OnBuildableAdded;
			BuildableElement.Destroyed -= OnBuildableRemoved;
			SaveManager.OnLoadingFinished -= GameData_OnLoadingFinished;
			AutomaticMapLoader.MapLoaded -= OnMapLoaded;
			ClearValues();
			_oldPrestige = 0f;
		}

		private void OnCleanableObjectFilthChanged(CleanableObject cleanableObject)
		{
			TotalFilthValue = -CTSSingleton<FilthManager>.Instance.TotalFilth;
			UpdatePrestige();
		}

		private void OnJunkDiscarded(JunkObject junk)
		{
			TotalJunkValue += junk.Parameters.PrestigeMalus;
			UpdatePrestige();
		}

		private void OnJunkAdded(JunkObject junk)
		{
			TotalJunkValue -= junk.Parameters.PrestigeMalus;
			UpdatePrestige();
		}

		private void OnMapLoaded()
		{
			if (GameMode.IsNewGame)
			{
				ConstructionSystem_BuildGenerated(MonoSingleton<ConstructionSystem>.Instance.GetTotalPrestige);
				TotalPaintValue = MonoSingleton<ConstructionSystem>.Instance.GetTotalStylePrestige;
			}
		}

		private void GameData_OnLoadingFinished()
		{
			Debug.Log("Load prestige : " + CurrentPrestige + " / " + CurrentPrestigeLevel.Level);
			Prestige.PrestigeChanged?.Invoke(CurrentPrestigeLevel, CurrentPrestige);
		}

		private void ConstructionSystem_BuildGenerated(int prestigeChanged)
		{
			TotalSuperficyValue = prestigeChanged;
			UpdatePrestige();
		}

		public void SetPrestigeData(PrestigeLevelsData data)
		{
			if (!(CurrentPrestigeData == data))
			{
				CurrentPrestigeData = data;
				UpdatePrestigeLevel();
			}
		}

		public static void AddRewardScore(int scoreToAdd)
		{
			MonoSingleton<Prestige>.Instance.TotalRewardValue += scoreToAdd;
			UpdatePrestige();
		}

		public static void AddVampireKilledScore(int scoreToAdd)
		{
			MonoSingleton<Prestige>.Instance.TotalVampiresKilled += scoreToAdd;
			UpdatePrestige();
		}

		public void AddReviewScore(int score)
		{
			TotalReviewsValue += score;
			UpdatePrestige();
		}

		public void ResetPrestigeData()
		{
			if (!(CurrentPrestigeData == _prestigeData))
			{
				CurrentPrestigeData = _prestigeData;
				UpdatePrestigeLevel();
			}
		}

		private void OnDataImported()
		{
			UpdatePrestigeLevel();
		}

		private void UpdateTotalFurnituresValue(float newValue)
		{
			TotalFurnituresValue += newValue;
			UpdatePrestige();
		}

		private void OnBuildableRemoved(BuildableElement buildable)
		{
			TotalBuildableValue -= buildable.BuildableElementSO.PrestigeValue;
			UpdatePrestige();
		}

		private void OnBuildableAdded(BuildableElement buildable)
		{
			TotalBuildableValue += buildable.BuildableElementSO.PrestigeValue;
			UpdatePrestige();
		}

		private void OnPaintingChanged(SurfaceData oldSurface, SurfaceData newSurface)
		{
			if ((bool)oldSurface)
			{
				TotalPaintValue -= oldSurface.PrestigeValue;
			}
			if ((bool)newSurface)
			{
				TotalPaintValue += newSurface.PrestigeValue;
			}
			UpdatePrestige();
		}

		private static void UpdatePrestige()
		{
			MonoSingleton<Prestige>.Instance.UpdatePrestige_Instance();
		}

		private void UpdatePrestige_Instance()
		{
			_oldPrestige = CurrentPrestige;
			CurrentPrestige = Mathf.Max(0f, TotalFurnituresValue + TotalJunkValue + TotalFilthValue + TotalReviewsValue + TotalSuperficyValue + TotalBuildableValue + TotalPaintValue + TotalRewardValue + TotalVampiresKilled);
			if (_oldPrestige < CurrentPrestige)
			{
				Prestige.PrestigeGained?.Invoke(CurrentPrestige - _oldPrestige);
			}
			if (Math.Abs(_oldPrestige - CurrentPrestige) > float.Epsilon)
			{
				Prestige.PrestigeChanged?.Invoke(CurrentPrestigeLevel, CurrentPrestige);
				UpdatePrestigeLevel();
				_oldPrestige = CurrentPrestige;
			}
		}

		private void UpdatePrestigeLevel()
		{
			CurrentPrestigeLevel = FindCurrentPrestigeLevel(CurrentPrestige, CurrentPrestigeData.PrestigeSteps, 0, CurrentPrestigeData.PrestigeSteps.Count);
		}

		public float GetNextStepPrestige()
		{
			return CurrentPrestigeData.GetNextStepFrom(_currentPrestigeLevel);
		}

		private static PrestigeLevelData FindCurrentPrestigeLevel(float prestigeAmount, List<PrestigeLevelData> list, int lowIndex, int highIndex)
		{
			if (list.Count == 0 || lowIndex == highIndex)
			{
				return null;
			}
			int num = Mathf.FloorToInt(Mathf.Lerp(lowIndex, highIndex, 0.5f));
			PrestigeLevelData prestigeLevelData = list[num];
			float num2 = ((num >= list.Count - 1) ? prestigeLevelData.PrestigeRequired : list[num + 1].PrestigeRequired);
			if (prestigeAmount == prestigeLevelData.PrestigeRequired || (prestigeAmount >= prestigeLevelData.PrestigeRequired && prestigeAmount < num2))
			{
				return prestigeLevelData;
			}
			if (prestigeAmount < prestigeLevelData.PrestigeRequired)
			{
				return FindCurrentPrestigeLevel(prestigeAmount, list, lowIndex, num);
			}
			if (prestigeLevelData.PrestigeRequired == num2)
			{
				return prestigeLevelData;
			}
			return FindCurrentPrestigeLevel(prestigeAmount, list, num, highIndex);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestAddReview()
		{
			AddReviewScore(500);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestAddReward()
		{
			AddRewardScore(100);
		}
	}
}
