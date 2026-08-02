using UnityEngine;
using UnityEngine.Events;

namespace JUTPS.WeaponSystem
{
	[RequireComponent(typeof(Weapon))]
	[AddComponentMenu("JU TPS/Weapon System/Prevent Gun Clipping")]
	public class PreventGunClipping : MonoBehaviour
	{
		private Weapon gun;

		private int startGunWieldingID;

		private WeaponAimRotationCenter center;

		private Transform GunWieldTransform;

		private float distanceCenterToWieldPosition;

		[Header("Settings")]
		public int ToUpDirectionWieldingID;

		public float RayDistance = 0.5f;

		public bool BlockGunFireOnPreventClipping = true;

		public LayerMask WallsLayer;

		public RaycastHit ClippingWallHit;

		[Header("State")]
		public bool IsPreventing;

		[Header("Events")]
		public UnityEvent OnPrevent;

		public UnityEvent OnStopPrevent;

		private bool calledPrevent;

		private bool calledStopPrevent;

		private void Start()
		{
			gun = GetComponent<Weapon>();
			if (gun != null)
			{
				startGunWieldingID = gun.ItemWieldPositionID;
			}
			center = ((gun.Owner != null) ? gun.Owner.GetComponentInChildren<WeaponAimRotationCenter>() : null);
			if (center != null)
			{
				GunWieldTransform = center.WeaponPositionTransform[startGunWieldingID];
			}
			if ((int)WallsLayer == 0)
			{
				WallsLayer = LayerMask.GetMask("Default", "Terrain", "Walls", "VehicleMeshCollider", "Vehicle", "TrainGround");
			}
			OnPrevent.AddListener(SetPreventWieldingID);
			OnStopPrevent.AddListener(SetNormalWieldingID);
		}

		private void Update()
		{
			if (!(gun == null) && !(center == null))
			{
				distanceCenterToWieldPosition = Vector3.Distance(GunWieldTransform.position, center.transform.position);
				Vector3 origin = GunWieldTransform.position - center.transform.forward * distanceCenterToWieldPosition;
				IsPreventing = Physics.Raycast(origin, center.transform.forward, out ClippingWallHit, RayDistance + distanceCenterToWieldPosition, WallsLayer);
				if (BlockGunFireOnPreventClipping && IsPreventing)
				{
					gun.CanUseItem = false;
				}
				if (IsPreventing && !calledPrevent)
				{
					OnPrevent.Invoke();
					calledPrevent = true;
					calledStopPrevent = false;
				}
				if (!IsPreventing && !calledStopPrevent)
				{
					OnStopPrevent.Invoke();
					calledPrevent = false;
					calledStopPrevent = true;
				}
			}
		}

		public void SetPreventWieldingID()
		{
			gun.ItemWieldPositionID = ToUpDirectionWieldingID;
		}

		public void SetNormalWieldingID()
		{
			gun.ItemWieldPositionID = startGunWieldingID;
		}

		private void OnDrawGizmos()
		{
			if (gun != null && gun.TPSOwner != null)
			{
				Gizmos.color = Color.cyan;
				Vector3 vector = GunWieldTransform.position - center.transform.forward * distanceCenterToWieldPosition;
				Gizmos.DrawLine(vector, vector + center.transform.forward * RayDistance);
			}
		}
	}
}
