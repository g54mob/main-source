using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(Rigidbody))]
	public class VehicleController : MonoBehaviour
	{
		[Header("VehicleController")]
		[SerializeField]
		private bool ShowBoundsGizmo;

		public bool IsBicycle;

		public string VehicleName;

		public Wheel[] Wheels;

		public Transform COM;

		public MeshRenderer[] BaseViews;

		public Transform FirstPersonCameraPos;

		private VehicleSFX _VehicleSFX;

		private float LastCheckVisibleTime;

		private bool _VehicleIsVisible;

		public bool BlockVehicleControl { get; set; }

		public Rigidbody RB { get; private set; }

		public Bounds Bounds { get; private set; }

		public float Size { get; private set; }

		public bool IsPlayerVehicle { get; set; }

		public bool IsLocalVehicle { get; set; }

		public VehicleSFX VehicleSFX => null;

		public bool VehicleIsVisible => false;

		public bool VehicleIsGrounded { get; private set; }

		public float CurrentSpeed { get; private set; }

		public float SpeedInHour => 0f;

		public int VehicleDirection => 0;

		public float VelocityAngle { get; private set; }

		public float PrevVelocityAngle { get; private set; }

		public event Action<VehicleController, Collision> CollisionAction
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

		public event Action<VehicleController, Collision> CollisionStayAction
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

		public event Action BeforeResetVehicleAction
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

		public event Action AfterResetVehicleAction
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

		protected virtual void Awake()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		public virtual void OnCollisionEnter(Collision collision)
		{
		}

		public void OnCollisionStay(Collision collision)
		{
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
		}

		protected virtual void OnTriggerExit(Collider other)
		{
		}

		public virtual void ResetVehicle()
		{
		}

		public virtual void RestoreVehicle()
		{
		}

		protected virtual void OnDrawGizmosSelected()
		{
		}
	}
}
