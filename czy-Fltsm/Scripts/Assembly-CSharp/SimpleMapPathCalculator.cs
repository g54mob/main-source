using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Map/Simple Path Calculator")]
public class SimpleMapPathCalculator : MapPathCalculator
{
	public override void CalculatePath(MapPath path, Vector3 from, Vector3 to)
	{
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		CalculatePointsOnPath(path.Obstacles, from.Vector2TopDown(), to.Vector2TopDown(), list);
		foreach (Vector2 item in list)
		{
			path.AddPathPoint(item);
		}
	}
}
