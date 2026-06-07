namespace Campaign
{
	public class DrawerContentCampaignMotherboardSection : DrawerContentMotherboardSection, ICampaignMotherboardsCountListener
	{
		public TextLabel textLabel;

		public override void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
		{
		}

		public override void SetSection(MotherboardSectionEnum motherboardSectionId)
		{
		}

		public override float GetSize(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override float GetMin(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override float GetMax(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		private void RefreshLabel()
		{
		}

		protected override bool IsMotherboardVisible()
		{
			return false;
		}

		public void OnMotherboardsCountChange(MotherboardSectionEnum variation)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
