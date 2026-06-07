using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI
{
	public class ArcanaCardUI : SelectableUI
	{
		[CompilerGenerated]
		private sealed class _003CWait_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float d;

			public ArcanaCardUI _003C_003E4__this;

			public int times;

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
			public _003CWait_003Ed__62(int _003C_003E1__state)
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

		public bool _IsOpen;

		public Action<SelectableUI, ArcanaData, ArcanaType, Transform> OnArcanaCardSelected;

		public Action<ArcanaType> OnArcanaCardDeselected;

		[SerializeField]
		private bool DEBUGTHIS;

		[SerializeField]
		private GameObject _Selected;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Image _Transitioner;

		[SerializeField]
		private Image _rarityIcon;

		[SerializeField]
		private Image _editionIcon;

		[SerializeField]
		private Material _foilMat;

		[SerializeField]
		private Material _holoMat;

		[SerializeField]
		private Material _polyMat;

		[SerializeField]
		private Material _inveMat;

		[SerializeField]
		private Material _galaMat;

		private ArcanaData _data;

		private ArcanaType _type;

		private ISetArcanaInfo _selectionPage;

		private IArcanaDisplayContainer _displayContainer;

		private float _halfTime;

		private bool _isFlipping;

		private Vector3 _scale;

		private Tween _flipTween;

		private Tween _backTween;

		private int _spinTimes;

		private Selectable _cachedSelectable;

		private Sprite _back;

		private bool _interactable;

		private Tween _tween;

		private string _overrideBackFrameName;

		private bool _ignoreDarkana;

		public Selectable Selectable => null;

		public CharacterSkillCard_Base CharacterCard { get; private set; }

		private bool ShowEditionIcon => false;

		private bool ShowRarityIcon => false;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnSelected()
		{
		}

		protected override void OnDeselected()
		{
		}

		public void SetData(ArcanaData data, ArcanaType type, ArcanaMainSelectionPage page)
		{
		}

		public void SetData(ArcanaData data, ArcanaType type, ISetArcanaInfo page, bool isShowing)
		{
		}

		public void SetArcanaDisplayContainer(IArcanaDisplayContainer container)
		{
		}

		private void ModeChanged(ArcanaMainSelectionPage.ArcanaMode m)
		{
		}

		public void SetOwned()
		{
		}

		public void SetData(ArcanaData data, ArcanaType t, bool isOpen = false, bool isInteractable = false)
		{
		}

		public void SetDarkBack()
		{
		}

		public void SetBackOnly()
		{
		}

		public void SetGreyBackOnly()
		{
		}

		public void OnClick()
		{
		}

		public void SetActiveSelection(bool b)
		{
		}

		public Tween Reveal(float delay = 0f)
		{
			return null;
		}

		private Tween GenerateFlipTween(float delay = 0f)
		{
			return null;
		}

		public void KillReveal()
		{
		}

		public void Hide()
		{
		}

		public Tween Spin(int spinTimes)
		{
			return null;
		}

		public void SpinDelay(float delay, int times)
		{
		}

		[IteratorStateMachine(typeof(_003CWait_003Ed__62))]
		private IEnumerator Wait(float d, int times)
		{
			return null;
		}

		public void ChangeSide()
		{
		}

		public void SetOpen()
		{
		}

		public void SetClosed()
		{
		}

		public ArcanaData GetData()
		{
			return null;
		}

		public ArcanaType GetArcanaType()
		{
			return default(ArcanaType);
		}

		public void OverrideBackFrameName(string frameName)
		{
		}

		public void SetIgnoreDarkana()
		{
		}

		public void SetCharacterCard(CharacterSkillCard_Base characterCard)
		{
		}
	}
}
