using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CTS
{
	public class UI_StockItemReferences : CTSBehaviour
	{
		public const string MinMaxButtonsBoxGroup = "+ - Buttons";

		[field: SerializeField]
		[field: Inject(false)]
		public Image IconImage { get; private set; }

		[field: SerializeField]
		public TMP_Text CountText { get; private set; }

		[field: SerializeField]
		public GameObject CountContainer { get; private set; }

		[field: SerializeField]
		public TMP_Text QualityText { get; private set; }

		[field: SerializeField]
		public GameObject QualityContainer { get; private set; }

		[field: SerializeField]
		public TMP_Text PriceText { get; private set; }

		[field: Header("Color")]
		[field: SerializeField]
		public PaletteData ActiveColor { get; private set; }

		[field: SerializeField]
		public PaletteData InactiveColor { get; private set; }

		[field: SerializeField]
		public Graphic ColorTarget { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("+ - Buttons")]
		public TMP_Text MinMaxText { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("+ - Buttons")]
		public ClickAndHoldButton MinusButton { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("+ - Buttons")]
		public ClickAndHoldButton PlusButton { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("+ - Buttons")]
		public InputActionReference ShiftActionReference { get; private set; }
	}
}
