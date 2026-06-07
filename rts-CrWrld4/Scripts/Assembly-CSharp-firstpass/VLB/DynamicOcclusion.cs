using UnityEngine;

namespace VLB
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class DynamicOcclusion : MonoBehaviour
	{
		private enum Direction
		{
			Up = 0,
			Right = 1,
			Down = 2,
			Left = 3
		}

		public LayerMask layerMask;

		public float minOccluderArea;

		public int waitFrameCount;

		public float minSurfaceRatio;

		public float maxSurfaceDot;

		public PlaneAlignment planeAlignment;

		public float planeOffset;

		private VolumetricLightBeam m_Master;

		private int m_FrameCountToWait;

		private float m_RangeMultiplier;

		private uint m_PrevNonSubHitDirectionId;

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		private Vector3 GetRandomVectorAround(Vector3 direction, float angleDiff)
		{
			return default(Vector3);
		}

		private RaycastHit GetBestHit(Vector3 rayPos, Vector3 rayDir)
		{
			return default(RaycastHit);
		}

		private Vector3 GetDirection(uint dirInt)
		{
			return default(Vector3);
		}

		private bool IsHitValid(RaycastHit hit)
		{
			return false;
		}

		private void ProcessRaycasts()
		{
		}

		private void SetHit(RaycastHit hit)
		{
		}

		private void SetHitNull()
		{
		}

		private void SetClippingPlane(Plane planeWS)
		{
		}

		private void SetClippingPlaneOff()
		{
		}
	}
}
