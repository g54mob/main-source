using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval
{
	public class AnimatorDisableManager : IDisposable
	{
		private static readonly int IdleTagHash = Animator.StringToHash("Idle");

		private readonly Dictionary<Animator, float> activeAnimators = new Dictionary<Animator, float>();

		private readonly HashSet<Animator> animatorsToRegister = new HashSet<Animator>();

		public AnimatorDisableManager()
		{
			MonoSingleton<SceneController>.Instance.Tick += Tick;
		}

		public void Dispose()
		{
			activeAnimators.Clear();
			animatorsToRegister.Clear();
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= Tick;
			}
		}

		public void Register(Animator animator)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(31, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Animations\\AnimatorDisableManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Registering DoorAnimator at ");
				messageBuilder.AppendFormatted(animator.transform.position);
				messageBuilder.AppendLiteral(" '");
				messageBuilder.AppendFormatted(animator.gameObject.name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			animatorsToRegister.Add(animator);
		}

		public void Unregister(Animator animator)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Animations\\AnimatorDisableManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Unregistering DoorAnimator at ");
				messageBuilder.AppendFormatted(animator.transform.position);
				messageBuilder.AppendLiteral(" '");
				messageBuilder.AppendFormatted(animator.gameObject.name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			activeAnimators.Remove(animator);
			animatorsToRegister.Remove(animator);
		}

		public void OnAnimatorParamModified(Animator animator)
		{
			if (activeAnimators.ContainsKey(animator))
			{
				activeAnimators[animator] = Time.time;
			}
		}

		public void Tick(float deltaTime)
		{
			float time = Time.time;
			if (activeAnimators.Count > 0)
			{
				using PooledHashSet<Animator> pooledHashSet = HashSetPool<Animator>.GetJanitor();
				foreach (var (animator2, num2) in activeAnimators)
				{
					if (animator2 == null || (time - num2 > 2f && TryDisableAnimator(animator2)))
					{
						bool isEnabled;
						FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Animations\\AnimatorDisableManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Disable Animator at ");
							messageBuilder.AppendFormatted(animator2?.transform.position);
						}
						Log.Trace(messageBuilder);
						pooledHashSet.Add(animator2);
					}
				}
				foreach (Animator item in pooledHashSet)
				{
					activeAnimators.Remove(item);
				}
			}
			if (animatorsToRegister.Count <= 0)
			{
				return;
			}
			foreach (Animator item2 in animatorsToRegister)
			{
				activeAnimators.TryAdd(item2, Time.time);
			}
			animatorsToRegister.Clear();
		}

		private static bool TryDisableAnimator(Animator animator)
		{
			if (!animator.enabled)
			{
				return true;
			}
			if (animator.IsInTagWithoutTransition(IdleTagHash))
			{
				animator.enabled = false;
				return true;
			}
			return false;
		}
	}
}
