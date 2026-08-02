using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GRP
{
	public class PhysicsController
	{
		public PhysicsScene physicsScene;

		public Scene scene;

		private readonly List<PhysicsBody> managedBodyList;

		private readonly List<PhysicsPiece> managedPieceList;

		private static uint sceneCounter;

		public event Action onUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Init()
		{
		}

		public void AddPiece(PhysicsPiece piece)
		{
		}

		public PhysicsBody AddBody(string name, GameObject collider, float mass, Vector3 position, Quaternion rotation, bool isStatic)
		{
			return null;
		}

		public void Update(float dt)
		{
		}

		public void Destroy()
		{
		}
	}
}
