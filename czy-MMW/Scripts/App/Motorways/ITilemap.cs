using UnityEngine;

namespace Motorways
{
	public interface ITilemap
	{
		Tile GetTile(Vector2Int coordinates);

		Tile GetOrCreateTile(Vector2Int coordinates);

		Motorway GetMotorway(int id);

		Motorway CreateMotorway(int id, int motorwayNumber, int replacedMotorwayNumber);
	}
}
