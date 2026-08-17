using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

namespace VampireSurvivors.Graphics;

public abstract class BaseSpriteAnimation : GameMonoBehaviour
{
	public List<FrameAnimationData> _defaultAnimations;

	private readonly Dictionary<string, FrameAnimationData> _animations;

	private FrameAnimationData _currentAnimation;

	private FrameAnimationData _localAnimation;

	private Action<string> _onUpdate;

	private bool _003CIsPaused_003Ek__BackingField;

	private static ProfilerMarker internalUpdateMarker;

	private static readonly ProfilerMarker MarkerAddAnimation;

	private static readonly ProfilerMarker MarkerCleanAnimations;

	public bool IsPaused
	{
		get
		{
			return _003CIsPaused_003Ek__BackingField;
		}
		set
		{
			_003CIsPaused_003Ek__BackingField = value;
		}
	}

	public string CurrentAnim
	{
		get
		{
			//IL_0033: Expected O, but got I4
			string currentAnimation = (string)(object)_currentAnimation;
			if (_currentAnimation != null)
			{
				return (string)currentAnimation._stringLength;
			}
			return (string)(object)_currentAnimation;
		}
	}

	protected virtual void Awake()
	{
		//IL_0013: Expected O, but got I4
		List<FrameAnimationData>.Enumerator enumerator = default(List<FrameAnimationData>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (!SpriteAnimationController.iterating)
		{
			bool flag = ((HashSet<object>)(object)SpriteAnimationController.Animations).AddIfNotPresent((object)this);
			return;
		}
		bool flag2 = ((HashSet<object>)(object)SpriteAnimationController.PendingAdd).AddIfNotPresent((object)this);
		bool flag3 = ((HashSet<object>)(object)SpriteAnimationController.PendingRemove).Remove((object)this);
	}

	protected override void OnDisable()
	{
		if (!SpriteAnimationController.iterating)
		{
			bool flag = ((HashSet<object>)(object)SpriteAnimationController.Animations).Remove((object)this);
			base.OnDisable();
		}
		else
		{
			bool flag2 = ((HashSet<object>)(object)SpriteAnimationController.PendingAdd).Remove((object)this);
			bool flag3 = ((HashSet<object>)(object)SpriteAnimationController.PendingRemove).AddIfNotPresent((object)this);
			base.OnDisable();
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public void InternalUpdate(float deltaTime)
	{
		if (_003CIsPaused_003Ek__BackingField || _currentAnimation == null)
		{
			return;
		}
		_currentAnimation.AddTime(deltaTime);
		FrameAnimationData currentAnimation = _currentAnimation;
		if (currentAnimation._frameChanged)
		{
			Sprite frame = currentAnimation.GetFrame();
			ApplySpriteFrame(frame);
			if (_onUpdate != null)
			{
				Action<string> onUpdate = _onUpdate;
				string text = ((UnityEngine.Object)frame).GetName();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v134 @ rbx_v6 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public void create(string animName, List<Sprite> frames, int frameRate, bool shouldLoop, bool startRandomFrame = false, Action onComplete = null, bool autoSetAnimation = true)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 7 Invalid \"Jump target not found in method: 0x1874BC330\"");
	}

	public unsafe void AddAnimation(string animName, List<Sprite> frames, int fps, bool shouldLoop, bool startRandomFrame = false, Action onComplete = null, bool autoSetAnimation = true)
	{
		//IL_0140: Expected I, but got O
		//IL_0047: Expected I4, but got I8
		//IL_0081: Expected O, but got I8
		//IL_00c2->IL00c2: Incompatible stack heights: 2 vs 1
		if ((object)MarkerAddAnimation != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerAddAnimation);
		}
		bool flag = _animations == null;
		FrameAnimationData frameAnimationData = default(FrameAnimationData);
		if (!((Dictionary<object, object>)(object)_animations).TryGetValue((object)animName, out object value))
		{
			frameAnimationData = null;
			frameAnimationData._frameIndex = -1;
			frameAnimationData._name = animName;
			frameAnimationData._frames = frames;
			frameAnimationData._fps = fps;
			bool shouldLoop2 = default(bool);
			frameAnimationData._shouldLoop = shouldLoop2;
			bool startOnRandomFrame = default(bool);
			frameAnimationData._startOnRandomFrame = startOnRandomFrame;
			float frameInterval = 1f / (float)fps;
			frameAnimationData._frameInterval = frameInterval;
			Action action = default(Action);
			if (action != null)
			{
				frameAnimationData._onComplete = action;
			}
			bool flag2 = ((Dictionary<string, FrameAnimationData>)(object)frameAnimationData).TryGetValue((string)6603577472L, out *(FrameAnimationData*)(&value));
			bool flag3 = _animations == null;
			bool flag4 = ((Dictionary<object, object>)(object)_animations).TryInsert((object)animName, (object)frameAnimationData, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
		object obj = default(object);
		if (obj != null && _currentAnimation == null)
		{
			SetAnimation(frameAnimationData, animName);
		}
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	public void SetAnimation(FrameAnimationData newAnim, string animName)
	{
		FrameAnimationData frameAnimationData = default(FrameAnimationData);
		if (frameAnimationData == null || frameAnimationData._frames == null)
		{
			return;
		}
		List<Sprite> frames = frameAnimationData._frames;
		if (frames._size > 0)
		{
			_currentAnimation = frameAnimationData;
			FrameAnimationData currentAnimation = _currentAnimation;
			currentAnimation._hasCompleted = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1874C46B0");
			currentAnimation._currentTime = 0f;
			FrameAnimationData currentAnimation2 = _currentAnimation;
			if (currentAnimation2._frames == null)
			{
				string text = default(string);
				string message = "Animation " + text + " has no frames";
				GameObject context = base.gameObject;
				Debug.LogError(message, context);
			}
			Sprite frame = _currentAnimation.GetFrame();
			ApplySpriteFrame(frame);
		}
	}

	public void SetLocalAnimation(FrameAnimationData newAnim, string animName)
	{
		FrameAnimationData frameAnimationData = default(FrameAnimationData);
		if (frameAnimationData == null || frameAnimationData._frames == null)
		{
			return;
		}
		List<Sprite> frames = frameAnimationData._frames;
		if (frames._size > 0)
		{
			_localAnimation = frameAnimationData;
			FrameAnimationData localAnimation = _localAnimation;
			localAnimation._hasCompleted = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1874C46B0");
			localAnimation._currentTime = 0f;
			FrameAnimationData currentAnimation = _currentAnimation;
			if (_currentAnimation != null)
			{
				currentAnimation._hasCompleted = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1874C46B0");
				currentAnimation._currentTime = 0f;
			}
			_currentAnimation = null;
			FrameAnimationData localAnimation2 = _localAnimation;
			if (localAnimation2._frames == null)
			{
				string text = default(string);
				string message = "Animation " + text + " has no frames";
				GameObject context = base.gameObject;
				Debug.LogError(message, context);
			}
			Sprite frame = _localAnimation.GetFrame();
			ApplySpriteFrame(frame);
		}
	}

	public FrameAnimationData GetCurrentAnimation()
	{
		return _currentAnimation;
	}

	public Sprite GetCurrentFrame()
	{
		if (_currentAnimation != null)
		{
			return _currentAnimation.GetFrame();
		}
		return null;
	}

	public unsafe void SetAnimation(string animName)
	{
		//IL_0074: Expected O, but got I
		if (!((Dictionary<object, object>)(object)_animations).TryGetValue((object)animName, out object value) || value == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_8_v3 (System.Object)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_8_v3 (System.Object)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v9+18]");
		if ((nint)0 > (nint)0)
		{
			_currentAnimation = (FrameAnimationData)value;
			FrameAnimationData currentAnimation = _currentAnimation;
			currentAnimation._hasCompleted = false;
			bool flag = ((Dictionary<string, FrameAnimationData>)(object)currentAnimation).TryGetValue(animName, out *(FrameAnimationData*)(&value));
			currentAnimation._currentTime = 0f;
			FrameAnimationData currentAnimation2 = _currentAnimation;
			if (currentAnimation2._frames == null)
			{
				string message = "Animation " + animName + " has no frames";
				GameObject context = base.gameObject;
				Debug.LogError(message, context);
			}
			Sprite frame = _currentAnimation.GetFrame();
			ApplySpriteFrame(frame);
		}
	}

	public void Play(string animName)
	{
		SetAnimation(animName);
	}

	public unsafe void Play(string animName, int frameRate)
	{
		if (((Dictionary<object, object>)(object)_animations).TryGetValue((object)animName, out object value))
		{
			_currentAnimation = (FrameAnimationData)value;
			FrameAnimationData currentAnimation = _currentAnimation;
			currentAnimation._fps = frameRate;
			FrameAnimationData currentAnimation2 = _currentAnimation;
			float frameInterval = 1f / (float)frameRate;
			currentAnimation2._frameInterval = frameInterval;
			currentAnimation2._hasCompleted = false;
			bool flag = ((Dictionary<string, FrameAnimationData>)(object)currentAnimation2).TryGetValue(animName, out *(FrameAnimationData*)(&value));
			currentAnimation2._currentTime = 0f;
			Sprite frame = _currentAnimation.GetFrame();
			ApplySpriteFrame(frame);
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public FrameAnimationData GetAnimation(string animName)
	{
		if (_animations != null)
		{
			bool flag = ((Dictionary<object, object>)(object)_animations).TryGetValue((object)animName, out object value);
			object result = value;
			if (!flag)
			{
				result = null;
			}
			return (FrameAnimationData)result;
		}
		return (FrameAnimationData)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public bool ContainsAnim(string animName)
	{
		if (_animations == null)
		{
			return false;
		}
		int num = _animations.FindEntry(animName);
		int num2 = num >> 31;
		return (byte)(num2 ^ 1) != 0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public void AddCompletionCallback(string animName, Action callback)
	{
		if (((Dictionary<object, object>)(object)_animations).TryGetValue((object)animName, out object value))
		{
			((FrameAnimationData)value).AddCompletionCallback(callback);
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public void RemoveCompletionCallback(string animName, Action callback)
	{
		if (((Dictionary<object, object>)(object)_animations).TryGetValue((object)animName, out object value))
		{
			((FrameAnimationData)value).RemoveCompletionCallback(callback);
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public void AddUpdateCallback(Action<string> callback)
	{
		Delegate obj = Delegate.Combine(_onUpdate, callback);
		if ((object)obj == null)
		{
			_onUpdate = (Action<string>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<string> action = default(Action<string>);
		if (action != null)
		{
			_onUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public void RemoveUpdateCallback(Action<string> callback)
	{
		Delegate obj = Delegate.Remove(_onUpdate, callback);
		if ((object)obj == null)
		{
			_onUpdate = (Action<string>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<string> action = default(Action<string>);
		if (action != null)
		{
			_onUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public void ClearCallbacksForAnim(string animName)
	{
		if (((Dictionary<object, object>)(object)_animations).TryGetValue((object)animName, out object _))
		{
			_ = 0;
		}
	}

	public void CleanAnimations()
	{
		_animations.Clear();
		Dictionary<string, FrameAnimationData> currentAnimation = (Dictionary<string, FrameAnimationData>)(object)_currentAnimation;
		if (_currentAnimation != null)
		{
			currentAnimation._syncRoot = null;
			((Dictionary<string, FrameAnimationData>)(object)_currentAnimation).Clear();
			_ = 0;
		}
		_currentAnimation = null;
	}

	public void Stop()
	{
		_currentAnimation = null;
	}

	public void Pause()
	{
		_003CIsPaused_003Ek__BackingField = true;
	}

	public void Resume()
	{
		_003CIsPaused_003Ek__BackingField = false;
	}

	[MethodImpl((MethodImplOptions)256)]
	private static bool IsAnimDataValid(FrameAnimationData frameAnimationData)
	{
		if (frameAnimationData != null && frameAnimationData._frames != null)
		{
			List<Sprite> frames = frameAnimationData._frames;
			int num = frames._size ^ frames._size;
			int num2 = frames._size & num;
			bool flag = num2 < 0;
			bool flag2 = frames._size < 0;
			bool flag3 = frames._size == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		return false;
	}

	protected abstract void ApplySpriteFrame(Sprite sprite);

	protected BaseSpriteAnimation()
	{
		List<FrameAnimationData> defaultAnimations = new List<FrameAnimationData>();
		_defaultAnimations = defaultAnimations;
		Dictionary<string, FrameAnimationData> dictionary = null;
		int num = dictionary.Initialize(32);
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		if (equalityComparer != null)
		{
			dictionary._comparer = null;
		}
		_animations = dictionary;
		base._onResumeSent = true;
	}

	static BaseSpriteAnimation()
	{
		//IL_0035: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_000e: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("BaseSpriteAnimation.InternalUpdate", 1, MarkerFlags.Default, 0);
		internalUpdateMarker = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("BaseSpriteAnimation.AddAnimation", 1, MarkerFlags.Default, 0);
		MarkerAddAnimation = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("BaseSpriteAnimation.CleanAnimations", 1, MarkerFlags.Default, 0);
		MarkerCleanAnimations = (ProfilerMarker)(nint)intPtr3;
	}
}
