using System;
using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class Combo
	{
		public ModeID Mode;

		public string Name = "Combo1";

		public Mode CachedMode;

		[Tooltip("After the Combo is Finished, With a finisher it cannot play again until the cooldown has passed")]
		public FloatReference CoolDown = new FloatReference();

		[Tooltip("States the Combo can be played")]
		public List<StateID> states = new List<StateID>();

		public float FinishTime;

		public List<ComboSequence> Sequence = new List<ComboSequence>();

		public IntEvent OnComboFinished = new IntEvent();

		public IntEvent OnComboInterrupted = new IntEvent();

		private IEnumerator C_WaitBuffer;

		public bool InCoolDown
		{
			get
			{
				if ((float)CoolDown > 0f)
				{
					return Time.time - FinishTime <= (float)CoolDown;
				}
				return false;
			}
		}

		public ComboSequence CurrentSequence { get; internal set; }

		public int ActiveSequenceIndex { get; internal set; }

		public int ComboIndex { get; internal set; }

		public void ResetCoolDown()
		{
			FinishTime = Time.time - (float)CoolDown * 2f;
		}

		public bool HasState(StateID activeState)
		{
			if (states != null && states.Count != 0)
			{
				return states.Contains(activeState);
			}
			return true;
		}

		public bool Play(ComboManager M)
		{
			if (M.ActiveComboSequence != null && M.ActiveComboSequence.Buffer)
			{
				return false;
			}
			MAnimal animal = M.animal;
			if (animal.IsPreparingMode)
			{
				return false;
			}
			ActiveSequenceIndex = Mathf.Clamp(ActiveSequenceIndex, 0, Sequence.Count - 1);
			if (!animal.IsPlayingMode || animal.ActiveMode != CachedMode)
			{
				for (int i = 0; i < Sequence.Count; i++)
				{
					ComboSequence comboSequence = Sequence[i];
					if (comboSequence.Used || comboSequence.Branch != M.Branch || comboSequence.PreviewsAbility != 0)
					{
						continue;
					}
					if (CachedMode.TryActivate(comboSequence.Ability))
					{
						M.PlayingCombo = true;
						PlaySequence(M, comboSequence);
						ActiveSequenceIndex = i;
						if (CachedMode.ActiveAbility.Status == AbilityStatus.Charged)
						{
							CachedMode.InputValue = true;
						}
						return true;
					}
					M.MDebug("Try Activate First Sequence (" + CachedMode.Name + ") Failed. Check Mode Conditions");
					return false;
				}
			}
			else
			{
				float modeTime = animal.ModeTime;
				ComboSequence comboSequence2 = Sequence[ActiveSequenceIndex];
				if (comboSequence2.Finisher)
				{
					if (comboSequence2.Restarter && comboSequence2.FinisherTime < modeTime)
					{
						OnComboFinished.Invoke(ActiveSequenceIndex);
						M.MDebug($"Combo Finished -<RESTARTING>-. <b>[{ActiveSequenceIndex}]</b> Branch:<b>[{M.Branch}]</b>. [Restarting]");
						M.Restart();
						for (int j = 0; j < Sequence.Count; j++)
						{
							ComboSequence comboSequence3 = Sequence[j];
							if (!comboSequence3.Used && comboSequence3.Branch == M.Branch && comboSequence3.PreviewsAbility == 0)
							{
								if (CachedMode.ForceActivate(comboSequence3.Ability))
								{
									M.PlayingCombo = true;
									PlaySequence(M, comboSequence3);
									ActiveSequenceIndex = j;
									return true;
								}
								M.MDebug("Try Activate First Sequence (" + CachedMode.Name + ") Failed. Check Mode Conditions");
								return false;
							}
						}
					}
					return true;
				}
				for (int k = ActiveSequenceIndex + 1; k < Sequence.Count; k++)
				{
					ComboSequence comboSequence4 = Sequence[k];
					if (comboSequence4.Used || comboSequence4.Branch != M.Branch || comboSequence4.PreviewsAbility == 0 || comboSequence4.PreviewsAbility != CachedMode.AbilityIndex)
					{
						continue;
					}
					if (comboSequence4.Activation.IsInRange(modeTime))
					{
						if (modeTime > comboSequence4.ActivationTime)
						{
							animal.Mode_ForceActivate(Mode, comboSequence4.Ability);
							PlaySequence(M, comboSequence4);
							ActiveSequenceIndex = k;
						}
						else if (!comboSequence4.Buffer)
						{
							comboSequence4.Buffer = true;
							M.MDebug($"Sequence <b>[{k}]</b> [**Buffering**] - Branch:<b>[{M.Branch}]</b>. [{animal.ModeTime:F2}]");
							if (C_WaitBuffer != null)
							{
								M.StopCoroutine(C_WaitBuffer);
							}
							C_WaitBuffer = WaitForBuffer(M, comboSequence4, k);
							M.StartCoroutine(C_WaitBuffer);
						}
					}
					return true;
				}
			}
			return false;
		}

		private void PlaySequence(ComboManager M, ComboSequence sequence)
		{
			CurrentSequence = sequence;
			CurrentSequence.Used = true;
			M.ActiveComboSequenceIndex = Mode.ID * 1000 + sequence.Ability;
			CurrentSequence.OnSequencePlay.Invoke(M.ActiveComboSequenceIndex);
			M.MDebug($"Sequence [{ActiveSequenceIndex}]: <b>[{M.ActiveComboSequenceIndex}]</b> - Branch:<b>[{M.Branch}]</b>. Time: {M.animal.ModeTime:F2}");
		}

		private IEnumerator WaitForBuffer(ComboManager M, ComboSequence seq, int Index)
		{
			yield return new WaitUntil(() => M.animal.ModeTime > seq.ActivationTime);
			seq.Buffer = false;
			M.animal.Mode_ForceActivate(Mode, seq.Ability);
			PlaySequence(M, seq);
			ActiveSequenceIndex = Index;
		}
	}
}
