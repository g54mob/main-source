using Assets.Scripts.Flight.MapView.UI.Inspector;
using ModApi;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class DeltaVAdjustorElement : ItemElement
	{
		private DeltaVAdjustorButtonScript _buttonNegative;

		private DeltaVAdjustorButtonScript _buttonPositive;

		private double _deltaV;

		private TMP_InputField _inputField;

		public DeltaVAdjustorModel Model { get; }

		public DeltaVAdjustorElement(XmlElement xmlElement, DeltaVAdjustorModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			Model = model;
			_inputField = xmlElement.GetElementByInternalId<TMP_InputField>("input-field");
			_inputField.onValueChanged.AddListener(OnTextValueChanged);
			_buttonNegative = xmlElement.GetElementByInternalId<Button>("button-negative").gameObject.AddComponent<DeltaVAdjustorButtonScript>();
			_buttonPositive = xmlElement.GetElementByInternalId<Button>("button-positive").gameObject.AddComponent<DeltaVAdjustorButtonScript>();
			_buttonNegative.ButtonDown += OnButtonNegativeDown;
			_buttonPositive.ButtonDown += OnButtonPositiveDown;
			Image component = _buttonNegative.GetComponent<Image>();
			Image component2 = _buttonPositive.GetComponent<Image>();
			IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
			XmlElement component3 = _buttonNegative.GetComponent<XmlElement>();
			XmlElement component4 = _buttonPositive.GetComponent<XmlElement>();
			XmlElement component5 = _inputField.GetComponent<XmlElement>();
			switch (Model.Type)
			{
			case DeltaVAdjustorModelType.ProgradeRetrograde:
				component.sprite = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Retrograde");
				component2.sprite = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Prograde");
				component3.Tooltip = "Retrograde";
				component4.Tooltip = "Prograde";
				component5.Tooltip = "Prograde / Retrograde Delta-V";
				break;
			case DeltaVAdjustorModelType.NormalAntiNormal:
				component.sprite = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Anti-normal");
				component2.sprite = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Normal");
				component3.Tooltip = "Anti-normal";
				component4.Tooltip = "Normal";
				component5.Tooltip = "Anti-normal / Normal Delta-V";
				break;
			case DeltaVAdjustorModelType.RadialOutRadialIn:
				component.sprite = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Radial-in");
				component2.sprite = resourceLoader.Load<Sprite>("Flight/MapView/Icons/Radial-out");
				component3.Tooltip = "Radial-in";
				component4.Tooltip = "Radial-out";
				component5.Tooltip = "Radial-in / Radial-out Delta-V";
				break;
			}
		}

		public override void Update()
		{
			base.Update();
			double num = Model.Type switch
			{
				DeltaVAdjustorModelType.ProgradeRetrograde => Model.ManeuverNode.DeltaVPrograde, 
				DeltaVAdjustorModelType.NormalAntiNormal => Model.ManeuverNode.DeltaVNormal, 
				DeltaVAdjustorModelType.RadialOutRadialIn => Model.ManeuverNode.DeltaVRadial, 
				_ => 0.0, 
			};
			if (!Utilities.CompareDoubles(num, _deltaV, 0.0001))
			{
				_deltaV = num;
				_inputField.SetTextWithoutNotify(num.ToString("F3"));
			}
		}

		private void OnButtonNegativeDown(float input)
		{
			Model.AdjustDeltaV(0f - input);
		}

		private void OnButtonPositiveDown(float input)
		{
			Model.AdjustDeltaV(input);
		}

		private void OnTextValueChanged(string value)
		{
			if (double.TryParse(value, out var result))
			{
				_deltaV = result;
				Model.SetDeltaV(result);
			}
		}
	}
}
