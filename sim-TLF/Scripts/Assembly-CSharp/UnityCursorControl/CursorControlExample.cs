using UnityEngine;
using UnityEngine.UI;

namespace UnityCursorControl
{
	public class CursorControlExample : MonoBehaviour
	{
		[SerializeField]
		private Text _globalPosText;

		[SerializeField]
		private Text _localPosText;

		[SerializeField]
		private InputField _xPos;

		[SerializeField]
		private InputField _yPos;

		private int _x;

		private int _y;

		private Vector2 _pos;

		private void Update()
		{
			UpdatePositionText();
			SimulateMouseClicks();
		}

		private void UpdatePositionText()
		{
			_globalPosText.text = "Global Cursor Position: " + CursorControl.GetGlobalCursorPos().ToString();
			_localPosText.text = "Local Cursor Position: " + ((Vector2)Input.mousePosition/*cast due to .constrained prefix*/).ToString();
		}

		private void SimulateMouseClicks()
		{
			if (Input.GetKeyDown(KeyCode.L))
			{
				CursorControl.SimulateLeftClick();
			}
			if (Input.GetKeyDown(KeyCode.M))
			{
				CursorControl.SimulateMiddleClick();
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				CursorControl.SimulateRightClick();
			}
		}

		private bool TryParsePos()
		{
			if (int.TryParse(_xPos.text, out _x) && int.TryParse(_yPos.text, out _y))
			{
				_pos = new Vector2(_x, _y);
				return true;
			}
			return false;
		}

		public void SetGlocalCursorPos()
		{
			if (TryParsePos())
			{
				CursorControl.SetGlobalCursorPos(_pos);
			}
		}

		public void SetLocalCursorPos()
		{
			if (TryParsePos())
			{
				CursorControl.SetLocalCursorPos(_pos);
			}
		}
	}
}
