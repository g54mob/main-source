using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class ChantMgr : MonoBehaviour
{
	public static ChantMgr I;

	private bool _isChanting;

	private int _curChantLoops;

	private int _numInvalidChantBeats;

	private Dictionary<EventReference, List<GridPieceObj>> _chantersBySfx;

	private List<GridPieceObj> _allChanters;

	private BeatLength _beatLength;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void MyUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnBeat()
	{
	}

	private void RunChantBeat(int curBeat)
	{
	}
}
