using System.Collections.Generic;
using FIMSpace.Basics;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_SpiderMover2 : MonoBehaviour
	{
		private class SphereCaster
		{
			public RaycastHit[] alloc = new RaycastHit[8];

			public RaycastHit closest;

			public int hits;

			public void Reset()
			{
				hits = 0;
			}

			public void Cast(Vector3 rayStart, int step, Quaternion castOrientation, float spread, float sidesSpread, float radius, float distance, LayerMask mask, float sideRangeBoost, float forwardsRangeBoost, float originOffsetPower)
			{
				Vector3 direction = GetDirection(step, spread);
				direction.y = 0f;
				rayStart += castOrientation * (-direction.normalized * radius * originOffsetPower);
				Vector3 direction2 = GetDirection(step, spread, sidesSpread);
				if (step >= 1 && step <= 2)
				{
					distance *= sideRangeBoost;
				}
				else if (step >= 3 && step <= 4)
				{
					distance *= forwardsRangeBoost;
				}
				hits = Physics.SphereCastNonAlloc(rayStart, radius, castOrientation * direction2, alloc, distance, mask, QueryTriggerInteraction.Ignore);
				float num = float.MaxValue;
				for (int i = 0; i < hits; i++)
				{
					if (alloc[i].distance < num)
					{
						num = alloc[i].distance;
						closest = alloc[i];
					}
				}
			}

			public static Vector3 GetDirection(int step, float spread, float sidesSpread = 1f)
			{
				return step switch
				{
					0 => Vector3.down, 
					1 => FEngineering.GetAngleDirectionXY(180f + spread * sidesSpread), 
					2 => FEngineering.GetAngleDirectionXY(180f - spread * sidesSpread), 
					3 => FEngineering.GetAngleDirectionZY(180f + spread), 
					4 => FEngineering.GetAngleDirectionZY(180f - spread), 
					_ => Vector3.zero, 
				};
			}
		}

		private class RaycastCounter
		{
			public Vector3 normal;

			public int count;
		}

		public Fimp_JoystickInput JoystickInput;

		public Transform ToRotate;

		public Animator Mecanim;

		public bool StrafeMode;

		[Space(4f)]
		public float MovementSpeed = 2f;

		public float RotateToSpeed = 2f;

		[Space(4f)]
		public LayerMask GroundMask = 0;

		[Space(4f)]
		public float JumpPower = 3f;

		private Vector2 moveDirectionLocal;

		[Range(0f, 360f)]
		public float UpAxisAngle;

		private Quaternion raycastRotation = Quaternion.identity;

		private SphereCaster[] sphereCasters = new SphereCaster[5];

		[Header("Raycasting Setup")]
		public Vector3 OriginOffset = Vector3.up;

		[Range(0.01f, 0.5f)]
		public float RayRadius = 0.3f;

		[Range(0.05f, 1f)]
		public float RayDistance = 1f;

		[Range(0f, 45f)]
		public float AngleSpread = 30f;

		[Range(0.1f, 3f)]
		public float SidesSpread = 1f;

		[Range(1f, 2f)]
		public float SidesRangeBoost = 1f;

		[Range(1f, 2f)]
		public float ForwardsRangeBoost = 1f;

		[Range(-5f, 5f)]
		public float OriginOffsetPower = 1f;

		private int currentNormalIDs;

		private List<RaycastCounter> raycastCounters = new List<RaycastCounter>();

		private void Start()
		{
			if (ToRotate == null)
			{
				ToRotate = base.transform;
			}
			raycastRotation = base.transform.rotation;
			UpAxisAngle = base.transform.eulerAngles.y;
			ResetSpherecasters();
		}

		private void Update()
		{
			moveDirectionLocal = Vector2.zero;
			if (Input.GetKey(KeyCode.A))
			{
				moveDirectionLocal += Vector2.left;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				moveDirectionLocal += Vector2.right;
			}
			if (Input.GetKey(KeyCode.W))
			{
				moveDirectionLocal += Vector2.up;
			}
			else if (Input.GetKey(KeyCode.S))
			{
				moveDirectionLocal += Vector2.down;
			}
			if (JoystickInput.OutputValue != Vector2.zero)
			{
				moveDirectionLocal.x += JoystickInput.OutputValue.x;
				moveDirectionLocal.y += JoystickInput.OutputValue.y;
			}
			Vector3 zero = Vector3.zero;
			if (moveDirectionLocal != Vector2.zero)
			{
				moveDirectionLocal.Normalize();
				zero = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * new Vector3(moveDirectionLocal.x, 0f, moveDirectionLocal.y);
				UpAxisAngle = Quaternion.LookRotation(zero).eulerAngles.y;
				if ((bool)Mecanim)
				{
					Mecanim.SetBool("Moving", value: true);
				}
			}
			else if ((bool)Mecanim)
			{
				Mecanim.SetBool("Moving", value: false);
			}
			ProceedSpherecasts();
			ReInitializeRaycastCounterPool(sphereCasters.Length * sphereCasters[0].alloc.Length);
			Vector3 zero2 = Vector3.zero;
			for (int i = 0; i < sphereCasters.Length; i++)
			{
				if (sphereCasters[i].hits > 0)
				{
					RaycastHit closest = sphereCasters[i].closest;
					zero2 += closest.normal;
					AddRaycastCounterNormal(closest.normal);
				}
			}
			if (!(zero2 != Vector3.zero))
			{
				return;
			}
			zero2.Normalize();
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, zero2);
			raycastRotation = quaternion * Quaternion.AngleAxis(UpAxisAngle, Vector3.up);
			Vector3 zero3 = Vector3.zero;
			for (int j = 0; j < currentNormalIDs; j++)
			{
				for (int k = 0; k < raycastCounters[j].count; k++)
				{
					zero3 += raycastCounters[j].normal / ((float)k + 1f);
				}
			}
			zero3.Normalize();
			quaternion = Quaternion.FromToRotation(Vector3.up, zero3);
			ToRotate.rotation = quaternion * Quaternion.AngleAxis(UpAxisAngle, Vector3.up);
		}

		private void ResetSpherecasters()
		{
			for (int i = 0; i < 5; i++)
			{
				if (sphereCasters[i] == null)
				{
					sphereCasters[i] = new SphereCaster();
				}
				sphereCasters[i].Reset();
			}
		}

		private void ProceedSpherecasts()
		{
			Vector3 raycastsOrigin = GetRaycastsOrigin();
			float radius = RayRadius * base.transform.localScale.x;
			for (int i = 0; i < 5; i++)
			{
				sphereCasters[i].Cast(raycastsOrigin, i, raycastRotation, AngleSpread, SidesSpread, radius, RayDistance, GroundMask, SidesRangeBoost, ForwardsRangeBoost, OriginOffsetPower);
			}
		}

		private Vector3 GetRaycastsOrigin()
		{
			return base.transform.position + raycastRotation * Vector3.Scale(OriginOffset, base.transform.localScale);
		}

		private void ReloadRaycastCounter()
		{
			currentNormalIDs = 0;
		}

		private void ReInitializeRaycastCounterPool(int count)
		{
			ReloadRaycastCounter();
			if (raycastCounters.Count != count)
			{
				raycastCounters.Clear();
				for (int i = 0; i < count; i++)
				{
					raycastCounters.Add(new RaycastCounter());
				}
			}
		}

		private void AddRaycastCounterNormal(Vector3 normal)
		{
			for (int i = 0; i < currentNormalIDs; i++)
			{
				if (raycastCounters[i].normal == normal)
				{
					raycastCounters[i].count++;
					return;
				}
			}
			raycastCounters[currentNormalIDs].normal = normal;
			raycastCounters[currentNormalIDs].count = 1;
			currentNormalIDs++;
		}
	}
}
