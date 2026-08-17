using System;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;

public class ChallengeModifierLava : ChallengeModifier
{
	private GameObject lavaObject;

	private Vector3 topPosition;

	private Vector3 lowPosition;

	private float riseTime = 30f;

	private float stayTop = 15f;

	private float lowerTime = 15f;

	private float stayBottom = 20f;

	private float cycleDuration;

	private float startDelay = 10f;

	private float startTime;

	public override void Init(ChallengeData challengeData)
	{
		//IL_0124: Expected I, but got O
		Action b = OnGenerationComplete;
		Delegate obj = Delegate.Combine(MapGenerationController.A_GenerationComplete, b);
		if ((object)obj == null)
		{
			MapGenerationController.A_GenerationComplete = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_0124: Expected I, but got O
		Action value = OnGenerationComplete;
		Delegate obj = Delegate.Remove(MapGenerationController.A_GenerationComplete, value);
		if ((object)obj == null)
		{
			MapGenerationController.A_GenerationComplete = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void OnGenerationComplete()
	{
		//IL_0057: Expected O, but got Ref
		//IL_0057: Expected O, but got Ref
		//IL_00e8: Expected O, but got I
		//IL_013b: Expected I, but got O
		//IL_01c9: Expected I, but got O
		EffectManager instance = EffectManager.Instance;
		EffectManager instance2 = EffectManager.Instance;
		Transform transform = instance2.floorIsLava.transform;
		Quaternion rotation = transform.rotation;
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(instance.floorIsLava, (Vector3)(&obj), (Quaternion)(&obj2));
		lavaObject = gameObject;
		Water component = lavaObject.GetComponent<Water>();
		component.SetFloorIsLava();
		MapGenerationController mapGenerationController = UnityEngine.Object.FindAnyObjectByType<MapGenerationController>();
		MapGenerator proceduralMapMeshGenerator = mapGenerationController.proceduralMapMeshGenerator;
		MapDisplay mapDisplay = proceduralMapMeshGenerator._003Cdisplay_003Ek__BackingField;
		Bounds bounds = mapDisplay.meshCollider.bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v21 (UnityEngine.Bounds)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v21 (UnityEngine.Bounds)+10]");
		object obj3 = num + 0;
		MapGenerator proceduralMapMeshGenerator2 = mapGenerationController.proceduralMapMeshGenerator;
		MapDisplay mapDisplay2 = proceduralMapMeshGenerator2._003Cdisplay_003Ek__BackingField;
		Bounds bounds2 = mapDisplay2.meshCollider.bounds;
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v26 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		float num4 = (float)obj3 * 0.5f;
		float num5 = num4 + 5f;
		float num6 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
		float num7 = num6 * 0f;
		float num8 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rax_v24 (UnityEngine.Bounds)+8]");
		float num9 = num8 + 0f;
		Vector3 vector = default(Vector3);
		lowPosition = vector;
		nint num10 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v28 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num11 = 0;
		float num12 = (float)obj3 * 0.375f;
		float num13 = num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rcx_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num14 = num13 * 0f;
		float num15 = num14;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rax_v24 (UnityEngine.Bounds)+8]");
		float num16 = num15 + 0f;
		float num17 = stayTop + riseTime;
		topPosition = vector;
		float num18 = num17 + lowerTime;
		float num19 = num18 + stayBottom;
		cycleDuration = num19;
		float time = Time.time;
		float num20 = time + startDelay;
		startTime = num20;
	}

	public unsafe override void Tick()
	{
		//IL_0271: Expected F4, but got O
		//IL_03f2: Expected O, but got Ref
		//IL_0296: Invalid comparison between F4 and I4
		//IL_018e: Invalid comparison between I4 and F4
		//IL_0058: Expected F4, but got I4
		//IL_01d9: Expected F4, but got I4
		//IL_01f6: Invalid comparison between I4 and F4
		//IL_0241: Expected F4, but got I4
		//IL_0116: Invalid comparison between I4 and F4
		//IL_0161: Expected F4, but got I4
		//IL_00d5: Expected F4, but got I4
		if (!(lavaObject != null))
		{
			return;
		}
		float time = Time.time;
		Transform transform;
		float num;
		if (startTime > time)
		{
			transform = lavaObject.transform;
			num = (float)lowPosition;
			goto IL_03e5;
		}
		float num2 = MyTime.stageTimer - 5f;
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FFEE0");
		float num15;
		float num16;
		float num17;
		if (!(riseTime > num2))
		{
			float num3 = stayTop + riseTime;
			if (!(num3 > num2))
			{
				float num4 = stayTop + riseTime;
				float num5 = num4 + lowerTime;
				if (num5 > num2)
				{
					float num6 = stayTop + riseTime;
					float num7 = num2 - num6;
					float num8 = num7 / lowerTime;
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
					float num9 = num8 * -2f;
					float num10 = num8 * 3f;
					float num11 = num9 * num8;
					float num12 = num10 * num8;
					float num13 = num11 * num8;
					float num14 = num13 + num12;
					num15 = 1f - num14;
					num16 = num14 * 0f;
					goto IL_041f;
				}
				num17 = 0f;
			}
			else
			{
				num17 = 1f;
			}
			goto IL_01de;
		}
		float num18 = num2 / riseTime;
		if (!(0f > num18))
		{
			if (num18 > 1f)
			{
				num18 = 1f;
			}
		}
		else
		{
			num18 = 0f;
		}
		float num19 = num18 * -2f;
		float num20 = num18 * 3f;
		float num21 = num19 * num18;
		float num22 = num20 * num18;
		float num23 = num21 * num18;
		num16 = num23 + num22;
		float num24 = 1f - num16;
		num15 = num24 * 0f;
		goto IL_041f;
		IL_03e5:
		transform.position = (Vector3)(&num);
		return;
		IL_041f:
		num17 = num15 + num16;
		goto IL_01de;
		IL_01de:
		transform = lavaObject.transform;
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
		object obj = topPosition - lowPosition;
		float num25 = (float)obj * num17;
		float num26 = num25 + (float)lowPosition;
		num = num26;
		goto IL_03e5;
	}
}
