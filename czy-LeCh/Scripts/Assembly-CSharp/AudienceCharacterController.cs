using System.Collections;
using DG.Tweening;
using UnityEngine;

public class AudienceCharacterController : MonoBehaviour
{
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(Random.Range(0.1f, 1f));
		StartCoroutine(Jump());
	}

	private IEnumerator Jump()
	{
		yield return new WaitForSeconds(Random.Range(4, 11));
		StartCoroutine(MoveUp());
	}

	private IEnumerator MoveUp()
	{
		yield return new WaitForSeconds(0.5f);
		base.transform.DOLocalMoveY(0.5f, 0.5f);
		StartCoroutine(MoveDown());
	}

	private IEnumerator MoveDown()
	{
		yield return new WaitForSeconds(0.5f);
		base.transform.DOLocalMoveY(0f, 0.5f);
		StartCoroutine(Jump());
	}
}
