using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class PanelItemInfoMessage : PanelItem
	{
		[SerializeField]
		private TMP_Text _text;

		public abstract InfoMessageSource MessageSource { get; }

		public void UpdateMessage(Level level)
		{
			if (_text != null && MessageSource != null)
			{
				_text.text = MessageSource.GetMessage(level);
			}
		}
	}
}
