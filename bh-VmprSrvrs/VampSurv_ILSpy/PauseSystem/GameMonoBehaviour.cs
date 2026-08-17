using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Plugins.PauseSystem;
using UnityEngine;

public class GameMonoBehaviour : MonoBehaviour
{
	private bool _onPauseSent;

	private bool _onResumeSent;

	private void Awake()
	{
		_onPauseSent = PauseSystem._paused;
		bool onResumeSent = !PauseSystem._paused;
		_onResumeSent = onResumeSent;
	}

	protected virtual void OnEnable()
	{
		GamePerfFixManager sInstance = GamePerfFixManager._sInstance;
		if ((object)GamePerfFixManager._sInstance != null && ((UnityEngine.Object)sInstance).m_CachedPtr != (IntPtr)0)
		{
			GamePerfFixManager sInstance2 = GamePerfFixManager._sInstance;
			bool flag = ((HashSet<object>)(object)sInstance2._gameMonoBehavioursToAdd).AddIfNotPresent((object)this);
			bool flag2 = ((HashSet<object>)(object)sInstance2._gameMonoBehavioursToRemove).Remove((object)this);
		}
	}

	protected virtual void OnDisable()
	{
		GamePerfFixManager sInstance = GamePerfFixManager._sInstance;
		if ((object)GamePerfFixManager._sInstance != null && ((UnityEngine.Object)sInstance).m_CachedPtr != (IntPtr)0)
		{
			GamePerfFixManager sInstance2 = GamePerfFixManager._sInstance;
			bool flag = ((HashSet<object>)(object)sInstance2._gameMonoBehavioursToAdd).Remove((object)this);
			bool flag2 = ((HashSet<object>)(object)sInstance2._gameMonoBehavioursToRemove).AddIfNotPresent((object)this);
		}
	}

	protected virtual void OnDestroy()
	{
	}

	public void UpdateCallback()
	{
		HandlePauseResume();
		if (!PauseSystem._paused)
		{
			OnUpdate();
		}
	}

	protected void HandlePauseResume()
	{
		if (!PauseSystem._paused)
		{
			if (!_onResumeSent)
			{
				_onPauseSent = false;
				OnResume();
			}
		}
		else if (!_onPauseSent)
		{
			_onPauseSent = true;
			OnPause();
		}
	}

	protected virtual void OnUpdate()
	{
	}

	protected virtual void OnPause()
	{
	}

	protected virtual void OnResume()
	{
	}

	public GameMonoBehaviour()
	{
		//IL_0020: Expected I, but got O
		_onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
