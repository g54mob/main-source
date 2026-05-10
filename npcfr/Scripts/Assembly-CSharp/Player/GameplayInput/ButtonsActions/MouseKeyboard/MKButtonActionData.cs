using System;
using Player.GameplayInput.ButtonsActions.MouseKeyboard.Actions;
using Player.GeneralInput.MouseKeyboard;
using UnityEngine;

namespace Player.GameplayInput.ButtonsActions.MouseKeyboard
{
	[CreateAssetMenu(fileName = "MKButtonActionData", menuName = "FRUKT/Button actions/Mouse keyboard")]
	public class MKButtonActionData : ButtonActionData
	{
		[field: SerializeField]
		public MKButtonType ButtonEnumValue { get; private set; }

		[field: SerializeField]
		public MKButtonActionType ActionEnumValue { get; private set; }

		public override Enum xbw => null;

		public override Enum xbx => null;
	}
}
