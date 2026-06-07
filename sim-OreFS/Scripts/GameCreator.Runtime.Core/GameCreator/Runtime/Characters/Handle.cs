using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[CreateAssetMenu(fileName = "My Handle", menuName = "Game Creator/Characters/Handle", order = 50)]
	public class Handle : ScriptableObject
	{
		[SerializeField]
		private HandleList m_Handles = new HandleList();

		public HandleResult Get(Args args)
		{
			return m_Handles.Get(args);
		}

		public override string ToString()
		{
			return base.name;
		}
	}
}
