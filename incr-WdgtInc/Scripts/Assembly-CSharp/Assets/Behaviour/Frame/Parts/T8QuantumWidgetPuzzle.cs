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

		[SerializeField]
		private T8QuantumWidgetSecretGem[] _secretGems;

		[SerializeField]
		private SecretButton _secretButton;

		private ActiveWorldFrame _parent;

		public T8QuantumWidgetGem ActiveGem { get; private set; }

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void OnEnable()
		{
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			ActiveGem = null;
			SeededRandom.Global.Shuffle(_colors);
			_setupGems(_gemsLeft);
			_setupGems(_gemsRight);
			for (int i = 0; i < _colors.Length; i++)
			{
				_secretGems[i].SetColor(_colors[i]);
			}
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
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T8QuantumWidgetWarning");
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

		public void FinalizeSecret(T8QuantumWidgetSecretGem gem)
		{
			if (gem.GemType == ActiveGem.GemType)
			{
				UISounds.CraftStep();
				ActiveGem.ConnectTo(gem);
				gem.Connected = true;
			}
			bool flag = true;
			for (int i = 0; i < _gemsLeft.Length; i++)
			{
				if (_gemsLeft[i].GemType == gem.GemType)
				{
					_gemsLeft[i].Locked = true;
				}
				if (_gemsRight[i].GemType == gem.GemType)
				{
					_gemsRight[i].Locked = true;
				}
				if (!_secretGems[i].Connected)
				{
					flag = false;
				}
			}
			DeactivateGem();
			if (flag)
			{
				_secretButton.gameObject.SetActive(value: true);
				UISounds.CraftFinished();
			}
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
