using System;
using System.Reflection;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class MapZoomController : MonoBehaviour
{
	private float ZoomInterval;

	private AdvancedUIButtonEvents _ZoomInButton;

	private AdvancedUIButtonEvents _ZoomOutButton;

	private MapManager _mapManager;

	private Rewired.Player _player;

	private MultiplayerManager _multiplayer;

	private bool _ZoomingIn;

	private bool _isZooming;

	private float _timeToNextZoom;

	private void Awake()
	{
		AdvancedUIButtonEvents zoomInButton = _ZoomInButton;
		UnityAction call = ZoomInPressed;
		zoomInButton.OnPressed.AddListener(call);
		AdvancedUIButtonEvents zoomInButton2 = _ZoomInButton;
		UnityAction call2 = ZoomInUnpressed;
		zoomInButton2.OnUnpressed.AddListener(call2);
		AdvancedUIButtonEvents zoomOutButton = _ZoomOutButton;
		UnityAction call3 = ZoomOutPressed;
		zoomOutButton.OnPressed.AddListener(call3);
		AdvancedUIButtonEvents zoomOutButton2 = _ZoomOutButton;
		UnityAction call4 = ZoomOutUnpressed;
		zoomOutButton2.OnUnpressed.AddListener(call4);
		ReInput.PlayerHelper players = ReInput.players;
		Rewired.Player systemPlayer = players.SystemPlayer;
		_player = systemPlayer;
	}

	private void OnDestroy()
	{
		AdvancedUIButtonEvents zoomInButton = _ZoomInButton;
		UnityEvent onPressed = zoomInButton.OnPressed;
		UnityAction unityAction = ZoomInPressed;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		((UnityEventBase)onPressed).m_Calls.RemoveListener(((Delegate)unityAction).m_target, methodImpl);
		AdvancedUIButtonEvents zoomInButton2 = _ZoomInButton;
		UnityEvent onUnpressed = zoomInButton2.OnUnpressed;
		UnityAction unityAction2 = ZoomInUnpressed;
		MethodInfo methodImpl2 = ((MulticastDelegate)unityAction2).GetMethodImpl();
		((UnityEventBase)onUnpressed).m_Calls.RemoveListener(((Delegate)unityAction2).m_target, methodImpl2);
		AdvancedUIButtonEvents zoomOutButton = _ZoomOutButton;
		UnityEvent onPressed2 = zoomOutButton.OnPressed;
		UnityAction unityAction3 = ZoomOutPressed;
		MethodInfo methodImpl3 = ((MulticastDelegate)unityAction3).GetMethodImpl();
		((UnityEventBase)onPressed2).m_Calls.RemoveListener(((Delegate)unityAction3).m_target, methodImpl3);
		AdvancedUIButtonEvents zoomOutButton2 = _ZoomOutButton;
		UnityEvent onUnpressed2 = zoomOutButton2.OnUnpressed;
		UnityAction unityAction4 = ZoomOutUnpressed;
		MethodInfo methodImpl4 = ((MulticastDelegate)unityAction4).GetMethodImpl();
		((UnityEventBase)onUnpressed2).m_Calls.RemoveListener(((Delegate)unityAction4).m_target, methodImpl4);
	}

	private void Construct(MultiplayerManager _mult)
	{
		_multiplayer = _mult;
	}

	private void Update()
	{
		//IL_0089: Invalid comparison between I4 and F4
		//IL_0098: Expected F4, but got I4
		//IL_0432: Expected O, but got F4
		//IL_0444: Expected O, but got F4
		//IL_0469: Invalid comparison between F4 and I4
		//IL_0478: Invalid comparison between F4 and I4
		//IL_04f0: Expected O, but got I4
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected O, but got Unknown
		//IL_0514: Expected O, but got F4
		//IL_0275: Expected O, but got F4
		//IL_0287: Expected O, but got F4
		//IL_02ac: Invalid comparison between F4 and I4
		//IL_02bb: Invalid comparison between F4 and I4
		//IL_037d: Expected O, but got F4
		//IL_038a: Expected O, but got F4
		//IL_03af: Invalid comparison between F4 and I4
		//IL_03be: Invalid comparison between F4 and I4
		//IL_04a1: Expected O, but got I4
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected O, but got Unknown
		//IL_0126: Expected O, but got F4
		//IL_0133: Expected O, but got F4
		//IL_0158: Invalid comparison between F4 and I4
		//IL_0167: Invalid comparison between F4 and I4
		int playerCount = _multiplayer.GetPlayerCount();
		MultiplayerManager multiplayerManager;
		if (playerCount > 1)
		{
			multiplayerManager = _multiplayer;
		}
		else
		{
			bool isOnlineMultiplayer = _multiplayer.IsOnlineMultiplayer;
			multiplayerManager = _multiplayer;
			if (!isOnlineMultiplayer)
			{
				int playerCount2 = _multiplayer.GetPlayerCount();
				if (playerCount2 != 1)
				{
					ReInput.PlayerHelper players = ReInput.players;
					Rewired.Player systemPlayer = players.SystemPlayer;
					_player = systemPlayer;
					multiplayerManager = (MultiplayerManager)(object)players;
				}
				else
				{
					multiplayerManager = _multiplayer;
					Rewired.Player rewiredPlayerOne = _multiplayer.GetRewiredPlayerOne();
					_player = rewiredPlayerOne;
				}
				goto IL_005f;
			}
		}
		Rewired.Player selectedPlayer = multiplayerManager.GetSelectedPlayer();
		_player = selectedPlayer;
		goto IL_005f;
		IL_005f:
		if (_isZooming)
		{
			bool flag = 0f < _timeToNextZoom;
			float num = 0f;
			MapManager mapManager = (MapManager)(object)multiplayerManager;
			if (!flag)
			{
				mapManager = _mapManager;
				float num2;
				bool flag2;
				bool flag3;
				bool flag4;
				if (!_ZoomingIn)
				{
					num2 = mapManager._manualZoomStep + mapManager._manualZoomFactor;
					num = mapManager._manualZoomOutCap;
					float num3 = num2 - mapManager._manualZoomOutCap;
					object obj = num2 ^ mapManager._manualZoomOutCap;
					object obj2 = num2 ^ num3;
					object obj3 = obj & obj2;
					flag2 = (nint)obj3 < 0;
					flag3 = num3 < 0f;
					flag4 = num3 == 0f;
				}
				else
				{
					num2 = mapManager._manualZoomFactor - mapManager._manualZoomStep;
					num = mapManager._manualZoomInCap;
					float num4 = mapManager._manualZoomInCap - num2;
					object obj4 = mapManager._manualZoomInCap ^ num2;
					object obj5 = mapManager._manualZoomInCap ^ num4;
					object obj6 = obj4 & obj5;
					flag2 = (nint)obj6 < 0;
					flag3 = num4 < 0f;
					flag4 = num4 == 0f;
				}
				bool flag5 = flag3 == flag2;
				object obj7 = !flag4;
				object obj8 = flag5 & obj7;
				if (obj8 == null)
				{
					num = num2;
				}
				mapManager._manualZoomFactor = num;
				mapManager.Populate();
				_timeToNextZoom = ZoomInterval;
			}
			object obj9 = Time.deltaTime;
			float timeToNextZoom = _timeToNextZoom - num;
			_timeToNextZoom = timeToNextZoom;
		}
		MapManager mapManager2;
		float num5;
		float manualZoomFactor;
		bool flag6;
		bool flag7;
		bool flag8;
		if (!_player.GetButtonDown(21))
		{
			if (!_player.GetButtonDown(22))
			{
				return;
			}
			mapManager2 = _mapManager;
			num5 = mapManager2._manualZoomStep + mapManager2._manualZoomFactor;
			manualZoomFactor = mapManager2._manualZoomOutCap;
			float num6 = num5 - mapManager2._manualZoomOutCap;
			object obj10 = num5 ^ mapManager2._manualZoomOutCap;
			object obj11 = num5 ^ num6;
			object obj12 = obj10 & obj11;
			flag6 = (nint)obj12 < 0;
			flag7 = num6 < 0f;
			flag8 = num6 == 0f;
		}
		else
		{
			mapManager2 = _mapManager;
			num5 = mapManager2._manualZoomFactor - mapManager2._manualZoomStep;
			manualZoomFactor = mapManager2._manualZoomInCap;
			float num7 = mapManager2._manualZoomInCap - num5;
			object obj13 = mapManager2._manualZoomInCap ^ num5;
			object obj14 = mapManager2._manualZoomInCap ^ num7;
			object obj15 = obj13 & obj14;
			flag6 = (nint)obj15 < 0;
			flag7 = num7 < 0f;
			flag8 = num7 == 0f;
		}
		bool flag9 = flag7 == flag6;
		object obj16 = !flag8;
		object obj17 = flag9 & obj16;
		if (obj17 == null)
		{
			manualZoomFactor = num5;
		}
		mapManager2._manualZoomFactor = manualZoomFactor;
		mapManager2.Populate();
	}

	private void ZoomInPressed()
	{
		_timeToNextZoom = ZoomInterval;
		_ZoomingIn = true;
		MapManager mapManager = _mapManager;
		float num = mapManager._manualZoomFactor - mapManager._manualZoomStep;
		float manualZoomFactor = mapManager._manualZoomInCap;
		if (mapManager._manualZoomInCap < num)
		{
			manualZoomFactor = num;
		}
		mapManager._manualZoomFactor = manualZoomFactor;
		mapManager.Populate();
	}

	private void ZoomInUnpressed()
	{
		_isZooming = false;
		_timeToNextZoom = 0f;
	}

	private void ZoomOutPressed()
	{
		_timeToNextZoom = ZoomInterval;
		_ZoomingIn = false;
		MapManager mapManager = _mapManager;
		float num = mapManager._manualZoomStep + mapManager._manualZoomFactor;
		float manualZoomFactor = mapManager._manualZoomOutCap;
		if (mapManager._manualZoomOutCap > num)
		{
			manualZoomFactor = num;
		}
		mapManager._manualZoomFactor = manualZoomFactor;
		mapManager.Populate();
	}

	private void ZoomOutUnpressed()
	{
		_isZooming = false;
		_timeToNextZoom = 0f;
	}

	public MapZoomController()
	{
		//IL_0020: Expected I, but got O
		ZoomInterval = 0.1f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
