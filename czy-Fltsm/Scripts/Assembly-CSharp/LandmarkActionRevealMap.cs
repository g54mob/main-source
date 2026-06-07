using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/Actions/Reveal Map")]
public class LandmarkActionRevealMap : LandmarkAction, ILandmarkActionToggleable, IToggleable
{
	public string Label => base.Title;

	public override GameEventType InteractableEventType => GameEventType.LandmarkActionRevealMapInteractable;

	public bool IsInteractable => ReturnIsInteractable();

	public bool IsToggled => base.State == ILandmarkActionStates.Active;

	public bool Unlocked { get; set; } = true;

	public override void OnLandmarkSpawned(LandmarkActionPersistentData persistentData = null)
	{
		base.OnLandmarkSpawned(persistentData);
		LandmarkLookout[] componentsInChildren = _landmarkBehaviour.Landmark.GetComponentsInChildren<LandmarkLookout>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].IsInteractable = true;
		}
	}

	public IEnumerator Unlock()
	{
		yield break;
	}

	protected override void OnActivated()
	{
		GameEventDispatcher.AddListener(GameEventType.RegionScouted, OnMapRegionScouted);
	}

	protected override void OnDeactivated()
	{
		GameEventDispatcher.RemoveListener(GameEventType.RegionScouted, OnMapRegionScouted);
	}

	protected override void OnProjectFinished(Project project, bool success)
	{
		base.OnProjectFinished(project, success);
		Debug.Log("Reveal Map Option 2!");
	}

	public override void InitializeUI(LandmarkPanel landmarkPanel)
	{
		landmarkPanel.ReturnLandmarkActionUI<LandmarkActionScoutUI>().Initialize(this);
	}

	public void Toggle()
	{
		ILandmarkActionStates state = base.State;
		if (state != ILandmarkActionStates.Hidden && state != ILandmarkActionStates.Completed)
		{
			if (!IsToggled)
			{
				Activate();
			}
			else
			{
				Deactivate();
			}
		}
	}

	public bool TryReturnRequiredItemAndCost(out ItemProperties itemProperties, out int cost)
	{
		itemProperties = null;
		cost = 0;
		return false;
	}

	private void OnMapRegionScouted(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.RegionScouted, OnMapRegionScouted);
		SetState(ILandmarkActionStates.Completed);
	}
}
