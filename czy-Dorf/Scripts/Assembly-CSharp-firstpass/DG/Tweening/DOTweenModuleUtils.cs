using System;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Scripting;

namespace DG.Tweening
{
	public static class DOTweenModuleUtils
	{
		public static class Physics
		{
			public static void SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans)
			{
				if (options.isRigidbody)
				{
					((Rigidbody)t.target).rotation = newRot;
				}
				else
				{
					trans.rotation = newRot;
				}
			}

			[Preserve]
			public static bool HasRigidbody(Component target)
			{
				return target.GetComponent<Rigidbody>() != null;
			}

			[Preserve]
			public static TweenerCore<Vector3, Path, PathOptions> CreateDOTweenPathTween(MonoBehaviour target, bool tweenRigidbody, bool isLocal, Path path, float duration, PathMode pathMode)
			{
				TweenerCore<Vector3, Path, PathOptions> result = null;
				bool flag = false;
				if (tweenRigidbody)
				{
					Rigidbody component = target.GetComponent<Rigidbody>();
					if (component != null)
					{
						flag = true;
						result = (isLocal ? DOTweenModulePhysics.DOLocalPath(component, path, duration, pathMode) : DOTweenModulePhysics.DOPath(component, path, duration, pathMode));
					}
				}
				if (!flag && tweenRigidbody)
				{
					Rigidbody2D component2 = target.GetComponent<Rigidbody2D>();
					if (component2 != null)
					{
						flag = true;
						result = (isLocal ? DOTweenModulePhysics2D.DOLocalPath(component2, path, duration, pathMode) : DOTweenModulePhysics2D.DOPath(component2, path, duration, pathMode));
					}
				}
				if (!flag)
				{
					result = (isLocal ? ShortcutExtensions.DOLocalPath(target.transform, path, duration, pathMode) : ShortcutExtensions.DOPath(target.transform, path, duration, pathMode));
				}
				return result;
			}
		}

		private static bool _initialized;

		[Preserve]
		public static void Init()
		{
			if (!_initialized)
			{
				_initialized = true;
				DOTweenExternalCommand.SetOrientationOnPath += Physics.SetOrientationOnPath;
			}
		}

		[Preserve]
		private static void Preserver()
		{
			AppDomain.CurrentDomain.GetAssemblies();
			typeof(MonoBehaviour).GetMethod("Stub");
		}
	}
}
