using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.UI.HUD
{
	public class ObjectiveUi : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateObjective_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ObjectiveUi _003C_003E4__this;

			public LocalizedString objective;

			public bool canComplete;

			public EObjective eObjective;

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
			public _003CAnimateObjective_003Ed__20(int _003C_003E1__state)
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

		public GameObject objectivePrefab;

		private ObjectivePrefabUi currentObjective;

		public AudioSource a_new;

		public AudioSource a_complete;

		public LocalizedString findBoss;

		public LocalizedString defeatBoss;

		public LocalizedString defeatBossFinal;

		public LocalizedString survive;

		public LocalizedString enterPortal;

		public LocalizedString graveyardCryptEscape;

		public LocalizedString graveyardCryptKeys;

		public LocalizedString graveyardFindCrypt;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void FirstObjective()
		{
		}

		public void GraveyardKeys()
		{
		}

		private void FinalBossObjective()
		{
		}

		public void AddObjective(LocalizedString localizedString, bool canComplete, EObjective eObjective = EObjective.Generic)
		{
		}

		public void CompleteCurrentObjective()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateObjective_003Ed__20))]
		private IEnumerator AnimateObjective(LocalizedString objective, bool canComplete, EObjective eObjective)
		{
			return null;
		}

		public void OnBossSpawned()
		{
		}

		private void OnBossDefeated(bool isOpeningPortal)
		{
		}

		private void OnStageBossDied()
		{
		}

		private void OnItemAdded(EItem eItem)
		{
		}
	}
}
