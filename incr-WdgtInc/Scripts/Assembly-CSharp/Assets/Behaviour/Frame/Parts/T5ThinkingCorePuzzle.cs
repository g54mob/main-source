using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T5ThinkingCorePuzzle : MonoBehaviour
	{
		[SerializeField]
		private FrameButton[] _buttons;

		private ActiveWorldFrame _parent;

		private int _activeButton = -1;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_setupButtons();
		}

		public void ButtonClicked()
		{
			_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			_setupButtons();
		}

		private void _setupButtons()
		{
			int num;
			do
			{
				num = SeededRandom.Global.RandomRange(0, _buttons.Length);
			}
			while (num == _activeButton);
			_activeButton = num;
			for (int i = 0; i < _buttons.Length; i++)
			{
				_buttons[i].SetActive(i == num);
			}
		}
	}
}
