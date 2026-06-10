using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NaughtyAttributes;
using Rewired;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public delegate void InputModeChange();

	[Serializable]
	public class ControllerVibration
	{
		public int motorIndex;

		public float fullMotorSpeed;

		public bool matchSoundDuration;

		[DisableIf("matchSoundDuration")]
		public float duration;
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CStartQuickSaveAsync_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[Header("Setup")]
	public bool enableInput;

	[NonSerialized]
	public Rewired.Player player;

	public AnimationCurve nearestLookAtCurve;

	[Header("Menu")]
	public ControllerType lastActiveController;

	public bool mouseInputMode;

	private bool initalInputModeSet;

	public bool cursorVisible;

	private ButtonController currentButtonDown;

	private float controlFallbackCheck;

	private bool controllerStickNavigateReset;

	private static InputController _instance;

	public static InputController Instance => null;

	public event InputModeChange OnInputModeChange
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	[AsyncStateMachine(typeof(_003CStartQuickSaveAsync_003Ed__22))]
	public void StartQuickSaveAsync()
	{
	}

	public void ResetCurrentButtonDown()
	{
	}

	public float GetAxisRelative(string actionId)
	{
		return 0f;
	}

	public void SetMouseInputMode(bool val, bool forceUpdate = false)
	{
	}

	public void SetCursorVisible(bool val)
	{
	}

	public void RefreshControllers()
	{
	}

	public void SetCursorLock(bool value)
	{
	}

	public void ExecuteControllerVibration(ref List<ControllerVibration> vibrationConfig, float soundDuration)
	{
	}
}
