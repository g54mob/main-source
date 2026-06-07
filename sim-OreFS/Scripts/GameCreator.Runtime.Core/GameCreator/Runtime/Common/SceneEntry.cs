using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class SceneEntry
	{
		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetLocation m_Location = GetLocationNone.Create;

		public GameObject GetTarget(Args args)
		{
			return m_Target.Get(args);
		}

		public Location GetLocation(Args args)
		{
			return m_Location.Get(args);
		}
	}
}
