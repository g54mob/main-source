using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T5IntegratedCircuitry : MonoBehaviour
	{
		[SerializeField]
		private T5IntegratedSlot _targetSlot;

		[SerializeField]
		private T5IntegratedSlot[] _slots;

		private bool _active;

		private void OnEnable()
		{
			SetupPuzzle();
		}

		public void Clear()
		{
			_targetSlot.Clear();
			T5IntegratedSlot[] slots = _slots;
			for (int i = 0; i < slots.Length; i++)
			{
				slots[i].Clear();
			}
		}

		public void SetupPuzzle()
		{
			Clear();
			_targetSlot.SetLineZ(0.1f);
			_targetSlot.SetupPuzzle(show: true);
			T5IntegratedSlot[] slots = _slots;
			for (int i = 0; i < slots.Length; i++)
			{
				slots[i].SetupPuzzle(show: true);
			}
			SeededRandom.Global.Choose(_slots).SetLines(_targetSlot.ExitGreen, _targetSlot.ExitRed, show: true);
			_active = true;
		}

		public void OptionClicked(int i)
		{
			if (_active)
			{
				StartCoroutine(_executeOption(i));
			}
		}

		private IEnumerator _executeOption(int i)
		{
			_active = false;
			ActiveWorldFrame componentInParent = GetComponentInParent<ActiveWorldFrame>();
			WorldAnchor anchor = new WorldAnchor(WorldAnchorType.HandCraft, 0);
			if (_slots[i].ExitGreen == _targetSlot.ExitGreen && _slots[i].ExitRed == _targetSlot.ExitRed)
			{
				UISounds.CraftStep();
				componentInParent.ActiveFrame.ButtonClicked(anchor);
				_targetSlot.SetLineZ(-0.1f);
				T5IntegratedSlot[] slots = _slots;
				for (int j = 0; j < slots.Length; j++)
				{
					slots[j].Clear();
				}
			}
			else
			{
				Clear();
				componentInParent.ShowWarning(anchor, "@T5IntegratedWidgetWarning");
			}
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}
	}
}
