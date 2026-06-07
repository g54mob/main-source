using System;
using UnityEngine;

public class LocomotionInputWrapper : MonoBehaviour
{
	public enum LeanDirection
	{
		LeaningLeft = -1,
		NotLeaning = 0,
		LeaningRight = 1
	}

	public ACharacterControllerProvider provider;

	public bool inputEnabled = true;

	public Vector2 speed = Vector2.zero;

	private LeanDirection previousLeanValue;

	private bool initialized;

	public ILocomotionInputInterpreter LocomotionInputInterpreter { get; private set; }

	public bool RunRequested
	{
		get
		{
			if (inputEnabled && initialized)
			{
				return LocomotionInputInterpreter.RunRequested;
			}
			return false;
		}
	}

	public bool SwimRequested
	{
		get
		{
			if (inputEnabled && initialized)
			{
				return LocomotionInputInterpreter.SwimRequested;
			}
			return false;
		}
	}

	public bool JumpRequested
	{
		get
		{
			if (inputEnabled && initialized)
			{
				return LocomotionInputInterpreter.JumpRequested;
			}
			return false;
		}
	}

	public bool CrouchRequested
	{
		get
		{
			if (inputEnabled && initialized)
			{
				return LocomotionInputInterpreter.CrouchRequested;
			}
			return false;
		}
	}

	public bool SittingRequested
	{
		get
		{
			if (inputEnabled && initialized)
			{
				return LocomotionInputInterpreter.SittingRequested;
			}
			return false;
		}
	}

	public bool ClimbLadderRequested
	{
		get
		{
			if (inputEnabled && initialized)
			{
				return LocomotionInputInterpreter.ClimbLadderRequested;
			}
			return false;
		}
	}

	public event Action<LeanDirection> LeanDirectionChanged;

	private void Awake()
	{
		Initialize();
	}

	private void OnDestroy()
	{
		LocomotionInputInterpreter?.Dispose();
		if (!UnloadWatcher.isQuitting)
		{
			if (!provider.IsVR)
			{
				provider.LeanToggleChanged_Unregister(OnToggleLeanPreferenceUpdated);
			}
			provider.CrouchToggleChanged_Unregister(OnToggleCrouchPreferenceUpdated);
			provider.RunToggleChanged_Unregister(OnToggleRunPreferenceUpdated);
		}
	}

	private void Initialize()
	{
		if (!initialized)
		{
			LocomotionInputInterpreter = provider.GetLocomotionInputInterpreter();
			if (!provider.IsVR)
			{
				provider.LeanToggleChanged_Register(OnToggleLeanPreferenceUpdated);
				OnToggleLeanPreferenceUpdated();
			}
			provider.CrouchToggleChanged_Register(OnToggleCrouchPreferenceUpdated);
			OnToggleCrouchPreferenceUpdated();
			provider.RunToggleChanged_Register(OnToggleRunPreferenceUpdated);
			OnToggleRunPreferenceUpdated();
			initialized = true;
		}
	}

	private void OnToggleLeanPreferenceUpdated()
	{
		LocomotionInputInterpreter.SetLeanToggle(provider.LeanToggle);
	}

	private void OnToggleCrouchPreferenceUpdated()
	{
		LocomotionInputInterpreter.SetCrouchToggle(provider.CrouchToggle);
	}

	private void OnToggleRunPreferenceUpdated()
	{
		LocomotionInputInterpreter.SetRunToggle(provider.RunToggle);
	}

	public void ResetLean()
	{
		if (LocomotionInputInterpreter.LeanValue != LeanDirection.NotLeaning)
		{
			LocomotionInputInterpreter.ResetLean();
		}
	}

	private void Update()
	{
		if (inputEnabled && Time.timeScale > 0f && Time.deltaTime > 0f)
		{
			LocomotionInputInterpreter.UpdateFrame();
			LeanDirection leanValue = LocomotionInputInterpreter.LeanValue;
			if (leanValue != previousLeanValue)
			{
				this.LeanDirectionChanged?.Invoke(leanValue);
			}
			previousLeanValue = leanValue;
			speed = LocomotionInputInterpreter.LocomotionAxis;
		}
		else
		{
			speed = Vector2.zero;
		}
	}

	public void ResetAxis(bool primary)
	{
		if (initialized)
		{
			LocomotionInputInterpreter.ResetAxis(primary);
		}
	}
}
