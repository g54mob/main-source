using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Events;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI;

[Serializable]
public class UIPopupBehavior
{
	public const bool DEFAULT_INSTANT_ANIMATION = false;

	public const bool DEFAULT_LOAD_SELECTED_PRESET_AT_RUNTIME = false;

	public UIAnimation Animation;

	public bool LoadSelectedPresetAtRuntime;

	public bool InstantAnimation;

	public UIAction OnFinished;

	public UIAction OnStart;

	public string PresetCategory;

	public string PresetName;

	private float m_progress;

	public static string DefaultPresetCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980704]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Uncategorized";
		}
	}

	public static string DefaultPresetName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980705]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Default";
		}
	}

	public bool HasAnimation
	{
		get
		{
			if (Animation == null)
			{
				return false;
			}
			bool enabled = Animation.Enabled;
			bool result = true;
			if (!enabled)
			{
				result = LoadSelectedPresetAtRuntime;
			}
			return result;
		}
	}

	public bool HasAnimatorEvents
	{
		get
		{
			//IL_016d: Expected I4, but got O
			UIAction onStart = OnStart;
			if (OnStart != null)
			{
				if (onStart.AnimatorEvents != null)
				{
					List<AnimatorEvent> animatorEvents = onStart.AnimatorEvents;
					if (onStart.AnimatorEvents == null)
					{
						goto IL_015f;
					}
					if (animatorEvents._size > 0)
					{
						return true;
					}
				}
				UIAction onFinished = OnFinished;
				if (OnFinished != null)
				{
					if (onFinished.AnimatorEvents == null)
					{
						return false;
					}
					List<AnimatorEvent> animatorEvents2 = onFinished.AnimatorEvents;
					if (onFinished.AnimatorEvents != null)
					{
						int num = animatorEvents2._size ^ animatorEvents2._size;
						int num2 = animatorEvents2._size & num;
						bool flag = num2 < 0;
						bool flag2 = animatorEvents2._size < 0;
						bool flag3 = animatorEvents2._size == 0;
						bool flag4 = flag2 == flag;
						bool flag5 = !flag3;
						return flag5 & flag4;
					}
				}
			}
			goto IL_015f;
			IL_015f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasEffect
	{
		get
		{
			//IL_008e: Expected I4, but got O
			if (OnStart != null)
			{
				if (OnStart.HasEffect)
				{
					return true;
				}
				if (OnFinished != null)
				{
					return OnFinished.HasEffect;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasGameEvents
	{
		get
		{
			//IL_016d: Expected I4, but got O
			UIAction onStart = OnStart;
			if (OnStart != null)
			{
				if (onStart.GameEvents != null)
				{
					List<string> gameEvents = onStart.GameEvents;
					if (onStart.GameEvents == null)
					{
						goto IL_015f;
					}
					if (gameEvents._size > 0)
					{
						return true;
					}
				}
				UIAction onFinished = OnFinished;
				if (OnFinished != null)
				{
					if (onFinished.GameEvents == null)
					{
						return false;
					}
					List<string> gameEvents2 = onFinished.GameEvents;
					if (onFinished.GameEvents != null)
					{
						int num = gameEvents2._size ^ gameEvents2._size;
						int num2 = gameEvents2._size & num;
						bool flag = num2 < 0;
						bool flag2 = gameEvents2._size < 0;
						bool flag3 = gameEvents2._size == 0;
						bool flag4 = flag2 == flag;
						bool flag5 = !flag3;
						return flag5 & flag4;
					}
				}
			}
			goto IL_015f;
			IL_015f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasSound
	{
		get
		{
			//IL_008e: Expected I4, but got O
			if (OnStart != null)
			{
				if (OnStart.HasSound)
				{
					return true;
				}
				if (OnFinished != null)
				{
					return OnFinished.HasSound;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasUnityEvents
	{
		get
		{
			//IL_00f8: Expected I4, but got O
			UIAction onStart = OnStart;
			if (OnStart != null)
			{
				if (onStart.Event == null)
				{
					goto IL_00b7;
				}
				UnityEvent unityEvent = onStart.Event;
				UnityEngine.Events.PersistentCallGroup persistentCalls = ((UnityEventBase)unityEvent).m_PersistentCalls;
				if (((UnityEventBase)unityEvent).m_PersistentCalls != null)
				{
					List<UnityEngine.Events.PersistentCall> calls = persistentCalls.m_Calls;
					if (persistentCalls.m_Calls != null)
					{
						if (calls._size > 0)
						{
							return true;
						}
						goto IL_00b7;
					}
				}
			}
			goto IL_00ea;
			IL_00b7:
			if (OnFinished != null)
			{
				return OnFinished.HasUnityEvent;
			}
			goto IL_00ea;
			IL_00ea:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public UIPopupBehavior(AnimationType animationType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980704]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PresetCategory = "Uncategorized";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980705]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PresetName = "Default";
		Reset(animationType);
	}

	public void LoadPreset()
	{
		UIAnimations instance = UIAnimations.Instance;
		UIAnimation animation = Animation;
		UIAnimationData uIAnimationData = instance.Get(animation.AnimationType, PresetCategory, PresetName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			UIAnimation animation2 = uIAnimationData.Animation.Copy();
			Animation = animation2;
		}
	}

	public void LoadPreset(string presetCategory, string presetName)
	{
		UIAnimations instance = UIAnimations.Instance;
		UIAnimation animation = Animation;
		UIAnimationData uIAnimationData = instance.Get(animation.AnimationType, presetCategory, presetName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			UIAnimation animation2 = uIAnimationData.Animation.Copy();
			Animation = animation2;
		}
	}

	public void Reset(AnimationType animationType)
	{
		LoadSelectedPresetAtRuntime = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980704]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PresetCategory = "Uncategorized";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980705]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PresetName = "Default";
		UIAnimation uIAnimation = null;
		uIAnimation.Reset(animationType);
		Animation = uIAnimation;
		UIAction onStart = new UIAction();
		OnStart = onStart;
		UIAction onFinished = new UIAction();
		OnFinished = onFinished;
	}
}
