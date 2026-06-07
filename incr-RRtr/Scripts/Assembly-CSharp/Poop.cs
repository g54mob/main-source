using UnityEngine;

public class Poop : MonoBehaviour
{
	public enum State
	{
		NeedsCollecting = 0,
		MarkedForCollection = 1
	}

	public State state;

	[SerializeField]
	private Sprite[] sprites;

	private SpriteRenderer sr;

	private void Start()
	{
		if (TryGetComponent<SpriteRenderer>(out sr))
		{
			sr.sprite = sprites[Random.Range(0, sprites.Length)];
			sr.flipX = Random.value > 0.5f;
		}
		GameManager.ins.piecesOfPoop.Add(this);
	}

	public void HarvestPoop()
	{
		GameManager.ins.piecesOfPoop.Remove(this);
		Object.Destroy(base.gameObject);
	}
}
