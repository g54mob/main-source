using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T6MainframeConsole : MonoBehaviour
	{
		[SerializeField]
		private T6MainframeFaller _fallerPrefab;

		[SerializeField]
		private T6MainframeCatcher _catcher;

		[SerializeField]
		private Transform _fallerParent;

		[SerializeField]
		private float _fallerXMin;

		[SerializeField]
		private float _fallerXMax;

		private void OnEnable()
		{
			StartCoroutine(_spawnFallers());
		}

		private IEnumerator _spawnFallers()
		{
			_fallerParent.DestroyChildren();
			while (true)
			{
				T6MainframeFaller t6MainframeFaller = Object.Instantiate(_fallerPrefab, _fallerParent);
				t6MainframeFaller.transform.localPosition = new Vector3(SeededRandom.Global.RandomRange(_fallerXMin, _fallerXMax), t6MainframeFaller.transform.localPosition.y, t6MainframeFaller.transform.localPosition.z);
				yield return new WaitForSeconds(0.8f);
			}
		}

		public void CheckFaller(T6MainframeFaller faller)
		{
			float x = faller.transform.localPosition.x;
			float x2 = _catcher.transform.localPosition.x;
			if (x > x2 - 0.25f && x < x2 + 0.25f)
			{
				UISounds.CraftStep();
				GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			}
		}
	}
}
