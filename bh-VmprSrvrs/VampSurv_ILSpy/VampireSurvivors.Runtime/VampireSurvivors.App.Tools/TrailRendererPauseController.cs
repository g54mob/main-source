using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.App.Tools;

public class TrailRendererPauseController : GameMonoBehaviour
{
	private TrailRenderer _trail;

	private Timer _trailTimeResetTimer;

	private float _trailTime;

	private float _trailPauseTime;

	public void Init(TrailRenderer trailRenderer, float trailTime)
	{
		_trail = trailRenderer;
		_trailTime = trailTime;
	}

	protected override void OnPause()
	{
		//IL_004e: Expected O, but got F4
		if (_trailTimeResetTimer != null)
		{
			_trailTimeResetTimer.Cancel();
		}
		object obj = Time.time;
		float trailPauseTime = default(float);
		_trailPauseTime = trailPauseTime;
		_trail.time = 1f / 0f;
	}

	protected override void OnResume()
	{
		//IL_00a0: Expected O, but got F4
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		object obj = Time.time;
		object obj3 = default(object);
		object obj2 = obj3 - _trailPauseTime;
		float time = (float)obj2 + _trailTime;
		_trail.time = time;
		Action onComplete = SetTrailTime;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer trailTimeResetTimer = Timers.Register(_trailTime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_trailTimeResetTimer = trailTimeResetTimer;
	}

	public void Despawn()
	{
		if (_trailTimeResetTimer != null)
		{
			_trailTimeResetTimer.Cancel();
		}
		_trailTimeResetTimer = null;
	}

	private void SetTrailTime()
	{
		_trail.time = _trailTime;
	}

	public TrailRendererPauseController()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
