using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using SPACE_UTIL;
using SPACE_DrawSystem;

// Arcade top-down helicopter controls - simplified for action gameplay
namespace SPACE_IP
{
	public class IPHeliPhysicsAllArcade : MonoBehaviour
	{
		[Header("RigidBody, Cog")]
		[SerializeField] Rigidbody _rb;
		[SerializeField] Transform _cogTr;

		[Header("Arcade Properties")]
		[SerializeField] float _maxSpeed = 20f;
		[SerializeField] float _acceleration = 15f;
		[SerializeField] float _rotationSpeed = 180f; // degrees per second
		[SerializeField] float _maxAltitude = 30f; // height ceiling
		[SerializeField] float _hoverHeight = 15f; // default hover altitude
		[SerializeField] float _altitudeChangeSpeed = 8f;
		[SerializeField] float _drag = 5f;
		[SerializeField] float _angularDrag = 8f;

		[Header("Auto-Stabilization")]
		[SerializeField] float _autoStabilizeStrength = 10f;
		[SerializeField] float _autoLevelSpeed = 5f;

		[Header("Visual Effects")]
		[SerializeField] float _tiltAngleMax = 15f; // visual tilt when moving
		[SerializeField] Transform _heliVisualRoot; // for banking/tilting visuals

		[Header("Collection Reference")]
		[SerializeField] List<Rotor> ROTOR;
		[SerializeField] RotorBlur rotorBlur;

		[Header("Runtime State")]
		[SerializeField] Vector2 moveInput = Vector2.zero; // WASD
		[SerializeField] float altitudeInput = 0f; // up/down arrows (optional)
		[SerializeField] float currentAltitude = 15f;
		[SerializeField] float targetYaw = 0f;
		[SerializeField] float currRotorRPSFactor = 0f;
		[SerializeField] bool isGrounded = false;

		// Keep your existing Rotor and RotorBlur classes
		[System.Serializable]
		public class Rotor
		{
			public GameObject rotorObj = null;
			public int maxRPS = 10;
			public Vector3 localRotateAxis = new Vector3(0f, 1f, 0f);
			public float currAngle = 0f;

			public void RotateIncr(float incr)
			{
				this.currAngle = (this.currAngle + incr);
				this.rotorObj.transform.localRotation = Quaternion.Euler(this.localRotateAxis * currAngle);
			}
		}

		[System.Serializable]
		public class RotorBlur
		{
			public List<GameObject> objBLADEHolder;
			public List<GameObject> objBlurQUAD;
			[Range(0.1f, 0.95f)] public float minRPSFactor = 0.4f;
			public Material blurMat;
			public List<Texture> BLUR_TEX;

			public void alterVisual(float currRPSFactor)
			{
				if (currRPSFactor <= minRPSFactor)
				{
					foreach (var objBlade in this.objBLADEHolder) objBlade.toggle(true);
					foreach (var objBlurQuad in this.objBlurQUAD) objBlurQuad.toggle(false);
					return;
				}

				foreach (var objBlade in this.objBLADEHolder) objBlade.toggle(false);
				foreach (var objBlurQuad in this.objBlurQUAD) objBlurQuad.toggle(true);

				float maxRPSFactor = 1f;
				float t = (currRPSFactor - this.minRPSFactor) / (maxRPSFactor - this.minRPSFactor);
				int texIndex = C.round(t * (this.BLUR_TEX.Count - 1));
				this.blurMat.SetTexture("_BaseMap", this.BLUR_TEX[texIndex]);
			}
		}

		private void Awake()
		{
			Debug.Log(C.method(this));
			this._rb.drag = this._drag;
			this._rb.angularDrag = this._angularDrag;
			this.currentAltitude = this._hoverHeight;
		}

		private void FixedUpdate()
		{
			this.HandleArcadePhysics();
		}

		private void Update()
		{
			this.HandleInput();
			this.HandleRotorsVisual();
		}

		void HandleInput()
		{
			// Movement input (WASD) - direct 2D movement
			float horizontal = 0f;
			if (INPUT.K.HeldDown(KeyCode.D)) horizontal = +1f;
			if (INPUT.K.HeldDown(KeyCode.A)) horizontal = -1f;

			float vertical = 0f;
			if (INPUT.K.HeldDown(KeyCode.W)) vertical = +1f;
			if (INPUT.K.HeldDown(KeyCode.S)) vertical = -1f;

			this.moveInput = new Vector2(horizontal, vertical).normalized;

			// Optional altitude control (up/down arrows)
			this.altitudeInput = 0f;
			if (INPUT.K.HeldDown(KeyCode.UpArrow)) this.altitudeInput = +1f;
			if (INPUT.K.HeldDown(KeyCode.DownArrow)) this.altitudeInput = -1f;

			// Auto-start rotors when any input is given
			float targetRPS = (this.moveInput.magnitude > 0.01f || this.altitudeInput != 0f) ? 1f : 0.5f;
			this.currRotorRPSFactor = Z.lerp(this.currRotorRPSFactor, targetRPS, 2f * Time.deltaTime);
		}

		void HandleRotorsVisual()
		{
			// Rotate rotors based on RPS factor
			foreach (var rotor in this.ROTOR)
				rotor.RotateIncr(incr: (rotor.maxRPS * 360) * this.currRotorRPSFactor * Time.deltaTime);

			// Update blur effect
			this.rotorBlur.alterVisual(this.currRotorRPSFactor);
		}

		void HandleArcadePhysics()
		{
			this.HandleCogPos();
			this.HandleAltitude();
			this.HandleMovement();
			this.HandleRotationYaw();
			this.HandleRotationTilt();
			this.HandleAutoLevel();
		}
		void HandleCogPos()
		{
			this._rb.centerOfMass = this._cogTr.localPosition;
		}
		void HandleAltitude()
		{
			// Target altitude based on input or default hover
			float targetAltitude = this._hoverHeight;
			if (this.altitudeInput > 0f) targetAltitude = this._maxAltitude;
			if (this.altitudeInput < 0f) targetAltitude = 0f;

			// Smoothly approach target altitude
			this.currentAltitude = Z.lerp(this.currentAltitude, targetAltitude, this._altitudeChangeSpeed * Time.fixedDeltaTime);

			// Clamp to max altitude ceiling
			this.currentAltitude = Mathf.Clamp(this.currentAltitude, 0f, this._maxAltitude);

			// Apply altitude control (override gravity)
			float altitudeDelta = this.currentAltitude - this._rb.position.y;
			Vector3 altitudeForce = Vector3.up * altitudeDelta * this._autoStabilizeStrength;
			this._rb.AddForce(altitudeForce, ForceMode.Acceleration);

			// Damp vertical velocity for stability
			Vector3 vel = this._rb.velocity;
			vel.y *= 0.9f;
			this._rb.velocity = vel;

			// Check if grounded
			this.isGrounded = this._rb.position.y < 1f;
		}
		void HandleMovement()
		{
			if (this.moveInput.magnitude < 0.01f) return;

			// Convert 2D input to 3D world space (XZ plane)
			Vector3 moveDir = new Vector3(this.moveInput.x, 0f, this.moveInput.y);

			// Calculate desired velocity
			Vector3 targetVelocity = moveDir * this._maxSpeed;

			// Get current horizontal velocity
			Vector3 currentVelXZ = this._rb.velocity.xz();

			// Apply acceleration force toward target velocity
			Vector3 velocityDelta = targetVelocity - currentVelXZ;
			Vector3 accelForce = velocityDelta * this._acceleration;

			this._rb.AddForce(accelForce, ForceMode.Acceleration);
		}
		void HandleRotationYaw()
		{
			if (this.moveInput.magnitude < 0.01f) return;

			// Calculate target yaw angle from movement direction
			float targetAngle = Mathf.Atan2(this.moveInput.x, this.moveInput.y) * Mathf.Rad2Deg;

			// Smoothly rotate toward target angle
			float currentYaw = this._rb.rotation.eulerAngles.y;
			float newYaw = Mathf.MoveTowardsAngle(currentYaw, targetAngle, this._rotationSpeed * Time.fixedDeltaTime);

			// store the currAngle in a float(clamp if required), set rotation via Quaternion.Euler(vec3) Approach.

			// Apply rotation (keep pitch and roll at 0 for arcade feel)
			Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, newYaw, 0f));
			this._rb.MoveRotation(targetRotation);
		}
		void HandleRotationTilt()
		{
			if (this._heliVisualRoot == null) return;

			// Calculate visual tilt based on velocity (for immersion)
			Vector3 localVel = this._rb.transform.InverseTransformDirection(this._rb.velocity);

			float pitchTilt = -localVel.z / this._maxSpeed * this._tiltAngleMax;
			float rollTilt = localVel.x / this._maxSpeed * this._tiltAngleMax;

			// Apply smooth tilt to visual root only (not rigidbody)
			Quaternion targetTilt = Quaternion.Euler(pitchTilt, 0f, rollTilt);
			this._heliVisualRoot.localRotation = Quaternion.Slerp(
				this._heliVisualRoot.localRotation,
				targetTilt,
				10f * Time.fixedDeltaTime
			);
		}
		void HandleAutoLevel()
		{
			// Ensure helicopter stays upright (no flipping)
			Vector3 currentUp = this._rb.transform.up;
			float tiltAmount = Vector3.Angle(currentUp, Vector3.up);

			if (tiltAmount > 1f)
			{
				Vector3 correctiveTorque = Vector3.Cross(currentUp, Vector3.up);
				this._rb.AddTorque(correctiveTorque * this._autoLevelSpeed, ForceMode.Acceleration);
			}

			// Damp angular velocity
			this._rb.angularVelocity *= 0.95f;
		}
	}
}

/* ============================================
   IMPLEMENTATION NOTES FOR ARCADE MODE
   ============================================

1. AUTOMATIC SYSTEMS (No Manual Control):
   ✓ Rotor RPM - Auto-managed based on input
   ✓ Lift/Hover - Automatic altitude maintenance
   ✓ Yaw/Pedal - Auto-rotates to face movement direction
   ✓ Stabilization - Always keeps heli upright

2. PLAYER CONTROLS:
   ✓ WASD - Direct 2D movement (like tank/car)
   ✓ Up/Down Arrows (OPTIONAL) - Quick altitude adjust
   ✓ No collective, no cyclic pitch, no pedal

3. HEIGHT CEILING:
   ✓ Hard cap at _maxAltitude
   ✓ Default hover at _hoverHeight
   ✓ Smooth altitude transitions
   ✓ Can add proximity warning near ceiling

4. ARCADE FEATURES:
   ✓ No fuel management
   ✓ No complex blade physics
   ✓ Fast, responsive controls
   ✓ Visual tilt for immersion (not physics-based)
   ✓ Auto-stabilization prevents flipping

5. COMPARISON TO YOUR SIM VERSION:
   
   SIM MODE:
   - Manual collective (lift)
   - Manual cyclic (pitch/roll)
   - Manual pedal (yaw)
   - Realistic blade angles
   - Can flip/crash
   
   ARCADE MODE:
   - Auto everything
   - Direct movement input
   - Always stable
   - Max height limit
   - Can't flip

6. RECOMMENDED ADDITIONS:
   □ Speed boost ability
   □ Strafe movement (move sideways while facing forward)
   □ Soft collision/bounce instead of crash
   □ Screen shake on weapon fire
   □ Minimap with objectives

7. CAMERA SETUP:
   - Top-down orthographic OR
   - Isometric 45° angle OR
   - Follow camera at 60° angle
   - Fixed distance, smooth follow

============================================ */
