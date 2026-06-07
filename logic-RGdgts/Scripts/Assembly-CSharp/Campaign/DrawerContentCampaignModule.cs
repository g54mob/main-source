namespace Campaign
{
	public class DrawerContentCampaignModule : DrawerContentModule, ICampaignModulesCountListener
	{
		public TextLabel textLabel;

		public override void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
		{
		}

		public override void SetModule(ModuleGestaltVariationEnum moduleGestaltVariationId, int rotation)
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

		protected override bool IsModuleVisible()
		{
			return false;
		}

		public void OnModuleCountChange(ModuleGestaltVariationEnum variation)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
