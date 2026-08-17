using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Graphics;

[Serializable]
public class FrameAnimationData
{
	public string _name;

	public List<Sprite> _frames;

	public int _fps;

	public bool _shouldLoop;

	public float _frameInterval;

	public bool _startOnRandomFrame;

	public bool _frameChanged;

	private int _frameIndex;

	private float _currentTime;

	private float _timeSinceFrameChange;

	private Action _onComplete;

	private bool _hasCompleted;

	public FrameAnimationData(string name, List<Sprite> frames, int fps, bool shouldLoop, bool startOnRandomFrame = false, Action onComplete = null)
	{
		//IL_000f: Expected I4, but got I8
		_frameIndex = -1;
		string name2 = default(string);
		_name = name2;
		List<Sprite> frames2 = default(List<Sprite>);
		_frames = frames2;
		bool shouldLoop2 = default(bool);
		_shouldLoop = shouldLoop2;
		bool startOnRandomFrame2 = default(bool);
		_startOnRandomFrame = startOnRandomFrame2;
		_fps = fps;
		float frameInterval = 1f / (float)fps;
		_frameInterval = frameInterval;
		Action action = default(Action);
		if (action != null)
		{
			_onComplete = action;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1874C46B0");
	}

	public void AddTime(float deltaTime)
	{
		//IL_0206: Invalid comparison between I4 and F4
		//IL_016f: Invalid comparison between I4 and F4
		if (_frames == null || _hasCompleted)
		{
			return;
		}
		_frameChanged = false;
		if ((_currentTime = deltaTime + _currentTime) > _frameInterval)
		{
			List<Sprite> frames = _frames;
			if (++_frameIndex >= frames._size)
			{
				if (!_shouldLoop)
				{
					Action onComplete = _onComplete;
					int frameIndex = frames._size - 1;
					_frameIndex = frameIndex;
					_hasCompleted = true;
					if (_onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v237.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				}
				else
				{
					_frameIndex = 0;
				}
			}
			_currentTime = 0f;
			_frameChanged = true;
		}
		if (0f > _currentTime)
		{
			int frameIndex2 = _frameIndex - 1;
			_frameIndex = frameIndex2;
			if (0f < _currentTime)
			{
				if (!_shouldLoop)
				{
					_frameIndex = 0;
				}
				else
				{
					List<Sprite> frames2 = _frames;
					_frameIndex = frames2._size;
				}
			}
			_currentTime = _frameInterval;
			_frameChanged = true;
		}
		float timeSinceFrameChange = deltaTime + _timeSinceFrameChange;
		_timeSinceFrameChange = timeSinceFrameChange;
	}

	public void Reset()
	{
		_hasCompleted = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1874C46B0");
		_currentTime = 0f;
	}

	public Sprite GetFrame()
	{
		List<Sprite> frames = _frames;
		int frameIndex = _frameIndex;
		if (_frameIndex < frames._size)
		{
			Sprite[] items = frames._items;
			return items[frameIndex];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sprite result = default(Sprite);
		return result;
	}

	public int GetFrameIndex()
	{
		return _frameIndex;
	}

	public void AddCompletionCallback(Action callback)
	{
		Delegate obj = Delegate.Combine(_onComplete, callback);
		if ((object)obj == null)
		{
			_onComplete = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			_onComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			if ((object)obj3 != null)
			{
				return;
			}
		}
		else
		{
			InvalidCastException ex = new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	public void RemoveCompletionCallback(Action callback)
	{
		Delegate obj = Delegate.Remove(_onComplete, callback);
		if ((object)obj == null)
		{
			_onComplete = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			_onComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			if ((object)obj3 != null)
			{
				return;
			}
		}
		else
		{
			InvalidCastException ex = new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	public void ClearCallbacks()
	{
		_onComplete = null;
	}

	[MethodImpl((MethodImplOptions)256)]
	private void SetStartingFrame()
	{
		if (!_startOnRandomFrame)
		{
			_frameIndex = 0;
			return;
		}
		List<Sprite> frames = _frames;
		int frameIndex = UnityEngine.Random.RandomRangeInt(0, frames._size);
		_frameIndex = frameIndex;
	}
}
