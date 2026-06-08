using UnityEngine;

public abstract class AsciiObject : MonoBehaviour
{
	public int PositionX;

	public int PositionY;

	public int Width;

	public int Height;

	public AsciiObject sourcePrefab { get; set; }

	public abstract void UpdateTic();

	public abstract void Draw(AsciiRenderProcedural r, int offsetX, int offsetY);
}
