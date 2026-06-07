using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Solo.MOST_IN_ONE
{
	public static class Most_HapticFeedback
	{
		[Serializable]
		[Tooltip("Each element = one pulse")]
		public struct CustomHapticPattern
		{
			[Tooltip("IOS Pulse data")]
			public IOS_Haptic[] IOS_HapticPattern;

			[Tooltip("Android Pulse data")]
			public Android_Haptic[] Android_HapticPattern;

			public CustomHapticPattern(IOS_Haptic[] iosHaptic, Android_Haptic[] androidHaptic)
			{
				IOS_HapticPattern = null;
				Android_HapticPattern = null;
			}
		}

		[Serializable]
		public struct IOS_Haptic
		{
			[Tooltip("Delay before starting this pulse in milliseconds")]
			public float Delay;

			[Tooltip("Haptic type of this pulse")]
			public HapticTypes PulseType;

			public IOS_Haptic(HapticTypes type, float delay)
			{
				Delay = 0f;
				PulseType = default(HapticTypes);
			}
		}

		[Serializable]
		public struct Android_Haptic
		{
			[Tooltip("Delay before starting this pulse in milliseconds")]
			public long Delay;

			[Tooltip("Pulse time in milliseconds")]
			public long PulseTime;

			[Tooltip("vibration Strength of the pulse\ninteger (0-255)")]
			public int PulseStrength;

			public Android_Haptic(long delay, long pattern, int amplitudes)
			{
				Delay = 0L;
				PulseTime = 0L;
				PulseStrength = 0;
			}
		}

		public enum HapticTypes
		{
			Selection = 0,
			Success = 1,
			Warning = 2,
			Failure = 3,
			LightImpact = 4,
			MediumImpact = 5,
			HeavyImpact = 6,
			RigidImpact = 7,
			SoftImpact = 8
		}

		[CompilerGenerated]
		private sealed class _003CGeneratePattern_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CGeneratePattern_003Ed__13(int _003C_003E1__state)
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

		private static bool _hapticsEnabled;

		private static bool _initialized;

		private static AndroidJavaObject _androidVibrator;

		private static AndroidJavaClass _vibrationEffectClass;

		private static int _androidApiLevel;

		private static float _lastHapticTime;

		private static float _hapticCooldown;

		public static bool HapticsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
		}

		public static void GenerateWithCooldown(HapticTypes type, float cooldown = -1f)
		{
		}

		[IteratorStateMachine(typeof(_003CGeneratePattern_003Ed__13))]
		public static IEnumerator GeneratePattern(CustomHapticPattern hapticPattern)
		{
			return null;
		}

		public static void Generate(HapticTypes type)
		{
		}

		public static bool IsSupported()
		{
			return false;
		}
	}
}
