using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class TubeWarning : MonoBehaviour
{
	public ParticleSystem ps;

	private float timer;

	private float fixedTimer;

	private float warningTime;

	private Action completeAction;

	private bool done;

	public unsafe void Set(float radius, float length, float time, Action completeAction)
	{
		//IL_008c: Expected O, but got Ref
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		ps.Stop();
		ps.time = 0f;
		ps.Play();
		ps.startLifetime = time;
		Transform transform = ps.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
		Action action = default(Action);
		this.completeAction = action;
		warningTime = time;
		timer = 0f;
		done = false;
	}

	private void Update()
	{
		//IL_0179: Invalid comparison between I4 and F4
		//IL_00b9: Expected F4, but got I4
		ps.Simulate(MyTime.deltaTime, withChildren: true, restart: false);
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
		if (!(num2 < 1f))
		{
			if (completeAction != null)
			{
				Action action = completeAction;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v354.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			PoolManager instance2 = PoolManager.Instance;
			GameObject element = base.gameObject;
			instance2.warningTubePool.Release(element);
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	public void ReleaseToPool()
	{
		PoolManager instance = PoolManager.Instance;
		GameObject element = base.gameObject;
		instance.warningTubePool.Release(element);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}
}
