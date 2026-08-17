using Assets.Scripts.Actors.Player;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
	private unsafe void Update()
	{
		//IL_0063: Expected O, but got Ref
		if (MyPlayer.Instance != null)
		{
			Transform transform = base.transform;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position = transform2.position;
			object obj = default(object);
			transform.position = (Vector3)(&obj);
		}
	}
}
