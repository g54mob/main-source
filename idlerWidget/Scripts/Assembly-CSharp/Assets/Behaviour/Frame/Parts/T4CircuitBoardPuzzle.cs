using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T4CircuitBoardPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T3PowerSwitch _switch;

		private ActiveWorldFrame _parent;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		public void ButtonClicked()
		{
			if (_switch.Progress > 0.19f)
			{
				_switch.Progress -= 0.19f;
				_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			}
			else
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Insufficient charge!");
			}
		}
	}
}
