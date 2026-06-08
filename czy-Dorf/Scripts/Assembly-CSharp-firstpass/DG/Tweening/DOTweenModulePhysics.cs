using DG.Tweening.Core;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	public static class DOTweenModulePhysics
	{
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public Rigidbody target;

			internal Vector3 _003CDOMove_003Eb__0()
			{
				return target.position;
			}
		}

		private sealed class _003C_003Ec__DisplayClass4_0
		{
			public Rigidbody target;

			internal Quaternion _003CDORotate_003Eb__0()
			{
				return target.rotation;
			}
		}

		private sealed class _003C_003Ec__DisplayClass9_0
		{
			public Rigidbody target;

			internal Vector3 _003CDOPath_003Eb__0()
			{
				return target.position;
			}
		}

		private sealed class _003C_003Ec__DisplayClass10_0
		{
			public Transform trans;

			public Rigidbody target;

			internal Vector3 _003CDOLocalPath_003Eb__0()
			{
				return trans.localPosition;
			}

			internal void _003CDOLocalPath_003Eb__1(Vector3 x)
			{
				target.MovePosition((trans.parent == null) ? x : trans.parent.TransformPoint(x));
			}
		}

		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(Rigidbody target, Vector3 endValue, float duration, bool snapping = false)
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass0_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.position, CS_0024_003C_003E8__locals4.target.MovePosition, endValue, duration);
			TweenSettingsExtensions.SetTarget(TweenSettingsExtensions.SetOptions(tweenerCore, snapping), CS_0024_003C_003E8__locals4.target);
			return tweenerCore;
		}

		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(Rigidbody target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass4_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(() => CS_0024_003C_003E8__locals4.target.rotation, CS_0024_003C_003E8__locals4.target.MoveRotation, endValue, duration);
			TweenSettingsExtensions.SetTarget(tweenerCore, CS_0024_003C_003E8__locals4.target);
			tweenerCore.plugOptions.rotateMode = mode;
			return tweenerCore;
		}

		internal static TweenerCore<Vector3, Path, PathOptions> DOPath(Rigidbody target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass9_0();
			CS_0024_003C_003E8__locals4.target = target;
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = TweenSettingsExtensions.SetTarget(DOTween.To(PathPlugin.Get(), () => CS_0024_003C_003E8__locals4.target.position, CS_0024_003C_003E8__locals4.target.MovePosition, path, duration), CS_0024_003C_003E8__locals4.target);
			tweenerCore.plugOptions.isRigidbody = true;
			tweenerCore.plugOptions.mode = pathMode;
			return tweenerCore;
		}

		internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(Rigidbody target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass10_0();
			CS_0024_003C_003E8__locals8.target = target;
			CS_0024_003C_003E8__locals8.trans = CS_0024_003C_003E8__locals8.target.transform;
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = TweenSettingsExtensions.SetTarget(DOTween.To(PathPlugin.Get(), () => CS_0024_003C_003E8__locals8.trans.localPosition, delegate(Vector3 x)
			{
				CS_0024_003C_003E8__locals8.target.MovePosition((CS_0024_003C_003E8__locals8.trans.parent == null) ? x : CS_0024_003C_003E8__locals8.trans.parent.TransformPoint(x));
			}, path, duration), CS_0024_003C_003E8__locals8.target);
			tweenerCore.plugOptions.isRigidbody = true;
			tweenerCore.plugOptions.mode = pathMode;
			tweenerCore.plugOptions.useLocalPosition = true;
			return tweenerCore;
		}
	}
}
