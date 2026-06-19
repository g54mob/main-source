using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class SpriteRendererSortOverride
{
	internal struct Backup
	{
		public SpriteRenderer sr;

		public int sortingLayer;

		public int sortingOrder;
	}

	private List<Backup> backups = new List<Backup>(16);

	private List<SpriteRendererAutoSort> sorters = new List<SpriteRendererAutoSort>(16);

	private List<SpriteRenderer> _preallocSRs = new List<SpriteRenderer>(16);

	public bool snapshotTaken { get; private set; }

	public bool tainted { get; private set; }

	public void BackupSortingData(GameObject root, bool includeInactive = false)
	{
		root.GetComponentsInChildren(includeInactive, sorters);
		root.GetComponentsInChildren(includeInactive, _preallocSRs);
		_preallocSRs.Sort((SpriteRenderer x, SpriteRenderer y) => x.sortingOrder.CompareTo(y.sortingOrder));
		backups.Recycle(_preallocSRs.Count);
		foreach (SpriteRenderer preallocSR in _preallocSRs)
		{
			backups.Add(new Backup
			{
				sr = preallocSR,
				sortingLayer = preallocSR.sortingLayerID,
				sortingOrder = preallocSR.sortingOrder
			});
		}
		_preallocSRs.Clear();
		snapshotTaken = true;
	}

	public void SendToSortingLayer(int sortingLayer)
	{
		_SendTo(sortingLayer, useSortingOrder: false, -1);
	}

	public void SendToSortingLayerWithSortingOrder(int sortingLayer, int sortingOrder)
	{
		_SendTo(sortingLayer, useSortingOrder: true, sortingOrder);
	}

	private void _SendTo(int sortingLayer, bool useSortingOrder, int sortingOrder)
	{
		for (int i = 0; i < backups.Count; i++)
		{
			Backup backup = backups[i];
			if (!(backup.sr == null))
			{
				backup.sr.sortingLayerID = sortingLayer;
				if (useSortingOrder)
				{
					backup.sr.sortingOrder = sortingOrder + i;
				}
			}
		}
		foreach (SpriteRendererAutoSort sorter in sorters)
		{
			if (!(sorter == null))
			{
				sorter.enabled = false;
			}
		}
		tainted = true;
	}

	public void RestoreSortingData()
	{
		if (!tainted)
		{
			return;
		}
		foreach (Backup backup in backups)
		{
			if (!(backup.sr == null))
			{
				backup.sr.sortingLayerID = backup.sortingLayer;
				backup.sr.sortingOrder = backup.sortingOrder;
			}
		}
		foreach (SpriteRendererAutoSort sorter in sorters)
		{
			if (!(sorter == null))
			{
				sorter.enabled = true;
			}
		}
		tainted = false;
	}

	public void ClearSortingData()
	{
		backups.Clear();
		sorters.Clear();
		snapshotTaken = false;
		tainted = false;
	}
}
