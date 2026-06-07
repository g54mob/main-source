using System;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class SliderControl
	{
		public TextMeshProUGUI LabelText { get; private set; }

		public XmlElement Panel { get; private set; }

		public Slider Slider { get; private set; }

		public TextMeshProUGUI ValueText { get; private set; }

		public SliderControl(XmlElement panelElement)
		{
			Panel = panelElement;
			LabelText = panelElement.GetElementByInternalId<TextMeshProUGUI>("slider-label");
			ValueText = panelElement.GetElementByInternalId<TextMeshProUGUI>("slider-value");
			Slider = panelElement.GetElementByInternalId<Slider>("slider");
		}

		public void EnableManualInput(Action<float> setter, Func<string> getter)
		{
			ValueText.raycastTarget = true;
			Panel.GetElementByInternalId("slider-value").AddOnClickEvent(delegate
			{
				ModApi.Ui.InputDialogScript dialog = Game.Instance.UserInterface.CreateInputDialog();
				dialog.MessageText = "Enter Value";
				dialog.InputText = getter();
				dialog.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
				{
					d.Close();
					if (float.TryParse(dialog.InputText, out var result))
					{
						setter(result);
					}
				};
			});
		}
	}
}
