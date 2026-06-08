using UnityEngine;

namespace Kitchen.Modules
{
	[CreateAssetMenu(fileName = "GridMenuPaginatedGenericConfig", menuName = "Kitchen/GridMenu/Paginated")]
	public class GridMenuPaginatedGenericConfig : GridMenuGenericConfig
	{
		public override GridMenu Instantiate(Transform container, int player, bool has_back)
		{
			return new GenericPaginatedGridMenu(Items, container, player, has_back);
		}
	}
}
