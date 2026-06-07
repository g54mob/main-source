using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states/wallrun")]
	public class WallRunVertical : State
	{
		[Tooltip("If the Animal is going to find the wall automatically to activate the State")]
		public BoolReference Automatic = new BoolReference(value: true);

		[Tooltip("Try Finding the Wall only when [Sprint] is true")]
		public BoolReference OnSprint = new BoolReference(value: true);

		[Tooltip("Another Filter to activate  wallrun Vertical")]
		public StringReference WallTag = new StringReference("WallRun");

		[Header("Wall Parameters")]
		[Tooltip("Max Distance to find walls left and Right.")]
		public FloatReference WallCheck = new FloatReference(1f);

		[Tooltip("Distance to align the Character to the Wall")]
		public FloatReference WallDistance = new FloatReference(0.5f);

		[Tooltip("Pivot to cast rays from the Animal, to find walls left and right")]
		public Vector3Reference Center = new Vector3Reference(0f, 1f, 0f);

		public LayerReference WallLayer = new LayerReference(1);

		[Tooltip("Angle Limit to Exit the WallRun")]
		public float WallLimitAngle = 45f;

		[Tooltip("Use the Rotator to Rotate 90 degree the animal. Use this if you do not have Wall Run Vertical animations")]
		public bool UseRotator;

		[Tooltip("Smoothness value to align the animal to the wall")]
		public float AlignSmoothness = 10f;

		[Header("Side Movement")]
		[Tooltip("Move the Character left and Right while going Up the wall")]
		public FloatReference SideMovement = new FloatReference(1f);

		public float Bank;

		[Header("Exit Features")]
		[Tooltip("When there's no wall, wait This time to propelry exit")]
		public float ExitDelay = 0.5f;

		private float currentExitDelay;

		[Tooltip("Force to apply when exiting the WallRun")]
		[Min(0f)]
		public float ExitForce = 15f;

		[Hide("ExitForce", true)]
		[Min(0f)]
		public float ExitForceAceleration = 2f;

		public override string StateName => "WallRun/Wall-Run Vertical";

		public override string StateIDName => "WallRunVertical";

		public Transform ValidWall { get; private set; }

		public float WallCurrentDistance { get; private set; }

		public Vector3 WallNormal { get; private set; }

		public override bool TryActivate()
		{
			bool flag = ((bool)OnSprint && animal.Sprint) || !OnSprint.Value;
			if (!FindWall())
			{
				return false;
			}
			int num;
			if (!InputValue)
			{
				num = ((Automatic.Value && flag) ? 1 : 0);
				if (num == 0)
				{
					goto IL_005c;
				}
			}
			else
			{
				num = 1;
			}
			Debugging("[Try Activate] Wall detected Front");
			goto IL_005c;
			IL_005c:
			return (byte)num != 0;
		}

		public override void ResetStateValues()
		{
			animal.ResetCameraInput();
			currentExitDelay = 0f;
			WallCurrentDistance = 0f;
			WallNormal = Vector3.zero;
		}

		private bool FindWall()
		{
			ValidWall = null;
			Vector3 vector = base.transform.TransformPoint(Center);
			if (m_debug)
			{
				MDebug.DrawRay(vector, animal.Forward * WallCheck, Color.red);
				MDebug.DrawRay(vector, animal.Forward * WallDistance, Color.green);
			}
			if (Physics.Raycast(vector, animal.Forward, out var hitInfo, WallCheck, WallLayer.Value, QueryTriggerInteraction.Ignore))
			{
				Transform transform = hitInfo.transform;
				if (ValidWall != transform && (WallTag.Empty || transform.CompareTag(WallTag)))
				{
					animal.SetPlatform(transform);
					MDebug.DrawWireSphere(hitInfo.point, 0.05f, Color.green, 0.2f);
					ValidWall = transform;
					WallNormal = hitInfo.normal;
					WallCurrentDistance = hitInfo.distance;
					return true;
				}
			}
			return false;
		}

		public override Vector3 Speed_Direction()
		{
			return base.Up * animal.VerticalSmooth + animal.HorizontalSmooth * (float)SideMovement * base.Right;
		}

		public override void Activate()
		{
			base.Activate();
			animal.UseCameraInput = false;
			currentExitDelay = 0f;
			WallCurrentDistance = (float)WallDistance * 1.5f;
			WallNormal = Vector3.zero;
		}

		public override void OnStateMove(float deltatime)
		{
			if (base.InCoreAnimation)
			{
				FindWall();
				AlignToWall(WallCurrentDistance, deltatime);
				if (Vector3.Angle(WallNormal, animal.UpVector) > WallLimitAngle)
				{
					OrientToWall(WallNormal, deltatime);
				}
				if (UseRotator)
				{
					animal.PitchDirection = animal.UpVector;
					animal.FreeMovementRotator(90f, 0f);
				}
			}
		}

		public override void TryExitState(float DeltaTime)
		{
			if (!(ValidWall == null))
			{
				return;
			}
			currentExitDelay += DeltaTime;
			if (currentExitDelay > ExitDelay)
			{
				Debugging("[Try Exit] Wall not detected");
				AllowExit();
				animal.Force_Add(animal.Up, ExitForce, ExitForceAceleration, ResetGravity: false);
				animal.Delay_Action(0.5f, delegate
				{
					animal.Force_Remove(ExitForceAceleration);
				});
			}
		}

		private void AlignToWall(float distance, float deltatime)
		{
			float num = distance - (float)WallDistance * animal.ScaleFactor;
			if (!Mathf.Approximately(distance, (float)WallDistance * animal.ScaleFactor))
			{
				Vector3 vector = AlignSmoothness * deltatime * num * base.ScaleFactor * animal.Forward;
				animal.AdditivePosition += vector;
			}
		}

		private void OrientToWall(Vector3 normal, float deltatime)
		{
			Quaternion quaternion = Quaternion.FromToRotation(base.Forward, -normal) * transform.rotation;
			Quaternion b = Quaternion.Inverse(transform.rotation) * quaternion;
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, b, deltatime * AlignSmoothness);
			animal.AdditiveRotation *= quaternion2;
			Vector3 lhs = Vector3.Cross(base.Forward, base.UpVector);
			lhs = Vector3.Cross(lhs, base.Forward);
			if (Bank != 0f)
			{
				lhs = Quaternion.Euler(animal.HorizontalSmooth * Bank, 0f, 0f) * lhs;
			}
			quaternion = Quaternion.FromToRotation(transform.up, lhs) * transform.rotation;
			b = Quaternion.Inverse(transform.rotation) * quaternion;
			animal.AdditiveRotation *= b;
		}

		public override void StatebyInput()
		{
			if (InputValue && FindWall())
			{
				Activate();
			}
		}

		public override void StateGizmos(MAnimal animal)
		{
			if (m_debug && !Application.isPlaying)
			{
				Transform obj = animal.transform;
				float scaleFactor = animal.ScaleFactor;
				Vector3 vector = obj.forward * scaleFactor;
				Vector3 vector2 = obj.TransformPoint(Center);
				Gizmos.color = Color.red;
				Gizmos.DrawRay(vector2, vector * WallCheck);
				Gizmos.color = Color.green;
				Gizmos.DrawRay(vector2, vector * WallDistance);
			}
		}

		internal override void Reset()
		{
			base.Reset();
			TryLoop = new IntReference(6);
			AlwaysForward = new BoolReference(value: true);
			Input = "Sprint";
			General = new AnimalModifier
			{
				modify = (modifier)(-1),
				RootMotion = true,
				AdditivePosition = true,
				AdditiveRotation = true,
				Grounded = false,
				Sprint = true,
				OrientToGround = false,
				Gravity = false,
				CustomRotation = true,
				FreeMovement = false,
				IgnoreLowerStates = true
			};
			SpeedSets = new List<MSpeedSet>
			{
				new MSpeedSet
				{
					name = "Wall Run Vertical",
					StartVerticalIndex = new IntReference(1),
					TopIndex = new IntReference(1),
					states = new List<StateID>(1) { MTools.GetInstance<StateID>(StateIDName) },
					Speeds = new List<MSpeed>
					{
						new MSpeed("Wall Run Vertical")
						{
							position = new FloatReference(5f)
						}
					}
				}
			};
		}

		public override void SetSpeedSets(MAnimal animal)
		{
		}
	}
}
