using Presentation.FactoryFloor.Toolbar;

namespace Events.UI.BarInfo
{
	public struct BlueprintBarInfoDto
	{
		public BlueprintUIData UIData;

		public string[] TextArgs;

		public BlueprintBarInfoDto(BlueprintUIData uiData, params string[] textArgs)
		{
			UIData = uiData;
			TextArgs = textArgs;
		}
	}
}
