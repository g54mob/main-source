using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_RumbleDecay_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public float initialStrength;

		public Joystick j;

		public float decay;

		private float _003CcurrentStrength_003E5__2;

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
		public _003CCR_RumbleDecay_003Ed__31(int _003C_003E1__state)
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

	public static InputController instance;

	private static Player player;

	private static eControlScheme currentControlScheme;

	private Stack<eControlScheme> controlSchemeStack;

	private bool isLastUpdateUsingKeyboard;

	private bool isInitialized;

	private int defaultCameraEventMask;

	private Coroutine coroutine_RumbleDecay;

	public static Player Player => null;

	public static bool IsUsingKeyboard => false;

	public static bool IsUsingJoystick => false;

	private void Awake()
	{
	}

	public void Initialize()
	{
	}

	private void SwitchInputMode(ControllerType targetType)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnControllerAdded(ControllerAssignmentChangedEventArgs args)
	{
	}

	public static void ClearAllAndForceControlScheme(eControlScheme targetMap)
	{
	}

	public static void SwitchToControlScheme(eControlScheme targetMap)
	{
	}

	public static void EndControlScheme(eControlScheme targetMap)
	{
	}

	private static void SwitchControlScheme(eControlScheme targetMap)
	{
	}

	public static eControlScheme GetCurrentControlScheme()
	{
		return default(eControlScheme);
	}

	public static bool IsCurrentControlScheme(eControlScheme scheme)
	{
		return false;
	}

	public ControllerType GetCurrentControlType()
	{
		return default(ControllerType);
	}

	private bool GetIsUsingKeyboard()
	{
		return false;
	}

	private bool GetIsUsingJoystick()
	{
		return false;
	}

	public static void PlayRumbleForPlayer(int playerId, float strength, float durationSeconds)
	{
	}

	public void PlayRumbleForPlayerWithDecay(int playerId, float strength, float decay, float delay = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RumbleDecay_003Ed__31))]
	private IEnumerator CR_RumbleDecay(Joystick j, float initialStrength, float decay, float delay)
	{
		return null;
	}

	public static float GetAxis(eInputAction action)
	{
		return 0f;
	}

	public static bool GetButtonDown(eInputAction action)
	{
		return false;
	}

	public static bool GetNegativeButtonDown(eInputAction action)
	{
		return false;
	}

	public static bool GetButtonHold(eInputAction action)
	{
		return false;
	}

	public static bool GetNegativeButtonHold(eInputAction action)
	{
		return false;
	}

	public static bool GetButtonUp(eInputAction action)
	{
		return false;
	}

	public static bool GetNegativeButtonUp(eInputAction action)
	{
		return false;
	}

	public static bool IsAnyJoystickButtonDown()
	{
		return false;
	}

	public static bool IsAnyJoystickButtonHold()
	{
		return false;
	}

	public static string GetTmpTextForActionAllRanges(eInputAction action, int playerId = 0, string separator = " / ")
	{
		return null;
	}

	private static string BuildTag(int playerId, eInputAction action, string range, int index)
	{
		return null;
	}

	public static string GetTmpTextForAction(eInputAction action, int actionIndex = 0, bool isPositive = true, bool showAllBindings = false, string separator = " / ", int playerId = 0)
	{
		return null;
	}

	private static string BuildTag(eInputAction action, int index, string range, int playerId)
	{
		return null;
	}

	private static int GetBindingCount(int playerId, eInputAction action, bool isPositive)
	{
		return 0;
	}

	private static bool IsMatchRange(Pole contribution, bool wantPositive)
	{
		return false;
	}

	public static Sprite GetGlyphForAction(eInputAction action)
	{
		return null;
	}

	public static string GetDebugInformation()
	{
		return null;
	}

	public static string GetCurrentControlSchemeMapsInfo()
	{
		return null;
	}

	public static string GetControlSchemeStackInfo()
	{
		return null;
	}
}
