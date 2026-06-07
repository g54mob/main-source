using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using Zenject;

namespace VampireSurvivors.App.Framework.Adventures
{
	public class AdventureMeltManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public AdventureMeltManager _003C_003E4__this;

			public Texture2D renderedTexture;

			public RenderTexture screenTexture;

			internal void _003CPerformMeltEffect_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CPerformMeltEffect_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AdventureMeltManager _003C_003E4__this;

			private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

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
			public _003CPerformMeltEffect_003Ed__15(int _003C_003E1__state)
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
		private CanvasGroup _CanvasGroup;

		[SerializeField]
		private RawImage _FullScreenImage;

		[SerializeField]
		private MainMenuBackgroundManager _MainMenuBackgroundManager;

		[SerializeField]
		private Camera _UICamera;

		[SerializeField]
		private float _MeltDelay;

		[SerializeField]
		private float _MeltDuration;

		[SerializeField]
		private Ease _MeltEase;

		private AdventureManager _adventureManager;

		private bool _isRunning;

		private static readonly int MeltProgressId;

		[Inject]
		private void Construct(AdventureManager adventureManager)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnAdventureExit()
		{
		}

		[IteratorStateMachine(typeof(_003CPerformMeltEffect_003Ed__15))]
		private IEnumerator PerformMeltEffect()
		{
			return null;
		}
	}
}
