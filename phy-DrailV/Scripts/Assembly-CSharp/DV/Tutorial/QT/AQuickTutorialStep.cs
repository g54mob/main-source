using System;
using DV.Interaction.Inputs;
using DV.Localization;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public abstract class AQuickTutorialStep
	{
		private AQuickTutorialCondition checkCondition;

		private bool checkDesiredValue;

		private bool instantSkip;

		protected bool shownFloatie;

		public virtual AQuickTutorialMessage Message { get; protected set; }

		public virtual Sprite Visual { get; protected set; }

		public virtual Transform AttentionPoint { get; protected set; }

		public virtual Vector3 AttentionOffset { get; protected set; }

		public QuickTutorialHost Host { get; private set; }

		public virtual bool ShouldRecheck { get; protected set; } = true;

		public virtual bool AttentionOnGUI { get; protected set; }

		public bool IsActive { get; private set; }

		protected abstract bool InternalCheck();

		public AQuickTutorialStep(AQuickTutorialMessage message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
		{
			Message = message;
			AttentionPoint = ProcessAttentionPoint(attentionPoint);
			AttentionOffset = attentionOffset;
			ShouldRecheck = shouldRecheck;
		}

		protected virtual Transform ProcessAttentionPoint(Transform attentionPoint)
		{
			return attentionPoint;
		}

		public void SetCheckingCondition(AQuickTutorialCondition condition, bool desiredValueToCheck)
		{
			if (IsActive)
			{
				throw new InvalidOperationException("Can't add AQuickTutorialCondition while step is active, check code");
			}
			checkCondition = condition;
			checkDesiredValue = desiredValueToCheck;
		}

		public bool Check()
		{
			if (instantSkip)
			{
				return true;
			}
			if (checkCondition != null && checkCondition.CheckAsBool() != checkDesiredValue)
			{
				return true;
			}
			return InternalCheck();
		}

		protected virtual QTVerb GetVerb()
		{
			return QTVerb.None;
		}

		protected virtual void InternalMakeCurrent()
		{
		}

		protected virtual void InternalDeactivate()
		{
		}

		public void MakeCurrent(QuickTutorialHost host)
		{
			Host = host;
			IsActive = true;
			instantSkip = false;
			if (checkCondition != null)
			{
				checkCondition.Start();
				if (checkCondition.CheckAsBool() != checkDesiredValue)
				{
					instantSkip = true;
					return;
				}
			}
			InternalMakeCurrent();
		}

		public static string GetVerbLocalizedString(QTVerb verb)
		{
			return LocalizationAPI.L("tutorial/verb/" + verb.ToString().ToLower());
		}

		public static string GetVerbColor(QTVerb verb)
		{
			if (!object.Equals(QTVerb.Look, verb) && !object.Equals(QTVerb.Monitor, verb))
			{
				return "#ffff00";
			}
			return "#00ffff";
		}

		public virtual void ShowVisual()
		{
			if (Message != null)
			{
				string message = Message.GetMessage(GetVerb());
				if (!string.IsNullOrEmpty(message))
				{
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, AttentionPoint, AttentionOffset, localize: false, AttentionOnGUI);
					shownFloatie = true;
				}
			}
		}

		protected virtual void HideVisual()
		{
			if (shownFloatie)
			{
				if ((bool)SingletonBehaviour<TutorialHelper>.Instance)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
				}
				shownFloatie = false;
			}
		}

		protected string GetContinuePromptSuffix()
		{
			string text;
			if (VRManager.IsVREnabled())
			{
				string firstParamValue = (VRManager.AnyWandController() ? LocalizationAPI.L("vr/meta/right_touchpad_up") : LocalizationAPI.L("vr/meta/right_joystick_up"));
				text = LocalizationAPI.L("tutorial/to_continue_vr", firstParamValue);
			}
			else
			{
				text = LocalizationAPI.L("tutorial/to_continue_nonvr", InputManager.Actions.Interact.LocalizeInput());
			}
			return "<align=\"left\"><br>\n<b><color=#00ffff>" + text + "</color></b></align>\n";
		}

		public void Deactivate()
		{
			HideVisual();
			IsActive = false;
			if (checkCondition != null)
			{
				checkCondition.Deactivate();
			}
			if (instantSkip)
			{
				instantSkip = false;
			}
			else
			{
				InternalDeactivate();
			}
			Host = null;
		}
	}
}
