using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class BillingProductIdAttribute : StringPopupAttribute
	{
		private string[] m_options;

		public BillingProductIdAttribute()
			: base((string)null, false, (string[])null)
		{
		}

		private static string[] GetProductIds()
		{
			return null;
		}

		protected override string[] GetDynamicOptions()
		{
			return null;
		}
	}
}
