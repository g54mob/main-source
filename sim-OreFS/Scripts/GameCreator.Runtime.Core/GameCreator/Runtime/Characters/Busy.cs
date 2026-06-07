using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Busy
	{
		public enum Limb
		{
			ArmLeft = 1,
			ArmRight = 2,
			LegLeft = 4,
			LegRight = 8,
			Arms = 3,
			Legs = 12,
			Every = 15,
			None = 0
		}

		private Character m_Character;

		private Limb m_State;

		public Limb State
		{
			get
			{
				return m_State;
			}
			private set
			{
				m_State = value;
				this.EventChange?.Invoke(m_State);
			}
		}

		public bool IsArmLeftBusy => ArmLeftBusy(m_State);

		public bool IsArmRightBusy => ArmRightBusy(m_State);

		public bool IsLegLeftBusy => LegLeftBusy(m_State);

		public bool IsLegRightBusy => LegRightBusy(m_State);

		public bool AreArmsBusy => ArmsBusy(m_State);

		public bool AreLegsBusy => LegsBusy(m_State);

		public bool IsBusy => WholeBodyBusy(m_State);

		public event Action<Limb> EventChange;

		internal void OnStartup(Character character)
		{
			m_Character = character;
		}

		internal void AfterStartup(Character character)
		{
		}

		public void SetBusy()
		{
			AddState(Limb.Every);
		}

		public void SetAvailable()
		{
			RemoveState(Limb.Every);
		}

		public void MakeArmLeftBusy()
		{
			AddState(Limb.ArmLeft);
		}

		public void MakeArmRightBusy()
		{
			AddState(Limb.ArmRight);
		}

		public void MakeLegLeftBusy()
		{
			AddState(Limb.LegLeft);
		}

		public void MakeLegRightBusy()
		{
			AddState(Limb.LegRight);
		}

		public void MakeArmsBusy()
		{
			AddState(Limb.Arms);
		}

		public void MakeLegsBusy()
		{
			AddState(Limb.Legs);
		}

		public void RemoveArmLeftBusy()
		{
			RemoveState(Limb.ArmLeft);
		}

		public void RemoveArmRightBusy()
		{
			RemoveState(Limb.ArmRight);
		}

		public void RemoveLegLeftBusy()
		{
			RemoveState(Limb.LegLeft);
		}

		public void RemoveLegRightBusy()
		{
			RemoveState(Limb.LegRight);
		}

		public void RemoveArmsBusy()
		{
			RemoveState(Limb.Arms);
		}

		public void RemoveLegsBusy()
		{
			RemoveState(Limb.Legs);
		}

		public async Task Timeout(Limb limbs, float timeout)
		{
			AddState(limbs);
			float startTime = m_Character.Time.Time;
			while (!ApplicationManager.IsExiting && m_Character.Time.Time < startTime + timeout)
			{
				await Task.Yield();
			}
			RemoveState(limbs);
		}

		public static bool ArmLeftBusy(Limb state)
		{
			return (state & Limb.ArmLeft) > Limb.None;
		}

		public static bool ArmRightBusy(Limb state)
		{
			return (state & Limb.ArmRight) > Limb.None;
		}

		public static bool LegLeftBusy(Limb state)
		{
			return (state & Limb.LegLeft) > Limb.None;
		}

		public static bool LegRightBusy(Limb state)
		{
			return (state & Limb.LegRight) > Limb.None;
		}

		public static bool ArmsBusy(Limb state)
		{
			return (state & Limb.Arms) > Limb.None;
		}

		public static bool LegsBusy(Limb state)
		{
			return (state & Limb.Legs) > Limb.None;
		}

		public static bool WholeBodyBusy(Limb state)
		{
			return (state & Limb.Every) > Limb.None;
		}

		public void AddState(Limb limbs)
		{
			int state = (int)m_State;
			State = (Limb)(state | (int)limbs);
		}

		public void RemoveState(Limb limbs)
		{
			int state = (int)m_State;
			State = (Limb)(state & (int)(~limbs));
		}
	}
}
