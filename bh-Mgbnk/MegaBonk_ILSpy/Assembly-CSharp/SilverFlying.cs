using Assets.Scripts.Actors.Player;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SilverFlying : MonoBehaviour
{
	private bool pickedUp;

	private Transform target;

	private float speed;

	private Vector3 randomDir;

	private float rndSpeed;

	private float rndMaxSpeed = 40f;

	private float rndTime;

	public unsafe void Set(Vector3 pos)
	{
		//IL_002f: Expected O, but got Ref
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		speed = -20f;
		Transform transform2 = MyPlayer.Instance.transform;
		target = transform2;
		pickedUp = false;
		Vector3 insideUnitSphere = Random.insideUnitSphere;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj = default(object);
		randomDir = (Vector3)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v16+8]");
		_ = 0;
		rndSpeed = rndMaxSpeed;
		rndTime = 0f;
	}

	private unsafe void Update()
	{
		//IL_0189: Expected O, but got Ref
		//IL_01e7: Invalid comparison between I4 and F4
		//IL_0104: Invalid comparison between I4 and F4
		//IL_00c0: Expected F4, but got I4
		//IL_014f: Expected F4, but got I4
		//IL_016e: Expected O, but got Ref
		if (!(target != null))
		{
			return;
		}
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Vector3 position2 = target.position;
		Transform transform2 = base.transform;
		Vector3 position3 = transform2.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num = default(float);
		transform.position = (Vector3)(&num);
		if (49f > speed)
		{
			float num2 = MyTime.deltaTime + MyTime.deltaTime;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			float num3 = 50f - speed;
			float num4 = num3 * num2;
			float num5 = num4 + speed;
			speed = num5;
		}
		if (!(1f > rndTime))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num6 = Easing.OutCirc(rndTime = deltaTime + rndTime);
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		float num7 = 0f - rndMaxSpeed;
		float num8 = num7 * num6;
		float num9 = num8 + rndMaxSpeed;
		rndSpeed = num9;
		Transform transform3 = base.transform;
		Vector3 position4 = transform3.position;
		transform3.position = (Vector3)(&num);
	}

	private void FixedUpdate()
	{
		if (!pickedUp)
		{
			Vector3 position = target.position;
			Transform transform = base.transform;
			Vector3 position2 = transform.position;
			float num = position.x - position2.x;
			float num2 = position.y - position2.y;
			float num3 = position.z - position2.z;
			float num4 = num2 * num2;
			float num5 = num * num;
			float num6 = num3 * num3;
			float num7 = num4 + num5;
			float num8 = num7 + num6;
			if (0.5f > num8)
			{
				AudioManager.Instance.PlaySilver();
				MyPlayer instance = MyPlayer.Instance;
				instance.inventory.AddSilver(1);
				PoolManager instance2 = PoolManager.Instance;
				GameObject element = base.gameObject;
				instance2.silverPool.Release(element);
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			}
		}
	}

	private void Pickup()
	{
		AudioManager.Instance.PlaySilver();
		MyPlayer instance = MyPlayer.Instance;
		instance.inventory.AddSilver(1);
		PoolManager instance2 = PoolManager.Instance;
		GameObject element = base.gameObject;
		instance2.silverPool.Release(element);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}
}
