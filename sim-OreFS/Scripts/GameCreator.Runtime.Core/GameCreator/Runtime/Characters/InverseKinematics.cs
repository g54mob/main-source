using System;
using GameCreator.Runtime.Characters.IK;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class InverseKinematics
	{
		[NonSerialized]
		private Character m_Character;

		[NonSerialized]
		private GameObject m_Model;

		[SerializeField]
		private RigLayers m_RigLayers = new RigLayers();

		public Character Character => m_Character;

		public GameObject Model
		{
			get
			{
				if (m_Model == null)
				{
					m_Model = m_Character.Animim.Animator.gameObject;
				}
				return m_Model;
			}
		}

		public T GetRig<T>() where T : TRig
		{
			return m_RigLayers.GetRig<T>();
		}

		public bool HasRig<T>() where T : TRig
		{
			return m_RigLayers.GetRig<T>() != null;
		}

		public T RequireRig<T>() where T : TRig, new()
		{
			return GetRig<T>() ?? m_RigLayers.Create<T>();
		}

		internal void OnStartup(Character character)
		{
			m_Character = character;
			m_RigLayers.OnStartup(this);
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnEnable()
		{
			m_RigLayers.OnEnable();
		}

		internal void OnDisable()
		{
			m_RigLayers.OnDisable();
		}

		internal void OnUpdate()
		{
			m_RigLayers.OnUpdate();
		}

		public void OnDrawGizmos(Character character)
		{
			if (Application.isPlaying)
			{
				m_RigLayers.OnDrawGizmos();
			}
		}
	}
}
