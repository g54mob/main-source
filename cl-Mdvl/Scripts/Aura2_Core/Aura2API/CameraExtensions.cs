using System;
using UnityEngine;

namespace Aura2API
{
	public static class CameraExtensions
	{
		private static readonly Vector3[] _frustumClipPos = new Vector3[8]
		{
			new Vector3(-1f, 1f, -1f),
			new Vector3(1f, 1f, -1f),
			new Vector3(1f, -1f, -1f),
			new Vector3(-1f, -1f, -1f),
			new Vector3(-1f, 1f, 1f),
			new Vector3(1f, 1f, 1f),
			new Vector3(1f, -1f, 1f),
			new Vector3(-1f, -1f, 1f)
		};

		private static readonly float _spawnDistanceFromCamera = 50f;

		private static readonly float _spawnHeightTolerance = 25f;

		private static Vector3[] _tmpRetrievedFrustumPlaneCornersArray = new Vector3[4];

		private static Vector4[] _tmpNearPlaneCornersArray = new Vector4[4];

		private static Vector4[] _tmpFarPlaneCornersArray = new Vector4[4];

		public static bool IsCurrentSceneViewCamera
		{
			get
			{
				if (Camera.current != null)
				{
					return Camera.current.IsSceneViewCamera();
				}
				return false;
			}
		}

		public static bool IsSceneViewCamera(this Camera camera)
		{
			return false;
		}

		public static Plane[] GetFrustumPlanes(this Camera camera, float nearClipPlaneDistance, float farClipPlaneDistance)
		{
			Plane[] array = GeometryUtility.CalculateFrustumPlanes(camera);
			array[4] = new Plane(camera.transform.forward, camera.transform.position + camera.transform.forward * nearClipPlaneDistance);
			array[5] = new Plane(-camera.transform.forward, camera.transform.position + camera.transform.forward * farClipPlaneDistance);
			return array;
		}

		public static Vector2 GetFrustumSizeAtDistance(this Camera camera, float distance)
		{
			float num = Mathf.Tan(camera.fieldOfView * (MathF.PI / 180f) * 0.5f) * 2f * distance;
			return new Vector2(num * camera.aspect, num);
		}

		public static Camera.StereoscopicEye GetStereoscopicEye(this Camera camera)
		{
			return (Camera.StereoscopicEye)((int)camera.stereoActiveEye % 2);
		}

		public static void GetFrustumPlaneCorners(this Camera camera, Camera.MonoOrStereoscopicEye eye, float planeDistance, ref Vector4[] planeCornersArray)
		{
			if (camera.orthographic)
			{
				_tmpRetrievedFrustumPlaneCornersArray[0].x = 0f;
				_tmpRetrievedFrustumPlaneCornersArray[0].y = 1f;
				_tmpRetrievedFrustumPlaneCornersArray[0].z = planeDistance;
				_tmpRetrievedFrustumPlaneCornersArray[1].x = 1f;
				_tmpRetrievedFrustumPlaneCornersArray[1].y = 1f;
				_tmpRetrievedFrustumPlaneCornersArray[1].z = planeDistance;
				_tmpRetrievedFrustumPlaneCornersArray[2].x = 1f;
				_tmpRetrievedFrustumPlaneCornersArray[2].y = 0f;
				_tmpRetrievedFrustumPlaneCornersArray[2].z = planeDistance;
				_tmpRetrievedFrustumPlaneCornersArray[3].x = 0f;
				_tmpRetrievedFrustumPlaneCornersArray[3].y = 0f;
				_tmpRetrievedFrustumPlaneCornersArray[3].z = planeDistance;
				for (int i = 0; i < 4; i++)
				{
					planeCornersArray[i] = camera.ViewportToWorldPoint(_tmpRetrievedFrustumPlaneCornersArray[i]);
				}
			}
			else
			{
				camera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), planeDistance, eye, _tmpRetrievedFrustumPlaneCornersArray);
				for (int j = 0; j < 4; j++)
				{
					_tmpRetrievedFrustumPlaneCornersArray[j] = camera.transform.localToWorldMatrix.MultiplyPoint(_tmpRetrievedFrustumPlaneCornersArray[j]);
				}
				Vector3 vector = _tmpRetrievedFrustumPlaneCornersArray[0];
				planeCornersArray[0] = new Vector4(_tmpRetrievedFrustumPlaneCornersArray[1].x, _tmpRetrievedFrustumPlaneCornersArray[1].y, _tmpRetrievedFrustumPlaneCornersArray[1].z, 1f);
				planeCornersArray[1] = new Vector4(_tmpRetrievedFrustumPlaneCornersArray[2].x, _tmpRetrievedFrustumPlaneCornersArray[2].y, _tmpRetrievedFrustumPlaneCornersArray[2].z, 1f);
				planeCornersArray[2] = new Vector4(_tmpRetrievedFrustumPlaneCornersArray[3].x, _tmpRetrievedFrustumPlaneCornersArray[3].y, _tmpRetrievedFrustumPlaneCornersArray[3].z, 1f);
				planeCornersArray[3] = new Vector4(vector.x, vector.y, vector.z, 1f);
			}
		}

		public static void GetFrustumCorners(this Camera camera, Camera.MonoOrStereoscopicEye eye, float nearClipDistance, float farClipDistance, ref float[] floatsArrayToFill)
		{
			camera.GetFrustumPlaneCorners(eye, nearClipDistance, ref _tmpNearPlaneCornersArray);
			for (int i = 0; i < 4; i++)
			{
				floatsArrayToFill[i * 4] = _tmpNearPlaneCornersArray[i].x;
				floatsArrayToFill[i * 4 + 1] = _tmpNearPlaneCornersArray[i].y;
				floatsArrayToFill[i * 4 + 2] = _tmpNearPlaneCornersArray[i].z;
				floatsArrayToFill[i * 4 + 3] = _tmpNearPlaneCornersArray[i].w;
			}
			camera.GetFrustumPlaneCorners(eye, farClipDistance, ref _tmpFarPlaneCornersArray);
			for (int j = 0; j < 4; j++)
			{
				floatsArrayToFill[16 + j * 4] = _tmpFarPlaneCornersArray[j].x;
				floatsArrayToFill[16 + j * 4 + 1] = _tmpFarPlaneCornersArray[j].y;
				floatsArrayToFill[16 + j * 4 + 2] = _tmpFarPlaneCornersArray[j].z;
				floatsArrayToFill[16 + j * 4 + 3] = _tmpFarPlaneCornersArray[j].w;
			}
		}

		public static Vector3 GetSpawnPosition(this Camera camera)
		{
			RaycastHit hitInfo = default(RaycastHit);
			Vector3 vector;
			if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, _spawnDistanceFromCamera))
			{
				vector = hitInfo.point;
			}
			else
			{
				vector = camera.transform.position + camera.transform.forward * _spawnDistanceFromCamera;
				if (Physics.Raycast(vector, Vector3.down, out hitInfo, _spawnHeightTolerance))
				{
					vector = hitInfo.point;
				}
			}
			return vector;
		}

		public static Vector4[] GetViewportFrustumCornersWorldPosition(this Camera camera, float nearClipPlaneDistance, float farClipPlaneDistance)
		{
			return new Vector4[8]
			{
				camera.ViewportToWorldPoint(new Vector3(0f, 1f, nearClipPlaneDistance)),
				camera.ViewportToWorldPoint(new Vector3(1f, 1f, nearClipPlaneDistance)),
				camera.ViewportToWorldPoint(new Vector3(1f, 0f, nearClipPlaneDistance)),
				camera.ViewportToWorldPoint(new Vector3(0f, 0f, nearClipPlaneDistance)),
				camera.ViewportToWorldPoint(new Vector3(0f, 1f, farClipPlaneDistance)),
				camera.ViewportToWorldPoint(new Vector3(1f, 1f, farClipPlaneDistance)),
				camera.ViewportToWorldPoint(new Vector3(1f, 0f, farClipPlaneDistance)),
				camera.ViewportToWorldPoint(new Vector3(0f, 0f, farClipPlaneDistance))
			};
		}

		public static Vector4[] GetFrustumCornersWorldPosition(this Camera camera, Matrix4x4 frustumClipToCameraInverseProjMatrix)
		{
			Vector4[] array = new Vector4[8];
			for (int i = 0; i < 8; i++)
			{
				array[i] = frustumClipToCameraInverseProjMatrix.MultiplyPoint(_frustumClipPos[i]);
			}
			return array;
		}

		public static Vector3[] GetFrustumCornersWorldPosition(this Camera camera, float nearClipPlaneDistance, float farClipPlaneDistance)
		{
			Vector3[] array = new Vector3[8];
			Vector2 frustumSizeAtDistance = camera.GetFrustumSizeAtDistance(nearClipPlaneDistance);
			Vector2 frustumSizeAtDistance2 = camera.GetFrustumSizeAtDistance(farClipPlaneDistance);
			Matrix4x4 matrix4x = Matrix4x4.TRS(camera.transform.position, camera.transform.rotation, Vector3.one);
			for (int i = 0; i < 8; i++)
			{
				Vector3 point = _frustumClipPos[i];
				if (point.z < 0f)
				{
					point.x *= frustumSizeAtDistance.x;
					point.y *= frustumSizeAtDistance.y;
					point.z = nearClipPlaneDistance;
				}
				else
				{
					point.x *= frustumSizeAtDistance2.x;
					point.y *= frustumSizeAtDistance2.y;
					point.z = farClipPlaneDistance;
				}
				array[i] = matrix4x.MultiplyPoint3x4(point);
			}
			return array;
		}

		public static Matrix4x4 GetProjectionMatrix(this Camera camera, Camera.MonoOrStereoscopicEye eye = Camera.MonoOrStereoscopicEye.Mono)
		{
			if (eye == Camera.MonoOrStereoscopicEye.Mono)
			{
				return camera.projectionMatrix;
			}
			return camera.GetStereoProjectionMatrix((Camera.StereoscopicEye)eye);
		}

		public static void GetWorldToClipMatrix(this Camera cameraComponent, Camera.MonoOrStereoscopicEye eye, float nearClipPlane, float farClipPlane, ref Matrix4x4 matrixToFill)
		{
			float nearClipPlane2 = cameraComponent.nearClipPlane;
			cameraComponent.nearClipPlane = nearClipPlane;
			float farClipPlane2 = cameraComponent.farClipPlane;
			cameraComponent.farClipPlane = farClipPlane;
			Matrix4x4 worldToCameraMatrix = cameraComponent.worldToCameraMatrix;
			Matrix4x4 projectionMatrix = cameraComponent.GetProjectionMatrix(eye);
			matrixToFill = projectionMatrix * worldToCameraMatrix;
			if (cameraComponent.orthographic)
			{
				matrixToFill[2, 0] = 0f - worldToCameraMatrix[2, 0];
				matrixToFill[2, 1] = 0f - worldToCameraMatrix[2, 1];
				matrixToFill[2, 2] = 0f - worldToCameraMatrix[2, 2];
				matrixToFill[2, 3] = 0f - worldToCameraMatrix[2, 3];
			}
			cameraComponent.nearClipPlane = nearClipPlane2;
			cameraComponent.farClipPlane = farClipPlane2;
		}

		public static StereoMode GetCameraStereoMode(this Camera camera)
		{
			if (camera.stereoEnabled)
			{
				if (XrHelpers.IsSinglePassStereo)
				{
					return StereoMode.SinglePass;
				}
				return StereoMode.MultiPass;
			}
			return StereoMode.Mono;
		}
	}
}
