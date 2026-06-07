using System;
using System.Collections;
using System.Collections.Generic;
using DV.Common;
using DV.JObjectExtstensions;
using DV.LocoRestoration;
using DV.UI;
using DV.UIFramework;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class QuickTutorialInitiator : SingletonBehaviour<QuickTutorialInitiator>
	{
		public Dictionary<string, string> supportedLocoIds = new Dictionary<string, string>
		{
			{ "LocoDE2", "QT_DE2" },
			{ "LocoDE6", "QT_DE6" },
			{ "LocoDH4", "QT_DH4" },
			{ "LocoDM3", "QT_DM3" },
			{ "LocoS282A", "QT_S282A" },
			{ "LocoS060", "QT_S060" },
			{ "LocoMicroshunter", "QT_Microshunter" },
			{ "LocoDM1U", "QT_DM1U" }
		};

		private PopupClosedByAction? popupAnswer;

		private Coroutine coro;

		private string N => "[" + GetType().Name + "]";

		public bool IsRoutineRunning => coro != null;

		public new static string AllowAutoCreate()
		{
			return "[QuickTutorialInitiator]";
		}

		private void Start()
		{
			PlayerManager.CarChanged += OnCarChanged;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			PlayerManager.CarChanged -= OnCarChanged;
		}

		private void OnCarChanged(TrainCar _)
		{
			if (WorldStreamingInit.IsLoaded && GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.QuickTutorialControl) && coro == null && !QuickTutorialHost.IsTutorialRunning)
			{
				coro = StartCoroutine(OnCarChangedCoro(manualStart: false));
			}
		}

		private IEnumerator ShowDialogQuestion(string labelKey)
		{
			popupAnswer = null;
			Popup question = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.uiReferences.popup3Buttons, new PopupLocalizationKeys
			{
				labelKey = labelKey,
				positiveKey = "yes",
				negativeKey = "later",
				abortionKey = "never"
			});
			question.EscAction = PopupClosedByAction.Negative;
			question.Closed += QuestionClosed;
			while (!popupAnswer.HasValue)
			{
				yield return null;
			}
			void QuestionClosed(PopupResult result)
			{
				question.Closed -= QuestionClosed;
				popupAnswer = result.closedBy;
			}
		}

		public void StartNow()
		{
			if (coro != null)
			{
				StopCoroutine(coro);
			}
			coro = StartCoroutine(OnCarChangedCoro(manualStart: true));
		}

		private IEnumerator OnCarChangedCoro(bool manualStart)
		{
			TrainCar initialCar = PlayerManager.Car;
			if (initialCar == null)
			{
				coro = null;
				yield break;
			}
			if (!manualStart)
			{
				yield return WaitFor.Seconds(2f);
			}
			if (PlayerManager.Car == null || PlayerManager.Car != initialCar)
			{
				coro = null;
				if (manualStart)
				{
					SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt("tutorial/cond/in_locomotive", pause: false, null);
				}
				yield break;
			}
			if (!SingletonBehaviour<LicenseManager>.Instance.IsLicensedForCar(PlayerManager.Car.carLivery))
			{
				coro = null;
				yield break;
			}
			string carID = PlayerManager.Car.carLivery.id;
			if (!IsPlayerOnLocoThatSupportsQuickTutorial())
			{
				Debug.Log(N + " Unsupported or already passed quick tutorial for " + carID);
				coro = null;
				yield break;
			}
			if (manualStart && TutorialHelper.InRestrictedMode)
			{
				bool done = false;
				SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt("tutorial/pause/abort_qt", pause: false, delegate
				{
					done = true;
				});
				while (!done)
				{
					yield return null;
				}
			}
			if (manualStart || !WasTutorialAlreadyPlayed(carID))
			{
				yield return ShowDialogQuestion("tutorial/qt/driving_question");
				if (popupAnswer.Value != PopupClosedByAction.Positive)
				{
					if (popupAnswer.Value == PopupClosedByAction.Abortion)
					{
						UpdateProgressionState(carID, state: true);
					}
					else
					{
						UpdateProgressionState(carID, state: false);
					}
					coro = null;
					yield break;
				}
				yield return WaitFor.Seconds(1f);
				QuickTutorial tutorial = QuickTutorialFactory.PrepareFor(PlayerManager.Car);
				if (tutorial == null || !QuickTutorialHost.StartTutorial(tutorial))
				{
					Debug.LogWarning(N + " Tutorial failed to start for " + carID + "!");
					coro = null;
					if (PlayerManager.Car == null)
					{
						SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt("tutorial/cond/in_locomotive", pause: false, null);
					}
					yield break;
				}
				if (TutorialHelper.InRestrictedMode)
				{
					SingletonBehaviour<TutorialHelper>.Instance.RemoveImmobilizationFromLoco(PlayerManager.Car);
				}
				Debug.Log(N + " Tutorial started for " + carID);
				while (QuickTutorialHost.IsTutorialRunning)
				{
					yield return null;
				}
				yield return WaitFor.Seconds(1f);
				if (tutorial.IsFailed || tutorial.IsAborted)
				{
					Debug.Log(N + " First part failed or aborted, not continuing.");
					coro = null;
					yield break;
				}
				UpdateProgressionState(carID, state: true);
			}
			coro = null;
		}

		public bool WasTutorialAlreadyPlayed(string carID)
		{
			if (!supportedLocoIds.TryGetValue(carID, out var value))
			{
				Debug.LogWarning(N + " Unsupported carID " + carID + ", assuming that tutorial has already been passed for this car type");
				return true;
			}
			if (SingletonBehaviour<UserManager>.Instance == null)
			{
				Debug.LogError(N + " Couldn't find UserManager, assuming that tutorial has already been passed for this car type");
				return true;
			}
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			if (currentUser == null || currentUser.GameData == null)
			{
				Debug.LogError(N + " Couldn't find current user's data, assuming that tutorial has already been passed for this car type");
				return true;
			}
			try
			{
				bool? flag = currentUser.GameData.GetBool(value);
				if (!flag.HasValue && value == "QT_DE2")
				{
					return true;
				}
				return flag.HasValue && flag.Value;
			}
			catch (Exception exception)
			{
				Debug.LogError(N + " Caught the following error, assuming that tutorial hasn't already been passed");
				Debug.LogException(exception);
				return false;
			}
		}

		public void UpdateProgressionState(string carID, bool state)
		{
			if (!supportedLocoIds.TryGetValue(carID, out var value))
			{
				Debug.LogError(N + " Unsupported carID " + carID + ", not writing anything to user data");
				return;
			}
			if (SingletonBehaviour<UserManager>.Instance == null)
			{
				Debug.LogError(N + " Couldn't find UserManager, not writing anything to user data");
				return;
			}
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			if (currentUser == null || currentUser.GameData == null)
			{
				Debug.LogError(N + " Couldn't find current user's data, not writing anything to user data");
				return;
			}
			try
			{
				currentUser.GameData.SetBool(value, state);
				currentUser.Save(UserSavingMode.JustUser);
				Debug.Log($"{N} Written {value} {state}");
			}
			catch (Exception exception)
			{
				Debug.LogError($"{N} Caught the following error when attempting to write progression state {state} for car {carID} to user data");
				Debug.LogException(exception);
			}
		}

		public bool IsPlayerOnLocoThatSupportsQuickTutorial()
		{
			if (PlayerManager.Car == null)
			{
				return false;
			}
			string id = PlayerManager.Car.carLivery.id;
			LocoRestorationController forTrainCar = LocoRestorationController.GetForTrainCar(PlayerManager.Car);
			if (forTrainCar != null && forTrainCar.State < LocoRestorationController.RestorationState.S9_LocoServiced)
			{
				return false;
			}
			return supportedLocoIds.ContainsKey(id);
		}
	}
}
