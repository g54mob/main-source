using Loaf.Assets.NoesisGUI;
using Noesis;
using UnityEngine;

namespace Testing
{
	public class PinsDisplayView : UserControl
	{
		private static PinsDisplayView inst;

		private GameObject[] pins;

		private GameObject[] anodes;

		private PinHint[] pinHints;

		private bool display;

		private GameObject[] logicPins;

		private LogicHint[] logicHints;

		private bool displayLogic;

		public Grid PinsGrid;

		public static void DisplayPins()
		{
		}

		public static void DisplayLogic()
		{
		}

		public static void HidePins()
		{
		}

		public static void Refresh()
		{
		}

		public static void UpdatePins()
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
