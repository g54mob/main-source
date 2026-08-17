using Assets.Scripts.Actors.Player;
using UnityEngine;

public class TestDeleteLater : MonoBehaviour
{
	public class Hoverboard
	{
		public void Do()
		{
		}

		public Hoverboard()
		{
			Do();
		}
	}

	private Rigidbody[] rbs;

	public GameObject ragdoll;

	public GameObject torso;

	private unsafe void MakeRagdoll()
	{
		//IL_0099: Expected O, but got Ref
		//IL_010a: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_01a8: Expected O, but got I4
		//IL_01b1: Expected O, but got I4
		//IL_01cc: Expected O, but got Ref
		//IL_0254: Expected O, but got Ref
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		GameObject gameObject = ragdoll.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = ragdoll.transform;
		transform.parentInternal = null;
		Transform transform2 = ragdoll.transform;
		MyPlayer instance = MyPlayer.Instance;
		Transform transform3 = instance.playerRenderer.transform;
		Vector3 position = transform3.position;
		float num = default(float);
		transform2.position = (Vector3)(&num);
		MyPlayer instance2 = MyPlayer.Instance;
		GameObject gameObject2 = instance2.playerRenderer.gameObject;
		gameObject2.SetActive(value: false);
		MyPlayer instance3 = MyPlayer.Instance;
		Vector3 velocity = instance3.playerMovement.GetVelocity();
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < componentsInChildren.Length)
		{
			componentsInChildren[obj].enabled = false;
			obj++;
			obj2 = obj;
		}
		MyPlayer instance4 = MyPlayer.Instance;
		PlayerMovement playerMovement = instance4.playerMovement;
		playerMovement.rb.isKinematic = true;
		Rigidbody[] componentsInChildren2 = ragdoll.GetComponentsInChildren<Rigidbody>(includeInactive: true);
		num = position.x;
		object obj3 = 0;
		object obj4 = 0;
		float num2 = default(float);
		while ((nint)obj3 < componentsInChildren2.Length)
		{
			componentsInChildren2[obj4].velocity = (Vector3)(&num2);
			componentsInChildren2[obj4].interpolation = RigidbodyInterpolation.Interpolate;
			componentsInChildren2[obj4].maxAngularVelocity = 99999f;
			componentsInChildren2[obj4].collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			float num3 = Random.insideUnitSphere.x * 10f;
			componentsInChildren2[obj4].AddTorque((Vector3)(&num), ForceMode.Impulse);
			obj4++;
			num = num3;
			obj3 = obj4;
		}
		MyPlayer instance5 = MyPlayer.Instance;
		PlayerInventory inventory = instance5.inventory;
		inventory.weaponInventory.ToggleWeapon(EWeapon.CorruptSword, enable: false);
		MyPlayer instance6 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance6.inventory;
		inventory2.weaponInventory.ToggleWeapon(EWeapon.HeroSword, enable: false);
	}

	private void LateUpdate()
	{
	}

	public void HoverboardFlying()
	{
		Hoverboard hoverboard = new Hoverboard();
	}
}
