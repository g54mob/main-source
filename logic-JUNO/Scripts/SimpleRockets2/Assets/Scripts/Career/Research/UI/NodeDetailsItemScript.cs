using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Career.Research.UI
{
	public class NodeDetailsItemScript : ItemBlockScript
	{
		[SerializeField]
		private GameObject _iconCanvas;

		[SerializeField]
		private Image _iconPart;

		[SerializeField]
		private Image _iconGeneric;

		[SerializeField]
		private TextMeshPro _textName;

		[SerializeField]
		private TextMeshPro _textValue;

		public override void Initialize(NodeScript node, TechItemValue item)
		{
			base.Initialize(node, item);
			string displayString = item.DisplayString;
			string valueString = item.ValueString;
			_textName.text = displayString;
			if (!string.IsNullOrWhiteSpace(valueString))
			{
				_textValue.text = valueString;
				_iconCanvas.SetActive(value: false);
				return;
			}
			_textValue.gameObject.SetActive(value: false);
			_iconCanvas.SetActive(value: true);
			if (item.TechItem.Id.StartsWith("Part."))
			{
				_iconPart.gameObject.SetActive(value: true);
			}
			else
			{
				_iconGeneric.gameObject.SetActive(value: true);
			}
		}
	}
}
