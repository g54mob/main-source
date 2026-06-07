using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[CreateAssetMenu(fileName = "My Skeleton", menuName = "Game Creator/Characters/Skeleton", order = 50)]
	public class Skeleton : ScriptableObject, IStageGizmos
	{
		[SerializeField]
		private PhysicsMaterial m_Material;

		[SerializeField]
		private CollisionDetectionMode m_CollisionDetection;

		[SerializeReference]
		private Volumes m_Volumes = new Volumes();

		public PhysicsMaterial Material => m_Material;

		public CollisionDetectionMode CollisionDetection => m_CollisionDetection;

		public bool IsEmpty => m_Volumes.Length == 0;

		[field: SerializeField]
		public string EditorModelPath { get; set; }

		public GameObject[] Refresh(Character character)
		{
			if (character == null)
			{
				return Array.Empty<GameObject>();
			}
			Animator animator = character.Animim.Animator;
			if (!(animator != null))
			{
				return Array.Empty<GameObject>();
			}
			return Refresh(animator, character.Motion.Mass);
		}

		public GameObject[] Refresh(Animator animator, float mass)
		{
			return m_Volumes.Update(animator, mass, this);
		}

		public void DrawGizmos(Animator animator, Volumes.Display display)
		{
			m_Volumes.DrawGizmos(animator, display);
		}

		public void StageGizmos(StagingGizmos stagingGizmos)
		{
			Animator animator = stagingGizmos.Animator;
			if (!(animator == null))
			{
				DrawGizmos(animator, Volumes.Display.Solid);
			}
		}
	}
}
