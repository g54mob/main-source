using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Gh.Tk
{
	public class EditControlHandle : Button3DUIView
	{
		public enum HandleMode
		{
			PositionX = 0,
			PositionY = 1,
			PositionZ = 2,
			PositionYZ = 3,
			PositionXY = 4,
			PositionXZ = 5,
			RotationX = 6,
			RotationY = 7,
			RotationZ = 8,
			ScaleX = 9,
			ScaleY = 10,
			ScaleZ = 11,
			ScaleAll = 12
		}

		public static bool snapRotation;

		public Transform EditingTransform;

		public Material rotationGuideLineMaterial;

		private GameObject _guideLineObj;

		private LineRenderer _guideLine;

		private GameObject _startingLineObj;

		private LineRenderer _startingLine;

		private float _guideLineWidth;

		public HandleMode handleMode;

		public static EventHandler<EventArgs> PositionChanged;

		public static EventHandler<EventArgs> RotationChanged;

		public static EventHandler<EventArgs> ScaleChanged;

		private float _previousRotationSoundAngle;

		private Plane? _plane;

		private int _snapDegree;

		private Vector2 _previousMousePosition;

		private Vector2 _startingMousePosition;

		private Vector3 _previousClickPosition;

		private Vector3 _startingClickPosition;

		private Vector3 _startTransformPosition;

		private Vector3 _mouseOffsetPosition;

		private Vector3 _mouseOffsetPositionPlane;

		private Vector3 _startingScale;

		private Vector3 _startingRotationDirection;

		private Quaternion _startingRotation;

		private List<(EntityObject eo, float3 oldPosition, quaternion oldRotation, float3 oldScale)> _originalPositionRotationScaleValues;

		public EntityObjectSync EditingObject { get; set; }

		public static event EventHandler MovementMade
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

		protected override void Start()
		{
		}

		private void ToggleVisibility(object sender, EventArgs<bool> e)
		{
		}

		private void DrawRotationLine(Vector3 end)
		{
		}

		private LineRenderer GetLineRenderer(GameObject parent)
		{
			return null;
		}

		private void UpdateLineRendererWidth()
		{
		}

		private void DestroyRotationLine()
		{
		}

		private void Update()
		{
		}

		private void UpdatePosition(Vector3 position)
		{
		}

		private void UpdateScale(Vector3 scale)
		{
		}

		private void UpdateHandle()
		{
		}

		private void PlayRotationSound(float angle)
		{
		}

		private float GetCenterScaleDifferenceFromMouseInput()
		{
			return 0f;
		}

		private float GetAxisScaleDifferenceFromMouseInput()
		{
			return 0f;
		}

		public Vector3 GetMultiAxisPosition(Vector3 axis)
		{
			return default(Vector3);
		}

		public Vector3 GetMultiAxisClickPosition(Vector3 axis)
		{
			return default(Vector3);
		}

		public Vector3 GetRotationClickPosition(Vector3 axis)
		{
			return default(Vector3);
		}

		public Vector3 GetClickPosition()
		{
			return default(Vector3);
		}

		private Vector3 GetPosition()
		{
			return default(Vector3);
		}

		private Vector3 GetRotationDirection()
		{
			return default(Vector3);
		}

		private Vector3 GetAxisScale(Vector3 direction, float percentageScale)
		{
			return default(Vector3);
		}

		private Vector3 GetScale(Vector3 direction, float difference)
		{
			return default(Vector3);
		}

		private Vector3 ClampScale(Vector3 newScale, Vector3 direction)
		{
			return default(Vector3);
		}

		private float GetRotationAngle(Vector3 axis)
		{
			return 0f;
		}

		private void DrawPlane(Vector3 normal, Vector3 position)
		{
		}

		protected override void UpdateIsPressed()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
