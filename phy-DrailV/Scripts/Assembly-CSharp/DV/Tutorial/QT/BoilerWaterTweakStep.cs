using DV.CabControls;
using DV.Interaction.Inputs;
using DV.Localization;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class BoilerWaterTweakStep : AQuickTutorialStep
	{
		private enum State
		{
			Initial = 0,
			WhereNext = 1,
			OpenInjector = 2,
			CloseInjector = 3,
			OpenBlowdown = 4,
			CloseBlowdown = 5,
			WaitForIndicator = 6,
			GoodRangeConfirmation = 7
		}

		private Indicator boilerWaterIndicator;

		private ControlImplBase injectorControl;

		private ControlImplBase blowdownControl;

		private State state;

		private QTVerb verbToUse;

		private ControlIconQuickTutorialMessage changeableMessage;

		public BoilerWaterTweakStep(Indicator boilerWaterIndicator, ControlImplBase injectorControl, ControlImplBase blowdownControl, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(new ControlIconQuickTutorialMessage("", ""), boilerWaterIndicator.transform, offset, shouldRecheck)
		{
			this.boilerWaterIndicator = boilerWaterIndicator;
			this.injectorControl = injectorControl;
			this.blowdownControl = blowdownControl;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			changeableMessage = (ControlIconQuickTutorialMessage)Message;
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			if (!VRManager.IsVREnabled() && state == State.GoodRangeConfirmation)
			{
				InputManager.SetInteractConflictersEnabled(on: true);
			}
		}

		protected override bool InternalCheck()
		{
			float normalizedValue = boilerWaterIndicator.GetNormalizedValue();
			bool flag = normalizedValue <= 0.1f;
			bool flag2 = normalizedValue >= 0.9f;
			bool flag3 = injectorControl.Value > 0f;
			bool flag4 = blowdownControl.Value > 0f;
			bool flag5 = !flag && !flag2;
			State state = this.state;
			switch (this.state)
			{
			case State.Initial:
				if (flag5 && !flag3 && !flag4)
				{
					return true;
				}
				this.state = State.WhereNext;
				break;
			case State.OpenInjector:
				if (flag3)
				{
					this.state = State.WhereNext;
				}
				break;
			case State.CloseInjector:
				if (!flag3)
				{
					this.state = State.WhereNext;
				}
				break;
			case State.OpenBlowdown:
				if (flag4)
				{
					this.state = State.WhereNext;
				}
				break;
			case State.CloseBlowdown:
				if (!flag4)
				{
					this.state = State.WhereNext;
				}
				break;
			case State.WaitForIndicator:
				if (normalizedValue > 0.2f && normalizedValue < 0.8f)
				{
					this.state = State.WhereNext;
				}
				break;
			case State.GoodRangeConfirmation:
				if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Interact) || SingletonBehaviour<TutorialHelper>.Instance.IsAnyVRContinueButtonPressed)
				{
					return true;
				}
				break;
			case State.WhereNext:
				if (flag5)
				{
					if (flag3)
					{
						this.state = State.CloseInjector;
					}
					else if (flag4)
					{
						this.state = State.CloseBlowdown;
					}
					else
					{
						this.state = State.GoodRangeConfirmation;
					}
				}
				else if (flag)
				{
					if (flag4)
					{
						this.state = State.CloseBlowdown;
					}
					else if (flag3)
					{
						this.state = State.WaitForIndicator;
					}
					else
					{
						this.state = State.OpenInjector;
					}
				}
				else if (flag2)
				{
					if (flag3)
					{
						this.state = State.CloseInjector;
					}
					else if (flag4)
					{
						this.state = State.WaitForIndicator;
					}
					else
					{
						this.state = State.OpenBlowdown;
					}
				}
				else
				{
					Debug.LogError("Unexpected state: BoilerWaterTweakStep got into bad state!");
				}
				break;
			default:
				Debug.LogError("Unexpected state: BoilerWaterTweakStep got into bad state!");
				break;
			}
			if (state != this.state)
			{
				switch (this.state)
				{
				case State.OpenInjector:
					UpdateVisuals(LocalizationAPI.L("car/tut/injector"), LocalizationAPI.L("tutorial/control/injector"), injectorControl, QTVerb.Open, QTSemantic.Open, injectorControl.transform);
					break;
				case State.CloseInjector:
					UpdateVisuals(LocalizationAPI.L("car/tut/injector"), LocalizationAPI.L("tutorial/control/injector"), injectorControl, QTVerb.Close, QTSemantic.Close, injectorControl.transform);
					break;
				case State.OpenBlowdown:
					UpdateVisuals(LocalizationAPI.L("car/tut/waterdump"), LocalizationAPI.L("tutorial/control/blowdown"), blowdownControl, QTVerb.Open, QTSemantic.Open, blowdownControl.transform);
					break;
				case State.CloseBlowdown:
					UpdateVisuals(LocalizationAPI.L("car/tut/waterdump"), LocalizationAPI.L("tutorial/control/blowdown"), blowdownControl, QTVerb.Close, QTSemantic.Close, blowdownControl.transform);
					break;
				case State.WaitForIndicator:
					UpdateVisuals(LocalizationAPI.L("car/tut/water"), LocalizationAPI.L("tutorial/loco/steam_wait_water_range"), boilerWaterIndicator, QTVerb.Monitor, QTSemantic.Monitor, boilerWaterIndicator.transform);
					break;
				case State.GoodRangeConfirmation:
					UpdateVisuals(LocalizationAPI.L("car/tut/water"), LocalizationAPI.L("tutorial/loco/steam_water_in_range") + GetContinuePromptSuffix(), boilerWaterIndicator, QTVerb.Look, QTSemantic.Look, boilerWaterIndicator.transform);
					if (!VRManager.IsVREnabled())
					{
						InputManager.SetInteractConflictersEnabled(on: false);
					}
					break;
				default:
					Debug.LogError("Unexpected state: BoilerWaterTweakStep");
					break;
				case State.WhereNext:
					break;
				}
			}
			return false;
		}

		private void UpdateVisuals(string controlName, string controlDescription, Behaviour controlBehaviour, QTVerb verb, QTSemantic semantic, Transform attentionPoint)
		{
			changeableMessage.controlName = controlName;
			changeableMessage.controlDescription = controlDescription;
			verbToUse = verb;
			changeableMessage.WithSprite(null, controlBehaviour, semantic);
			AttentionPoint = attentionPoint;
			ShowVisual();
		}

		protected override QTVerb GetVerb()
		{
			return verbToUse;
		}
	}
}
