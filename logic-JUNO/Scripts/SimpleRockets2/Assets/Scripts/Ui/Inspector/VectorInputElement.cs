using ModApi.Common.Events;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class VectorInputElement<T> : ItemElement
	{
		private TMP_InputField _inputX;

		private TMP_InputField _inputY;

		private TMP_InputField _inputZ;

		private TextMeshProUGUI _labelText;

		private VectorInputModel<T> _model;

		private T _value;

		public VectorInputElement(XmlElement xmlElement, VectorInputModel<T> model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_inputX = xmlElement.GetElementByInternalId<TMP_InputField>("input-field-x");
			_inputY = xmlElement.GetElementByInternalId<TMP_InputField>("input-field-y");
			_inputZ = xmlElement.GetElementByInternalId<TMP_InputField>("input-field-z");
			_inputX.onEndEdit.AddListener(delegate(string s)
			{
				OnValueChanged(s, 0);
			});
			_inputY.onEndEdit.AddListener(delegate(string s)
			{
				OnValueChanged(s, 1);
			});
			_inputZ?.onEndEdit.AddListener(delegate(string s)
			{
				OnValueChanged(s, 2);
			});
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				UpdateText();
			});
			Selectable selectable = _inputX?.GetComponent<Selectable>();
			Selectable selectable2 = _inputY?.GetComponent<Selectable>();
			Selectable selectable3 = _inputZ?.GetComponent<Selectable>();
			ConfigureSelectable(selectable, selectable2);
			ConfigureSelectable(selectable2, selectable3);
			ConfigureSelectable(selectable3, null);
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			T value = _model.Value;
			if (!_value.Equals(value))
			{
				_value = value;
				UpdateText();
			}
		}

		private static void ConfigureSelectable(Selectable selectable, Selectable next)
		{
			if (selectable != null)
			{
				Navigation navigation = selectable.navigation;
				if (next != null)
				{
					navigation.mode = Navigation.Mode.Explicit;
					navigation.selectOnDown = next;
					navigation.selectOnRight = next;
				}
				else
				{
					navigation.mode = Navigation.Mode.Automatic;
				}
				selectable.navigation = navigation;
			}
		}

		private void OnValueChanged(string s, int componentChanged)
		{
			string[] array = new string[_model.NumComponents];
			array[0] = _inputX.text;
			array[1] = _inputY.text;
			if (_model.NumComponents > 2)
			{
				array[2] = _inputZ?.text;
			}
			_model.OnInputChanged(array, componentChanged);
		}

		private void UpdateText()
		{
			_inputX.text = _model.GetComponentText(0);
			_inputY.text = _model.GetComponentText(1);
			if (_model.NumComponents > 2)
			{
				_inputZ.text = _model.GetComponentText(2);
			}
		}
	}
}
