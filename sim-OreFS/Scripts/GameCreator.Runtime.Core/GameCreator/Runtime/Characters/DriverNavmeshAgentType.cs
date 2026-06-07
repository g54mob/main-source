using System;
using UnityEngine;
using UnityEngine.AI;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class DriverNavmeshAgentType
	{
		[SerializeField]
		private int m_AgentTypeIndex;

		public int AgentType
		{
			get
			{
				if (m_AgentTypeIndex >= NavMesh.GetSettingsCount())
				{
					return NavMesh.GetSettingsByIndex(0).agentTypeID;
				}
				return NavMesh.GetSettingsByIndex(m_AgentTypeIndex).agentTypeID;
			}
		}
	}
}
