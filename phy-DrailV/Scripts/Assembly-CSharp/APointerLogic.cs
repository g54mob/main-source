using System;
using UnityEngine;

public abstract class APointerLogic : MonoBehaviour
{
	[NonSerialized]
	public Color colorValid;

	[NonSerialized]
	public Color colorInvalid;

	public abstract void Enable();

	public abstract void Disable();

	public abstract void SetColor(Color color);

	public abstract bool ScanForCab(int layerMask, out RaycastHit hit);

	public abstract bool ScanForTeleportDestination(int layerMask, out RaycastHit hit);

	public abstract bool IsActivationButtonBeingHeld();

	public abstract bool IsActivationButtonJustReleased();
}
