using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9SuperconductorPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T9SuperconductorTube[] _tubes;

		[SerializeField]
		private FrameButton _button;

		private void Update()
		{
			for (int i = 0; i < _tubes.Length; i++)
			{
				if (!_tubes[i].Done)
				{
					_button.SetActive(active: false);
					return;
				}
			}
			_button.SetActive(active: true);
		}

		public void StartCraft()
		{
			GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			for (int i = 0; i < _tubes.Length; i++)
			{
				_tubes[i].Reset();
			}
		}
	}
}
