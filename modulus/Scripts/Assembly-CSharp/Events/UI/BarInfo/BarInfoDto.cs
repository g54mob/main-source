using Data.FactoryFloor.Behaviours;
using Data.Operator;
using UnityEngine;

namespace Events.UI.BarInfo
{
	public struct BarInfoDto
	{
		public bool Vertical;

		public RectTransform ReferenceButton;

		public Sprite ToolImage;

		public string TitleLocKey;

		public string TextLocKey;

		public string[] TextArgs;

		public FactoryObjectBehaviour FactoryObjectBehaviour;

		public FactoryObjectData FactoryObjectData;

		public FactoryObjectUIData FactoryObjectUIData;

		public BarInfoDto(bool vertical, FactoryObjectUIData factoryObjectUIData, RectTransform referenceButton, params string[] textArgs)
		{
			Vertical = vertical;
			ReferenceButton = referenceButton;
			FactoryObjectUIData = factoryObjectUIData;
			ToolImage = factoryObjectUIData.PreviewSprite;
			TitleLocKey = factoryObjectUIData.NameLocKey;
			TextLocKey = factoryObjectUIData.TooltipLocKey;
			TextArgs = textArgs;
			FactoryObjectBehaviour = factoryObjectUIData.FactoryObjectBehaviour;
			FactoryObjectData = factoryObjectUIData.FactoryObject;
		}

		public BarInfoDto(bool vertical, Sprite toolImage, string titleId, string textId, FactoryObjectBehaviour factoryObjectBehaviour, FactoryObjectData factoryObjectData, RectTransform referenceButton, params string[] textArgs)
		{
			Vertical = vertical;
			ReferenceButton = referenceButton;
			FactoryObjectUIData = null;
			ToolImage = toolImage;
			TitleLocKey = titleId;
			TextLocKey = textId;
			TextArgs = textArgs;
			FactoryObjectBehaviour = factoryObjectBehaviour;
			FactoryObjectData = factoryObjectData;
		}
	}
}
