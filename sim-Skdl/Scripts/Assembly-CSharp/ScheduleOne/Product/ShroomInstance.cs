using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.AvatarFramework;
using ScheduleOne.FX;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Product
{
	[Serializable]
	public class ShroomInstance : ProductItemInstance
	{
		[CompilerGenerated]
		private sealed class _003CDoPsychedlicEffectBlend_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float targetValuePercentage;

			public float duration;

			public PsychedelicFullScreenFeature.MaterialProperties targetMaterialProperties;

			private float _003Celapsed_003E5__2;

			private PsychedelicFullScreenFeature.MaterialProperties _003CactiveProperties_003E5__3;

			private PsychedelicFullScreenFeature.MaterialProperties _003CsourceProperties_003E5__4;

			private float _003CstartValue_003E5__5;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoPsychedlicEffectBlend_003Ed__14(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private static Coroutine _psychedelicEffectCoroutine;

		public override string Name => null;

		private ShroomDefinition _shroomDefinition => null;

		public ShroomInstance(ItemDefinition definition, int quantity, EQuality quality, PackagingDefinition packaging = null)
			: base(null, 0, default(EQuality))
		{
		}

		public override ItemInstance GetCopy(int overrideQuantity = -1)
		{
			return null;
		}

		public override ItemData GetItemData()
		{
			return null;
		}

		public override void ApplyEffectsToNPC(NPC npc)
		{
		}

		public override void ClearEffectsFromNPC(NPC npc)
		{
		}

		public override void ApplyEffectsToPlayer(Player player)
		{
		}

		public override void ClearEffectsFromPlayer(Player player)
		{
		}

		private void ApplyEffectsToAvatar(ScheduleOne.AvatarFramework.Avatar avatar)
		{
		}

		private void ClearEffectsFromAvatar(ScheduleOne.AvatarFramework.Avatar avatar)
		{
		}

		[IteratorStateMachine(typeof(_003CDoPsychedlicEffectBlend_003Ed__14))]
		private IEnumerator DoPsychedlicEffectBlend(PsychedelicFullScreenFeature.MaterialProperties targetMaterialProperties, float targetValuePercentage, float duration)
		{
			return null;
		}
	}
}
