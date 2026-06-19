#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	public class CharacterAnimationEvents : MustCallDestroy
	{
		private readonly Character _character;

		private readonly Level _level;

		private readonly List<AdditionalActorDefinition> _extras;

		[DontSave]
		private List<GameObject> _extraGameObjects;

		public CharacterAnimationEvents(Character character, Level level)
		{
			_character = character;
			_level = level;
			_extraGameObjects = new List<GameObject>();
			_extras = new List<AdditionalActorDefinition>();
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_extraGameObjects = new List<GameObject>();
			RegisterEvents();
			foreach (AdditionalActorDefinition extra in _extras)
			{
				SpawnExtraInternal(extra);
			}
		}

		private void RegisterEvents()
		{
			AnimationEventListener animationEventListener = _character.AnimationEventListener;
			animationEventListener.RegisterEvent("SpawnExtra", SpawnExtraEvent);
			animationEventListener.RegisterEvent("DestroyExtra", DestroyExtraEvent);
			animationEventListener.RegisterEvent("SpawnRoomItem", SpawnRoomItemEvent);
			animationEventListener.RegisterEvent("SpawnRandomItem", SpawnRandomItemEvent);
			animationEventListener.RegisterEvent("SetModularMask", SetModularMask);
			animationEventListener.RegisterEvent("SetSkinOverride", SetSkinOverride);
			animationEventListener.RegisterEvent("ClearModularMask", ClearModularMask);
			animationEventListener.RegisterEvent("EnableXrayVisualMode", EnableXrayVisualMode);
			animationEventListener.RegisterEvent("DisableXrayVisualMode", DisableXrayVisualMode);
			animationEventListener.RegisterEvent("DisableGreyAnatomyVisualMode", DisableGreyAnatomyVisualMode);
			animationEventListener.RegisterEvent("DestroyInteractionObject", DestroyInteractionObject);
			animationEventListener.RegisterEvent("FadeMesh", FadeMeshEvent);
			animationEventListener.RegisterEvent("StopFadeMesh", StopFadeMeshEvent);
			animationEventListener.RegisterEvent("TriggerCharacterAction", TriggerCharacterAction);
			animationEventListener.RegisterEvent("AttachActor", AttachActorEvent);
			animationEventListener.RegisterEvent("DetachActor", DetachActorEvent);
			animationEventListener.RegisterEvent("AddStatusEffect", AddStatusEffect);
			animationEventListener.RegisterEvent("RemoveStatusEffect", RemoveStatusEffect);
			animationEventListener.RegisterEvent("PlayParticleEffects", PlayParticleEffects);
			animationEventListener.RegisterEvent("StopParticleEffects", StopParticleEffects);
			animationEventListener.RegisterEvent("ClearCostume", ClearCostume);
			animationEventListener.RegisterEvent("RestoreCostume", RestoreCostume);
		}

		public override void Destroy()
		{
			DestroyAllExtras();
			AnimationEventListener animationEventListener = _character.AnimationEventListener;
			if (animationEventListener != null)
			{
				animationEventListener.UnregisterEvent("SpawnExtra", SpawnExtraEvent);
				animationEventListener.UnregisterEvent("DestroyExtra", DestroyExtraEvent);
				animationEventListener.UnregisterEvent("SpawnRoomItem", SpawnRoomItemEvent);
				animationEventListener.UnregisterEvent("SpawnRandomItem", SpawnRandomItemEvent);
				animationEventListener.UnregisterEvent("SetModularMask", SetModularMask);
				animationEventListener.UnregisterEvent("SetSkinOverride", SetSkinOverride);
				animationEventListener.UnregisterEvent("ClearModularMask", ClearModularMask);
				animationEventListener.UnregisterEvent("EnableXrayVisualMode", EnableXrayVisualMode);
				animationEventListener.UnregisterEvent("DisableXrayVisualMode", DisableXrayVisualMode);
				animationEventListener.UnregisterEvent("DisableGreyAnatomyVisualMode", DisableGreyAnatomyVisualMode);
				animationEventListener.UnregisterEvent("DestroyInteractionObject", DestroyInteractionObject);
				animationEventListener.UnregisterEvent("FadeMesh", FadeMeshEvent);
				animationEventListener.UnregisterEvent("StopFadeMesh", StopFadeMeshEvent);
				animationEventListener.UnregisterEvent("TriggerCharacterAction", TriggerCharacterAction);
				animationEventListener.UnregisterEvent("AttachActor", AttachActorEvent);
				animationEventListener.UnregisterEvent("DetachActor", DetachActorEvent);
				animationEventListener.UnregisterEvent("AddStatusEffect", AddStatusEffect);
				animationEventListener.UnregisterEvent("RemoveStatusEffect", RemoveStatusEffect);
				animationEventListener.UnregisterEvent("PlayParticleEffects", PlayParticleEffects);
				animationEventListener.UnregisterEvent("StopParticleEffects", StopParticleEffects);
				animationEventListener.UnregisterEvent("ClearCostume", ClearCostume);
				animationEventListener.UnregisterEvent("RestoreCostume", RestoreCostume);
			}
			else
			{
				Logging.Warning("RB: Trying to delete CharacterAnimationEvents, but the AnimationEventListener was null.  Not sure how this happened.  Defensive fix for M4779!");
			}
			base.Destroy();
		}

		private void DestroyAllExtras()
		{
			_extraGameObjects.ClearAndDestroy();
			_extras.Clear();
		}

		public void OnAnimGraphChanged()
		{
			DestroyAllExtras();
		}

		private void SpawnExtraEvent(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_AdditionalActorDefinition sharedInstance_TH20TH20_AdditionalActorDefinition = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_AdditionalActorDefinition;
			if (sharedInstance_TH20TH20_AdditionalActorDefinition != null && sharedInstance_TH20TH20_AdditionalActorDefinition.Instance != null && !_extras.Contains(sharedInstance_TH20TH20_AdditionalActorDefinition.Instance))
			{
				SpawnExtraInternal(sharedInstance_TH20TH20_AdditionalActorDefinition.Instance);
			}
		}

		private void SpawnExtraInternal(AdditionalActorDefinition extraDef)
		{
			GameObject gameObject = extraDef.SpawnActor(_character.GameObject.transform);
			_extraGameObjects.Add(gameObject);
			_extras.AddUnique(extraDef);
			Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
			if (componentInChildren != null)
			{
				componentInChildren.Play(0, 0, _character.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
			}
		}

		private void DestroyExtraEvent(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_AdditionalActorDefinition sharedInstance_TH20TH20_AdditionalActorDefinition = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_AdditionalActorDefinition;
			if (sharedInstance_TH20TH20_AdditionalActorDefinition == null)
			{
				DestroyAllExtras();
			}
			else if (_extras.Contains(sharedInstance_TH20TH20_AdditionalActorDefinition.Instance))
			{
				GameObject gameObject = _extraGameObjects[_extras.IndexOf(sharedInstance_TH20TH20_AdditionalActorDefinition.Instance)];
				Object.Destroy(gameObject);
				_extraGameObjects.Remove(gameObject);
				_extras.Remove(sharedInstance_TH20TH20_AdditionalActorDefinition.Instance);
			}
		}

		private void SpawnRoomItemEvent(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_RoomItemDefinition sharedInstance_TH20TH20_RoomItemDefinition = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_RoomItemDefinition;
			if (sharedInstance_TH20TH20_RoomItemDefinition != null && sharedInstance_TH20TH20_RoomItemDefinition.Instance != null)
			{
				RoomItemAlgorithms.SpawnItem(sharedInstance_TH20TH20_RoomItemDefinition.Instance, _character.Position, 0f, _character.RotationY, _level, _character.RoomUsing);
			}
		}

		private void SpawnRandomItemEvent(AnimationEvent animationEvent)
		{
			RoomItemDefinitionList instance = (animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_RoomItemDefinitionList).Instance;
			if (instance != null && instance._list != null && _character.RoomUsing != null)
			{
				RoomItemAlgorithms.SpawnItem(instance._list.RandomItem().Instance, rotation: _character.RotationY + (float)Random.Range(-animationEvent.intParameter, animationEvent.intParameter), position: _character.Position, randomOffset: 0.25f, level: _level, room: _character.RoomUsing);
			}
		}

		private void SetModularMask(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_CharModule_Mask sharedInstance_TH20TH20_CharModule_Mask = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_CharModule_Mask;
			if (sharedInstance_TH20TH20_CharModule_Mask != null)
			{
				_character.Visual.SetModularMask(sharedInstance_TH20TH20_CharModule_Mask.Instance);
			}
		}

		private void SetSkinOverride(AnimationEvent animationEvent)
		{
			ModularSkinMaterialSelection skinSelectionOverride = (ModularSkinMaterialSelection)animationEvent.objectReferenceParameter;
			_character.Visual.SetSkinSelectionOverride(skinSelectionOverride);
		}

		private void ClearModularMask(AnimationEvent animationEvent)
		{
			_character.Visual.SetModularMask(null);
		}

		private void ClearCostume(AnimationEvent animationEvent)
		{
			_character.Visual.SetCustomisationOptionOnHold(_character);
		}

		private void RestoreCostume(AnimationEvent animationEvent)
		{
			_character.Visual.RestoreCustomisationOptionOnHold(_character);
		}

		private void EnableXrayVisualMode(AnimationEvent animationEvent)
		{
			_character.Visual.XRayModeEnabled = true;
		}

		private void DisableXrayVisualMode(AnimationEvent animationEvent)
		{
			_character.Visual.XRayModeEnabled = false;
		}

		private void DisableGreyAnatomyVisualMode(AnimationEvent animationEvent)
		{
			_character.Visual.GreyAnatomyModeEnabled = false;
		}

		private void DestroyInteractionObject(AnimationEvent animationEvent)
		{
			if (_character.Interaction == null)
			{
				return;
			}
			RoomItem parentRoomItem = _character.Interaction.ParentRoomItem;
			if (parentRoomItem != null && !parentRoomItem.HasBeenDestroyed())
			{
				if (animationEvent.floatParameter > 0f)
				{
					parentRoomItem.AddComponent<RoomItemShrinkComponent>().SetDuration(animationEvent.floatParameter);
				}
				else if (parentRoomItem.Visual != null)
				{
					parentRoomItem.Visual.SetActive(active: false);
				}
			}
			_character.Interaction.DestroyOnFinish = true;
		}

		private void FadeMeshEvent(AnimationEvent animationEvent)
		{
			_character.GetOrAddComponent<FadeCharacterComponent>().FadeTo((float)animationEvent.intParameter / 255f, animationEvent.floatParameter);
		}

		private void StopFadeMeshEvent(AnimationEvent animationEvent)
		{
			_character.GetComponent<FadeCharacterComponent>()?.Destroy();
		}

		private void TriggerCharacterAction(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_CharacterActionDefinition sharedInstance_TH20TH20_CharacterActionDefinition = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_CharacterActionDefinition;
			if (sharedInstance_TH20TH20_CharacterActionDefinition != null)
			{
				_level.CharacterEvents.TriggerGlobalCharacterAction(_character, _character.RoomUsing, _character.Position, sharedInstance_TH20TH20_CharacterActionDefinition.Instance);
			}
		}

		private void AttachActorEvent(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_AdditionalActorDefinition sharedInstance_TH20TH20_AdditionalActorDefinition = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_AdditionalActorDefinition;
			if (sharedInstance_TH20TH20_AdditionalActorDefinition != null)
			{
				_character.GetOrAddComponent<AttachActorToCharacterComponent>().Attach(sharedInstance_TH20TH20_AdditionalActorDefinition.Instance);
			}
		}

		private void DetachActorEvent(AnimationEvent animationEvent)
		{
			_character.RemoveComponents<AttachActorToCharacterComponent>();
		}

		private void AddStatusEffect(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_CharacterStatusEffectDefinition sharedInstance_TH20TH20_CharacterStatusEffectDefinition = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_CharacterStatusEffectDefinition;
			if (sharedInstance_TH20TH20_CharacterStatusEffectDefinition != null && _character.ModifiersComponent != null)
			{
				_character.ModifiersComponent.AddStatusEffect(sharedInstance_TH20TH20_CharacterStatusEffectDefinition.Instance);
			}
		}

		private void RemoveStatusEffect(AnimationEvent animationEvent)
		{
			SharedInstance_TH20TH20_CharacterStatusEffectDefinition sharedInstance_TH20TH20_CharacterStatusEffectDefinition = animationEvent.objectReferenceParameter as SharedInstance_TH20TH20_CharacterStatusEffectDefinition;
			if (sharedInstance_TH20TH20_CharacterStatusEffectDefinition != null && _character.ModifiersComponent != null)
			{
				_character.ModifiersComponent.RemoveStatusEffect(sharedInstance_TH20TH20_CharacterStatusEffectDefinition.Instance);
			}
		}

		private void PlayParticleEffects(AnimationEvent animationEvent)
		{
			EnableParticleEffects(enable: true, animationEvent.intParameter);
		}

		private void StopParticleEffects(AnimationEvent animationEvent)
		{
			EnableParticleEffects(enable: false, animationEvent.intParameter);
		}

		private void EnableParticleEffects(bool enable, int effectIndex)
		{
			if (_character.Interaction == null)
			{
				return;
			}
			RoomItem parentRoomItem = _character.Interaction.ParentRoomItem;
			if (parentRoomItem != null && !parentRoomItem.HasBeenDestroyed() && parentRoomItem.Visual != null)
			{
				ParticleEffectControlComponent component = parentRoomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
				if (component != null)
				{
					component.EnableEffect(effectIndex, enable);
				}
			}
		}
	}
}
