using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using SPACE_UTIL;
using SPACE_DrawSystem;

// a helicopter rider, conditions for riding: provided externally
namespace SPACE_IP
{
	public class IPHeliPhysicsAll : MonoBehaviour
	{
		[Header("RigidBody, Cog")]
		[SerializeField] Rigidbody _rb;
		[SerializeField] Transform _cogTr;

		[Header("Properties")]
		[SerializeField] float _currRotorRpsIncrFactor = 0.7f;
		[SerializeField] float _liftForceMultiplier = 1.8f;
		[SerializeField] float _pedalTorqueMultiplier = 3f;
		[SerializeField] float _cyclicTorqueMultiplier = 2.3f;
		[SerializeField] float _cyclicForceMultiplier = 24f;
		[SerializeField] float _maxCyclicVelocity = 15f;
		[SerializeField] float _autoLevelMultiplier = 7f;

		[Header("Collection Reference")]
		[SerializeField] List<Rotor> ROTOR;
		[SerializeField] List<Blade> BLADE;

		[Header("just to log")]
		// [SerializeField] float currHP; // not required
		[SerializeField] float dotForward, dotRight;

		[Space]
		[SerializeField] float horizontal = 0f; // input: d a
		[SerializeField] float vertical = 0f; // input: w s
		[SerializeField] float throttleInput = 0f; // = -
		[SerializeField] float stickyThrottle = 0f;
		[SerializeField] float pedalInput = 0f; // right left 
		[SerializeField] float collectiveInput = 0f; // up down
		[SerializeField] Vector2 cyclicInput = new Vector2(0, 0); // w s d a

		[System.Serializable]
		public class Rotor
		{
			public GameObject rotorObj = null;
			public int maxRPS = 10;
			public Vector3 localRotateAxis = new Vector3(0f, 1f, 0f);
			public float currAngle = 0f;
			public float currAngleIncr = 0f;

			public float getCurrAngleIncr
			{
				get { return this.currAngleIncr; }
			}

			public void currAngleIncrTowardSticky(float sticky, float t)
			{
				/*
				float currAngleIncr_Incr  = t;
				int dir = (sticky - currAngleIncr).sign();
				float nextAngleIncr = (this.currAngleIncr + dir * currAngleIncr_Incr);
				if (dir * nextAngleIncr > dir * sticky)
					nextAngleIncr = sticky;
				this.currAngleIncr = nextAngleIncr;
				*/

				this.currAngleIncr = Z.lerp(this.currAngleIncr, sticky, t).approxZero();
			}

			public void RotateIncr(float incr)
			{
				this.currAngle = (this.currAngle + incr); // increment angle, clamp  if necessary
				this.rotorObj.transform.localRotation = Quaternion.Euler(this.localRotateAxis * currAngle); // apply angle to .rotation via Quaternion.Euler(axis * angle)
			}


			/*
				a cyclic group
					bladeHodler
					blurQuad
			*/
			public bool blurAtHighRps = true;
			public List<GameObject> objBLADEHolder;
			public List<GameObject> objBlurQUAD;

			[Range(0.1f, 0.95f)] public float minRpsFactor = 0.4f, maxRpsFactor = 0.95f;
			public Material blurMat;
			public List<Texture> BLUR_TEX;

			public void alterVisual(float currRPSFactor)
			{
				if (this.blurAtHighRps == false)
					return;

				if (currRPSFactor <= minRpsFactor)
				{
					foreach (var objBlade in this.objBLADEHolder) objBlade.toggle(true);
					foreach (var objBlurQuad in this.objBlurQUAD) objBlurQuad.toggle(false);
					return;
				}

				foreach (var objBlade in this.objBLADEHolder) objBlade.toggle(!true);
				foreach (var objBlurQuad in this.objBlurQUAD) objBlurQuad.toggle(!false);

				float t = (currRPSFactor - this.minRpsFactor) / (maxRpsFactor - this.minRpsFactor);
				t = t.clamp(0f, 1f);
				int texIndex = C.round(t * (this.BLUR_TEX.Count - 1));
				Debug.Log(C.method(null, "cyan", $"texIndex: {texIndex}, t: {t}"));

				this.blurMat.SetTexture("_BaseMap", this.BLUR_TEX[texIndex]);
			}
		}
		[System.Serializable]
		public class Blade
		{
			public enum IntakeInputType
			{
				head, tail
			}

			public GameObject bladeObj = null;
			public int minAngle = -10;
			public int maxAngle = 30;
			public Vector3 localRotateAxis = new Vector3(1f, 0f, 0f);
			public float RPS = 10f;
			public IntakeInputType intakeInputType = IntakeInputType.head;
			public float currAngle = 0f;
			//
			public void RotateIncrAndClamp(float incr)
			{
				#region gimbal lock -90 to +90 if altered euler angles directly
				//blade.bladeObj.transform.localEulerAngles += this.collectiveInput * 10 * Time.deltaTime * blade.localRotateAxis; 

				//blade.bladeObj.transform.localRotation = blade.bladeObj.transform.localRotation
				//				.rotateAndClamp(blade.localRotateAxis, this.collectiveInput * 10 * Time.deltaTime * 10, -360, +360);
				#endregion
				this.currAngle = (this.currAngle + incr).clamp(this.minAngle, this.maxAngle); // increment angle, clamp  if necessary
				this.bladeObj.transform.localRotation = Quaternion.Euler(this.localRotateAxis * currAngle); // apply angle to .rotation via Quaternion.Euler(axis * angle)
			}
			public float getAngleFactor // 0 to 1
			{
				get
				{
					return (this.currAngle - minAngle) / (this.maxAngle - this.minAngle);
				}
			}
		}

		float currSceneTime = 0f;
		private void Awake()
		{
			Debug.Log(C.method(this));
			this.currSceneTime = 0f;
		}

		/* ==== Unity Life Cycle ==== >>
		INITIALIZATION PHASE
		├─ Awake()           → Called when script instance is loaded (even if disabled)
		├─ OnEnable()        → Called when object/component becomes enabled
		└─ Start()           → Called before first frame update (only if enabled)

		PHYSICS LOOP (Fixed Timestep - Default 0.02s)
		├─ FixedUpdate()     → Called at fixed intervals for physics
		└─ Internal Physics Update

		GAME LOOP (Per Frame)
		├─ Update()          → Called once per frame (main logic)
		├─ LateUpdate()      → Called after all Updates (cameras, follow systems)
		├─ Animation Events  → Triggered during animation playback
		└─ Animation Rigging → IK and rig calculations

		RENDERING
		├─ OnWillRenderObject()
		├─ OnPreCull()
		├─ OnBecameVisible() / OnBecameInvisible()
		├─ OnPreRender()
		├─ OnRenderObject()
		└─ OnPostRender()

		COLLISION/TRIGGER DETECTION
		├─ OnCollisionEnter/Stay/Exit()
		├─ OnTriggerEnter/Stay/Exit()
		├─ OnCollisionEnter2D/Stay2D/Exit2D()
		└─ OnTriggerEnter2D/Stay2D/Exit2D()

		DEINITIALIZATION PHASE
		├─ OnDisable()       → Called when object/component becomes disabled
		├─ OnDestroy()       → Called when object is destroyed
		└─ OnApplicationQuit() → Global, called before application quits
		<< ==== Unity Life Cycle ==== */
		private void FixedUpdate()
		{
			this.HandlePhysics();
		}

		private void Update()
		{
			this.HandleInput();
			this.HandleRotorsAndBladesVisual();
			//
			this.currSceneTime += Time.unscaledDeltaTime;
		}

		void HandleInput()
		{
			this.horizontal = 0f;
			if (INPUT.K.HeldDown(KeyCode.D)) this.horizontal = +1f;
			if (INPUT.K.HeldDown(KeyCode.A)) this.horizontal = -1f;

			this.vertical = 0f;
			if (INPUT.K.HeldDown(KeyCode.W)) this.vertical = +1f;
			if (INPUT.K.HeldDown(KeyCode.S)) this.vertical = -1f;

			this.cyclicInput = new Vector2(this.horizontal, this.vertical);

			this.pedalInput = 0f;
			if (INPUT.K.HeldDown(KeyCode.LeftArrow)) this.pedalInput = +1f;
			if (INPUT.K.HeldDown(KeyCode.RightArrow)) this.pedalInput = -1f;

			this.collectiveInput = 0f;
			if (INPUT.K.HeldDown(KeyCode.UpArrow)) this.collectiveInput = +1f;
			if (INPUT.K.HeldDown(KeyCode.DownArrow)) this.collectiveInput = -1f;

			this.throttleInput = 0f;
			if (INPUT.K.HeldDown(KeyCode.Equals)) this.throttleInput = +1f;
			if (INPUT.K.HeldDown(KeyCode.Minus)) this.throttleInput = -1f;

			// sticky throttle
			if (this.throttleInput > 0f) this.stickyThrottle = 1f;
			else if (this.throttleInput < 0f) this.stickyThrottle = 0f;

			// currHP, currRPSFactor
			// sticky val, curr val approach >>
			// this.currHP = Z.lerp(this.currHP, this.stickyThrottle * this._maxHP, this._powerDelayIncr * Time.deltaTime).approxZero(1e-4);
			// this.currRotorRpsFactor = Z.lerp(this.currRotorRpsFactor, this.stickyThrottle, this._currRotorRpsIncrFactor * Time.deltaTime).approxZero(1e-4);
			
			// << sticky val, curr val approach
			// Debug.Log($"stickyThrottle: {this.stickyThrottle}, hp/rpsFactor: {this.currHP}/{this.currRPSFactor}".colorTag("cyan"));
		}
		void HandleRotorsAndBladesVisual()
		{
			// rotor
			foreach (var rotor in this.ROTOR)
			{
				rotor.currAngleIncrTowardSticky(this.stickyThrottle, this._currRotorRpsIncrFactor * Time.deltaTime);
				// currAngleIncr is based of stickyThrottle, which is based of throttleInput
				rotor.RotateIncr(incr: (rotor.maxRPS * 360) * rotor.getCurrAngleIncr.pow(1) * Time.deltaTime);
				// activate blur after certain min currAngleIncr
				rotor.alterVisual(rotor.getCurrAngleIncr);
			}
			// blade
			foreach (var blade in this.BLADE) // no clamping yet -> done with clamping approach for .rotation via Quaternion.Euler(axis * angle)
			{
				if (blade.intakeInputType == Blade.IntakeInputType.head)
					blade.RotateIncrAndClamp(incr: (blade.RPS * 360) * this.collectiveInput * Time.deltaTime);
				/*
				else if(blade.intakeInputType == Blade.IntakeInputType.tail)
					blade.RotateIncrAndClamp(incr: (blade.RPS * 360) * this.pedalInput * Time.deltaTime);
				*/
			}
		}

		void HandlePhysics()
		{
			this.HandleCogPos();
			this.HandleLiftForce();
			this.HandlePedalTorque();
			this.HandleCyclicTorque();
			this.HandleCyclicForce_0(); // this.HandleCyclicForce_1(); // this.HandleCyclicForce_2(); // this.HandleCyclicForce_3();

			this.CalculateAngles();
			this.HandleAutoLevelTorque();
		}
		void HandleCogPos()
		{
			this._rb.centerOfMass = this._cogTr.localPosition;
		}
		void HandleLiftForce()
		{
			Debug.Log(C.method(null, "cyan"));
			// TODO Fix: Debug.Log(C.method("cyan")); // result log shall be: "method() -> C -> UTIL.cs" => Done
			Vector3 liftForce = Vector3.up * Physics.gravity.magnitude * this._rb.mass;
			float multiplier = this.ROTOR[0].getCurrAngleIncr * this.BLADE[0].getAngleFactor.pow(4) * this._liftForceMultiplier;
			this._rb.AddRelativeForce(liftForce * multiplier, ForceMode.Force);
		}
		void HandlePedalTorque()
		{
			Debug.Log(C.method(null, "cyan"));
			float multiplier = this._pedalTorqueMultiplier * this.pedalInput.powSign(2);
			this._rb.AddRelativeTorque(-Vector3.up * multiplier, ForceMode.Acceleration); // apply acceleration instead of force
		}
		void HandleCyclicTorque()
		{
			Debug.Log(C.method(null, "cyan"));
			// z rotation
			this._rb.AddRelativeTorque(-Vector3.forward * this.cyclicInput.x.powSign(1) * this._cyclicTorqueMultiplier, ForceMode.Acceleration);

			// x rotation
			this._rb.AddRelativeTorque(Vector3.right * this.cyclicInput.y.powSign(1) * this._cyclicTorqueMultiplier, ForceMode.Acceleration);

		}
		void HandleCyclicForce_0()
		{
			if (this._rb.velocity.xz().magnitude < this._maxCyclicVelocity)
			{
				Vector3 cyclicForce = this._rb.transform.forward.xz().normalizedZero() * this.dotForward.abs() * this.cyclicInput.y.powSign(2) +
									  this._rb.transform.right.xz().normalizedZero() * this.dotRight.abs() * this.cyclicInput.x.powSign(2);
				cyclicForce = Vector3.ClampMagnitude(cyclicForce, 1f);
				this._rb.AddForce(cyclicForce * this._cyclicForceMultiplier, ForceMode.Acceleration);
			}
		}
		#region ad
		void HandleCyclicForce_1()
		{
			// add force along the cyclic
			Vector3 cyclicForce =
				this._rb.transform.forward.xz().normalizedZero() * this.dotForward
			  + this._rb.transform.right.xz().normalizedZero() * this.dotRight;
			this._rb.AddRelativeForce(Vector3.ClampMagnitude(cyclicForce, 1f) * _cyclicForceMultiplier * _cyclicTorqueMultiplier, ForceMode.Acceleration);
		}
		void HandleCyclicForce_2()
		{
			if (this._rb.velocity.xz().magnitude < this._maxCyclicVelocity)
			{
				// Smooth the squared response
				float forwardInput = Mathf.Pow(Mathf.Abs(this.cyclicInput.y), 2f) * Mathf.Sign(this.cyclicInput.y);
				float rightInput = Mathf.Pow(Mathf.Abs(this.cyclicInput.x), 2f) * Mathf.Sign(this.cyclicInput.x);

				Vector3 cyclicForce =
					this._rb.transform.forward.xz().normalizedZero() * this.dotForward.abs() * forwardInput +
					this._rb.transform.right.xz().normalizedZero() * this.dotRight.abs() * rightInput;

				cyclicForce = Vector3.ClampMagnitude(cyclicForce, 1f);
				Debug.Log(C.method(null, "cyan", cyclicForce.ToString()));
				this._rb.AddRelativeForce(cyclicForce * this._cyclicForceMultiplier, ForceMode.Acceleration);
			}
		}
		void HandleCyclicForce_3()
		{
			Vector3 cyclicForce = Vector3.forward * this.dotForward.abs() * this.cyclicInput.y +
								  Vector3.right * this.dotRight.abs() * this.cyclicInput.x;
			cyclicForce = Vector3.ClampMagnitude(cyclicForce, 1f);
			this._rb.AddRelativeForce(cyclicForce * this._cyclicForceMultiplier, ForceMode.Acceleration);
		}
		#endregion

		/// <summary>
		/// dot with the .xz() of front, right with the transform.up
		/// </summary>
		void CalculateAngles()
		{
			Debug.Log(C.method(null, "cyan"));
			this.dotForward = Z.dot(this._rb.transform.forward.xz().normalizedZero(), this._rb.transform.up);
			this.dotRight = Z.dot(this._rb.transform.right.xz().normalizedZero(), this._rb.transform.up);

			// just to log >>
			#region Line
			Vector3 flatFwd = this._rb.transform.forward.xz().normalizedZero();
			Vector3 flatRight = this._rb.transform.right.xz().normalizedZero();
			Line.create(id: "flatRightLine").setA(this._rb.transform.position).setN(flatRight * 3f).setCol(Color.red);
			Line.create(id: "flatFwdLine").setA(this._rb.transform.position).setN(flatFwd * 3f).setCol(Color.blue); 
			#endregion
			// << just to log
		}
		void HandleAutoLevelTorque()
		{
			Debug.Log(C.method(null, "cyan"));
			this._rb.AddRelativeTorque(Vector3.forward * this.dotRight * this._autoLevelMultiplier, ForceMode.Acceleration);
			this._rb.AddRelativeTorque(-Vector3.right * this.dotForward * this._autoLevelMultiplier, ForceMode.Acceleration);
		}

		private void OnApplicationQuit()
		{
			Debug.Log(C.method(this, "orange"));
			// SaveGameData >>
			GameStore.playerStats.HISTORY.Add(this.currSceneTime.roundDecimal(2));
			GameStore.playerStats.gameTime = (GameStore.playerStats.gameTime + this.currSceneTime).roundDecimal(2);
			GameStore.playerStats.SaveGameData();
			// << SaveGameData
		}
	}
}