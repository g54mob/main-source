using UnityEngine;

public class AnimEventEmitter : MonoBehaviour
{
	public delegate void AnimEvent(AnimEventId evId);

	public delegate void IntAnimEvent(AnimEventId evId, int id);

	public AnimEvent OnEventEmitted;

	public IntAnimEvent OnIntEventEmitted;

	public void DragStart(int id)
	{
	}

	public void DragEnd(int id)
	{
	}

	public void PunchChargeStart(int id)
	{
	}

	public void Flap()
	{
	}
}
