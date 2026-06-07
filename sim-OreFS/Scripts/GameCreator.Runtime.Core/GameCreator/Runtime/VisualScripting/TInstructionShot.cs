using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Shot", "The camera Shot targeted")]
	[Keywords(new string[] { "Cameras", "Shot" })]
	public abstract class TInstructionShot : Instruction
	{
		[SerializeField]
		protected PropertyGetGameObject m_Shot = GetGameObjectShot.Create;

		protected abstract int SystemID { get; }

		protected T GetShotSystem<T>(Args args) where T : class, IShotSystem
		{
			ShotCamera shotCamera = m_Shot.Get<ShotCamera>(args);
			if (!(shotCamera != null))
			{
				return null;
			}
			return shotCamera.ShotType.GetSystem(SystemID) as T;
		}
	}
}
