using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class BackgroundPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndHideFader_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BackgroundPage _003C_003E4__this;

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
			public _003CWaitAndHideFader_003Ed__30(int _003C_003E1__state)
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
		private PixelateEffect _pixelateEffect;

		[SerializeField]
		private TextMeshProUGUI _VersionText;

		[SerializeField]
		private Image _Villain;

		[SerializeField]
		private Image _Antonio;

		[SerializeField]
		private Image _Imelda;

		[SerializeField]
		private Image _Fader;

		[SerializeField]
		private Image _AdventureSubtitleImage;

		public Animator _Animator;

		private Material _pixelizer;

		private Slider _slider;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		private LobbiesManager _lobbiesManager;

		private static bool _hasPlayedSong;

		private bool _doTrumpetGag;

		private bool _doMirrorGag;

		private static readonly int CellSizeX;

		private static readonly int CellSizeY;

		private static readonly int PixelSize;

		private static readonly int TexSize;

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions playerOptions, AdventureManager adventureManager, LobbiesManager lobbiesManager)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void CompleteIntroAnimation()
		{
		}

		public void ProceedToNextPage()
		{
		}

		public void PlayIntroSound()
		{
		}

		public static void AllowJinglePlayback()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndHideFader_003Ed__30))]
		private IEnumerator WaitAndHideFader()
		{
			return null;
		}

		private void OnAdventureStarted(AdventureType adventureType)
		{
		}

		private void OnAdventureExit()
		{
		}

		private void SetupAdventureSubtitleImage()
		{
		}
	}
}
