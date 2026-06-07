using System;
using UnityEngine.UIElements;

namespace Kamgam.LocalizationForSettings.UIElements
{
	public class LocalizeLabel : LocalizeVisualElement
	{
		protected Label _label;

		public Label Label
		{
			get
			{
				if ((_label == null && base.VisualElement != null) || _label != base.VisualElement)
				{
					_label = base.VisualElement as Label;
				}
				return _label;
			}
		}

		public override Type GetElementType()
		{
			return typeof(Label);
		}

		public override void Awake()
		{
			base.Awake();
		}

		public override void OnDisable()
		{
			_label = null;
			base.OnDisable();
		}

		public override string GetText()
		{
			if (Label != null)
			{
				return Label.text;
			}
			return null;
		}

		public override void SetText(string text)
		{
			if (Label != null)
			{
				Label.text = text;
			}
		}
	}
}
