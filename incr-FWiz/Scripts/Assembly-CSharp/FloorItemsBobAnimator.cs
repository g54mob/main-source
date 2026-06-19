using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FloorItemsBobAnimator : MonoBehaviour
{
	private class BobPool
	{
		public List<FloorItem> FloorItems;

		public float Offset;

		public Tween Tween;

		public void Add(FloorItem item)
		{
		}

		public bool Remove(FloorItem item)
		{
			return false;
		}
	}

	[SerializeField]
	private int _bobPoolCount;

	[SerializeField]
	private float _bobHeight;

	[SerializeField]
	private float _bobDuration;

	[SerializeField]
	private float _offset;

	private List<BobPool> _bobPools;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void EnterItem(FloorItem item)
	{
	}

	public void ExitItem(FloorItem item)
	{
	}

	private void Update()
	{
	}
}
