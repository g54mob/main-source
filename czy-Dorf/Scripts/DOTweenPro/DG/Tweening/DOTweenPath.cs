using System;
using System.Collections.Generic;
using System.Reflection;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	public class DOTweenPath : ABSAnimationComponent
	{
		public float delay;

		public float duration = 1f;

		public Ease easeType = Ease.OutQuad;

		public AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public int loops = 1;

		public string id = "";

		public LoopType loopType;

		public OrientType orientType;

		public Transform lookAtTransform;

		public Vector3 lookAtPosition;

		public float lookAhead = 0.01f;

		public bool autoPlay = true;

		public bool autoKill = true;

		public bool relative;

		public bool isLocal;

		public bool isClosedPath;

		public int pathResolution = 10;

		public PathMode pathMode = PathMode.Full3D;

		public AxisConstraint lockRotation;

		public bool assignForwardAndUp;

		public Vector3 forwardDirection = Vector3.forward;

		public Vector3 upDirection = Vector3.up;

		public bool tweenRigidbody;

		public List<Vector3> wps = new List<Vector3>();

		public List<Vector3> fullWps = new List<Vector3>();

		public Path path;

		public DOTweenInspectorMode inspectorMode;

		public PathType pathType;

		public HandlesType handlesType;

		public bool livePreview = true;

		public HandlesDrawMode handlesDrawMode;

		public float perspectiveHandleSize = 0.5f;

		public bool showIndexes = true;

		public bool showWpLength;

		public Color pathColor = new Color(1f, 1f, 1f, 0.5f);

		public Vector3 lastSrcPosition;

		public Quaternion lastSrcRotation;

		public bool wpsDropdown;

		public float dropToFloorOffset;

		private static MethodInfo _miCreateTween;

		public static event Action<DOTweenPath> OnReset;

		private static void Dispatch_OnReset(DOTweenPath path)
		{
			if (DOTweenPath.OnReset != null)
			{
				DOTweenPath.OnReset(path);
			}
		}

		private void Awake()
		{
			if (path == null || wps.Count < 1 || inspectorMode == DOTweenInspectorMode.OnlyPath)
			{
				return;
			}
			if ((object)_miCreateTween == null)
			{
				_miCreateTween = DOTweenUtils.GetLooseScriptType("DG.Tweening.DOTweenModuleUtils+Physics").GetMethod("CreateDOTweenPathTween", BindingFlags.Static | BindingFlags.Public);
			}
			path.AssignDecoder(path.type);
			if (TweenManager.isUnityEditor)
			{
				DOTween.GizmosDelegates.Add(path.Draw);
				path.gizmoColor = pathColor;
			}
			if (isLocal)
			{
				Transform transform = base.transform;
				if (transform.parent != null)
				{
					transform = transform.parent;
					Vector3 position = transform.position;
					int num = path.wps.Length;
					for (int i = 0; i < num; i++)
					{
						path.wps[i] = path.wps[i] - position;
					}
					num = path.controlPoints.Length;
					for (int j = 0; j < num; j++)
					{
						ControlPoint controlPoint = path.controlPoints[j];
						controlPoint.a -= position;
						controlPoint.b -= position;
						path.controlPoints[j] = controlPoint;
					}
				}
			}
			if (relative)
			{
				ReEvaluateRelativeTween();
			}
			if (pathMode == PathMode.Full3D && GetComponent<SpriteRenderer>() != null)
			{
				pathMode = PathMode.TopDown2D;
			}
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = (TweenerCore<Vector3, Path, PathOptions>)_miCreateTween.Invoke(null, new object[6] { this, tweenRigidbody, isLocal, path, duration, pathMode });
			TweenSettingsExtensions.SetOptions(tweenerCore, isClosedPath, AxisConstraint.None, lockRotation);
			switch (orientType)
			{
			case OrientType.LookAtTransform:
				if (lookAtTransform != null)
				{
					if (assignForwardAndUp)
					{
						TweenSettingsExtensions.SetLookAt(tweenerCore, lookAtTransform, forwardDirection, upDirection);
					}
					else
					{
						TweenSettingsExtensions.SetLookAt(tweenerCore, lookAtTransform);
					}
				}
				break;
			case OrientType.LookAtPosition:
				if (assignForwardAndUp)
				{
					TweenSettingsExtensions.SetLookAt(tweenerCore, lookAtPosition, forwardDirection, upDirection);
				}
				else
				{
					TweenSettingsExtensions.SetLookAt(tweenerCore, lookAtPosition);
				}
				break;
			case OrientType.ToPath:
				if (assignForwardAndUp)
				{
					TweenSettingsExtensions.SetLookAt(tweenerCore, lookAhead, forwardDirection, upDirection);
				}
				else
				{
					TweenSettingsExtensions.SetLookAt(tweenerCore, lookAhead);
				}
				break;
			}
			TweenSettingsExtensions.OnKill(TweenSettingsExtensions.SetUpdate(TweenSettingsExtensions.SetAutoKill(TweenSettingsExtensions.SetLoops(TweenSettingsExtensions.SetDelay(tweenerCore, delay), loops, loopType), autoKill), updateType), delegate
			{
				tween = null;
			});
			if (isSpeedBased)
			{
				TweenSettingsExtensions.SetSpeedBased(tweenerCore);
			}
			if (easeType == Ease.INTERNAL_Custom)
			{
				TweenSettingsExtensions.SetEase(tweenerCore, easeCurve);
			}
			else
			{
				TweenSettingsExtensions.SetEase(tweenerCore, easeType);
			}
			if (!string.IsNullOrEmpty(id))
			{
				TweenSettingsExtensions.SetId(tweenerCore, id);
			}
			if (hasOnStart)
			{
				if (onStart != null)
				{
					TweenSettingsExtensions.OnStart(tweenerCore, onStart.Invoke);
				}
			}
			else
			{
				onStart = null;
			}
			if (hasOnPlay)
			{
				if (onPlay != null)
				{
					TweenSettingsExtensions.OnPlay(tweenerCore, onPlay.Invoke);
				}
			}
			else
			{
				onPlay = null;
			}
			if (hasOnUpdate)
			{
				if (onUpdate != null)
				{
					TweenSettingsExtensions.OnUpdate(tweenerCore, onUpdate.Invoke);
				}
			}
			else
			{
				onUpdate = null;
			}
			if (hasOnStepComplete)
			{
				if (onStepComplete != null)
				{
					TweenSettingsExtensions.OnStepComplete(tweenerCore, onStepComplete.Invoke);
				}
			}
			else
			{
				onStepComplete = null;
			}
			if (hasOnComplete)
			{
				if (onComplete != null)
				{
					TweenSettingsExtensions.OnComplete(tweenerCore, onComplete.Invoke);
				}
			}
			else
			{
				onComplete = null;
			}
			if (hasOnRewind)
			{
				if (onRewind != null)
				{
					TweenSettingsExtensions.OnRewind(tweenerCore, onRewind.Invoke);
				}
			}
			else
			{
				onRewind = null;
			}
			if (autoPlay)
			{
				TweenExtensions.Play(tweenerCore);
			}
			else
			{
				TweenExtensions.Pause(tweenerCore);
			}
			tween = tweenerCore;
			if (hasOnTweenCreated && onTweenCreated != null)
			{
				onTweenCreated.Invoke();
			}
		}

		private void Reset()
		{
			path = new Path(pathType, wps.ToArray(), 10, pathColor);
			Dispatch_OnReset(this);
		}

		private void OnDestroy()
		{
			if (tween != null && tween.active)
			{
				TweenExtensions.Kill(tween);
			}
			tween = null;
		}

		public override void DOPlay()
		{
			TweenExtensions.Play(tween);
		}

		public void DOPlayById(string id)
		{
			DOTween.Play(base.gameObject, id);
		}

		public void DOPlayAllById(string id)
		{
			DOTween.Play(id);
		}

		public override void DOPlayBackwards()
		{
			TweenExtensions.PlayBackwards(tween);
		}

		public override void DOPlayForward()
		{
			TweenExtensions.PlayForward(tween);
		}

		public override void DOPause()
		{
			TweenExtensions.Pause(tween);
		}

		public override void DOTogglePause()
		{
			TweenExtensions.TogglePause(tween);
		}

		public override void DORewind()
		{
			TweenExtensions.Rewind(tween);
		}

		public override void DORestart()
		{
			DORestart(fromHere: false);
		}

		public override void DORestart(bool fromHere)
		{
			if (tween == null)
			{
				if (Debugger.logPriority > 1)
				{
					Debugger.LogNullTween(tween);
				}
				return;
			}
			if (fromHere && relative && !isLocal)
			{
				ReEvaluateRelativeTween();
			}
			TweenExtensions.Restart(tween);
		}

		public override void DOComplete()
		{
			TweenExtensions.Complete(tween);
		}

		public override void DOKill()
		{
			TweenExtensions.Kill(tween);
		}

		public void DOKillAllById(string id)
		{
			DOTween.Kill(id);
		}

		public Tween GetTween()
		{
			if (tween == null || !tween.active)
			{
				if (Debugger.logPriority > 1)
				{
					if (tween == null)
					{
						Debugger.LogNullTween(tween);
					}
					else
					{
						Debugger.LogInvalidTween(tween);
					}
				}
				return null;
			}
			return tween;
		}

		public Vector3[] GetDrawPoints()
		{
			if (path.wps == null || path.nonLinearDrawWps == null)
			{
				Debugger.LogWarning("Draw points not ready yet. Returning NULL");
				return null;
			}
			if (pathType == PathType.Linear)
			{
				return path.wps;
			}
			return path.nonLinearDrawWps;
		}

		internal Vector3[] GetFullWps()
		{
			int count = wps.Count;
			int num = count + 1;
			if (isClosedPath)
			{
				num++;
			}
			Vector3[] array = new Vector3[num];
			array[0] = base.transform.position;
			for (int i = 0; i < count; i++)
			{
				array[i + 1] = wps[i];
			}
			if (isClosedPath)
			{
				array[num - 1] = array[0];
			}
			return array;
		}

		private void ReEvaluateRelativeTween()
		{
			Vector3 position = base.transform.position;
			if (!(position == lastSrcPosition))
			{
				Vector3 vector = position - lastSrcPosition;
				int num = path.wps.Length;
				for (int i = 0; i < num; i++)
				{
					path.wps[i] = path.wps[i] + vector;
				}
				num = path.controlPoints.Length;
				for (int j = 0; j < num; j++)
				{
					ControlPoint controlPoint = path.controlPoints[j];
					controlPoint.a += vector;
					controlPoint.b += vector;
					path.controlPoints[j] = controlPoint;
				}
				lastSrcPosition = position;
			}
		}

		private void _003CAwake_003Eb__44_0()
		{
			tween = null;
		}
	}
}
