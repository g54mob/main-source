using PajamaLlama.Flotsam.World;
using UnityEngine;

public interface ILandmarkBehaviourProvider
{
	string Name { get; }

	string EditorName { get; }

	Sprite EditorIcon { get; }

	float Radius { get; }

	LandmarkBehaviour ReturnLandmarkBehaviour(WorldRegionType region);

	MooringPointBase[] ReturnMooringPoints();

	bool ReturnIsInteractable();

	bool ReturnHasLandmarkActionReference<T>() where T : LandmarkAction;

	bool ReturnIsLandmarkBehaviour(LandmarkBehaviour behaviour);
}
