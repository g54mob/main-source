using I2.Loc;
using UnityEngine;

public class DistractionDie : DistractionBase
{
	private DogBehaviorBase deathKnell;

	private bool deathKnellRun;

	private bool deathPopupShown;

	private bool deathPopupClosed;

	private DeathReason deathReason;

	private GUIManagerPens guiRef;

	public DistractionDie(DogAI newAIRef, float newWeight, DeathReason reasonForDeath)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.CRITICAL;
		deathKnell = aiRef.fixationTypeBehaviorMapping[FixationType.DEATH_KNELL][0];
		guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		deathReason = reasonForDeath;
	}

	public override void Update()
	{
		base.Update();
		if (!GameSettings.IsDogDeathEnabled())
		{
			aiRef.ForceInterruptBehavior();
			aiRef.OnDistractionDone(this);
			return;
		}
		if (!deathPopupShown && guiRef.GetGUIInteractiveStatus())
		{
			ShowDeathPopup();
			return;
		}
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null)
		{
			if (deathKnellRun)
			{
				OnDeathKnellComplete();
			}
			else
			{
				FindNewBehavior(forceInterrupt: true);
			}
		}
	}

	public override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		if (!deathPopupShown || !deathPopupClosed)
		{
			aiRef.FindNewBehavior();
			currentRunningBehavior = aiRef.GetCurrentBehavior();
			if (currentRunningBehavior != null && !deathPopupShown && guiRef.GetGUIInteractiveStatus())
			{
				ShowDeathPopup();
			}
			return true;
		}
		if (aiRef.TryRunBehavior(deathKnell, null, forceInterrupt))
		{
			deathKnellRun = true;
			currentRunningBehavior = aiRef.GetCurrentBehavior();
			return true;
		}
		OnDeathKnellComplete();
		return false;
	}

	private void ShowDeathPopup()
	{
		deathPopupShown = true;
		if (GameSettings.IsPassiveModeEnabled())
		{
			if (GameSettings.PassiveModeDeathNotificationOption() == GameSettings.PassiveNotificationsOption.SMALL_NOTIF)
			{
				Sprite defaultThumbnailForDog = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetDefaultThumbnailForDog(aiRef.gameObject);
				guiRef.ShowPassiveModeNotification(ScriptLocalization.GUI.GUI_POPUP_DEATH_HEADER, GetBodyTextForDeathReason(usePassiveModeSmallNotif: true), defaultThumbnailForDog);
				if (GameSettings.PassiveModeFocusOnDyingDogs())
				{
					if (GameSettings.PassiveModeRandomDogFocus())
					{
						Camera.main.GetComponent<PenFocus>().AutoFocusOnDogIfNeeded(aiRef.gameObject);
					}
					else
					{
						Camera.main.GetComponent<PenFocus>().AutoFocusOnRoomObjectIsInIfNeeded(aiRef.gameObject);
					}
				}
				OnDeathPopupClosed();
				return;
			}
			if (GameSettings.PassiveModeDeathNotificationOption() == GameSettings.PassiveNotificationsOption.DISABLED)
			{
				if (GameSettings.PassiveModeFocusOnDyingDogs())
				{
					Camera.main.GetComponent<PenFocus>().AutoFocusOnDogIfNeeded(aiRef.gameObject);
				}
				OnDeathPopupClosed();
				return;
			}
		}
		guiRef.RequestGenericPopup(ScriptLocalization.GUI.GUI_POPUP_DEATH_HEADER, GetBodyTextForDeathReason(), MoveCamera, OnDeathPopupClosed);
	}

	private string GetBodyTextForDeathReason(bool usePassiveModeSmallNotif = false)
	{
		bool flag = false;
		string text = "";
		string dogName = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetSaveableDogFromDog(aiRef.gameObject)
			.dogName;
		switch (deathReason)
		{
		case DeathReason.OLD_AGE:
			flag = true;
			text = ScriptLocalization.GUI.GUI_POPUP_DEATH_OLD;
			break;
		case DeathReason.HUNGER:
			flag = true;
			text = ScriptLocalization.GUI.GUI_POPUP_DEATH_HUNGER;
			break;
		}
		if (usePassiveModeSmallNotif)
		{
			flag = true;
			text = ScriptLocalization.GUI.GUI_POPUP_DEATH_SHORT;
		}
		if (flag)
		{
			int length = text.IndexOf("[");
			int num = text.IndexOf("]");
			return text.Substring(0, length) + dogName + text.Substring(num + 1);
		}
		return ScriptLocalization.GUI.GUI_POPUP_DEATH_NOREASON;
	}

	private void MoveCamera()
	{
		Camera.main.GetComponent<PenFocus>().RequestFollowCam(aiRef.GetComponent<LegController>().bodyFront.transform);
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).SelectDog(aiRef.gameObject);
		OnDeathPopupClosed();
	}

	private void OnDeathPopupClosed()
	{
		deathPopupClosed = true;
		aiRef.ForceInterruptBehavior();
		FindNewBehavior(forceInterrupt: true);
	}

	private void OnDeathKnellComplete()
	{
		aiRef.OnDistractionDone(this);
		aiRef.GetComponent<DoggyBrain>().Die(deathReason);
	}
}
