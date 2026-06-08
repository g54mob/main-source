using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CSettingSelector : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int SettingID;

		public static int IDFromQuery(EntityQuery q)
		{
			int num = ((!q.IsEmpty) ? q.First<CSettingSelector>().SettingID : 0);
			if (num == 0)
			{
				num = AssetReference.FixedRunSetting[0];
			}
			return num;
		}
	}
}
