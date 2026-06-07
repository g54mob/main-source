using System.Collections;
using Assets.Source.Player;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T11PicoprocessorPuzzle : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _sample;

		[SerializeField]
		private Sprite _passSprite;

		[SerializeField]
		private Sprite[] _failSprites;

		[SerializeField]
		private FrameButton _pass;

		[SerializeField]
		private FrameButton _fail;

		[SerializeField]
		private Vector3 _samplePos;

		private ActiveWorldFrame _parent;

		private bool _shouldPass;

		private int _failsInARow;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_samplePos = _sample.transform.position;
		}

		private void OnEnable()
		{
			SetupPuzzle();
			_failsInARow = 0;
		}

		public void SetupPuzzle()
		{
			_shouldPass = SeededRandom.Global.RandomBool();
			if (_shouldPass)
			{
				_sample.sprite = _passSprite;
			}
			else
			{
				_sample.sprite = SeededRandom.Global.Choose(_failSprites);
			}
		}

		public void DoPass()
		{
			UISounds.CraftStep();
			this.StartImportantCoroutine(_doInteraction(pass: true));
		}

		public void DoFail()
		{
			UISounds.CraftStep();
			this.StartImportantCoroutine(_doInteraction(pass: false));
		}

		private IEnumerator _doInteraction(bool pass)
		{
			_pass.SetActive(active: false);
			_fail.SetActive(active: false);
			bool num = pass == _shouldPass;
			this.StartImportantCoroutine(_swapSamples());
			if (num)
			{
				_failsInARow = 0;
				_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				yield return new WaitForSeconds(1f);
			}
			else
			{
				_failsInARow++;
				if (_failsInARow == 10)
				{
					SteamAchievement.Trigger("PicoprocessorFail");
				}
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T11PicoprocessorWarning");
				yield return new WaitForSeconds(2f);
			}
			_pass.SetActive(active: true);
			_fail.SetActive(active: true);
		}

		private IEnumerator _swapSamples()
		{
			SpriteRenderer old = _sample;
			_sample = Object.Instantiate(old, _samplePos + new Vector3(0f, -3f, 0f), Quaternion.identity, old.transform.parent);
			SetupPuzzle();
			float time = 0f;
			while (time < 1f)
			{
				time += Time.deltaTime;
				_sample.transform.position = _samplePos + new Vector3(0f, Mathf.SmoothStep(-3f, 0f, time));
				old.transform.position = _samplePos + new Vector3(0f, Mathf.SmoothStep(0f, 3f, time));
				yield return null;
			}
			Object.Destroy(old.gameObject);
		}
	}
}
