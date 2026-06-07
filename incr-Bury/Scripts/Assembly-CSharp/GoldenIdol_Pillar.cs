using UnityEngine;

public class GoldenIdol_Pillar : MonoBehaviour
{
	public BerryNames goldenIdolBerryTier;

	public bool idolCompleted;

	[SerializeField]
	private GameObject goldenBerryVisual;

	private void Start()
	{
		goldenBerryVisual.SetActive(value: false);
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && !Puzzle_GoldenIdol.Singleton.puzzleCompleted && !idolCompleted && collision.collider.transform.root.gameObject.CompareTag("PickUp") && !(collision.collider.transform.root.gameObject.GetComponent<PickUppable>() == null))
		{
			GameObject gameObject = collision.collider.transform.root.gameObject;
			Berry component = gameObject.GetComponent<Berry>();
			if ((bool)component && component.isGoldenBerry && component.berryTier == (int)goldenIdolBerryTier)
			{
				CompleteIdol(_playSFX: true);
				Object.Destroy(gameObject);
			}
		}
	}

	public void CompleteIdol(bool _playSFX)
	{
		idolCompleted = true;
		goldenBerryVisual.SetActive(value: true);
		switch (goldenIdolBerryTier)
		{
		case BerryNames.Blueberry:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Blueberry = true;
			break;
		case BerryNames.Raspberry:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Raspberry = true;
			break;
		case BerryNames.Strawberry:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Strawberry = true;
			break;
		case BerryNames.Kiwi:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Kiwi = true;
			break;
		case BerryNames.Plum:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Plum = true;
			break;
		case BerryNames.Apple:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Apple = true;
			break;
		case BerryNames.Pear:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Pear = true;
			break;
		case BerryNames.Peach:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Peach = true;
			break;
		case BerryNames.Banana:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Banana = true;
			break;
		case BerryNames.Pineapple:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Pineapple = true;
			break;
		case BerryNames.Watermelon:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Watermelon = true;
			break;
		case BerryNames.Pumpkin:
			Puzzle_GoldenIdol.Singleton.idolCompleted_Pumpkin = true;
			break;
		}
		if (_playSFX)
		{
			AudioManager.Singleton.PlaySFX_GoldenIdolCompleted();
			Puzzle_GoldenIdol.Singleton.CheckForAllIdolsCompleted(_playCompletionSFX: true);
		}
	}
}
