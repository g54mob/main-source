using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class AnimationEventObserver : BasicAnimationEventObserver
	{
		private IBasicAnimEventSupport _baes;

		private GameObjectX _gox;

		private bool _suppressBlinking;

		public event EventHandler ParticleAnim
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<AnimationEventArgs> SetBoolOnTargetEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<AnimationEventArgs> SetBoolOnSpawnedItemsEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<SpawnConvItemEventArgs> SpawnConvItemEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<SpawnItemEventArgs> SpawnItemEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<AnimationEventArgs> SetBoolOnItemsEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void InitGOX()
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public override void Enable(string transformName)
		{
		}

		public override void Disable(string transformName)
		{
		}

		public void EnableRandom(string values)
		{
		}

		public void EnableOnTarget(string transformName)
		{
		}

		public void EnableOnItems(string transformName)
		{
		}

		public void EnableFinalModelOnItems()
		{
		}

		public void DisableFinalModelOnItems()
		{
		}

		public void DisableOnItems(string transformName)
		{
		}

		public void ExplodeItem()
		{
		}

		public void ItemDropped()
		{
		}

		public void EnableOnTargetItems(string transformName)
		{
		}

		public void DisableOnTargetItems(string transformName)
		{
		}

		public void EnableRandomOnSpawnedItems(string values)
		{
		}

		public void EnableOnSpawnedItems(string transformName)
		{
		}

		public void DisableOnSpawnedItems(string transformName)
		{
		}

		public void Spark(string transformName)
		{
		}

		public void DisableOnTarget(string transformName)
		{
		}

		protected virtual void OnParticleAnimEvent(EventArgs e)
		{
		}

		public void ParticleAnimEvent()
		{
		}

		public override void FireAnimEvent(string name)
		{
		}

		public void Random(string value)
		{
		}

		public new void SetRandomTrigger(string value)
		{
		}

		public void SetTriggerOnPropWithChance(string value)
		{
		}

		public void UpdateInnerTableStateOnBoardGameTable()
		{
		}

		protected virtual void OnSetBoolOnTargetEvent(AnimationEventArgs e)
		{
		}

		public void SetBoolOnTarget(string name)
		{
		}

		public override void SetBool(string param)
		{
		}

		protected virtual void OnSetBoolOnSpawnedItemsEvent(AnimationEventArgs e)
		{
		}

		public void SetBoolOnSpawnedItems(string name)
		{
		}

		public void EmitParticleSystem(string name)
		{
		}

		public void SpawnConvItem(AnimationEvent value)
		{
		}

		public void SpawnConvItemOnAP(AnimationEvent value)
		{
		}

		public void RemoveConvItem(AnimationEvent value)
		{
		}

		protected virtual void OnSpawnItemEvent(SpawnItemEventArgs e)
		{
		}

		public void SpawnItem(AnimationEvent value)
		{
		}

		public void SpawnItemOnAP(AnimationEvent value)
		{
		}

		private void SpawnItemInternal(AnimationEvent value, bool onAP = false)
		{
		}

		public void RemoveItem(AnimationEvent value)
		{
		}

		public void SwitchParentTransformForSpawnedItem(AnimationEvent value)
		{
		}

		public void Carry(string prefabTypeIdentifier)
		{
		}

		public void StopCarry(string prefabTypeIdentifier)
		{
		}

		public override void PlaySoundEvent(string eventName)
		{
		}

		public void PlayCharacterSoundEvent(string eventName)
		{
		}

		public void PlayCharacterEmote(string phonetic)
		{
		}

		public void StartAreaEffect(string effectName)
		{
		}

		public void StopAreaEffect(string effectName)
		{
		}

		public void EnableTemperature(string enable)
		{
		}

		public void SpawnOutput(string bone)
		{
		}

		public void RemoveInput()
		{
		}

		public void SnapSpawnedItems(string bone)
		{
		}

		public void MoveSpawnedItems(string bone)
		{
		}

		private void MoveSpawnedItems(string bone, bool snap)
		{
		}

		public void SnapItems(string bone)
		{
		}

		public void MoveItems(string bone)
		{
		}

		private void MoveItems(string bone, bool snap)
		{
		}

		protected virtual void OnSetBoolOnItemsEvent(AnimationEventArgs e)
		{
		}

		public void SetBoolOnItems(string parameter)
		{
		}

		public void SnapToTarget(string parameter)
		{
		}

		public void SnapTo(string parameter)
		{
		}

		private void SnapTo(GameObjectX gox, string parameter, Transform startTransform, Inventory sourceInventory)
		{
		}

		public void AttachItemToBone(string bone)
		{
		}

		public void AttachItemToPropBone()
		{
		}

		public void RemoveItemFromPropBone()
		{
		}

		public void SetBlinkType(string blinkType)
		{
		}

		public void IncrementGameStat(string gameStat)
		{
		}

		public void HandleIngredientVisualsOnTarget()
		{
		}

		public void SelfDestroy()
		{
		}
	}
}
