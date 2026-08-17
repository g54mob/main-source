using Assets.Scripts.Actors.Player;
using UnityEngine;

public class MinimapPlayerIcon : MonoBehaviour
{
	private unsafe void Update()
	{
		//IL_0071: Expected O, but got Ref
		//IL_0084: Expected O, but got Ref
		//IL_0091: Expected O, but got Ref
		//IL_00a7: Expected O, but got Ref
		if (MyPlayer.Instance != null)
		{
			Transform transform = base.transform;
			MyPlayer instance = MyPlayer.Instance;
			PlayerMovement playerMovement = instance.playerMovement;
			Transform transform2 = playerMovement.orientation.transform;
			Quaternion rotation = transform2.rotation;
			float num = default(float);
			Vector3 vector = Quaternion.Internal_ToEulerRad((Quaternion)(&num));
			float num2 = default(float);
			Vector3 vector2 = Quaternion.Internal_MakePositive((Vector3)(&num2));
			object obj = default(object);
			Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj));
			transform.rotation = (Quaternion)(&num);
		}
	}
}
