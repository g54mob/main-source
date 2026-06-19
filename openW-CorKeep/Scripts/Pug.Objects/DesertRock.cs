using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class DesertRock : EntityMonoBehaviour
{
	public List<GameObject> ObjectsToFlipRandomly;

	public override void OnOccupied()
	{
		base.OnOccupied();
		int hashCode = base.WorldPosition.GetHashCode();
		bool flag = PugRandom.Range(0f, 1f, hashCode) > 0.5f;
		foreach (GameObject item in ObjectsToFlipRandomly)
		{
			item.transform.localScale = new Vector3((!flag) ? 1 : (-1), 1f, 1f);
		}
	}
}
