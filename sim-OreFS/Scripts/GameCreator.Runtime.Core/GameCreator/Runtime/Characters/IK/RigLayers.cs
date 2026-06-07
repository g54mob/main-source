using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	public class RigLayers : TPolymorphicList<TRig>
	{
		[SerializeReference]
		protected List<TRig> m_Rigs = new List<TRig>();

		public override int Length => m_Rigs.Count;

		[field: NonSerialized]
		private Character Character { get; set; }

		public T GetRig<T>() where T : TRig
		{
			foreach (TRig rig in m_Rigs)
			{
				if (rig is T result)
				{
					return result;
				}
			}
			return null;
		}

		public T Create<T>() where T : TRig, new()
		{
			if (Character == null)
			{
				return null;
			}
			T val = new T();
			m_Rigs.Add(val);
			val.OnStartup(Character);
			if (Character.isActiveAndEnabled)
			{
				val.OnEnable(Character);
			}
			return val;
		}

		public void OnStartup(InverseKinematics inverseKinematics)
		{
			Character = inverseKinematics.Character;
			foreach (TRig rig in m_Rigs)
			{
				if (Character.Animim.Animator.isHuman || !rig.RequiresHuman)
				{
					rig?.OnStartup(Character);
				}
			}
		}

		public void OnEnable()
		{
			foreach (TRig rig in m_Rigs)
			{
				if (Character.Animim.Animator.isHuman || !rig.RequiresHuman)
				{
					rig?.OnEnable(Character);
				}
			}
		}

		public void OnDisable()
		{
			if (Character.Animim?.Animator == null)
			{
				return;
			}
			foreach (TRig rig in m_Rigs)
			{
				if (Character.Animim.Animator.isHuman || !rig.RequiresHuman)
				{
					rig?.OnDisable(Character);
				}
			}
		}

		public void OnUpdate()
		{
			foreach (TRig rig in m_Rigs)
			{
				if (Character.Animim.Animator.isHuman || !rig.RequiresHuman)
				{
					rig?.OnUpdate(Character);
				}
			}
		}

		public void OnDrawGizmos()
		{
			foreach (TRig rig in m_Rigs)
			{
				if (Character.Animim.Animator.isHuman || !rig.RequiresHuman)
				{
					rig?.OnDrawGizmos(Character);
				}
			}
		}
	}
}
