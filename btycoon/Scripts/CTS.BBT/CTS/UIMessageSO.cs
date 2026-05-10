using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "UIMessageSO", menuName = "BBT/UIMessageSO")]
	public class UIMessageSO : UIMessageBase
	{
		[field: SerializeField]
		public Sprite MessageSprite { get; private set; }

		[field: SerializeField]
		public LocalizedString MessageTitle { get; private set; }

		[field: SerializeField]
		public LocalizedString MessageSubtitle { get; private set; }

		[field: SerializeField]
		public LocalizedString MessageBody { get; private set; }

		[field: SerializeField]
		public bool UseSpecificMessageVisual { get; private set; }

		[field: SerializeField]
		[field: ShowIf("UseSpecificMessageVisual")]
		public StringKey SpecificMessageVisual { get; private set; }

		[field: SerializeField]
		public UnityEvent EndEvent { get; private set; }

		public override Sprite GetSprite()
		{
			return MessageSprite;
		}

		public override LocalizedString GetTitle()
		{
			return MessageTitle;
		}

		public override LocalizedString GetSubtitle()
		{
			return MessageSubtitle;
		}

		public override LocalizedString GetDescription()
		{
			return MessageBody;
		}

		public override bool ShouldUseSpecificVisual()
		{
			return UseSpecificMessageVisual;
		}

		public override StringKey GetSpecificVisualKey()
		{
			return SpecificMessageVisual;
		}

		public override UnityEvent GetEndEvent()
		{
			return EndEvent;
		}
	}
}
