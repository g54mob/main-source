using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BalatroCropCard : MonoBehaviour
{
	public CropSO cropSO;

	public int spareParts;

	[Header("References")]
	[SerializeField]
	private SpriteRenderer cropImage;

	private float duration = 0.35f;

	private bool isQuitting;

	private void Start()
	{
		FindClosestPokerCardSlot();
	}

	public void SetPokerCardInfo(CropSO crop, int sp)
	{
		cropSO = crop;
		spareParts = sp;
		cropImage.sprite = cropSO.cropSprite;
	}

	private void FindClosestPokerCardSlot()
	{
		BalatroJokerHand jokerHand;
		BalatroHandSlot closestHandSlot = GetClosestHandSlot(out jokerHand);
		if (closestHandSlot != null)
		{
			StartCoroutine(MoveTo(closestHandSlot, jokerHand));
			return;
		}
		Debug.Log("No empty slots available.");
		DestroyCardObject();
	}

	private BalatroHandSlot GetClosestHandSlot(out BalatroJokerHand jokerHand)
	{
		jokerHand = null;
		BalatroHandSlot result = null;
		float num = 99999f;
		for (int i = 0; i < GameManager.ins.jokerHands.Count; i++)
		{
			for (int j = 0; j < GameManager.ins.jokerHands[i].handSlots.Count; j++)
			{
				BalatroHandSlot balatroHandSlot = GameManager.ins.jokerHands[i].handSlots[j];
				if (balatroHandSlot.card == null && balatroHandSlot.active)
				{
					float num2 = Vector2.Distance(base.transform.position, balatroHandSlot.transform.position);
					if (num2 < num)
					{
						num = num2;
						result = balatroHandSlot;
						jokerHand = GameManager.ins.jokerHands[i];
					}
				}
			}
		}
		return result;
	}

	private IEnumerator MoveTo(BalatroHandSlot handSlot, BalatroJokerHand jokerHand)
	{
		handSlot.SetCardTo(this);
		float speed = Vector2.Distance(base.transform.position, handSlot.transform.position) / duration;
		Vector2 vector = (handSlot.transform.position - base.transform.position).normalized;
		float overshoot = 0.125f;
		Vector2 vector2 = (Vector2)handSlot.transform.position + vector * overshoot;
		yield return new WaitForPositionReached(base.transform, vector2, speed);
		yield return new WaitForPositionReached(base.transform, handSlot.transform.position, 3f * overshoot / duration);
		jokerHand.TryToPlayHand();
	}

	private void OnApplicationQuit()
	{
		isQuitting = true;
	}

	public void DestroyCardObject()
	{
		if (!isQuitting)
		{
			Transform child = base.transform.parent.GetChild(1);
			child.DOKill();
			child.DOScaleY(0f, 0.2f).SetEase(Ease.InBack);
			int num = ((Random.Range(0, 2) != 0) ? 1 : (-1));
			child.localRotation = Quaternion.Euler(0f, 0f, 15 * num);
			child.DOLocalRotate(Vector3.zero, 0.2f).SetEase(Ease.OutBack);
			Object.Destroy(base.transform.parent.gameObject, 0.25f);
		}
	}
}
