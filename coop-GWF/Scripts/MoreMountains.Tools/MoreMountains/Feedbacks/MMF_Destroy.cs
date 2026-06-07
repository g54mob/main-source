using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to destroy a target gameobject, either via Destroy, DestroyImmediate, or SetActive:False")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("GameObject/Destroy")]
	public class MMF_Destroy : MMF_Feedback
	{
		public enum Modes
		{
			Destroy = 0,
			DestroyImmediate = 1,
			Disable = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Destruction", true, 18, true, false)]
		[Tooltip("the game object we want to destroy")]
		public GameObject TargetGameObject;

		[Tooltip("the optional list of extra gameobjects we want to change the active state of")]
		public List<GameObject> ExtraTargetGameObjects;

		[Tooltip("the selected destruction mode")]
		public Modes Mode;

		protected bool _initialActiveState;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetGameObject = FindAutomatedTargetGameObject();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetGameObject == null)
			{
				return;
			}
			ProceedWithDestruction(TargetGameObject);
			foreach (GameObject extraTargetGameObject in ExtraTargetGameObjects)
			{
				ProceedWithDestruction(extraTargetGameObject);
			}
		}

		protected virtual void ProceedWithDestruction(GameObject go)
		{
			switch (Mode)
			{
			case Modes.Destroy:
				Owner.ProxyDestroy(go);
				break;
			case Modes.DestroyImmediate:
				Owner.ProxyDestroyImmediate(go);
				break;
			case Modes.Disable:
				_initialActiveState = go.activeInHierarchy;
				go.SetActive(value: false);
				break;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized && Mode == Modes.Disable)
			{
				TargetGameObject.SetActive(_initialActiveState);
			}
		}
	}
}
