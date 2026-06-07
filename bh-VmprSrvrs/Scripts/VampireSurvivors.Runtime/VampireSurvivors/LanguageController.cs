using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors
{
	public class LanguageController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFixLayout_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LanguageController _003C_003E4__this;

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
			public _003CFixLayout_003Ed__10(int _003C_003E1__state)
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
		private GameObject LanguageButtonPrefab;

		[SerializeField]
		private RectTransform Container;

		private List<GameObject> spawned;

		private SignalBus signalBus;

		private PlayerOptions _playerOptions;

		[Inject]
		private void Construct(SignalBus _signal, PlayerOptions playerOptions)
		{
		}

		private void Start()
		{
		}

		public void Set()
		{
		}

		public static string GetCurrentLanguageName()
		{
			return null;
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CFixLayout_003Ed__10))]
		private IEnumerator FixLayout()
		{
			return null;
		}

		private void OnDisable()
		{
		}

		public void ApplyLanguage(string code)
		{
		}

		public GameObject GetFirstObject()
		{
			return null;
		}
	}
}
