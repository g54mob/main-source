using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class SwimUnderwater : State
	{
		[Header("UnderWater Parameters")]
		[Range(0f, 90f)]
		public float Bank = 30f;

		[Range(0f, 90f)]
		[Tooltip("Limit to go Up and Down")]
		public float Ylimit = 80f;

		[Tooltip("It will push the animal down into the water for a given time")]
		public float EnterWaterDrag = 10f;

		[Tooltip("When the Underwater state exits, it will activate the Fall State")]
		public bool AllowFallOnExit = true;

		protected Vector3 Inertia;

		protected Swim SwimState;

		public override string StateName => "UnderWater";

		public override string StateIDName => "UnderWater";

		public override void InitializeState()
		{
			SwimState = null;
			SwimState = (Swim)animal.State_Get(StateEnum.Swim);
			if (SwimState == null)
			{
				Debug.LogError("UnderWater State needs Swim State in order to work, please add the Swim State to " + animal.name, animal);
			}
		}

		public override void Activate()
		{
			base.Activate();
			Inertia = animal.DeltaPos;
		}

		public override Vector3 Speed_Direction()
		{
			if (!animal.FreeMovement)
			{
				return animal.Forward;
			}
			return animal.PitchDirection;
		}

		public override bool TryActivate()
		{
			if (SwimState == null)
			{
				return false;
			}
			if (SwimState.IsActiveState)
			{
				if (animal.RawInputAxis.y < -0.25f)
				{
					base.IgnoreLowerStates = true;
					return true;
				}
			}
			else if (SwimState.CheckWater() && animal.MovementAxisSmoothed.y < -0.25f)
			{
				base.IgnoreLowerStates = false;
				return true;
			}
			return false;
		}

		public override void OnStateMove(float deltatime)
		{
			animal.FreeMovementRotator(Ylimit, Bank);
			animal.AddInertia(ref Inertia, EnterWaterDrag);
			animal.UseGravity = false;
		}

		public override void TryExitState(float DeltaTime)
		{
			if (!SwimState.CheckWater())
			{
				if (AllowFallOnExit && animal.Sprint && animal.UpDownSmooth > 0f)
				{
					Debugging("[Exit to Fall]");
					animal.State_Force(StateEnum.Fall);
					AllowExit();
				}
				else
				{
					Debugging("[Allow Exit to Swim]");
					SwimState.Activate();
					SwimState.BounceDown = Vector3.zero;
				}
			}
		}

		public override void ResetStateValues()
		{
			Inertia = Vector3.zero;
		}

		public override void RestoreAnimalOnExit()
		{
			animal.FreeMovement = false;
		}
	}
}
