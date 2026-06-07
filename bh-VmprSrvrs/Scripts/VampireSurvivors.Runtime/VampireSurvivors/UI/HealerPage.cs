using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class HealerPage : GameWindowedUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndTween_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HealerPage _003C_003E4__this;

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
			public _003CWaitAndTween_003Ed__22(int _003C_003E1__state)
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

		[SerializeField]
		private GameObject _EggPrefab;

		[SerializeField]
		private RectTransform _EggContainer;

		[SerializeField]
		private GameObject _ItemPrefab;

		[SerializeField]
		private TextMeshProUGUI _EggCountText;

		[SerializeField]
		private RectTransform _EggPanel;

		[SerializeField]
		private UISpriteAnimation _BurstVFX;

		[SerializeField]
		private VerticalLayoutGroup _Grid;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private EggManager _egg;

		private BgmType _currentTrack;

		private BgmModType _currentMod;

		private List<Image> _spawnedEggs;

		private int _spriteIndex;

		private ParticleSystem _happyPfx1;

		private ParticleSystem _happyPfx2;

		private bool _happyParticlesCreated;

		[Inject]
		private void Constructor(DataManager data, PlayerOptions player, EggManager egg)
		{
		}

		public override void Purchase(ItemType t, ItemData d, ShopItemUI item, float price, RectTransform sender)
		{
		}

		public void Back()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void IntroAnimation()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndTween_003Ed__22))]
		private IEnumerator WaitAndTween()
		{
			return null;
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		private void UnsetMusic()
		{
		}

		private void SetMusic()
		{
		}

		private void CreateHappyParticles()
		{
		}

		private void Populate()
		{
		}

		private void SpawnItem(ItemType t, int index)
		{
		}

		private void SpawnEggs()
		{
		}

		private void ShuffleText()
		{
		}

		private void RemoveEggs(int value, Vector2 pos)
		{
		}

		private void PlayRemovalAnimation(Vector2 pos)
		{
		}

		private void UpdateEggsTotal()
		{
		}
	}
}
