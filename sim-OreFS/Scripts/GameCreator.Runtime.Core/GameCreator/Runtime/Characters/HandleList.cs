using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class HandleList : TPolymorphicList<HandleItem>
	{
		[SerializeReference]
		private HandleItem[] m_Handles = new HandleItem[1]
		{
			new HandleItem()
		};

		public override int Length => m_Handles.Length;

		public HandleResult Get(Args args)
		{
			HandleItem[] handles = m_Handles;
			foreach (HandleItem handleItem in handles)
			{
				if (handleItem.CheckConditions(args))
				{
					return new HandleResult(handleItem.Bone, handleItem.GetPosition(args), handleItem.GetRotation(args));
				}
			}
			return new HandleResult(default(Bone), Vector3.zero, Quaternion.identity);
		}
	}
}
