using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	[ExecuteAlways]
	public class AdvancedDissolveGeometricCutoutController : AdvancedDissolveController
	{
		public enum UpdateMode
		{
			OnFixedUpdate = 0,
			EveryFrame = 1,
			Manual = 2
		}

		public UpdateMode updateMode;

		public bool drawGizmos;

		public AdvancedDissolveKeywords.CutoutGeometricType type;

		public AdvancedDissolveKeywords.CutoutGeometricCount count;

		public AdvancedDissolveProperties.Cutout.Geometric.XYZAxis xyzAxis;

		public AdvancedDissolveProperties.Cutout.Geometric.XYZStyle xyzStyle;

		public AdvancedDissolveProperties.Cutout.Geometric.XYZSpace xyzSpace;

		public float xyzRollout;

		public Transform xyzPivotPointTransform;

		public Vector3 xyzPivotPointPosition;

		public Transform target1StartPointTransform;

		public Transform target1EndPointTransform;

		public Vector3 target1StartPointPosition;

		public Vector3 target1EndPointPosition;

		public float target1Radius;

		public Vector3 target1Normal;

		public Vector3 target1Rotation;

		public Vector3 target1Size;

		public Transform target2StartPointTransform;

		public Transform target2EndPointTransform;

		public Vector3 target2StartPointPosition;

		public Vector3 target2EndPointPosition;

		public float target2Radius;

		public Vector3 target2Normal;

		public Vector3 target2Rotation;

		public Vector3 target2Size;

		public Transform target3StartPointTransform;

		public Transform target3EndPointTransform;

		public Vector3 target3StartPointPosition;

		public Vector3 target3EndPointPosition;

		public float target3Radius;

		public Vector3 target3Normal;

		public Vector3 target3Rotation;

		public Vector3 target3Size;

		public Transform target4StartPointTransform;

		public Transform target4EndPointTransform;

		public Vector3 target4StartPointPosition;

		public Vector3 target4EndPointPosition;

		public float target4Radius;

		public Vector3 target4Normal;

		public Vector3 target4Rotation;

		public Vector3 target4Size;

		public bool invert;

		public float noise;

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		[ContextMenu("Force Update Geometric Cutout Controller")]
		public override void ForceUpdateShaderData()
		{
		}

		[ContextMenu("Reset Geometric Cutout Controller")]
		public override void ResetShaderData()
		{
		}

		private void UpdateShaderData()
		{
		}

		public Transform GetTargetStartPointTransform(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return null;
		}

		public Transform GetTargetEndPointTransform(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return null;
		}

		public Vector3 GetTargetStartPointPosition(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return default(Vector3);
		}

		public Vector3 GetTargetEndPointPosition(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return default(Vector3);
		}

		public float GetTargetRadius(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return 0f;
		}

		public Vector3 GetTargetNormal(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return default(Vector3);
		}

		public Vector3 GetTargetRotation(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return default(Vector3);
		}

		public Vector3 GetTargetSize(AdvancedDissolveKeywords.CutoutGeometricCount countID)
		{
			return default(Vector3);
		}

		public void SetTargetStartPointTransform(AdvancedDissolveKeywords.CutoutGeometricCount countID, Transform transform)
		{
		}

		public void SetTargetEndPointTransform(AdvancedDissolveKeywords.CutoutGeometricCount countID, Transform transform)
		{
		}

		public void SetTargetStartPointPosition(AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position)
		{
		}

		public void SetTargetEndPointPosition(AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position)
		{
		}

		public void SetTargetRadius(AdvancedDissolveKeywords.CutoutGeometricCount countID, float radius)
		{
		}

		public void SetTargetNormal(AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 normal)
		{
		}

		public void SetTargetRotation(AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 rotation)
		{
		}

		public void SetTargetSize(AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 size)
		{
		}

		public void GetPlaneData(AdvancedDissolveKeywords.CutoutGeometricCount countID, out Vector3 position, out Vector3 normal)
		{
			position = default(Vector3);
			normal = default(Vector3);
		}

		public void GetSphereData(AdvancedDissolveKeywords.CutoutGeometricCount countID, out Vector3 position, out float radius)
		{
			position = default(Vector3);
			radius = default(float);
		}

		public void GetCubeData(AdvancedDissolveKeywords.CutoutGeometricCount countID, out Vector3 position, out Vector3 rotation, out Vector3 size)
		{
			position = default(Vector3);
			rotation = default(Vector3);
			size = default(Vector3);
		}

		public void GetCapsuleData(AdvancedDissolveKeywords.CutoutGeometricCount countID, out Vector3 startPosition, out Vector3 endPosition, out float radius)
		{
			startPosition = default(Vector3);
			endPosition = default(Vector3);
			radius = default(float);
		}

		public void GetConeSmoothData(AdvancedDissolveKeywords.CutoutGeometricCount countID, out Vector3 startPosition, out Vector3 endPosition, out float radius)
		{
			startPosition = default(Vector3);
			endPosition = default(Vector3);
			radius = default(float);
		}
	}
}
