using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.TimerSystem;

public class Timer
{
	private float _003CDuration_003Ek__BackingField;

	private bool _003CIsLooped_003Ek__BackingField;

	private bool _003CIsCompleted_003Ek__BackingField;

	private bool _003CUsesRealTime_003Ek__BackingField;

	protected static TimerManager _manager;

	protected readonly Action _onComplete;

	protected readonly Action<float> _onUpdate;

	protected float _startTime;

	protected float _lastUpdateTime;

	protected int _repeat;

	protected float? _timeElapsedBeforeCancel;

	protected float? _timeElapsedBeforePause;

	protected readonly MonoBehaviour _autoDestroyOwner;

	protected readonly bool _hasAutoDestroyOwner;

	protected bool _isOnlineTimer;

	protected bool _canPause;

	public float Duration
	{
		get
		{
			return _003CDuration_003Ek__BackingField;
		}
		protected set
		{
			_003CDuration_003Ek__BackingField = value;
		}
	}

	public bool IsLooped
	{
		get
		{
			return _003CIsLooped_003Ek__BackingField;
		}
		set
		{
			_003CIsLooped_003Ek__BackingField = value;
		}
	}

	public bool IsCompleted
	{
		get
		{
			return _003CIsCompleted_003Ek__BackingField;
		}
		protected set
		{
			_003CIsCompleted_003Ek__BackingField = value;
		}
	}

	public bool UsesRealTime
	{
		get
		{
			return _003CUsesRealTime_003Ek__BackingField;
		}
		protected set
		{
			_003CUsesRealTime_003Ek__BackingField = value;
		}
	}

	public bool IsPaused
	{
		get
		{
			//IL_003c: Expected I4, but got O
			//IL_0035: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A289B]");
			if ((nint)0 == 0)
			{
				_ = 1;
				return (byte)(int)_timeElapsedBeforePause != 0;
			}
			return (byte)(int)_timeElapsedBeforePause != 0;
		}
	}

	public bool IsCancelled
	{
		get
		{
			//IL_003c: Expected I4, but got O
			//IL_0035: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A289C]");
			if ((nint)0 == 0)
			{
				_ = 1;
				return (byte)(int)_timeElapsedBeforeCancel != 0;
			}
			return (byte)(int)_timeElapsedBeforeCancel != 0;
		}
	}

	public bool IsDone
	{
		get
		{
			if (!_003CIsCompleted_003Ek__BackingField && (object)_timeElapsedBeforeCancel == null)
			{
				if (!_hasAutoDestroyOwner)
				{
					return false;
				}
				MonoBehaviour autoDestroyOwner = _autoDestroyOwner;
				if ((object)_autoDestroyOwner != null)
				{
					return ((UnityEngine.Object)autoDestroyOwner).m_CachedPtr == (IntPtr)0;
				}
			}
			return true;
		}
	}

	public int RepeatCount => _repeat;

	protected bool IsOwnerDestroyed
	{
		get
		{
			if (!_hasAutoDestroyOwner)
			{
				return false;
			}
			MonoBehaviour autoDestroyOwner = _autoDestroyOwner;
			if ((object)_autoDestroyOwner != null)
			{
				return ((UnityEngine.Object)autoDestroyOwner).m_CachedPtr == (IntPtr)0;
			}
			return true;
		}
	}

	public void Cancel()
	{
		//IL_001a: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		if (!IsDone)
		{
			float timeElapsed = GetTimeElapsed();
			_timeElapsedBeforeCancel = (float?)(object)1;
			_timeElapsedBeforePause = (float?)(object)0;
		}
	}

	public void Complete(bool runAllRepeats = false)
	{
		//IL_00e9: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		if (IsDone)
		{
			return;
		}
		if (runAllRepeats && _repeat > 0)
		{
			do
			{
				int repeat = _repeat - 1;
				_repeat = repeat;
				float worldTime = GetWorldTime();
				bool flag = _onComplete == null;
				_startTime = worldTime;
				if (!flag)
				{
					Action onComplete = _onComplete;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v173.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
			while (_repeat > 0);
		}
		if (_onComplete != null)
		{
			Action onComplete2 = _onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v154.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003CIsCompleted_003Ek__BackingField = true;
		float timeElapsed = GetTimeElapsed();
		_timeElapsedBeforeCancel = (float?)(object)1;
		_timeElapsedBeforePause = (float?)(object)0;
	}

	public void Pause()
	{
		//IL_0037: Expected O, but got I4
		if (_canPause && (object)_timeElapsedBeforePause == null && !IsDone)
		{
			float timeElapsed = GetTimeElapsed();
			_timeElapsedBeforePause = (float?)(object)1;
		}
	}

	public void Resume()
	{
		//IL_0028: Expected O, but got I4
		if ((object)_timeElapsedBeforePause != null && !IsDone)
		{
			_timeElapsedBeforePause = (float?)(object)0;
			GameManager core = GM.Core;
			if (core._multiplayer.IsOnlineMultiplayer && _isOnlineTimer)
			{
				InitializeTime();
			}
		}
	}

	public float GetTimeElapsed()
	{
		if (!_003CIsCompleted_003Ek__BackingField)
		{
			float worldTime = GetWorldTime();
			float num = _startTime + _003CDuration_003Ek__BackingField;
			if (worldTime < num)
			{
				float result = default(float);
				if ((object)_timeElapsedBeforeCancel != null || (object)_timeElapsedBeforePause != null)
				{
					return result;
				}
				float worldTime2 = GetWorldTime();
				return worldTime2 - _startTime;
			}
		}
		return _003CDuration_003Ek__BackingField;
	}

	public float GetTimeRemaining()
	{
		if (!_003CIsCompleted_003Ek__BackingField)
		{
			float worldTime = GetWorldTime();
			float num = _startTime + _003CDuration_003Ek__BackingField;
			if (worldTime < num)
			{
				object obj = default(object);
				if ((object)_timeElapsedBeforeCancel != null || (object)_timeElapsedBeforePause != null)
				{
					return _003CDuration_003Ek__BackingField - (float)obj;
				}
				float worldTime2 = GetWorldTime();
				float num2 = worldTime2 - _startTime;
				return _003CDuration_003Ek__BackingField - num2;
			}
		}
		return _003CDuration_003Ek__BackingField - _003CDuration_003Ek__BackingField;
	}

	public float GetRatioComplete()
	{
		float timeElapsed = GetTimeElapsed();
		return timeElapsed / _003CDuration_003Ek__BackingField;
	}

	public float GetRatioRemaining()
	{
		float timeRemaining = GetTimeRemaining();
		return timeRemaining / _003CDuration_003Ek__BackingField;
	}

	public Timer(float duration, Action onComplete, Action<float> onUpdate, bool isLooped, bool usesRealTime, MonoBehaviour autoDestroyOwner, int repeat = 0, bool isMultiplayer = false, bool canPause = true)
	{
		_003CDuration_003Ek__BackingField = duration;
		_canPause = true;
		_onComplete = onComplete;
		_onUpdate = onUpdate;
		_003CIsLooped_003Ek__BackingField = canPause;
		IntPtr intPtr = default(IntPtr);
		_003CUsesRealTime_003Ek__BackingField = (byte)(nint)intPtr != 0;
		int repeat2 = default(int);
		_repeat = repeat2;
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		_autoDestroyOwner = monoBehaviour;
		bool hasAutoDestroyOwner;
		if ((object)monoBehaviour != null)
		{
			bool flag = ((UnityEngine.Object)monoBehaviour).m_CachedPtr == (IntPtr)0;
			hasAutoDestroyOwner = !flag;
		}
		else
		{
			hasAutoDestroyOwner = false;
		}
		_hasAutoDestroyOwner = hasAutoDestroyOwner;
		bool isOnlineTimer = default(bool);
		_isOnlineTimer = isOnlineTimer;
		bool canPause2 = default(bool);
		_canPause = canPause2;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 283 Invalid \"Jump target not found in method: 0x186B24E30\"");
	}

	private void InitializeTime()
	{
		//IL_0109: Expected I, but got O
		//IL_0048: Expected F4, but got I
		//IL_0053: Invalid comparison between F4 and I4
		//IL_006c: Expected F4, but got I
		//IL_00bf: Invalid comparison between F4 and I4
		float worldTime = GetWorldTime();
		_startTime = worldTime;
		nint num = (nint)typeof(PauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (Il2CppClass<PauseSystem>)+B8]");
		nint num2 = 0;
		if ((object)PauseSystem.DesynchronizedTimeInSeconds != null && _isOnlineTimer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppStaticFields<PauseSystem>)+8]");
			float num3 = 0f;
			bool flag = !(_003CDuration_003Ek__BackingField > 0f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppStaticFields<PauseSystem>)+8]");
			float num4 = 0f;
			if (!flag)
			{
				bool flag3;
				do
				{
					bool flag2 = !(num3 > _003CDuration_003Ek__BackingField);
					num4 = num3;
					if (flag2)
					{
						break;
					}
					num3 -= _003CDuration_003Ek__BackingField;
					flag3 = _003CDuration_003Ek__BackingField > 0f;
					num4 = num3;
				}
				while (flag3);
			}
			float startTime = _startTime - num4;
			_startTime = startTime;
		}
		_lastUpdateTime = _startTime;
	}

	private void AdjustStartTimeForOnlineDeSync()
	{
		//IL_00f5: Expected I, but got O
		//IL_0034: Expected F4, but got I
		//IL_003f: Invalid comparison between F4 and I4
		//IL_0058: Expected F4, but got I
		//IL_00ab: Invalid comparison between F4 and I4
		nint num = (nint)typeof(PauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (Il2CppClass<PauseSystem>)+B8]");
		nint num2 = 0;
		if ((object)PauseSystem.DesynchronizedTimeInSeconds == null || !_isOnlineTimer)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppStaticFields<PauseSystem>)+8]");
		float num3 = 0f;
		bool flag = !(_003CDuration_003Ek__BackingField > 0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppStaticFields<PauseSystem>)+8]");
		float num4 = 0f;
		if (!flag)
		{
			bool flag3;
			do
			{
				bool flag2 = !(num3 > _003CDuration_003Ek__BackingField);
				num4 = num3;
				if (flag2)
				{
					break;
				}
				num3 -= _003CDuration_003Ek__BackingField;
				flag3 = _003CDuration_003Ek__BackingField > 0f;
				num4 = num3;
			}
			while (flag3);
		}
		float startTime = _startTime - num4;
		_startTime = startTime;
	}

	private float GetAdjustTime(float adjustTime)
	{
		//IL_000b: Invalid comparison between F4 and I4
		bool flag = !(_003CDuration_003Ek__BackingField > 0f);
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			while (num > _003CDuration_003Ek__BackingField)
			{
				num -= _003CDuration_003Ek__BackingField;
			}
		}
		return num;
	}

	protected float GetWorldTime()
	{
		//IL_0030: Expected O, but got I
		//IL_0025: Expected O, but got I
		if (_003CUsesRealTime_003Ek__BackingField)
		{
			object obj = 0;
		}
		else
		{
			object obj = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v47 @ rax_v4 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	protected float GetFireTime()
	{
		return _startTime + _003CDuration_003Ek__BackingField;
	}

	protected float GetTimeDelta()
	{
		float worldTime = GetWorldTime();
		return worldTime - _lastUpdateTime;
	}

	public void Update()
	{
		if (IsDone)
		{
			return;
		}
		if ((object)_timeElapsedBeforePause == null)
		{
			float worldTime = GetWorldTime();
			bool flag = _onUpdate == null;
			_lastUpdateTime = worldTime;
			if (!flag)
			{
				Action<float> onUpdate = _onUpdate;
				float timeElapsed = GetTimeElapsed();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rbx_v3 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			float worldTime2 = GetWorldTime();
			float num = _startTime + _003CDuration_003Ek__BackingField;
			if (worldTime2 < num)
			{
				return;
			}
			if (_onComplete != null)
			{
				Action onComplete = _onComplete;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v199.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			if (!_003CIsLooped_003Ek__BackingField)
			{
				if (_repeat <= 0)
				{
					_003CIsCompleted_003Ek__BackingField = true;
					return;
				}
				int repeat = _repeat - 1;
				_repeat = repeat;
			}
			float worldTime3 = GetWorldTime();
			_startTime = worldTime3;
		}
		else
		{
			float worldTime4 = GetWorldTime();
			float num2 = worldTime4 - _lastUpdateTime;
			float startTime = num2 + _startTime;
			_startTime = startTime;
			float worldTime5 = GetWorldTime();
			_lastUpdateTime = worldTime5;
		}
	}
}
