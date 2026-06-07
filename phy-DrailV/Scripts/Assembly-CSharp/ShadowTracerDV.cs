using UnityEngine;

public class ShadowTracerDV : ShadowTracer
{
	protected override Vector3 WorldOffset => WorldMover.currentMove;

	protected override Camera CurrentlyActiveCamera => PlayerManager.ActiveCamera;
}
