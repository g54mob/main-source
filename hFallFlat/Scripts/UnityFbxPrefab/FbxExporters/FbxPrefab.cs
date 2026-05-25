using System;
using System.Collections.Generic;
using UnityEngine;

namespace FbxExporters
{
	public class FbxPrefab : MonoBehaviour
	{
		[Serializable]
		public struct StringPair
		{
			public string FBXObjectName;

			public string UnityObjectName;
		}

		public delegate void HandleUpdate(FbxPrefab updatedInstance, IEnumerable<GameObject> updatedObjects);

		[SerializeField]
		private string m_fbxHistory;

		[SerializeField]
		private List<StringPair> m_nameMapping;

		[Tooltip("Which FBX file does this refer to?")]
		[SerializeField]
		private GameObject m_fbxModel;

		[SerializeField]
		[Tooltip("Should we auto-update this prefab when the FBX file is updated?")]
		private bool m_autoUpdate = true;

		public string FbxHistory
		{
			get
			{
				return m_fbxHistory;
			}
			set
			{
				m_fbxHistory = value;
			}
		}

		public List<StringPair> NameMapping
		{
			get
			{
				return m_nameMapping;
			}
		}

		public GameObject FbxModel
		{
			get
			{
				return m_fbxModel;
			}
			set
			{
				m_fbxModel = value;
			}
		}

		public bool AutoUpdate
		{
			get
			{
				return m_autoUpdate;
			}
			set
			{
				m_autoUpdate = value;
			}
		}

		public static event HandleUpdate OnUpdate;

		public static void CallOnUpdate(FbxPrefab instance, IEnumerable<GameObject> updatedObjects)
		{
			if (FbxPrefab.OnUpdate != null)
			{
				FbxPrefab.OnUpdate(instance, updatedObjects);
			}
		}
	}
}
