using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace EpicToonFX
{
	public class ETFXEffectControllerPooled : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CEffectLoop_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ETFXEffectControllerPooled _003C_003E4__this;

			private ParticleSystem _003CparticleSystem_003E5__2;

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
			public _003CEffectLoop_003Ed__22(int _003C_003E1__state)
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

		public GameObject[] effects;

		private List<GameObject> effectsPool;

		private int effectIndex;

		[Space(10f)]
		[Header("Spawn Settings")]
		public bool disableLights;

		public bool disableSound;

		public float startDelay;

		public float respawnDelay;

		public bool slideshowMode;

		public bool autoRotation;

		[Range(0.001f, 0.5f)]
		public float autoRotationSpeed;

		private GameObject currentEffect;

		private Text effectNameText;

		private Text effectIndexText;

		private ETFXMouseOrbit etfxMouseOrbit;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		public void InitializeLoop()
		{
		}

		public void NextEffect()
		{
		}

		public void PreviousEffect()
		{
		}

		private void CleanCurrentEffect()
		{
		}

		[IteratorStateMachine(typeof(_003CEffectLoop_003Ed__22))]
		private IEnumerator EffectLoop()
		{
			return null;
		}
	}
}
