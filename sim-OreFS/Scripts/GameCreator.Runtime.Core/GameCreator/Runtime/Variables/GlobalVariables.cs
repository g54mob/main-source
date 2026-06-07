using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	public class GlobalVariables
	{
		[NonSerialized]
		private Dictionary<IdString, GlobalNameVariables> m_MapNameVariables;

		[NonSerialized]
		private Dictionary<IdString, GlobalListVariables> m_MapListVariables;

		[SerializeField]
		private GlobalNameVariables[] m_NameVariables = Array.Empty<GlobalNameVariables>();

		[SerializeField]
		private GlobalListVariables[] m_ListVariables = Array.Empty<GlobalListVariables>();

		public GlobalNameVariables[] NameVariables => m_NameVariables;

		public GlobalListVariables[] ListVariables => m_ListVariables;

		public GlobalNameVariables GetNameVariablesAsset(IdString itemID)
		{
			RequireInitialize();
			if (!m_MapNameVariables.TryGetValue(itemID, out var value))
			{
				return null;
			}
			return value;
		}

		public GlobalListVariables GetListVariablesAsset(IdString itemID)
		{
			RequireInitialize();
			if (!m_MapListVariables.TryGetValue(itemID, out var value))
			{
				return null;
			}
			return value;
		}

		public void RequireInitialize()
		{
			if (m_MapNameVariables == null || m_MapListVariables == null)
			{
				m_MapNameVariables = new Dictionary<IdString, GlobalNameVariables>();
				m_MapListVariables = new Dictionary<IdString, GlobalListVariables>();
				GlobalNameVariables[] nameVariables = m_NameVariables;
				foreach (GlobalNameVariables globalNameVariables in nameVariables)
				{
					m_MapNameVariables[globalNameVariables.UniqueID] = globalNameVariables;
				}
				GlobalListVariables[] listVariables = m_ListVariables;
				foreach (GlobalListVariables globalListVariables in listVariables)
				{
					m_MapListVariables[globalListVariables.UniqueID] = globalListVariables;
				}
			}
		}
	}
}
