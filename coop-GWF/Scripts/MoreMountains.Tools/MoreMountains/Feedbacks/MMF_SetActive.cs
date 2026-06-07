using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to change the state of the target gameobject from active to inactive (or the opposite), on init, play, stop or reset. For each of these you can specify if you want to force a state (active or inactive), or toggle it (active becomes inactive, inactive becomes active).")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("GameObject/Set Active")]
	public class MMF_SetActive : MMF_Feedback
	{
		public enum PossibleStates
		{
			Active = 0,
			Inactive = 1,
			Toggle = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Set Active Target", true, 12, true, false)]
		[Tooltip("the gameobject we want to change the active state of")]
		public GameObject TargetGameObject;

		[Tooltip("a list of extra gameobjects we want to change the active state of")]
		public List<GameObject> ExtraTargetGameObjects;

		[MMFInspectorGroup("States", true, 14, false, false)]
		[Tooltip("whether or not we should alter the state of the target object on init")]
		public bool SetStateOnInit;

		[MMFCondition("SetStateOnInit", true)]
		[Tooltip("how to change the state on init")]
		public PossibleStates StateOnInit = PossibleStates.Inactive;

		[Tooltip("whether or not we should alter the state of the target object on play")]
		public bool SetStateOnPlay;

		[Tooltip("how to change the state on play")]
		[MMFCondition("SetStateOnPlay", true)]
		public PossibleStates StateOnPlay = PossibleStates.Inactive;

		[Tooltip("whether or not we should alter the state of the target object on stop")]
		public bool SetStateOnStop;

		[Tooltip("how to change the state on stop")]
		[MMFCondition("SetStateOnStop", true)]
		public PossibleStates StateOnStop = PossibleStates.Inactive;

		[Tooltip("whether or not we should alter the state of the target object on reset")]
		public bool SetStateOnReset;

		[Tooltip("how to change the state on reset")]
		[MMFCondition("SetStateOnReset", true)]
		public PossibleStates StateOnReset = PossibleStates.Inactive;

		[Tooltip("whether or not we should alter the state of the target object on skip")]
		public bool SetStateOnSkip;

		[Tooltip("how to change the state on skip")]
		[MMFCondition("SetStateOnSkip", true)]
		public PossibleStates StateOnSkip = PossibleStates.Inactive;

		[Tooltip("whether or not we should alter the state of the target object when the player this feedback belongs to is done playing all its feedbacks")]
		public bool SetStateOnPlayerComplete;

		[Tooltip("how to change the state on player complete")]
		[MMFCondition("SetStateOnPlayerComplete", true)]
		public PossibleStates StateOnPlayerComplete = PossibleStates.Inactive;

		protected bool _initialState;

		protected List<bool> _initialStates;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetGameObject = FindAutomatedTargetGameObject();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			_initialStates = new List<bool>(ExtraTargetGameObjects.Count);
			if (Active && TargetGameObject != null)
			{
				_initialState = TargetGameObject.activeInHierarchy;
				for (int i = 0; i < ExtraTargetGameObjects.Count; i++)
				{
					_initialStates.Add(ExtraTargetGameObjects[i].activeInHierarchy);
				}
				if (SetStateOnInit)
				{
					SetStatus(StateOnInit);
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetGameObject == null) && SetStateOnPlay)
			{
				SetStatus(StateOnPlay);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			base.CustomStopFeedback(position, feedbacksIntensity);
			if (Active && FeedbackTypeAuthorized && TargetGameObject != null && SetStateOnStop)
			{
				SetStatus(StateOnStop);
			}
		}

		protected override void CustomReset()
		{
			base.CustomReset();
			if (!InCooldown && Active && FeedbackTypeAuthorized && TargetGameObject != null && SetStateOnReset)
			{
				SetStatus(StateOnReset);
			}
		}

		protected override void CustomPlayerComplete()
		{
			base.CustomPlayerComplete();
			if (!InCooldown && Active && FeedbackTypeAuthorized && TargetGameObject != null && SetStateOnPlayerComplete)
			{
				SetStatus(StateOnPlayerComplete);
			}
		}

		protected override void CustomSkipToTheEnd(Vector3 position, float feedbacksIntensity = 1f)
		{
			base.CustomSkipToTheEnd(position, feedbacksIntensity);
			if (!InCooldown && Active && FeedbackTypeAuthorized && TargetGameObject != null && SetStateOnSkip)
			{
				SetStatus(StateOnSkip);
			}
		}

		protected virtual void SetStatus(PossibleStates state)
		{
			bool newState = false;
			switch (state)
			{
			case PossibleStates.Active:
				newState = (NormalPlayDirection ? true : false);
				break;
			case PossibleStates.Inactive:
				newState = !NormalPlayDirection;
				break;
			case PossibleStates.Toggle:
				newState = !TargetGameObject.activeInHierarchy;
				break;
			}
			ApplyStatus(TargetGameObject, newState);
			foreach (GameObject extraTargetGameObject in ExtraTargetGameObjects)
			{
				ApplyStatus(extraTargetGameObject, newState);
			}
		}

		protected virtual void ApplyStatus(GameObject target, bool newState)
		{
			target.SetActive(newState);
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetGameObject.SetActive(_initialState);
				for (int i = 0; i < ExtraTargetGameObjects.Count; i++)
				{
					ExtraTargetGameObjects[i].SetActive(_initialStates[i]);
				}
			}
		}
	}
}
