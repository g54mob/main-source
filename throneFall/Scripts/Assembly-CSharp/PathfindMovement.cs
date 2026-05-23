using Pathfinding.RVO;
using UnityEngine;

public abstract class PathfindMovement : MonoBehaviour
{
	public virtual bool IsSlowed => false;

	public virtual RVOController RVO => null;

	public abstract void ClearCurrentPath();

	public abstract void Slow(float _duration);

	public abstract void GetAgroFromObject(TaggedObject _agroTarget);
}
