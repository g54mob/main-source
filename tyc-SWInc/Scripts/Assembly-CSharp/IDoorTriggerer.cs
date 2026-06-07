using UnityEngine;

public interface IDoorTriggerer
{
	Vector3 GetPosition();

	Vector3 GetFuturePoint(float dist);
}
