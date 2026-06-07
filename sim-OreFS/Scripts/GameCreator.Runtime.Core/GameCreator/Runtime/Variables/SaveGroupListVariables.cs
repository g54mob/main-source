using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	internal class SaveGroupListVariables
	{
		[Serializable]
		private class Group
		{
			[SerializeField]
			private string m_ID;

			[SerializeField]
			private SaveSingleListVariables m_Data;

			public string ID => m_ID;

			public SaveSingleListVariables Data => m_Data;

			public Group(string id, ListVariableRuntime runtime)
			{
				m_ID = id;
				m_Data = new SaveSingleListVariables(runtime);
			}
		}

		[SerializeField]
		private List<Group> m_Groups;

		public SaveGroupListVariables(Dictionary<string, ListVariableRuntime> runtime)
		{
			m_Groups = new List<Group>();
			foreach (KeyValuePair<string, ListVariableRuntime> item in runtime)
			{
				m_Groups.Add(new Group(item.Key, item.Value));
			}
		}

		public int Count()
		{
			return m_Groups?.Count ?? 0;
		}

		public string GetID(int index)
		{
			return m_Groups?[index].ID ?? string.Empty;
		}

		public SaveSingleListVariables GetData(int index)
		{
			return m_Groups?[index].Data;
		}
	}
}
