using System;
using System.Collections.Generic;
using UnityEngine;

public class AssemblerDetailWindow : MonoBehaviour
{
	public GUIWindow Window;

	public AssemblerDetailTile TilePrefab;

	public Transform TilePanel;

	public float RefreshTime = 0.25f;

	[NonSerialized]
	private ProductPrinter _target;

	[NonSerialized]
	private float _refreshTimer;

	[NonSerialized]
	private List<AssemblerDetailTile> _activeTiles = new List<AssemblerDetailTile>();

	[NonSerialized]
	private List<ValueTuple<int, float>> _recentlyDone = new List<ValueTuple<int, float>>();

	public void Show(ProductPrinter target)
	{
		_target = target;
		Window.Show();
		Window.NonLocTitle = "AssemblerPost".Loc((target.TargetProcess != null) ? target.TargetProcess.GetPrettyName() : "NotApplicableAbbr".Loc());
		Refresh();
	}

	private void Refresh()
	{
		_refreshTimer = RefreshTime;
		for (int i = 0; i < _recentlyDone.Count; i++)
		{
			ValueTuple<int, float> valueTuple = _recentlyDone[i];
			if (Time.realtimeSinceStartup - valueTuple.Item2 > 1f)
			{
				_activeTiles[valueTuple.Item1].gameObject.SetActive(false);
				_recentlyDone.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < _activeTiles.Count; j++)
		{
			AssemblerDetailTile assemblerDetailTile = _activeTiles[j];
			if (!assemblerDetailTile.gameObject.activeSelf)
			{
				break;
			}
			if (!assemblerDetailTile.Checkmark.activeSelf && assemblerDetailTile.CheckFinished())
			{
				_recentlyDone.Add(new ValueTuple<int, float>(j, Time.realtimeSinceStartup));
			}
		}
		int k = 0;
		lock (_target.ManufactureQueue)
		{
			for (int l = 0; l < _target.ManufactureQueue.Count; l++)
			{
				for (; IsDone(k); k++)
				{
				}
				SetTile(k, _target.ManufactureQueue[l]);
				k++;
			}
		}
		for (; k < _activeTiles.Count; k++)
		{
			if (!IsDone(k))
			{
				_activeTiles[k].gameObject.SetActive(false);
			}
		}
	}

	private bool IsDone(int k)
	{
		for (int i = 0; i < _recentlyDone.Count; i++)
		{
			if (_recentlyDone[i].Item1 == k)
			{
				return true;
			}
		}
		return false;
	}

	private void SetTile(int idx, ManufactureOrder order)
	{
		AssemblerDetailTile assemblerDetailTile;
		if (idx < _activeTiles.Count)
		{
			assemblerDetailTile = _activeTiles[idx];
		}
		else
		{
			assemblerDetailTile = UnityEngine.Object.Instantiate(TilePrefab);
			assemblerDetailTile.transform.SetParent(TilePanel, false);
			_activeTiles.Add(assemblerDetailTile);
		}
		assemblerDetailTile.gameObject.SetActive(true);
		assemblerDetailTile.Set(order, _target);
	}

	public void Update()
	{
		if (_target == null)
		{
			Window.Close();
			return;
		}
		if (GameSettings.GameSpeed > 0f)
		{
			_refreshTimer -= Time.deltaTime;
		}
		if (_refreshTimer <= 0f)
		{
			Refresh();
		}
	}
}
