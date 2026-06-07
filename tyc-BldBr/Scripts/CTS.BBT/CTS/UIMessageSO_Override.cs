using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/UIMessageSO Override")]
	public class UIMessageSO_Override : UIMessageBase
	{
		[field: SerializeField]
		public UIMessageBase Reference { get; private set; }

		[field: SerializeField]
		[field: ShowIf("HasReference")]
		public bool OverrideSprite { get; private set; }

		[field: SerializeField]
		[field: ShowIf(EConditionOperator.And, new string[] { "HasReference", "OverrideSprite" })]
		public Sprite MessageSprite { get; private set; }

		[field: SerializeField]
		[field: ShowIf("HasReference")]
		public bool OverrideTitle { get; private set; }

		[field: SerializeField]
		[field: ShowIf(EConditionOperator.And, new string[] { "HasReference", "OverrideTitle" })]
		public LocalizedString MessageTitle { get; private set; }

		[field: SerializeField]
		[field: ShowIf("HasReference")]
		public bool OverrideSubtitle { get; private set; }

		[field: SerializeField]
		[field: ShowIf(EConditionOperator.And, new string[] { "HasReference", "OverrideSubtitle" })]
		public LocalizedString MessageSubtitle { get; private set; }

		[field: SerializeField]
		[field: ShowIf("HasReference")]
		public bool OverrideDescription { get; private set; }

		[field: SerializeField]
		[field: ShowIf(EConditionOperator.And, new string[] { "HasReference", "OverrideDescription" })]
		public LocalizedString MessageBody { get; private set; }

		[field: SerializeField]
		[field: ShowIf("HasReference")]
		public bool OverrideVisual { get; private set; }

		[field: SerializeField]
		[field: ShowIf(EConditionOperator.And, new string[] { "HasReference", "OverrideVisual" })]
		public bool UseSpecificMessageVisual { get; private set; }

		[field: SerializeField]
		[field: ShowIf(EConditionOperator.And, new string[] { "HasReference", "UseSpecificMessageVisual", "OverrideVisual" })]
		public StringKey SpecificMessageVisual { get; private set; }

		[field: SerializeField]
		[field: ShowIf("HasReference")]
		public bool OverrideEndEvent { get; private set; }

		[field: SerializeField]
		[field: ShowIf(EConditionOperator.And, new string[] { "HasReference", "OverrideEndEvent" })]
		public UnityEvent EndEvent { get; private set; }

		private bool HasReference()
		{
			return (object)Reference != null;
		}

		public override Sprite GetSprite()
		{
			if (OverrideSprite)
			{
				return MessageSprite;
			}
			if (HasReference())
			{
				return Reference.GetSprite();
			}
			return null;
		}

		public override LocalizedString GetTitle()
		{
			if (OverrideTitle)
			{
				return MessageTitle;
			}
			if (HasReference())
			{
				return Reference.GetTitle();
			}
			return null;
		}

		public override LocalizedString GetSubtitle()
		{
			if (OverrideSubtitle)
			{
				return MessageSubtitle;
			}
			if (HasReference())
			{
				return Reference.GetSubtitle();
			}
			return null;
		}

		public override LocalizedString GetDescription()
		{
			if (OverrideDescription)
			{
				return MessageBody;
			}
			if (HasReference())
			{
				return Reference.GetDescription();
			}
			return null;
		}

		public override bool ShouldUseSpecificVisual()
		{
			if (OverrideVisual)
			{
				return UseSpecificMessageVisual;
			}
			if (HasReference())
			{
				return Reference.ShouldUseSpecificVisual();
			}
			return false;
		}

		public override StringKey GetSpecificVisualKey()
		{
			if (OverrideVisual)
			{
				return SpecificMessageVisual;
			}
			if (HasReference())
			{
				return Reference.GetSpecificVisualKey();
			}
			return default(StringKey);
		}

		public override UnityEvent GetEndEvent()
		{
			if (OverrideEndEvent)
			{
				return EndEvent;
			}
			if (HasReference())
			{
				return Reference.GetEndEvent();
			}
			return null;
		}
	}
}
