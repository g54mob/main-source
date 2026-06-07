using UnityEngine;

public interface IGameCenterAccessPoint
{
	bool IsAvailable();

	void Show();

	void Hide();

	Rect GetRect();

	void Select();
}
