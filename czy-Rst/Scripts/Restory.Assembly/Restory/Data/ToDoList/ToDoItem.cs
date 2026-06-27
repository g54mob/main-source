using Mandragora.Utils;
using Restory.Data.Base;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Data.ToDoList
{
	public class ToDoItem : RestoryEntityInfoBase
	{
		[SerializeField]
		private string nameLocalizationId;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool shouldAddVisitOnItemCompletion;

		[SerializeField]
		private StoryNpcInfo npcForVisitToAddOnCompletion;

		[SerializeField]
		private int gameMinutesBeforeVisitAfterCompletion;

		[SerializeField]
		private string textureIdOfNpcForVisitToAddOnCompletion;

		public string NameLocalizationId => nameLocalizationId;

		public bool ShouldAddVisitOnItemCompletion => shouldAddVisitOnItemCompletion;

		public StoryNpcInfo NpcForVisitToAddOnCompletion => npcForVisitToAddOnCompletion;

		public int GameMinutesBeforeVisitAfterCompletion => gameMinutesBeforeVisitAfterCompletion;

		public string TextureIdOfNpcForVisitToAddOnCompletion => textureIdOfNpcForVisitToAddOnCompletion;
	}
}
