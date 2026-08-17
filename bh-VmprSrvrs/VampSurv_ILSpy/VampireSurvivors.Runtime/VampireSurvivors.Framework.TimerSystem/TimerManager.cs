using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.TimerSystem;

public class TimerManager : GameMonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Timer> _003C_003E9__6_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CUpdateAllTimers_003Eb__6_0(Timer t)
		{
			//IL_003d: Expected I4, but got O
			if (t != null)
			{
				return t.IsDone;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private List<Timer> _timers;

	private List<Timer> _timersToAdd;

	public void RegisterTimer(Timer timer)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97A50");
	}

	public unsafe void CancelAllTimers()
	{
		//IL_0017: Expected O, but got Ref
		if (_timers != null)
		{
			List<Timer>.Enumerator enumerator = default(List<Timer>.Enumerator);
			if (enumerator.MoveNext())
			{
				Timer timer = null;
				List<Timer>.Enumerator enumerator2 = (List<Timer>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (_timersToAdd != null)
			{
				List<Timer>.Enumerator enumerator3 = default(List<Timer>.Enumerator);
				if (enumerator3.MoveNext())
				{
					Timer timer2 = null;
					throw new NullReferenceException();
				}
				List<Timer> timers = new List<Timer>();
				_timers = timers;
				List<Timer> timersToAdd = new List<Timer>();
				_timersToAdd = timersToAdd;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void PauseAllTimers()
	{
		List<Timer>.Enumerator enumerator = default(List<Timer>.Enumerator);
		if (enumerator.MoveNext())
		{
			throw new NullReferenceException();
		}
		List<Timer>.Enumerator enumerator2 = default(List<Timer>.Enumerator);
		if (enumerator2.MoveNext())
		{
			Timer timer = null;
			throw new NullReferenceException();
		}
	}

	public void ResumeAllTimers()
	{
		List<Timer>.Enumerator enumerator = default(List<Timer>.Enumerator);
		if (enumerator.MoveNext())
		{
			throw new NullReferenceException();
		}
		List<Timer>.Enumerator enumerator2 = default(List<Timer>.Enumerator);
		if (enumerator2.MoveNext())
		{
			Timer timer = null;
			throw new NullReferenceException();
		}
	}

	protected unsafe void UpdateAllTimers()
	{
		//IL_0129: Expected O, but got Ref
		List<Timer> timersToAdd = _timersToAdd;
		bool flag = _timersToAdd == null;
		List<object> list = (List<object>)(object)this;
		if (!flag)
		{
			if (timersToAdd._size <= 0)
			{
				goto IL_0329;
			}
			list = (List<object>)(object)_timers;
			if (_timers != null)
			{
				((List<object>)(object)_timers).InsertRange(list._size, (IEnumerable<object>)_timersToAdd);
				list = (List<object>)(object)_timersToAdd;
				if (_timersToAdd != null)
				{
					int version = list._version + 1;
					list._version = version;
					int size = list._size;
					list._size = 0;
					if (list._size > 0)
					{
						Array.Clear(list._items, 0, list._size);
					}
					goto IL_0329;
				}
			}
		}
		goto IL_02ef;
		IL_02ef:
		throw new NullReferenceException();
		IL_0329:
		if (_timers != null)
		{
			List<Timer>.Enumerator enumerator = default(List<Timer>.Enumerator);
			if (enumerator.MoveNext())
			{
				Timer timer = null;
				List<Timer>.Enumerator enumerator2 = (List<Timer>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__6_0;
			if (_003C_003Ec._003C_003E9__6_0 == null)
			{
				match = (Predicate<object>)(_003C_003Ec._003C_003E9__6_0 = delegate(Timer t)
				{
					//IL_003d: Expected I4, but got O
					if (t == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					return t.IsDone;
				});
			}
			if (_timers != null)
			{
				int num = ((List<object>)(object)_timers).RemoveAll(match);
				return;
			}
		}
		goto IL_02ef;
	}

	public TimerManager()
	{
		List<Timer> timers = new List<Timer>();
		_timers = timers;
		List<Timer> timersToAdd = new List<Timer>();
		_timersToAdd = timersToAdd;
		base._onResumeSent = true;
	}
}
