using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T3BatteryPuzzle : MonoBehaviour
	{
		[SerializeField]
		private FrameButton _buttonPositive;

		[SerializeField]
		private FrameButton _buttonNegative;

		private ActiveWorldFrame _parent;

		private bool _positive;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_toggleButtons();
		}

		public void ButtonClicked()
		{
			_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			_toggleButtons();
		}

		private void _toggleButtons()
		{
			_positive = !_positive;
			_buttonPositive.SetActive(_positive);
			_buttonNegative.SetActive(!_positive);
		}
	}
}
