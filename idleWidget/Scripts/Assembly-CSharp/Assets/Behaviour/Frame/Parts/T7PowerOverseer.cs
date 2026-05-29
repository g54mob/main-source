using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7PowerOverseer : MonoBehaviour
	{
		[SerializeField]
		private T7PowerSlider[] _sliders;

		[SerializeField]
		private ActiveWorldFrame _frame;

		private void OnEnable()
		{
			_frame = GetComponentInParent<ActiveWorldFrame>();
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			T7PowerSlider[] sliders = _sliders;
			for (int i = 0; i < sliders.Length; i++)
			{
				sliders[i].SetNotch(SeededRandom.Global.RandomFloat());
			}
		}

		public void CraftingTrigger()
		{
			T7PowerSlider[] sliders = _sliders;
			for (int i = 0; i < sliders.Length; i++)
			{
				if (!sliders[i].IsSolved())
				{
					_frame.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Auto-shutdown triggered!");
					return;
				}
			}
			_frame.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			StartCoroutine(ResetPuzzle());
		}

		public IEnumerator ResetPuzzle()
		{
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}
	}
}
