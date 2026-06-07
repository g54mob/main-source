using FractureField.Tools;
using FractureField.UI.Components.Buttons;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;

namespace FractureField.UI.Popups.Tools
{
	public class ToolRow : MonoBehaviour
	{
		[Header("Variables")]
		[SerializeField]
		private ToolType _toolType;

		[Header("References")]
		[SerializeField]
		private RImage _backgroundImage;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _descriptionText;

		[SerializeField]
		private TMP_Text _fractureText;

		[SerializeField]
		private TMP_Text _pierceText;

		[SerializeField]
		private TMP_Text _rangeText;

		[SerializeField]
		private RButtonComponent _purchaseButton;

		[SerializeField]
		private RButtonComponent _equipButton;

		private void Awake()
		{
		}

		private void Setup()
		{
		}

		public void ClickedPurchase()
		{
		}

		public void ClickedEquip()
		{
		}
	}
}
