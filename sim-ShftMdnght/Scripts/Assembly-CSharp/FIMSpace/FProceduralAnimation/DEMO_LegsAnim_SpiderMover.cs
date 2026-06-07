using System.Collections.Generic;
using FIMSpace.Basics;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_SpiderMover : MonoBehaviour
	{
		private class SpiderRaycaster
		{
			public RaycastHit firstHit;

			public RaycastHit secondaryHit;

			public RaycastHit lastDetectedFirst;

			public RaycastHit lastDetectedSec;

			public Vector3 lastFirstHitLocal;

			public Vector3 lastSecHitLocal;

			public bool anyHit;

			public void Reset()
			{
				firstHit = default(RaycastHit);
				secondaryHit = default(RaycastHit);
				lastDetectedFirst = default(RaycastHit);
				lastDetectedSec = default(RaycastHit);
				lastFirstHitLocal = Vector3.zero;
				lastSecHitLocal = Vector3.zero;
				anyHit = false;
			}

			public void Cast(Vector3 rayStart, int step, DEMO_LegsAnim_SpiderMover mover)
			{
				anyHit = false;
				Vector3 direction = GetDirection(step, mover);
				Vector3 vector = mover.raycastRotation * direction;
				direction.y = 0f;
				Vector3 raycastPoint = GetRaycastPoint00(rayStart, vector, mover.raycastRotation * direction, mover);
				Vector3 raycastPoint2 = GetRaycastPoint01(rayStart, vector, mover);
				if (Physics.Linecast(raycastPoint, raycastPoint2, out firstHit, mover.GroundMask, QueryTriggerInteraction.Ignore))
				{
					anyHit = true;
					lastDetectedFirst = firstHit;
					lastFirstHitLocal = mover.InversePoint(firstHit.point);
				}
				else if (lastDetectedFirst.distance > 0f)
				{
					if (Vector3.Distance(mover.TransformPoint(lastFirstHitLocal), lastDetectedFirst.point) < mover.HitMemoryDistance)
					{
						firstHit = lastDetectedFirst;
					}
					else
					{
						lastDetectedFirst = default(RaycastHit);
					}
				}
				raycastPoint = GetRaycastPoint10(rayStart, vector, mover);
				raycastPoint2 = GetRaycastPoint11(step, raycastPoint, mover);
				if (Physics.Linecast(raycastPoint, raycastPoint2, out secondaryHit, mover.GroundMask, QueryTriggerInteraction.Ignore))
				{
					anyHit = true;
					lastDetectedSec = secondaryHit;
					lastSecHitLocal = mover.InversePoint(secondaryHit.point);
				}
				else if (lastDetectedSec.distance > 0f)
				{
					if (Vector3.Distance(mover.TransformPoint(lastSecHitLocal), lastDetectedSec.point) < mover.HitMemoryDistance)
					{
						secondaryHit = lastDetectedSec;
					}
					else
					{
						lastDetectedSec = default(RaycastHit);
					}
				}
			}

			public static Vector3 GetDirection(int step, DEMO_LegsAnim_SpiderMover mover)
			{
				return step switch
				{
					0 => Vector3.down, 
					1 => FEngineering.GetAngleDirectionYZ(0f - mover.FirstAngle), 
					2 => FEngineering.GetAngleDirectionYZ(180f + mover.FirstAngle), 
					3 => FEngineering.GetAngleDirectionYX((0f - mover.FirstAngle) * mover.CollapseSides), 
					4 => FEngineering.GetAngleDirectionYX(180f + mover.FirstAngle * mover.CollapseSides), 
					_ => Vector3.zero, 
				};
			}

			public static Vector3 GetDirection2(int step, DEMO_LegsAnim_SpiderMover mover)
			{
				return step switch
				{
					0 => Vector3.down, 
					1 => FEngineering.GetAngleDirectionYZ(270f - mover.SecondAngle), 
					2 => FEngineering.GetAngleDirectionYZ(270f + mover.SecondAngle), 
					3 => FEngineering.GetAngleDirectionYX(270f - mover.SecondAngle * Mathf.Lerp(0.5f, 1f, mover.CollapseSides)), 
					4 => FEngineering.GetAngleDirectionYX(270f + mover.SecondAngle * Mathf.Lerp(0.5f, 1f, mover.CollapseSides)), 
					_ => Vector3.zero, 
				};
			}

			public Vector3 GetRaycastDir1(int step, DEMO_LegsAnim_SpiderMover mover)
			{
				return mover.raycastRotation * GetDirection(step, mover);
			}

			public Vector3 GetRaycastPoint00(Vector3 origin, Vector3 dir1, Vector3 flatDir, DEMO_LegsAnim_SpiderMover mover)
			{
				return origin - flatDir * mover.CounterOffsets;
			}

			public Vector3 GetRaycastPoint01(Vector3 origin, Vector3 dir1, DEMO_LegsAnim_SpiderMover mover)
			{
				return origin + dir1 * mover.FirstRayDistance;
			}

			public Vector3 GetRaycastPoint10(Vector3 origin, Vector3 ray1Dir, DEMO_LegsAnim_SpiderMover mover)
			{
				return origin + ray1Dir * mover.FirstRayDistance * mover.SecondCastAlong;
			}

			public Vector3 GetRaycastPoint11(int step, Vector3 rayPoint10, DEMO_LegsAnim_SpiderMover mover)
			{
				return rayPoint10 + mover.raycastRotation * GetDirection2(step, mover) * mover.SecondRayDistance;
			}
		}

		private class RaycastCounter
		{
			public Vector3 normal;

			public int count;
		}

		public Fimp_JoystickInput JoystickInput;

		public Transform ToRotate;

		public Transform ToOffset;

		public Animator Mecanim;

		public LegsAnimator ToAssignHelperVars;

		[Header("Movement")]
		public float MovementSpeed = 2f;

		public float SpeedOnShift = 3f;

		[Range(0f, 1f)]
		public float RotateToSpeed = 0.75f;

		[Space(4f)]
		public LayerMask GroundMask = 0;

		[Space(4f)]
		public float JumpPower = 3f;

		[Space(4f)]
		[Range(0f, 1f)]
		public float GroundAlignSpeed = 0.8f;

		[Range(0f, 2f)]
		public float GravityPower = 1f;

		[Header("Control")]
		[Range(0f, 360f)]
		public float UpAxisAngle;

		public bool StrafeMode;

		[Header("Raycasting Setup")]
		public Vector3 OriginOffset = Vector3.up;

		[Space(3f)]
		[Range(0.05f, 1f)]
		public float FirstRayDistance = 1f;

		[Range(0.05f, 1f)]
		public float SecondRayDistance = 1f;

		[Space(5f)]
		[Range(0f, 90f)]
		public float FirstAngle = 45f;

		[Range(0f, 90f)]
		public float SecondAngle = 45f;

		[Space(3f)]
		[Range(0f, 1f)]
		public float SecondCastAlong = 0.75f;

		[Range(0f, 2f)]
		public float CollapseSides;

		[Range(0f, 1f)]
		public float HitMemoryDistance = 0.1f;

		[Range(-1f, 1f)]
		public float CounterOffsets = 0.1f;

		[Range(0f, 90f)]
		public float SkipSimilar;

		private Quaternion raycastRotation = Quaternion.identity;

		private Quaternion modelRotation = Quaternion.identity;

		private Vector3 rotationNormal = Vector3.up;

		private Vector3 raycastingRNormal = Vector3.up;

		private Vector3 sd_rotNorm = Vector3.zero;

		private Vector3 raycastNormal = Vector3.up;

		private Vector3 sd_castNorm = Vector3.zero;

		private float sd_upAxis;

		private Vector2 moveDirectionLocal = Vector3.zero;

		private Vector3 moveDirectionWorld = Vector3.zero;

		private float acceleration;

		private float sd_accel;

		private float lastTargetAngle;

		private float jumpRequest;

		private float jumpCulldown;

		private bool isGrounded = true;

		private FDebug_PerformanceTest perf = new FDebug_PerformanceTest();

		private Vector3 raycastUp = Vector3.up;

		private float jumpIn;

		public LegsAnimator.PelvisImpulseSettings ToJumpImpulse;

		private Vector3[] applied = new Vector3[16];

		private int appliedCount;

		private Vector3 gravityVelo = Vector3.zero;

		private Vector3 sd_targetOffset = Vector3.zero;

		private Vector3 sd_position = Vector3.zero;

		public float GroundingCatchRange = 0.01f;

		private SpiderRaycaster[] spiderCasters = new SpiderRaycaster[4];

		private Vector3 lowestLocal;

		private Vector3 highestLocal;

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
			ResetSpidercasters();
			rotationNormal = base.transform.up;
			raycastNormal = base.transform.up;
			lastTargetAngle = base.transform.eulerAngles.y;
		}

		private Vector3 TransformPoint(Vector3 pos)
		{
			return base.transform.TransformPoint(pos);
		}

		private Vector3 InversePoint(Vector3 pos)
		{
			return base.transform.InverseTransformPoint(pos);
		}

		private void Update()
		{
			perf.Start(base.gameObject);
			jumpIn -= Time.deltaTime;
			if (isGrounded && jumpIn <= 0f && Input.GetKeyDown(KeyCode.Space))
			{
				if ((bool)ToAssignHelperVars)
				{
					jumpIn = 0.2f;
					ToAssignHelperVars.User_AddImpulse(ToJumpImpulse);
				}
				jumpRequest = JumpPower;
			}
			moveDirectionLocal = Vector2.zero;
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				moveDirectionLocal += Vector2.left;
			}
			else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				moveDirectionLocal += Vector2.right;
			}
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				moveDirectionLocal += Vector2.up;
			}
			else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				moveDirectionLocal += Vector2.down;
			}
			if (JoystickInput.OutputValue != Vector2.zero)
			{
				moveDirectionLocal.x += JoystickInput.OutputValue.x;
				moveDirectionLocal.y += JoystickInput.OutputValue.y;
			}
			if (moveDirectionLocal != Vector2.zero)
			{
				moveDirectionLocal.Normalize();
				Quaternion quaternion = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
				moveDirectionWorld = quaternion * new Vector3(moveDirectionLocal.x, 0f, moveDirectionLocal.y);
				lastTargetAngle = FEngineering.GetAngleDeg(moveDirectionWorld.x, moveDirectionWorld.z);
				if ((bool)Mecanim)
				{
					Mecanim.SetBool("IsMoving", value: true);
				}
				if ((bool)ToAssignHelperVars)
				{
					ToAssignHelperVars.User_SetIsMoving(moving: true);
				}
				acceleration = Mathf.SmoothDamp(acceleration, 1f, ref sd_accel, 0.1f, 10000f, Time.deltaTime);
			}
			else
			{
				if ((bool)Mecanim)
				{
					Mecanim.SetBool("IsMoving", value: false);
				}
				if ((bool)ToAssignHelperVars)
				{
					ToAssignHelperVars.User_SetIsMoving(moving: false);
				}
				acceleration = Mathf.SmoothDamp(acceleration, 0f, ref sd_accel, 0.04f, 10000f, Time.deltaTime);
			}
			float target = Mathf.LerpAngle(UpAxisAngle, lastTargetAngle, acceleration);
			UpAxisAngle = Mathf.SmoothDampAngle(UpAxisAngle, target, ref sd_upAxis, Mathf.Lerp(0.6f, 0.0005f, RotateToSpeed), 1000f + RotateToSpeed * 9000f, Time.deltaTime);
			if ((bool)ToAssignHelperVars)
			{
				ToAssignHelperVars.User_SetDesiredMovementDirection(moveDirectionWorld);
			}
			ProceedSpidercasts();
			ReInitializeRaycastCounterPool(spiderCasters.Length * 2);
			Vector3 average = Vector3.zero;
			isGrounded = false;
			lowestLocal.y = float.MaxValue;
			highestLocal.y = float.MinValue;
			for (int i = 0; i < spiderCasters.Length; i++)
			{
				if (spiderCasters[i].anyHit)
				{
					AnalyzeRaycast(spiderCasters[i].firstHit, ref average, spiderCasters[i], firstHit: true);
					AnalyzeRaycast(spiderCasters[i].secondaryHit, ref average, spiderCasters[i], firstHit: false);
				}
			}
			if (average == Vector3.zero)
			{
				average = Vector3.up;
			}
			else
			{
				average.Normalize();
			}
			Vector3 zero = Vector3.zero;
			appliedCount = 0;
			if (SkipSimilar < 0.1f)
			{
				for (int j = 0; j < currentNormalIDs; j++)
				{
					zero += raycastCounters[j].normal;
				}
				zero.Normalize();
			}
			else
			{
				for (int k = 0; k < currentNormalIDs; k++)
				{
					bool flag = true;
					for (int l = 0; l < appliedCount; l++)
					{
						if (Vector3.Angle(applied[l], raycastCounters[k].normal) < SkipSimilar)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						zero += raycastCounters[k].normal;
						applied[appliedCount] = raycastCounters[k].normal;
						appliedCount++;
					}
				}
				zero.Normalize();
			}
			raycastRotation = Quaternion.FromToRotation(Vector3.up, zero);
			raycastRotation *= Quaternion.AngleAxis(UpAxisAngle, Vector3.up);
			raycastUp = raycastRotation * Vector3.up;
			float num = Mathf.Lerp(4f, 24f, GroundAlignSpeed);
			if (!isGrounded)
			{
				rotationNormal = Vector3.Slerp(rotationNormal, Vector3.up, Time.deltaTime * num * 0.5f);
			}
			else
			{
				rotationNormal = Vector3.Slerp(rotationNormal, zero, Time.deltaTime * num * 1.25f);
			}
			modelRotation = Quaternion.FromToRotation(Vector3.up, rotationNormal);
			modelRotation *= Quaternion.AngleAxis(UpAxisAngle, Vector3.up);
			ToRotate.rotation = modelRotation;
			Vector3 vector = base.transform.position;
			if (highestLocal.y > 0f)
			{
				Vector3 pos = InversePoint(vector);
				pos.y = Mathf.Lerp(pos.y, highestLocal.y, Time.deltaTime * 10f);
				vector = TransformPoint(pos);
			}
			if (lowestLocal.y < 0f)
			{
				Vector3 pos2 = InversePoint(vector);
				pos2.y = Mathf.Lerp(pos2.y, lowestLocal.y, Time.deltaTime * 10f);
				vector = TransformPoint(pos2);
			}
			if (isGrounded)
			{
				gravityVelo = Vector3.zero;
				if ((bool)ToOffset)
				{
					ToOffset.localPosition = Vector3.SmoothDamp(ToOffset.localPosition, CalculateTargetPositionLocal(), ref sd_targetOffset, 0.05f, 10000f, Time.deltaTime);
				}
			}
			else
			{
				if ((bool)ToOffset)
				{
					ToOffset.localPosition = Vector3.SmoothDamp(ToOffset.localPosition, Vector3.zero, ref sd_targetOffset, 0.035f, 10000f, Time.deltaTime);
				}
				gravityVelo.y += Time.deltaTime * Physics.gravity.y;
				gravityVelo.x = Mathf.Lerp(gravityVelo.x, 0f, Time.deltaTime * 2.2f);
				gravityVelo.z = Mathf.Lerp(gravityVelo.z, 0f, Time.deltaTime * 2.2f);
				vector += Time.deltaTime * GravityPower * gravityVelo;
			}
			Vector3 vector2 = raycastRotation * Vector3.forward;
			float num2 = MovementSpeed;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				num2 = SpeedOnShift;
			}
			vector += vector2 * Time.deltaTime * acceleration * num2;
			jumpCulldown -= Time.deltaTime;
			bool flag2 = false;
			if ((bool)ToAssignHelperVars && jumpIn > 0f)
			{
				flag2 = true;
			}
			if (!flag2 && jumpRequest != 0f)
			{
				Jump(jumpRequest);
				jumpRequest = 0f;
				vector += raycastUp * GroundingCatchRange;
			}
			base.transform.position = vector;
			perf.Finish();
		}

		public void Jump(float power)
		{
			gravityVelo = Vector3.Lerp(Vector3.up, raycastUp, 0.7f) * power;
			SetGrounded(gr: false);
			jumpCulldown = 0.6f;
		}

		private Vector3 CalculateTargetPositionLocal()
		{
			Vector3 position = base.transform.position;
			Vector3 zero = Vector3.zero;
			float num = 0f;
			for (int i = 0; i < spiderCasters.Length; i++)
			{
				SpiderRaycaster spiderRaycaster = spiderCasters[i];
				if (spiderRaycaster.anyHit && spiderRaycaster.lastDetectedFirst.distance != 0f)
				{
					zero += spiderRaycaster.lastFirstHitLocal;
					num += 1f;
				}
			}
			if (num == 0f)
			{
				return position;
			}
			return zero;
		}

		private Vector3 CalculateTargetPosition()
		{
			Vector3 position = base.transform.position;
			Vector3 zero = Vector3.zero;
			float num = 0f;
			for (int i = 0; i < spiderCasters.Length; i++)
			{
				SpiderRaycaster spiderRaycaster = spiderCasters[i];
				if (spiderRaycaster.anyHit && spiderRaycaster.lastDetectedFirst.distance != 0f)
				{
					zero += spiderRaycaster.lastFirstHitLocal;
					num += 1f;
				}
			}
			if (num == 0f)
			{
				return position;
			}
			zero.x = 0f;
			zero.z = 0f;
			zero = base.transform.TransformPoint(zero / num);
			return Vector3.SmoothDamp(position, zero, ref sd_position, 0.05f, 100000f, Time.deltaTime);
		}

		private void AnalyzeRaycast(RaycastHit hit, ref Vector3 average, SpiderRaycaster caster, bool firstHit)
		{
			if (hit.distance <= 0f)
			{
				return;
			}
			average += hit.normal;
			AddRaycastCounterNormal(hit.normal);
			Vector3 vector = (firstHit ? caster.lastFirstHitLocal : caster.lastSecHitLocal);
			if (vector.y > 0f - GroundingCatchRange)
			{
				if (jumpCulldown > 0f)
				{
					if (vector.y > GroundingCatchRange * 2f)
					{
						SetGrounded(gr: true);
					}
				}
				else
				{
					SetGrounded(gr: true);
				}
			}
			if (vector.y < lowestLocal.y)
			{
				lowestLocal = vector;
			}
			else if (vector.y > highestLocal.y)
			{
				highestLocal = vector;
			}
		}

		private void SetGrounded(bool gr)
		{
			isGrounded = gr;
			if ((bool)Mecanim)
			{
				Mecanim.SetBool("IsGrounded", gr);
			}
			if ((bool)ToAssignHelperVars)
			{
				ToAssignHelperVars.User_SetIsGrounded(gr);
			}
		}

		private void ResetSpidercasters()
		{
			for (int i = 0; i < 4; i++)
			{
				if (spiderCasters[i] == null)
				{
					spiderCasters[i] = new SpiderRaycaster();
				}
				spiderCasters[i].Reset();
			}
		}

		private void ProceedSpidercasts()
		{
			Vector3 raycastsOrigin = GetRaycastsOrigin();
			for (int i = 0; i < 4; i++)
			{
				spiderCasters[i].Cast(raycastsOrigin, i + 1, this);
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
