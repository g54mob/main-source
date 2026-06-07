using UnityEngine;

public class BalatroHandSlot : MonoBehaviour
{
	public BalatroCropCard card;

	public bool active = true;

	public void SetCardTo(BalatroCropCard card)
	{
		this.card = card;
		card.transform.parent.SetParent(base.transform);
	}

	public void RemoveCard()
	{
		if ((bool)card)
		{
			card.DestroyCardObject();
		}
		card = null;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, new Vector3(1f, 1.5f, 0f));
	}
}
