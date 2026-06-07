using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class SingleScoreUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private PlacementGhost placementGhost;

	[SerializeField]
	private float scoreMoveOffsetY;

	[SerializeField]
	private float scoreMoveDuration;

	[SerializeField]
	private Ease easing;

	private void Start()
	{
		placementGhost.OnStopShowingPlacementGhost += PlacementGhost_OnStopShowingPlacementGhost;
	}

	private void PlacementGhost_OnStopShowingPlacementGhost(object sender, EventArgs e)
	{
		StartCoroutine(Fade());
		base.transform.DOMoveY(base.transform.position.y + scoreMoveOffsetY, scoreMoveDuration).SetEase(easing).OnComplete(delegate
		{
			DestroySelf();
		});
	}

	private IEnumerator Fade()
	{
		yield return new WaitForSeconds(scoreMoveDuration / 2f);
		base.transform.GetComponent<CanvasGroup>().DOFade(0f, scoreMoveDuration / 2f);
	}

	private void OnDestroy()
	{
		placementGhost.OnStopShowingPlacementGhost -= PlacementGhost_OnStopShowingPlacementGhost;
	}

	public static SingleScoreUI Create(Transform singleScoreTemplate)
	{
		Transform obj = UnityEngine.Object.Instantiate(singleScoreTemplate, singleScoreTemplate.parent);
		obj.gameObject.SetActive(value: true);
		return obj.GetComponent<SingleScoreUI>();
	}

	public void UpdateText(int plantScore)
	{
		scoreText.text = "+" + plantScore;
	}

	private void DestroySelf()
	{
		UnityEngine.Object.Destroy(base.gameObject, scoreMoveDuration + 2f);
	}
}
