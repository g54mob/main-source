using System;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Utility;

public static class MyTime
{
	public static bool paused;

	public static float time;

	public static float deltaTime;

	public static float fixedDeltaTime;

	private static float _003CtimeScale_003Ek__BackingField = 1f;

	public static int tick;

	public static int unpauseTick;

	public static float stageTimer;

	public static float runTimer;

	public static float finalSwarmTimer;

	public static float difficultyTimer;

	public static float cryptTimer;

	public static Action<bool> A_Pause;

	public static Action A_Tick;

	public static Action A_TimeScaleChange;

	private static float timescaleTimeRemaining;

	public static float timeScale
	{
		get
		{
			return _003CtimeScale_003Ek__BackingField;
		}
		private set
		{
			_003CtimeScale_003Ek__BackingField = value;
		}
	}

	public static void Init()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_0217: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_0253: Expected O, but got I4
		//IL_0269: Expected I, but got O
		//IL_0294: Expected I, but got O
		//IL_029d: Expected O, but got I4
		Action b = OnNewStageStarted;
		Delegate obj = Delegate.Combine(GameManager.A_StageStarted, b);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02ce;
			}
			GameManager.A_StageStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b3;
			}
		}
		Action b2 = OnNewRunStarted;
		Delegate obj6 = Delegate.Combine(GameManager.A_RunStarted, b2);
		if ((object)obj6 == null)
		{
			GameManager.A_RunStarted = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02be;
		}
		GameManager.A_RunStarted = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02ce;
		IL_02b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02be:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b3;
		IL_02ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02be;
	}

	public static void Cleanup()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_0217: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_0253: Expected O, but got I4
		//IL_0269: Expected I, but got O
		//IL_0294: Expected I, but got O
		//IL_029d: Expected O, but got I4
		Action value = OnNewStageStarted;
		Delegate obj = Delegate.Remove(GameManager.A_StageStarted, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02ce;
			}
			GameManager.A_StageStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b3;
			}
		}
		Action value2 = OnNewRunStarted;
		Delegate obj6 = Delegate.Remove(GameManager.A_RunStarted, value2);
		if ((object)obj6 == null)
		{
			GameManager.A_RunStarted = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02be;
		}
		GameManager.A_RunStarted = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02ce;
		IL_02b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02be:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b3;
		IL_02ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02be;
	}

	private static void OnNewRunStarted()
	{
		Unpause();
		stageTimer = 0f;
		runTimer = 0f;
		difficultyTimer = 0f;
		_003CtimeScale_003Ek__BackingField = 1f;
	}

	private static void OnNewStageStarted()
	{
		if (!MapController.IsFirstStage())
		{
			double num = Math.Floor(runTimer);
			runTimer = (float)num;
		}
		else
		{
			runTimer = 0f;
			difficultyTimer = 0f;
		}
		Unpause();
		stageTimer = 0f;
		finalSwarmTimer = 0f;
		tick = 0;
		unpauseTick = 0;
		_003CtimeScale_003Ek__BackingField = 1f;
		timescaleTimeRemaining = 0f;
	}

	public static void Update()
	{
		//IL_02d9: Invalid comparison between F4 and I4
		//IL_0286: Invalid comparison between I4 and F4
		if (!paused)
		{
			float num = Time.deltaTime;
			float num2 = num * _003CtimeScale_003Ek__BackingField;
			deltaTime = num2;
		}
		else
		{
			deltaTime = 0f;
		}
		float num3 = deltaTime + time;
		time = num3;
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			if (instance.isPlaying)
			{
				if (instance._003CisCrypt_003Ek__BackingField)
				{
					if (instance._003CisDungeonTimerStarted_003Ek__BackingField)
					{
						float num4 = cryptTimer + deltaTime;
						cryptTimer = num4;
					}
				}
				else
				{
					float num5 = stageTimer + deltaTime;
					stageTimer = num5;
				}
				float num6 = runTimer + deltaTime;
				runTimer = num6;
				if (GameManager.Instance.IsFinalSwarm())
				{
					float num7 = finalSwarmTimer + deltaTime;
					finalSwarmTimer = num7;
				}
				if (!MapController.isFinalBossStage)
				{
					float num8 = difficultyTimer + deltaTime;
					difficultyTimer = num8;
				}
			}
		}
		if (!(timescaleTimeRemaining > 0f) || paused)
		{
			return;
		}
		float num9 = Time.deltaTime;
		float num10 = timescaleTimeRemaining - num9;
		timescaleTimeRemaining = num10;
		if (!(0f < timescaleTimeRemaining))
		{
			_003CtimeScale_003Ek__BackingField = 1f;
			Action a_TimeScaleChange = A_TimeScaleChange;
			if (A_TimeScaleChange != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v372.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public static void FixedUpdate()
	{
		if (!paused)
		{
			float num = Time.fixedDeltaTime;
			float num2 = num * _003CtimeScale_003Ek__BackingField;
			fixedDeltaTime = num2;
			int num3 = tick + 1;
			tick = num3;
			Action a_Tick = A_Tick;
			if (A_Tick != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v108.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		else
		{
			fixedDeltaTime = 0f;
		}
	}

	public static void SetTimeScale(float newTimeScale, float duration)
	{
		_003CtimeScale_003Ek__BackingField = newTimeScale;
		timescaleTimeRemaining = duration;
		Action a_TimeScaleChange = A_TimeScaleChange;
		if (A_TimeScaleChange != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v79.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static void ResetTimeScale()
	{
		_003CtimeScale_003Ek__BackingField = 1f;
		Action a_TimeScaleChange = A_TimeScaleChange;
		if (A_TimeScaleChange != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v71.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public static void Pause()
	{
		paused = true;
		Physics.simulationMode = SimulationMode.Script;
		Action<bool> a_Pause = A_Pause;
		if (A_Pause != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rax_v8 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	public static void Unpause()
	{
		paused = false;
		Physics.simulationMode = SimulationMode.FixedUpdate;
		Action<bool> a_Pause = A_Pause;
		if (A_Pause != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ r9_v1 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
		unpauseTick = tick;
	}

	public static void StartCryptBoss()
	{
		stageTimer = 0f;
	}
}
