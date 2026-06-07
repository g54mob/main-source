using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class Swim : State
	{
		[Header("Swim Paramenters")]
		public LayerMask WaterLayer = 16;

		[Tooltip("Ray to Shoot Down To find the water leve;")]
		public float UpSearch = 3f;

		[Tooltip("Lerp value for the animal to stay align to the water level ")]
		[Min(0f)]
		public float AlignSmooth = 10f;

		[Tooltip("When entering the water the Animal will sink for a while... Higher values, will return to the surface faster")]
		[Min(0f)]
		public float bounce = 2f;

		[Tooltip("Lerp value to do the Bounce Feature")]
		[Min(0f)]
		public float bounceLerp = 10f;

		[Tooltip("Gives an extra impulse when entering the state using the accumulated  inertia")]
		public bool KeepInertia = true;

		[Tooltip("Spherecast radius to find water using the Water Pivot")]
		[Min(0.01f)]
		public float m_Radius = 0.1f;

		[Tooltip("Ray to the Front to check if the Animal has touched a Front Ground and it cannot push it")]
		[Min(0f)]
		public float FrontRayLength = 1f;

		[Tooltip("When checking he ground, this will be the multiplier for the height value")]
		[Range(0f, 0.9f)]
		public float HeightMult = 0.9f;

		[Header("Reactions")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction OnTouchedWaterEnter;

		[SerializeReference]
		[SubclassSelector]
		public Reaction OnTouchedWaterExit;

		[Disable]
		public bool IsInWater;

		[Disable]
		public bool PivotAboveWater;

		protected float EnterWaterTime;

		protected Vector3 WaterNormal = Vector3.up;

		protected Vector3 HorizontalInertia;

		private readonly Vector3 NoWaterLevel = new Vector3(0f, float.MinValue, 0f);

		[Disable]
		public Vector3 BounceUp;

		[Disable]
		public Vector3 BounceDown;

		protected Vector3 BounceUpTarget;

		protected int TryLoopOriginal;

		protected Collider[] WaterCollider;

		public override string StateName => "Swim";

		public override string StateIDName => "Swim";

		public bool TouchedWater { get; protected set; }

		public MPivots WaterPivot { get; protected set; }

		public Vector3 WaterLine_Difference { get; internal set; }

		public Vector3 WaterLevel { get; internal set; }

		public Vector3 WaterPivotPoint => WaterPivot.World(animal.transform) + animal.DeltaVelocity;

		public override void InitializeState()
		{
			WaterPivot = animal.pivots.Find((MPivots p) => p.name.ToLower().Contains("water"));
			if (WaterPivot == null)
			{
				Debug.LogError("No Water Pivot Found.. please create a Water Pivot");
			}
			WaterCollider = new Collider[1];
			IsInWater = false;
			TouchedWater = false;
			TryLoopOriginal = TryLoop;
		}

		public override bool TryActivate()
		{
			if (FindWaterLevel2())
			{
				return !PivotAboveWater;
			}
			return false;
		}

		public override void Activate()
		{
			base.Activate();
			HorizontalInertia = Vector3.ProjectOnPlane(animal.DeltaPos, animal.UpVector);
			if (bounce > 0f)
			{
				BounceDown = Vector3.Project(animal.DeltaPos, animal.Up);
			}
			BounceUp = Vector3.one * 0.0001f;
			base.IgnoreLowerStates = true;
			animal.UseGravity = false;
			animal.Force_Reset();
			WaterNormal = Vector3.up;
			BounceUpTarget = -base.Gravity * bounce;
			animal.SetPlatform(null);
		}

		public bool CheckWater()
		{
			int num = Physics.OverlapSphereNonAlloc(WaterPivotPoint, m_Radius * animal.ScaleFactor, WaterCollider, WaterLayer, QueryTriggerInteraction.Collide);
			if (base.GizmoDebug)
			{
				MDebug.DrawWireSphere(WaterPivotPoint, transform.rotation, Color.cyan, m_Radius * animal.ScaleFactor);
			}
			return num > 0;
		}

		public bool FindWaterLevel2()
		{
			Vector3 vector = WaterPivotPoint + Vector3.up * (UpSearch * base.ScaleFactor);
			float num = (UpSearch + WaterPivot.position.y) * base.ScaleFactor;
			float radius = m_Radius * base.ScaleFactor;
			if (base.GizmoDebug)
			{
				MDebug.DrawWireSphere(vector, Color.cyan, radius);
				MDebug.DrawWireSphere(WaterPivotPoint, Color.cyan, radius);
				MDebug.DrawWireSphere(vector + base.Gravity * num, Color.cyan, radius);
			}
			if (Physics.Raycast(vector, base.Gravity, out var hitInfo, num, WaterLayer, QueryTriggerInteraction.Collide))
			{
				WaterLevel = hitInfo.point;
				WaterNormal = hitInfo.normal;
				if (!TouchedWater)
				{
					TouchedWater = true;
					OnTouchedWaterEnter?.React(animal);
					TryLoop = 1;
				}
				Vector3 lhs = WaterPivotPoint - WaterLevel;
				PivotAboveWater = Vector3.Dot(lhs, base.Gravity) < 0f;
				IsInWater = !PivotAboveWater;
				if (!IsInWater && MTools.DoSpheresIntersect(WaterLevel, m_Radius, WaterPivotPoint, m_Radius))
				{
					IsInWater = true;
				}
				if (base.GizmoDebug)
				{
					Debug.DrawLine(vector, WaterLevel, Color.blue + Color.cyan);
					MDebug.DrawWireSphere(WaterLevel, Color.white, radius);
					Debug.DrawRay(WaterLevel, WaterPivot.position.y * HeightMult * base.Gravity, Color.white);
				}
				return IsInWater;
			}
			if (TouchedWater)
			{
				TouchedWater = false;
				OnTouchedWaterExit?.React(animal);
				TryLoop = TryLoopOriginal;
			}
			if (base.GizmoDebug)
			{
				Debug.DrawRay(vector, base.ScaleFactor * UpSearch * base.Gravity, Color.cyan);
			}
			IsInWater = false;
			return IsInWater;
		}

		public bool CheckNearGround()
		{
			float num = HeightMult * WaterPivot.position.y * base.ScaleFactor;
			if (base.GizmoDebug)
			{
				Debug.DrawRay(WaterPivotPoint, num * base.Gravity, Color.cyan);
				MDebug.DrawWireSphere(WaterPivotPoint + num * base.Gravity, Color.cyan, 0.1f);
			}
			if (Physics.Raycast(WaterPivotPoint, base.Gravity, out var hitInfo, num, animal.GroundLayer, base.IgnoreTrigger))
			{
				float num2 = Vector3.Angle(hitInfo.normal, animal.UpVector);
				BounceDown = Vector3.zero;
				return num2 < animal.SlopeLimit;
			}
			return false;
		}

		public override void TryExitState(float DeltaTime)
		{
			bool flag = CheckNearGround();
			if (!(BounceUp != Vector3.zero) && (!IsInWater || flag))
			{
				Debugging("[Allow Exit] No Longer in water");
				animal.CheckIfGrounded();
				AllowExit();
			}
		}

		public override void OnStateMove(float deltatime)
		{
			if (KeepInertia)
			{
				AddInertia(ref HorizontalInertia, 3f, deltatime);
			}
			WaterNormal = animal.UpVector;
			FindWaterLevel2();
			animal.AlignRotation(WaterNormal, deltatime, (AlignSmooth > 0f) ? AlignSmooth : 5f);
			WaterLine_Difference = Vector3.Project(WaterLevel - WaterPivotPoint, base.UpVector);
			BounceEnteringWater(deltatime);
			Color color = (Color.blue + Color.cyan) / 2f;
			if (FrontRayLength > 0f && Physics.Raycast(WaterPivotPoint, base.Forward, out var hitInfo, FrontRayLength, base.GroundLayer, QueryTriggerInteraction.Ignore))
			{
				float num = Vector3.Angle(hitInfo.normal, animal.UpVector);
				color = Color.cyan;
				if (num > animal.SlopeLimit)
				{
					color = Color.black;
					base.Position += WaterLine_Difference;
					animal.ResetUPVector();
				}
			}
			else if (IsInWater)
			{
				if (AlignSmooth > 0f)
				{
					base.Position += Vector3.Lerp(Vector3.zero, WaterLine_Difference, deltatime * AlignSmooth);
				}
				else
				{
					base.Position += WaterLine_Difference;
					animal.ResetUPVector();
				}
			}
			if (base.GizmoDebug)
			{
				Debug.DrawRay(WaterPivotPoint, animal.Forward * FrontRayLength, color);
			}
		}

		private void BounceEnteringWater(float delta)
		{
			if (BounceUp != Vector3.zero)
			{
				BounceDown = Vector3.Lerp(BounceDown, Vector3.zero, bounceLerp * delta);
				animal.AdditivePosition += BounceDown;
				BounceUp = Vector3.Lerp(BounceUp, BounceUpTarget, bounceLerp * delta);
				Vector3 vector = WaterPivotPoint + BounceUp * (delta * bounceLerp);
				if (base.GizmoDebug)
				{
					MDebug.DrawWireSphere(vector, Color.green, m_Radius);
				}
				Vector3 lhs = vector - WaterLevel;
				PivotAboveWater = Vector3.Dot(lhs, base.Gravity) < 0f;
				if (PivotAboveWater)
				{
					BounceDown = Vector3.zero;
					BounceUp = Vector3.zero;
				}
				else
				{
					animal.AdditivePosition += BounceUp * (delta * bounceLerp);
					WaterLine_Difference = Vector3.zero;
				}
			}
		}

		private void AddInertia(ref Vector3 value, float speed, float DeltaTime)
		{
			transform.position += value;
			value = Vector3.Lerp(value, Vector3.zero, DeltaTime * speed);
		}

		public override void ResetStateValues()
		{
			WaterCollider = new Collider[1];
			IsInWater = false;
			TouchedWater = false;
			PivotAboveWater = false;
			BounceDown = Vector3.zero;
			BounceUp = Vector3.zero;
			WaterLine_Difference = Vector3.zero;
			HorizontalInertia = Vector3.zero;
			WaterNormal = Vector3.up;
			WaterLevel = NoWaterLevel;
		}
	}
}
