using Assets.Scripts.Actors.Player;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ReturnWeaponWui : MonoBehaviour
{
	public RawImage icon;

	private Transform target;

	private Vector3 targetOffset;

	private float scale;

	private bool useScaleDown;

	private int phase;

	private float timer;

	private float moveUpTimer;

	private float moveUpTime;

	private float floatAbovePlayerHeadTime = 1.5f;

	private float scaleDownTime = 1f;

	public unsafe void Set(UnlockableBase unlockable)
	{
		//IL_006d: Expected O, but got Ref
		//IL_008e: Expected O, but got Ref
		Texture texture = unlockable.GetIcon();
		icon.texture = texture;
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		float num = default(float);
		transform.position = (Vector3)(&num);
		Transform transform3 = base.transform;
		transform3.localScale = (Vector3)(&num);
		scale = 1.5f;
		timer = 0f;
		bool flag = !(0.75f > floatAbovePlayerHeadTime);
		float num2 = 0.75f;
		if (!flag)
		{
			num2 = floatAbovePlayerHeadTime;
		}
		moveUpTime = num2;
	}

	private unsafe void Update()
	{
		//IL_042c: Invalid comparison between I4 and F4
		//IL_0231: Expected F4, but got I4
		//IL_038c: Invalid comparison between I4 and F4
		//IL_0243: Expected O, but got Ref
		//IL_0063: Expected F4, but got I4
		//IL_0474: Invalid comparison between I4 and F4
		//IL_027f: Expected F4, but got I4
		//IL_04be: Invalid comparison between I4 and F4
		//IL_02bb: Expected F4, but got I4
		//IL_00cb: Invalid comparison between I4 and F4
		//IL_02f8: Expected O, but got Ref
		//IL_0119: Expected O, but got Ref
		//IL_03ed: Invalid comparison between I4 and F4
		//IL_0180: Expected F4, but got I4
		//IL_0192: Expected O, but got Ref
		float num4 = default(float);
		if (phase != 0)
		{
			if (phase != 1)
			{
				return;
			}
			float num = MyTime.deltaTime / scaleDownTime;
			float num2 = num + timer;
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
			timer = num2;
			float num3 = Easing.InOutCirc(num2);
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			Transform transform3 = base.transform;
			if (0f > num3 || num3 > 1f)
			{
			}
			transform3.position = (Vector3)(&num4);
			Transform transform4 = base.transform;
			Transform transform5 = base.transform;
			Vector3 localScale = transform5.localScale;
			float deltaTime = Time.deltaTime;
			float num5 = deltaTime * 4f;
			if (!(0f > num5))
			{
				if (num5 > 1f)
				{
					num5 = 1f;
				}
			}
			else
			{
				num5 = 0f;
			}
			transform4.localScale = (Vector3)(&num4);
			if (!(timer < 1f))
			{
				GameObject obj = base.gameObject;
				Object.Destroy(obj);
			}
			return;
		}
		Transform transform6 = base.transform;
		Transform transform7 = base.transform;
		Vector3 localScale2 = transform7.localScale;
		float deltaTime2 = Time.deltaTime;
		float num6 = deltaTime2 * 4f;
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
		transform6.localScale = (Vector3)(&num4);
		float num7 = MyTime.deltaTime / floatAbovePlayerHeadTime;
		float num8 = num7 + timer;
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
		timer = num8;
		float num9 = MyTime.deltaTime / moveUpTime;
		float num10 = num9 + moveUpTimer;
		if (!(0f > num10))
		{
			if (num10 > 1f)
			{
				num10 = 1f;
			}
		}
		else
		{
			num10 = 0f;
		}
		moveUpTimer = num10;
		float num11 = Easing.InOutCirc(num10);
		Transform transform8 = base.transform;
		Transform transform9 = MyPlayer.Instance.transform;
		Vector3 position3 = transform9.position;
		transform8.position = (Vector3)(&num4);
		if (!(timer < 1f))
		{
			int num12 = phase + 1;
			phase = num12;
			timer = 0f;
		}
	}
}
