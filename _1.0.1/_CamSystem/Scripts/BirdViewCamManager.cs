using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_6000_0_OR_NEWER
	using Unity.Cinemachine;
#else
	using Cinemachine;
#endif

using SPACE_UTIL;

namespace SPACE_CamSystem
{
	public class BirdViewCamManager : MonoBehaviour
	{
		Vector3 StartingOffset;

		#region Cinemachine Properties Get/Set Based On Unity3D Version
#if UNITY_6000_0_OR_NEWER
		[Header("vcam ref")] [SerializeField] CinemachineCamera VCam;
#else
		[Header("vcam ref")] [SerializeField] CinemachineVirtualCamera VCam;
#endif
		Vector3 GetFollowOffset()
		{
#if UNITY_6000_0_OR_NEWER
			// Unity 6000.3+ (Cinemachine 3.x)
			var follow = VCam.GetComponent<CinemachineFollow>();
			return follow != null ? follow.FollowOffset : Vector3.zero;
#else
			// Unity 2020.3+ (Cinemachine 2.x)
			return VCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
#endif
		}
		void SetFollowOffset(Vector3 vec3)
		{
#if UNITY_6000_0_OR_NEWER
			// Unity 6000.3+ (Cinemachine 3.x)
			var follow = VCam.GetComponent<CinemachineFollow>();
			if (follow != null)
				follow.FollowOffset = vec3;
#else
			// Unity 2020.3+ (Cinemachine 2.x)
			VCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = vec3;
#endif
		}
		float GetFov()
		{
#if UNITY_6000_0_OR_NEWER
			// Unity 6000.3+ (Cinemachine 3.x)
			return VCam.Lens.FieldOfView;
#else
			// Unity 2020.3+ (Cinemachine 2.x)
			return VCam.m_Lens.FieldOfView;
#endif
		}
		void SetFov(float fov)
		{
#if UNITY_6000_0_OR_NEWER
			// Unity 6000.3+ (Cinemachine 3.x)
			VCam.Lens.FieldOfView = fov;
#else
			// Unity 2020.3+ (Cinemachine 2.x)
			VCam.m_Lens.FieldOfView = fov;
#endif
		}
		#endregion

		private void Start()
		{
			this.StartingOffset = GetFollowOffset().normalized;
		}
		private void Update()
		{
			float dt = Time.unscaledDeltaTime;

			this.Translating = this.Rotating = this.Zooming = false;

			this.HandleTranslate(dt);
			this.HandleCursorLock();
			this.HandleRotate(dt);
			this.HandleZoom();

			if (this.EnableEdgeScroll)
				if (!this.Translating && !this.Rotating && !this.Zooming)
					this.HandleEdgeScroll(dt);
		}
		#region README
		[TextArea(3, 10)]
		[SerializeField] string README = @"0. Attach to Target of Cinemachine
1. Assign VCam Reference to Main Cinemachine[VirtualCamera]
2. Set Aim Properties Of VCam X, Y dampening to 0f, Set Body Properties Of VCam YawDampening to 0.5f";
		#endregion
		[Header("Speed")]
		[SerializeField] float MoveSpeed = 5f;
		[SerializeField] float RotateSpeed = 120f;
		[SerializeField] float ZoomSpeed = 0.5f;
		[Header("Clamp")]
		[SerializeField] float MinOffsetY = 4;
		[SerializeField] float MaxOffsetY = 24;
		[SerializeField] float MinFov = 35;
		[SerializeField] float MaxFov = 80;
		[Header("Smooth")]
		[Range(0.1f, 1f)] [SerializeField] float SmoothFov = 0.5f;
		[Header("EdgeScroll")]
		[SerializeField] bool EnableEdgeScroll = false;
		[SerializeField] int EdgeScrollPad = 40;
		[SerializeField] bool Translating, Rotating, Zooming;
		void HandleTranslate(float dt)
		{
			Vector3 move_vel =
			(
				Input.GetAxisRaw("Horizontal") * this.transform.right +
				Input.GetAxisRaw("Vertical") * this.transform.forward
			).normalized * this.MoveSpeed * (INPUT.K.HeldDown(KeyCode.LeftShift) ? 2f : 1f);

			this.transform.position += move_vel * dt;
			this.Translating = !C.zero(move_vel);
		}
		void HandleRotate(float dt)
		{
			if (INPUT.M.HeldDown(2))
			{
				Vector3 rotate_vel = this.transform.up * Input.GetAxisRaw("Mouse X") * this.RotateSpeed;
				this.Rotating = true;
				this.transform.eulerAngles += rotate_vel * dt;
			}
		}
		void HandleZoom()
		{
			float dt = 1f;
			// var ct = VCam.GetCinemachineComponent<CinemachineTransposer>();

			Vector3 zoom_vel = (this.transform.up + StartingOffset) * -Input.mouseScrollDelta.y * this.ZoomSpeed;
			// Vector3 newOffset = ct.m_FollowOffset + zoom_vel * dt;
			Vector3 newOffset = GetFollowOffset() + zoom_vel * dt;
			if (newOffset.y >= this.MinOffsetY && newOffset.y <= this.MaxOffsetY)
				// ct.m_FollowOffset = new_offset;
				SetFollowOffset(newOffset);

			this.Zooming = !C.zero(zoom_vel);

			// float t = Z.t(ct.m_FollowOffset.y, this.MinOffsetY, this.MaxOffsetY);
			float t = Z.t(GetFollowOffset().y, this.MinOffsetY, this.MaxOffsetY);
			float newFov = Z.lerp(this.MinFov, this.MaxFov, t);
			// VCam.m_Lens.FieldOfView = Z.lerp(VCam.m_Lens.FieldOfView, newFov, this.SmoothFov);
			SetFov(Z.lerp(GetFov(), newFov, this.SmoothFov));
		}
		void HandleEdgeScroll(float dt)
		{
			float EdgeScrollSpeed = this.MoveSpeed * 0.5f * (INPUT.K.HeldDown(KeyCode.LeftShift) ? 2f : 1f);

			Vector3 move_vel = Vector2.zero;
			if (INPUT.UI.pos.x < this.EdgeScrollPad) move_vel = -1 * this.transform.right * EdgeScrollSpeed;
			if (INPUT.UI.pos.y < this.EdgeScrollPad) move_vel = -1 * this.transform.forward * EdgeScrollSpeed;
			if (INPUT.UI.pos.x > INPUT.UI.size.x - this.EdgeScrollPad) move_vel = +1 * this.transform.right * EdgeScrollSpeed;
			if (INPUT.UI.pos.y > INPUT.UI.size.y - this.EdgeScrollPad) move_vel = +1 * this.transform.forward * EdgeScrollSpeed;

			this.transform.position += move_vel * dt;
		}

		[SerializeField] bool _enableCursorLockDuringRotation = true;
		void HandleCursorLock()
		{
			if (!_enableCursorLockDuringRotation)
				return;

			if (Input.GetMouseButtonDown(2))
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = true;
			}
			if (Input.GetMouseButtonUp(2))
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
	}
}