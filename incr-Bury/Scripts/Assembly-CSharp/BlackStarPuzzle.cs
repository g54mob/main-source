using UnityEngine;

public class BlackStarPuzzle : MonoBehaviour
{
	[Header("Black Star Puzzle")]
	public PuzzleIdentity puzzleIdentity;

	public bool puzzleCompleted;

	[SerializeField]
	private GameObject blackStarOrb_Dummy;

	public virtual void Start()
	{
		int num = (int)puzzleIdentity;
		while (PuzzleManager.Singleton.blackStarPuzzleScripts.Count <= num)
		{
			PuzzleManager.Singleton.blackStarPuzzleScripts.Add(null);
		}
		PuzzleManager.Singleton.blackStarPuzzleScripts[num] = this;
	}

	public virtual void CompletePuzzle(bool _SpawnBlackStarOrb, bool _playSolveSFX)
	{
		puzzleCompleted = true;
		Debug.Log("PUZZLE SOLVED!");
		blackStarOrb_Dummy.SetActive(value: false);
		if (_SpawnBlackStarOrb)
		{
			PuzzleManager.Singleton.SpawnBlackStarOrb(puzzleIdentity);
		}
		if (_playSolveSFX)
		{
			AudioManager.Singleton.PlayBlackStarPuzzle_Solved();
		}
	}

	public Transform GetStarOrbSpawnTransform()
	{
		return blackStarOrb_Dummy.transform;
	}
}
