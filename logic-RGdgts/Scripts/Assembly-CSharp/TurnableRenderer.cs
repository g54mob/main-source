using UnityEngine;

public abstract class TurnableRenderer : MonoBehaviour
{
	public TurnableRenderer parent;

	public new abstract bool enabled { get; set; }

	public abstract SpriteMaskInteraction maskInteraction { get; set; }

	public abstract string sortingLayerName { get; set; }

	public abstract int sortingLayerID { get; set; }

	public abstract int sortingOrder { get; set; }

	public int rotationI { get; protected set; }

	public abstract void SetRotation(int rotationI);
}
