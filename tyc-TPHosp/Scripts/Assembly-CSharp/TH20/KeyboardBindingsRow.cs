using System.Collections.Generic;
using I2.Loc;
using Rewired;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class KeyboardBindingsRow : MonoBehaviour
	{
		[Header("Text")]
		[SerializeField]
		private Localize _actionName;

		[SerializeField]
		private TMP_Text _keyboardBinding0;

		[SerializeField]
		private TMP_Text _keyboardBinding1;

		[SerializeField]
		private Localize _keyboardBinding0Localize;

		[SerializeField]
		private Localize _keyboardBinding1Localize;

		[Header("Buttons")]
		[SerializeField]
		private DynamicButton _keyboardBindingButton0;

		[SerializeField]
		private DynamicButton _keyboardBindingButton1;

		[SerializeField]
		private ButtonAnimator _keyboardBindingButtonAnimator0;

		[SerializeField]
		private ButtonAnimator _keyboardBindingButtonAnimator1;

		[Header("Sprites")]
		[SerializeField]
		private Sprite _disabledSprite;

		[SerializeField]
		private Sprite _conflictSprite;

		private bool _hasConflicts;

		public DynamicButton KeyboardBindingButton0 => _keyboardBindingButton0;

		public DynamicButton KeyboardBindingButton1 => _keyboardBindingButton1;

		public bool HasConflicts => _hasConflicts;

		public void Setup(InputAction inputAction, ControllerMap keyboardMap, List<InputAction> playerVisbleActions)
		{
			_actionName.Term = inputAction.descriptiveName;
			int num = 0;
			_keyboardBinding0.text = string.Empty;
			_keyboardBinding1.text = string.Empty;
			_keyboardBinding0Localize.Term = "-";
			_keyboardBinding1Localize.Term = "-";
			_keyboardBindingButtonAnimator0.CurrentState = ButtonAnimator.State.Selectable;
			_keyboardBindingButtonAnimator1.CurrentState = ButtonAnimator.State.Unselectable;
			_keyboardBindingButton0.image.overrideSprite = null;
			_keyboardBindingButton1.image.overrideSprite = _disabledSprite;
			foreach (ActionElementMap actionElementMap in keyboardMap.ButtonMapsWithAction(inputAction.id))
			{
				List<ActionElementMap> list = new List<ActionElementMap>();
				keyboardMap.GetButtonMapMatches((ActionElementMap e) => e.id != actionElementMap.id && e.keyboardKeyCode == actionElementMap.keyboardKeyCode && playerVisbleActions.Exists((InputAction pa) => pa.id == e.actionId), list);
				bool flag = list.Count > 0;
				_hasConflicts |= flag;
				if (num == 0)
				{
					_keyboardBinding0Localize.Term = "Misc/KeyCode/" + actionElementMap.keyboardKeyCode;
					_keyboardBindingButtonAnimator1.CurrentState = ButtonAnimator.State.Selectable;
					_keyboardBindingButton0.image.overrideSprite = (flag ? _conflictSprite : null);
					_keyboardBindingButton1.image.overrideSprite = null;
				}
				if (num == 1)
				{
					_keyboardBinding1Localize.Term = "Misc/KeyCode/" + actionElementMap.keyboardKeyCode;
					_keyboardBindingButton1.image.overrideSprite = (flag ? _conflictSprite : null);
				}
				num++;
			}
		}
	}
}
