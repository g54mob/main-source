using UnityEngine;

public interface IScreenModule
{
	bool isSoldered { get; }

	Vector2Int GetOrigin();

	Vector2Int GetSize();

	void RebindVideoChip();

	void SetTouchCoord(Vector2Int? coord);
}
