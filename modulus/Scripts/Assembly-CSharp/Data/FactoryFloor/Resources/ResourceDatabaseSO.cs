using System.Collections.Generic;
using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[CreateAssetMenu(menuName = "Factory/Resources/ResourceDatabase", fileName = "ResourceDatabase", order = 0)]
	public class ResourceDatabaseSO : ScriptableObject
	{
		[SerializeField]
		private List<ResourceDataSO> _resourceData = new List<ResourceDataSO>();

		public List<ResourceDataSO> ResourceData => _resourceData;

		public ResourceDataSO GetResourceDataFromID(int id)
		{
			if (id < 0 || id >= _resourceData.Count)
			{
				return null;
			}
			return _resourceData[id];
		}

		private void OnValidate()
		{
			AssignIDs();
		}

		private void AssignIDs()
		{
			List<ResourceDataSO> list = new List<ResourceDataSO>();
			for (int i = 0; i < _resourceData.Count; i++)
			{
				if (!list.Contains(_resourceData[i]))
				{
					_resourceData[i].ID = i;
					list.Add(_resourceData[i]);
				}
			}
		}
	}
}
