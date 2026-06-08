using System;
using KitchenData;
using Shapes;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class LevelProgressSubview : MonoBehaviour, INewsItemSubview
	{
		private enum State
		{
			None = 0,
			Filling = 1,
			FillingPartially = 2,
			Emptying = 3,
			Waiting = 4
		}

		public TextMeshPro Text;

		public Line ProgressLine;

		public AnimationCurve FillPartialCurve;

		public AnimationCurve EmptyCurve;

		public AnimationCurve FillCurve;

		public AnimationCurve WaitingCurve;

		private AnimationCurve CurrentCurve;

		private float CurrentFillAmount;

		private float LineLength;

		private int FullLevelUps;

		private float StartExp;

		private float EndExp;

		private int FinalLevel;

		private float AnimationSpeed;

		private float AnimationProgress;

		private float PreviousBar;

		private float TargetBar;

		private State CurrentState;

		private bool HasStarted;

		public void SetChange(CExpChange change, bool force = false)
		{
			if (!HasStarted || force)
			{
				HasStarted = true;
				FullLevelUps = change.New.Level - change.Old.Level;
				StartExp = change.Old.GetProgressPercent();
				EndExp = change.New.GetProgressPercent();
				FinalLevel = change.New.Level;
				CurrentFillAmount = StartExp;
				UpdateFill();
				UpdateText();
				SetState(State.Waiting, Mathf.Clamp01(CurrentFillAmount + 0.1f));
			}
		}

		private void Awake()
		{
			CurrentCurve = FillCurve;
			LineLength = ProgressLine.End.x;
		}

		public void Update()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			AnimationProgress += unscaledDeltaTime * AnimationSpeed;
			CurrentFillAmount = CurrentCurve.Evaluate(AnimationProgress) * (TargetBar - PreviousBar) + PreviousBar;
			if (AnimationProgress >= 1f)
			{
				switch (CurrentState)
				{
				case State.Filling:
					LoopComplete();
					break;
				case State.FillingPartially:
					PartialFillComplete();
					break;
				case State.Emptying:
					EmptyComplete();
					break;
				case State.Waiting:
					WaitComplete();
					break;
				}
			}
			UpdateFill();
		}

		private void SetState(State state, float target)
		{
			CurrentState = state;
			CurrentCurve = state switch
			{
				State.Filling => FillCurve, 
				State.FillingPartially => FillPartialCurve, 
				State.Emptying => EmptyCurve, 
				State.Waiting => WaitingCurve, 
				_ => FillCurve, 
			};
			AnimationSpeed = state switch
			{
				State.Filling => 0.5f, 
				State.FillingPartially => 0.25f / ((Math.Abs(target - CurrentFillAmount) < 0.01f) ? 1f : (target - CurrentFillAmount)), 
				State.Emptying => 1.5f, 
				State.Waiting => 0.5f, 
				_ => 1f, 
			};
			PreviousBar = CurrentFillAmount;
			TargetBar = target;
			AnimationProgress = 0f;
		}

		private void UpdateText()
		{
			int num = FinalLevel - FullLevelUps;
			Text.text = GameData.Main.GlobalLocalisation["LEVEL", new object[1] { num + 1 }];
		}

		private void UpdateFill(bool jump = true)
		{
			CurrentFillAmount = Mathf.Clamp01(CurrentFillAmount);
			ProgressLine.End = new Vector3(LineLength * CurrentFillAmount, 0f, 0f);
		}

		private void PartialFillComplete()
		{
			SetState(State.None, CurrentFillAmount);
		}

		private void WaitComplete()
		{
			if (FullLevelUps > 0)
			{
				SetState(State.Filling, 1f);
			}
			else
			{
				SetState(State.FillingPartially, EndExp);
			}
		}

		private void EmptyComplete()
		{
			if (FullLevelUps > 0)
			{
				SetState(State.Filling, 1f);
			}
			else
			{
				SetState(State.FillingPartially, EndExp);
			}
		}

		private void LoopComplete()
		{
			FullLevelUps--;
			UpdateText();
			SetState(State.Emptying, 0f);
		}

		public void SetItem(int id)
		{
		}
	}
}
