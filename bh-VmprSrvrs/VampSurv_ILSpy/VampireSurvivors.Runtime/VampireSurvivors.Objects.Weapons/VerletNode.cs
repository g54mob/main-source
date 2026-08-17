using UnityEngine;

namespace VampireSurvivors.Objects.Weapons;

public class VerletNode(Vector2 position)
{
	public Vector2 position = position;

	public Vector2 oldPosition = position;
}
