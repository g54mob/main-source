using UnityEngine;

public interface IProcessor
{
	void BringOnline();

	void Update();

	void DebugDraw(ref Rect startingRect);
}
