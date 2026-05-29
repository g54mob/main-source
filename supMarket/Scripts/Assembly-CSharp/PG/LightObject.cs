using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class LightObject : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSoftSwitch_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool value;

			public LightObject _003C_003E4__this;

			public bool forceSwitch;

			private Color _003CtargetColor_003E5__2;

			private Color _003CstartColor_003E5__3;

			private float _003Cspeed_003E5__4;

			private float _003Ctimer_003E5__5;

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
			public _003CSoftSwitch_003Ed__25(int _003C_003E1__state)
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

		public int GlassMaterialIndex;

		public CarLightType CarLightType;

		public Light LightGO;

		public Material OnLightMaterial;

		[Header("Soft Switch settings")]
		public bool IsSoftSwitch;

		public float OnSwitchSpeed;

		public float OffSwitchSpeed;

		public float Intensity;

		[Header("Main settings")]
		public bool EnableOnStart;

		private MaterialPropertyBlock MaterialBlock;

		private Material MaterialForSoftSwitch;

		private Material MaterialForHardSwitch;

		private Animator LightsAnimator;

		private int EmissionColorPropertyID;

		private int AnimatorLightIsOnID;

		private Coroutine SoftSwitchCoroutine;

		private Renderer Renderer;

		private Material[] Materials;

		public bool LightIsOn { get; private set; }

		private void Start()
		{
		}

		public void Switch()
		{
		}

		public void Switch(bool value, bool forceSwitch = false)
		{
		}

		[IteratorStateMachine(typeof(_003CSoftSwitch_003Ed__25))]
		private IEnumerator SoftSwitch(bool value, bool forceSwitch = false)
		{
			return null;
		}

		private void HardSwitch()
		{
		}
	}
}
