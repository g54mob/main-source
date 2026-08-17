using System;
using System.Collections.Generic;
using Doozy.Engine.Events;
using Doozy.Engine.UI.Base;
using UnityEngine.Events;

namespace Doozy.Engine.SceneManagement;

[Serializable]
public class SceneLoadBehavior
{
	public UIAction OnLoadScene;

	public UIAction OnSceneLoaded;

	public bool HasAnimatorEvents
	{
		get
		{
			//IL_016d: Expected I4, but got O
			UIAction onLoadScene = OnLoadScene;
			if (OnLoadScene != null)
			{
				if (onLoadScene.AnimatorEvents != null)
				{
					List<AnimatorEvent> animatorEvents = onLoadScene.AnimatorEvents;
					if (onLoadScene.AnimatorEvents == null)
					{
						goto IL_015f;
					}
					if (animatorEvents._size > 0)
					{
						return true;
					}
				}
				UIAction onSceneLoaded = OnSceneLoaded;
				if (OnSceneLoaded != null)
				{
					if (onSceneLoaded.AnimatorEvents == null)
					{
						return false;
					}
					List<AnimatorEvent> animatorEvents2 = onSceneLoaded.AnimatorEvents;
					if (onSceneLoaded.AnimatorEvents != null)
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
			if (OnLoadScene != null)
			{
				if (OnLoadScene.HasEffect)
				{
					return true;
				}
				if (OnSceneLoaded != null)
				{
					return OnSceneLoaded.HasEffect;
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
			UIAction onLoadScene = OnLoadScene;
			if (OnLoadScene != null)
			{
				if (onLoadScene.GameEvents != null)
				{
					List<string> gameEvents = onLoadScene.GameEvents;
					if (onLoadScene.GameEvents == null)
					{
						goto IL_015f;
					}
					if (gameEvents._size > 0)
					{
						return true;
					}
				}
				UIAction onSceneLoaded = OnSceneLoaded;
				if (OnSceneLoaded != null)
				{
					if (onSceneLoaded.GameEvents == null)
					{
						return false;
					}
					List<string> gameEvents2 = onSceneLoaded.GameEvents;
					if (onSceneLoaded.GameEvents != null)
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
			if (OnLoadScene != null)
			{
				if (OnLoadScene.HasSound)
				{
					return true;
				}
				if (OnSceneLoaded != null)
				{
					return OnSceneLoaded.HasSound;
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
			UIAction onLoadScene = OnLoadScene;
			if (OnLoadScene != null)
			{
				if (onLoadScene.Event == null)
				{
					goto IL_00b7;
				}
				UnityEvent unityEvent = onLoadScene.Event;
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
			if (OnSceneLoaded != null)
			{
				return OnSceneLoaded.HasUnityEvent;
			}
			goto IL_00ea;
			IL_00ea:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public SceneLoadBehavior()
	{
		UIAction onLoadScene = new UIAction();
		OnLoadScene = onLoadScene;
		UIAction onSceneLoaded = new UIAction();
		OnSceneLoaded = onSceneLoaded;
		UIAction onLoadScene2 = new UIAction();
		OnLoadScene = onLoadScene2;
		UIAction onSceneLoaded2 = new UIAction();
		OnSceneLoaded = onSceneLoaded2;
	}

	public void Reset()
	{
		UIAction onLoadScene = new UIAction();
		OnLoadScene = onLoadScene;
		UIAction onSceneLoaded = new UIAction();
		OnSceneLoaded = onSceneLoaded;
	}
}
