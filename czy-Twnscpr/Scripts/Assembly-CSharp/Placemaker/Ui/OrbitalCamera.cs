using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Ui
{
	public class OrbitalCamera : MonoBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		public Camera cam;

		[SerializeField]
		public Camera mirrorCam;

		[SerializeField]
		public float zoomTarget;

		[SerializeField]
		public float zoomCurrent;

		[SerializeField]
		public float rotationY;

		[SerializeField]
		public float rotationX;

		[SerializeField]
		public float panHexCurrentX;

		[SerializeField]
		public float panHexCurrentY;

		[SerializeField]
		public float panHeightCurrent;

		[SerializeField]
		public float panHexTargetX;

		[SerializeField]
		public float panHexTargetY;

		[SerializeField]
		public float panHeightTarget;

		[SerializeField]
		private float rotationSpeedX;

		[SerializeField]
		private float rotationSpeedY;

		public float3x2 boundsCurrent;

		public float3x2 boundsTarget;

		public float heightCurrent;

		public float heightTarget;

		private float anyVoxelsCurrent;

		private float minRadius;

		private bool snap;

		public const float maxAngle = 88f;

		public float currentDist;

		public float nonDollyDist;

		public float lastBoundsChangeTime;

		private float distMin;

		private float distMax;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		private float GetMinAngle(float dist)
		{
			return 0f;
		}

		private void RemapPans(float3x2 oldBounds, float3x2 newBounts, float oldHeight, float newHeight)
		{
		}

		public void SetBounds()
		{
		}

		public void BoundsUpdated()
		{
		}

		private void LateUpdate()
		{
		}

		public void StopRotation()
		{
		}

		public void SetRotationSpeed(float2 delta)
		{
		}

		public void RotateCamera(float2 delta)
		{
		}

		public static Vector3 GetWorldPos(float panHexX, float panHexY, float panHeight, float3x2 bounds, float height)
		{
			return default(Vector3);
		}

		public static (float, float, float) GetRelativePos(Vector3 worldPos, float3x2 bounds, float height)
		{
			return default((float, float, float));
		}

		public void Focus(Vector3 pos)
		{
		}

		public void WASDCamera(Vector3 delta)
		{
		}

		public void PanCamera(Vector2 pos, Vector2 delta2)
		{
		}

		public void PinchZoom(float multiplier)
		{
		}

		public void ScrollZoom(float delta)
		{
		}

		public void GamepadZoom(float delta)
		{
		}

		public void Save(SaveData saveData)
		{
		}

		public void Load(SaveData saveData)
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
