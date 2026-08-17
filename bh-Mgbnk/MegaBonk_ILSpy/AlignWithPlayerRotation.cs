using Assets.Scripts.Actors.Player;
using UnityEngine;

public class AlignWithPlayerRotation : MonoBehaviour
{
	private unsafe void Update()
	{
		//IL_0068: Expected O, but got Ref
		if (MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			Transform transform = instance.playerRenderer.transform;
			Vector3 up = transform.up;
			Transform transform2 = base.transform;
			float num = default(float);
			transform2.up = (Vector3)(&num);
		}
	}
}
