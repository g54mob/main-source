using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class DynamicConvertSettings : Settings
	{
		private Rect _prefabFolderDropRect;

		[SerializeField]
		private GameObjectType _convertableObjectTypes = GameObjectTypeHelper.AllCombined;

		[SerializeField]
		private string _prefabFolder = string.Empty;

		[SerializeField]
		private bool _processPrefabSubfolders = true;

		public GameObjectType ConvertableObjectTypes
		{
			get
			{
				return _convertableObjectTypes;
			}
			set
			{
				_convertableObjectTypes = value;
			}
		}

		public string PrefabFolder
		{
			get
			{
				return _prefabFolder;
			}
			set
			{
				if (value != null)
				{
					_prefabFolder = value;
				}
			}
		}

		public bool ProcessPrefabSubfolders
		{
			get
			{
				return _processPrefabSubfolders;
			}
			set
			{
				_processPrefabSubfolders = value;
			}
		}

		public Rect PrefabFolderDropRect => _prefabFolderDropRect;
	}
}
