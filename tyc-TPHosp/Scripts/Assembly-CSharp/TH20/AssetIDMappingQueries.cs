using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public static class AssetIDMappingQueries
	{
		public static bool TryLookupAssetIDDetails(ISharedInstance rootObject, int assetID, out string path, out int owningAssetID, out object obj)
		{
			AssetIDMapping.ToVisit firstVisited = new AssetIDMapping.ToVisit(rootObject, rootObject.GetID, "", rootObject.GetID);
			List<AssetIDMapping.ToVisit> list = new List<AssetIDMapping.ToVisit>();
			if (AssetIDMapping.GenerateExternalReferencesListInternal(firstVisited, list).TryGetValue(assetID, out obj))
			{
				object objToSearchFor = obj;
				AssetIDMapping.ToVisit toVisit = list.Find((AssetIDMapping.ToVisit x) => x.Obj == objToSearchFor);
				path = toVisit.MemberPath;
				owningAssetID = toVisit.OwningAssetID;
				obj = toVisit.Obj;
				return true;
			}
			path = null;
			owningAssetID = 0;
			obj = null;
			return false;
		}

		public static bool TryLookupAssetDetailsByObject(ISharedInstance rootObject, object obj, out string path, out int owningAssetID, out int assetID)
		{
			AssetIDMapping.ToVisit firstVisited = new AssetIDMapping.ToVisit(rootObject, rootObject.GetID, "", rootObject.GetID);
			List<AssetIDMapping.ToVisit> list = new List<AssetIDMapping.ToVisit>();
			if (AssetIDMapping.GenerateExternalReferencesListInternal(firstVisited, list).Reverse.TryGetValue(obj, out assetID))
			{
				object objToSearchFor = obj;
				AssetIDMapping.ToVisit toVisit = list.Find((AssetIDMapping.ToVisit x) => x.Obj == objToSearchFor);
				path = toVisit.MemberPath;
				owningAssetID = toVisit.OwningAssetID;
				return true;
			}
			path = null;
			owningAssetID = 0;
			assetID = 0;
			return false;
		}
	}
}
