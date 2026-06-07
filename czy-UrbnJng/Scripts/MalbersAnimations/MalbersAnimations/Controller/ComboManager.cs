using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[DefaultExecutionOrder(3000)]
	[AddComponentMenu("Malbers/Animal Controller/Combo Manager")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/combo-manager")]
	public class ComboManager : MonoBehaviour
	{
		[RequiredField]
		public MAnimal animal;

		public int Branch;

		public List<Combo> combos = new List<Combo>();

		private List<Combo> extraStateCombos;

		[Tooltip("Current Active Combo Index")]
		public IntReference ActiveComboIndex = new IntReference(0);

		[Tooltip("Disable Combo Manager if the animal is Sleep.")]
		public bool DisableOnSleep = true;

		public bool debug;

		[HideInInspector]
		public int selectedComboEditor = -1;

		public Combo ActiveCombo { get; internal set; }

		public int ActiveComboSequenceIndex { get; internal set; }

		public ComboSequence ActiveComboSequence => ActiveCombo.CurrentSequence;

		public bool PlayingCombo { get; internal set; }

		private void OnValidate()
		{
			ActiveComboIndex = Mathf.Clamp(ActiveComboIndex.Value, -1, combos.Count - 1);
		}

		private void OnEnable()
		{
			if (!animal)
			{
				animal = this.FindComponent<MAnimal>();
			}
			ActiveCombo = null;
			if (!animal)
			{
				Debug.LogWarning("The Combo Manager needs an Animal Component", base.gameObject);
				return;
			}
			animal.OnModeEnd.AddListener(OnModeEnd);
			animal.OnStateActivate.AddListener(OnStateEnter);
			for (int i = 0; i < combos.Count; i++)
			{
				Combo combo = combos[i];
				combo.ComboIndex = i;
				combo.FinishTime = 0f - (float)combo.CoolDown;
				combo.CachedMode = animal.Mode_Get(combo.Mode);
				if (combo.CachedMode == null)
				{
					Debug.LogError("Animal " + animal.name + " does not have the mode " + combo.Mode.name + ". Please Add it to your animal", this);
				}
			}
			if ((int)ActiveComboIndex >= 0)
			{
				ActiveCombo = combos[ActiveComboIndex];
				ActiveComboSequenceIndex = 0;
				PlayingCombo = false;
				RestartActiveCombo();
			}
		}

		private void OnDisable()
		{
			animal.OnStateActivate.RemoveListener(OnStateEnter);
			animal.OnModeEnd.RemoveListener(OnModeEnd);
			StopAllCoroutines();
		}

		private void OnStateEnter(int stateID)
		{
			if (DisableOnSleep || !base.enabled || ActiveCombo == null || (int)ActiveComboIndex == -1)
			{
				return;
			}
			StateID activeStateID = animal.ActiveStateID;
			if (extraStateCombos == null)
			{
				return;
			}
			foreach (Combo extraStateCombo in extraStateCombos)
			{
				if (extraStateCombo == ActiveCombo && extraStateCombo.HasState(activeStateID))
				{
					break;
				}
				if (extraStateCombo.HasState(activeStateID))
				{
					SetActiveCombo(ActiveCombo.Mode);
					break;
				}
			}
		}

		private void OnModeEnd(int modeID, int CurrentExitAbility)
		{
			if (PlayingCombo)
			{
				if (ActiveComboSequence == null)
				{
					Restart();
				}
				else if (ActiveComboSequence.Finisher)
				{
					ActiveCombo.OnComboFinished.Invoke(ActiveComboSequenceIndex);
					MDebug($"Combo Finished. <b>[{ActiveComboSequenceIndex}]</b> Branch:<b>[{Branch}]</b>. [Restarting]");
					Restart();
					ActiveCombo.FinishTime = Time.time;
				}
				else if (CurrentExitAbility == ActiveComboSequence.Ability && !animal.IsPlayingMode)
				{
					MDebug($"Incomplete <b>[{ActiveComboSequenceIndex}]</b> Branch: <b>[{Branch}]</b>. [Restarting*]");
					ActiveCombo.OnComboInterrupted.Invoke(ActiveComboSequenceIndex);
					Restart();
					ActiveCombo.FinishTime = Time.time;
				}
			}
		}

		public virtual void SetActiveCombo(int index)
		{
			ActiveComboIndex = index;
			RestartActiveCombo();
			if ((int)ActiveComboIndex < 0)
			{
				MDebug("Combo Manager Disabled. No combo set for activation.-1");
				selectedComboEditor = -1;
				ActiveCombo = null;
				return;
			}
			ActiveCombo = combos[ActiveComboIndex];
			MDebug($"Set Active Combo [{ActiveCombo.Name},Index: {index}]");
			extraStateCombos = combos.FindAll((Combo x) => x.Mode == ActiveCombo.Mode);
			selectedComboEditor = ActiveComboIndex;
		}

		public virtual void SetActiveCombo(ModeID ComboMode)
		{
			if (ComboMode == null)
			{
				SetActiveCombo(-1);
				return;
			}
			PlayingCombo = false;
			RestartActiveCombo();
			int activeCombo = combos.FindIndex((Combo x) => x.Mode == ComboMode && x.HasState(animal.ActiveStateID));
			SetActiveCombo(activeCombo);
		}

		public virtual void SetActiveCombo(IntVar index)
		{
			SetActiveCombo(index.Value);
		}

		public virtual void SetActiveCombo(string ComboName)
		{
			int activeCombo = combos.FindIndex((Combo x) => x.Name == ComboName);
			SetActiveCombo(activeCombo);
		}

		public virtual void Play()
		{
			TryPlay(Branch);
		}

		public virtual bool TryPlay()
		{
			return TryPlay(Branch);
		}

		public virtual void Play(int branch)
		{
			TryPlay(Branch = branch);
		}

		public virtual bool TryPlay(int branch)
		{
			if (!base.gameObject.activeInHierarchy || (DisableOnSleep && animal.Sleep) || !base.enabled || animal.LockInput || (int)ActiveComboIndex < 0)
			{
				MDebug("[Failed] Animal Disabled|Lock");
				return false;
			}
			if ((DisableOnSleep && animal.Sleep) || !base.enabled || animal.LockInput || (int)ActiveComboIndex < 0)
			{
				MDebug("[Failed] Animal Disabled|Lock");
				return false;
			}
			if (animal.IsPreparingMode)
			{
				return true;
			}
			if (!animal.IsPlayingMode)
			{
				Restart();
			}
			Branch = branch;
			if (ActiveCombo != null)
			{
				if (ActiveCombo.InCoolDown)
				{
					MDebug(ActiveCombo.Name + " - [In CoolDown]");
					return false;
				}
				return ActiveCombo.Play(this);
			}
			return false;
		}

		public virtual void SetBranch(int branch)
		{
			Branch = branch;
		}

		public virtual void Restart()
		{
			ActiveComboSequenceIndex = 0;
			PlayingCombo = false;
			RestartActiveCombo();
			MDebug("Restart");
		}

		private void RestartActiveCombo()
		{
			if (ActiveCombo == null)
			{
				return;
			}
			ActiveCombo.CurrentSequence = null;
			ActiveCombo.ActiveSequenceIndex = -1;
			foreach (ComboSequence item in ActiveCombo.Sequence)
			{
				item.Used = false;
			}
		}

		public void ResetCoolDown(string name)
		{
			combos.Find((Combo x) => x.Name == name)?.ResetCoolDown();
		}

		internal void MDebug(string value)
		{
		}

		internal Combo GetCombo(ModeID weaponID)
		{
			return combos.Find((Combo x) => x.Mode == weaponID);
		}

		private void Reset()
		{
			animal = this.FindComponent<MAnimal>();
		}
	}
}
