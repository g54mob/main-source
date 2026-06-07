using UnityEngine;

public interface IPointable
{
	void Hover(Vector3 point, Vector3 normal, HandIPointableSource source);

	void Unhover();

	string GetHoverText();
}
