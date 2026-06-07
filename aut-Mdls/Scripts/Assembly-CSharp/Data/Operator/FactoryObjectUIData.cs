using System;
using Data.FactoryFloor.Behaviours;
using Data.Variables;
using UnityEngine;

namespace Data.Operator
{
	[Serializable]
	[CreateAssetMenu(menuName = "UI/FactoryObjectUIData", fileName = "FactoryObjectUIData", order = 0)]
	public class FactoryObjectUIData : ScriptableObject
	{
		[field: SerializeField]
		[field: LocaKey]
		public string NameLocKey { get; private set; }

		[field: SerializeField]
		[field: LocaKey]
		public string ShortNameLocKey { get; private set; }

		[field: SerializeField]
		[field: LocaKey]
		public string TooltipLocKey { get; private set; }

		[field: SerializeField]
		public Sprite PreviewSprite { get; private set; }

		[field: SerializeField]
		public Sprite NotificationSprite { get; private set; }

		[field: SerializeField]
		public FactoryObjectBehaviour FactoryObjectBehaviour { get; private set; }

		[field: SerializeField]
		public FactoryObjectData FactoryObject { get; private set; }

		[field: SerializeField]
		public bool HideFromBuildBar { get; private set; }

		[field: SerializeField]
		public BoolVariableSO ShowCondition { get; private set; }

		[field: SerializeField]
		public bool HideProductionLevelInUI { get; private set; }

		[field: Header("Select Behavior")]
		[field: SerializeField]
		public bool IsConfigurable { get; private set; }

		[field: Header("Speed info")]
		[field: SerializeField]
		public bool InputDefinedByBeltSpeed { get; private set; }

		[field: SerializeField]
		public bool InputDefinedByConfiguration { get; private set; }

		[field: SerializeField]
		public bool OutputDefinedByBeltSpeed { get; private set; }

		[field: SerializeField]
		public bool OutputDefinedByConfiguration { get; private set; }

		[field: SerializeField]
		public float InputMultiplier { get; private set; } = 1f;

		[field: SerializeField]
		public float OutputMultiplier { get; private set; } = 1f;

		[field: SerializeField]
		public bool IsConnector { get; private set; }

		[field: SerializeField]
		public bool HideInput { get; private set; }

		[field: SerializeField]
		public bool HideOutput { get; private set; }
	}
}
