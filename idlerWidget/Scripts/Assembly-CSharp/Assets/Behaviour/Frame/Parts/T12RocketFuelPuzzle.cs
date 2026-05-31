using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12RocketFuelPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T12RocketFuelTube[] _tubes;

		private ActiveWorldFrame _frame;

		private void Start()
		{
			_frame = GetComponentInParent<ActiveWorldFrame>();
		}

		public void ButtonClicked()
		{
			T12RocketFuelTube[] tubes = _tubes;
			for (int i = 0; i < tubes.Length; i++)
			{
				if (!tubes[i].Done)
				{
					_frame.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Inputs not locked!");
					return;
				}
			}
			float num = 1f;
			tubes = _tubes;
			for (int i = 0; i < tubes.Length; i++)
			{
				tubes[i].Reset(num);
				num += 0.5f;
			}
			_frame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
		}
	}
}
