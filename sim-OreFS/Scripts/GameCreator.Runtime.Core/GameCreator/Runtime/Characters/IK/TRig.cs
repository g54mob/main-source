using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("IK Rig")]
	public abstract class TRig : TPolymorphicItem<TRig>
	{
		[NonSerialized]
		private bool m_IsActive = true;

		[field: NonSerialized]
		protected Args Args { get; private set; }

		[field: NonSerialized]
		public Character Character { get; private set; }

		public Animator Animator
		{
			get
			{
				if (!(Character != null))
				{
					return null;
				}
				return Character.Animim.Animator;
			}
		}

		public bool IsActive
		{
			get
			{
				if (DisableOnBusy && Character.Busy.IsBusy)
				{
					return false;
				}
				if (m_IsActive && base.IsEnabled)
				{
					return !Character.IsDead;
				}
				return false;
			}
			set
			{
				m_IsActive = value;
			}
		}

		public abstract override string Title { get; }

		public abstract string Name { get; }

		public abstract bool RequiresHuman { get; }

		public abstract bool DisableOnBusy { get; }

		public void OnStartup(Character character)
		{
			Args = new Args(character);
			Character = character;
			DoStartup(character);
			Character.EventAfterChangeModel += DoChangeModel;
		}

		public void OnEnable(Character character)
		{
			DoEnable(character);
		}

		public void OnDisable(Character character)
		{
			DoDisable(character);
		}

		public abstract void OnUpdate(Character character);

		public void OnDrawGizmos(Character character)
		{
			DoDrawGizmos(character);
		}

		private void OnChangeModel()
		{
			DoChangeModel();
		}

		protected virtual void DoStartup(Character character)
		{
		}

		protected virtual void DoEnable(Character character)
		{
		}

		protected virtual void DoDisable(Character character)
		{
		}

		protected virtual void DoUpdate(Character character)
		{
		}

		protected virtual void DoChangeModel()
		{
		}

		protected virtual void DoDrawGizmos(Character character)
		{
		}
	}
}
