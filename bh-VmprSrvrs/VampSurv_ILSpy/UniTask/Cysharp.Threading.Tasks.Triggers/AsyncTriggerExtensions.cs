using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public static class AsyncTriggerExtensions
{
	public static AsyncAwakeTrigger GetAsyncAwakeTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAwakeTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncAwakeTrigger>();
			}
			return component;
		}
		return (AsyncAwakeTrigger)(object)new NullReferenceException();
	}

	public static AsyncAwakeTrigger GetAsyncAwakeTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAwakeTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncAwakeTrigger>();
			}
			return component2;
		}
		return (AsyncAwakeTrigger)(object)new NullReferenceException();
	}

	public static AsyncDestroyTrigger GetAsyncDestroyTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDestroyTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncDestroyTrigger>();
			}
			return component;
		}
		return (AsyncDestroyTrigger)(object)new NullReferenceException();
	}

	public static AsyncDestroyTrigger GetAsyncDestroyTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDestroyTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncDestroyTrigger>();
			}
			return component2;
		}
		return (AsyncDestroyTrigger)(object)new NullReferenceException();
	}

	public static AsyncStartTrigger GetAsyncStartTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncStartTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncStartTrigger>();
			}
			return component;
		}
		return (AsyncStartTrigger)(object)new NullReferenceException();
	}

	public static AsyncStartTrigger GetAsyncStartTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncStartTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncStartTrigger>();
			}
			return component2;
		}
		return (AsyncStartTrigger)(object)new NullReferenceException();
	}

	private static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<T>(out var component))
			{
				return gameObject.AddComponent<T>();
			}
			return component;
		}
		return (T)(object)new NullReferenceException();
	}

	public unsafe static UniTask OnDestroyAsync(GameObject gameObject)
	{
		//IL_005d: Expected native int or pointer, but got O
		AsyncDestroyTrigger asyncDestroyTrigger = (gameObject.TryGetComponent<AsyncDestroyTrigger>(out var component) ? component : gameObject.AddComponent<AsyncDestroyTrigger>());
		if ((object)asyncDestroyTrigger != null)
		{
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncDestroyTrigger.OnDestroyAsync().source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe static UniTask OnDestroyAsync(Component component)
	{
		//IL_0044: Expected native int or pointer, but got O
		AsyncDestroyTrigger asyncDestroyTrigger = GetAsyncDestroyTrigger(component);
		if ((object)asyncDestroyTrigger != null)
		{
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncDestroyTrigger.OnDestroyAsync().source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe static UniTask StartAsync(GameObject gameObject)
	{
		//IL_005d: Expected native int or pointer, but got O
		AsyncStartTrigger asyncStartTrigger = (gameObject.TryGetComponent<AsyncStartTrigger>(out var component) ? component : gameObject.AddComponent<AsyncStartTrigger>());
		if ((object)asyncStartTrigger != null)
		{
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncStartTrigger.StartAsync().source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe static UniTask StartAsync(Component component)
	{
		//IL_0087: Expected native int or pointer, but got O
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			AsyncStartTrigger asyncStartTrigger = (gameObject.TryGetComponent<AsyncStartTrigger>(out var component2) ? component2 : gameObject.AddComponent<AsyncStartTrigger>());
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncStartTrigger.StartAsync().source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe static UniTask AwakeAsync(GameObject gameObject)
	{
		//IL_005d: Expected native int or pointer, but got O
		AsyncAwakeTrigger asyncAwakeTrigger = (gameObject.TryGetComponent<AsyncAwakeTrigger>(out var component) ? component : gameObject.AddComponent<AsyncAwakeTrigger>());
		if ((object)asyncAwakeTrigger != null)
		{
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncAwakeTrigger.AwakeAsync().source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe static UniTask AwakeAsync(Component component)
	{
		//IL_0087: Expected native int or pointer, but got O
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			AsyncAwakeTrigger asyncAwakeTrigger = (gameObject.TryGetComponent<AsyncAwakeTrigger>(out var component2) ? component2 : gameObject.AddComponent<AsyncAwakeTrigger>());
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, asyncAwakeTrigger.AwakeAsync().source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public static AsyncFixedUpdateTrigger GetAsyncFixedUpdateTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncFixedUpdateTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncFixedUpdateTrigger>();
			}
			return component;
		}
		return (AsyncFixedUpdateTrigger)(object)new NullReferenceException();
	}

	public static AsyncFixedUpdateTrigger GetAsyncFixedUpdateTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncFixedUpdateTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncFixedUpdateTrigger>();
			}
			return component2;
		}
		return (AsyncFixedUpdateTrigger)(object)new NullReferenceException();
	}

	public static AsyncLateUpdateTrigger GetAsyncLateUpdateTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncLateUpdateTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncLateUpdateTrigger>();
			}
			return component;
		}
		return (AsyncLateUpdateTrigger)(object)new NullReferenceException();
	}

	public static AsyncLateUpdateTrigger GetAsyncLateUpdateTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncLateUpdateTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncLateUpdateTrigger>();
			}
			return component2;
		}
		return (AsyncLateUpdateTrigger)(object)new NullReferenceException();
	}

	public static AsyncAnimatorIKTrigger GetAsyncAnimatorIKTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAnimatorIKTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncAnimatorIKTrigger>();
			}
			return component;
		}
		return (AsyncAnimatorIKTrigger)(object)new NullReferenceException();
	}

	public static AsyncAnimatorIKTrigger GetAsyncAnimatorIKTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAnimatorIKTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncAnimatorIKTrigger>();
			}
			return component2;
		}
		return (AsyncAnimatorIKTrigger)(object)new NullReferenceException();
	}

	public static AsyncAnimatorMoveTrigger GetAsyncAnimatorMoveTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAnimatorMoveTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncAnimatorMoveTrigger>();
			}
			return component;
		}
		return (AsyncAnimatorMoveTrigger)(object)new NullReferenceException();
	}

	public static AsyncAnimatorMoveTrigger GetAsyncAnimatorMoveTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAnimatorMoveTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncAnimatorMoveTrigger>();
			}
			return component2;
		}
		return (AsyncAnimatorMoveTrigger)(object)new NullReferenceException();
	}

	public static AsyncApplicationFocusTrigger GetAsyncApplicationFocusTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncApplicationFocusTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncApplicationFocusTrigger>();
			}
			return component;
		}
		return (AsyncApplicationFocusTrigger)(object)new NullReferenceException();
	}

	public static AsyncApplicationFocusTrigger GetAsyncApplicationFocusTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncApplicationFocusTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncApplicationFocusTrigger>();
			}
			return component2;
		}
		return (AsyncApplicationFocusTrigger)(object)new NullReferenceException();
	}

	public static AsyncApplicationPauseTrigger GetAsyncApplicationPauseTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncApplicationPauseTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncApplicationPauseTrigger>();
			}
			return component;
		}
		return (AsyncApplicationPauseTrigger)(object)new NullReferenceException();
	}

	public static AsyncApplicationPauseTrigger GetAsyncApplicationPauseTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncApplicationPauseTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncApplicationPauseTrigger>();
			}
			return component2;
		}
		return (AsyncApplicationPauseTrigger)(object)new NullReferenceException();
	}

	public static AsyncApplicationQuitTrigger GetAsyncApplicationQuitTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncApplicationQuitTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncApplicationQuitTrigger>();
			}
			return component;
		}
		return (AsyncApplicationQuitTrigger)(object)new NullReferenceException();
	}

	public static AsyncApplicationQuitTrigger GetAsyncApplicationQuitTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncApplicationQuitTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncApplicationQuitTrigger>();
			}
			return component2;
		}
		return (AsyncApplicationQuitTrigger)(object)new NullReferenceException();
	}

	public static AsyncAudioFilterReadTrigger GetAsyncAudioFilterReadTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAudioFilterReadTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncAudioFilterReadTrigger>();
			}
			return component;
		}
		return (AsyncAudioFilterReadTrigger)(object)new NullReferenceException();
	}

	public static AsyncAudioFilterReadTrigger GetAsyncAudioFilterReadTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncAudioFilterReadTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncAudioFilterReadTrigger>();
			}
			return component2;
		}
		return (AsyncAudioFilterReadTrigger)(object)new NullReferenceException();
	}

	public static AsyncBecameInvisibleTrigger GetAsyncBecameInvisibleTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBecameInvisibleTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncBecameInvisibleTrigger>();
			}
			return component;
		}
		return (AsyncBecameInvisibleTrigger)(object)new NullReferenceException();
	}

	public static AsyncBecameInvisibleTrigger GetAsyncBecameInvisibleTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBecameInvisibleTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncBecameInvisibleTrigger>();
			}
			return component2;
		}
		return (AsyncBecameInvisibleTrigger)(object)new NullReferenceException();
	}

	public static AsyncBecameVisibleTrigger GetAsyncBecameVisibleTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBecameVisibleTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncBecameVisibleTrigger>();
			}
			return component;
		}
		return (AsyncBecameVisibleTrigger)(object)new NullReferenceException();
	}

	public static AsyncBecameVisibleTrigger GetAsyncBecameVisibleTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBecameVisibleTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncBecameVisibleTrigger>();
			}
			return component2;
		}
		return (AsyncBecameVisibleTrigger)(object)new NullReferenceException();
	}

	public static AsyncBeforeTransformParentChangedTrigger GetAsyncBeforeTransformParentChangedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBeforeTransformParentChangedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncBeforeTransformParentChangedTrigger>();
			}
			return component;
		}
		return (AsyncBeforeTransformParentChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncBeforeTransformParentChangedTrigger GetAsyncBeforeTransformParentChangedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBeforeTransformParentChangedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncBeforeTransformParentChangedTrigger>();
			}
			return component2;
		}
		return (AsyncBeforeTransformParentChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncOnCanvasGroupChangedTrigger GetAsyncOnCanvasGroupChangedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncOnCanvasGroupChangedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncOnCanvasGroupChangedTrigger>();
			}
			return component;
		}
		return (AsyncOnCanvasGroupChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncOnCanvasGroupChangedTrigger GetAsyncOnCanvasGroupChangedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncOnCanvasGroupChangedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncOnCanvasGroupChangedTrigger>();
			}
			return component2;
		}
		return (AsyncOnCanvasGroupChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionEnterTrigger GetAsyncCollisionEnterTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionEnterTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncCollisionEnterTrigger>();
			}
			return component;
		}
		return (AsyncCollisionEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionEnterTrigger GetAsyncCollisionEnterTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionEnterTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncCollisionEnterTrigger>();
			}
			return component2;
		}
		return (AsyncCollisionEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionEnter2DTrigger GetAsyncCollisionEnter2DTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionEnter2DTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncCollisionEnter2DTrigger>();
			}
			return component;
		}
		return (AsyncCollisionEnter2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionEnter2DTrigger GetAsyncCollisionEnter2DTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionEnter2DTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncCollisionEnter2DTrigger>();
			}
			return component2;
		}
		return (AsyncCollisionEnter2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionExitTrigger GetAsyncCollisionExitTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionExitTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncCollisionExitTrigger>();
			}
			return component;
		}
		return (AsyncCollisionExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionExitTrigger GetAsyncCollisionExitTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionExitTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncCollisionExitTrigger>();
			}
			return component2;
		}
		return (AsyncCollisionExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionExit2DTrigger GetAsyncCollisionExit2DTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionExit2DTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncCollisionExit2DTrigger>();
			}
			return component;
		}
		return (AsyncCollisionExit2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionExit2DTrigger GetAsyncCollisionExit2DTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionExit2DTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncCollisionExit2DTrigger>();
			}
			return component2;
		}
		return (AsyncCollisionExit2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionStayTrigger GetAsyncCollisionStayTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionStayTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncCollisionStayTrigger>();
			}
			return component;
		}
		return (AsyncCollisionStayTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionStayTrigger GetAsyncCollisionStayTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionStayTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncCollisionStayTrigger>();
			}
			return component2;
		}
		return (AsyncCollisionStayTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionStay2DTrigger GetAsyncCollisionStay2DTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionStay2DTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncCollisionStay2DTrigger>();
			}
			return component;
		}
		return (AsyncCollisionStay2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncCollisionStay2DTrigger GetAsyncCollisionStay2DTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCollisionStay2DTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncCollisionStay2DTrigger>();
			}
			return component2;
		}
		return (AsyncCollisionStay2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncControllerColliderHitTrigger GetAsyncControllerColliderHitTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncControllerColliderHitTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncControllerColliderHitTrigger>();
			}
			return component;
		}
		return (AsyncControllerColliderHitTrigger)(object)new NullReferenceException();
	}

	public static AsyncControllerColliderHitTrigger GetAsyncControllerColliderHitTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncControllerColliderHitTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncControllerColliderHitTrigger>();
			}
			return component2;
		}
		return (AsyncControllerColliderHitTrigger)(object)new NullReferenceException();
	}

	public static AsyncDisableTrigger GetAsyncDisableTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDisableTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncDisableTrigger>();
			}
			return component;
		}
		return (AsyncDisableTrigger)(object)new NullReferenceException();
	}

	public static AsyncDisableTrigger GetAsyncDisableTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDisableTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncDisableTrigger>();
			}
			return component2;
		}
		return (AsyncDisableTrigger)(object)new NullReferenceException();
	}

	public static AsyncDrawGizmosTrigger GetAsyncDrawGizmosTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDrawGizmosTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncDrawGizmosTrigger>();
			}
			return component;
		}
		return (AsyncDrawGizmosTrigger)(object)new NullReferenceException();
	}

	public static AsyncDrawGizmosTrigger GetAsyncDrawGizmosTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDrawGizmosTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncDrawGizmosTrigger>();
			}
			return component2;
		}
		return (AsyncDrawGizmosTrigger)(object)new NullReferenceException();
	}

	public static AsyncDrawGizmosSelectedTrigger GetAsyncDrawGizmosSelectedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDrawGizmosSelectedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncDrawGizmosSelectedTrigger>();
			}
			return component;
		}
		return (AsyncDrawGizmosSelectedTrigger)(object)new NullReferenceException();
	}

	public static AsyncDrawGizmosSelectedTrigger GetAsyncDrawGizmosSelectedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDrawGizmosSelectedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncDrawGizmosSelectedTrigger>();
			}
			return component2;
		}
		return (AsyncDrawGizmosSelectedTrigger)(object)new NullReferenceException();
	}

	public static AsyncEnableTrigger GetAsyncEnableTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncEnableTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncEnableTrigger>();
			}
			return component;
		}
		return (AsyncEnableTrigger)(object)new NullReferenceException();
	}

	public static AsyncEnableTrigger GetAsyncEnableTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncEnableTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncEnableTrigger>();
			}
			return component2;
		}
		return (AsyncEnableTrigger)(object)new NullReferenceException();
	}

	public static AsyncGUITrigger GetAsyncGUITrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncGUITrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncGUITrigger>();
			}
			return component;
		}
		return (AsyncGUITrigger)(object)new NullReferenceException();
	}

	public static AsyncGUITrigger GetAsyncGUITrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncGUITrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncGUITrigger>();
			}
			return component2;
		}
		return (AsyncGUITrigger)(object)new NullReferenceException();
	}

	public static AsyncJointBreakTrigger GetAsyncJointBreakTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncJointBreakTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncJointBreakTrigger>();
			}
			return component;
		}
		return (AsyncJointBreakTrigger)(object)new NullReferenceException();
	}

	public static AsyncJointBreakTrigger GetAsyncJointBreakTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncJointBreakTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncJointBreakTrigger>();
			}
			return component2;
		}
		return (AsyncJointBreakTrigger)(object)new NullReferenceException();
	}

	public static AsyncJointBreak2DTrigger GetAsyncJointBreak2DTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncJointBreak2DTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncJointBreak2DTrigger>();
			}
			return component;
		}
		return (AsyncJointBreak2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncJointBreak2DTrigger GetAsyncJointBreak2DTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncJointBreak2DTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncJointBreak2DTrigger>();
			}
			return component2;
		}
		return (AsyncJointBreak2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseDownTrigger GetAsyncMouseDownTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseDownTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMouseDownTrigger>();
			}
			return component;
		}
		return (AsyncMouseDownTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseDownTrigger GetAsyncMouseDownTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseDownTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMouseDownTrigger>();
			}
			return component2;
		}
		return (AsyncMouseDownTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseDragTrigger GetAsyncMouseDragTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseDragTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMouseDragTrigger>();
			}
			return component;
		}
		return (AsyncMouseDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseDragTrigger GetAsyncMouseDragTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseDragTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMouseDragTrigger>();
			}
			return component2;
		}
		return (AsyncMouseDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseEnterTrigger GetAsyncMouseEnterTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseEnterTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMouseEnterTrigger>();
			}
			return component;
		}
		return (AsyncMouseEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseEnterTrigger GetAsyncMouseEnterTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseEnterTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMouseEnterTrigger>();
			}
			return component2;
		}
		return (AsyncMouseEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseExitTrigger GetAsyncMouseExitTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseExitTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMouseExitTrigger>();
			}
			return component;
		}
		return (AsyncMouseExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseExitTrigger GetAsyncMouseExitTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseExitTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMouseExitTrigger>();
			}
			return component2;
		}
		return (AsyncMouseExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseOverTrigger GetAsyncMouseOverTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseOverTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMouseOverTrigger>();
			}
			return component;
		}
		return (AsyncMouseOverTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseOverTrigger GetAsyncMouseOverTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseOverTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMouseOverTrigger>();
			}
			return component2;
		}
		return (AsyncMouseOverTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseUpTrigger GetAsyncMouseUpTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseUpTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMouseUpTrigger>();
			}
			return component;
		}
		return (AsyncMouseUpTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseUpTrigger GetAsyncMouseUpTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseUpTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMouseUpTrigger>();
			}
			return component2;
		}
		return (AsyncMouseUpTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseUpAsButtonTrigger GetAsyncMouseUpAsButtonTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseUpAsButtonTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMouseUpAsButtonTrigger>();
			}
			return component;
		}
		return (AsyncMouseUpAsButtonTrigger)(object)new NullReferenceException();
	}

	public static AsyncMouseUpAsButtonTrigger GetAsyncMouseUpAsButtonTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMouseUpAsButtonTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMouseUpAsButtonTrigger>();
			}
			return component2;
		}
		return (AsyncMouseUpAsButtonTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleCollisionTrigger GetAsyncParticleCollisionTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleCollisionTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncParticleCollisionTrigger>();
			}
			return component;
		}
		return (AsyncParticleCollisionTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleCollisionTrigger GetAsyncParticleCollisionTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleCollisionTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncParticleCollisionTrigger>();
			}
			return component2;
		}
		return (AsyncParticleCollisionTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleSystemStoppedTrigger GetAsyncParticleSystemStoppedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleSystemStoppedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncParticleSystemStoppedTrigger>();
			}
			return component;
		}
		return (AsyncParticleSystemStoppedTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleSystemStoppedTrigger GetAsyncParticleSystemStoppedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleSystemStoppedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncParticleSystemStoppedTrigger>();
			}
			return component2;
		}
		return (AsyncParticleSystemStoppedTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleTriggerTrigger GetAsyncParticleTriggerTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleTriggerTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncParticleTriggerTrigger>();
			}
			return component;
		}
		return (AsyncParticleTriggerTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleTriggerTrigger GetAsyncParticleTriggerTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleTriggerTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncParticleTriggerTrigger>();
			}
			return component2;
		}
		return (AsyncParticleTriggerTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleUpdateJobScheduledTrigger GetAsyncParticleUpdateJobScheduledTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleUpdateJobScheduledTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncParticleUpdateJobScheduledTrigger>();
			}
			return component;
		}
		return (AsyncParticleUpdateJobScheduledTrigger)(object)new NullReferenceException();
	}

	public static AsyncParticleUpdateJobScheduledTrigger GetAsyncParticleUpdateJobScheduledTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncParticleUpdateJobScheduledTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncParticleUpdateJobScheduledTrigger>();
			}
			return component2;
		}
		return (AsyncParticleUpdateJobScheduledTrigger)(object)new NullReferenceException();
	}

	public static AsyncPostRenderTrigger GetAsyncPostRenderTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPostRenderTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPostRenderTrigger>();
			}
			return component;
		}
		return (AsyncPostRenderTrigger)(object)new NullReferenceException();
	}

	public static AsyncPostRenderTrigger GetAsyncPostRenderTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPostRenderTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPostRenderTrigger>();
			}
			return component2;
		}
		return (AsyncPostRenderTrigger)(object)new NullReferenceException();
	}

	public static AsyncPreCullTrigger GetAsyncPreCullTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPreCullTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPreCullTrigger>();
			}
			return component;
		}
		return (AsyncPreCullTrigger)(object)new NullReferenceException();
	}

	public static AsyncPreCullTrigger GetAsyncPreCullTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPreCullTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPreCullTrigger>();
			}
			return component2;
		}
		return (AsyncPreCullTrigger)(object)new NullReferenceException();
	}

	public static AsyncPreRenderTrigger GetAsyncPreRenderTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPreRenderTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPreRenderTrigger>();
			}
			return component;
		}
		return (AsyncPreRenderTrigger)(object)new NullReferenceException();
	}

	public static AsyncPreRenderTrigger GetAsyncPreRenderTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPreRenderTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPreRenderTrigger>();
			}
			return component2;
		}
		return (AsyncPreRenderTrigger)(object)new NullReferenceException();
	}

	public static AsyncRectTransformDimensionsChangeTrigger GetAsyncRectTransformDimensionsChangeTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRectTransformDimensionsChangeTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncRectTransformDimensionsChangeTrigger>();
			}
			return component;
		}
		return (AsyncRectTransformDimensionsChangeTrigger)(object)new NullReferenceException();
	}

	public static AsyncRectTransformDimensionsChangeTrigger GetAsyncRectTransformDimensionsChangeTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRectTransformDimensionsChangeTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncRectTransformDimensionsChangeTrigger>();
			}
			return component2;
		}
		return (AsyncRectTransformDimensionsChangeTrigger)(object)new NullReferenceException();
	}

	public static AsyncRectTransformRemovedTrigger GetAsyncRectTransformRemovedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRectTransformRemovedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncRectTransformRemovedTrigger>();
			}
			return component;
		}
		return (AsyncRectTransformRemovedTrigger)(object)new NullReferenceException();
	}

	public static AsyncRectTransformRemovedTrigger GetAsyncRectTransformRemovedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRectTransformRemovedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncRectTransformRemovedTrigger>();
			}
			return component2;
		}
		return (AsyncRectTransformRemovedTrigger)(object)new NullReferenceException();
	}

	public static AsyncRenderImageTrigger GetAsyncRenderImageTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRenderImageTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncRenderImageTrigger>();
			}
			return component;
		}
		return (AsyncRenderImageTrigger)(object)new NullReferenceException();
	}

	public static AsyncRenderImageTrigger GetAsyncRenderImageTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRenderImageTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncRenderImageTrigger>();
			}
			return component2;
		}
		return (AsyncRenderImageTrigger)(object)new NullReferenceException();
	}

	public static AsyncRenderObjectTrigger GetAsyncRenderObjectTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRenderObjectTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncRenderObjectTrigger>();
			}
			return component;
		}
		return (AsyncRenderObjectTrigger)(object)new NullReferenceException();
	}

	public static AsyncRenderObjectTrigger GetAsyncRenderObjectTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncRenderObjectTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncRenderObjectTrigger>();
			}
			return component2;
		}
		return (AsyncRenderObjectTrigger)(object)new NullReferenceException();
	}

	public static AsyncServerInitializedTrigger GetAsyncServerInitializedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncServerInitializedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncServerInitializedTrigger>();
			}
			return component;
		}
		return (AsyncServerInitializedTrigger)(object)new NullReferenceException();
	}

	public static AsyncServerInitializedTrigger GetAsyncServerInitializedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncServerInitializedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncServerInitializedTrigger>();
			}
			return component2;
		}
		return (AsyncServerInitializedTrigger)(object)new NullReferenceException();
	}

	public static AsyncTransformChildrenChangedTrigger GetAsyncTransformChildrenChangedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTransformChildrenChangedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTransformChildrenChangedTrigger>();
			}
			return component;
		}
		return (AsyncTransformChildrenChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncTransformChildrenChangedTrigger GetAsyncTransformChildrenChangedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTransformChildrenChangedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTransformChildrenChangedTrigger>();
			}
			return component2;
		}
		return (AsyncTransformChildrenChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncTransformParentChangedTrigger GetAsyncTransformParentChangedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTransformParentChangedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTransformParentChangedTrigger>();
			}
			return component;
		}
		return (AsyncTransformParentChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncTransformParentChangedTrigger GetAsyncTransformParentChangedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTransformParentChangedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTransformParentChangedTrigger>();
			}
			return component2;
		}
		return (AsyncTransformParentChangedTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerEnterTrigger GetAsyncTriggerEnterTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerEnterTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTriggerEnterTrigger>();
			}
			return component;
		}
		return (AsyncTriggerEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerEnterTrigger GetAsyncTriggerEnterTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerEnterTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTriggerEnterTrigger>();
			}
			return component2;
		}
		return (AsyncTriggerEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerEnter2DTrigger GetAsyncTriggerEnter2DTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerEnter2DTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTriggerEnter2DTrigger>();
			}
			return component;
		}
		return (AsyncTriggerEnter2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerEnter2DTrigger GetAsyncTriggerEnter2DTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerEnter2DTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTriggerEnter2DTrigger>();
			}
			return component2;
		}
		return (AsyncTriggerEnter2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerExitTrigger GetAsyncTriggerExitTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerExitTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTriggerExitTrigger>();
			}
			return component;
		}
		return (AsyncTriggerExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerExitTrigger GetAsyncTriggerExitTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerExitTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTriggerExitTrigger>();
			}
			return component2;
		}
		return (AsyncTriggerExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerExit2DTrigger GetAsyncTriggerExit2DTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerExit2DTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTriggerExit2DTrigger>();
			}
			return component;
		}
		return (AsyncTriggerExit2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerExit2DTrigger GetAsyncTriggerExit2DTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerExit2DTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTriggerExit2DTrigger>();
			}
			return component2;
		}
		return (AsyncTriggerExit2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerStayTrigger GetAsyncTriggerStayTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerStayTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTriggerStayTrigger>();
			}
			return component;
		}
		return (AsyncTriggerStayTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerStayTrigger GetAsyncTriggerStayTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerStayTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTriggerStayTrigger>();
			}
			return component2;
		}
		return (AsyncTriggerStayTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerStay2DTrigger GetAsyncTriggerStay2DTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerStay2DTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncTriggerStay2DTrigger>();
			}
			return component;
		}
		return (AsyncTriggerStay2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncTriggerStay2DTrigger GetAsyncTriggerStay2DTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncTriggerStay2DTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncTriggerStay2DTrigger>();
			}
			return component2;
		}
		return (AsyncTriggerStay2DTrigger)(object)new NullReferenceException();
	}

	public static AsyncValidateTrigger GetAsyncValidateTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncValidateTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncValidateTrigger>();
			}
			return component;
		}
		return (AsyncValidateTrigger)(object)new NullReferenceException();
	}

	public static AsyncValidateTrigger GetAsyncValidateTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncValidateTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncValidateTrigger>();
			}
			return component2;
		}
		return (AsyncValidateTrigger)(object)new NullReferenceException();
	}

	public static AsyncWillRenderObjectTrigger GetAsyncWillRenderObjectTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncWillRenderObjectTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncWillRenderObjectTrigger>();
			}
			return component;
		}
		return (AsyncWillRenderObjectTrigger)(object)new NullReferenceException();
	}

	public static AsyncWillRenderObjectTrigger GetAsyncWillRenderObjectTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncWillRenderObjectTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncWillRenderObjectTrigger>();
			}
			return component2;
		}
		return (AsyncWillRenderObjectTrigger)(object)new NullReferenceException();
	}

	public static AsyncResetTrigger GetAsyncResetTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncResetTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncResetTrigger>();
			}
			return component;
		}
		return (AsyncResetTrigger)(object)new NullReferenceException();
	}

	public static AsyncResetTrigger GetAsyncResetTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncResetTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncResetTrigger>();
			}
			return component2;
		}
		return (AsyncResetTrigger)(object)new NullReferenceException();
	}

	public static AsyncUpdateTrigger GetAsyncUpdateTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncUpdateTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncUpdateTrigger>();
			}
			return component;
		}
		return (AsyncUpdateTrigger)(object)new NullReferenceException();
	}

	public static AsyncUpdateTrigger GetAsyncUpdateTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncUpdateTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncUpdateTrigger>();
			}
			return component2;
		}
		return (AsyncUpdateTrigger)(object)new NullReferenceException();
	}

	public static AsyncBeginDragTrigger GetAsyncBeginDragTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBeginDragTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncBeginDragTrigger>();
			}
			return component;
		}
		return (AsyncBeginDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncBeginDragTrigger GetAsyncBeginDragTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncBeginDragTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncBeginDragTrigger>();
			}
			return component2;
		}
		return (AsyncBeginDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncCancelTrigger GetAsyncCancelTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCancelTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncCancelTrigger>();
			}
			return component;
		}
		return (AsyncCancelTrigger)(object)new NullReferenceException();
	}

	public static AsyncCancelTrigger GetAsyncCancelTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncCancelTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncCancelTrigger>();
			}
			return component2;
		}
		return (AsyncCancelTrigger)(object)new NullReferenceException();
	}

	public static AsyncDeselectTrigger GetAsyncDeselectTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDeselectTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncDeselectTrigger>();
			}
			return component;
		}
		return (AsyncDeselectTrigger)(object)new NullReferenceException();
	}

	public static AsyncDeselectTrigger GetAsyncDeselectTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDeselectTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncDeselectTrigger>();
			}
			return component2;
		}
		return (AsyncDeselectTrigger)(object)new NullReferenceException();
	}

	public static AsyncDragTrigger GetAsyncDragTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDragTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncDragTrigger>();
			}
			return component;
		}
		return (AsyncDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncDragTrigger GetAsyncDragTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDragTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncDragTrigger>();
			}
			return component2;
		}
		return (AsyncDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncDropTrigger GetAsyncDropTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDropTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncDropTrigger>();
			}
			return component;
		}
		return (AsyncDropTrigger)(object)new NullReferenceException();
	}

	public static AsyncDropTrigger GetAsyncDropTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncDropTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncDropTrigger>();
			}
			return component2;
		}
		return (AsyncDropTrigger)(object)new NullReferenceException();
	}

	public static AsyncEndDragTrigger GetAsyncEndDragTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncEndDragTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncEndDragTrigger>();
			}
			return component;
		}
		return (AsyncEndDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncEndDragTrigger GetAsyncEndDragTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncEndDragTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncEndDragTrigger>();
			}
			return component2;
		}
		return (AsyncEndDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncInitializePotentialDragTrigger GetAsyncInitializePotentialDragTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncInitializePotentialDragTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncInitializePotentialDragTrigger>();
			}
			return component;
		}
		return (AsyncInitializePotentialDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncInitializePotentialDragTrigger GetAsyncInitializePotentialDragTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncInitializePotentialDragTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncInitializePotentialDragTrigger>();
			}
			return component2;
		}
		return (AsyncInitializePotentialDragTrigger)(object)new NullReferenceException();
	}

	public static AsyncMoveTrigger GetAsyncMoveTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMoveTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncMoveTrigger>();
			}
			return component;
		}
		return (AsyncMoveTrigger)(object)new NullReferenceException();
	}

	public static AsyncMoveTrigger GetAsyncMoveTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncMoveTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncMoveTrigger>();
			}
			return component2;
		}
		return (AsyncMoveTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerClickTrigger GetAsyncPointerClickTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerClickTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPointerClickTrigger>();
			}
			return component;
		}
		return (AsyncPointerClickTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerClickTrigger GetAsyncPointerClickTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerClickTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPointerClickTrigger>();
			}
			return component2;
		}
		return (AsyncPointerClickTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerDownTrigger GetAsyncPointerDownTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerDownTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPointerDownTrigger>();
			}
			return component;
		}
		return (AsyncPointerDownTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerDownTrigger GetAsyncPointerDownTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerDownTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPointerDownTrigger>();
			}
			return component2;
		}
		return (AsyncPointerDownTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerEnterTrigger GetAsyncPointerEnterTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerEnterTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPointerEnterTrigger>();
			}
			return component;
		}
		return (AsyncPointerEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerEnterTrigger GetAsyncPointerEnterTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerEnterTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPointerEnterTrigger>();
			}
			return component2;
		}
		return (AsyncPointerEnterTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerExitTrigger GetAsyncPointerExitTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerExitTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPointerExitTrigger>();
			}
			return component;
		}
		return (AsyncPointerExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerExitTrigger GetAsyncPointerExitTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerExitTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPointerExitTrigger>();
			}
			return component2;
		}
		return (AsyncPointerExitTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerUpTrigger GetAsyncPointerUpTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerUpTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncPointerUpTrigger>();
			}
			return component;
		}
		return (AsyncPointerUpTrigger)(object)new NullReferenceException();
	}

	public static AsyncPointerUpTrigger GetAsyncPointerUpTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncPointerUpTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncPointerUpTrigger>();
			}
			return component2;
		}
		return (AsyncPointerUpTrigger)(object)new NullReferenceException();
	}

	public static AsyncScrollTrigger GetAsyncScrollTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncScrollTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncScrollTrigger>();
			}
			return component;
		}
		return (AsyncScrollTrigger)(object)new NullReferenceException();
	}

	public static AsyncScrollTrigger GetAsyncScrollTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncScrollTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncScrollTrigger>();
			}
			return component2;
		}
		return (AsyncScrollTrigger)(object)new NullReferenceException();
	}

	public static AsyncSelectTrigger GetAsyncSelectTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncSelectTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncSelectTrigger>();
			}
			return component;
		}
		return (AsyncSelectTrigger)(object)new NullReferenceException();
	}

	public static AsyncSelectTrigger GetAsyncSelectTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncSelectTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncSelectTrigger>();
			}
			return component2;
		}
		return (AsyncSelectTrigger)(object)new NullReferenceException();
	}

	public static AsyncSubmitTrigger GetAsyncSubmitTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncSubmitTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncSubmitTrigger>();
			}
			return component;
		}
		return (AsyncSubmitTrigger)(object)new NullReferenceException();
	}

	public static AsyncSubmitTrigger GetAsyncSubmitTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncSubmitTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncSubmitTrigger>();
			}
			return component2;
		}
		return (AsyncSubmitTrigger)(object)new NullReferenceException();
	}

	public static AsyncUpdateSelectedTrigger GetAsyncUpdateSelectedTrigger(GameObject gameObject)
	{
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncUpdateSelectedTrigger>(out var component))
			{
				return gameObject.AddComponent<AsyncUpdateSelectedTrigger>();
			}
			return component;
		}
		return (AsyncUpdateSelectedTrigger)(object)new NullReferenceException();
	}

	public static AsyncUpdateSelectedTrigger GetAsyncUpdateSelectedTrigger(Component component)
	{
		GameObject gameObject = component.gameObject;
		if ((object)gameObject != null)
		{
			if (!gameObject.TryGetComponent<AsyncUpdateSelectedTrigger>(out var component2))
			{
				return gameObject.AddComponent<AsyncUpdateSelectedTrigger>();
			}
			return component2;
		}
		return (AsyncUpdateSelectedTrigger)(object)new NullReferenceException();
	}
}
