using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class Wargame
	{
		private Wargame_HUDPopupModule m_uiModule;

		private int m_round;

		private EWargamePhase m_phase;

		private bool m_playerHasPriority;

		private bool m_playerAPlaying;

		private WargameSquad m_squadA;

		private bool[] m_squadAAlive;

		private WargameSquad m_squadB;

		private bool[] m_squadBAlive;

		private int m_playerALife;

		private int m_playerBLife;

		private int m_playerATokens;

		private int m_playerBTokens;

		private int m_playerAAssault;

		private int m_playerADamage;

		private int m_playerBAssault;

		private int m_playerBDamage;

		private WargameSkillEffect m_playerADice1Effect;

		private WargameSkillEffect m_playerADice2Effect;

		private WargameSkillEffect m_playerADice3Effect;

		private WargameSkillEffect m_playerBDice1Effect;

		private WargameSkillEffect m_playerBDice2Effect;

		private WargameSkillEffect m_playerBDice3Effect;

		private int m_playerADiceCount;

		private int m_playerACombinationSize;

		private int[] m_playerADices;

		private int[] m_playerACombination;

		private int m_playerABet;

		private int m_playerBDiceCount;

		private int m_playerBCombinationSize;

		private int[] m_playerBCombination;

		private int m_playerBBet;

		private List<int> m_usedDices = new List<int>();

		private bool[] m_playerAActivatedMiniatures;

		private bool[] m_playerBActivatedMiniatures;

		private int[] m_playerAActivationBonuses;

		private int[] m_playerBActivationBonuses;

		private int m_currentActivations;

		private int m_precedentActivations;

		private int m_allPrecedentActivations;

		private float m_gameStartTime;

		private float m_gameDuration;

		private bool m_gameOver;

		private Tween m_revealDiceDelay;

		private Sequence m_combatSequence;

		private Sequence m_endRoundSequence;

		private Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> m_playerADelayedEffects = new Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>>();

		private Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> m_playerBDelayedEffects = new Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>>();

		private List<WargameSkillEffect> m_tempDelayedEffects = new List<WargameSkillEffect>();

		private bool m_isPreview;

		private int[] m_playerAActivationCounter;

		private int[] m_playerBActivationCounter;

		public Wargame(WargameSquad squadA, WargameSquad squadB)
		{
			if (!TabletopWorld.TabletopHUDPopup.GetModule<Wargame_HUDPopupModule>(ETabletopHUDPopupModuleType.WARGAME, out m_uiModule))
			{
				Debug.LogError("Can't find HUD Popup Module");
				return;
			}
			RegisterToUICallbacks(register: true);
			m_round = 1;
			m_playerHasPriority = WargameSettings.FirstPlayer switch
			{
				EWargameFirstPlayer.PLAYER => true, 
				EWargameFirstPlayer.OPPONENT => false, 
				_ => Random.value > 0.5f, 
			};
			InitSquads(squadA, squadB);
			InitLife();
			InitTokens();
			InitDices();
			m_uiModule.InitWargame(squadA, squadB);
			UpdateUIInstant();
		}

		private void InitSquads(WargameSquad squadA, WargameSquad squadB)
		{
			m_squadA = squadA;
			m_squadAAlive = new bool[WargameSettings.SquadSize];
			m_playerAActivatedMiniatures = new bool[WargameSettings.SquadSize];
			m_playerAActivationBonuses = new int[WargameSettings.SquadSize];
			for (int i = 0; i < m_squadAAlive.Length; i++)
			{
				m_squadAAlive[i] = true;
			}
			m_squadB = squadB;
			m_squadBAlive = new bool[WargameSettings.SquadSize];
			m_playerBActivatedMiniatures = new bool[WargameSettings.SquadSize];
			m_playerBActivationBonuses = new int[WargameSettings.SquadSize];
			for (int j = 0; j < m_squadBAlive.Length; j++)
			{
				m_squadBAlive[j] = true;
			}
		}

		private void InitLife()
		{
			m_playerALife = 0;
			foreach (MiniatureData squadum in m_squadA)
			{
				m_playerALife += squadum.Skill.LifePoints;
			}
			m_playerBLife = 0;
			foreach (MiniatureData item in m_squadB)
			{
				m_playerBLife += item.Skill.LifePoints;
			}
		}

		private void InitTokens()
		{
			m_playerATokens = WargameSettings.StartToken;
			m_playerBTokens = WargameSettings.StartToken;
		}

		private void InitScores()
		{
			m_playerAAssault = WargameSettings.InitialAssault;
			m_playerADamage = WargameSettings.InitialDamage;
			m_playerBAssault = WargameSettings.InitialAssault;
			m_playerBDamage = WargameSettings.InitialDamage;
		}

		private void InitDices()
		{
			m_playerADices = new int[WargameSettings.DiceThrown];
			m_playerACombination = new int[WargameSettings.DiceKept];
			m_playerBCombination = new int[WargameSettings.DiceKept];
			m_playerADice1Effect = Object.Instantiate(WargameSettings.GetDiceEffect(1));
			m_playerADice2Effect = Object.Instantiate(WargameSettings.GetDiceEffect(2));
			m_playerADice3Effect = Object.Instantiate(WargameSettings.GetDiceEffect(3));
			m_playerBDice1Effect = Object.Instantiate(WargameSettings.GetDiceEffect(1));
			m_playerBDice2Effect = Object.Instantiate(WargameSettings.GetDiceEffect(2));
			m_playerBDice3Effect = Object.Instantiate(WargameSettings.GetDiceEffect(3));
		}

		public void Destroy()
		{
			KillAllSequences();
			RegisterToUICallbacks(register: false);
			m_uiModule.PrepareDestruction();
		}

		private void TriggerDicePhase()
		{
			m_phase = EWargamePhase.DICE;
			m_uiModule.DisplayRoundAndPriority(m_round, m_playerHasPriority);
			InitDicePhase();
			InitScores();
			TriggerRoundStartEffects();
			ApplyDiceEffects();
			RollDices();
			UpdateUIInstant();
			DoPlayerBDicePhase();
		}

		private void InitDicePhase()
		{
			m_playerADiceCount = WargameSettings.DiceThrown;
			m_playerACombinationSize = WargameSettings.DiceKept;
			m_playerABet = 0;
			m_playerBDiceCount = WargameSettings.DiceThrown;
			m_playerBCombinationSize = WargameSettings.DiceKept;
			m_playerBBet = 0;
			m_uiModule.InitDicePhase();
		}

		private void ApplyDiceEffects()
		{
			m_playerACombinationSize = Mathf.Max(1, m_playerACombinationSize);
			m_playerADiceCount = Mathf.Max(m_playerACombinationSize, m_playerADiceCount);
			m_playerADices = new int[m_playerADiceCount];
			m_playerACombination = new int[m_playerACombinationSize];
			m_playerBCombinationSize = Mathf.Max(1, m_playerBCombinationSize);
			m_playerBCombination = new int[m_playerBCombinationSize];
			m_uiModule.InitCombinations(m_playerACombinationSize, m_playerBCombinationSize);
		}

		private void RollDices()
		{
			for (int i = 0; i < m_playerADices.Length; i++)
			{
				m_playerADices[i] = WargameSettings.GetRandomDiceFace();
				m_uiModule.DisplayAvailableDices(i, m_playerADices[i]);
			}
		}

		private void PlayerAPlaceDice(int combinationIndex, int diceValue)
		{
			m_playerACombination[combinationIndex] = diceValue;
		}

		private void PlayerABet()
		{
			if (m_playerATokens > 0)
			{
				m_playerABet++;
				m_playerATokens--;
				m_uiModule.BetToken(player: true, m_playerABet, m_playerATokens);
			}
		}

		private void PlayerAUnbet()
		{
			if (m_playerABet > 0)
			{
				m_playerABet--;
				m_playerATokens++;
				m_uiModule.BetToken(player: true, m_playerABet, m_playerATokens);
			}
		}

		private void PlayerAConfirms()
		{
			if (!WargameSettings.AllowIncompleteValidation)
			{
				for (int i = 0; i < m_playerACombination.Length; i++)
				{
					if (m_playerACombination[i] == 0)
					{
						return;
					}
				}
			}
			if (m_playerHasPriority || WargameSettings.PlayAtTheSameTime)
			{
				RevealPlayerBDices();
			}
			else
			{
				StartCombatPhase();
			}
		}

		private void DoPlayerBDicePhase()
		{
			List<MiniatureData> list = GetAliveMiniaturesOfSquad(playerA: false).ToList();
			List<int> list2 = new List<int>();
			if (list.Count > 1)
			{
				List<int>[] array = new List<int>[WargameSettings.MinimumActivations];
				int num = -1;
				do
				{
					num++;
					list2.Clear();
					int num2 = 0;
					for (int i = 0; i < array.Length; i++)
					{
						MiniatureData random = list.GetRandom();
						list.Remove(random);
						array[i] = random.Skill.Condition.GetCombination();
						num2 += array[i].Count;
					}
					if (num2 == m_playerBCombinationSize + 1)
					{
						int num3 = -1;
						int num4 = -1;
						bool flag = false;
						for (int j = 0; j < array.Length; j++)
						{
							if (flag)
							{
								break;
							}
							for (int k = 0; k < array.Length; k++)
							{
								if (k != j)
								{
									List<int> obj = array[j];
									if (obj[obj.Count - 1] == array[k][0])
									{
										num3 = j;
										num4 = k;
										flag = true;
										break;
									}
									int num5 = array[j][0];
									List<int> obj2 = array[k];
									if (num5 == obj2[obj2.Count - 1])
									{
										num3 = k;
										num4 = j;
										flag = true;
										break;
									}
								}
							}
						}
						if (flag)
						{
							list2.AddRange(array[num3]);
							array[num4].RemoveAt(0);
							list2.AddRange(array[num4]);
						}
						for (int l = 0; l < array.Length; l++)
						{
							if (l != num3 && l != num4)
							{
								list2.AddRange(array[l]);
							}
						}
					}
					else
					{
						for (int m = 0; m < array.Length; m++)
						{
							list2.AddRange(array[m]);
						}
					}
					while (list2.Count < m_playerBCombinationSize)
					{
						list2.Add(WargameSettings.GetRandomDiceFace());
					}
					if (num > 5)
					{
						while (list2.Count > m_playerBCombinationSize)
						{
							list2.RemoveAt(0);
						}
					}
				}
				while (list2.Count != m_playerBCombinationSize);
			}
			else
			{
				list2.AddRange(list[0].Skill.Condition.GetCombination());
				while (list2.Count > m_playerBCombinationSize)
				{
					list2.RemoveAt(0);
				}
				while (list2.Count < m_playerBCombinationSize)
				{
					list2.Add(WargameSettings.GetRandomDiceFace());
				}
			}
			for (int n = 0; n < m_playerBCombination.Length; n++)
			{
				m_playerBCombination[n] = list2[n];
				m_uiModule.AIPlaceDice(n, list2[n], !m_playerHasPriority && !WargameSettings.PlayAtTheSameTime);
			}
			m_playerBBet = Random.Range(0, Mathf.Min(3, m_playerBTokens));
			m_playerBTokens -= m_playerBBet;
			m_uiModule.BetToken(player: false, m_playerBBet, m_playerBTokens);
			if (!m_playerHasPriority && !WargameSettings.PlayAtTheSameTime)
			{
				UpdatePreview(showOpponentPreview: true);
			}
		}

		private void RevealPlayerBDices()
		{
			m_uiModule.InitCombatPhase();
			UpdatePreview(showOpponentPreview: true);
			m_revealDiceDelay = DOVirtual.DelayedCall(2f, StartCombatPhase);
			m_revealDiceDelay.SetUpdate(isIndependentUpdate: true);
			m_revealDiceDelay.Play();
		}

		private void StartCombatPhase()
		{
			m_phase = EWargamePhase.COMBAT;
			m_playerAPlaying = m_playerHasPriority;
			m_uiModule.InitCombatPhase();
			UpdateUIInstant();
			m_combatSequence = DOTween.Sequence();
			AddDelayToCombatPhase(1f);
			TriggerCombatSequence(m_playerHasPriority);
			AddDelayToCombatPhase(WargameSettings.DelayBetweenPlayers);
			TriggerCombatSequence(!m_playerHasPriority);
			AddDelayToCombatPhase(WargameSettings.DelayBeforeRoundWinner);
			m_combatSequence.SetUpdate(isIndependentUpdate: true);
			m_combatSequence.OnComplete(ComputeScores);
			m_combatSequence.Play();
		}

		private void TriggerCombatSequence(bool playerA)
		{
			m_playerAPlaying = playerA;
			m_precedentActivations = 0;
			m_allPrecedentActivations = 0;
			m_usedDices.Clear();
			int[] array = (playerA ? m_playerACombination : m_playerBCombination);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0)
				{
					m_usedDices.Clear();
					m_usedDices.Add(i);
					EvaluateDiceEffect(array[i], playerA);
					UpdateUIStateDuringCombatPhase();
					AddDelayToCombatPhase(WargameSettings.DelayBetweenEffectTrigger);
				}
			}
			int num = 0;
			foreach (MiniatureData item in GetSquad(playerA))
			{
				if (item != null && GetSquadAlive(playerA)[num])
				{
					AddDelayToCombatPhase(WargameSettings.DelayBetweenMiniatureActivation);
					ActivateMiniature(num, item, playerA);
				}
				num++;
			}
		}

		private void ActivateMiniature(int index, MiniatureData miniatureData, bool playerA)
		{
			MiniatureWargameSkill skill = miniatureData.Skill;
			if (playerA)
			{
				m_playerAActivatedMiniatures[index] = true;
			}
			else
			{
				m_playerBActivatedMiniatures[index] = true;
			}
			UpdateUIStateDuringCombatPhase();
			AddDelayToCombatPhase(0.1f);
			m_currentActivations = skill.Condition.TriggerCount(playerA ? m_playerACombination : m_playerBCombination, m_usedDices, GetDiceCombinationModification(playerA));
			int[] array = (playerA ? m_playerAActivationBonuses : m_playerBActivationBonuses);
			m_currentActivations += array[index];
			array[index] = 0;
			if (m_currentActivations > 0)
			{
				for (int i = 0; i < m_currentActivations; i++)
				{
					if (!GetSquadAlive(playerA)[index])
					{
						continue;
					}
					TriggerActivateAllyMiniatureEffects(playerA);
					foreach (WargameSkillEffect effect in skill.Effects)
					{
						EvaluateEffect(index, effect, playerA);
					}
					UpdateUIStateDuringCombatPhase();
					AddDelayToCombatPhase(WargameSettings.DelayBetweenEffectTrigger);
				}
				TriggerPostEffects(playerA, index);
				AddDelayToCombatPhase(WargameSettings.DelayBetweenEffectTrigger);
			}
			if (playerA)
			{
				m_playerAActivatedMiniatures[index] = false;
			}
			else
			{
				m_playerBActivatedMiniatures[index] = false;
			}
			m_precedentActivations = m_currentActivations;
			m_allPrecedentActivations += m_currentActivations;
			m_currentActivations = 0;
			m_usedDices.Clear();
			UpdateUIStateDuringCombatPhase();
		}

		private void FreeActivateMiniature(int index, MiniatureData miniatureData, bool playerA, bool countAsActivation = true)
		{
			if (m_isPreview)
			{
				TriggerFreePreviewMiniatureActivation(index, miniatureData, playerA, countAsActivation);
				return;
			}
			MiniatureWargameSkill skill = miniatureData.Skill;
			if (playerA)
			{
				m_playerAActivatedMiniatures[index] = true;
			}
			else
			{
				m_playerBActivatedMiniatures[index] = true;
			}
			UpdateUIStateDuringCombatPhase();
			AddDelayToCombatPhase(0.1f);
			int currentActivations = m_currentActivations;
			if (GetSquadAlive(playerA)[index])
			{
				m_currentActivations = 1;
				TriggerActivateAllyMiniatureEffects(playerA);
				foreach (WargameSkillEffect effect in skill.Effects)
				{
					EvaluateEffect(index, effect, playerA);
				}
				UpdateUIStateDuringCombatPhase();
				AddDelayToCombatPhase(WargameSettings.DelayBetweenEffectTrigger);
			}
			TriggerPostEffects(playerA, index);
			AddDelayToCombatPhase(WargameSettings.DelayBetweenEffectTrigger);
			m_currentActivations = currentActivations;
			if (playerA)
			{
				m_playerAActivatedMiniatures[index] = false;
			}
			else
			{
				m_playerBActivatedMiniatures[index] = false;
			}
			if (countAsActivation)
			{
				m_allPrecedentActivations++;
			}
			UpdateUIStateDuringCombatPhase();
		}

		private void ComputeScores()
		{
			m_phase = EWargamePhase.DAMAGE;
			m_endRoundSequence = DOTween.Sequence();
			if (m_playerAAssault != m_playerBAssault)
			{
				bool playerAWinsRound = m_playerAAssault > m_playerBAssault;
				EWargameResult result = ((!playerAWinsRound) ? EWargameResult.PLAYER_B : EWargameResult.PLAYER_A);
				m_endRoundSequence.AppendCallback(delegate
				{
					m_uiModule.DisplayRoundResult(result);
				});
				m_endRoundSequence.AppendInterval(WargameSettings.DelayBeforeRoundResultEffects);
				m_endRoundSequence.AppendCallback(delegate
				{
					TriggerResultEffects(result);
					UpdateUIInstant();
				});
				m_endRoundSequence.AppendInterval(WargameSettings.DelayBeforeTokensActivation);
				int num = (playerAWinsRound ? m_playerABet : m_playerBBet);
				for (int num2 = 0; num2 < num; num2++)
				{
					if (num2 > 0)
					{
						m_endRoundSequence.AppendInterval(WargameSettings.DelayBetweenTokenActivation);
					}
					m_endRoundSequence.AppendCallback(delegate
					{
						OnApplyTokensModifications(playerAWinsRound);
						UpdateUIInstant();
					});
				}
				m_endRoundSequence.AppendInterval(WargameSettings.DelayBeforeDamageApplication);
				m_endRoundSequence.AppendCallback(delegate
				{
					if (playerAWinsRound)
					{
						ApplyOperation(ref m_playerBLife, EWargameEffectOperation.ADD, -m_playerADamage, EWargameEffectType.PV, originIsPlayerA: true, appliedOnPlayerA: false);
					}
					else
					{
						ApplyOperation(ref m_playerALife, EWargameEffectOperation.ADD, -m_playerBDamage, EWargameEffectType.PV, originIsPlayerA: false, appliedOnPlayerA: true);
					}
					UpdateUIInstant();
					if (m_playerALife <= 0)
					{
						m_endRoundSequence.AppendInterval(WargameSettings.DelayBeforePVTo0Effects);
						TriggerPVTO0Effects(playerA: true);
						UpdateUIInstant();
					}
					if (m_playerBLife <= 0)
					{
						m_endRoundSequence.AppendInterval(WargameSettings.DelayBeforePVTo0Effects);
						TriggerPVTO0Effects(playerA: false);
						UpdateUIInstant();
					}
				});
				m_endRoundSequence.AppendCallback(CompleteCombatPhase);
				m_endRoundSequence.AppendInterval(WargameSettings.DelayBetweenRounds);
				m_endRoundSequence.AppendCallback(EnableNextRound);
			}
			else
			{
				m_endRoundSequence.AppendCallback(delegate
				{
					m_uiModule.DisplayRoundResult(EWargameResult.DRAW);
					TriggerResultEffects(EWargameResult.DRAW);
				});
				m_endRoundSequence.AppendCallback(CompleteCombatPhase);
				m_endRoundSequence.AppendInterval(WargameSettings.DelayBetweenRounds);
				m_endRoundSequence.AppendCallback(EnableNextRound);
			}
			m_endRoundSequence.SetUpdate(isIndependentUpdate: true);
			m_endRoundSequence.Play();
		}

		private void EvaluateEffect(int miniatureIndex, WargameSkillEffect effect, bool playerA)
		{
			if (effect.trigger == EWargameEffectTrigger.IMMEDIATE)
			{
				if (effect.triggerModifier == EWargameEffectTriggerModifier.UNUSED_DICES)
				{
					int[] array = (playerA ? m_playerACombination : m_playerBCombination);
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] == 0)
						{
							TriggerEffect(miniatureIndex, effect, playerA);
						}
					}
				}
				else
				{
					TriggerEffect(miniatureIndex, effect, playerA);
				}
			}
			else if (effect.triggerModifier == EWargameEffectTriggerModifier.APPLY_POST_EFFECT)
			{
				m_tempDelayedEffects.Add(effect);
			}
			else
			{
				AddToDelayedEffect(playerA, effect.trigger, effect);
			}
		}

		private void AddToDelayedEffect(bool playerA, EWargameEffectTrigger trigger, WargameSkillEffect effect)
		{
			Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> dictionary = (playerA ? m_playerADelayedEffects : m_playerBDelayedEffects);
			if (dictionary.TryGetValue(trigger, out var value) && value != null)
			{
				value.Add(effect);
				return;
			}
			dictionary[trigger] = new List<WargameSkillEffect> { effect };
		}

		private void EvaluateDiceEffect(int diceIndex, bool playerA)
		{
			if (playerA)
			{
				switch (diceIndex)
				{
				case 1:
					EvaluateEffect(-1, m_playerADice1Effect, playerA);
					break;
				case 2:
					EvaluateEffect(-1, m_playerADice2Effect, playerA);
					break;
				case 3:
					EvaluateEffect(-1, m_playerADice3Effect, playerA);
					break;
				}
			}
			else
			{
				switch (diceIndex)
				{
				case 1:
					EvaluateEffect(-1, m_playerBDice1Effect, playerA);
					break;
				case 2:
					EvaluateEffect(-1, m_playerBDice2Effect, playerA);
					break;
				case 3:
					EvaluateEffect(-1, m_playerBDice3Effect, playerA);
					break;
				}
			}
		}

		private void TriggerPostEffects(bool playerA, int miniatureIndex)
		{
			foreach (WargameSkillEffect tempDelayedEffect in m_tempDelayedEffects)
			{
				AddToDelayedEffect(playerA, tempDelayedEffect.trigger, tempDelayedEffect);
			}
			m_tempDelayedEffects.Clear();
			Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> dictionary = (playerA ? m_playerADelayedEffects : m_playerBDelayedEffects);
			if (!dictionary.TryGetValue(EWargameEffectTrigger.POST_EFFECT, out var value) || !value.IsValid())
			{
				return;
			}
			dictionary[EWargameEffectTrigger.POST_EFFECT] = null;
			foreach (WargameSkillEffect item in value)
			{
				TriggerEffect(miniatureIndex, item, playerA);
			}
		}

		private void TriggerResultEffects(EWargameResult roundResult)
		{
			List<WargameSkillEffect> value;
			switch (roundResult)
			{
			case EWargameResult.PLAYER_A:
				if (m_playerADelayedEffects.TryGetValue(EWargameEffectTrigger.WIN_ROUND, out value) && value.IsValid())
				{
					foreach (WargameSkillEffect item in value)
					{
						switch (item.triggerModifier)
						{
						case EWargameEffectTriggerModifier.NEXT_ROUND:
							AddToDelayedEffect(playerA: true, EWargameEffectTrigger.NEXT_ROUND, item);
							break;
						case EWargameEffectTriggerModifier.EVERY_ROUND:
							AddToDelayedEffect(playerA: true, EWargameEffectTrigger.EVERY_ROUND, item);
							break;
						default:
							TriggerEffect(-1, item, playerA: true);
							break;
						}
					}
				}
				if (!m_playerBDelayedEffects.TryGetValue(EWargameEffectTrigger.LOSE_ROUND, out value) || !value.IsValid())
				{
					break;
				}
				foreach (WargameSkillEffect item2 in value)
				{
					switch (item2.triggerModifier)
					{
					case EWargameEffectTriggerModifier.NEXT_ROUND:
						AddToDelayedEffect(playerA: false, EWargameEffectTrigger.NEXT_ROUND, item2);
						break;
					case EWargameEffectTriggerModifier.EVERY_ROUND:
						AddToDelayedEffect(playerA: false, EWargameEffectTrigger.EVERY_ROUND, item2);
						break;
					default:
						TriggerEffect(-1, item2, playerA: false);
						break;
					}
				}
				break;
			case EWargameResult.PLAYER_B:
				if (m_playerBDelayedEffects.TryGetValue(EWargameEffectTrigger.WIN_ROUND, out value) && value.IsValid())
				{
					foreach (WargameSkillEffect item3 in value)
					{
						switch (item3.triggerModifier)
						{
						case EWargameEffectTriggerModifier.NEXT_ROUND:
							AddToDelayedEffect(playerA: false, EWargameEffectTrigger.NEXT_ROUND, item3);
							break;
						case EWargameEffectTriggerModifier.EVERY_ROUND:
							AddToDelayedEffect(playerA: false, EWargameEffectTrigger.EVERY_ROUND, item3);
							break;
						default:
							TriggerEffect(-1, item3, playerA: false);
							break;
						}
					}
				}
				if (!m_playerADelayedEffects.TryGetValue(EWargameEffectTrigger.LOSE_ROUND, out value) || !value.IsValid())
				{
					break;
				}
				foreach (WargameSkillEffect item4 in value)
				{
					switch (item4.triggerModifier)
					{
					case EWargameEffectTriggerModifier.NEXT_ROUND:
						AddToDelayedEffect(playerA: true, EWargameEffectTrigger.NEXT_ROUND, item4);
						break;
					case EWargameEffectTriggerModifier.EVERY_ROUND:
						AddToDelayedEffect(playerA: true, EWargameEffectTrigger.EVERY_ROUND, item4);
						break;
					default:
						TriggerEffect(-1, item4, playerA: true);
						break;
					}
				}
				break;
			}
			m_playerADelayedEffects[EWargameEffectTrigger.WIN_ROUND] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.LOSE_ROUND] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.WIN_ROUND] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.LOSE_ROUND] = null;
		}

		private void TriggerPVTO0Effects(bool playerA)
		{
			if (!(playerA ? m_playerADelayedEffects : m_playerBDelayedEffects).TryGetValue(EWargameEffectTrigger.PV_TO_0, out var value) || !value.IsValid())
			{
				return;
			}
			foreach (WargameSkillEffect item in value)
			{
				TriggerEffect(-1, item, playerA);
			}
		}

		private void TriggerRoundStartEffects()
		{
			m_playerADelayedEffects[EWargameEffectTrigger.NEXT_EFFECT_RECEIVED] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.WHOLE_ROUND_EFFECT_RECEIVED] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.NEXT_EFFECT_APPLIED] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.WHOLE_ROUND_EFFECT_APPLIED] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.OVERRIDE_TOKEN_BEHAVIOUR] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.PV_TO_0] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.WHOLE_ROUND_ALLY_ACTIVATION] = null;
			m_playerADelayedEffects[EWargameEffectTrigger.NEXT_DICE_COMBINATION] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.NEXT_EFFECT_RECEIVED] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.WHOLE_ROUND_EFFECT_RECEIVED] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.NEXT_EFFECT_APPLIED] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.WHOLE_ROUND_EFFECT_APPLIED] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.OVERRIDE_TOKEN_BEHAVIOUR] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.PV_TO_0] = null;
			m_playerBDelayedEffects[EWargameEffectTrigger.NEXT_DICE_COMBINATION] = null;
			if (m_playerADelayedEffects.TryGetValue(EWargameEffectTrigger.NEXT_ROUND, out var value) && value.IsValid())
			{
				foreach (WargameSkillEffect item in value)
				{
					TriggerEffect(-1, item, playerA: true);
				}
			}
			m_playerADelayedEffects[EWargameEffectTrigger.NEXT_ROUND] = null;
			if (m_playerADelayedEffects.TryGetValue(EWargameEffectTrigger.EVERY_ROUND, out value) && value.IsValid())
			{
				foreach (WargameSkillEffect item2 in value)
				{
					TriggerEffect(-1, item2, playerA: true);
				}
			}
			if (m_playerBDelayedEffects.TryGetValue(EWargameEffectTrigger.NEXT_ROUND, out value) && value.IsValid())
			{
				foreach (WargameSkillEffect item3 in value)
				{
					TriggerEffect(-1, item3, playerA: false);
				}
			}
			m_playerBDelayedEffects[EWargameEffectTrigger.NEXT_ROUND] = null;
			if (!m_playerBDelayedEffects.TryGetValue(EWargameEffectTrigger.EVERY_ROUND, out value) || !value.IsValid())
			{
				return;
			}
			foreach (WargameSkillEffect item4 in value)
			{
				TriggerEffect(-1, item4, playerA: false);
			}
		}

		private void TriggerActivateAllyMiniatureEffects(bool playerA)
		{
			if (!(playerA ? m_playerADelayedEffects : m_playerBDelayedEffects).TryGetValue(EWargameEffectTrigger.WHOLE_ROUND_ALLY_ACTIVATION, out var value) || !value.IsValid())
			{
				return;
			}
			foreach (WargameSkillEffect item in value)
			{
				TriggerEffect(-1, item, playerA);
			}
		}

		private void TriggerEffect(int miniatureIndex, WargameSkillEffect effect, bool playerA)
		{
			switch (effect.type)
			{
			case EWargameEffectType.ASSAULT:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerAAssault, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBAssault, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBAssault, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerAAssault, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerAAssault, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBAssault, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.DAMAGE:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerADamage, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBDamage, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBDamage, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerADamage, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerADamage, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBDamage, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.PV:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerALife, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBLife, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBLife, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerALife, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerALife, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBLife, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.DICES:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerADiceCount, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBDiceCount, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBDiceCount, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerADiceCount, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerADiceCount, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBDiceCount, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.DICE_COMBINATION:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerACombinationSize, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBCombinationSize, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBCombinationSize, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerACombinationSize, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerACombinationSize, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBCombinationSize, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.MINIATURE:
				switch (effect.operation)
				{
				case EWargameEffectOperation.ACTIVATE_EFFECT:
					switch (effect.miniatureTarget)
					{
					case EWargameEffectMiniatureTarget.RANDOM:
					{
						int effectQuantityAsInt7 = GetEffectQuantityAsInt(effect, playerA);
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							int randomAliveMiniatureIndex2 = GetRandomAliveMiniatureIndexExcept(playerA, miniatureIndex);
							for (int num45 = 0; num45 < effectQuantityAsInt7; num45++)
							{
								FreeActivateMiniature(randomAliveMiniatureIndex2, GetMiniatureFromSquad(playerA, randomAliveMiniatureIndex2), playerA);
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							int randomAliveMiniatureIndex2 = GetRandomAliveMiniatureIndex(!playerA);
							for (int num46 = 0; num46 < effectQuantityAsInt7; num46++)
							{
								FreeActivateMiniature(randomAliveMiniatureIndex2, GetMiniatureFromSquad(!playerA, randomAliveMiniatureIndex2), !playerA);
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							int randomAliveMiniatureIndex2 = GetRandomAliveMiniatureIndex(playerA);
							for (int num43 = 0; num43 < effectQuantityAsInt7; num43++)
							{
								FreeActivateMiniature(randomAliveMiniatureIndex2, GetMiniatureFromSquad(playerA, randomAliveMiniatureIndex2), playerA);
							}
							randomAliveMiniatureIndex2 = GetRandomAliveMiniatureIndex(!playerA);
							for (int num44 = 0; num44 < effectQuantityAsInt7; num44++)
							{
								FreeActivateMiniature(randomAliveMiniatureIndex2, GetMiniatureFromSquad(!playerA, randomAliveMiniatureIndex2), !playerA);
							}
							break;
						}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.ALL:
					{
						int effectQuantityAsInt4 = GetEffectQuantityAsInt(effect, playerA);
						int num25 = 0;
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							foreach (MiniatureData item in GetAliveMiniaturesOfSquad(playerA))
							{
								for (int num28 = 0; num28 < effectQuantityAsInt4; num28++)
								{
									FreeActivateMiniature(num25, item, playerA);
								}
								num25++;
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							foreach (MiniatureData item2 in GetAliveMiniaturesOfSquad(!playerA))
							{
								for (int num29 = 0; num29 < effectQuantityAsInt4; num29++)
								{
									FreeActivateMiniature(num25, item2, !playerA);
								}
								num25++;
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
							foreach (MiniatureData item3 in GetAliveMiniaturesOfSquad(playerA))
							{
								for (int num26 = 0; num26 < effectQuantityAsInt4; num26++)
								{
									FreeActivateMiniature(num25, item3, playerA);
								}
								num25++;
							}
							{
								foreach (MiniatureData item4 in GetAliveMiniaturesOfSquad(!playerA))
								{
									for (int num27 = 0; num27 < effectQuantityAsInt4; num27++)
									{
										FreeActivateMiniature(num25, item4, !playerA);
									}
									num25++;
								}
								break;
							}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.NEXT:
					{
						int num38 = miniatureIndex + 1;
						if (num38 >= WargameSettings.SquadSize)
						{
							break;
						}
						int effectQuantityAsInt6 = GetEffectQuantityAsInt(effect, playerA);
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							for (int num41 = 0; num41 < effectQuantityAsInt6; num41++)
							{
								FreeActivateMiniature(num38, GetMiniatureFromSquad(playerA, num38), playerA);
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							for (int num42 = 0; num42 < effectQuantityAsInt6; num42++)
							{
								FreeActivateMiniature(num38, GetMiniatureFromSquad(!playerA, num38), !playerA);
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							for (int num39 = 0; num39 < effectQuantityAsInt6; num39++)
							{
								FreeActivateMiniature(num38, GetMiniatureFromSquad(playerA, num38), playerA);
							}
							for (int num40 = 0; num40 < effectQuantityAsInt6; num40++)
							{
								FreeActivateMiniature(num38, GetMiniatureFromSquad(!playerA, num38), !playerA);
							}
							break;
						}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.ALL_NEXT:
					{
						int effectQuantityAsInt5 = GetEffectQuantityAsInt(effect, playerA);
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							for (int num34 = miniatureIndex + 1; num34 < WargameSettings.SquadSize; num34++)
							{
								for (int num35 = 0; num35 < effectQuantityAsInt5; num35++)
								{
									FreeActivateMiniature(num34, GetMiniatureFromSquad(playerA, num34), playerA);
								}
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							for (int num36 = miniatureIndex + 1; num36 < WargameSettings.SquadSize; num36++)
							{
								for (int num37 = 0; num37 < effectQuantityAsInt5; num37++)
								{
									FreeActivateMiniature(num36, GetMiniatureFromSquad(!playerA, num36), !playerA);
								}
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							for (int num30 = miniatureIndex + 1; num30 < WargameSettings.SquadSize; num30++)
							{
								for (int num31 = 0; num31 < effectQuantityAsInt5; num31++)
								{
									FreeActivateMiniature(num30, GetMiniatureFromSquad(playerA, num30), playerA);
								}
							}
							for (int num32 = miniatureIndex + 1; num32 < WargameSettings.SquadSize; num32++)
							{
								for (int num33 = 0; num33 < effectQuantityAsInt5; num33++)
								{
									FreeActivateMiniature(num32, GetMiniatureFromSquad(!playerA, num32), !playerA);
								}
							}
							break;
						}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.PREVIOUS:
					{
						int num20 = miniatureIndex - 1;
						if (num20 < 0)
						{
							break;
						}
						int effectQuantityAsInt3 = GetEffectQuantityAsInt(effect, playerA);
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							for (int num23 = 0; num23 < effectQuantityAsInt3; num23++)
							{
								FreeActivateMiniature(num20, GetMiniatureFromSquad(playerA, num20), playerA);
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							for (int num24 = 0; num24 < effectQuantityAsInt3; num24++)
							{
								FreeActivateMiniature(num20, GetMiniatureFromSquad(!playerA, num20), !playerA);
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							for (int num21 = 0; num21 < effectQuantityAsInt3; num21++)
							{
								FreeActivateMiniature(num20, GetMiniatureFromSquad(playerA, num20), playerA);
							}
							for (int num22 = 0; num22 < effectQuantityAsInt3; num22++)
							{
								FreeActivateMiniature(num20, GetMiniatureFromSquad(!playerA, num20), !playerA);
							}
							break;
						}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.ALL_PREVIOUS:
					{
						int effectQuantityAsInt2 = GetEffectQuantityAsInt(effect, playerA);
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							for (int num16 = 0; num16 < miniatureIndex; num16++)
							{
								for (int num17 = 0; num17 < effectQuantityAsInt2; num17++)
								{
									FreeActivateMiniature(num16, GetMiniatureFromSquad(playerA, num16), playerA);
								}
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							for (int num18 = 0; num18 < miniatureIndex; num18++)
							{
								for (int num19 = 0; num19 < effectQuantityAsInt2; num19++)
								{
									FreeActivateMiniature(num18, GetMiniatureFromSquad(!playerA, num18), !playerA);
								}
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							for (int num12 = 0; num12 < miniatureIndex; num12++)
							{
								for (int num13 = 0; num13 < effectQuantityAsInt2; num13++)
								{
									FreeActivateMiniature(num12, GetMiniatureFromSquad(playerA, num12), playerA);
								}
							}
							for (int num14 = 0; num14 < miniatureIndex; num14++)
							{
								for (int num15 = 0; num15 < effectQuantityAsInt2; num15++)
								{
									FreeActivateMiniature(num14, GetMiniatureFromSquad(!playerA, num14), !playerA);
								}
							}
							break;
						}
						}
						break;
					}
					}
					break;
				case EWargameEffectOperation.SACRIFICE:
					switch (effect.miniatureTarget)
					{
					case EWargameEffectMiniatureTarget.RANDOM:
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
							GetSquadAlive(playerA)[GetRandomAliveMiniatureIndex(playerA)] = false;
							break;
						case EWargameEffectTarget.OPPONENT:
							GetSquadAlive(!playerA)[GetRandomAliveMiniatureIndex(!playerA)] = false;
							break;
						case EWargameEffectTarget.BOTH:
							GetSquadAlive(playerA)[GetRandomAliveMiniatureIndex(playerA)] = false;
							GetSquadAlive(!playerA)[GetRandomAliveMiniatureIndex(!playerA)] = false;
							break;
						}
						break;
					case EWargameEffectMiniatureTarget.NEXT:
					{
						int num11 = miniatureIndex + 1;
						if (num11 < WargameSettings.SquadSize)
						{
							switch (effect.target)
							{
							case EWargameEffectTarget.PLAYER:
								GetSquadAlive(playerA)[num11] = false;
								break;
							case EWargameEffectTarget.OPPONENT:
								GetSquadAlive(!playerA)[num11] = false;
								break;
							case EWargameEffectTarget.BOTH:
								GetSquadAlive(playerA)[num11] = false;
								GetSquadAlive(!playerA)[num11] = false;
								break;
							}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.PREVIOUS:
					{
						int num10 = miniatureIndex - 1;
						if (num10 >= 0)
						{
							switch (effect.target)
							{
							case EWargameEffectTarget.PLAYER:
								GetSquadAlive(playerA)[num10] = false;
								break;
							case EWargameEffectTarget.OPPONENT:
								GetSquadAlive(!playerA)[num10] = false;
								break;
							case EWargameEffectTarget.BOTH:
								GetSquadAlive(playerA)[num10] = false;
								GetSquadAlive(!playerA)[num10] = false;
								break;
							}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.ALL:
					case EWargameEffectMiniatureTarget.ALL_NEXT:
						break;
					}
					break;
				case EWargameEffectOperation.REVIVE:
					switch (effect.miniatureTarget)
					{
					case EWargameEffectMiniatureTarget.RANDOM:
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
							GetSquadAlive(playerA)[GetRandomDeadMiniatureIndex(playerA)] = false;
							break;
						case EWargameEffectTarget.OPPONENT:
							GetSquadAlive(!playerA)[GetRandomDeadMiniatureIndex(!playerA)] = false;
							break;
						case EWargameEffectTarget.BOTH:
							GetSquadAlive(playerA)[GetRandomDeadMiniatureIndex(playerA)] = false;
							GetSquadAlive(!playerA)[GetRandomDeadMiniatureIndex(!playerA)] = false;
							break;
						}
						break;
					case EWargameEffectMiniatureTarget.ALL:
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							for (int l = 0; l < WargameSettings.SquadSize; l++)
							{
								GetSquadAlive(playerA)[l] = true;
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							for (int m = 0; m < WargameSettings.SquadSize; m++)
							{
								GetSquadAlive(!playerA)[m] = true;
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							for (int j = 0; j < WargameSettings.SquadSize; j++)
							{
								GetSquadAlive(playerA)[j] = true;
							}
							for (int k = 0; k < WargameSettings.SquadSize; k++)
							{
								GetSquadAlive(!playerA)[k] = true;
							}
							break;
						}
						}
						break;
					case EWargameEffectMiniatureTarget.NEXT:
					{
						int num9 = miniatureIndex + 1;
						if (num9 < WargameSettings.SquadSize)
						{
							switch (effect.target)
							{
							case EWargameEffectTarget.PLAYER:
								GetSquadAlive(playerA)[num9] = true;
								break;
							case EWargameEffectTarget.OPPONENT:
								GetSquadAlive(!playerA)[num9] = true;
								break;
							case EWargameEffectTarget.BOTH:
								GetSquadAlive(playerA)[num9] = true;
								GetSquadAlive(!playerA)[num9] = true;
								break;
							}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.ALL_NEXT:
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							for (int num7 = miniatureIndex + 1; num7 < WargameSettings.SquadSize; num7++)
							{
								GetSquadAlive(playerA)[num7] = true;
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							for (int num8 = miniatureIndex + 1; num8 < WargameSettings.SquadSize; num8++)
							{
								GetSquadAlive(!playerA)[num8] = true;
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							for (int n = miniatureIndex + 1; n < WargameSettings.SquadSize; n++)
							{
								GetSquadAlive(playerA)[n] = true;
							}
							for (int num6 = miniatureIndex + 1; num6 < WargameSettings.SquadSize; num6++)
							{
								GetSquadAlive(!playerA)[num6] = true;
							}
							break;
						}
						}
						break;
					case EWargameEffectMiniatureTarget.PREVIOUS:
					{
						int num5 = miniatureIndex - 1;
						if (num5 >= 0)
						{
							switch (effect.target)
							{
							case EWargameEffectTarget.PLAYER:
								GetSquadAlive(playerA)[num5] = true;
								break;
							case EWargameEffectTarget.OPPONENT:
								GetSquadAlive(!playerA)[num5] = true;
								break;
							case EWargameEffectTarget.BOTH:
								GetSquadAlive(playerA)[num5] = true;
								GetSquadAlive(!playerA)[num5] = true;
								break;
							}
						}
						break;
					}
					case EWargameEffectMiniatureTarget.ALL_PREVIOUS:
						switch (effect.target)
						{
						case EWargameEffectTarget.PLAYER:
						{
							for (int num3 = miniatureIndex - 1; num3 >= 0; num3--)
							{
								GetSquadAlive(playerA)[num3] = true;
							}
							break;
						}
						case EWargameEffectTarget.OPPONENT:
						{
							for (int num4 = miniatureIndex - 1; num4 >= 0; num4--)
							{
								GetSquadAlive(!playerA)[num4] = true;
							}
							break;
						}
						case EWargameEffectTarget.BOTH:
						{
							for (int num = miniatureIndex - 1; num >= 0; num--)
							{
								GetSquadAlive(playerA)[num] = true;
							}
							for (int num2 = miniatureIndex - 1; num2 >= 0; num2--)
							{
								GetSquadAlive(!playerA)[num2] = true;
							}
							break;
						}
						}
						break;
					}
					break;
				case EWargameEffectOperation.ADD_ACTIVATION:
				{
					int effectQuantityAsInt = GetEffectQuantityAsInt(effect, playerA);
					switch (effect.miniatureTarget)
					{
					case EWargameEffectMiniatureTarget.NEXT:
						if (miniatureIndex != -1 && miniatureIndex < WargameSettings.SquadSize - 1)
						{
							(playerA ? m_playerAActivationBonuses : m_playerBActivationBonuses)[miniatureIndex + 1] += effectQuantityAsInt;
						}
						break;
					case EWargameEffectMiniatureTarget.ALL_NEXT:
						if (miniatureIndex != -1)
						{
							int[] array = (playerA ? m_playerAActivationBonuses : m_playerBActivationBonuses);
							for (int i = miniatureIndex + 1; i < WargameSettings.SquadSize; i++)
							{
								array[i] += effectQuantityAsInt;
							}
						}
						break;
					case EWargameEffectMiniatureTarget.SELF:
						if (miniatureIndex != -1)
						{
							(playerA ? m_playerAActivationBonuses : m_playerBActivationBonuses)[miniatureIndex] += effectQuantityAsInt;
						}
						break;
					case EWargameEffectMiniatureTarget.PREVIOUS:
					case EWargameEffectMiniatureTarget.ALL_PREVIOUS:
						break;
					}
					break;
				}
				case EWargameEffectOperation.COPY_EFFECT:
					switch (effect.miniatureTarget)
					{
					case EWargameEffectMiniatureTarget.NEXT:
						if (miniatureIndex != -1 && miniatureIndex < WargameSettings.SquadSize - 1)
						{
							int index = miniatureIndex + 1;
							MiniatureData miniatureFromSquad3 = GetMiniatureFromSquad(playerA, index);
							FreeActivateMiniature(miniatureIndex, miniatureFromSquad3, playerA, countAsActivation: false);
						}
						break;
					case EWargameEffectMiniatureTarget.PREVIOUS:
						if (miniatureIndex != -1 && miniatureIndex > 0)
						{
							int index2 = miniatureIndex - 1;
							MiniatureData miniatureFromSquad4 = GetMiniatureFromSquad(playerA, index2);
							FreeActivateMiniature(miniatureIndex, miniatureFromSquad4, playerA, countAsActivation: false);
						}
						break;
					case EWargameEffectMiniatureTarget.RANDOM:
						if (miniatureIndex != -1)
						{
							switch (effect.target)
							{
							case EWargameEffectTarget.PLAYER:
							{
								int randomAliveMiniatureIndex = GetRandomAliveMiniatureIndexExcept(playerA, miniatureIndex);
								MiniatureData miniatureFromSquad2 = GetMiniatureFromSquad(playerA, randomAliveMiniatureIndex);
								FreeActivateMiniature(miniatureIndex, miniatureFromSquad2, playerA, countAsActivation: false);
								break;
							}
							case EWargameEffectTarget.OPPONENT:
							{
								int randomAliveMiniatureIndex = GetRandomAliveMiniatureIndex(!playerA);
								MiniatureData miniatureFromSquad = GetMiniatureFromSquad(playerA, randomAliveMiniatureIndex);
								FreeActivateMiniature(miniatureIndex, miniatureFromSquad, playerA, countAsActivation: false);
								break;
							}
							}
						}
						break;
					case EWargameEffectMiniatureTarget.ALL:
					case EWargameEffectMiniatureTarget.ALL_NEXT:
						break;
					}
					break;
				case EWargameEffectOperation.DISABLE_EFFECT:
				case EWargameEffectOperation.NULLIFY:
					break;
				}
				break;
			case EWargameEffectType.TOKEN_LEFT:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerATokens, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBTokens, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBTokens, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerATokens, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerATokens, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBTokens, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.TOKEN_BET:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerABet, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBBet, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBBet, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerABet, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerABet, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBBet, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.DICE1_VALUE:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerADice1Effect.operand, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBDice1Effect.operand, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBDice1Effect.operand, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerADice1Effect.operand, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerADice1Effect.operand, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBDice1Effect.operand, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.DICE2_VALUE:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerADice2Effect.operand, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBDice2Effect.operand, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBDice2Effect.operand, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerADice2Effect.operand, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerADice2Effect.operand, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBDice2Effect.operand, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.DICE3_VALUE:
				switch (effect.target)
				{
				case EWargameEffectTarget.PLAYER:
					if (playerA)
					{
						ApplyOperation(ref m_playerADice3Effect.operand, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerBDice3Effect.operand, effect, playerA);
					}
					break;
				case EWargameEffectTarget.OPPONENT:
					if (playerA)
					{
						ApplyOperation(ref m_playerBDice3Effect.operand, effect, playerA);
					}
					else
					{
						ApplyOperation(ref m_playerADice3Effect.operand, effect, playerA);
					}
					break;
				case EWargameEffectTarget.BOTH:
					ApplyOperation(ref m_playerADice3Effect.operand, effect, playerA, appliedOnPlayerA: true);
					ApplyOperation(ref m_playerBDice3Effect.operand, effect, playerA, appliedOnPlayerA: false);
					break;
				}
				break;
			case EWargameEffectType.EFFECT_RECEIVED:
			case EWargameEffectType.EFFECT_APPLIED:
				break;
			}
		}

		private void TriggerEffectReceivedEffect(ref int effectValue, WargameSkillEffect effect, bool effectOriginIsPlayerA)
		{
			int num = SimpleApplyOperation(effectValue, effect, effectOriginIsPlayerA);
			effectValue += num;
		}

		private void OnTryApplyModification(ref int modification, EWargameEffectType type, bool appliedOnPlayerA, bool originIsPlayerA)
		{
			List<int> list = new List<int>();
			Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> dictionary = (appliedOnPlayerA ? m_playerADelayedEffects : m_playerBDelayedEffects);
			if (dictionary.TryGetValue(EWargameEffectTrigger.NEXT_EFFECT_RECEIVED, out var value) && value.IsValid())
			{
				for (int i = 0; i < value.Count; i++)
				{
					EWargameEffectTarget secondaryTarget = value[i].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.PLAYER || secondaryTarget == EWargameEffectTarget.BOTH) && value[i].type == EWargameEffectType.EFFECT_RECEIVED && value[i].triggerModifier.Encapsulate(type, modification))
					{
						TriggerEffectReceivedEffect(ref modification, value[i], appliedOnPlayerA);
						list.Add(i);
					}
				}
				for (int num = list.Count - 1; num >= 0; num--)
				{
					value.RemoveAt(list[num]);
				}
			}
			if (dictionary.TryGetValue(EWargameEffectTrigger.WHOLE_ROUND_EFFECT_RECEIVED, out value) && value.IsValid())
			{
				for (int j = 0; j < value.Count; j++)
				{
					EWargameEffectTarget secondaryTarget = value[j].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.PLAYER || secondaryTarget == EWargameEffectTarget.BOTH) && value[j].type == EWargameEffectType.EFFECT_RECEIVED && value[j].triggerModifier.Encapsulate(type, modification))
					{
						TriggerEffectReceivedEffect(ref modification, value[j], appliedOnPlayerA);
					}
				}
			}
			list.Clear();
			dictionary = (appliedOnPlayerA ? m_playerBDelayedEffects : m_playerADelayedEffects);
			if (dictionary.TryGetValue(EWargameEffectTrigger.NEXT_EFFECT_RECEIVED, out value) && value.IsValid())
			{
				for (int k = 0; k < value.Count; k++)
				{
					EWargameEffectTarget secondaryTarget = value[k].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.OPPONENT || secondaryTarget == EWargameEffectTarget.BOTH) && value[k].type == EWargameEffectType.EFFECT_RECEIVED && value[k].triggerModifier.Encapsulate(type, modification))
					{
						TriggerEffectReceivedEffect(ref modification, value[k], appliedOnPlayerA);
						list.Add(k);
					}
				}
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					value.RemoveAt(list[num2]);
				}
			}
			if (dictionary.TryGetValue(EWargameEffectTrigger.WHOLE_ROUND_EFFECT_RECEIVED, out value) && value.IsValid())
			{
				for (int l = 0; l < value.Count; l++)
				{
					EWargameEffectTarget secondaryTarget = value[l].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.OPPONENT || secondaryTarget == EWargameEffectTarget.BOTH) && value[l].type == EWargameEffectType.EFFECT_RECEIVED && value[l].triggerModifier.Encapsulate(type, modification))
					{
						TriggerEffectReceivedEffect(ref modification, value[l], appliedOnPlayerA);
					}
				}
			}
			list.Clear();
			dictionary = (originIsPlayerA ? m_playerADelayedEffects : m_playerBDelayedEffects);
			if (dictionary.TryGetValue(EWargameEffectTrigger.NEXT_EFFECT_APPLIED, out value) && value.IsValid())
			{
				for (int m = 0; m < value.Count; m++)
				{
					if ((value[m].secondaryTarget == EWargameEffectTarget.BOTH || (value[m].secondaryTarget == EWargameEffectTarget.PLAYER && appliedOnPlayerA == originIsPlayerA) || (value[m].secondaryTarget == EWargameEffectTarget.OPPONENT && appliedOnPlayerA != originIsPlayerA)) && value[m].type == EWargameEffectType.EFFECT_APPLIED && value[m].triggerModifier.Encapsulate(type, modification))
					{
						TriggerEffectReceivedEffect(ref modification, value[m], !appliedOnPlayerA);
						list.Add(m);
					}
				}
				for (int num3 = list.Count - 1; num3 >= 0; num3--)
				{
					value.RemoveAt(list[num3]);
				}
			}
			if (!dictionary.TryGetValue(EWargameEffectTrigger.WHOLE_ROUND_EFFECT_APPLIED, out value) || !value.IsValid())
			{
				return;
			}
			for (int n = 0; n < value.Count; n++)
			{
				if ((value[n].secondaryTarget == EWargameEffectTarget.BOTH || (value[n].secondaryTarget == EWargameEffectTarget.PLAYER && appliedOnPlayerA == originIsPlayerA) || (value[n].secondaryTarget == EWargameEffectTarget.OPPONENT && appliedOnPlayerA != originIsPlayerA)) && value[n].type == EWargameEffectType.EFFECT_APPLIED && value[n].triggerModifier.Encapsulate(type, modification))
				{
					TriggerEffectReceivedEffect(ref modification, value[n], !appliedOnPlayerA);
				}
			}
		}

		private void OnModificationApplied(int modification, EWargameEffectType type, bool appliedOnPlayerA, bool originIsPlayerA)
		{
			List<int> list = new List<int>();
			List<WargameSkillEffect> list2 = new List<WargameSkillEffect>();
			Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> dictionary = (appliedOnPlayerA ? m_playerADelayedEffects : m_playerBDelayedEffects);
			if (dictionary.TryGetValue(EWargameEffectTrigger.NEXT_EFFECT_RECEIVED, out var value) && value.IsValid())
			{
				for (int i = 0; i < value.Count; i++)
				{
					EWargameEffectTarget secondaryTarget = value[i].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.PLAYER || secondaryTarget == EWargameEffectTarget.BOTH) && value[i].type != EWargameEffectType.EFFECT_RECEIVED && value[i].triggerModifier.Encapsulate(type, modification))
					{
						list2.Add(value[i]);
						list.Add(i);
					}
				}
				for (int num = list.Count - 1; num >= 0; num--)
				{
					value.RemoveAt(list[num]);
				}
				foreach (WargameSkillEffect item in list2)
				{
					TriggerEffect(-1, item, appliedOnPlayerA);
				}
				list2.Clear();
			}
			if (dictionary.TryGetValue(EWargameEffectTrigger.WHOLE_ROUND_EFFECT_RECEIVED, out value) && value.IsValid())
			{
				for (int j = 0; j < value.Count; j++)
				{
					EWargameEffectTarget secondaryTarget = value[j].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.PLAYER || secondaryTarget == EWargameEffectTarget.BOTH) && value[j].type != EWargameEffectType.EFFECT_RECEIVED && value[j].triggerModifier.Encapsulate(type, modification))
					{
						TriggerEffect(-1, value[j], appliedOnPlayerA);
					}
				}
			}
			list.Clear();
			dictionary = (appliedOnPlayerA ? m_playerBDelayedEffects : m_playerADelayedEffects);
			if (dictionary.TryGetValue(EWargameEffectTrigger.NEXT_EFFECT_RECEIVED, out value) && value.IsValid())
			{
				for (int k = 0; k < value.Count; k++)
				{
					EWargameEffectTarget secondaryTarget = value[k].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.OPPONENT || secondaryTarget == EWargameEffectTarget.BOTH) && value[k].type != EWargameEffectType.EFFECT_RECEIVED && value[k].triggerModifier.Encapsulate(type, modification))
					{
						list2.Add(value[k]);
						list.Add(k);
					}
				}
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					value.RemoveAt(list[num2]);
				}
				foreach (WargameSkillEffect item2 in list2)
				{
					TriggerEffect(-1, item2, appliedOnPlayerA);
				}
				list2.Clear();
			}
			if (dictionary.TryGetValue(EWargameEffectTrigger.WHOLE_ROUND_EFFECT_RECEIVED, out value) && value.IsValid())
			{
				for (int l = 0; l < value.Count; l++)
				{
					EWargameEffectTarget secondaryTarget = value[l].secondaryTarget;
					if ((secondaryTarget == EWargameEffectTarget.OPPONENT || secondaryTarget == EWargameEffectTarget.BOTH) && value[l].type != EWargameEffectType.EFFECT_RECEIVED && value[l].triggerModifier.Encapsulate(type, modification))
					{
						TriggerEffect(-1, value[l], appliedOnPlayerA);
					}
				}
			}
			list.Clear();
			dictionary = (originIsPlayerA ? m_playerADelayedEffects : m_playerBDelayedEffects);
			if (dictionary.TryGetValue(EWargameEffectTrigger.NEXT_EFFECT_APPLIED, out value) && value.IsValid())
			{
				for (int m = 0; m < value.Count; m++)
				{
					if ((value[m].secondaryTarget == EWargameEffectTarget.BOTH || (value[m].secondaryTarget == EWargameEffectTarget.PLAYER && appliedOnPlayerA == originIsPlayerA) || (value[m].secondaryTarget == EWargameEffectTarget.OPPONENT && appliedOnPlayerA != originIsPlayerA)) && value[m].type != EWargameEffectType.EFFECT_APPLIED && value[m].triggerModifier.Encapsulate(type, modification))
					{
						list2.Add(value[m]);
						list.Add(m);
					}
				}
				for (int num3 = list.Count - 1; num3 >= 0; num3--)
				{
					value.RemoveAt(list[num3]);
				}
				foreach (WargameSkillEffect item3 in list2)
				{
					TriggerEffect(-1, item3, !appliedOnPlayerA);
				}
				list2.Clear();
			}
			if (!dictionary.TryGetValue(EWargameEffectTrigger.WHOLE_ROUND_EFFECT_APPLIED, out value) || !value.IsValid())
			{
				return;
			}
			for (int n = 0; n < value.Count; n++)
			{
				if ((value[n].secondaryTarget == EWargameEffectTarget.BOTH || (value[n].secondaryTarget == EWargameEffectTarget.PLAYER && appliedOnPlayerA == originIsPlayerA) || (value[n].secondaryTarget == EWargameEffectTarget.OPPONENT && appliedOnPlayerA != originIsPlayerA)) && value[n].type != EWargameEffectType.EFFECT_APPLIED && value[n].triggerModifier.Encapsulate(type, modification))
				{
					TriggerEffect(-1, value[n], !appliedOnPlayerA);
				}
			}
		}

		private void OnApplyTokensModifications(bool playerA)
		{
			if (playerA)
			{
				ApplyOperation(ref m_playerABet, EWargameEffectOperation.ADD, -1f, EWargameEffectType.TOKEN_BET, playerA, playerA);
			}
			else
			{
				ApplyOperation(ref m_playerBBet, EWargameEffectOperation.ADD, -1f, EWargameEffectType.TOKEN_BET, playerA, playerA);
			}
			if ((playerA ? m_playerADelayedEffects : m_playerBDelayedEffects).TryGetValue(EWargameEffectTrigger.OVERRIDE_TOKEN_BEHAVIOUR, out var value) && value.IsValid())
			{
				foreach (WargameSkillEffect item in value)
				{
					TriggerEffect(-1, item, playerA);
				}
				return;
			}
			if (playerA)
			{
				ApplyOperation(ref m_playerADamage, EWargameEffectOperation.ADD, WargameSettings.DamagePerToken, EWargameEffectType.DAMAGE, originIsPlayerA: true, appliedOnPlayerA: true);
			}
			else
			{
				ApplyOperation(ref m_playerBDamage, EWargameEffectOperation.ADD, WargameSettings.DamagePerToken, EWargameEffectType.DAMAGE, originIsPlayerA: false, appliedOnPlayerA: false);
			}
		}

		private int GetDiceCombinationModification(bool playerA)
		{
			int num = 0;
			Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> dictionary = (playerA ? m_playerADelayedEffects : m_playerBDelayedEffects);
			if (dictionary.TryGetValue(EWargameEffectTrigger.NEXT_DICE_COMBINATION, out var value) && value.IsValid())
			{
				foreach (WargameSkillEffect item in value)
				{
					num += (int)item.operand;
				}
			}
			dictionary.Remove(EWargameEffectTrigger.NEXT_DICE_COMBINATION);
			return num;
		}

		private void ApplyOperation(ref int input, WargameSkillEffect effect, bool originIsPlayerA)
		{
			ApplyOperation(ref input, effect, originIsPlayerA, (effect.target == EWargameEffectTarget.PLAYER) ? originIsPlayerA : (!originIsPlayerA));
		}

		private void ApplyOperation(ref float input, WargameSkillEffect effect, bool originIsPlayerA)
		{
			ApplyOperation(ref input, effect, originIsPlayerA, (effect.target == EWargameEffectTarget.PLAYER) ? originIsPlayerA : (!originIsPlayerA));
		}

		private void ApplyOperation(ref int input, WargameSkillEffect effect, bool originIsPlayerA, bool appliedOnPlayerA)
		{
			int modification = SimpleApplyOperation(input, effect, originIsPlayerA);
			OnTryApplyModification(ref modification, effect.type, appliedOnPlayerA, originIsPlayerA);
			if (modification != 0)
			{
				int num = ClampValue(input, modification, effect.type);
				modification = num - input;
				input = num;
				OnModificationApplied(modification, effect.type, appliedOnPlayerA, originIsPlayerA);
			}
		}

		private void ApplyOperation(ref float input, WargameSkillEffect effect, bool originIsPlayerA, bool appliedOnPlayerA)
		{
			int modification = SimpleApplyOperation((int)input, effect, originIsPlayerA);
			OnTryApplyModification(ref modification, effect.type, appliedOnPlayerA, originIsPlayerA);
			if (modification != 0)
			{
				int num = ClampValue((int)input, modification, effect.type);
				modification = num - (int)input;
				input = num;
				OnModificationApplied(modification, effect.type, appliedOnPlayerA, originIsPlayerA);
			}
		}

		private void ApplyOperation(ref int input, EWargameEffectOperation operation, float quantity, EWargameEffectType type, bool originIsPlayerA, bool appliedOnPlayerA)
		{
			int modification = SimpleApplyOperation(input, operation, quantity);
			OnTryApplyModification(ref modification, type, appliedOnPlayerA, originIsPlayerA);
			if (modification != 0)
			{
				int num = ClampValue(input, modification, type);
				modification = num - input;
				input = num;
				OnModificationApplied(modification, type, appliedOnPlayerA, originIsPlayerA);
			}
		}

		private int SimpleApplyOperation(int input, WargameSkillEffect effect, bool effectOriginIsPlayerA)
		{
			float effectQuantity = GetEffectQuantity(effect, effectOriginIsPlayerA);
			return SimpleApplyOperation(input, effect.operation, effectQuantity);
		}

		private int SimpleApplyOperation(int input, EWargameEffectOperation operation, float quantity)
		{
			int num = input;
			switch (operation)
			{
			case EWargameEffectOperation.ADD:
				num = Mathf.FloorToInt((float)input + quantity);
				break;
			case EWargameEffectOperation.MULTIPLY:
				num = Mathf.FloorToInt((float)input * quantity);
				break;
			case EWargameEffectOperation.NULLIFY:
				num = 0;
				break;
			}
			return num - input;
		}

		private int ClampValue(int input, int diff, EWargameEffectType type)
		{
			switch (type)
			{
			case EWargameEffectType.DAMAGE:
			case EWargameEffectType.PV:
			case EWargameEffectType.TOKEN_LEFT:
			case EWargameEffectType.TOKEN_BET:
			case EWargameEffectType.DICE1_VALUE:
			case EWargameEffectType.DICE2_VALUE:
			case EWargameEffectType.DICE3_VALUE:
				return Mathf.Max(0, input + diff);
			case EWargameEffectType.DICES:
				return Mathf.Max(1, input + diff);
			case EWargameEffectType.DICE_COMBINATION:
				return Mathf.Max(1, input + diff);
			default:
				return input + diff;
			}
		}

		private float GetEffectQuantity(WargameSkillEffect effect, bool playerA)
		{
			switch (effect.quantity)
			{
			case EWargameEffectQuantity.NUMERIC:
				return effect.operand;
			case EWargameEffectQuantity.PLAYER_ASSAULT:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return playerA ? m_playerAAssault : m_playerBAssault;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)(playerA ? m_playerAAssault : m_playerBAssault) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)(playerA ? m_playerAAssault : m_playerBAssault) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.PLAYER_DAMAGE:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return playerA ? m_playerADamage : m_playerBDamage;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)(playerA ? m_playerADamage : m_playerBDamage) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)(playerA ? m_playerADamage : m_playerBDamage) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.PLAYER_PV:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return playerA ? m_playerALife : m_playerBLife;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)(playerA ? m_playerALife : m_playerBLife) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)(playerA ? m_playerALife : m_playerBLife) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.OPPONENT_ASSAULT:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return playerA ? m_playerBAssault : m_playerAAssault;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)(playerA ? m_playerBAssault : m_playerAAssault) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)(playerA ? m_playerBAssault : m_playerAAssault) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.OPPONENT_DAMAGE:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return playerA ? m_playerBDamage : m_playerADamage;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)(playerA ? m_playerBDamage : m_playerADamage) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)(playerA ? m_playerBDamage : m_playerADamage) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.OPPONENT_PV:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return playerA ? m_playerBLife : m_playerALife;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)(playerA ? m_playerBLife : m_playerALife) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)(playerA ? m_playerBLife : m_playerALife) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.PRECEDENT_ACTIVATION:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return m_precedentActivations;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)m_precedentActivations + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)m_precedentActivations * effect.operand;
				}
				break;
			case EWargameEffectQuantity.ALL_PRECEDENT_ACTIVATION:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return m_allPrecedentActivations;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)m_allPrecedentActivations + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)m_allPrecedentActivations * effect.operand;
				}
				break;
			case EWargameEffectQuantity.DELTA_ASSAULT:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return Mathf.Abs(m_playerAAssault - m_playerBAssault);
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)Mathf.Abs(m_playerAAssault - m_playerBAssault) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)Mathf.Abs(m_playerAAssault - m_playerBAssault) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.DELTA_DAMAGE:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return Mathf.Abs(m_playerADamage - m_playerBDamage);
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)Mathf.Abs(m_playerADamage - m_playerBDamage) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)Mathf.Abs(m_playerADamage - m_playerBDamage) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.DELTA_PV:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return Mathf.Abs(m_playerALife - m_playerBLife);
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)Mathf.Abs(m_playerALife - m_playerBLife) + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)Mathf.Abs(m_playerALife - m_playerBLife) * effect.operand;
				}
				break;
			case EWargameEffectQuantity.CURRENT_ACTIVATION:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return m_currentActivations;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (float)m_currentActivations + effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (float)m_currentActivations * effect.operand;
				}
				break;
			}
			return 0f;
		}

		private int GetEffectQuantityAsInt(WargameSkillEffect effect, bool playerA)
		{
			switch (effect.quantity)
			{
			case EWargameEffectQuantity.NUMERIC:
				return (int)effect.operand;
			case EWargameEffectQuantity.PLAYER_ASSAULT:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					if (!playerA)
					{
						return m_playerBAssault;
					}
					return m_playerAAssault;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (playerA ? m_playerAAssault : m_playerBAssault) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (playerA ? m_playerAAssault : m_playerBAssault) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.PLAYER_DAMAGE:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					if (!playerA)
					{
						return m_playerBDamage;
					}
					return m_playerADamage;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (playerA ? m_playerADamage : m_playerBDamage) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (playerA ? m_playerADamage : m_playerBDamage) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.PLAYER_PV:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					if (!playerA)
					{
						return m_playerBLife;
					}
					return m_playerALife;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (playerA ? m_playerALife : m_playerBLife) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (playerA ? m_playerALife : m_playerBLife) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.OPPONENT_ASSAULT:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					if (!playerA)
					{
						return m_playerAAssault;
					}
					return m_playerBAssault;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (playerA ? m_playerBAssault : m_playerAAssault) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (playerA ? m_playerBAssault : m_playerAAssault) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.OPPONENT_DAMAGE:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					if (!playerA)
					{
						return m_playerADamage;
					}
					return m_playerBDamage;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (playerA ? m_playerBDamage : m_playerADamage) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (playerA ? m_playerBDamage : m_playerADamage) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.OPPONENT_PV:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					if (!playerA)
					{
						return m_playerALife;
					}
					return m_playerBLife;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return (playerA ? m_playerBLife : m_playerALife) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return (playerA ? m_playerBLife : m_playerALife) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.PRECEDENT_ACTIVATION:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return m_precedentActivations;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return m_precedentActivations + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return m_precedentActivations * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.ALL_PRECEDENT_ACTIVATION:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return m_allPrecedentActivations;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return m_allPrecedentActivations + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return m_allPrecedentActivations * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.DELTA_ASSAULT:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return Mathf.Abs(m_playerAAssault - m_playerBAssault);
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return Mathf.Abs(m_playerAAssault - m_playerBAssault) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return Mathf.Abs(m_playerAAssault - m_playerBAssault) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.DELTA_DAMAGE:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return Mathf.Abs(m_playerADamage - m_playerBDamage);
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return Mathf.Abs(m_playerADamage - m_playerBDamage) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return Mathf.Abs(m_playerADamage - m_playerBDamage) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.DELTA_PV:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return Mathf.Abs(m_playerALife - m_playerBLife);
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return Mathf.Abs(m_playerALife - m_playerBLife) + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return Mathf.Abs(m_playerALife - m_playerBLife) * (int)effect.operand;
				}
				break;
			case EWargameEffectQuantity.CURRENT_ACTIVATION:
				switch (effect.quantityModifier)
				{
				case EWargameEffectQuantityModifier.NONE:
					return m_currentActivations;
				case EWargameEffectQuantityModifier.ADD_NUMERIC:
					return m_currentActivations + (int)effect.operand;
				case EWargameEffectQuantityModifier.MULTIPLY_NUMERIC:
					return m_currentActivations * (int)effect.operand;
				}
				break;
			}
			return 0;
		}

		private bool CheckForGameOver()
		{
			if (m_playerALife <= 0 && m_playerBLife <= 0)
			{
				GameOver(EWargameResult.DRAW);
				return true;
			}
			if (m_playerALife <= 0)
			{
				GameOver(EWargameResult.PLAYER_B);
				return true;
			}
			if (m_playerBLife <= 0)
			{
				GameOver(EWargameResult.PLAYER_A);
				return true;
			}
			if (m_round == WargameSettings.RoundCount)
			{
				if (m_playerALife == m_playerBLife)
				{
					GameOver(EWargameResult.DRAW);
					return true;
				}
				GameOver((m_playerBLife >= m_playerALife) ? EWargameResult.PLAYER_B : EWargameResult.PLAYER_A);
				return true;
			}
			return false;
		}

		private void CompleteCombatPhase()
		{
			m_uiModule.OnCompleteCombatPhase();
		}

		private void EnableNextRound()
		{
			if (!CheckForGameOver())
			{
				m_uiModule.EnableNextRound();
			}
		}

		private void NextRound()
		{
			m_round++;
			m_playerHasPriority = !m_playerHasPriority;
			TriggerDicePhase();
		}

		private void GameOver(EWargameResult result)
		{
			m_gameOver = true;
			m_uiModule.DisplayGameOver(result);
			switch (result)
			{
			case EWargameResult.PLAYER_A:
				GameAnalytics.NewOrAddDesignEvent("id_analytics_wargame1_victory", 1f);
				GetRewards();
				break;
			case EWargameResult.DRAW:
				GetRewards();
				break;
			case EWargameResult.PLAYER_B:
				TabletopWorld.TabletopGameState.TriggerTabletopXPRewardEvent(ETabletopXPRewardEvent.WARGAME_LOSS);
				Collection.AddWargameResultToSquad(TabletopWorld.WargameManager.CurrentSquadIndex, victory: false);
				break;
			}
			ComputeGameDuration();
			void GetRewards()
			{
				TabletopWorld.TabletopGameState.TriggerTabletopXPRewardEvent(ETabletopXPRewardEvent.WARGAME_WIN);
				World.GameState.GainMoney(WargameSettings.MoneyForVictory);
				Collection.AddWargameResultToSquad(TabletopWorld.WargameManager.CurrentSquadIndex, victory: true);
				MiniaturePieceData pieceData = Collection.WinOnePiece(ELicense.FWB, WargameSettings.PieceForVictoryRarityModifier, EMiniatureArmy.NONE);
				m_uiModule.ShowReward(pieceData);
			}
		}

		public void OnComplete()
		{
			if (!m_gameOver)
			{
				OnGameCancel();
			}
		}

		private void OnGameCancel()
		{
			ComputeGameDuration();
		}

		private void ComputeGameDuration()
		{
			if (!(m_gameStartTime <= 0f))
			{
				m_gameDuration = Time.unscaledTime - m_gameStartTime;
				GameAnalytics.NewDesignEvent("id_analytics_wargame1_duration", (int)m_gameDuration);
			}
		}

		private WargamePreviewState GetPreview(bool showOpponentPreview)
		{
			m_isPreview = true;
			WargameState wargameState = GetWargameState();
			Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> dictionary = new Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>>();
			EWargameEffectTrigger key;
			List<WargameSkillEffect> value;
			foreach (KeyValuePair<EWargameEffectTrigger, List<WargameSkillEffect>> playerADelayedEffect in m_playerADelayedEffects)
			{
				playerADelayedEffect.Deconstruct(out key, out value);
				EWargameEffectTrigger key2 = key;
				List<WargameSkillEffect> collection = value;
				if (collection.IsValid())
				{
					dictionary[key2] = new List<WargameSkillEffect>(collection);
				}
			}
			Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>> dictionary2 = new Dictionary<EWargameEffectTrigger, List<WargameSkillEffect>>();
			foreach (KeyValuePair<EWargameEffectTrigger, List<WargameSkillEffect>> playerBDelayedEffect in m_playerBDelayedEffects)
			{
				playerBDelayedEffect.Deconstruct(out key, out value);
				EWargameEffectTrigger key3 = key;
				List<WargameSkillEffect> collection2 = value;
				if (collection2.IsValid())
				{
					dictionary2[key3] = new List<WargameSkillEffect>(collection2);
				}
			}
			m_playerAActivationCounter = new int[GetSquad(playerA: true).Count];
			m_playerBActivationCounter = new int[GetSquad(playerA: false).Count];
			if (showOpponentPreview)
			{
				TriggerPreviewComputation(playerA: false);
			}
			TriggerPreviewComputation(playerA: true);
			m_isPreview = false;
			WargameState wargameState2 = GetWargameState();
			WargamePreviewState result = new WargamePreviewState(wargameState, wargameState2, m_playerAActivationCounter, m_playerBActivationCounter, showOpponentPreview);
			RestoreState(wargameState);
			m_playerADelayedEffects.Clear();
			foreach (KeyValuePair<EWargameEffectTrigger, List<WargameSkillEffect>> item in dictionary)
			{
				item.Deconstruct(out key, out value);
				EWargameEffectTrigger key4 = key;
				List<WargameSkillEffect> collection3 = value;
				if (collection3.IsValid())
				{
					m_playerADelayedEffects[key4] = new List<WargameSkillEffect>(collection3);
				}
			}
			m_playerBDelayedEffects.Clear();
			foreach (KeyValuePair<EWargameEffectTrigger, List<WargameSkillEffect>> item2 in dictionary2)
			{
				item2.Deconstruct(out key, out value);
				EWargameEffectTrigger key5 = key;
				List<WargameSkillEffect> collection4 = value;
				if (collection4.IsValid())
				{
					m_playerBDelayedEffects[key5] = new List<WargameSkillEffect>(collection4);
				}
			}
			return result;
		}

		private void TriggerPreviewComputation(bool playerA)
		{
			m_precedentActivations = 0;
			m_allPrecedentActivations = 0;
			m_playerAPlaying = playerA;
			int[] array = (playerA ? m_playerACombination : m_playerBCombination);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0)
				{
					EvaluateDiceEffect(array[i], playerA);
				}
			}
			int num = 0;
			foreach (MiniatureData item in GetSquad(playerA))
			{
				if (item != null && GetSquadAlive(playerA)[num])
				{
					TriggerPreviewMiniatureActivation(num, item, playerA);
				}
				num++;
			}
			int num2 = (playerA ? m_playerABet : m_playerBBet);
			for (int j = 0; j < num2; j++)
			{
				OnApplyTokensModifications(playerA);
			}
		}

		private void TriggerPreviewMiniatureActivation(int index, MiniatureData miniatureData, bool playerA)
		{
			MiniatureWargameSkill skill = miniatureData.Skill;
			m_currentActivations = skill.Condition.TriggerCount(playerA ? m_playerACombination : m_playerBCombination, GetDiceCombinationModification(playerA));
			int[] array = (playerA ? m_playerAActivationBonuses : m_playerBActivationBonuses);
			m_currentActivations += array[index];
			array[index] = 0;
			if (playerA)
			{
				m_playerAActivationCounter[index] += m_currentActivations;
			}
			else
			{
				m_playerBActivationCounter[index] += m_currentActivations;
			}
			if (m_currentActivations > 0)
			{
				for (int i = 0; i < m_currentActivations; i++)
				{
					if (!GetSquadAlive(playerA)[index])
					{
						continue;
					}
					TriggerActivateAllyMiniatureEffects(playerA);
					foreach (WargameSkillEffect effect in skill.Effects)
					{
						EvaluateEffect(index, effect, playerA);
					}
				}
				TriggerPostEffects(playerA, index);
			}
			m_precedentActivations = m_currentActivations;
			m_allPrecedentActivations += m_currentActivations;
			m_currentActivations = 0;
		}

		private void TriggerFreePreviewMiniatureActivation(int index, MiniatureData miniatureData, bool playerA, bool countAsActivation)
		{
			MiniatureWargameSkill skill = miniatureData.Skill;
			if (countAsActivation)
			{
				if (playerA)
				{
					m_playerAActivationCounter[index]++;
				}
				else
				{
					m_playerBActivationCounter[index]++;
				}
			}
			int currentActivations = m_currentActivations;
			if (GetSquadAlive(playerA)[index])
			{
				m_currentActivations = 1;
				TriggerActivateAllyMiniatureEffects(playerA);
				foreach (WargameSkillEffect effect in skill.Effects)
				{
					EvaluateEffect(index, effect, playerA);
				}
			}
			TriggerPostEffects(playerA, index);
			m_currentActivations = currentActivations;
			if (countAsActivation)
			{
				m_allPrecedentActivations++;
			}
		}

		private WargameState GetWargameState()
		{
			return new WargameState(m_playerAPlaying, m_squadAAlive, m_squadBAlive, m_playerALife, m_playerBLife, m_playerATokens, m_playerABet, m_playerBTokens, m_playerBBet, m_playerAAssault, m_playerADamage, m_playerBAssault, m_playerBDamage, m_playerADice1Effect.operand, m_playerADice2Effect.operand, m_playerADice3Effect.operand, m_playerBDice1Effect.operand, m_playerBDice2Effect.operand, m_playerBDice3Effect.operand, m_playerAActivatedMiniatures, m_playerBActivatedMiniatures, m_playerAActivationBonuses, m_playerBActivationBonuses, m_usedDices);
		}

		private void RestoreState(WargameState state)
		{
			m_playerAPlaying = state.playerAPlaying;
			state.squadAAlive.CopyTo(m_squadAAlive, 0);
			state.squadBAlive.CopyTo(m_squadBAlive, 0);
			m_playerALife = state.playerALife;
			m_playerBLife = state.playerBLife;
			m_playerATokens = state.playerATokens;
			m_playerBTokens = state.playerBTokens;
			m_playerABet = state.playerABet;
			m_playerBBet = state.playerBBet;
			m_playerAAssault = state.playerAAssault;
			m_playerBAssault = state.playerBAssault;
			m_playerADamage = state.playerADamage;
			m_playerBDamage = state.playerBDamage;
			m_playerADice1Effect.operand = state.playerADice1Value;
			m_playerADice2Effect.operand = state.playerADice2Value;
			m_playerADice3Effect.operand = state.playerADice3Value;
			m_playerBDice1Effect.operand = state.playerBDice1Value;
			m_playerBDice2Effect.operand = state.playerBDice2Value;
			m_playerBDice3Effect.operand = state.playerBDice3Value;
			state.playerAActivatedMiniatures.CopyTo(m_playerAActivatedMiniatures, 0);
			state.playerBActivatedMiniatures.CopyTo(m_playerBActivatedMiniatures, 0);
			state.playerAActivationBonuses.CopyTo(m_playerAActivationBonuses, 0);
			state.playerBActivationBonuses.CopyTo(m_playerBActivationBonuses, 0);
		}

		private void RegisterToUICallbacks(bool register)
		{
			if (register)
			{
				m_uiModule.StartedGame += OnStartedGame;
				m_uiModule.PlayerRethrewDices += OnPlayerRethrewDices;
				m_uiModule.PlayerPlacedDice += OnPlayerPlacedDice;
				m_uiModule.PlayerBetToken += OnPlayerBetToken;
				m_uiModule.PlayerConfirmedDices += OnPlayerConfirmedDices;
				m_uiModule.CompletedRound += OnCompletedRound;
			}
			else
			{
				m_uiModule.StartedGame -= OnStartedGame;
				m_uiModule.PlayerRethrewDices -= OnPlayerRethrewDices;
				m_uiModule.PlayerPlacedDice -= OnPlayerPlacedDice;
				m_uiModule.PlayerBetToken -= OnPlayerBetToken;
				m_uiModule.PlayerConfirmedDices -= OnPlayerConfirmedDices;
				m_uiModule.CompletedRound -= OnCompletedRound;
			}
		}

		private void OnStartedGame()
		{
			m_gameStartTime = Time.unscaledTime;
			GameAnalytics.NewOrAddDesignEvent("id_analytics_wargame1_launch", 1f);
			TriggerDicePhase();
		}

		private void OnPlayerRethrewDices(List<int> dices)
		{
			foreach (int dix in dices)
			{
				m_playerADices[dix] = WargameSettings.GetRandomDiceFace();
				m_uiModule.RethrowDice(dix, m_playerADices[dix]);
			}
		}

		private void OnPlayerPlacedDice(int combinationIndex, int diceValue)
		{
			PlayerAPlaceDice(combinationIndex, diceValue);
			UpdatePreview(!m_playerHasPriority && !WargameSettings.PlayAtTheSameTime);
		}

		private void OnPlayerBetToken(bool bet)
		{
			if (bet)
			{
				PlayerABet();
			}
			else
			{
				PlayerAUnbet();
			}
			UpdatePreview(!m_playerHasPriority && !WargameSettings.PlayAtTheSameTime);
		}

		private void OnPlayerConfirmedDices()
		{
			PlayerAConfirms();
		}

		private void OnCompletedRound()
		{
			NextRound();
		}

		private void UpdateUIInstant()
		{
			m_uiModule.UpdateState(GetWargameState(), m_phase);
		}

		private void UpdatePreview(bool showOpponentPreview)
		{
			m_uiModule.UpdatePreview(GetPreview(showOpponentPreview));
		}

		private void AddDelayToCombatPhase(float delay)
		{
			m_combatSequence.AppendInterval(delay);
		}

		private void UpdateUIStateDuringCombatPhase()
		{
			WargameState state = GetWargameState();
			EWargamePhase phase = m_phase;
			m_combatSequence.AppendCallback(delegate
			{
				m_uiModule.UpdateState(state, phase);
			});
		}

		private WargameSquad GetSquad(bool playerA)
		{
			if (playerA)
			{
				return m_squadA;
			}
			return m_squadB;
		}

		private bool[] GetSquadAlive(bool playerA)
		{
			if (playerA)
			{
				return m_squadAAlive;
			}
			return m_squadBAlive;
		}

		private IEnumerable<MiniatureData> GetAliveMiniaturesOfSquad(bool playerA)
		{
			if (playerA)
			{
				for (int i = 0; i < m_squadAAlive.Length; i++)
				{
					if (m_squadAAlive[i])
					{
						yield return m_squadA.Get(i);
					}
				}
				yield break;
			}
			for (int i = 0; i < m_squadBAlive.Length; i++)
			{
				if (m_squadBAlive[i])
				{
					yield return m_squadB.Get(i);
				}
			}
		}

		private MiniatureData GetMiniatureFromSquad(bool playerA, int index)
		{
			if (playerA)
			{
				return m_squadA.Get(index);
			}
			return m_squadB.Get(index);
		}

		private int GetRandomAliveMiniatureIndex(bool playerA)
		{
			List<int> list = new List<int>();
			if (playerA)
			{
				for (int i = 0; i < m_squadAAlive.Length; i++)
				{
					if (m_squadAAlive[i])
					{
						list.Add(i);
					}
				}
			}
			else
			{
				for (int j = 0; j < m_squadBAlive.Length; j++)
				{
					if (m_squadBAlive[j])
					{
						list.Add(j);
					}
				}
			}
			return list.GetRandom();
		}

		private int GetRandomAliveMiniatureIndexExcept(bool playerA, int except)
		{
			List<int> list = new List<int>();
			if (playerA)
			{
				for (int i = 0; i < m_squadAAlive.Length; i++)
				{
					if (m_squadAAlive[i] && i != except)
					{
						list.Add(i);
					}
				}
			}
			else
			{
				for (int j = 0; j < m_squadBAlive.Length; j++)
				{
					if (m_squadBAlive[j] && j != except)
					{
						list.Add(j);
					}
				}
			}
			return list.GetRandom();
		}

		private int GetRandomDeadMiniatureIndex(bool playerA)
		{
			List<int> list = new List<int>();
			if (playerA)
			{
				for (int i = 0; i < m_squadAAlive.Length; i++)
				{
					if (!m_squadAAlive[i])
					{
						list.Add(i);
					}
				}
			}
			else
			{
				for (int j = 0; j < m_squadBAlive.Length; j++)
				{
					if (!m_squadBAlive[j])
					{
						list.Add(j);
					}
				}
			}
			return list.GetRandom();
		}

		private void KillAllSequences()
		{
			m_revealDiceDelay.Kill();
			m_combatSequence.Kill();
			m_endRoundSequence.Kill();
		}
	}
}
