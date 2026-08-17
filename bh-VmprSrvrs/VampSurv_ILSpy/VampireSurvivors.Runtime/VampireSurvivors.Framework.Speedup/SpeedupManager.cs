using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Speedup;

public class SpeedupManager
{
	private static SpeedupManager m_Instance;

	private float m_CurrentSpeedMultiplier = 1f;

	private float m_DefaultSpeedMultiplier = 1f;

	private float m_MaxSpeed = 2f;

	private float m_MinimumSpeed = 1f;

	private bool m_isSpeedupBlocked;

	private const float c_SpeedMultiplierSpeedupStep = 0.5f;

	private Player m_Player;

	public static SpeedupManager Instance
	{
		get
		{
			if (m_Instance == null)
			{
				SpeedupManager speedupManager = new SpeedupManager();
				speedupManager.m_CurrentSpeedMultiplier = 1f;
				speedupManager.m_DefaultSpeedMultiplier = 1f;
				speedupManager.m_MaxSpeed = 2f;
				speedupManager.m_MinimumSpeed = 1f;
				m_Instance = speedupManager;
			}
			return m_Instance;
		}
	}

	public float CurrentSpeedMultiplier => m_CurrentSpeedMultiplier;

	public bool IsSpeedupBlocked => m_isSpeedupBlocked;

	public void Setup()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		ReInput.PlayerHelper players = ReInput.players;
		Player player = players.GetPlayer(0);
		m_Player = player;
		if (m_Player != null)
		{
			SetSpeedup(1f);
			if (m_Player != null)
			{
				Action<InputActionEventData> action = null;
				((SpeedupManager)(object)action).ToggleSpeedup((InputActionEventData)this);
				int actionId = default(int);
				object[] arguments = default(object[]);
				m_Player.AddInputEventDelegate(action, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, actionId, arguments);
			}
		}
	}

	private void SetupInputDelegates()
	{
		if (m_Player != null)
		{
			Action<InputActionEventData> action = null;
			((SpeedupManager)(object)action).ToggleSpeedup((InputActionEventData)this);
			int actionId = default(int);
			object[] arguments = default(object[]);
			m_Player.AddInputEventDelegate(action, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, actionId, arguments);
		}
	}

	private void RemoveInputDelegates()
	{
		if (m_Player != null)
		{
			Action<InputActionEventData> action = null;
			((SpeedupManager)(object)action).ToggleSpeedup((InputActionEventData)this);
			int actionId = default(int);
			m_Player.RemoveInputEventDelegate(action, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, actionId);
		}
	}

	public float GetCurrentSpeedUpMultiplier()
	{
		return m_CurrentSpeedMultiplier;
	}

	public void ToggleSpeedup(InputActionEventData _)
	{
		if (m_Player != null && m_Player.GetButton(26))
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj == -1)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			if (!(1f < m_CurrentSpeedMultiplier) || (2f > m_CurrentSpeedMultiplier && !(m_CurrentSpeedMultiplier < 1.5f)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 288 Invalid \"Jump target not found in method: 0x186B27860\"");
				throw new NullReferenceException();
			}
			if (!(m_CurrentSpeedMultiplier < 2f))
			{
				SetSpeedup(1f);
			}
		}
	}

	public void IncreaseSpeedup()
	{
		Debug.Log("<SpeedupManager.IncreaseSpeedup>");
		float speedup = m_CurrentSpeedMultiplier + 0.5f;
		SetSpeedup(speedup);
	}

	public void IncreaseSpeedup(float increaseBy = 0.5f)
	{
		Debug.Log("<SpeedupManager.IncreaseSpeedup>");
		float speedup = increaseBy + m_CurrentSpeedMultiplier;
		SetSpeedup(speedup);
	}

	public void ReduceSpeedup()
	{
		Debug.Log("<SpeedupManager.ReduceSpeedup>");
		float speedup = m_CurrentSpeedMultiplier - 0.5f;
		SetSpeedup(speedup);
	}

	public void ReduceSpeedup(float reduceBy = 0.5f)
	{
		Debug.Log("<SpeedupManager.ReduceSpeedup>");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 50 Invalid \"Jump target not found in method: 0x186B27A80\"");
	}

	public unsafe void SetSpeedup(float speed)
	{
		//IL_0201: Expected O, but got I
		//IL_023e: Expected Ref, but got F4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (!stageData._003CisSpeedupBanned_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj = default(object);
			if (obj == null)
			{
				GameManager core3 = GM.Core;
				bool isOnlineMultiplayer = core3._multiplayer.IsOnlineMultiplayer;
				if (!isOnlineMultiplayer)
				{
					if (m_isSpeedupBlocked != isOnlineMultiplayer)
					{
						return;
					}
					bool flag = speed == m_CurrentSpeedMultiplier;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B27BEAh\"");
					if (flag)
					{
						return;
					}
					float currentSpeedMultiplier;
					if (!(speed > m_MaxSpeed))
					{
						if (!(m_MinimumSpeed > speed))
						{
							m_CurrentSpeedMultiplier = speed;
							goto IL_021d;
						}
						currentSpeedMultiplier = m_MinimumSpeed;
					}
					else
					{
						currentSpeedMultiplier = m_MaxSpeed;
					}
					m_CurrentSpeedMultiplier = currentSpeedMultiplier;
					goto IL_021d;
				}
			}
		}
		Debug.Log("<SpeedupManage.SetSpeedup> Speedup is Banned");
		bool flag2 = m_CurrentSpeedMultiplier == m_DefaultSpeedMultiplier;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B27CB1h\"");
		if (flag2)
		{
			return;
		}
		float defaultSpeedMultiplier = m_DefaultSpeedMultiplier;
		m_CurrentSpeedMultiplier = m_DefaultSpeedMultiplier;
		object obj2 = 0;
		object obj3 = "<SpeedupManage.SetSpeedup> Speedup is Banned";
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v285 @ rax_v15 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
		IL_021d:
		Time.timeScale = m_CurrentSpeedMultiplier;
		float num = (float)this + 16f;
		string text = ((float*)num)->ToString();
		float num2 = default(float);
		string text2 = num2.ToString();
		string message = "<SpeedupManager.SetSpeed> Set speed to: " + text + " Requested speed : " + text2;
		Debug.Log(message);
	}

	public unsafe void SetSpeedupDebug(float speed)
	{
		//IL_0051: Expected F4, but got O
		//IL_0067: Expected Ref, but got F4
		bool flag = m_CurrentSpeedMultiplier == speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B27D5Fh\"");
		if (!flag)
		{
			m_CurrentSpeedMultiplier = speed;
			Time.timeScale = (float)this;
			float num = (float)this + 16f;
			string text = ((float*)num)->ToString();
			string message = "<SpeedupManager.SetSpeedDebug> Set speed to: " + text;
			Debug.Log(message);
		}
	}

	public void SetSpeedupBlocked(bool isBlocked)
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer || isBlocked)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag = !isBlocked;
			string text = "False";
			if (!flag)
			{
				text = "True";
			}
			string message = "<SpeedupManager.SetSpeedupBlocked> isBlocked : " + text;
			Debug.Log(message);
			if (isBlocked != m_isSpeedupBlocked)
			{
				float timeScale = (isBlocked ? m_DefaultSpeedMultiplier : m_CurrentSpeedMultiplier);
				Time.timeScale = timeScale;
				m_isSpeedupBlocked = isBlocked;
			}
		}
	}

	public static void ClearSpeedupManager()
	{
		//IL_0075: Expected O, but got I
		Debug.Log("<SpeedupManager.ClearSpeedupManager>");
		if (m_Instance != null)
		{
			InputActionEventData instance = (InputActionEventData)m_Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rsi_v2 (Rewired.InputActionEventData)+28]");
			if ((nint)0 != 0)
			{
				Action<InputActionEventData> action = null;
				((SpeedupManager)(object)action).ToggleSpeedup(instance);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rsi_v2 (Rewired.InputActionEventData)+28]");
				int actionId = default(int);
				((Player)0).RemoveInputEventDelegate(action, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, actionId);
			}
			m_Instance = null;
		}
	}
}
