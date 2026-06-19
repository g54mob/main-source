using System;
using Aggro.Core;
using UnityEngine;

public class FloaterPopulator : EntityBehaviourBase
{
	[Flags]
	public enum VisibleRoomTypesMask
	{
		Lobby = 8,
		BreakRoom = 2,
		Warehouse = 4
	}

	public GameObject floaterUIPrefab;

	public bool AddFloaterOnEntityCreated = true;

	private FloaterUI _floaterUI;

	public Transform targetTransform;

	public bool continuouslyUpdate;

	public bool excludeLocalPlayer;

	public VisibleRoomTypesMask visibleRoomTypeMask = (VisibleRoomTypesMask)2147483647;

	protected override void OnUpdatePresentationLate()
	{
		if (_floaterUI != null)
		{
			RoomType currentRoomType = GameUtil.GetCurrentRoomType();
			if (((uint)(1 << (int)currentRoomType) & (uint)visibleRoomTypeMask) == 0)
			{
				_floaterUI.visible = false;
			}
			if (continuouslyUpdate)
			{
				_floaterUI.targetWorldPosition = ((targetTransform != null) ? targetTransform.position : base.transform.position);
			}
		}
	}

	protected override void OnEntityCreated()
	{
		if (AddFloaterOnEntityCreated)
		{
			AddFloater();
		}
	}

	public void AddFloater()
	{
		if (!excludeLocalPlayer || !base.isLocalPlayer)
		{
			if (_floaterUI != null)
			{
				RemoveFloater();
			}
			_floaterUI = AggroManagerBase<FloaterManagerUI>.instance.AddFloater(floaterUIPrefab);
			_floaterUI.targetWorldPosition = ((targetTransform != null) ? targetTransform.position : base.transform.position);
			IFloaterPopulator[] components = GetComponents<IFloaterPopulator>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].AddedFloater(_floaterUI);
			}
		}
	}

	public void HideAndRemoveFloater()
	{
		if (_floaterUI != null)
		{
			_floaterUI.HideAndRemove();
		}
	}

	public void RemoveFloater()
	{
		if (_floaterUI != null)
		{
			AggroManagerBase<FloaterManagerUI>.instance.RemoveFloater(_floaterUI);
		}
	}

	protected override void OnEntityDestroyed()
	{
		RemoveFloater();
	}
}
