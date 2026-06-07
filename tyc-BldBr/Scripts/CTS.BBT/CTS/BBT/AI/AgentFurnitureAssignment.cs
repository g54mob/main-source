using System;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class AgentFurnitureAssignment : MonoBehaviour
	{
		private Agent _agent;

		public FurnitureInteractor CurrentAssignment { get; private set; }

		public Seat CurrentSeat { get; private set; }

		public bool CurrentlyAssigned { get; private set; }

		public static event Action<Agent, Seat> OnSeatAssinged;

		public static event Action<Agent, Seat> OnSeatReleased;

		public static event Action<Seat> OnFurnitureUseChanged;

		private void Awake()
		{
			_agent = GetComponent<Agent>();
		}

		public void AssignSeat(Seat p_seat)
		{
			if (!(CurrentSeat == p_seat))
			{
				CurrentSeat = p_seat;
				AgentFurnitureAssignment.OnSeatAssinged?.Invoke(_agent, CurrentSeat);
			}
		}

		public void ReleaseSeat()
		{
			CurrentSeat = null;
			AgentFurnitureAssignment.OnSeatReleased?.Invoke(_agent, CurrentSeat);
		}

		public void StartUsing(FurnitureInteractor p_furnitureInteractor)
		{
			if (p_furnitureInteractor.CanBeUsed() && !CurrentlyAssigned)
			{
				p_furnitureInteractor.StartUsing(_agent);
				CurrentAssignment = p_furnitureInteractor;
				CurrentlyAssigned = true;
			}
		}

		public void StopUsing()
		{
			if (CurrentlyAssigned)
			{
				CurrentAssignment.StopUsing();
				CurrentAssignment = null;
				CurrentlyAssigned = false;
			}
		}

		public bool TryGetAssignment<TFurniture>(out TFurniture p_assignment) where TFurniture : FurnitureInteractor
		{
			p_assignment = null;
			if (!CurrentlyAssigned)
			{
				return false;
			}
			if (!(CurrentAssignment is TFurniture val))
			{
				return false;
			}
			p_assignment = val;
			return true;
		}
	}
}
