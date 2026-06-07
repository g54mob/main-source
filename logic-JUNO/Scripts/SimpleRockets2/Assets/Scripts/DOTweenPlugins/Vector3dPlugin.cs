using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Assets.Scripts.DOTweenPlugins
{
	public class Vector3dPlugin : ABSTweenPlugin<Vector3d, Vector3d, VectorOptions>
	{
		private static Vector3dPlugin _instance = new Vector3dPlugin();

		public static Vector3dPlugin Instance => _instance;

		public override Vector3d ConvertToStartValue(TweenerCore<Vector3d, Vector3d, VectorOptions> tween, Vector3d value)
		{
			return value;
		}

		public override void EvaluateAndApply(VectorOptions options, Tween tween, bool isRelative, DOGetter<Vector3d> getter, DOSetter<Vector3d> setter, float elapsed, Vector3d startValue, Vector3d changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			float num = EaseManager.Evaluate(tween, elapsed, duration, tween.easeOvershootOrAmplitude, tween.easePeriod);
			switch (options.axisConstraint)
			{
			case AxisConstraint.X:
			{
				Vector3d pNewValue3 = getter();
				pNewValue3.x = startValue.x + changeValue.x * (double)num;
				if (options.snapping)
				{
					pNewValue3.x = Math.Round(pNewValue3.x);
				}
				setter(pNewValue3);
				return;
			}
			case AxisConstraint.Y:
			{
				Vector3d pNewValue2 = getter();
				pNewValue2.y = startValue.y + changeValue.y * (double)num;
				if (options.snapping)
				{
					pNewValue2.y = Math.Round(pNewValue2.y);
				}
				setter(pNewValue2);
				return;
			}
			case AxisConstraint.Z:
			{
				Vector3d pNewValue = getter();
				pNewValue.z = startValue.z + changeValue.z * (double)num;
				if (options.snapping)
				{
					pNewValue.z = Math.Round(pNewValue.z);
				}
				setter(pNewValue);
				return;
			}
			}
			startValue.x += changeValue.x * (double)num;
			startValue.y += changeValue.y * (double)num;
			startValue.z += changeValue.z * (double)num;
			if (options.snapping)
			{
				startValue.x = Math.Round(startValue.x);
				startValue.y = Math.Round(startValue.y);
				startValue.z = Math.Round(startValue.z);
			}
			setter(startValue);
		}

		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector3d changeValue)
		{
			return (float)(changeValue.magnitude / (double)unitsXSecond);
		}

		public override void Reset(TweenerCore<Vector3d, Vector3d, VectorOptions> tween)
		{
		}

		public override void SetChangeValue(TweenerCore<Vector3d, Vector3d, VectorOptions> tween)
		{
			switch (tween.plugOptions.axisConstraint)
			{
			case AxisConstraint.X:
				tween.changeValue = new Vector3d(tween.endValue.x - tween.startValue.x, 0.0, 0.0);
				break;
			case AxisConstraint.Y:
				tween.changeValue = new Vector3d(0.0, tween.endValue.y - tween.startValue.y, 0.0);
				break;
			default:
				tween.changeValue = tween.endValue - tween.startValue;
				break;
			case AxisConstraint.Z:
				tween.changeValue = new Vector3d(0.0, 0.0, tween.endValue.z - tween.startValue.z);
				break;
			}
		}

		public override void SetFrom(TweenerCore<Vector3d, Vector3d, VectorOptions> tween, bool isRelative)
		{
			Vector3d endValue = tween.endValue;
			tween.endValue = tween.getter();
			tween.startValue = (isRelative ? (tween.endValue + endValue) : endValue);
			Vector3d pNewValue = tween.endValue;
			switch (tween.plugOptions.axisConstraint)
			{
			default:
				pNewValue = tween.startValue;
				break;
			case AxisConstraint.Z:
				pNewValue.z = tween.startValue.z;
				break;
			case AxisConstraint.Y:
				pNewValue.y = tween.startValue.y;
				break;
			case AxisConstraint.X:
				pNewValue.x = tween.startValue.x;
				break;
			}
			if (tween.plugOptions.snapping)
			{
				pNewValue.x = Math.Round(pNewValue.x);
				pNewValue.y = Math.Round(pNewValue.y);
				pNewValue.z = Math.Round(pNewValue.z);
			}
			tween.setter(pNewValue);
		}

		public override void SetRelativeEndValue(TweenerCore<Vector3d, Vector3d, VectorOptions> t)
		{
			t.endValue += t.startValue;
		}
	}
}
