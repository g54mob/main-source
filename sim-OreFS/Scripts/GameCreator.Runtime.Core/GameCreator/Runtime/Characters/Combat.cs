using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Combat
	{
		public const int DEFAULT_LAYER_WEAPON = 5;

		public const int DEFAULT_LAYER_CHARGE = 6;

		public const int DEFAULT_LAYER_SHIELD = 7;

		private static readonly Color GIZMO_BLOCK_ON = new Color(0f, 1f, 0f, 0.5f);

		private static readonly Color GIZMO_BLOCK_OFF = new Color(1f, 1f, 0f, 0.5f);

		[NonSerialized]
		private Invincibility m_Invincibility;

		[NonSerialized]
		private Targets m_Targets;

		[NonSerialized]
		private Block m_Block;

		[NonSerialized]
		private Poise m_Poise;

		[NonSerialized]
		private Dictionary<int, Weapon> m_Weapons;

		[NonSerialized]
		private Dictionary<int, IMunition> m_Munitions;

		[NonSerialized]
		private Dictionary<int, IStance> m_Stances;

		[NonSerialized]
		private Character m_Character;

		[NonSerialized]
		private Args m_Args;

		[NonSerialized]
		private float m_MaxDefense;

		[NonSerialized]
		private float m_CurDefense;

		public float MaximumDefense
		{
			get
			{
				return m_MaxDefense;
			}
			set
			{
				m_MaxDefense = Math.Max(0f, value);
			}
		}

		public float CurrentDefense
		{
			get
			{
				return m_CurDefense;
			}
			set
			{
				m_CurDefense = Math.Clamp(value, 0f, m_MaxDefense);
				this.EventDefenseChange?.Invoke();
			}
		}

		public Invincibility Invincibility => m_Invincibility;

		public Targets Targets => m_Targets;

		public Block Block => m_Block;

		public Poise Poise => m_Poise;

		public Weapon[] Weapons
		{
			get
			{
				List<Weapon> list = new List<Weapon>();
				foreach (KeyValuePair<int, Weapon> weapon in m_Weapons)
				{
					list.Add(weapon.Value);
				}
				return list.ToArray();
			}
		}

		public IMunition[] Munitions
		{
			get
			{
				List<IMunition> list = new List<IMunition>();
				foreach (KeyValuePair<int, IMunition> munition in m_Munitions)
				{
					list.Add(munition.Value);
				}
				return list.ToArray();
			}
		}

		[field: NonSerialized]
		public float LastBlockTime { get; private set; } = -999f;

		[field: NonSerialized]
		public float LastParryTime { get; private set; } = -999f;

		[field: NonSerialized]
		public float LastBreakTime { get; private set; } = -999f;

		public event Action<IWeapon, GameObject> EventEquip;

		public event Action<IWeapon, GameObject> EventUnequip;

		public event Action EventDefenseChange;

		public Combat()
		{
			m_Invincibility = new Invincibility();
			m_Targets = new Targets();
			m_Block = new Block();
			m_Poise = new Poise();
			m_Weapons = new Dictionary<int, Weapon>();
			m_Munitions = new Dictionary<int, IMunition>();
			m_Stances = new Dictionary<int, IStance>();
		}

		internal void OnStartup(Character character)
		{
			m_Character = character;
			m_Args = new Args(character, character);
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnDispose(Character character)
		{
			m_Character = character;
			m_Args = new Args(character, character);
		}

		internal void OnEnable()
		{
			foreach (KeyValuePair<int, IStance> stance in m_Stances)
			{
				stance.Value.OnEnable(m_Character);
			}
			m_Invincibility.OnEnable(m_Character);
			m_Block.OnEnable(m_Character);
		}

		internal void OnDisable()
		{
			foreach (KeyValuePair<int, IStance> stance in m_Stances)
			{
				stance.Value.OnDisable(m_Character);
			}
			m_Invincibility.OnDisable(m_Character);
			m_Block.OnDisable(m_Character);
		}

		internal void OnLateUpdate()
		{
			CalculateDefense();
			foreach (KeyValuePair<int, IStance> stance in m_Stances)
			{
				stance.Value.OnUpdate();
			}
			m_Invincibility.OnUpdate();
		}

		public TMunitionValue RequestMunition(IWeapon weapon)
		{
			if (weapon == null)
			{
				return null;
			}
			if (m_Munitions.TryGetValue(weapon.Id.Hash, out var value))
			{
				return value.Value;
			}
			value = new Munition(weapon.Id.Hash, weapon.CreateMunition());
			m_Munitions.Add(weapon.Id.Hash, value);
			return value.Value;
		}

		public T RequestStance<T>() where T : IStance, new()
		{
			if (m_Character == null)
			{
				return default(T);
			}
			int hashCode = typeof(T).GetHashCode();
			if (m_Stances.TryGetValue(hashCode, out var value))
			{
				return (T)value;
			}
			T val = new T();
			val.OnEnable(m_Character);
			m_Stances.Add(hashCode, val);
			return val;
		}

		public ReactionOutput GetHitReaction(ReactionInput input, Args args, IReaction reaction)
		{
			ReactionItem reactionItem = reaction?.CanRun(m_Character, args, input);
			if (reactionItem != null)
			{
				return reaction.Run(m_Character, args, input, reactionItem);
			}
			Weapon[] weapons = m_Character.Combat.Weapons;
			foreach (Weapon weapon in weapons)
			{
				if (weapon.Asset.HitReaction != null)
				{
					reactionItem = weapon.Asset.HitReaction.CanRun(m_Character, args, input);
					if (reactionItem != null)
					{
						return weapon.Asset.HitReaction.Run(m_Character, args, input, reactionItem);
					}
				}
			}
			Reaction reaction2 = m_Character.Animim.Reaction;
			if (reaction2 == null)
			{
				return ReactionOutput.None;
			}
			reactionItem = reaction2.CanRun(m_Character, args, input);
			if (reactionItem == null)
			{
				return ReactionOutput.None;
			}
			return reaction2.Run(m_Character, args, input, reactionItem);
		}

		public void ResetBlockTime()
		{
			LastBlockTime = -999f;
		}

		public void ResetParryTime()
		{
			LastParryTime = -999f;
		}

		public void ResetBreakTime()
		{
			LastBreakTime = -999f;
		}

		public bool IsEquipped(IWeapon weapon)
		{
			if (weapon != null)
			{
				return m_Weapons.ContainsKey(weapon.Id.Hash);
			}
			return false;
		}

		public async Task Equip(IWeapon asset, GameObject instance, Args args)
		{
			if (asset != null && !IsEquipped(asset))
			{
				Weapon value = new Weapon(asset, instance);
				m_Weapons.Add(asset.Id.Hash, value);
				if (asset.Shield != null)
				{
					IShield shield = FindShield();
					m_Block.SetShield(shield);
				}
				if (!m_Munitions.ContainsKey(asset.Id.Hash))
				{
					Munition value2 = new Munition(asset.Id.Hash, asset.CreateMunition());
					m_Munitions.Add(asset.Id.Hash, value2);
				}
				Args args2 = new Args(m_Character.gameObject, instance);
				await asset.RunOnEquip(m_Character, args2);
				this.EventEquip?.Invoke(asset, instance);
			}
		}

		public async Task Unequip(IWeapon asset, Args args)
		{
			if (asset == null || !IsEquipped(asset))
			{
				return;
			}
			Weapon weapon = m_Weapons[asset.Id.Hash];
			m_Weapons.Remove(asset.Id.Hash);
			if (asset.Shield != null)
			{
				if (m_Block.IsBlocking && asset.Shield == m_Block.Shield)
				{
					m_Block.LowerGuard();
				}
				IShield shield = FindShield();
				m_Block.SetShield(shield);
			}
			Args args2 = new Args(m_Character.gameObject, weapon.Instance);
			await asset.RunOnUnequip(m_Character, args2);
			this.EventUnequip?.Invoke(asset, weapon.Instance);
		}

		public GameObject GetProp(IWeapon asset)
		{
			if (asset == null)
			{
				return null;
			}
			if (!m_Weapons.TryGetValue(asset.Id.Hash, out var value))
			{
				return null;
			}
			return value.Instance;
		}

		public IShield GetBlock(ShieldInput input, Args args, bool canBlock, bool canParry, out ShieldOutput output)
		{
			if (m_Block.Shield == null)
			{
				output = ShieldOutput.NO_BLOCK;
				return null;
			}
			m_Block.BlockHitTime = m_Character.Time.Time;
			ShieldOutput shieldOutput = m_Block.Shield.CanDefend(m_Character, args, input);
			if (shieldOutput.Type == BlockType.Block && !canBlock)
			{
				shieldOutput = new ShieldOutput(shieldOutput.IsBlocked, shieldOutput.Point, shieldOutput.ElapsedTime, BlockType.Break);
			}
			if (shieldOutput.Type == BlockType.Parry && !canParry)
			{
				shieldOutput = new ShieldOutput(shieldOutput.IsBlocked, shieldOutput.Point, shieldOutput.ElapsedTime, BlockType.Break);
			}
			switch (shieldOutput.Type)
			{
			case BlockType.Block:
				LastBlockTime = m_Character.Time.Time;
				break;
			case BlockType.Parry:
				LastParryTime = m_Character.Time.Time;
				break;
			case BlockType.Break:
				LastBreakTime = m_Character.Time.Time;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case BlockType.None:
				break;
			}
			output = shieldOutput;
			if (shieldOutput.Type == BlockType.None)
			{
				return null;
			}
			return m_Block.Shield;
		}

		private IShield FindShield()
		{
			int num = -1;
			IShield result = null;
			foreach (KeyValuePair<int, Weapon> weapon in m_Weapons)
			{
				IShield shield = weapon.Value.Asset.Shield;
				if ((shield?.Priority ?? (-1)) > num)
				{
					num = shield?.Priority ?? (-1);
					result = shield;
				}
			}
			return result;
		}

		private void CalculateDefense()
		{
			if (m_Block.Shield != null)
			{
				float defense = m_Block.Shield.GetDefense(m_Args);
				float recovery = m_Block.Shield.GetRecovery(m_Args);
				float cooldown = m_Block.Shield.GetCooldown(m_Args);
				float num = m_Block.BlockHitTime + cooldown;
				float value = ((m_Character.Time.Time >= num) ? (CurrentDefense + recovery * m_Character.Time.DeltaTime) : CurrentDefense);
				MaximumDefense = defense;
				CurrentDefense = Math.Clamp(value, 0f, defense);
			}
			else
			{
				MaximumDefense = 0f;
				CurrentDefense = 0f;
			}
		}

		internal void OnDrawGizmos(Character character)
		{
			if (Application.isPlaying && m_Block.Shield != null)
			{
				float angle = m_Block.Shield.GetAngle(new Args(character));
				Gizmos.color = (m_Block.IsBlocking ? GIZMO_BLOCK_ON : GIZMO_BLOCK_OFF);
				GizmosExtension.Arc(character.Feet + Vector3.up * 0.05f, character.transform.rotation, angle, character.Motion.Radius + 0.5f, character.Motion.Radius + 0.7f);
			}
		}
	}
}
