using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CircleWarning : MonoBehaviour
{
	public float warningTime = 2f;

	public Transform filler;

	private float defaultProjectorSize = 0.52f;

	private float timer;

	private Action finishAction;

	private Vector3 desiredScale;

	public unsafe void Set(float radius, float warningTime, Action finishAction)
	{
		//IL_0063: Expected I, but got O
		//IL_003f: Expected O, but got Ref
		this.finishAction = finishAction;
		float num = radius + radius;
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		float num4 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num5 = num4 * 0f;
		Vector3 vector = default(Vector3);
		desiredScale = vector;
		Transform transform = filler.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		this.warningTime = warningTime;
		timer = 0f;
	}

	private unsafe void Update()
	{
		//IL_01ae: Invalid comparison between I4 and F4
		//IL_007d: Expected F4, but got I4
		//IL_00b8: Expected O, but got Ref
		if (!(timer < 1f))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
		{
			return;
		}
		float num = MyTime.deltaTime / warningTime;
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
		Transform transform = filler.transform;
		float num3 = Easing.OutQuad(timer);
		float num4 = default(float);
		transform.localScale = (Vector3)(&num4);
		if (!(timer < 1f))
		{
			if (finishAction != null)
			{
				Action action = finishAction;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v409.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			PoolManager instance2 = PoolManager.Instance;
			GameObject element = base.gameObject;
			instance2.warningSpherePool.Release(element);
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	public void ReleaseToPool()
	{
		PoolManager instance = PoolManager.Instance;
		GameObject element = base.gameObject;
		instance.warningSpherePool.Release(element);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}
}
