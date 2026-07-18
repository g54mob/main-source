using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KnightController : MonoBehaviour
{
	[SerializeField]
	private bool jumpInPlace = true;

	[SerializeField]
	private bool movesToPoints;

	[SerializeField]
	private List<PointToMoveTo> moveToPoints;

	private int currentMovePointIndex;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(Random.Range(0.1f, 1f));
		StartCoroutine(MoveUp());
		if (movesToPoints)
		{
			StartCoroutine(MoveToPoint(moveToPoints[currentMovePointIndex]));
		}
	}

	private void Update()
	{
		try
		{
			base.transform.LookAt(new Vector3(moveToPoints[currentMovePointIndex].position.x, base.transform.position.y, moveToPoints[currentMovePointIndex].position.z));
		}
		catch
		{
		}
	}

	private IEnumerator MoveUp()
	{
		if (jumpInPlace)
		{
			yield return new WaitForSeconds(0.5f);
			base.transform.DOLocalMoveY(0.5f, 0.5f);
			StartCoroutine(MoveDown());
		}
	}

	private IEnumerator MoveDown()
	{
		if (jumpInPlace)
		{
			yield return new WaitForSeconds(0.5f);
			base.transform.DOLocalMoveY(0f, 0.5f);
			StartCoroutine(MoveUp());
		}
	}

	private IEnumerator MoveToPoint(PointToMoveTo pointToMoveTo)
	{
		yield return new WaitForSeconds(Random.Range(3.5f, 6.5f));
		base.transform.DOLocalMove(moveToPoints[currentMovePointIndex].position, moveToPoints[currentMovePointIndex].duration);
		currentMovePointIndex++;
		if (currentMovePointIndex >= moveToPoints.Count)
		{
			currentMovePointIndex = 0;
		}
		StartCoroutine(MoveToPoint(moveToPoints[currentMovePointIndex]));
	}
}
