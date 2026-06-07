using System.Collections.Generic;
using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[CreateAssetMenu(menuName = "Factory/Resources/ResourceOriginsDatabase", fileName = "ResourceOriginsDatabase", order = 0)]
	public class ResourceOriginsDatabase : ScriptableObject
	{
		private Dictionary<NonShapeResourceDataSO, ResourceOriginInfo> _resourceOriginInfo = new Dictionary<NonShapeResourceDataSO, ResourceOriginInfo>();

		public ResourceOriginInfo GetResourceOriginInfo(NonShapeResourceDataSO nonShapeResourceDataSO)
		{
			if (_resourceOriginInfo.ContainsKey(nonShapeResourceDataSO))
			{
				return _resourceOriginInfo[nonShapeResourceDataSO];
			}
			return null;
		}

		public void AddOriginInfo(NonShapeResourceDataSO nonShapeResourceData, ResourceOriginInfo resourceOriginInfo)
		{
			if (!_resourceOriginInfo.ContainsKey(nonShapeResourceData))
			{
				_resourceOriginInfo.Add(nonShapeResourceData, resourceOriginInfo);
			}
		}
	}
}
