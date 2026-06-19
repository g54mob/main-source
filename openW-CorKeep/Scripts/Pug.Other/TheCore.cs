using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugScan;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TheCore : EntityMonoBehaviour
{
	public enum AwakeState
	{
		Undefined = 0,
		Idle = 1,
		StartAwakening = 2,
		Awakening = 3,
		Awake = 4
	}

	[Serializable]
	public class TextAndFormatField
	{
		public LocalizedString text;

		public Biome hasDirectionFormatFieldToBiome;
	}

	public enum EyeState
	{
		Undefined = 0,
		Closed = 1,
		Open = 2
	}

	[Header("Core settings")]
	public SpriteObject[] roots;

	public LightFlickerEffect coreLight;

	private const float CORE_LIGHT_RANGE = 5.5f;

	private const float CORE_LIGHT_INTENSITY = 1f;

	private const float CORE_LIGHT_INTENSITY_DEVIATION = 0.1f;

	private const float CORE_LIGHT_MIN_INTENSITY = 0.9f;

	private const float CORE_LIGHT_MAX_INTENSITY = 1.1f;

	public ParticleSystem particles;

	private int2 rootPos1 = new int2(-1, 3);

	private int2 rootPos2 = new int2(-3, -1);

	private int2 rootPos3 = new int2(2, -3);

	private int2 rootPos4 = new int2(3, 1);

	private TimerSimple rootCheckDelayTimer = new TimerSimple(0.5f);

	private List<AudioManager.RunningSfxReference> CoreAudioLoop;

	public SpriteObject PlatformSO;

	public SpriteObject CoreSO;

	public SpriteRenderer PlatformGlowSR;

	public SpriteRenderer CoreGlowSR;

	[ColorUsage(false, true)]
	public Color platformEmissiveMinColor = Color.white;

	[ColorUsage(false, true)]
	public Color platformEmissiveColor = Color.white;

	[ColorUsage(false, true)]
	public Color coreEmissiveMinColor = Color.white;

	[ColorUsage(false, true)]
	public Color coreEmissiveColor = Color.white;

	public Color platformGlowColor = Color.white;

	public Color coreGlowColor = Color.white;

	private bool isPendingAnimation;

	private bool isPlayingIntro;

	private AwakeState awakeState;

	private EntityQuery statuesQuery;

	private EntityQuery worldInfoQuery;

	public PugText coreSpeechText;

	public List<PugText> coreSpeechTextOutlines;

	public List<PugTextEffectEnunciateSyllables> coreSyllables;

	public List<TextAndFormatField> coreSpeechStrings;

	public List<TextAndFormatField> soulOfBirdBossStrings;

	public List<TextAndFormatField> soulOfOctopusBossStrings;

	public List<TextAndFormatField> soulOfScarabBossStrings;

	public List<TextAndFormatField> soulOfHydraBossNatureStrings;

	public List<TextAndFormatField> soulOfHydraBossSeaStrings;

	public List<TextAndFormatField> soulOfHydraBossDesertStrings;

	public List<TextAndFormatField> coreBossStrings;

	public List<TextAndFormatField> coreBossRevealedStrings;

	public List<TextAndFormatField> giantCicadaStrings;

	public List<TextAndFormatField> robotBossStrings;

	private const string cardinalPreFix = "CardinalDirections/";

	private int birdBossLastHintIndex;

	private int octopusBossLastHintIndex;

	private int scarabBossLastHintIndex;

	private int hydraBossNatureLastHintIndex;

	private int hydraBossSeaLastHintIndex;

	private int hydraBossDesertLastHintIndex;

	private int coreBossRevealedLastIndex;

	private int giantCicadaLastHintIndex;

	private int robotBossLastHintIndex;

	public List<TextAndFormatField> greatWallHintStrings;

	private int greatWallLastHintIndex;

	public LocalizedString finalSpeechString;

	private int coreSpeechIndex;

	private const float DISTANCE_SQ_FROM_OTHER_PLAYERS_TO_TRIGGER_OUTRO = 100f;

	public ParticleSystem gatherEnergyEffect;

	public ParticleSystem empowerPlayerEffect;

	public Transform playerTarget;

	public bool startAtLastSentenceOnActivateDebug;

	public CompassDirection[] biomeDirections;

	public bool overrideCrystalsFilledDebug;

	public int statuesDoneLoading;

	private int statuesDonePrevious;

	private float activeLightStrength;

	private float targetLightStrength;

	private TimerSimple useCooldownTimer = new TimerSimple(0.5f);

	private bool isDoingCicadaDialogue;

	private bool isDoingRobotDialogue;

	private bool isDoingUnlockingSoulsDialogue;

	private List<TextAndFormatField> activationStringsToUse;

	private bool fadingOut;

	private bool reseting;

	private float fadeValue = 1f;

	private EyeState eyeState;

	private TimerSimple eyeRandomAnimationTimer = new TimerSimple(2f);

	private bool eyeIsFollowingPlayer;

	private static readonly int PlayerX = Animator.StringToHash("playerX");

	private static readonly int PlayerY = Animator.StringToHash("playerY");

	public override void OnOccupied()
	{
		base.OnOccupied();
		statuesQuery = Manager.ecs.GetClientEntityQuery(typeof(BossStatueCD));
		worldInfoQuery = Manager.ecs.GetClientEntityQuery(typeof(WorldInfoCD));
		biomeDirections = Manager.ecs.GetClientEntityQuery(typeof(BiomeDirectionCD)).GetSingleton<BiomeDirectionCD>().Value.ToArray<CompassDirection>(12);
		overrideCrystalsFilledDebug = false;
		startAtLastSentenceOnActivateDebug = false;
		isPendingAnimation = false;
		if (startAtLastSentenceOnActivateDebug)
		{
			coreSpeechIndex = coreSpeechStrings.Count - 1;
		}
		else
		{
			coreSpeechIndex = 0;
		}
		birdBossLastHintIndex = 0;
		gatherEnergyEffect.Stop(withChildren: true);
		empowerPlayerEffect.Stop(withChildren: true);
		Manager.effects.SetScanEffectValues(0f, 0f, 10f, base.RenderPosition);
		coreLight.flickeringLight.range = 5.5f;
		coreLight.SetIntensityRange(0.9f, 1.1f);
		UpdateStatueLoadState();
		StartCoroutine(InitializeState());
		eyeState = EyeState.Undefined;
		eyeIsFollowingPlayer = false;
		isPlayingIntro = false;
		isDoingUnlockingSoulsDialogue = false;
		ResetSpeechText();
		UpdateRootVisuals(playRemoveParticlesOnRemove: false);
		UpdateLightVisualsAndAwakeState();
		rootCheckDelayTimer.Start();
		UpdateEyeAndAwakeAnimations();
		if (Manager.sceneHandler.optionalCutsceneHandler != null)
		{
			Manager.sceneHandler.optionalCutsceneHandler.theCore = this;
		}
	}

	private IEnumerator InitializeState()
	{
		TimerSimple timer = new TimerSimple(2f);
		timer.Start();
		while (!timer.isTimerElapsed)
		{
			if (worldInfoQuery.TryGetSingleton<WorldInfoCD>(out var value))
			{
				if (value.coreIsActivated)
				{
					awakeState = AwakeState.Awake;
				}
				else
				{
					awakeState = AwakeState.Idle;
				}
				break;
			}
			yield return null;
		}
		if (awakeState == AwakeState.Awake)
		{
			SetGlow(1f);
		}
		else
		{
			SetGlow(0f);
		}
		UpdateCoreSprite();
	}

	public override void OnFree()
	{
		if (Manager.sceneHandler.optionalCutsceneHandler != null)
		{
			Manager.sceneHandler.optionalCutsceneHandler.theCore = null;
		}
		StopAllCoroutines();
		base.OnFree();
	}

	protected override void OnShow()
	{
		if (awakeState == AwakeState.Awake && CoreAudioLoop == null)
		{
			CoreAudioLoop = new List<AudioManager.RunningSfxReference>();
			AudioManager.Sfx(SfxTableID.coreAudioLoop, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, CoreAudioLoop);
		}
		base.OnShow();
	}

	protected override void OnHide()
	{
		if (CoreAudioLoop != null)
		{
			foreach (AudioManager.RunningSfxReference item in CoreAudioLoop)
			{
				item.FadeOutAndStop();
			}
			CoreAudioLoop.Clear();
			CoreAudioLoop = null;
		}
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateRootVisuals(playRemoveParticlesOnRemove: true);
		UpdateLightVisualsAndAwakeState();
		UpdateSpeechText();
		UpdateTargetToFollowPlayer();
		UpdateEyeAndAwakeAnimations();
	}

	private void UpdateCoreSprite()
	{
		if (awakeState == AwakeState.Awake)
		{
			CoreSO.PlayAnimation(1260321794);
		}
		else
		{
			CoreSO.PlayAnimation(-601574123);
		}
	}

	private void UpdateRootVisuals(bool playRemoveParticlesOnRemove)
	{
		if (!rootCheckDelayTimer.isRunning || rootCheckDelayTimer.isTimerElapsed)
		{
			int2 int5 = base.WorldPosition.RoundToInt2();
			SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
			UpdateRootVisibility(0, tileLayerLookup.GetTopTile(int5 + rootPos1).tileType != TileType.bigRoot, playRemoveParticlesOnRemove);
			UpdateRootVisibility(1, tileLayerLookup.GetTopTile(int5 + rootPos2).tileType != TileType.bigRoot, playRemoveParticlesOnRemove);
			UpdateRootVisibility(2, tileLayerLookup.GetTopTile(int5 + rootPos3).tileType != TileType.bigRoot, playRemoveParticlesOnRemove);
			UpdateRootVisibility(3, tileLayerLookup.GetTopTile(int5 + rootPos4).tileType != TileType.bigRoot, playRemoveParticlesOnRemove);
		}
	}

	private void UpdateRootVisibility(int index, bool blockRemoved, bool playRemoveParticlesOnRemove)
	{
		if (roots[index].gameObject.activeInHierarchy && blockRemoved && playRemoveParticlesOnRemove)
		{
			Manager.effects.PlayPuff(PuffID.WoodDebris, roots[index].transform.position + new Vector3(0f, 0.5f, 0f));
		}
		if (roots[index].gameObject.activeSelf == blockRemoved)
		{
			roots[index].gameObject.SetActive(!blockRemoved);
		}
	}

	private void UpdateStatueLoadState()
	{
		using NativeArray<BossStatueCD> nativeArray = statuesQuery.ToComponentDataArray<BossStatueCD>(Allocator.Temp);
		if (overrideCrystalsFilledDebug)
		{
			return;
		}
		statuesDoneLoading = 0;
		for (int i = 0; i < nativeArray.Length; i++)
		{
			if (nativeArray[i].doneLoadingUp)
			{
				statuesDoneLoading++;
			}
		}
		statuesDoneLoading = Mathf.Min(statuesDoneLoading, 3);
	}

	private void UpdateLightVisualsAndAwakeState()
	{
		if (!isPlayingIntro)
		{
			UpdateStatueLoadState();
			if (statuesDoneLoading == 3 && awakeState == AwakeState.Idle)
			{
				awakeState = AwakeState.StartAwakening;
			}
			targetLightStrength = (float)statuesDoneLoading / 3f;
			if (statuesDonePrevious != statuesDoneLoading && awakeState != AwakeState.Awake)
			{
				StartCoroutine(GlowChange_Coroutine(activeLightStrength, targetLightStrength, 3f));
				activeLightStrength = targetLightStrength;
				statuesDonePrevious = statuesDoneLoading;
			}
			coreLight.SetIntensityRange(0.9f + targetLightStrength, 1.1f + targetLightStrength);
		}
	}

	private void SetGlow(float strength)
	{
		PlatformSO.emissiveColor = Color.Lerp(platformEmissiveMinColor, platformEmissiveColor, math.pow(strength, 3.5f));
		CoreSO.emissiveColor = Color.Lerp(coreEmissiveMinColor, coreEmissiveColor, math.pow(strength, 3.5f));
		PlatformGlowSR.color = Color.Lerp(Color.clear, platformGlowColor, strength);
		CoreGlowSR.color = Color.Lerp(Color.clear, coreGlowColor, math.pow(strength, 2f));
		int num = 300;
		SetParticlesAmount((float)num * strength);
	}

	private void SetParticlesAmount(float amountNormalized)
	{
		ParticleSystem.EmissionModule emission = particles.emission;
		emission.rateOverTime = amountNormalized;
	}

	public IEnumerator Intro_Coroutine()
	{
		isPlayingIntro = true;
		yield return new WaitForSeconds(2f);
		TimerSimple timer = new TimerSimple(2f);
		timer.Start();
		bool hasStartedFire = false;
		StartCoroutine(GlowChange_Coroutine(0f, 1f, 2f));
		StartCoroutine(LightRangeChange_Coroutine(5.5f, 9.5f, 1f, 1f, 2f));
		while (!timer.isTimerElapsed)
		{
			if (timer.remainingTime < 1f && !hasStartedFire)
			{
				CoreSO.PlayAnimation(1260321794);
				animator.SetTrigger(436585760);
				hasStartedFire = true;
				animator.SetTrigger("fire");
			}
			yield return null;
		}
		yield return new WaitForSeconds(0.5f);
		AudioManager.SfxFollowTransform(SfxID.ElectricShock1, base.transform, 0.25f);
		animator.SetTrigger("lightning1");
		yield return new WaitForSeconds(1f);
		animator.SetTrigger("lightning2");
		AudioManager.SfxFollowTransform(SfxID.ElectricShock2, base.transform, 0.25f);
		yield return new WaitForSeconds(2.5f);
		AudioManager.SfxFollowTransform(SfxID.MagicBuildup, base.transform, 0.4f);
		yield return new WaitForSeconds(0.25f);
		animator.SetTrigger("swirl");
		yield return new WaitForSeconds(1.25f);
		CoreSO.PlayAnimation(-601574123);
		StartCoroutine(GlowChange_Coroutine(1f, 0f, 1f));
		StartCoroutine(LightRangeChange_Coroutine(9.5f, 5.5f, 1f, 1f, 1f));
		eyeState = EyeState.Undefined;
		eyeIsFollowingPlayer = false;
		isPlayingIntro = false;
	}

	public void OnUse()
	{
		if (useCooldownTimer.isRunning && !useCooldownTimer.isTimerElapsed)
		{
			return;
		}
		useCooldownTimer.Start();
		if (awakeState == AwakeState.Awake)
		{
			if (coreSyllables[0].done && !fadingOut)
			{
				if (worldInfoQuery.IsEmpty)
				{
					return;
				}
				WorldInfoCD singleton = worldInfoQuery.GetSingleton<WorldInfoCD>();
				bool greatWallHasBeenLowered = singleton.greatWallHasBeenLowered;
				if (!Manager.saves.HasUnlockedSouls() || isDoingUnlockingSoulsDialogue)
				{
					UpdateUnlockingSoulsSequence();
					return;
				}
				if (isDoingCicadaDialogue)
				{
					UpdateChainedDialogueSequence(ref isDoingCicadaDialogue, ref giantCicadaLastHintIndex, giantCicadaStrings);
					return;
				}
				if (isDoingRobotDialogue)
				{
					UpdateChainedDialogueSequence(ref isDoingRobotDialogue, ref robotBossLastHintIndex, robotBossStrings);
					return;
				}
				bool birdBossBeenKilled = singleton.birdBossBeenKilled;
				bool flag = Manager.saves.HasCollectedSoul(SoulID.SoulOfAzeos);
				bool octopusBossHasBeenKilled = singleton.octopusBossHasBeenKilled;
				bool flag2 = Manager.saves.HasCollectedSoul(SoulID.SoulOfOmoroth);
				bool scarabHasBeenKilled = singleton.scarabHasBeenKilled;
				bool flag3 = Manager.saves.HasCollectedSoul(SoulID.SoulOfScarab);
				bool hydraBossNatureHasBeenKilled = singleton.hydraBossNatureHasBeenKilled;
				bool flag4 = Manager.saves.HasCollectedSoul(SoulID.SoulOfNatureHydra);
				bool hydraBossSeaHasBeenKilled = singleton.hydraBossSeaHasBeenKilled;
				bool flag5 = Manager.saves.HasCollectedSoul(SoulID.SoulOfSeaHydra);
				bool hydraBossDesertHasBeenKilled = singleton.hydraBossDesertHasBeenKilled;
				bool flag6 = Manager.saves.HasCollectedSoul(SoulID.SoulOfDesertHydra);
				bool giantCicadaBossHasBeenKilled = singleton.giantCicadaBossHasBeenKilled;
				bool robotBossHasBeenKilled = singleton.robotBossHasBeenKilled;
				bool coreBossHasBeenKilled = singleton.coreBossHasBeenKilled;
				if (singleton.birdBossBeenKilled && singleton.octopusBossHasBeenKilled && singleton.scarabHasBeenKilled && singleton.hydraBossNatureHasBeenKilled && singleton.hydraBossSeaHasBeenKilled && singleton.hydraBossDesertHasBeenKilled && Manager.saves.HasCollectedAllSouls() && !coreBossHasBeenKilled && greatWallHasBeenLowered && !Manager.ui.mapUI.IsShowingUniqueMarker(ObjectID.CrystalMeteor))
				{
					UpdateUnlockingCoreBossSequence();
				}
				else
				{
					if (coreSpeechText.displayedTextString == "")
					{
						LocalizedString thingToSay = default(LocalizedString);
						string[] formatFields = null;
						if (!greatWallHasBeenLowered)
						{
							if (!Manager.saves.HasCollectedSoul(SoulID.SoulOfAzeos))
							{
								SpawnMarker(ObjectID.NatureBossStatue, sendResponse: false);
							}
							int index = greatWallLastHintIndex % greatWallHintStrings.Count;
							thingToSay = greatWallHintStrings[index].text;
							greatWallLastHintIndex++;
							if (greatWallHintStrings[index].hasDirectionFormatFieldToBiome != Biome.None)
							{
								Biome hasDirectionFormatFieldToBiome = greatWallHintStrings[index].hasDirectionFormatFieldToBiome;
								string text = "CardinalDirections/" + biomeDirections[(int)hasDirectionFormatFieldToBiome];
								formatFields = new string[1] { text };
							}
						}
						else if (!birdBossBeenKilled || !flag)
						{
							SpawnMarker(ObjectID.NatureBossStatue, sendResponse: false);
							GetNextHint(soulOfBirdBossStrings, birdBossLastHintIndex, out thingToSay, out formatFields);
							birdBossLastHintIndex++;
						}
						else if (!octopusBossHasBeenKilled || !flag2)
						{
							SpawnMarker(ObjectID.SeaBossStatue, sendResponse: false);
							GetNextHint(soulOfOctopusBossStrings, octopusBossLastHintIndex, out thingToSay, out formatFields);
							octopusBossLastHintIndex++;
						}
						else if (!scarabHasBeenKilled || !flag3)
						{
							SpawnMarker(ObjectID.DesertBossStatue, sendResponse: false);
							GetNextHint(soulOfScarabBossStrings, scarabBossLastHintIndex, out thingToSay, out formatFields);
							scarabBossLastHintIndex++;
						}
						else if (!hydraBossNatureHasBeenKilled || !flag4)
						{
							SpawnMarker(ObjectID.HydraBossStatue, sendResponse: false);
							GetNextHint(soulOfHydraBossNatureStrings, hydraBossNatureLastHintIndex, out thingToSay, out formatFields);
							hydraBossNatureLastHintIndex++;
						}
						else if (!hydraBossSeaHasBeenKilled || !flag5)
						{
							SpawnMarker(ObjectID.HydraBossStatue, sendResponse: false);
							GetNextHint(soulOfHydraBossSeaStrings, hydraBossSeaLastHintIndex, out thingToSay, out formatFields);
							hydraBossSeaLastHintIndex++;
						}
						else if (!hydraBossDesertHasBeenKilled || !flag6)
						{
							SpawnMarker(ObjectID.HydraBossStatue, sendResponse: false);
							GetNextHint(soulOfHydraBossDesertStrings, hydraBossDesertLastHintIndex, out thingToSay, out formatFields);
							hydraBossDesertLastHintIndex++;
						}
						else if (Manager.ui.mapUI.IsShowingUniqueMarker(ObjectID.CrystalMeteor) && Manager.saves.HasCollectedAllSouls() && !coreBossHasBeenKilled)
						{
							int index2 = coreBossRevealedLastIndex % coreBossRevealedStrings.Count;
							thingToSay = coreBossRevealedStrings[index2].text;
							if (coreBossRevealedStrings[index2].hasDirectionFormatFieldToBiome != Biome.None)
							{
								Biome hasDirectionFormatFieldToBiome2 = coreBossRevealedStrings[index2].hasDirectionFormatFieldToBiome;
								string text2 = "CardinalDirections/" + biomeDirections[(int)hasDirectionFormatFieldToBiome2];
								formatFields = new string[1] { text2 };
							}
							coreBossRevealedLastIndex++;
						}
						else if (Manager.saves.HasCollectedAllSouls() && coreBossHasBeenKilled && !Manager.saves.HasPlayedOutro())
						{
							PlayerController player = Manager.main.player;
							if (player == null)
							{
								return;
							}
							foreach (PlayerController nonLocalPlayer in Manager.main.nonLocalPlayers)
							{
								if (math.distancesq(nonLocalPlayer.RenderPosition, player.RenderPosition) > 100f)
								{
									Emote.SpawnEmoteText(player.center, Emote.EmoteType.AllPlayersMustBeGathered);
									return;
								}
							}
							StartOutro(new PopupResponse(confirm: true));
						}
						else if (!giantCicadaBossHasBeenKilled)
						{
							SpawnMarker(ObjectID.PassageBossStatue, sendResponse: false);
							UpdateChainedDialogueSequence(ref isDoingCicadaDialogue, ref giantCicadaLastHintIndex, giantCicadaStrings);
						}
						else if (!robotBossHasBeenKilled)
						{
							SpawnMarker(ObjectID.ExcavationBossStatue, sendResponse: false);
							UpdateChainedDialogueSequence(ref isDoingRobotDialogue, ref robotBossLastHintIndex, robotBossStrings);
						}
						else
						{
							thingToSay = finalSpeechString;
						}
						if (string.IsNullOrEmpty(thingToSay.mTerm))
						{
							return;
						}
						coreSpeechText.formatFields = formatFields;
						coreSpeechText.Render(thingToSay.mTerm, rewindEffectAnims: true);
						{
							foreach (PugText coreSpeechTextOutline in coreSpeechTextOutlines)
							{
								coreSpeechTextOutline.formatFields = coreSpeechText.formatFields;
								coreSpeechTextOutline.Render(thingToSay.mTerm, rewindEffectAnims: true);
							}
							return;
						}
					}
					FadeOutSpeechText();
				}
			}
			else
			{
				FinishCurrentSpeechText();
				AudioManager.Sfx(SfxTableID.menuSkip, Vector3.zero, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.UI);
			}
		}
		else
		{
			PlayerController player2 = Manager.main.player;
			if (player2 != null)
			{
				Emote.SpawnEmoteText(player2.center, Emote.EmoteType.ObjectNeedsEnergy);
				AudioManager.Sfx(SfxTableID.playerInteractWithInactiveCore, player2.center);
			}
		}
	}

	private void GetNextHint(List<TextAndFormatField> hintList, int hintIndex, out LocalizedString thingToSay, out string[] formatFields)
	{
		int index = hintIndex % hintList.Count;
		thingToSay = hintList[index].text;
		formatFields = null;
		if (hintList[index].hasDirectionFormatFieldToBiome != Biome.None)
		{
			Biome hasDirectionFormatFieldToBiome = hintList[index].hasDirectionFormatFieldToBiome;
			string text = "CardinalDirections/" + biomeDirections[(int)hasDirectionFormatFieldToBiome];
			formatFields = new string[1] { text };
		}
	}

	private void UpdateUnlockingSoulsSequence()
	{
		if (isPendingAnimation)
		{
			return;
		}
		isDoingUnlockingSoulsDialogue = true;
		if (coreSpeechIndex < coreSpeechStrings.Count)
		{
			if (Manager.main.player != null && !Manager.saves.HasUnlockedSouls())
			{
				Manager.main.player.UnlockSouls();
			}
			if (coreSpeechIndex == 0 || coreSpeechIndex == 7)
			{
				animator.SetTrigger(-1278052697);
			}
			else if (coreSpeechIndex == 4)
			{
				animator.SetTrigger(842569181);
			}
			else if (coreSpeechIndex == 2)
			{
				animator.SetTrigger(-331764715);
			}
			else if (coreSpeechIndex == 5)
			{
				StartCoroutine(ScanArea_Coroutine(revealNatureBossStatue: true));
				return;
			}
			activationStringsToUse = coreSpeechStrings;
			StartNextActivationSentence();
		}
		else if (coreSpeechIndex >= coreSpeechStrings.Count)
		{
			FadeOutSpeechText();
			StartCoroutine(EmpowerPlayer_Coroutine());
			isDoingUnlockingSoulsDialogue = false;
		}
	}

	private void UpdateChainedDialogueSequence(ref bool isDoingDialogue, ref int hintIndex, List<TextAndFormatField> hintList)
	{
		if (!isDoingDialogue)
		{
			isDoingDialogue = true;
		}
		if (hintIndex < hintList.Count)
		{
			GetNextHint(hintList, hintIndex, out var thingToSay, out var formatFields);
			hintIndex++;
			coreSpeechText.formatFields = formatFields;
			coreSpeechText.Render(thingToSay.mTerm, rewindEffectAnims: true);
			{
				foreach (PugText coreSpeechTextOutline in coreSpeechTextOutlines)
				{
					coreSpeechTextOutline.formatFields = coreSpeechText.formatFields;
					coreSpeechTextOutline.Render(thingToSay.mTerm, rewindEffectAnims: true);
				}
				return;
			}
		}
		FadeOutSpeechText();
		isDoingDialogue = false;
		hintIndex = 0;
	}

	private void UpdateUnlockingCoreBossSequence()
	{
		if (isPendingAnimation)
		{
			return;
		}
		if (coreSpeechIndex < coreBossStrings.Count)
		{
			if (coreSpeechIndex == 4)
			{
				StartCoroutine(ScanArea_Coroutine(revealNatureBossStatue: false, revealCoreBoss: true));
				return;
			}
			activationStringsToUse = coreBossStrings;
			StartNextActivationSentence();
		}
		else if (coreSpeechIndex >= coreBossStrings.Count)
		{
			FadeOutSpeechText();
		}
	}

	private void StartOutro(PopupResponse response)
	{
		if (response.IsConfirm)
		{
			Manager.main.player.TriggerOutroForAllPlayers();
		}
	}

	private void StartNextActivationSentence()
	{
		string[] formatFields = null;
		if (activationStringsToUse[coreSpeechIndex].hasDirectionFormatFieldToBiome != Biome.None)
		{
			Biome hasDirectionFormatFieldToBiome = activationStringsToUse[coreSpeechIndex].hasDirectionFormatFieldToBiome;
			string text = "CardinalDirections/" + biomeDirections[(int)hasDirectionFormatFieldToBiome];
			formatFields = new string[1] { text };
		}
		coreSpeechText.formatFields = formatFields;
		coreSpeechText.Render(activationStringsToUse[coreSpeechIndex].text.mTerm, rewindEffectAnims: true);
		foreach (PugText coreSpeechTextOutline in coreSpeechTextOutlines)
		{
			coreSpeechTextOutline.formatFields = coreSpeechText.formatFields;
			coreSpeechTextOutline.Render(activationStringsToUse[coreSpeechIndex].text.mTerm, rewindEffectAnims: true);
		}
		coreSpeechIndex++;
	}

	private IEnumerator LookAround_Coroutine()
	{
		isPendingAnimation = true;
		FadeOutSpeechText(reset: false);
		yield return new WaitForSeconds(0.8f);
		animator.SetTrigger(-331764715);
		yield return new WaitForSeconds(1.4f);
		StartNextActivationSentence();
		isPendingAnimation = false;
	}

	private IEnumerator ScanArea_Coroutine(bool revealNatureBossStatue = false, bool revealCoreBoss = false)
	{
		isPendingAnimation = true;
		FadeOutSpeechText(reset: false);
		animator.SetTrigger(842569181);
		yield return new WaitForSeconds(0.5f);
		animator.SetTrigger(318865860);
		yield return new WaitForSeconds(0.5f);
		Manager.effects.PlayScanEffect(base.RenderPosition, 10f, 5f);
		yield return new WaitForSeconds(3.7f);
		if (revealNatureBossStatue && Manager.main.player != null)
		{
			base.world.GetExistingSystemManaged<PugScanClientSystem>().Scan(new ScanRequestCD
			{
				objectToScan = new ObjectDataCD
				{
					objectID = ObjectID.NatureBossStatue
				},
				sendResponse = false,
				typeOfRequest = PugScanType.Scan
			});
		}
		if (revealCoreBoss && Manager.main.player != null)
		{
			base.world.GetExistingSystemManaged<PugScanClientSystem>().Scan(new ScanRequestCD
			{
				objectToScan = new ObjectDataCD
				{
					objectID = ObjectID.CrystalMeteor
				},
				sendResponse = false,
				typeOfRequest = PugScanType.Scan
			});
		}
		animator.SetTrigger(-1536130140);
		yield return new WaitForSeconds(0.5f);
		StartNextActivationSentence();
		isPendingAnimation = false;
	}

	public IEnumerator EmpowerPlayer_Coroutine()
	{
		isPendingAnimation = true;
		animator.SetTrigger(-1278052697);
		empowerPlayerEffect.Play(withChildren: true);
		AudioManager.SfxFollowTransform(SfxID.powerUp, base.transform, 0.8f, 0.85f);
		yield return new WaitForSeconds(0.25f);
		if (Manager.main.player != null)
		{
			Manager.main.player.flashableComponent.FlashLinearNoCurve(3.5f);
		}
		yield return new WaitForSeconds(1.75f);
		eyeState = EyeState.Undefined;
		eyeIsFollowingPlayer = false;
		if (!Manager.ui.characterWindow.isShowing)
		{
			Manager.ui.ShowBagLightUpHint();
		}
		isPendingAnimation = false;
		empowerPlayerEffect.Stop(withChildren: true);
		yield return new WaitForSeconds(3f);
	}

	private void UpdateTargetToFollowPlayer()
	{
		if (Manager.main.player != null)
		{
			playerTarget.position = Manager.main.player.center;
		}
	}

	private void UpdateSpeechText()
	{
		if (fadingOut)
		{
			for (int i = 0; i < coreSpeechText.glyphs.Count; i++)
			{
				coreSpeechText.glyphs[i].SetAlpha(fadeValue);
			}
			foreach (PugText coreSpeechTextOutline in coreSpeechTextOutlines)
			{
				for (int j = 0; j < coreSpeechTextOutline.glyphs.Count; j++)
				{
					coreSpeechTextOutline.glyphs[j].SetAlpha(fadeValue);
				}
			}
			if (fadeValue <= 0f)
			{
				fadeValue = 1f;
				fadingOut = false;
				if (reseting)
				{
					ResetSpeechText();
				}
			}
			fadeValue = Mathf.Clamp01(fadeValue - Time.deltaTime * 2f);
		}
		else if (Manager.main.player == null || math.distancesq(Manager.main.player.RenderPosition, base.RenderPosition) > 16f)
		{
			if (coreSpeechText.displayedTextString != "")
			{
				FadeOutSpeechText();
			}
			isDoingUnlockingSoulsDialogue = false;
		}
	}

	private void FinishCurrentSpeechText()
	{
		foreach (PugTextEffectEnunciateSyllables coreSyllable in coreSyllables)
		{
			coreSyllable.FinishEffect();
		}
	}

	private void FadeOutSpeechText(bool reset = true)
	{
		fadingOut = true;
		reseting = reset;
		foreach (PugTextEffectEnunciateSyllables coreSyllable in coreSyllables)
		{
			coreSyllable.StopPlaying();
		}
	}

	private void ResetSpeechText()
	{
		coreSpeechText.Render("", rewindEffectAnims: true);
		foreach (PugText coreSpeechTextOutline in coreSpeechTextOutlines)
		{
			coreSpeechTextOutline.Render("");
		}
		foreach (PugTextEffectEnunciateSyllables coreSyllable in coreSyllables)
		{
			coreSyllable.StopPlaying();
		}
		coreSpeechIndex = 0;
	}

	private void UpdateEyeAndAwakeAnimations()
	{
		if (awakeState == AwakeState.StartAwakening)
		{
			StartCoroutine(WakeUp_Coroutine());
		}
		if (awakeState == AwakeState.Awake && eyeState != EyeState.Open)
		{
			animator.SetTrigger(-1536130140);
			eyeState = EyeState.Open;
		}
		else if (awakeState == AwakeState.Idle && eyeState != EyeState.Closed)
		{
			animator.SetTrigger(80170468);
			eyeState = EyeState.Closed;
		}
		if (awakeState != AwakeState.Awake)
		{
			return;
		}
		bool flag = false;
		PlayerController player = Manager.main.player;
		Vector3 vector = Vector3.zero;
		if (player != null)
		{
			vector = playerTarget.position - base.transform.position;
			flag = vector.z > -10f && vector.z < -1f && math.abs(vector.x) < 6f;
		}
		if (flag && eyeState == EyeState.Open && !eyeIsFollowingPlayer)
		{
			eyeIsFollowingPlayer = true;
			animator.SetTrigger(1748255856);
		}
		else if (!flag && eyeIsFollowingPlayer)
		{
			eyeIsFollowingPlayer = false;
			animator.SetTrigger(1749173997);
			eyeRandomAnimationTimer.Start(UnityEngine.Random.Range(4f, 10f));
		}
		animator.SetFloat(PlayerX, vector.x);
		animator.SetFloat(PlayerY, vector.z);
		if (eyeIsFollowingPlayer || awakeState != AwakeState.Awake)
		{
			return;
		}
		if (!eyeRandomAnimationTimer.isRunning)
		{
			eyeRandomAnimationTimer.Start(UnityEngine.Random.Range(4f, 10f));
		}
		if (eyeRandomAnimationTimer.isTimerElapsed)
		{
			eyeRandomAnimationTimer.Start(UnityEngine.Random.Range(4f, 10f));
			if (UnityEngine.Random.value < 0.7f)
			{
				animator.SetTrigger(842569181);
			}
			else
			{
				animator.SetTrigger(-331764715);
			}
		}
	}

	private IEnumerator WakeUp_Coroutine()
	{
		awakeState = AwakeState.Awakening;
		gatherEnergyEffect.Play(withChildren: true);
		animator.SetTrigger(1875937994);
		yield return new WaitForSeconds(0.25f);
		AudioManager.SfxFollowTransform(SfxID.MagicBuildup, base.transform, 0.4f);
		yield return new WaitForSeconds(1.75f);
		gatherEnergyEffect.Stop(withChildren: true);
		yield return new WaitForSeconds(0.8f);
		AudioManager.SfxFollowTransform(SfxID.darkgleam, base.transform);
		SpawnEffect freeComponent = Manager.memory.GetFreeComponent<SpawnEffect>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.transform.position = base.RenderPosition + new Vector3(0f, 5f, -6f);
			freeComponent.OnOccupied();
		}
		else
		{
			Debug.LogError("failed to instantiate player spawn effect");
		}
		if (CoreAudioLoop == null)
		{
			CoreAudioLoop = new List<AudioManager.RunningSfxReference>();
			AudioManager.Sfx(SfxTableID.coreAudioLoop, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, CoreAudioLoop);
		}
		CoreSO.PlayAnimation(1260321794);
		animator.SetTrigger(910517187);
		animator.SetTrigger(1796921150);
		yield return new WaitForSeconds(2.5f);
		awakeState = AwakeState.Awake;
	}

	public IEnumerator GlowChange_Coroutine(float StartStrength, float EndStrength, float Duration)
	{
		TimerSimple timer = new TimerSimple(Duration);
		timer.Start();
		while (!timer.isTimerElapsed)
		{
			SetGlow(Mathf.Lerp(StartStrength, EndStrength, timer.elapsedRatio));
			yield return null;
		}
	}

	public IEnumerator LightRangeChange_Coroutine(float StartRange, float EndRange, float StartIntensity, float EndIntensity, float Duration)
	{
		TimerSimple timer = new TimerSimple(Duration);
		timer.Start();
		while (!timer.isTimerElapsed)
		{
			float num = Mathf.Lerp(StartIntensity, EndIntensity, timer.elapsedRatio);
			coreLight.SetIntensityRange(num - 0.1f, num + 0.1f);
			coreLight.flickeringLight.range = Mathf.Lerp(StartRange, EndRange, timer.elapsedRatio);
			yield return null;
		}
		coreLight.flickeringLight.range = EndRange;
		coreLight.SetIntensityRange(EndIntensity - 0.1f, EndIntensity + 0.1f);
	}

	private void SpawnMarker(ObjectID markerID, bool sendResponse = true)
	{
		if (Manager.main.player != null)
		{
			base.world.GetExistingSystemManaged<PugScanClientSystem>().Scan(new ScanRequestCD
			{
				objectToScan = new ObjectDataCD
				{
					objectID = markerID
				},
				sendResponse = sendResponse,
				typeOfRequest = PugScanType.Scan
			});
		}
	}
}
