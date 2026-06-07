using System.Collections.Generic;
using UnityEngine;

public interface IRoom
{
	bool Outdoors { get; set; }

	bool Outside { get; set; }

	bool Pillar { get; set; }

	bool Rentable { get; set; }

	bool PlayerOwned { get; }

	float FenceHeight { get; set; }

	int Floor { get; set; }

	SVector3 FloorOffset { get; set; }

	float FloorRotation { get; set; }

	float FloorScale { get; set; }

	List<WallEdge> Edges { get; set; }

	Roof Roofing { get; set; }

	int AtriumChildrenCount { get; }

	uint GetUniqueID();

	uint GetRoomNetworkID();

	bool MakeBlack();

	IRoom GetAtriumParent(bool returnNull);

	bool IsContentVisible();

	IRoom FindCeilingAtrium(Vector2 p);

	IEnumerable<IRoom> GetSelfAndAtriumsAbove();

	Vector2[] GetExpanded(float expansion, bool ignoreBalcony = false);
}
