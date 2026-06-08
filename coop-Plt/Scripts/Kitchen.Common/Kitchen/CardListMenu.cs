using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class CardListMenu : Menu<MenuAction>
	{
		public override bool RequiresBackingPanel { get; protected set; }

		public CardListMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			CardScrollerElement cardScrollerElement = ModuleDirectory.Add<CardScrollerElement>(Container, new Vector2(0f, 0f));
			cardScrollerElement.SetCardList(GameInfo.AllCurrentCards);
			ModuleList.AddModule(cardScrollerElement, cardScrollerElement.transform.localPosition.ToFlat());
		}
	}
}
