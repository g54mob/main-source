using UnityEngine;

public interface ITowItem
{
	string TowId { get; }

	string TowFriendlyId { get; }

	GameObject UnderlyingGameObject { get; }

	bool CanBeTowed { get; set; }

	string CantTowReason { get; }

	bool IsBeingTowed { get; set; }

	Transform TowItemTransform { get; }

	Color TowColor { get; }

	void MoveForwardForced(float speed);

	void PreRotation();

	void PostRotation();

	void StartColorBlink(Color colorToFadeTo, float cycleTime, int numberOfCycles);
}
