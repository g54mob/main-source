using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states/wallrun")]
	public class WallRun : State
	{
		[Header("Wall Run Parameters")]
		[Tooltip("Find Walls to run automatically, without the need of an Input")]
		public BoolReference Automatic = new BoolReference();

		[Tooltip("Keep Pressing the input to maintain Wall Run")]
		public BoolReference InputPressed = new BoolReference(value: true);

		[Header("Pivot Center")]
		[Tooltip("Pivot to cast rays from the Animal, to find walls left and right")]
		public Vector3Reference Center = new Vector3Reference(0f, 1f, 0f);

		[Header("Wall Parameters")]
		[Tooltip("Max Distance to find walls left and Right.")]
		public FloatReference WallCheck = new FloatReference(1f);

		[Tooltip("Distance to align the Character to the Wall")]
		public FloatReference WallDistance = new FloatReference(0.01f);

		[Tooltip("Minimun Height required to activate the Wall Run")]
		public FloatReference StartHeight = new FloatReference(0f);

		[Tooltip("What layers can be Wallrunned")]
		public LayerReference Layer = new LayerReference(1);

		[Tooltip("Another Filter to the walls")]
		public StringReference WallTag = new StringReference("WallRun");

		[Header("Smoothness and Lerping")]
		[Tooltip("Lerp value to Orient the Animal to the wall")]
		public FloatReference AlignLerp = new FloatReference(10f);

		[Tooltip("Lerp value to rotate the Animal to the wall")]
		public FloatReference RotationLerp = new FloatReference(10f);

		[Tooltip("Rotation Angle")]
		public FloatReference Bank = new FloatReference(0f);

		[Header("Exit Impulse")]
		[Tooltip("Exit Rotation Angle")]
		public FloatReference ExitAngle = new FloatReference(30f);

		[Tooltip("Time to rotate the animal to the Exit Angle ")]
		public FloatReference ExitAngleTime = new FloatReference(0.2f);

		[Tooltip("Next State to apply the exit push")]
		public List<StateID> PushStates;

		[Header("Intertia and Gravity")]
		[Tooltip("Wall Running pushing")]
		public FloatReference GravityPush = new FloatReference(0.5f);

		[Tooltip("Decrease the Vertical Impulse when entering the Fall State")]
		public float UpDrag = 1f;

		private RaycastHit WallHit;

		private bool RightSide;

		public override string StateName => "WallRun/Wall-Run Sides";

		public override string StateIDName => "WallRun";

		public Vector3 UpImpulse { get; private set; }

		public bool Has_UP_Impulse { get; private set; }

		public override float GravityMultiplier => GravityPush;

		public Transform WallFound { get; private set; }

		private bool CheckWallRay()
		{
			Transform obj = animal.transform;
			float scaleFactor = animal.ScaleFactor;
			Vector3 vector = obj.right * scaleFactor;
			Vector3 vector2 = obj.TransformPoint(Center);
			Debug.DrawRay(vector2, vector * WallCheck, Color.green);
			Debug.DrawRay(vector2, -vector * WallCheck, Color.green);
			Debug.DrawRay(vector2, vector * WallDistance, Color.red);
			Debug.DrawRay(vector2, -vector * WallDistance, Color.red);
			if ((float)StartHeight > 0f && Physics.Raycast(vector2, animal.Gravity, out var _, animal.Height + (float)StartHeight * scaleFactor, animal.GroundLayer))
			{
				return false;
			}
			WallHit = default(RaycastHit);
			if (Physics.Raycast(vector2, vector, out WallHit, (float)WallCheck * scaleFactor, Layer))
			{
				Transform transform = WallHit.transform;
				if (m_debug)
				{
					MDebug.DrawWireSphere(WallHit.point, Color.green, 0.05f, 0.5f);
				}
				if (transform != WallFound)
				{
					WallFound = transform;
					if (WallTag.Empty || WallFound.CompareTag(WallTag))
					{
						RightSide = true;
						animal.SetPlatform(WallFound);
						Debugging("[Try Activate] Wall detected on the Right");
						return true;
					}
				}
			}
			else if (Physics.Raycast(vector2, -vector, out WallHit, (float)WallCheck * scaleFactor, Layer))
			{
				Transform transform2 = WallHit.transform;
				if (m_debug)
				{
					MDebug.DrawWireSphere(WallHit.point, Color.green, 0.05f, 0.5f);
				}
				if (transform2 != WallFound)
				{
					WallFound = transform2;
					if (WallTag.Empty || WallFound.CompareTag(WallTag))
					{
						RightSide = false;
						animal.SetPlatform(WallFound);
						Debugging("[Try Activate] Wall detected on the Left");
						return true;
					}
				}
			}
			else
			{
				WallFound = null;
			}
			return false;
		}

		public override bool TryActivate()
		{
			if (Automatic.Value || InputValue)
			{
				return CheckWallRay();
			}
			return false;
		}

		public override void Activate()
		{
			base.Activate();
			SetEnterStatus(RightSide ? 1 : (-1));
			animal.Gravity_ResetValues();
			UpImpulse = Vector3.Project(animal.DeltaPos, animal.UpVector);
			Has_UP_Impulse = Vector3.Dot(UpImpulse, animal.UpVector) > 0f;
		}

		public override void OnStatePreMove(float deltatime)
		{
			animal.DeltaRootMotion = Vector3.zero;
			animal.DeltaAngle = 0f;
			animal.MovementAxisRaw = new Vector3(0f, 0f, 1f);
			animal.MovementAxis = new Vector3(0f, 0f, 1f);
			animal.HorizontalSmooth = 0f;
		}

		public override void OnStateMove(float deltatime)
		{
			if (!base.InCoreAnimation)
			{
				return;
			}
			Transform transform = animal.transform;
			float scaleFactor = animal.ScaleFactor;
			int num = (RightSide ? 1 : (-1));
			Vector3 vector = num * transform.right * scaleFactor;
			Vector3 vector2 = transform.TransformPoint(Center);
			Debug.DrawRay(vector2, vector * WallCheck, Color.green);
			Debug.DrawRay(vector2, vector * WallDistance, Color.red);
			if (Has_UP_Impulse)
			{
				animal.AdditivePosition += UpImpulse;
				UpImpulse = Vector3.Lerp(UpImpulse, Vector3.zero, deltatime * UpDrag);
			}
			if (Physics.Raycast(vector2, vector, out WallHit, (float)WallCheck * scaleFactor, Layer))
			{
				Transform obj = WallHit.transform;
				if (m_debug)
				{
					MDebug.DrawWireSphere(WallHit.point, Color.green, 0.05f, 0.5f);
				}
				if (obj != WallFound)
				{
					WallFound = WallHit.transform;
					if (!WallTag.Empty && !WallFound.CompareTag(WallTag))
					{
						WallFound = null;
						return;
					}
				}
				OrientToWall(vector, WallHit.normal, deltatime);
				AlignToWall(vector, WallHit.distance, deltatime);
				animal.Bank = Mathf.Lerp(animal.Bank, (float)num * (float)Bank, deltatime * (float)animal.CurrentSpeedSet.BankLerp);
				float b = Vector3.SignedAngle(animal.Forward, animal.DeltaVelocity, animal.Right);
				animal.PitchAngle = Mathf.Lerp(animal.PitchAngle, b, deltatime * (float)animal.CurrentSpeedSet.PitchLerpOn);
				animal.State_SetFloat(animal.PitchAngle);
				animal.CalculateRotator();
			}
			else
			{
				WallFound = null;
			}
		}

		private void AlignToWall(Vector3 Direction, float distance, float deltatime)
		{
			float num = distance - (float)WallDistance * animal.ScaleFactor;
			Vector3 vector = Direction * num * deltatime * AlignLerp;
			animal.AdditivePosition += vector;
		}

		private void OrientToWall(Vector3 Right, Vector3 normal, float deltatime)
		{
			Quaternion rotation = transform.rotation;
			Quaternion quaternion = Quaternion.FromToRotation(Right, -normal) * rotation;
			Quaternion b = Quaternion.Inverse(rotation) * quaternion;
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, b, deltatime * (float)RotationLerp);
			animal.AdditiveRotation *= quaternion2;
		}

		public override void TryExitState(float DeltaTime)
		{
			if (!WallFound)
			{
				Debugging("[Allow Exit] Wall not Found");
				AllowExit();
			}
			else if (!string.IsNullOrEmpty(Input) && InputPressed.Value && !InputValue)
			{
				Debugging("[Allow Exit] The Input is no longer Pressed");
				AllowExit();
			}
			else if (animal.CheckIfGrounded())
			{
				Debugging("[Allow Exit] Is near the ground");
				AllowExit(-1, 3);
			}
		}

		public override void AllowStateExit()
		{
			animal.Gravity_ResetValues();
		}

		public override void PostExitState()
		{
			if (animal.LastState == this && (float)ExitAngle > 0f && animal.enabled && (PushStates == null || PushStates.Contains(base.ActiveState.ID)))
			{
				int num = ((!RightSide) ? 1 : (-1));
				animal.StartCoroutine(MTools.AlignTransform_Rotation(transform, transform.rotation * Quaternion.Euler(0f, (float)ExitAngle * (float)num, 0f), ExitAngleTime));
				Debugging("[Exit Impulse] Push the Animal Away from the Wall");
			}
		}

		public override void ResetStateValues()
		{
			WallFound = null;
			WallHit = default(RaycastHit);
			UpImpulse = Vector3.zero;
			Has_UP_Impulse = false;
		}
	}
}
