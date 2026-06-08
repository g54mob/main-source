using UnityEngine;

public abstract class CreditsASlide : MonoBehaviour
{
	public abstract void Reset();

	public abstract void UpdateTic();

	public abstract void Draw(AsciiRenderProcedural r, int offsetX, int offsetY);

	public abstract bool IsDone();
}
