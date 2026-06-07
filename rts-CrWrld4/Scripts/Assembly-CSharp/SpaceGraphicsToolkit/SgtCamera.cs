using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class SgtCamera : SgtLinkedBehaviour<SgtCamera>
	{
		public bool UseOrigin;

		public float RollAngle;

		public Quaternion RollQuaternion;

		public Matrix4x4 RollMatrix;

		[NonSerialized]
		public Vector3 DeltaPosition;

		[NonSerialized]
		public Vector3 Velocity;

		[NonSerialized]
		public Quaternion OldRotation;

		[NonSerialized]
		public Vector3 OldPosition;

		[NonSerialized]
		public Camera cachedCamera;

		[NonSerialized]
		public bool cachedCameraSet;

		[NonSerialized]
		private SgtPosition expectedPosition;

		[NonSerialized]
		private bool expectedPositionSet;

		public Camera CachedCamera => null;

		public static event Action<Camera> OnCameraPreCull
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<Camera> OnCameraPreRender
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<Camera> OnCameraPostRender
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<SgtCamera> OnSgtCameraPreCull
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<SgtCamera> OnSgtCameraPreRender
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<SgtCamera> OnSgtCameraPostRender
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		static SgtCamera()
		{
		}

		public static bool TryFind(Camera unityCamera, ref SgtCamera foundCamera)
		{
			return false;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected virtual void OnPreCull()
		{
		}

		protected virtual void OnPreRender()
		{
		}

		protected virtual void OnPostRender()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		private void FloatingCameraSnap(SgtFloatingCamera floatingCamera, Vector3 delta)
		{
		}
	}
}
