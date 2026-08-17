using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MoneyFlying : MonoBehaviour
{
	public static int maxMoneyObjects = 30;

	public int value = 1;

	private bool pickedUp;

	private Transform target;

	private float speed;

	public ParticleSystem ps;

	public Color colorTier1;

	public Color colorTier2;

	public Color colorTier3;

	private float currentSize;

	private Vector3 randomDir;

	private float rndSpeed;

	private float rndMaxSpeed = 40f;

	private float rndTime;

	private Vector3 lastPosition;

	public unsafe void Set(int value, Vector3 pos)
	{
		//IL_0030: Expected O, but got Ref
		//IL_003f: Expected O, but got F4
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		lastPosition = (Vector3)pos.x;
		_ = pos.z;
		this.value = value;
		pickedUp = false;
		speed = -20f;
		Transform transform2 = MyPlayer.Instance.transform;
		target = transform2;
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj = default(object);
		randomDir = (Vector3)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v17+8]");
		_ = 0;
		rndSpeed = rndMaxSpeed;
		rndTime = 0f;
		RefreshVisuals();
	}

	public void AddValue(int value)
	{
		int num = this.value + value;
		this.value = num;
		RefreshVisuals();
	}

	private unsafe void RefreshVisuals()
	{
		//IL_0098: Expected O, but got Ref
		//IL_00be: Expected O, but got Ref
		int[] moneyTiers = MoneyUtility.moneyTiers;
		float num;
		if (value >= moneyTiers[0])
		{
			num = 1f;
		}
		else
		{
			int[] moneyTiers2 = MoneyUtility.moneyTiers;
			num = ((value < moneyTiers2[1]) ? 0.4f : 0.8f);
		}
		bool flag = num == currentSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804D3D82h\"");
		if (!flag)
		{
			Color color = default(Color);
			ps.startColor = (Color)(&color);
			Transform transform = ps.transform;
			float num2 = default(float);
			transform.localScale = (Vector3)(&num2);
			currentSize = num;
		}
	}

	private unsafe void Update()
	{
		//IL_0021: Expected O, but got F4
		//IL_01c9: Expected O, but got Ref
		//IL_0224: Invalid comparison between I4 and F4
		//IL_013a: Invalid comparison between I4 and F4
		//IL_00f6: Expected F4, but got I4
		//IL_0185: Expected F4, but got I4
		//IL_01a4: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		lastPosition = (Vector3)position.x;
		_ = position.z;
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		Vector3 position3 = target.position;
		Transform transform3 = base.transform;
		Vector3 position4 = transform3.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num = default(float);
		transform2.position = (Vector3)(&num);
		float num2;
		float num3;
		if (MyTime.finalSwarmTimer > 10f)
		{
			num2 = 4f;
			num3 = 150f;
		}
		else
		{
			num2 = 2f;
			num3 = 50f;
		}
		if (num3 > speed)
		{
			float num4 = num2 * MyTime.deltaTime;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			float num5 = num3 - speed;
			float num6 = num5 * num4;
			float num7 = num6 + speed;
			speed = num7;
		}
		if (!(1f > rndTime))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num8 = Easing.OutCirc(rndTime = deltaTime + rndTime);
		if (!(0f > num8))
		{
			if (num8 > 1f)
			{
				num8 = 1f;
			}
		}
		else
		{
			num8 = 0f;
		}
		float num9 = 0f - rndMaxSpeed;
		float num10 = num9 * num8;
		float num11 = num10 + rndMaxSpeed;
		rndSpeed = num11;
		Transform transform4 = base.transform;
		Vector3 position5 = transform4.position;
		transform4.position = (Vector3)(&num);
	}

	private unsafe void FixedUpdate()
	{
		//IL_0056: Expected O, but got Ref
		//IL_0056: Expected O, but got Ref
		//IL_0056: Expected O, but got Ref
		if (!pickedUp)
		{
			bool flag = !(MyTime.finalSwarmTimer > 10f);
			float num = 0.25f;
			if (!flag)
			{
				num = 2f;
			}
			Vector3 position = target.position;
			Transform transform = base.transform;
			Vector3 position2 = transform.position;
			object obj = default(object);
			Vector3 vector = default(Vector3);
			object obj2 = default(object);
			float num2 = DistancePointToSegment((Vector3)(&obj), (Vector3)(&vector), (Vector3)(&obj2));
			if (!(num < num2))
			{
				AudioManager.Instance.PlayGold();
				PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
				playerInventory.ChangeGold(value);
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
				PoolManager instance = PoolManager.Instance;
				GameObject element = base.gameObject;
				instance.goldPool.Release(element);
			}
		}
	}

	private float DistancePointToSegment(Vector3 p, Vector3 a, Vector3 b)
	{
		//IL_0144: Invalid comparison between I4 and F4
		//IL_018f: Expected F4, but got I4
		//IL_02cb: Expected I, but got O
		//IL_0221: Expected F4, but got I4
		float num = b.x - a.x;
		float num2 = b.y - a.y;
		float num3 = b.z - a.z;
		float num4 = p.x - a.x;
		float num5 = p.z - a.z;
		float num6 = p.y - a.y;
		float num7 = num4 * num;
		float num8 = num5 * num3;
		float num9 = num6 * num2;
		float num10 = num2 * num2;
		float num11 = num9 + num7;
		float num12 = num * num;
		float num13 = num11 + num8;
		float num14 = num10 + num12;
		float num15 = num3 * num3;
		float num16 = num14 + num15;
		float num17 = num13 / num16;
		if (!(0f > num17))
		{
			if (num17 > 1f)
			{
				num17 = 1f;
			}
		}
		else
		{
			num17 = 0f;
		}
		float num18 = num * num17;
		float num19 = num2 * num17;
		float num20 = num18 + a.x;
		float num21 = num3 * num17;
		float num22 = num19 + a.y;
		float num23 = num21 + a.z;
		nint num24 = (nint)typeof(Math);
		float num25 = p.x - num20;
		float num26 = p.y - num22;
		float num27 = p.z - num23;
		float num28 = num26 * num26;
		float num29 = num25 * num25;
		float num30 = num27 * num27;
		float num31 = num28 + num29;
		float num32 = num31 + num30;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v2 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			return 0f;
		}
		double num33 = Math.Sqrt(num32);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		return (float)num33;
	}

	private void Pickup()
	{
		AudioManager.Instance.PlayGold();
		PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
		playerInventory.ChangeGold(value);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		PoolManager instance = PoolManager.Instance;
		GameObject element = base.gameObject;
		instance.goldPool.Release(element);
	}
}
