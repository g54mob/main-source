namespace NSMedieval.UI
{
	public class EquipmentSlotLayoutItemView : ButtonLayoutItemView
	{
		private ResourceIconItemView resourceIconItemView;

		public ResourceIconItemView IconItemView
		{
			get
			{
				if (resourceIconItemView == null)
				{
					resourceIconItemView = base.GroupItems[base.IconIndex].GetComponent<ResourceIconItemView>();
				}
				return resourceIconItemView;
			}
		}

		public void SetImageData(string resourceId)
		{
			IconItemView.SetData(resourceId);
		}
	}
}
