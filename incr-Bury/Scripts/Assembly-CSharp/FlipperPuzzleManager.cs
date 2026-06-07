using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperPuzzleManager : BlackStarPuzzle
{
	public enum FlipperPuzzleState
	{
		Active = 0,
		Failed = 1,
		Success = 2
	}

	[SerializeField]
	private List<FlipperPuzzle_Tile> flipperTiles;

	public FlipperPuzzleState puzzleState;

	private FlipperPuzzle_Tile lastFlippedTile;

	[Header("Tile Images")]
	[SerializeField]
	private List<GameObject> tileImages_Berries;

	[SerializeField]
	private List<GameObject> tileImages_Failed;

	public override void Start()
	{
		base.Start();
		SetUsAsTilesManager();
	}

	private void Update()
	{
	}

	private void SetUsAsTilesManager()
	{
		foreach (FlipperPuzzle_Tile flipperTile in flipperTiles)
		{
			flipperTile.SetOurManager(this);
		}
	}

	public void FlipATile(FlipperPuzzle_Tile _tile)
	{
		if (_tile.tileState != FlipperPuzzle_Tile.TileState.idle)
		{
			return;
		}
		_tile.tileState = FlipperPuzzle_Tile.TileState.flipped;
		AudioManager.Singleton.PlayUnimportantSFX(AudioManager.Singleton.sfx_Puzzle_SlidingSwitch, _tile.transform.position, new Vector2(0.95f, 1.05f), 0.6f, 6f, 1f);
		if ((bool)lastFlippedTile)
		{
			if (lastFlippedTile.tileValue == _tile.tileValue)
			{
				Debug.Log("Second tile matched!");
				lastFlippedTile.tileSolved = true;
				_tile.tileSolved = true;
				StartCoroutine(WaitForTileToFlipThen_PlayPositiveFeedback(lastFlippedTile));
				StartCoroutine(WaitForTileToFlipThen_PlayPositiveFeedback(_tile, _playSFX: true));
				if (AreAllTilesSolved())
				{
					CompletePuzzle(true, true);
				}
				lastFlippedTile = null;
			}
			else
			{
				Debug.Log("Second tile DID NOT MATCH BOOO");
				puzzleState = FlipperPuzzleState.Failed;
				StartCoroutine(WaitForTileToFlipThen_PlayNegativeFeedback(lastFlippedTile));
				StartCoroutine(WaitForTileToFlipThen_PlayNegativeFeedback(_tile, _playSFX: true, _showFailedTileImages: true));
			}
		}
		else
		{
			Debug.Log("Only one tile comparing!");
			lastFlippedTile = _tile;
		}
	}

	private IEnumerator WaitForTileToFlipThen_PlayPositiveFeedback(FlipperPuzzle_Tile _tile, bool _playSFX = false)
	{
		yield return new WaitForSeconds(0.5f);
		_tile.PlayFeedback_Success();
		if (_playSFX)
		{
			AudioManager.Singleton.PlayPuzzleSFX_Progress();
		}
	}

	private IEnumerator WaitForTileToFlipThen_PlayNegativeFeedback(FlipperPuzzle_Tile _tile, bool _playSFX = false, bool _showFailedTileImages = false)
	{
		yield return new WaitForSeconds(0.5f);
		_tile.PlayFeedback_Failed();
		if (_playSFX)
		{
			AudioManager.Singleton.PlayPuzzleSFX_Negative();
		}
		if (!_showFailedTileImages)
		{
			yield break;
		}
		foreach (GameObject tileImages_Berry in tileImages_Berries)
		{
			tileImages_Berry.SetActive(value: false);
		}
		foreach (GameObject item in tileImages_Failed)
		{
			item.SetActive(value: true);
		}
	}

	private bool AreAllTilesSolved()
	{
		bool result = true;
		foreach (FlipperPuzzle_Tile flipperTile in flipperTiles)
		{
			if (!flipperTile.tileSolved)
			{
				result = false;
				result = false;
				break;
			}
		}
		return result;
	}

	public override void CompletePuzzle(bool _spawnOrb, bool _playSolveSFX)
	{
		base.CompletePuzzle(_spawnOrb, _playSolveSFX);
		foreach (FlipperPuzzle_Tile flipperTile in flipperTiles)
		{
			flipperTile.tileState = FlipperPuzzle_Tile.TileState.flipped;
		}
	}
}
