using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemFollow : TShotSystem
	{
		public static readonly int ID = "ShotSystemFollow".GetHashCode();

		private static readonly Vector3 DEFAULT_DISTANCE = new Vector3(0f, 2f, -3f);

		[SerializeField]
		private PropertyGetGameObject m_Follow = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDirection m_Distance = new PropertyGetDirection(DEFAULT_DISTANCE);

		public override int Id => ID;

		public Transform Follow
		{
			set
			{
				m_Follow = GetGameObjectInstance.Create(value);
			}
		}

		public Vector3 Distance
		{
			set
			{
				m_Distance = new PropertyGetDirection(value);
			}
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			GameObject gameObject = m_Follow.Get(shotType.Args);
			Vector3 vector = m_Distance.Get(shotType.Args);
			if (gameObject != null)
			{
				shotType.Position = gameObject.transform.position + vector;
			}
		}
	}
}
