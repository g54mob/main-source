using System;
using System.Collections.Generic;
using UnityEngine;

public class FailTrigger : MonoBehaviour
{
	private class BrainBlockInside
	{
		private FailTrigger failTrigger;

		private bool isBrainBlockInZone;

		private float timer;

		private BlockView brainBlockView;

		public BlockView BrainBlockView
		{
			get
			{
				return brainBlockView;
			}
			set
			{
				brainBlockView = value;
				isBrainBlockInZone = true;
				timer = 0f;
			}
		}

		public BrainBlockInside(FailTrigger failTrigger)
		{
			this.failTrigger = failTrigger;
			isBrainBlockInZone = false;
			timer = 0f;
		}

		public void Update(float deltaTime)
		{
			if (isBrainBlockInZone)
			{
				timer += deltaTime;
				if (timer >= (float)failTrigger.secondsToFail && failTrigger.FailedEvent != null)
				{
					failTrigger.isFailed = true;
					failTrigger.FailedEvent(brainBlockView.ParentCreationView.CreationRole);
				}
			}
		}
	}

	public int secondsToFail;

	private bool isFailed;

	private List<BrainBlockInside> brainList;

	public event Action<CreationView.CreationRoleState> FailedEvent;

	private void Start()
	{
		isFailed = false;
		brainList = new List<BrainBlockInside>();
	}

	private void Update()
	{
		if (!isFailed)
		{
			for (int i = 0; i < brainList.Count; i++)
			{
				brainList[i].Update(Time.deltaTime);
			}
		}
	}

	private void OnTriggerEnter(Collider colliderInfo)
	{
		if (IsBrainBlock(colliderInfo) && !isFailed)
		{
			BlockView blockView = colliderInfo.gameObject.GetBlockView();
			brainList.Add(new BrainBlockInside(this)
			{
				BrainBlockView = blockView
			});
		}
	}

	private void OnTriggerExit(Collider colliderInfo)
	{
		if (!IsBrainBlock(colliderInfo) || isFailed)
		{
			return;
		}
		BlockView blockView = colliderInfo.gameObject.GetBlockView();
		BrainBlockInside item = null;
		foreach (BrainBlockInside brain in brainList)
		{
			if (brain.BrainBlockView == blockView)
			{
				item = brain;
				break;
			}
		}
		brainList.Remove(item);
	}

	private bool IsBrainBlock(Collider colliderInfo)
	{
		if (!colliderInfo.CompareTag("Block") || isFailed)
		{
			return false;
		}
		if (colliderInfo.gameObject.GetBlockView().Schematic.Type != "brain")
		{
			return false;
		}
		return true;
	}

	public void Reset()
	{
		isFailed = false;
		brainList.Clear();
	}
}
