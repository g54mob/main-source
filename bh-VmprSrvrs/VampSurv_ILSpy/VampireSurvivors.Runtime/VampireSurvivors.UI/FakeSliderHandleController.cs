using System;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class FakeSliderHandleController : Selectable
{
	private float _Speed;

	private Slider _Slider;

	public Selectable _OnUp;

	public Selectable _OnDown;

	private Rewired.Player _player;

	protected override void Start()
	{
	}

	private void Update()
	{
		//IL_0230: Expected O, but got I4
		//IL_024a: Expected O, but got I4
		//IL_0194: Invalid comparison between F4 and I4
		//IL_01d3: Invalid comparison between I4 and F4
		int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
		Rewired.Player player;
		if (playerCount <= 1 && !MultiplayerManager.s_instance.IsOnlineMultiplayer)
		{
			ReInput.PlayerHelper players = ReInput.players;
			player = players.GetPlayer(0);
		}
		else
		{
			player = MultiplayerManager.s_instance.GetCurrentUIPlayer();
		}
		_player = player;
		EventSystem current = EventSystem.current;
		GameObject currentSelected = current.m_CurrentSelected;
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = (object)current.m_CurrentSelected == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)gameObject != null)
			{
				if ((object)current.m_CurrentSelected != null)
				{
					object obj3 = (object)current.m_CurrentSelected - (object)gameObject;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		float axis = _player.GetAxis("UIVertical");
		if (axis > 0f)
		{
			DoUp();
		}
		float axis2 = _player.GetAxis("UIVertical");
		if (0f > axis2)
		{
			DoDown();
		}
	}

	private void DoDown()
	{
		//IL_009e: Expected O, but got F4
		//IL_0031: Invalid comparison between I4 and F4
		float value = _Slider.value;
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float num = (float)obj2 * _Speed;
		float value2 = (float)obj2 - num;
		_Slider.value = value2;
		float value3 = _Slider.value;
		if (!(0f < num))
		{
			Selectable onDown = _OnDown;
			if ((object)_OnDown != null && ((UnityEngine.Object)onDown).m_CachedPtr != (IntPtr)0)
			{
				_OnDown.Select();
			}
		}
	}

	private void DoUp()
	{
		//IL_009e: Expected O, but got F4
		float value = _Slider.value;
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float num = (float)obj2 * _Speed;
		float num2 = num + (float)obj2;
		_Slider.value = num2;
		float value2 = _Slider.value;
		if (!(num2 < 1f))
		{
			Selectable onUp = _OnUp;
			if ((object)_OnUp != null && ((UnityEngine.Object)onUp).m_CachedPtr != (IntPtr)0)
			{
				_OnUp.Select();
			}
		}
	}
}
