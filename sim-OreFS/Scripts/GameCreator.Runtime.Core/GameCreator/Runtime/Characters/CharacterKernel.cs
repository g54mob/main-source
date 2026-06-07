using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class CharacterKernel : ICharacterKernel
	{
		[SerializeReference]
		protected TUnitPlayer m_Player;

		[SerializeReference]
		protected TUnitMotion m_Motion;

		[SerializeReference]
		protected TUnitDriver m_Driver;

		[SerializeReference]
		protected TUnitFacing m_Facing;

		[SerializeReference]
		protected TUnitAnimim m_Animim;

		public Character Character { get; private set; }

		public IUnitPlayer Player => m_Player;

		public IUnitMotion Motion => m_Motion;

		public IUnitDriver Driver => m_Driver;

		public IUnitFacing Facing => m_Facing;

		public IUnitAnimim Animim => m_Animim;

		public event Action EventChangePlayer;

		public event Action EventChangeMotion;

		public event Action EventChangeDriver;

		public event Action EventChangeFacing;

		public event Action EventChangeAnimim;

		public CharacterKernel()
		{
			IKernelPreset kernelPreset = new KernelPreset3DController();
			m_Player = kernelPreset.MakePlayer;
			m_Motion = kernelPreset.MakeMotion;
			m_Driver = kernelPreset.MakeDriver;
			m_Facing = kernelPreset.MakeFacing;
			m_Animim = kernelPreset.MakeAnimim;
		}

		public void ChangePreset(Character character, IKernelPreset preset)
		{
			ChangePlayer(character, preset.MakePlayer);
			ChangeMotion(character, preset.MakeMotion);
			ChangeDriver(character, preset.MakeDriver);
			ChangeFacing(character, preset.MakeFacing);
			ChangeAnimim(character, preset.MakeAnimim);
		}

		public void ChangePlayer(Character character, TUnitPlayer unit)
		{
			if (unit != null && unit != m_Player)
			{
				m_Player?.OnDisable();
				m_Player?.OnDispose(character);
				m_Player = unit;
				m_Player.OnStartup(character);
				m_Player.OnEnable();
				this.EventChangePlayer?.Invoke();
			}
		}

		public void ChangeMotion(Character character, TUnitMotion unit)
		{
			if (unit != null && unit != m_Motion)
			{
				m_Motion?.OnDisable();
				m_Motion?.OnDispose(character);
				m_Motion = unit;
				m_Motion.OnStartup(character);
				m_Motion.OnEnable();
				this.EventChangeMotion?.Invoke();
			}
		}

		public void ChangeDriver(Character character, TUnitDriver unit)
		{
			if (unit != null && unit != m_Driver)
			{
				m_Driver?.OnDisable();
				m_Driver?.OnDispose(character);
				m_Driver = unit;
				m_Driver.OnStartup(character);
				m_Driver.OnEnable();
				this.EventChangeDriver?.Invoke();
			}
		}

		public void ChangeFacing(Character character, TUnitFacing unit)
		{
			if (unit != null && unit != m_Facing)
			{
				m_Facing?.OnDisable();
				m_Facing?.OnDispose(character);
				m_Facing = unit;
				m_Facing.OnStartup(character);
				m_Facing.OnEnable();
				this.EventChangeFacing?.Invoke();
			}
		}

		public void ChangeAnimim(Character character, TUnitAnimim unit)
		{
			if (unit != null && unit != m_Animim)
			{
				m_Animim?.OnDisable();
				m_Animim?.OnDispose(character);
				m_Animim = unit;
				m_Animim.OnStartup(character);
				m_Animim.OnEnable();
				this.EventChangeAnimim?.Invoke();
			}
		}

		public void OnStartup(Character character)
		{
			Character = character;
			m_Player?.OnStartup(Character);
			m_Motion?.OnStartup(Character);
			m_Driver?.OnStartup(Character);
			m_Facing?.OnStartup(Character);
			m_Animim?.OnStartup(Character);
		}

		public void AfterStartup(Character character)
		{
			Character = character;
			m_Player?.AfterStartup(Character);
			m_Motion?.AfterStartup(Character);
			m_Driver?.AfterStartup(Character);
			m_Facing?.AfterStartup(Character);
			m_Animim?.AfterStartup(Character);
		}

		public void OnDispose(Character character)
		{
			Character = character;
			m_Player?.OnDispose(Character);
			m_Motion?.OnDispose(Character);
			m_Driver?.OnDispose(Character);
			m_Facing?.OnDispose(Character);
			m_Animim?.OnDispose(Character);
		}

		public virtual void OnEnable()
		{
			m_Player?.OnEnable();
			m_Motion?.OnEnable();
			m_Driver?.OnEnable();
			m_Facing?.OnEnable();
			m_Animim?.OnEnable();
		}

		public virtual void OnDisable()
		{
			m_Player?.OnDisable();
			m_Motion?.OnDisable();
			m_Driver?.OnDisable();
			m_Facing?.OnDisable();
			m_Animim?.OnDisable();
		}

		public virtual void OnUpdate()
		{
			m_Player?.OnUpdate();
			m_Motion?.OnUpdate();
			m_Driver?.OnUpdate();
			m_Facing?.OnUpdate();
			m_Animim?.OnUpdate();
		}

		public virtual void OnFixedUpdate()
		{
			m_Player?.OnFixedUpdate();
			m_Motion?.OnFixedUpdate();
			m_Driver?.OnFixedUpdate();
			m_Facing?.OnFixedUpdate();
			m_Animim?.OnFixedUpdate();
		}

		public virtual void OnDrawGizmos(Character character)
		{
		}
	}
}
