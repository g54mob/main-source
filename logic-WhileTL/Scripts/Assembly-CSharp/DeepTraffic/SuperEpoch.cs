using System;
using UnityEngine;
using UnityEngine.UI;

namespace DeepTraffic
{
	public class SuperEpoch : ActiveComponent
	{
		[SceneBind("ProgressSlider")]
		private Slider progressSlider;

		[SceneBind("EvolveButton")]
		private Button evolveButton;

		[SceneBind("EvolveButton/Glow")]
		private RectTransform evolveButtonGlow;

		[SceneBind("AutoEvolveField/Toggle")]
		private Toggle autoEvolveToggle;

		[SceneBind("PrevSuperEpochStats")]
		private SuperEpochStats prevSuperEpochStats;

		[SceneBind("CurSuperEpochStats")]
		private SuperEpochStats curSuperEpochStats;

		[SceneBind("PrevSuperEpochStats/Medal")]
		private StatMedalController prevMedalController;

		[SceneBind("CurSuperEpochStats/Medal")]
		private StatMedalController curMedalController;

		private Action freeze;

		private Action unfreeze;

		private AgentUnlockedParams agentUnlockedParams;

		private GameObject allTrained;

		private Action stop;

		private Action dropCarTrain;

		private bool wasFullTrain;

		public bool AutoEvolve
		{
			get
			{
				return autoEvolveToggle.isOn;
			}
			set
			{
				autoEvolveToggle.isOn = value;
			}
		}

		public int CurEpoch => curSuperEpochStats.EpochNumber;

		private bool EvolveButtonOn
		{
			get
			{
				return evolveButton.interactable;
			}
			set
			{
				evolveButton.interactable = value;
				evolveButton.GetComponent<Image>().color = (value ? Logic.GetColor("GREEN") : Logic.GetColor("GREY"));
			}
		}

		public float Progress
		{
			get
			{
				return progressSlider.value;
			}
			set
			{
				progressSlider.value = value;
			}
		}

		public float ProgressMaxValue
		{
			get
			{
				return progressSlider.maxValue;
			}
			set
			{
				progressSlider.maxValue = value;
			}
		}

		public void Init(int superEpochSize, Action freeze, Action evolveCallback, AgentUnlockedParams agentUnlockedParams, Action stopTrain, Action dropCarTrain)
		{
			this.freeze = freeze;
			stop = stopTrain;
			this.dropCarTrain = dropCarTrain;
			unfreeze = evolveCallback;
			this.agentUnlockedParams = agentUnlockedParams;
			allTrained = base.gameObject.transform.parent.GetComponent<DeepTrafficGameController>().attentionButton.transform.parent.gameObject;
			if (!base.IsInited)
			{
				base.Init();
			}
			prevMedalController.Init();
			curMedalController.Init();
			prevSuperEpochStats.Init(superEpochSize, agentUnlockedParams);
			curSuperEpochStats.Init(superEpochSize, agentUnlockedParams);
			prevSuperEpochStats.EpochNumber = 0;
			AutoEvolve = false;
			progressSlider.value = 0f;
			progressSlider.interactable = false;
			EvolveButtonOn = false;
			evolveButton.onClick.AddListener(delegate
			{
				ActiveComponent.Model.P.evolveBtnTutorial = true;
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				EvolveButtonAction();
			});
		}

		private void EvolveButtonAction()
		{
			if (EvolveButtonOn)
			{
				EvolveButtonOn = false;
				prevSuperEpochStats.CloneData(curSuperEpochStats);
				prevMedalController.ActiveMedal = curMedalController.ActiveMedal;
				SuperEpochStats superEpochStats = curSuperEpochStats;
				int epochNumber = superEpochStats.EpochNumber + 1;
				superEpochStats.EpochNumber = epochNumber;
				curSuperEpochStats.ResetStats();
				Progress = 0f;
				unfreeze();
			}
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
		}

		public void InitUpdateData(SuperEpochData data)
		{
			curSuperEpochStats.UpdateData(data);
		}

		public void UpdateData(SuperEpochData data, int activeMedal = -1, bool canEvolve = true)
		{
			Progress = data.progress;
			wasFullTrain = false;
			curMedalController.ActiveMedal = activeMedal;
			if (data.superEpochNumber != curSuperEpochStats.EpochNumber)
			{
				curSuperEpochStats.UpdateData(data);
				SuperEpochStats superEpochStats = curSuperEpochStats;
				int epochNumber = superEpochStats.EpochNumber - 1;
				superEpochStats.EpochNumber = epochNumber;
				if (canEvolve)
				{
					EvolveButtonOn = true;
					bool autoEvolve = AutoEvolve;
					freeze();
					if (AutoEvolve)
					{
						EvolveButtonAction();
					}
					AutoEvolve = autoEvolve;
				}
				else
				{
					stop();
					dropCarTrain();
					ActiveComponent.Model.construction.StopTrainingAttentionLastEpoch.gameObject.SetActive(ActiveComponent.Model.P.lastEpochReachedTutorial == 1);
					ActiveComponent.Model.construction.LastEpochReachedTutorial.gameObject.SetActive(ActiveComponent.Model.P.lastEpochReachedTutorial == 0);
					ActiveComponent.Model.P.lastEpochReachedTutorial = 1;
				}
			}
			else
			{
				curSuperEpochStats.UpdateData(data);
			}
		}

		private void Update()
		{
			if (ActiveComponent.Model != null && ActiveComponent.Model.globalSaves != null && !ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial) && allTrained != null)
			{
				if (allTrained.gameObject.activeInHierarchy)
				{
					wasFullTrain = true;
				}
				evolveButtonGlow.gameObject.SetActive(!wasFullTrain && progressSlider.maxValue == progressSlider.value && !autoEvolveToggle.isOn && !ActiveComponent.Model.P.evolveBtnTutorial && !allTrained.gameObject.activeInHierarchy);
			}
		}
	}
}
