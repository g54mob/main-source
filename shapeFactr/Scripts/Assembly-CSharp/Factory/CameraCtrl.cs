using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Factory
{
	[RequireComponent(typeof(Camera))]
	public class CameraCtrl : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStart_003Ed__39(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public const string NoFactoryStartCameraMenuPath = "Development/Factory/開始時カメラなし";

		private static Camera cam;

		private static CameraCtrl _instance;

		private static Vector3 orthoPosition;

		private static Quaternion orthoRotation;

		private static float orthoNearClipPlane;

		private static float orthographicSize;

		private static Vector3 persPosition;

		private static Quaternion persRotation;

		private static float persNearClipPlane;

		private static float fieldOfView;

		private static bool orthographic;

		private static bool mapExtendMode;

		public static readonly float DefaultAspect;

		public static float CurrentAspect => 0f;

		private static float FieldOfViewMin => 0f;

		private static float FieldOfViewMax => 0f;

		private static float StartFieldOfView => 0f;

		private static float DefaultFieldOfView => 0f;

		private static float OrthographicSizeMin => 0f;

		private static float OrthographicSizeMax => 0f;

		private static float DefaultOrthographicSize => 0f;

		public static float ZoomRate { get; private set; }

		public static CameraCtrl I => null;

		public static Camera GetFieldCamera()
		{
			return null;
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__39))]
		private IEnumerator Start()
		{
			return null;
		}

		private static void BackupCamera()
		{
		}

		private static void RestoreCamera()
		{
		}

		public static void ChangeCamera(bool ortho, bool reset = false)
		{
		}

		public static void ZoomCamera(float cameraZoom)
		{
		}

		public static bool CheckMoveForTutorial(ref Vector3 preCameraPos, ref float total)
		{
			return false;
		}

		public static bool CheckZoomForTutorial(ref float preOrthographicSize, ref float preFieldOfView, ref float total)
		{
			return false;
		}

		private static float GetCorrectionForFieldOfViewMax()
		{
			return 0f;
		}

		private static float GetCorrectionForOrthographicSizeMax()
		{
			return 0f;
		}

		public static bool IsOrthographic()
		{
			return false;
		}

		public static void ChangeMapExtendCamera(bool enable)
		{
		}

		public static bool IsMapExtendMode()
		{
			return false;
		}

		public static Vector3 CurrentCellGridPos()
		{
			return default(Vector3);
		}
	}
}
