using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace Polarith.AI.Package.Net
{
	[AddComponentMenu("Polarith AI » Examples/Network/Player Controller")]
	public sealed class PlayerController : NetworkBehaviour
	{
		[Tooltip("The maximum speed at which the player can travel.")]
		public float MaxSpeed = 3f;

		[Tooltip("The accelartion used to reach the target velocity.")]
		public float Acceleration = 1f;

		[Tooltip("The maximum available torque.")]
		public float Torque = 2f;

		[Tooltip("The multiplier for the boost effect. It is applied to both MaxSpeed and Acceleration.")]
		public float BoostMultiplier = 2f;

		[Tooltip("The duration of the boost effect in seconds.")]
		public float BoostDuration = 0.5f;

		[Tooltip("The cooldown in seconds for the boost effect.")]
		public float BoostCooldown = 3f;

		[Tooltip("The key for moving up.")]
		public KeyCode MoveUp = KeyCode.W;

		[Tooltip("The key for moving down.")]
		public KeyCode MoveDown = KeyCode.S;

		[Tooltip("The key for moving left.")]
		public KeyCode MoveLeft = KeyCode.A;

		[Tooltip("The key for moving right.")]
		public KeyCode MoveRight = KeyCode.D;

		[Tooltip("The key for activating the boost mode.")]
		public KeyCode Boost = KeyCode.Space;

		[Tooltip("A reference to the gameobject representing the local player. E.g. a Sprite or a Mesh.")]
		public GameObject SelfVis;

		[Tooltip("A reference to the gameobject representing the other players who joined the game. E.g. a Sprite or a Mesh.")]
		public GameObject OtherVis;

		[Tooltip("The template for the bullets the player can shoot.")]
		public GameObject BulletPrefab;

		[Tooltip("The velocity of the bullets.")]
		public float BulletSpeed = 10f;

		private Rigidbody2D body;

		private Vector3 position;

		private float boostTimer;

		private float boost = 1f;

		private float fireDelayTime;

		private int acc;

		private int strafe;

		private bool isBoost;

		public override void OnStartLocalPlayer()
		{
			if (SelfVis != null)
			{
				SelfVis.SetActive(value: true);
			}
			if (OtherVis != null)
			{
				OtherVis.SetActive(value: false);
			}
		}

		private void Start()
		{
			body = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			if (base.isLocalPlayer)
			{
				if (Input.GetMouseButton(0) && fireDelayTime >= 0.2f)
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					new Plane(Vector3.forward, new Vector3(0f, 0f, 0f)).Raycast(ray, out var enter);
					position = ray.GetPoint(enter);
					CmdFire((position - base.transform.position).normalized);
					fireDelayTime = 0f;
				}
				if (Input.GetKey(MoveUp))
				{
					acc = 1;
				}
				else if (Input.GetKey(MoveDown))
				{
					acc = -1;
				}
				else if (!Input.GetKey(MoveUp) && !Input.GetKey(MoveDown))
				{
					acc = 0;
				}
				if (Input.GetKey(MoveLeft))
				{
					strafe = 1;
				}
				else if (Input.GetKey(MoveRight))
				{
					strafe = -1;
				}
				else if (!Input.GetKey(MoveLeft) && !Input.GetKey(MoveRight))
				{
					strafe = 0;
				}
				if (Input.GetKey(Boost) && !isBoost && boostTimer >= BoostCooldown)
				{
					boost = BoostMultiplier;
					isBoost = true;
					boostTimer = 0f;
				}
				if (isBoost && boostTimer >= BoostDuration)
				{
					isBoost = false;
					boost = 1f;
					boostTimer = 0f;
				}
				boostTimer += Time.deltaTime;
				fireDelayTime += Time.deltaTime;
			}
		}

		private void FixedUpdate()
		{
			if (acc > 0)
			{
				body.AddForce(Vector3.up * Acceleration * boost);
			}
			if (acc < 0)
			{
				body.AddForce(Vector3.up * (0f - Acceleration) * boost);
			}
			if (strafe > 0)
			{
				body.AddForce(Vector3.right * (0f - Acceleration) * boost);
			}
			if (strafe < 0)
			{
				body.AddForce(Vector3.right * Acceleration * boost);
			}
			float magnitude = body.velocity.magnitude;
			if (magnitude >= MaxSpeed * boost)
			{
				body.velocity *= MaxSpeed * boost / magnitude;
			}
			Vector3 to = position - base.transform.position;
			to.Normalize();
			float num = Vector3.Angle(base.transform.up, to);
			if (num >= 10f)
			{
				Vector3 vector = Quaternion.Inverse(base.transform.rotation) * base.transform.position;
				Vector3 vector2 = Quaternion.Inverse(base.transform.rotation) * position;
				if (vector.x > vector2.x)
				{
					body.AddTorque(num * Torque);
				}
				else
				{
					body.AddTorque((0f - num) * Torque);
				}
			}
		}

		[Command]
		private void CmdFire(Vector3 dir)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(dir);
			SendCommandInternal("System.Void Polarith.AI.Package.Net.PlayerController::CmdFire(UnityEngine.Vector3)", -1672288295, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdFire__Vector3(Vector3 dir)
		{
			GameObject obj = Object.Instantiate(BulletPrefab, base.transform.position, Quaternion.identity);
			obj.GetComponent<Rigidbody2D>().velocity = dir * BulletSpeed;
			NetworkServer.Spawn(obj);
			Object.Destroy(obj, 4f);
		}

		protected static void InvokeUserCode_CmdFire__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdFire called on client.");
			}
			else
			{
				((PlayerController)obj).UserCode_CmdFire__Vector3(reader.ReadVector3());
			}
		}

		static PlayerController()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(PlayerController), "System.Void Polarith.AI.Package.Net.PlayerController::CmdFire(UnityEngine.Vector3)", InvokeUserCode_CmdFire__Vector3, requiresAuthority: true);
		}
	}
}
