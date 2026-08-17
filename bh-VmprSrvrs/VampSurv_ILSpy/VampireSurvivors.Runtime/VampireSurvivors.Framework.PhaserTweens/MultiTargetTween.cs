using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Framework.PhaserTweens;

public class MultiTargetTween
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Sequence tween;

		internal void _003CRestart_003Eb__0()
		{
			Sequence sequence = DG.Tweening.TweenExtensions.Play(tween);
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public Tween delayTween;

		internal void _003CRestart_003Eb__1()
		{
			DG.Tweening.TweenExtensions.Kill(delayTween);
		}
	}

	private List<Sequence> tweens;

	private List<float> delays;

	private float _lastUpdateTime;

	private TweenCallback _onUpdate;

	private bool _isPaused;

	public void Add(Sequence tween, float delay = 0f)
	{
		//IL_00cd: Expected O, but got I
		//IL_0122: Expected O, but got I
		List<object> list = (List<object>)(object)tweens;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)tween);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<float> list2 = delays;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v5+18]");
		if (num >= 0)
		{
			list2.AddWithResize(delay);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public void Pause()
	{
		_isPaused = true;
		List<Sequence>.Enumerator enumerator = default(List<Sequence>.Enumerator);
		if (enumerator.MoveNext())
		{
			Sequence sequence = null;
			Sequence sequence2 = DG.Tweening.TweenExtensions.Pause<Sequence>(null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C5]");
			bool flag = (nint)0 != 0;
			Sequence sequence3 = null;
			if (!flag)
			{
				_ = 1;
				sequence3 = (Sequence)(object)"PausedGameTweenId";
			}
			throw new NullReferenceException();
		}
	}

	public void Play()
	{
		//IL_0018: Expected I, but got O
		_isPaused = false;
		List<Sequence>.Enumerator enumerator = default(List<Sequence>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				nint num = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v10 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num2 = 0;
				GameManager core = GM.Core;
				if ((object)GM.Core == null)
				{
					break;
				}
				if (!core._isPaused)
				{
					Sequence sequence = DG.Tweening.TweenExtensions.Play<Sequence>(null);
				}
				Sequence sequence2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(null);
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public bool IsPaused()
	{
		return _isPaused;
	}

	public void Restart()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_00cb: Expected O, but got I
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_0163: Expected F4, but got I
		List<Sequence> list = tweens;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= list._size)
			{
				return;
			}
			_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass9_0();
			List<Sequence> list2 = tweens;
			if ((nint)obj >= list2._size)
			{
				break;
			}
			Sequence[] items = list2._items;
			CS_0024_003C_003E8__locals6.tween = items[obj];
			List<float> list3 = delays;
			object obj3 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj3 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			DG.Tweening.TweenExtensions.Restart(CS_0024_003C_003E8__locals6.tween);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v13+20+v68 @ rsi_v5*4]");
			if ((nint)0 > (nint)0)
			{
				_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass9_1();
				Sequence sequence = DG.Tweening.TweenExtensions.Pause(CS_0024_003C_003E8__locals6.tween);
				TweenCallback callback = delegate
				{
					Sequence sequence2 = DG.Tweening.TweenExtensions.Play(CS_0024_003C_003E8__locals6.tween);
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v13+20+v68 @ rsi_v5*4]");
				Tween gameId = DOVirtual.DelayedCall(0f, callback, ignoreTimeScale: false);
				Tween delayTween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
				CS_0024_003C_003E8__locals7.delayTween = delayTween;
				TweenCallback tweenCallback = delegate
				{
					DG.Tweening.TweenExtensions.Kill(CS_0024_003C_003E8__locals7.delayTween);
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B560");
			}
			list = tweens;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Stop()
	{
		Kill();
	}

	public void Kill()
	{
		//IL_00a9: Expected I4, but got O
		bool flag = tweens == null;
		MultiTargetTween multiTargetTween = this;
		if (!flag)
		{
			List<Sequence>.Enumerator enumerator = default(List<Sequence>.Enumerator);
			while (enumerator.MoveNext())
			{
				Tween tween = null;
			}
			multiTargetTween = (MultiTargetTween)(object)tweens;
			if (tweens != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v2 (VampireSurvivors.Framework.PhaserTweens.MultiTargetTween)+1C]");
				_ = (nint)0 + (nint)1;
				multiTargetTween.delays = null;
				if ((nint)multiTargetTween.delays > 0)
				{
					Array.Clear((Array)(object)multiTargetTween.tweens, 0, (int)multiTargetTween.delays);
				}
				_onUpdate = null;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe bool IsAlive()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<Sequence>.Enumerator enumerator = default(List<Sequence>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Sequence>.Enumerator enumerator2 = (List<Sequence>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public MultiTargetTween SetAutoKill(bool autoKill)
	{
		//IL_0013: Expected O, but got I4
		List<Sequence>.Enumerator enumerator = default(List<Sequence>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = 0;
		}
		return this;
	}

	public Sequence GetFirstTween()
	{
		List<Sequence> list = tweens;
		if (list._size > 0)
		{
			Sequence[] items = list._items;
			return items[0];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sequence result = default(Sequence);
		return result;
	}

	public Sequence GetLastTween()
	{
		//IL_0018: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		List<Sequence> list = tweens;
		object obj = list._size - 1;
		if ((nint)obj < list._size)
		{
			Sequence[] items = list._items;
			object obj2 = list._size - 1;
			return items[obj2];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sequence result = default(Sequence);
		return result;
	}

	public unsafe Sequence GetLongestTween()
	{
		//IL_0018: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_008d: Expected O, but got Ref
		List<Sequence>.Enumerator enumerator = (List<Sequence>.Enumerator)tweens;
		object obj = enumerator._index - 1;
		if ((nint)obj < enumerator._index)
		{
			List<Sequence> list = enumerator._list;
			object obj2 = enumerator._index - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v6 (System.Collections.Generic.List`1<DG.Tweening.Sequence>)+20+v80 @ rax_v14*8]");
			Sequence result = (Sequence)0;
			List<Sequence>.Enumerator enumerator2 = default(List<Sequence>.Enumerator);
			if (enumerator2.MoveNext())
			{
				Sequence sequence = null;
				List<Sequence>.Enumerator enumerator3 = (List<Sequence>.Enumerator)(&enumerator2);
				throw new NullReferenceException();
			}
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sequence result2 = default(Sequence);
		return result2;
	}

	public void SetOnUpdate(TweenCallback onUpdate)
	{
		_onUpdate = onUpdate;
	}

	public void OnUpdate()
	{
		float time = PauseSystem.Time;
		bool flag = _lastUpdateTime == time;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B1790Ch\"");
		if (!flag)
		{
			TweenCallback onUpdate = _onUpdate;
			_lastUpdateTime = time;
			if (_onUpdate != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v17.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public MultiTargetTween()
	{
		List<Sequence> list = new List<Sequence>();
		tweens = list;
		List<float> list2 = new List<float>();
		delays = list2;
	}
}
