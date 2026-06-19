using UI.Craft;
using Zenject;

namespace Player.TutorialHelpers
{
	public class PlayerClickBlueprintTutorialHelper : BaseTutorialHelper
	{
		[Inject]
		private ICraftUIService _craftUIService;

		private void OnEnable()
		{
			_craftUIService.OnItemButtonCliked += BlueprintClicked;
		}

		private void BlueprintClicked(CraftItemViewModel model)
		{
			if (model.Name.Contains("Table"))
			{
				EmitStep("pressBlueprint");
			}
		}
	}
}
