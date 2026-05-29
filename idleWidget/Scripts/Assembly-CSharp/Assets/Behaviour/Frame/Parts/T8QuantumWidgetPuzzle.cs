using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T8QuantumWidgetPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T8QuantumWidgetGem[] _gemsLeft;

		[SerializeField]
		private T8QuantumWidgetGem[] _gemsRight;

		[SerializeField]
		private Color[] _colors;

		private ActiveWorldFrame _parent;

		public T8QuantumWidgetGem ActiveGem { get; private set; }

		private void Start()
		{
			SetupPuzzle();
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		public void SetupPuzzle()
		{
			ActiveGem = null;
			SeededRandom.Global.Shuffle(_colors);
			_setupGems(_gemsLeft);
			_setupGems(_gemsRight);
		}

		private void _setupGems(T8QuantumWidgetGem[] gems)
		{
			int[] array = new int[4] { 0, 1, 2, 3 };
			SeededRandom.Global.Shuffle(array);
			for (int i = 0; i < array.Length; i++)
			{
				gems[i].SetGemType(array[i], _colors[array[i]]);
			}
		}

		public void GemSelected(T8QuantumWidgetGem gem)
		{
			if (!ActiveGem)
			{
				UISounds.CraftStep();
				ActiveGem = gem;
			}
		}

		public void FinalizePuzzle(T8QuantumWidgetGem gem)
		{
			if (gem.GemType == ActiveGem.GemType)
			{
				UISounds.CraftStep();
				gem.ConnectTo(ActiveGem);
			}
			else
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Particle mismatch!");
			}
			DeactivateGem();
			T8QuantumWidgetGem[] gemsLeft = _gemsLeft;
			for (int i = 0; i < gemsLeft.Length; i++)
			{
				if (!gemsLeft[i].Locked)
				{
					return;
				}
			}
			StartCoroutine(_puzzleSolved());
		}

		private IEnumerator _puzzleSolved()
		{
			UISounds.CraftFinished();
			_parent.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			yield return new WaitForSeconds(2f);
			SetupPuzzle();
		}

		public void DeactivateGem()
		{
			ActiveGem = null;
		}
	}
}
