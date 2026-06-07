using System.Collections;
using System.Numerics;
using Assets.Behaviour.UI;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1BasicWidgetIntro : MonoBehaviour
	{
		public static bool NewGameStarted;

		[SerializeField]
		private SpriteRenderer _firstHider;

		[SerializeField]
		private SpriteRenderer _secondHider;

		private bool _isNewGame;

		private bool _newGameHiding;

		private void Start()
		{
			if (NewGameStarted)
			{
				GameUI.Instance.HideBottomBar();
				MilestoneUI.Instance.gameObject.SetActive(value: false);
				UITooltip.TooltipEnabled = false;
				NewGameStarted = false;
				_isNewGame = true;
				StartCoroutine(_hideFirstHider());
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void Update()
		{
			if (_isNewGame)
			{
				BigInteger inventoryCount = GamePlayer.Current.GetInventoryCount("widget");
				if (inventoryCount > 0L && !_newGameHiding)
				{
					_newGameHiding = true;
					StartCoroutine(_hide());
				}
				else if (inventoryCount == 5L)
				{
					GameUI.Instance.ShowBuildTutorial();
					MilestoneUI.Instance.gameObject.SetActive(value: true);
				}
			}
		}

		private IEnumerator _hideFirstHider()
		{
			yield return new WaitForSeconds(1f);
			float time = 1f;
			while (time > 0f)
			{
				time -= Time.deltaTime;
				Color color = _firstHider.color;
				color.a = Mathf.SmoothStep(0f, 1f, time);
				_firstHider.color = color;
				yield return null;
			}
			Object.Destroy(_firstHider.gameObject);
		}

		private IEnumerator _hide()
		{
			UITooltip.TooltipEnabled = true;
			GameUI.Instance.ShowBottomBar();
			float time = 4f;
			while (time > 0f)
			{
				time -= Time.deltaTime;
				float t = time / 4f;
				Color color = _secondHider.color;
				color.a = Mathf.SmoothStep(0f, 1f, t);
				_secondHider.color = color;
				yield return null;
			}
			Object.Destroy(_secondHider);
		}
	}
}
