using Presentation.UI.Menus;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Check ModuleViewer Open", fileName = "CheckModuleViewerOpen", order = 11)]
	public class CheckModuleViewerOpenSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private bool _shouldBeOpen = true;

		[SerializeField]
		private ModuleViewerLocator _moduleViewerLocator;

		public override bool IsValid()
		{
			return _shouldBeOpen == _moduleViewerLocator.ModuleViewer.isActiveAndEnabled;
		}

		public override void Reset()
		{
		}
	}
}
