using System;
using UnityEngine;

namespace Motorways.Views
{
	[Serializable]
	public class UpgradeContainer
	{
		public GameObject root;

		public NewUpgradeButton[] buttons;

		public LocalizedTextUI weekText;

		public LocalizedTextUI weekDescriptionText;
	}
}
