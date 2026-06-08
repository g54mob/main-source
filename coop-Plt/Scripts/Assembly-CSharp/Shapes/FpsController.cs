using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	[ExecuteAlways]
	public class FpsController : ImmediateModeShapeDrawer
	{
		public Transform head;

		public Camera cam;

		public Crosshair crosshair;

		public ChargeBar chargeBar;

		public AmmoBar ammoBar;

		public Compass compass;

		public Transform crosshairTransform;

		[Header("Player Movement")]
		[Range(0.8f, 1f)]
		public float smoof = 0.99f;

		public float moveSpeed = 1f;

		public float lookSensitivity = 1f;

		private float yaw;

		private float pitch;

		private Vector2 moveInput = Vector2.zero;

		private Vector3 moveVel = Vector3.zero;

		[Header("Sidebar Style")]
		[Range(0f, (float)Math.PI)]
		public float ammoBarAngularSpanRad;

		[Range(0f, 0.05f)]
		public float ammoBarOutlineThickness = 0.1f;

		[Range(0f, 0.2f)]
		public float ammoBarThickness;

		[Range(0f, 0.2f)]
		public float ammoBarRadius;

		[Header("Animation")]
		[Range(0f, 0.3f)]
		public float fireSidebarRadiusPunchAmount = 0.1f;

		public AnimationCurve shakeAnimX = AnimationCurve.Constant(0f, 1f, 0f);

		public AnimationCurve shakeAnimY = AnimationCurve.Constant(0f, 1f, 0f);

		private bool InputFocus
		{
			get
			{
				return !Cursor.visible;
			}
			set
			{
				Cursor.lockState = (value ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !value;
			}
		}

		private void Awake()
		{
			if (Application.isPlaying)
			{
				InputFocus = true;
				StartCoroutine(FixedSteps());
			}
		}

		public override void DrawShapes(Camera cam)
		{
			if (cam != this.cam)
			{
				return;
			}
			using (Draw.Command(cam))
			{
				Draw.ZTest = CompareFunction.Always;
				Draw.Matrix = crosshairTransform.localToWorldMatrix;
				Draw.BlendMode = ShapesBlendMode.Transparent;
				Draw.LineGeometry = LineGeometry.Flat2D;
				crosshair.DrawCrosshair();
				float barRadius = ammoBarRadius + fireSidebarRadiusPunchAmount * crosshair.fireDecayer.value;
				ammoBar.DrawBar(this, barRadius);
				chargeBar.DrawBar(this, barRadius);
				compass.DrawCompass(head.transform.forward);
			}
		}

		private IEnumerator FixedSteps()
		{
			while (true)
			{
				FixedUpdateManual();
				yield return new WaitForSeconds(0.01f);
			}
		}

		public static void DrawRoundedArcOutline(Vector2 origin, float radius, float thickness, float outlineThickness, float angStart, float angEnd)
		{
			float radius2 = radius - thickness / 2f;
			float radius3 = radius + thickness / 2f;
			Draw.Arc(origin, radius2, outlineThickness, angStart - 0.01f, angEnd + 0.01f);
			Draw.Arc(origin, radius3, outlineThickness, angStart - 0.01f, angEnd + 0.01f);
			Vector2 vector = origin + ShapesMath.AngToDir(angStart) * radius;
			Vector2 vector2 = origin + ShapesMath.AngToDir(angEnd) * radius;
			Draw.Arc(vector, thickness / 2f, outlineThickness, angStart, angStart - (float)Math.PI);
			Draw.Arc(vector2, thickness / 2f, outlineThickness, angEnd, angEnd + (float)Math.PI);
		}

		public Vector2 GetShake(float speed, float amp)
		{
			float time = ShapesMath.Frac(Time.time * speed);
			float x = shakeAnimX.Evaluate(time);
			float y = shakeAnimY.Evaluate(time);
			return new Vector2(x, y) * amp;
		}

		private void FixedUpdateManual()
		{
			if (Application.isPlaying)
			{
				if (InputFocus)
				{
					Vector3 right = head.right;
					Vector3 forward = head.forward;
					forward.y = 0f;
					moveVel += (moveInput.y * forward + moveInput.x * right) * (Time.fixedDeltaTime * moveSpeed);
				}
				base.transform.position += moveVel * Time.deltaTime;
				moveVel *= smoof;
			}
		}

		private void Update()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			crosshair.UpdateCrosshairDecay();
			chargeBar.UpdateCharge();
			if (InputFocus)
			{
				yaw += Input.GetAxis("Mouse X") * lookSensitivity;
				pitch -= Input.GetAxis("Mouse Y") * lookSensitivity;
				pitch = Mathf.Clamp(pitch, -90f, 90f);
				head.localRotation = Quaternion.Euler(pitch, yaw, 0f);
				chargeBar.isCharging = Input.GetMouseButton(1);
				if (Input.GetKey(KeyCode.R))
				{
					ammoBar.Reload();
				}
				if (Input.GetMouseButtonDown(0) && ammoBar.HasBulletsLeft)
				{
					ammoBar.Fire();
					crosshair.Fire();
					if (Physics.Raycast(new Ray(head.transform.position, head.transform.forward), float.PositiveInfinity, 512))
					{
						crosshair.FireHit();
					}
				}
				moveInput = Vector2.zero;
				DoInput(KeyCode.W, Vector2.up);
				DoInput(KeyCode.S, Vector2.down);
				DoInput(KeyCode.D, Vector2.right);
				DoInput(KeyCode.A, Vector2.left);
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					InputFocus = false;
				}
			}
			else if (Input.GetMouseButtonDown(0))
			{
				InputFocus = true;
			}
			void DoInput(KeyCode key, Vector2 dir)
			{
				if (Input.GetKey(key))
				{
					moveInput += dir;
				}
			}
		}
	}
}
