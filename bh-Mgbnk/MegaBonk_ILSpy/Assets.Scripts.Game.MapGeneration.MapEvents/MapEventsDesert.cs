using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Game.MapGeneration.MapEvents;

public class MapEventsDesert : MapEvents
{
	public bool ENABLE_SANDSTORM = true;

	private int numStorms;

	private List<float> stormTimes;

	private float minDuration;

	private float maxDuration;

	private static bool isActiveStorm;

	private float nextStormTime;

	private float stormOverAtTime;

	private int stormIndex;

	public static float currentStormStartedAtTime;

	private float tumbleweedSpawnInterval;

	private float lastSpawnedTumbleweedTime;

	private float minGapBetweenStorms => maxDuration + 5f;

	public override void Init()
	{
		//IL_004c: Expected I, but got O
		//IL_00e2: Invalid comparison between I4 and F4
		//IL_0106: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_012a: Expected O, but got I4
		//IL_0133: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_01cc: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01e0: Expected O, but got I4
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0260: Expected O, but got I4
		//IL_0298: Expected O, but got I
		//IL_02f1: Expected O, but got I
		//IL_0323: Expected O, but got I4
		isActiveStorm = false;
		if (MapController.isFinalBossStage)
		{
			return;
		}
		EffectManager.Instance.SpawnTornadoes(25);
		System.Random random = MyRandom.random;
		nint num = (nint)random;
		int num2 = random.Next(1, 4);
		numStorms = num2;
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		float stageTime = stageData.stageTimeline.GetStageTime();
		float num3 = maxDuration + 5f;
		float num4 = stageTime - 120f;
		float num5 = (float)numStorms * num3;
		float num6 = num4 - num5;
		if (0f > num6)
		{
			return;
		}
		object obj = numStorms + 1;
		float[] array = new float[obj];
		object obj2 = 0;
		object obj3 = 0;
		object obj4 = 0;
		while ((nint)obj4 < array.Length)
		{
			float value = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300CD0");
			stageTime = value ^ -0f;
			array[obj2] = stageTime;
			object obj5 = 0 + 1;
			obj3 += array[obj2];
			obj4 = obj5;
		}
		float[] array2 = new float[array.Length];
		object obj6 = 0;
		object obj7 = 0;
		while ((nint)obj6 < array2.Length)
		{
			object obj8 = 0 + 1;
			object obj9 = array[obj7] / obj3;
			float num7 = (float)obj9 * num6;
			array2[obj7] = num7;
			obj6 = obj8;
		}
		if (numStorms > 0)
		{
			float num8 = array2[0];
			object obj10 = 0;
			object obj13;
			do
			{
				List<float> list = stormTimes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v29 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				float item = num8 + 30f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v29 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v29 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r8_v10+18]");
				if (num9 >= 0)
				{
					list.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v29 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj12 = (nint)0 + (nint)1;
				}
				float num10 = num8 + num3;
				obj13 = 0 + 1;
				float num11 = num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v30 (System.Single[])+24+v266 @ rbx_v9*4]");
				num8 = num11 + 0f;
			}
			while ((nint)obj13 < numStorms);
		}
		stormTimes.Sort();
		float num12 = stormTimes.get_Item(0);
		nextStormTime = num12;
	}

	public override void Cleanup()
	{
		isActiveStorm = false;
	}

	public static bool IsActiveStorm()
	{
		return isActiveStorm;
	}

	public override void Tick()
	{
		if (!MapController.isFinalBossStage)
		{
			TickStorms();
			float num = lastSpawnedTumbleweedTime + tumbleweedSpawnInterval;
			if (!(num > MyTime.time))
			{
				lastSpawnedTumbleweedTime = MyTime.time;
				EffectManager.Instance.SpawnTumbleWeeds(1);
			}
		}
	}

	private void TickStorms()
	{
		if (!isActiveStorm && MyTime.stageTimer > nextStormTime)
		{
			isActiveStorm = true;
			float num = UnityEngine.Random.Range(minDuration, maxDuration);
			float num2 = num + MyTime.stageTimer;
			stormOverAtTime = num2;
			currentStormStartedAtTime = MyTime.stageTimer;
			DesertStorm desertStorm = EffectManager.Instance.GetDesertStorm();
			desertStorm.FadeIn();
		}
		else if (isActiveStorm && MyTime.stageTimer > stormOverAtTime)
		{
			isActiveStorm = false;
			List<float> list = stormTimes;
			int num3 = ++stormIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
			float num4 = (((nint)num3 < (nint)0) ? list.get_Item(num3) : 3.4028235E+38f);
			nextStormTime = num4;
			DesertStorm desertStorm2 = EffectManager.Instance.GetDesertStorm();
			desertStorm2.FadeOut();
		}
	}

	private void SpawnTumbleWeeds()
	{
		float num = lastSpawnedTumbleweedTime + tumbleweedSpawnInterval;
		if (!(num > MyTime.time))
		{
			lastSpawnedTumbleweedTime = MyTime.time;
			EffectManager.Instance.SpawnTumbleWeeds(1);
		}
	}

	private void StartStorm()
	{
		isActiveStorm = true;
		float num = UnityEngine.Random.Range(minDuration, maxDuration);
		float num2 = num + MyTime.stageTimer;
		stormOverAtTime = num2;
		currentStormStartedAtTime = MyTime.stageTimer;
		DesertStorm desertStorm = EffectManager.Instance.GetDesertStorm();
		desertStorm.FadeIn();
	}

	private void StopStorm()
	{
		isActiveStorm = false;
		List<float> list = stormTimes;
		int num = ++stormIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
		float num2 = (((nint)num < (nint)0) ? list.get_Item(num) : 3.4028235E+38f);
		nextStormTime = num2;
		DesertStorm desertStorm = EffectManager.Instance.GetDesertStorm();
		desertStorm.FadeOut();
	}

	public MapEventsDesert()
	{
		List<float> list = new List<float>();
		stormTimes = list;
		minDuration = 8f;
		maxDuration = 18f;
		tumbleweedSpawnInterval = 2.2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
