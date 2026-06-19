using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AggroInput : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct GameActions
	{
		private AggroInput m_Wrapper;

		public InputAction GrabRelease => m_Wrapper.m_Game_GrabRelease;

		public InputAction RaiseLower => m_Wrapper.m_Game_RaiseLower;

		public InputAction Steering => m_Wrapper.m_Game_Steering;

		public InputAction Gas => m_Wrapper.m_Game_Gas;

		public InputAction Brake => m_Wrapper.m_Game_Brake;

		public InputAction Boost => m_Wrapper.m_Game_Boost;

		public InputAction ToggleSteeringStyle => m_Wrapper.m_Game_ToggleSteeringStyle;

		public InputAction StationPlace => m_Wrapper.m_Game_StationPlace;

		public InputAction Drift => m_Wrapper.m_Game_Drift;

		public InputAction Beep => m_Wrapper.m_Game_Beep;

		public InputAction DMenuLeft => m_Wrapper.m_Game_DMenuLeft;

		public InputAction DMenuRight => m_Wrapper.m_Game_DMenuRight;

		public InputAction OpenGameMenu => m_Wrapper.m_Game_OpenGameMenu;

		public InputAction UseBox => m_Wrapper.m_Game_UseBox;

		public InputAction TapTapMouseAxis => m_Wrapper.m_Game_TapTapMouseAxis;

		public InputAction ToggleTipTap => m_Wrapper.m_Game_ToggleTipTap;

		public InputAction SwipeUpTipTap => m_Wrapper.m_Game_SwipeUpTipTap;

		public InputAction SwipeDownTipTap => m_Wrapper.m_Game_SwipeDownTipTap;

		public InputAction SwipeRightTipTap => m_Wrapper.m_Game_SwipeRightTipTap;

		public InputAction SwipeLeftTipTap => m_Wrapper.m_Game_SwipeLeftTipTap;

		public InputAction StationRotateClockwise => m_Wrapper.m_Game_StationRotateClockwise;

		public InputAction StationRotateCounterClockwise => m_Wrapper.m_Game_StationRotateCounterClockwise;

		public bool enabled => Get().enabled;

		public GameActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Game;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(GameActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IGameActions instance)
		{
			if (instance != null && !m_Wrapper.m_GameActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_GameActionsCallbackInterfaces.Add(instance);
				GrabRelease.started += instance.OnGrabRelease;
				GrabRelease.performed += instance.OnGrabRelease;
				GrabRelease.canceled += instance.OnGrabRelease;
				RaiseLower.started += instance.OnRaiseLower;
				RaiseLower.performed += instance.OnRaiseLower;
				RaiseLower.canceled += instance.OnRaiseLower;
				Steering.started += instance.OnSteering;
				Steering.performed += instance.OnSteering;
				Steering.canceled += instance.OnSteering;
				Gas.started += instance.OnGas;
				Gas.performed += instance.OnGas;
				Gas.canceled += instance.OnGas;
				Brake.started += instance.OnBrake;
				Brake.performed += instance.OnBrake;
				Brake.canceled += instance.OnBrake;
				Boost.started += instance.OnBoost;
				Boost.performed += instance.OnBoost;
				Boost.canceled += instance.OnBoost;
				ToggleSteeringStyle.started += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.performed += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.canceled += instance.OnToggleSteeringStyle;
				StationPlace.started += instance.OnStationPlace;
				StationPlace.performed += instance.OnStationPlace;
				StationPlace.canceled += instance.OnStationPlace;
				Drift.started += instance.OnDrift;
				Drift.performed += instance.OnDrift;
				Drift.canceled += instance.OnDrift;
				Beep.started += instance.OnBeep;
				Beep.performed += instance.OnBeep;
				Beep.canceled += instance.OnBeep;
				DMenuLeft.started += instance.OnDMenuLeft;
				DMenuLeft.performed += instance.OnDMenuLeft;
				DMenuLeft.canceled += instance.OnDMenuLeft;
				DMenuRight.started += instance.OnDMenuRight;
				DMenuRight.performed += instance.OnDMenuRight;
				DMenuRight.canceled += instance.OnDMenuRight;
				OpenGameMenu.started += instance.OnOpenGameMenu;
				OpenGameMenu.performed += instance.OnOpenGameMenu;
				OpenGameMenu.canceled += instance.OnOpenGameMenu;
				UseBox.started += instance.OnUseBox;
				UseBox.performed += instance.OnUseBox;
				UseBox.canceled += instance.OnUseBox;
				TapTapMouseAxis.started += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.performed += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.canceled += instance.OnTapTapMouseAxis;
				ToggleTipTap.started += instance.OnToggleTipTap;
				ToggleTipTap.performed += instance.OnToggleTipTap;
				ToggleTipTap.canceled += instance.OnToggleTipTap;
				SwipeUpTipTap.started += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.performed += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.canceled += instance.OnSwipeUpTipTap;
				SwipeDownTipTap.started += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.performed += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.canceled += instance.OnSwipeDownTipTap;
				SwipeRightTipTap.started += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.performed += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.canceled += instance.OnSwipeRightTipTap;
				SwipeLeftTipTap.started += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.performed += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.canceled += instance.OnSwipeLeftTipTap;
				StationRotateClockwise.started += instance.OnStationRotateClockwise;
				StationRotateClockwise.performed += instance.OnStationRotateClockwise;
				StationRotateClockwise.canceled += instance.OnStationRotateClockwise;
				StationRotateCounterClockwise.started += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.performed += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.canceled += instance.OnStationRotateCounterClockwise;
			}
		}

		private void UnregisterCallbacks(IGameActions instance)
		{
			GrabRelease.started -= instance.OnGrabRelease;
			GrabRelease.performed -= instance.OnGrabRelease;
			GrabRelease.canceled -= instance.OnGrabRelease;
			RaiseLower.started -= instance.OnRaiseLower;
			RaiseLower.performed -= instance.OnRaiseLower;
			RaiseLower.canceled -= instance.OnRaiseLower;
			Steering.started -= instance.OnSteering;
			Steering.performed -= instance.OnSteering;
			Steering.canceled -= instance.OnSteering;
			Gas.started -= instance.OnGas;
			Gas.performed -= instance.OnGas;
			Gas.canceled -= instance.OnGas;
			Brake.started -= instance.OnBrake;
			Brake.performed -= instance.OnBrake;
			Brake.canceled -= instance.OnBrake;
			Boost.started -= instance.OnBoost;
			Boost.performed -= instance.OnBoost;
			Boost.canceled -= instance.OnBoost;
			ToggleSteeringStyle.started -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.performed -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.canceled -= instance.OnToggleSteeringStyle;
			StationPlace.started -= instance.OnStationPlace;
			StationPlace.performed -= instance.OnStationPlace;
			StationPlace.canceled -= instance.OnStationPlace;
			Drift.started -= instance.OnDrift;
			Drift.performed -= instance.OnDrift;
			Drift.canceled -= instance.OnDrift;
			Beep.started -= instance.OnBeep;
			Beep.performed -= instance.OnBeep;
			Beep.canceled -= instance.OnBeep;
			DMenuLeft.started -= instance.OnDMenuLeft;
			DMenuLeft.performed -= instance.OnDMenuLeft;
			DMenuLeft.canceled -= instance.OnDMenuLeft;
			DMenuRight.started -= instance.OnDMenuRight;
			DMenuRight.performed -= instance.OnDMenuRight;
			DMenuRight.canceled -= instance.OnDMenuRight;
			OpenGameMenu.started -= instance.OnOpenGameMenu;
			OpenGameMenu.performed -= instance.OnOpenGameMenu;
			OpenGameMenu.canceled -= instance.OnOpenGameMenu;
			UseBox.started -= instance.OnUseBox;
			UseBox.performed -= instance.OnUseBox;
			UseBox.canceled -= instance.OnUseBox;
			TapTapMouseAxis.started -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.performed -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.canceled -= instance.OnTapTapMouseAxis;
			ToggleTipTap.started -= instance.OnToggleTipTap;
			ToggleTipTap.performed -= instance.OnToggleTipTap;
			ToggleTipTap.canceled -= instance.OnToggleTipTap;
			SwipeUpTipTap.started -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.performed -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.canceled -= instance.OnSwipeUpTipTap;
			SwipeDownTipTap.started -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.performed -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.canceled -= instance.OnSwipeDownTipTap;
			SwipeRightTipTap.started -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.performed -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.canceled -= instance.OnSwipeRightTipTap;
			SwipeLeftTipTap.started -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.performed -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.canceled -= instance.OnSwipeLeftTipTap;
			StationRotateClockwise.started -= instance.OnStationRotateClockwise;
			StationRotateClockwise.performed -= instance.OnStationRotateClockwise;
			StationRotateClockwise.canceled -= instance.OnStationRotateClockwise;
			StationRotateCounterClockwise.started -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.performed -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.canceled -= instance.OnStationRotateCounterClockwise;
		}

		public void RemoveCallbacks(IGameActions instance)
		{
			if (m_Wrapper.m_GameActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IGameActions instance)
		{
			foreach (IGameActions gameActionsCallbackInterface in m_Wrapper.m_GameActionsCallbackInterfaces)
			{
				UnregisterCallbacks(gameActionsCallbackInterface);
			}
			m_Wrapper.m_GameActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct Game1Actions
	{
		private AggroInput m_Wrapper;

		public InputAction GrabRelease => m_Wrapper.m_Game1_GrabRelease;

		public InputAction RaiseLower => m_Wrapper.m_Game1_RaiseLower;

		public InputAction Steering => m_Wrapper.m_Game1_Steering;

		public InputAction Gas => m_Wrapper.m_Game1_Gas;

		public InputAction Brake => m_Wrapper.m_Game1_Brake;

		public InputAction Boost => m_Wrapper.m_Game1_Boost;

		public InputAction ToggleSteeringStyle => m_Wrapper.m_Game1_ToggleSteeringStyle;

		public InputAction StationPlace => m_Wrapper.m_Game1_StationPlace;

		public InputAction Drift => m_Wrapper.m_Game1_Drift;

		public InputAction Beep => m_Wrapper.m_Game1_Beep;

		public InputAction DMenuLeft => m_Wrapper.m_Game1_DMenuLeft;

		public InputAction DMenuRight => m_Wrapper.m_Game1_DMenuRight;

		public InputAction OpenGameMenu => m_Wrapper.m_Game1_OpenGameMenu;

		public InputAction UseBox => m_Wrapper.m_Game1_UseBox;

		public InputAction TapTapMouseAxis => m_Wrapper.m_Game1_TapTapMouseAxis;

		public InputAction ToggleTipTap => m_Wrapper.m_Game1_ToggleTipTap;

		public InputAction SwipeUpTipTap => m_Wrapper.m_Game1_SwipeUpTipTap;

		public InputAction SwipeDownTipTap => m_Wrapper.m_Game1_SwipeDownTipTap;

		public InputAction SwipeRightTipTap => m_Wrapper.m_Game1_SwipeRightTipTap;

		public InputAction SwipeLeftTipTap => m_Wrapper.m_Game1_SwipeLeftTipTap;

		public InputAction StationRotateClockwise => m_Wrapper.m_Game1_StationRotateClockwise;

		public InputAction StationRotateCounterClockwise => m_Wrapper.m_Game1_StationRotateCounterClockwise;

		public bool enabled => Get().enabled;

		public Game1Actions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Game1;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(Game1Actions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IGame1Actions instance)
		{
			if (instance != null && !m_Wrapper.m_Game1ActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_Game1ActionsCallbackInterfaces.Add(instance);
				GrabRelease.started += instance.OnGrabRelease;
				GrabRelease.performed += instance.OnGrabRelease;
				GrabRelease.canceled += instance.OnGrabRelease;
				RaiseLower.started += instance.OnRaiseLower;
				RaiseLower.performed += instance.OnRaiseLower;
				RaiseLower.canceled += instance.OnRaiseLower;
				Steering.started += instance.OnSteering;
				Steering.performed += instance.OnSteering;
				Steering.canceled += instance.OnSteering;
				Gas.started += instance.OnGas;
				Gas.performed += instance.OnGas;
				Gas.canceled += instance.OnGas;
				Brake.started += instance.OnBrake;
				Brake.performed += instance.OnBrake;
				Brake.canceled += instance.OnBrake;
				Boost.started += instance.OnBoost;
				Boost.performed += instance.OnBoost;
				Boost.canceled += instance.OnBoost;
				ToggleSteeringStyle.started += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.performed += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.canceled += instance.OnToggleSteeringStyle;
				StationPlace.started += instance.OnStationPlace;
				StationPlace.performed += instance.OnStationPlace;
				StationPlace.canceled += instance.OnStationPlace;
				Drift.started += instance.OnDrift;
				Drift.performed += instance.OnDrift;
				Drift.canceled += instance.OnDrift;
				Beep.started += instance.OnBeep;
				Beep.performed += instance.OnBeep;
				Beep.canceled += instance.OnBeep;
				DMenuLeft.started += instance.OnDMenuLeft;
				DMenuLeft.performed += instance.OnDMenuLeft;
				DMenuLeft.canceled += instance.OnDMenuLeft;
				DMenuRight.started += instance.OnDMenuRight;
				DMenuRight.performed += instance.OnDMenuRight;
				DMenuRight.canceled += instance.OnDMenuRight;
				OpenGameMenu.started += instance.OnOpenGameMenu;
				OpenGameMenu.performed += instance.OnOpenGameMenu;
				OpenGameMenu.canceled += instance.OnOpenGameMenu;
				UseBox.started += instance.OnUseBox;
				UseBox.performed += instance.OnUseBox;
				UseBox.canceled += instance.OnUseBox;
				TapTapMouseAxis.started += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.performed += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.canceled += instance.OnTapTapMouseAxis;
				ToggleTipTap.started += instance.OnToggleTipTap;
				ToggleTipTap.performed += instance.OnToggleTipTap;
				ToggleTipTap.canceled += instance.OnToggleTipTap;
				SwipeUpTipTap.started += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.performed += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.canceled += instance.OnSwipeUpTipTap;
				SwipeDownTipTap.started += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.performed += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.canceled += instance.OnSwipeDownTipTap;
				SwipeRightTipTap.started += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.performed += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.canceled += instance.OnSwipeRightTipTap;
				SwipeLeftTipTap.started += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.performed += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.canceled += instance.OnSwipeLeftTipTap;
				StationRotateClockwise.started += instance.OnStationRotateClockwise;
				StationRotateClockwise.performed += instance.OnStationRotateClockwise;
				StationRotateClockwise.canceled += instance.OnStationRotateClockwise;
				StationRotateCounterClockwise.started += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.performed += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.canceled += instance.OnStationRotateCounterClockwise;
			}
		}

		private void UnregisterCallbacks(IGame1Actions instance)
		{
			GrabRelease.started -= instance.OnGrabRelease;
			GrabRelease.performed -= instance.OnGrabRelease;
			GrabRelease.canceled -= instance.OnGrabRelease;
			RaiseLower.started -= instance.OnRaiseLower;
			RaiseLower.performed -= instance.OnRaiseLower;
			RaiseLower.canceled -= instance.OnRaiseLower;
			Steering.started -= instance.OnSteering;
			Steering.performed -= instance.OnSteering;
			Steering.canceled -= instance.OnSteering;
			Gas.started -= instance.OnGas;
			Gas.performed -= instance.OnGas;
			Gas.canceled -= instance.OnGas;
			Brake.started -= instance.OnBrake;
			Brake.performed -= instance.OnBrake;
			Brake.canceled -= instance.OnBrake;
			Boost.started -= instance.OnBoost;
			Boost.performed -= instance.OnBoost;
			Boost.canceled -= instance.OnBoost;
			ToggleSteeringStyle.started -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.performed -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.canceled -= instance.OnToggleSteeringStyle;
			StationPlace.started -= instance.OnStationPlace;
			StationPlace.performed -= instance.OnStationPlace;
			StationPlace.canceled -= instance.OnStationPlace;
			Drift.started -= instance.OnDrift;
			Drift.performed -= instance.OnDrift;
			Drift.canceled -= instance.OnDrift;
			Beep.started -= instance.OnBeep;
			Beep.performed -= instance.OnBeep;
			Beep.canceled -= instance.OnBeep;
			DMenuLeft.started -= instance.OnDMenuLeft;
			DMenuLeft.performed -= instance.OnDMenuLeft;
			DMenuLeft.canceled -= instance.OnDMenuLeft;
			DMenuRight.started -= instance.OnDMenuRight;
			DMenuRight.performed -= instance.OnDMenuRight;
			DMenuRight.canceled -= instance.OnDMenuRight;
			OpenGameMenu.started -= instance.OnOpenGameMenu;
			OpenGameMenu.performed -= instance.OnOpenGameMenu;
			OpenGameMenu.canceled -= instance.OnOpenGameMenu;
			UseBox.started -= instance.OnUseBox;
			UseBox.performed -= instance.OnUseBox;
			UseBox.canceled -= instance.OnUseBox;
			TapTapMouseAxis.started -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.performed -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.canceled -= instance.OnTapTapMouseAxis;
			ToggleTipTap.started -= instance.OnToggleTipTap;
			ToggleTipTap.performed -= instance.OnToggleTipTap;
			ToggleTipTap.canceled -= instance.OnToggleTipTap;
			SwipeUpTipTap.started -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.performed -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.canceled -= instance.OnSwipeUpTipTap;
			SwipeDownTipTap.started -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.performed -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.canceled -= instance.OnSwipeDownTipTap;
			SwipeRightTipTap.started -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.performed -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.canceled -= instance.OnSwipeRightTipTap;
			SwipeLeftTipTap.started -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.performed -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.canceled -= instance.OnSwipeLeftTipTap;
			StationRotateClockwise.started -= instance.OnStationRotateClockwise;
			StationRotateClockwise.performed -= instance.OnStationRotateClockwise;
			StationRotateClockwise.canceled -= instance.OnStationRotateClockwise;
			StationRotateCounterClockwise.started -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.performed -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.canceled -= instance.OnStationRotateCounterClockwise;
		}

		public void RemoveCallbacks(IGame1Actions instance)
		{
			if (m_Wrapper.m_Game1ActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IGame1Actions instance)
		{
			foreach (IGame1Actions game1ActionsCallbackInterface in m_Wrapper.m_Game1ActionsCallbackInterfaces)
			{
				UnregisterCallbacks(game1ActionsCallbackInterface);
			}
			m_Wrapper.m_Game1ActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct Game2Actions
	{
		private AggroInput m_Wrapper;

		public InputAction GrabRelease => m_Wrapper.m_Game2_GrabRelease;

		public InputAction RaiseLower => m_Wrapper.m_Game2_RaiseLower;

		public InputAction Steering => m_Wrapper.m_Game2_Steering;

		public InputAction Gas => m_Wrapper.m_Game2_Gas;

		public InputAction Brake => m_Wrapper.m_Game2_Brake;

		public InputAction Boost => m_Wrapper.m_Game2_Boost;

		public InputAction ToggleSteeringStyle => m_Wrapper.m_Game2_ToggleSteeringStyle;

		public InputAction StationPlace => m_Wrapper.m_Game2_StationPlace;

		public InputAction Drift => m_Wrapper.m_Game2_Drift;

		public InputAction Beep => m_Wrapper.m_Game2_Beep;

		public InputAction DMenuLeft => m_Wrapper.m_Game2_DMenuLeft;

		public InputAction DMenuRight => m_Wrapper.m_Game2_DMenuRight;

		public InputAction OpenGameMenu => m_Wrapper.m_Game2_OpenGameMenu;

		public InputAction UseBox => m_Wrapper.m_Game2_UseBox;

		public InputAction TapTapMouseAxis => m_Wrapper.m_Game2_TapTapMouseAxis;

		public InputAction ToggleTipTap => m_Wrapper.m_Game2_ToggleTipTap;

		public InputAction SwipeUpTipTap => m_Wrapper.m_Game2_SwipeUpTipTap;

		public InputAction SwipeDownTipTap => m_Wrapper.m_Game2_SwipeDownTipTap;

		public InputAction SwipeRightTipTap => m_Wrapper.m_Game2_SwipeRightTipTap;

		public InputAction SwipeLeftTipTap => m_Wrapper.m_Game2_SwipeLeftTipTap;

		public InputAction StationRotateClockwise => m_Wrapper.m_Game2_StationRotateClockwise;

		public InputAction StationRotateCounterClockwise => m_Wrapper.m_Game2_StationRotateCounterClockwise;

		public bool enabled => Get().enabled;

		public Game2Actions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Game2;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(Game2Actions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IGame2Actions instance)
		{
			if (instance != null && !m_Wrapper.m_Game2ActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_Game2ActionsCallbackInterfaces.Add(instance);
				GrabRelease.started += instance.OnGrabRelease;
				GrabRelease.performed += instance.OnGrabRelease;
				GrabRelease.canceled += instance.OnGrabRelease;
				RaiseLower.started += instance.OnRaiseLower;
				RaiseLower.performed += instance.OnRaiseLower;
				RaiseLower.canceled += instance.OnRaiseLower;
				Steering.started += instance.OnSteering;
				Steering.performed += instance.OnSteering;
				Steering.canceled += instance.OnSteering;
				Gas.started += instance.OnGas;
				Gas.performed += instance.OnGas;
				Gas.canceled += instance.OnGas;
				Brake.started += instance.OnBrake;
				Brake.performed += instance.OnBrake;
				Brake.canceled += instance.OnBrake;
				Boost.started += instance.OnBoost;
				Boost.performed += instance.OnBoost;
				Boost.canceled += instance.OnBoost;
				ToggleSteeringStyle.started += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.performed += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.canceled += instance.OnToggleSteeringStyle;
				StationPlace.started += instance.OnStationPlace;
				StationPlace.performed += instance.OnStationPlace;
				StationPlace.canceled += instance.OnStationPlace;
				Drift.started += instance.OnDrift;
				Drift.performed += instance.OnDrift;
				Drift.canceled += instance.OnDrift;
				Beep.started += instance.OnBeep;
				Beep.performed += instance.OnBeep;
				Beep.canceled += instance.OnBeep;
				DMenuLeft.started += instance.OnDMenuLeft;
				DMenuLeft.performed += instance.OnDMenuLeft;
				DMenuLeft.canceled += instance.OnDMenuLeft;
				DMenuRight.started += instance.OnDMenuRight;
				DMenuRight.performed += instance.OnDMenuRight;
				DMenuRight.canceled += instance.OnDMenuRight;
				OpenGameMenu.started += instance.OnOpenGameMenu;
				OpenGameMenu.performed += instance.OnOpenGameMenu;
				OpenGameMenu.canceled += instance.OnOpenGameMenu;
				UseBox.started += instance.OnUseBox;
				UseBox.performed += instance.OnUseBox;
				UseBox.canceled += instance.OnUseBox;
				TapTapMouseAxis.started += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.performed += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.canceled += instance.OnTapTapMouseAxis;
				ToggleTipTap.started += instance.OnToggleTipTap;
				ToggleTipTap.performed += instance.OnToggleTipTap;
				ToggleTipTap.canceled += instance.OnToggleTipTap;
				SwipeUpTipTap.started += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.performed += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.canceled += instance.OnSwipeUpTipTap;
				SwipeDownTipTap.started += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.performed += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.canceled += instance.OnSwipeDownTipTap;
				SwipeRightTipTap.started += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.performed += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.canceled += instance.OnSwipeRightTipTap;
				SwipeLeftTipTap.started += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.performed += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.canceled += instance.OnSwipeLeftTipTap;
				StationRotateClockwise.started += instance.OnStationRotateClockwise;
				StationRotateClockwise.performed += instance.OnStationRotateClockwise;
				StationRotateClockwise.canceled += instance.OnStationRotateClockwise;
				StationRotateCounterClockwise.started += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.performed += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.canceled += instance.OnStationRotateCounterClockwise;
			}
		}

		private void UnregisterCallbacks(IGame2Actions instance)
		{
			GrabRelease.started -= instance.OnGrabRelease;
			GrabRelease.performed -= instance.OnGrabRelease;
			GrabRelease.canceled -= instance.OnGrabRelease;
			RaiseLower.started -= instance.OnRaiseLower;
			RaiseLower.performed -= instance.OnRaiseLower;
			RaiseLower.canceled -= instance.OnRaiseLower;
			Steering.started -= instance.OnSteering;
			Steering.performed -= instance.OnSteering;
			Steering.canceled -= instance.OnSteering;
			Gas.started -= instance.OnGas;
			Gas.performed -= instance.OnGas;
			Gas.canceled -= instance.OnGas;
			Brake.started -= instance.OnBrake;
			Brake.performed -= instance.OnBrake;
			Brake.canceled -= instance.OnBrake;
			Boost.started -= instance.OnBoost;
			Boost.performed -= instance.OnBoost;
			Boost.canceled -= instance.OnBoost;
			ToggleSteeringStyle.started -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.performed -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.canceled -= instance.OnToggleSteeringStyle;
			StationPlace.started -= instance.OnStationPlace;
			StationPlace.performed -= instance.OnStationPlace;
			StationPlace.canceled -= instance.OnStationPlace;
			Drift.started -= instance.OnDrift;
			Drift.performed -= instance.OnDrift;
			Drift.canceled -= instance.OnDrift;
			Beep.started -= instance.OnBeep;
			Beep.performed -= instance.OnBeep;
			Beep.canceled -= instance.OnBeep;
			DMenuLeft.started -= instance.OnDMenuLeft;
			DMenuLeft.performed -= instance.OnDMenuLeft;
			DMenuLeft.canceled -= instance.OnDMenuLeft;
			DMenuRight.started -= instance.OnDMenuRight;
			DMenuRight.performed -= instance.OnDMenuRight;
			DMenuRight.canceled -= instance.OnDMenuRight;
			OpenGameMenu.started -= instance.OnOpenGameMenu;
			OpenGameMenu.performed -= instance.OnOpenGameMenu;
			OpenGameMenu.canceled -= instance.OnOpenGameMenu;
			UseBox.started -= instance.OnUseBox;
			UseBox.performed -= instance.OnUseBox;
			UseBox.canceled -= instance.OnUseBox;
			TapTapMouseAxis.started -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.performed -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.canceled -= instance.OnTapTapMouseAxis;
			ToggleTipTap.started -= instance.OnToggleTipTap;
			ToggleTipTap.performed -= instance.OnToggleTipTap;
			ToggleTipTap.canceled -= instance.OnToggleTipTap;
			SwipeUpTipTap.started -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.performed -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.canceled -= instance.OnSwipeUpTipTap;
			SwipeDownTipTap.started -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.performed -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.canceled -= instance.OnSwipeDownTipTap;
			SwipeRightTipTap.started -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.performed -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.canceled -= instance.OnSwipeRightTipTap;
			SwipeLeftTipTap.started -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.performed -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.canceled -= instance.OnSwipeLeftTipTap;
			StationRotateClockwise.started -= instance.OnStationRotateClockwise;
			StationRotateClockwise.performed -= instance.OnStationRotateClockwise;
			StationRotateClockwise.canceled -= instance.OnStationRotateClockwise;
			StationRotateCounterClockwise.started -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.performed -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.canceled -= instance.OnStationRotateCounterClockwise;
		}

		public void RemoveCallbacks(IGame2Actions instance)
		{
			if (m_Wrapper.m_Game2ActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IGame2Actions instance)
		{
			foreach (IGame2Actions game2ActionsCallbackInterface in m_Wrapper.m_Game2ActionsCallbackInterfaces)
			{
				UnregisterCallbacks(game2ActionsCallbackInterface);
			}
			m_Wrapper.m_Game2ActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct Game3Actions
	{
		private AggroInput m_Wrapper;

		public InputAction GrabRelease => m_Wrapper.m_Game3_GrabRelease;

		public InputAction RaiseLower => m_Wrapper.m_Game3_RaiseLower;

		public InputAction Steering => m_Wrapper.m_Game3_Steering;

		public InputAction Gas => m_Wrapper.m_Game3_Gas;

		public InputAction Brake => m_Wrapper.m_Game3_Brake;

		public InputAction Boost => m_Wrapper.m_Game3_Boost;

		public InputAction ToggleSteeringStyle => m_Wrapper.m_Game3_ToggleSteeringStyle;

		public InputAction StationPlace => m_Wrapper.m_Game3_StationPlace;

		public InputAction Drift => m_Wrapper.m_Game3_Drift;

		public InputAction Beep => m_Wrapper.m_Game3_Beep;

		public InputAction DMenuLeft => m_Wrapper.m_Game3_DMenuLeft;

		public InputAction DMenuRight => m_Wrapper.m_Game3_DMenuRight;

		public InputAction OpenGameMenu => m_Wrapper.m_Game3_OpenGameMenu;

		public InputAction UseBox => m_Wrapper.m_Game3_UseBox;

		public InputAction TapTapMouseAxis => m_Wrapper.m_Game3_TapTapMouseAxis;

		public InputAction ToggleTipTap => m_Wrapper.m_Game3_ToggleTipTap;

		public InputAction SwipeUpTipTap => m_Wrapper.m_Game3_SwipeUpTipTap;

		public InputAction SwipeDownTipTap => m_Wrapper.m_Game3_SwipeDownTipTap;

		public InputAction SwipeRightTipTap => m_Wrapper.m_Game3_SwipeRightTipTap;

		public InputAction SwipeLeftTipTap => m_Wrapper.m_Game3_SwipeLeftTipTap;

		public InputAction StationRotateClockwise => m_Wrapper.m_Game3_StationRotateClockwise;

		public InputAction StationRotateCounterClockwise => m_Wrapper.m_Game3_StationRotateCounterClockwise;

		public bool enabled => Get().enabled;

		public Game3Actions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Game3;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(Game3Actions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IGame3Actions instance)
		{
			if (instance != null && !m_Wrapper.m_Game3ActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_Game3ActionsCallbackInterfaces.Add(instance);
				GrabRelease.started += instance.OnGrabRelease;
				GrabRelease.performed += instance.OnGrabRelease;
				GrabRelease.canceled += instance.OnGrabRelease;
				RaiseLower.started += instance.OnRaiseLower;
				RaiseLower.performed += instance.OnRaiseLower;
				RaiseLower.canceled += instance.OnRaiseLower;
				Steering.started += instance.OnSteering;
				Steering.performed += instance.OnSteering;
				Steering.canceled += instance.OnSteering;
				Gas.started += instance.OnGas;
				Gas.performed += instance.OnGas;
				Gas.canceled += instance.OnGas;
				Brake.started += instance.OnBrake;
				Brake.performed += instance.OnBrake;
				Brake.canceled += instance.OnBrake;
				Boost.started += instance.OnBoost;
				Boost.performed += instance.OnBoost;
				Boost.canceled += instance.OnBoost;
				ToggleSteeringStyle.started += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.performed += instance.OnToggleSteeringStyle;
				ToggleSteeringStyle.canceled += instance.OnToggleSteeringStyle;
				StationPlace.started += instance.OnStationPlace;
				StationPlace.performed += instance.OnStationPlace;
				StationPlace.canceled += instance.OnStationPlace;
				Drift.started += instance.OnDrift;
				Drift.performed += instance.OnDrift;
				Drift.canceled += instance.OnDrift;
				Beep.started += instance.OnBeep;
				Beep.performed += instance.OnBeep;
				Beep.canceled += instance.OnBeep;
				DMenuLeft.started += instance.OnDMenuLeft;
				DMenuLeft.performed += instance.OnDMenuLeft;
				DMenuLeft.canceled += instance.OnDMenuLeft;
				DMenuRight.started += instance.OnDMenuRight;
				DMenuRight.performed += instance.OnDMenuRight;
				DMenuRight.canceled += instance.OnDMenuRight;
				OpenGameMenu.started += instance.OnOpenGameMenu;
				OpenGameMenu.performed += instance.OnOpenGameMenu;
				OpenGameMenu.canceled += instance.OnOpenGameMenu;
				UseBox.started += instance.OnUseBox;
				UseBox.performed += instance.OnUseBox;
				UseBox.canceled += instance.OnUseBox;
				TapTapMouseAxis.started += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.performed += instance.OnTapTapMouseAxis;
				TapTapMouseAxis.canceled += instance.OnTapTapMouseAxis;
				ToggleTipTap.started += instance.OnToggleTipTap;
				ToggleTipTap.performed += instance.OnToggleTipTap;
				ToggleTipTap.canceled += instance.OnToggleTipTap;
				SwipeUpTipTap.started += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.performed += instance.OnSwipeUpTipTap;
				SwipeUpTipTap.canceled += instance.OnSwipeUpTipTap;
				SwipeDownTipTap.started += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.performed += instance.OnSwipeDownTipTap;
				SwipeDownTipTap.canceled += instance.OnSwipeDownTipTap;
				SwipeRightTipTap.started += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.performed += instance.OnSwipeRightTipTap;
				SwipeRightTipTap.canceled += instance.OnSwipeRightTipTap;
				SwipeLeftTipTap.started += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.performed += instance.OnSwipeLeftTipTap;
				SwipeLeftTipTap.canceled += instance.OnSwipeLeftTipTap;
				StationRotateClockwise.started += instance.OnStationRotateClockwise;
				StationRotateClockwise.performed += instance.OnStationRotateClockwise;
				StationRotateClockwise.canceled += instance.OnStationRotateClockwise;
				StationRotateCounterClockwise.started += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.performed += instance.OnStationRotateCounterClockwise;
				StationRotateCounterClockwise.canceled += instance.OnStationRotateCounterClockwise;
			}
		}

		private void UnregisterCallbacks(IGame3Actions instance)
		{
			GrabRelease.started -= instance.OnGrabRelease;
			GrabRelease.performed -= instance.OnGrabRelease;
			GrabRelease.canceled -= instance.OnGrabRelease;
			RaiseLower.started -= instance.OnRaiseLower;
			RaiseLower.performed -= instance.OnRaiseLower;
			RaiseLower.canceled -= instance.OnRaiseLower;
			Steering.started -= instance.OnSteering;
			Steering.performed -= instance.OnSteering;
			Steering.canceled -= instance.OnSteering;
			Gas.started -= instance.OnGas;
			Gas.performed -= instance.OnGas;
			Gas.canceled -= instance.OnGas;
			Brake.started -= instance.OnBrake;
			Brake.performed -= instance.OnBrake;
			Brake.canceled -= instance.OnBrake;
			Boost.started -= instance.OnBoost;
			Boost.performed -= instance.OnBoost;
			Boost.canceled -= instance.OnBoost;
			ToggleSteeringStyle.started -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.performed -= instance.OnToggleSteeringStyle;
			ToggleSteeringStyle.canceled -= instance.OnToggleSteeringStyle;
			StationPlace.started -= instance.OnStationPlace;
			StationPlace.performed -= instance.OnStationPlace;
			StationPlace.canceled -= instance.OnStationPlace;
			Drift.started -= instance.OnDrift;
			Drift.performed -= instance.OnDrift;
			Drift.canceled -= instance.OnDrift;
			Beep.started -= instance.OnBeep;
			Beep.performed -= instance.OnBeep;
			Beep.canceled -= instance.OnBeep;
			DMenuLeft.started -= instance.OnDMenuLeft;
			DMenuLeft.performed -= instance.OnDMenuLeft;
			DMenuLeft.canceled -= instance.OnDMenuLeft;
			DMenuRight.started -= instance.OnDMenuRight;
			DMenuRight.performed -= instance.OnDMenuRight;
			DMenuRight.canceled -= instance.OnDMenuRight;
			OpenGameMenu.started -= instance.OnOpenGameMenu;
			OpenGameMenu.performed -= instance.OnOpenGameMenu;
			OpenGameMenu.canceled -= instance.OnOpenGameMenu;
			UseBox.started -= instance.OnUseBox;
			UseBox.performed -= instance.OnUseBox;
			UseBox.canceled -= instance.OnUseBox;
			TapTapMouseAxis.started -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.performed -= instance.OnTapTapMouseAxis;
			TapTapMouseAxis.canceled -= instance.OnTapTapMouseAxis;
			ToggleTipTap.started -= instance.OnToggleTipTap;
			ToggleTipTap.performed -= instance.OnToggleTipTap;
			ToggleTipTap.canceled -= instance.OnToggleTipTap;
			SwipeUpTipTap.started -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.performed -= instance.OnSwipeUpTipTap;
			SwipeUpTipTap.canceled -= instance.OnSwipeUpTipTap;
			SwipeDownTipTap.started -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.performed -= instance.OnSwipeDownTipTap;
			SwipeDownTipTap.canceled -= instance.OnSwipeDownTipTap;
			SwipeRightTipTap.started -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.performed -= instance.OnSwipeRightTipTap;
			SwipeRightTipTap.canceled -= instance.OnSwipeRightTipTap;
			SwipeLeftTipTap.started -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.performed -= instance.OnSwipeLeftTipTap;
			SwipeLeftTipTap.canceled -= instance.OnSwipeLeftTipTap;
			StationRotateClockwise.started -= instance.OnStationRotateClockwise;
			StationRotateClockwise.performed -= instance.OnStationRotateClockwise;
			StationRotateClockwise.canceled -= instance.OnStationRotateClockwise;
			StationRotateCounterClockwise.started -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.performed -= instance.OnStationRotateCounterClockwise;
			StationRotateCounterClockwise.canceled -= instance.OnStationRotateCounterClockwise;
		}

		public void RemoveCallbacks(IGame3Actions instance)
		{
			if (m_Wrapper.m_Game3ActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IGame3Actions instance)
		{
			foreach (IGame3Actions game3ActionsCallbackInterface in m_Wrapper.m_Game3ActionsCallbackInterfaces)
			{
				UnregisterCallbacks(game3ActionsCallbackInterface);
			}
			m_Wrapper.m_Game3ActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct DebugActions
	{
		private AggroInput m_Wrapper;

		public InputAction ToggleConsoleGamePad => m_Wrapper.m_Debug_ToggleConsoleGamePad;

		public InputAction ToggleConsoleKBM => m_Wrapper.m_Debug_ToggleConsoleKBM;

		public InputAction ToggleDebugGraphs => m_Wrapper.m_Debug_ToggleDebugGraphs;

		public InputAction PrintGraphicsRaycast => m_Wrapper.m_Debug_PrintGraphicsRaycast;

		public InputAction ToggleFreeCam => m_Wrapper.m_Debug_ToggleFreeCam;

		public bool enabled => Get().enabled;

		public DebugActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Debug;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(DebugActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IDebugActions instance)
		{
			if (instance != null && !m_Wrapper.m_DebugActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_DebugActionsCallbackInterfaces.Add(instance);
				ToggleConsoleGamePad.started += instance.OnToggleConsoleGamePad;
				ToggleConsoleGamePad.performed += instance.OnToggleConsoleGamePad;
				ToggleConsoleGamePad.canceled += instance.OnToggleConsoleGamePad;
				ToggleConsoleKBM.started += instance.OnToggleConsoleKBM;
				ToggleConsoleKBM.performed += instance.OnToggleConsoleKBM;
				ToggleConsoleKBM.canceled += instance.OnToggleConsoleKBM;
				ToggleDebugGraphs.started += instance.OnToggleDebugGraphs;
				ToggleDebugGraphs.performed += instance.OnToggleDebugGraphs;
				ToggleDebugGraphs.canceled += instance.OnToggleDebugGraphs;
				PrintGraphicsRaycast.started += instance.OnPrintGraphicsRaycast;
				PrintGraphicsRaycast.performed += instance.OnPrintGraphicsRaycast;
				PrintGraphicsRaycast.canceled += instance.OnPrintGraphicsRaycast;
				ToggleFreeCam.started += instance.OnToggleFreeCam;
				ToggleFreeCam.performed += instance.OnToggleFreeCam;
				ToggleFreeCam.canceled += instance.OnToggleFreeCam;
			}
		}

		private void UnregisterCallbacks(IDebugActions instance)
		{
			ToggleConsoleGamePad.started -= instance.OnToggleConsoleGamePad;
			ToggleConsoleGamePad.performed -= instance.OnToggleConsoleGamePad;
			ToggleConsoleGamePad.canceled -= instance.OnToggleConsoleGamePad;
			ToggleConsoleKBM.started -= instance.OnToggleConsoleKBM;
			ToggleConsoleKBM.performed -= instance.OnToggleConsoleKBM;
			ToggleConsoleKBM.canceled -= instance.OnToggleConsoleKBM;
			ToggleDebugGraphs.started -= instance.OnToggleDebugGraphs;
			ToggleDebugGraphs.performed -= instance.OnToggleDebugGraphs;
			ToggleDebugGraphs.canceled -= instance.OnToggleDebugGraphs;
			PrintGraphicsRaycast.started -= instance.OnPrintGraphicsRaycast;
			PrintGraphicsRaycast.performed -= instance.OnPrintGraphicsRaycast;
			PrintGraphicsRaycast.canceled -= instance.OnPrintGraphicsRaycast;
			ToggleFreeCam.started -= instance.OnToggleFreeCam;
			ToggleFreeCam.performed -= instance.OnToggleFreeCam;
			ToggleFreeCam.canceled -= instance.OnToggleFreeCam;
		}

		public void RemoveCallbacks(IDebugActions instance)
		{
			if (m_Wrapper.m_DebugActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IDebugActions instance)
		{
			foreach (IDebugActions debugActionsCallbackInterface in m_Wrapper.m_DebugActionsCallbackInterfaces)
			{
				UnregisterCallbacks(debugActionsCallbackInterface);
			}
			m_Wrapper.m_DebugActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct PopUpActions
	{
		private AggroInput m_Wrapper;

		public InputAction Close => m_Wrapper.m_PopUp_Close;

		public bool enabled => Get().enabled;

		public PopUpActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_PopUp;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(PopUpActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IPopUpActions instance)
		{
			if (instance != null && !m_Wrapper.m_PopUpActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_PopUpActionsCallbackInterfaces.Add(instance);
				Close.started += instance.OnClose;
				Close.performed += instance.OnClose;
				Close.canceled += instance.OnClose;
			}
		}

		private void UnregisterCallbacks(IPopUpActions instance)
		{
			Close.started -= instance.OnClose;
			Close.performed -= instance.OnClose;
			Close.canceled -= instance.OnClose;
		}

		public void RemoveCallbacks(IPopUpActions instance)
		{
			if (m_Wrapper.m_PopUpActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IPopUpActions instance)
		{
			foreach (IPopUpActions popUpActionsCallbackInterface in m_Wrapper.m_PopUpActionsCallbackInterfaces)
			{
				UnregisterCallbacks(popUpActionsCallbackInterface);
			}
			m_Wrapper.m_PopUpActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct QuotaReportActions
	{
		private AggroInput m_Wrapper;

		public InputAction Continue => m_Wrapper.m_QuotaReport_Continue;

		public InputAction Skip => m_Wrapper.m_QuotaReport_Skip;

		public bool enabled => Get().enabled;

		public QuotaReportActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_QuotaReport;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(QuotaReportActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IQuotaReportActions instance)
		{
			if (instance != null && !m_Wrapper.m_QuotaReportActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_QuotaReportActionsCallbackInterfaces.Add(instance);
				Continue.started += instance.OnContinue;
				Continue.performed += instance.OnContinue;
				Continue.canceled += instance.OnContinue;
				Skip.started += instance.OnSkip;
				Skip.performed += instance.OnSkip;
				Skip.canceled += instance.OnSkip;
			}
		}

		private void UnregisterCallbacks(IQuotaReportActions instance)
		{
			Continue.started -= instance.OnContinue;
			Continue.performed -= instance.OnContinue;
			Continue.canceled -= instance.OnContinue;
			Skip.started -= instance.OnSkip;
			Skip.performed -= instance.OnSkip;
			Skip.canceled -= instance.OnSkip;
		}

		public void RemoveCallbacks(IQuotaReportActions instance)
		{
			if (m_Wrapper.m_QuotaReportActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IQuotaReportActions instance)
		{
			foreach (IQuotaReportActions quotaReportActionsCallbackInterface in m_Wrapper.m_QuotaReportActionsCallbackInterfaces)
			{
				UnregisterCallbacks(quotaReportActionsCallbackInterface);
			}
			m_Wrapper.m_QuotaReportActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct UnlockMenuActions
	{
		private AggroInput m_Wrapper;

		public InputAction Continue => m_Wrapper.m_UnlockMenu_Continue;

		public bool enabled => Get().enabled;

		public UnlockMenuActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_UnlockMenu;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(UnlockMenuActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IUnlockMenuActions instance)
		{
			if (instance != null && !m_Wrapper.m_UnlockMenuActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_UnlockMenuActionsCallbackInterfaces.Add(instance);
				Continue.started += instance.OnContinue;
				Continue.performed += instance.OnContinue;
				Continue.canceled += instance.OnContinue;
			}
		}

		private void UnregisterCallbacks(IUnlockMenuActions instance)
		{
			Continue.started -= instance.OnContinue;
			Continue.performed -= instance.OnContinue;
			Continue.canceled -= instance.OnContinue;
		}

		public void RemoveCallbacks(IUnlockMenuActions instance)
		{
			if (m_Wrapper.m_UnlockMenuActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IUnlockMenuActions instance)
		{
			foreach (IUnlockMenuActions unlockMenuActionsCallbackInterface in m_Wrapper.m_UnlockMenuActionsCallbackInterfaces)
			{
				UnregisterCallbacks(unlockMenuActionsCallbackInterface);
			}
			m_Wrapper.m_UnlockMenuActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct OptionsMenuActions
	{
		private AggroInput m_Wrapper;

		public InputAction BackOut => m_Wrapper.m_OptionsMenu_BackOut;

		public bool enabled => Get().enabled;

		public OptionsMenuActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_OptionsMenu;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(OptionsMenuActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IOptionsMenuActions instance)
		{
			if (instance != null && !m_Wrapper.m_OptionsMenuActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_OptionsMenuActionsCallbackInterfaces.Add(instance);
				BackOut.started += instance.OnBackOut;
				BackOut.performed += instance.OnBackOut;
				BackOut.canceled += instance.OnBackOut;
			}
		}

		private void UnregisterCallbacks(IOptionsMenuActions instance)
		{
			BackOut.started -= instance.OnBackOut;
			BackOut.performed -= instance.OnBackOut;
			BackOut.canceled -= instance.OnBackOut;
		}

		public void RemoveCallbacks(IOptionsMenuActions instance)
		{
			if (m_Wrapper.m_OptionsMenuActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IOptionsMenuActions instance)
		{
			foreach (IOptionsMenuActions optionsMenuActionsCallbackInterface in m_Wrapper.m_OptionsMenuActionsCallbackInterfaces)
			{
				UnregisterCallbacks(optionsMenuActionsCallbackInterface);
			}
			m_Wrapper.m_OptionsMenuActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct GameMenuActions
	{
		private AggroInput m_Wrapper;

		public InputAction BackOut => m_Wrapper.m_GameMenu_BackOut;

		public InputAction OpenProfile => m_Wrapper.m_GameMenu_OpenProfile;

		public bool enabled => Get().enabled;

		public GameMenuActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_GameMenu;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(GameMenuActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IGameMenuActions instance)
		{
			if (instance != null && !m_Wrapper.m_GameMenuActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_GameMenuActionsCallbackInterfaces.Add(instance);
				BackOut.started += instance.OnBackOut;
				BackOut.performed += instance.OnBackOut;
				BackOut.canceled += instance.OnBackOut;
				OpenProfile.started += instance.OnOpenProfile;
				OpenProfile.performed += instance.OnOpenProfile;
				OpenProfile.canceled += instance.OnOpenProfile;
			}
		}

		private void UnregisterCallbacks(IGameMenuActions instance)
		{
			BackOut.started -= instance.OnBackOut;
			BackOut.performed -= instance.OnBackOut;
			BackOut.canceled -= instance.OnBackOut;
			OpenProfile.started -= instance.OnOpenProfile;
			OpenProfile.performed -= instance.OnOpenProfile;
			OpenProfile.canceled -= instance.OnOpenProfile;
		}

		public void RemoveCallbacks(IGameMenuActions instance)
		{
			if (m_Wrapper.m_GameMenuActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IGameMenuActions instance)
		{
			foreach (IGameMenuActions gameMenuActionsCallbackInterface in m_Wrapper.m_GameMenuActionsCallbackInterfaces)
			{
				UnregisterCallbacks(gameMenuActionsCallbackInterface);
			}
			m_Wrapper.m_GameMenuActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct ChoiceMenuActions
	{
		private AggroInput m_Wrapper;

		public InputAction OpenGameMenu => m_Wrapper.m_ChoiceMenu_OpenGameMenu;

		public InputAction ChooseLeft => m_Wrapper.m_ChoiceMenu_ChooseLeft;

		public InputAction ChooseRight => m_Wrapper.m_ChoiceMenu_ChooseRight;

		public bool enabled => Get().enabled;

		public ChoiceMenuActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_ChoiceMenu;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(ChoiceMenuActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IChoiceMenuActions instance)
		{
			if (instance != null && !m_Wrapper.m_ChoiceMenuActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_ChoiceMenuActionsCallbackInterfaces.Add(instance);
				OpenGameMenu.started += instance.OnOpenGameMenu;
				OpenGameMenu.performed += instance.OnOpenGameMenu;
				OpenGameMenu.canceled += instance.OnOpenGameMenu;
				ChooseLeft.started += instance.OnChooseLeft;
				ChooseLeft.performed += instance.OnChooseLeft;
				ChooseLeft.canceled += instance.OnChooseLeft;
				ChooseRight.started += instance.OnChooseRight;
				ChooseRight.performed += instance.OnChooseRight;
				ChooseRight.canceled += instance.OnChooseRight;
			}
		}

		private void UnregisterCallbacks(IChoiceMenuActions instance)
		{
			OpenGameMenu.started -= instance.OnOpenGameMenu;
			OpenGameMenu.performed -= instance.OnOpenGameMenu;
			OpenGameMenu.canceled -= instance.OnOpenGameMenu;
			ChooseLeft.started -= instance.OnChooseLeft;
			ChooseLeft.performed -= instance.OnChooseLeft;
			ChooseLeft.canceled -= instance.OnChooseLeft;
			ChooseRight.started -= instance.OnChooseRight;
			ChooseRight.performed -= instance.OnChooseRight;
			ChooseRight.canceled -= instance.OnChooseRight;
		}

		public void RemoveCallbacks(IChoiceMenuActions instance)
		{
			if (m_Wrapper.m_ChoiceMenuActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IChoiceMenuActions instance)
		{
			foreach (IChoiceMenuActions choiceMenuActionsCallbackInterface in m_Wrapper.m_ChoiceMenuActionsCallbackInterfaces)
			{
				UnregisterCallbacks(choiceMenuActionsCallbackInterface);
			}
			m_Wrapper.m_ChoiceMenuActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct LobbyActions
	{
		private AggroInput m_Wrapper;

		public InputAction ChooseLeft => m_Wrapper.m_Lobby_ChooseLeft;

		public InputAction ChooseRight => m_Wrapper.m_Lobby_ChooseRight;

		public InputAction Confirm => m_Wrapper.m_Lobby_Confirm;

		public InputAction BackOut => m_Wrapper.m_Lobby_BackOut;

		public InputAction OpenGameMenu => m_Wrapper.m_Lobby_OpenGameMenu;

		public bool enabled => Get().enabled;

		public LobbyActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Lobby;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(LobbyActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(ILobbyActions instance)
		{
			if (instance != null && !m_Wrapper.m_LobbyActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_LobbyActionsCallbackInterfaces.Add(instance);
				ChooseLeft.started += instance.OnChooseLeft;
				ChooseLeft.performed += instance.OnChooseLeft;
				ChooseLeft.canceled += instance.OnChooseLeft;
				ChooseRight.started += instance.OnChooseRight;
				ChooseRight.performed += instance.OnChooseRight;
				ChooseRight.canceled += instance.OnChooseRight;
				Confirm.started += instance.OnConfirm;
				Confirm.performed += instance.OnConfirm;
				Confirm.canceled += instance.OnConfirm;
				BackOut.started += instance.OnBackOut;
				BackOut.performed += instance.OnBackOut;
				BackOut.canceled += instance.OnBackOut;
				OpenGameMenu.started += instance.OnOpenGameMenu;
				OpenGameMenu.performed += instance.OnOpenGameMenu;
				OpenGameMenu.canceled += instance.OnOpenGameMenu;
			}
		}

		private void UnregisterCallbacks(ILobbyActions instance)
		{
			ChooseLeft.started -= instance.OnChooseLeft;
			ChooseLeft.performed -= instance.OnChooseLeft;
			ChooseLeft.canceled -= instance.OnChooseLeft;
			ChooseRight.started -= instance.OnChooseRight;
			ChooseRight.performed -= instance.OnChooseRight;
			ChooseRight.canceled -= instance.OnChooseRight;
			Confirm.started -= instance.OnConfirm;
			Confirm.performed -= instance.OnConfirm;
			Confirm.canceled -= instance.OnConfirm;
			BackOut.started -= instance.OnBackOut;
			BackOut.performed -= instance.OnBackOut;
			BackOut.canceled -= instance.OnBackOut;
			OpenGameMenu.started -= instance.OnOpenGameMenu;
			OpenGameMenu.performed -= instance.OnOpenGameMenu;
			OpenGameMenu.canceled -= instance.OnOpenGameMenu;
		}

		public void RemoveCallbacks(ILobbyActions instance)
		{
			if (m_Wrapper.m_LobbyActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(ILobbyActions instance)
		{
			foreach (ILobbyActions lobbyActionsCallbackInterface in m_Wrapper.m_LobbyActionsCallbackInterfaces)
			{
				UnregisterCallbacks(lobbyActionsCallbackInterface);
			}
			m_Wrapper.m_LobbyActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct DialogueActions
	{
		private AggroInput m_Wrapper;

		public InputAction Complete => m_Wrapper.m_Dialogue_Complete;

		public bool enabled => Get().enabled;

		public DialogueActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Dialogue;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(DialogueActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IDialogueActions instance)
		{
			if (instance != null && !m_Wrapper.m_DialogueActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_DialogueActionsCallbackInterfaces.Add(instance);
				Complete.started += instance.OnComplete;
				Complete.performed += instance.OnComplete;
				Complete.canceled += instance.OnComplete;
			}
		}

		private void UnregisterCallbacks(IDialogueActions instance)
		{
			Complete.started -= instance.OnComplete;
			Complete.performed -= instance.OnComplete;
			Complete.canceled -= instance.OnComplete;
		}

		public void RemoveCallbacks(IDialogueActions instance)
		{
			if (m_Wrapper.m_DialogueActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IDialogueActions instance)
		{
			foreach (IDialogueActions dialogueActionsCallbackInterface in m_Wrapper.m_DialogueActionsCallbackInterfaces)
			{
				UnregisterCallbacks(dialogueActionsCallbackInterface);
			}
			m_Wrapper.m_DialogueActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct CreditsActions
	{
		private AggroInput m_Wrapper;

		public InputAction FastForward => m_Wrapper.m_Credits_FastForward;

		public InputAction Exit => m_Wrapper.m_Credits_Exit;

		public bool enabled => Get().enabled;

		public CreditsActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Credits;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(CreditsActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(ICreditsActions instance)
		{
			if (instance != null && !m_Wrapper.m_CreditsActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_CreditsActionsCallbackInterfaces.Add(instance);
				FastForward.started += instance.OnFastForward;
				FastForward.performed += instance.OnFastForward;
				FastForward.canceled += instance.OnFastForward;
				Exit.started += instance.OnExit;
				Exit.performed += instance.OnExit;
				Exit.canceled += instance.OnExit;
			}
		}

		private void UnregisterCallbacks(ICreditsActions instance)
		{
			FastForward.started -= instance.OnFastForward;
			FastForward.performed -= instance.OnFastForward;
			FastForward.canceled -= instance.OnFastForward;
			Exit.started -= instance.OnExit;
			Exit.performed -= instance.OnExit;
			Exit.canceled -= instance.OnExit;
		}

		public void RemoveCallbacks(ICreditsActions instance)
		{
			if (m_Wrapper.m_CreditsActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(ICreditsActions instance)
		{
			foreach (ICreditsActions creditsActionsCallbackInterface in m_Wrapper.m_CreditsActionsCallbackInterfaces)
			{
				UnregisterCallbacks(creditsActionsCallbackInterface);
			}
			m_Wrapper.m_CreditsActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct DebugCamActions
	{
		private AggroInput m_Wrapper;

		public InputAction Move => m_Wrapper.m_DebugCam_Move;

		public InputAction Look => m_Wrapper.m_DebugCam_Look;

		public InputAction Modifier => m_Wrapper.m_DebugCam_Modifier;

		public InputAction ZoomIn => m_Wrapper.m_DebugCam_ZoomIn;

		public InputAction ZoomOut => m_Wrapper.m_DebugCam_ZoomOut;

		public bool enabled => Get().enabled;

		public DebugCamActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_DebugCam;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(DebugCamActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IDebugCamActions instance)
		{
			if (instance != null && !m_Wrapper.m_DebugCamActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_DebugCamActionsCallbackInterfaces.Add(instance);
				Move.started += instance.OnMove;
				Move.performed += instance.OnMove;
				Move.canceled += instance.OnMove;
				Look.started += instance.OnLook;
				Look.performed += instance.OnLook;
				Look.canceled += instance.OnLook;
				Modifier.started += instance.OnModifier;
				Modifier.performed += instance.OnModifier;
				Modifier.canceled += instance.OnModifier;
				ZoomIn.started += instance.OnZoomIn;
				ZoomIn.performed += instance.OnZoomIn;
				ZoomIn.canceled += instance.OnZoomIn;
				ZoomOut.started += instance.OnZoomOut;
				ZoomOut.performed += instance.OnZoomOut;
				ZoomOut.canceled += instance.OnZoomOut;
			}
		}

		private void UnregisterCallbacks(IDebugCamActions instance)
		{
			Move.started -= instance.OnMove;
			Move.performed -= instance.OnMove;
			Move.canceled -= instance.OnMove;
			Look.started -= instance.OnLook;
			Look.performed -= instance.OnLook;
			Look.canceled -= instance.OnLook;
			Modifier.started -= instance.OnModifier;
			Modifier.performed -= instance.OnModifier;
			Modifier.canceled -= instance.OnModifier;
			ZoomIn.started -= instance.OnZoomIn;
			ZoomIn.performed -= instance.OnZoomIn;
			ZoomIn.canceled -= instance.OnZoomIn;
			ZoomOut.started -= instance.OnZoomOut;
			ZoomOut.performed -= instance.OnZoomOut;
			ZoomOut.canceled -= instance.OnZoomOut;
		}

		public void RemoveCallbacks(IDebugCamActions instance)
		{
			if (m_Wrapper.m_DebugCamActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IDebugCamActions instance)
		{
			foreach (IDebugCamActions debugCamActionsCallbackInterface in m_Wrapper.m_DebugCamActionsCallbackInterfaces)
			{
				UnregisterCallbacks(debugCamActionsCallbackInterface);
			}
			m_Wrapper.m_DebugCamActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct AlwaysActions
	{
		private AggroInput m_Wrapper;

		public InputAction PTT => m_Wrapper.m_Always_PTT;

		public bool enabled => Get().enabled;

		public AlwaysActions(AggroInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Always;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(AlwaysActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IAlwaysActions instance)
		{
			if (instance != null && !m_Wrapper.m_AlwaysActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_AlwaysActionsCallbackInterfaces.Add(instance);
				PTT.started += instance.OnPTT;
				PTT.performed += instance.OnPTT;
				PTT.canceled += instance.OnPTT;
			}
		}

		private void UnregisterCallbacks(IAlwaysActions instance)
		{
			PTT.started -= instance.OnPTT;
			PTT.performed -= instance.OnPTT;
			PTT.canceled -= instance.OnPTT;
		}

		public void RemoveCallbacks(IAlwaysActions instance)
		{
			if (m_Wrapper.m_AlwaysActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IAlwaysActions instance)
		{
			foreach (IAlwaysActions alwaysActionsCallbackInterface in m_Wrapper.m_AlwaysActionsCallbackInterfaces)
			{
				UnregisterCallbacks(alwaysActionsCallbackInterface);
			}
			m_Wrapper.m_AlwaysActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IGameActions
	{
		void OnGrabRelease(InputAction.CallbackContext context);

		void OnRaiseLower(InputAction.CallbackContext context);

		void OnSteering(InputAction.CallbackContext context);

		void OnGas(InputAction.CallbackContext context);

		void OnBrake(InputAction.CallbackContext context);

		void OnBoost(InputAction.CallbackContext context);

		void OnToggleSteeringStyle(InputAction.CallbackContext context);

		void OnStationPlace(InputAction.CallbackContext context);

		void OnDrift(InputAction.CallbackContext context);

		void OnBeep(InputAction.CallbackContext context);

		void OnDMenuLeft(InputAction.CallbackContext context);

		void OnDMenuRight(InputAction.CallbackContext context);

		void OnOpenGameMenu(InputAction.CallbackContext context);

		void OnUseBox(InputAction.CallbackContext context);

		void OnTapTapMouseAxis(InputAction.CallbackContext context);

		void OnToggleTipTap(InputAction.CallbackContext context);

		void OnSwipeUpTipTap(InputAction.CallbackContext context);

		void OnSwipeDownTipTap(InputAction.CallbackContext context);

		void OnSwipeRightTipTap(InputAction.CallbackContext context);

		void OnSwipeLeftTipTap(InputAction.CallbackContext context);

		void OnStationRotateClockwise(InputAction.CallbackContext context);

		void OnStationRotateCounterClockwise(InputAction.CallbackContext context);
	}

	public interface IGame1Actions
	{
		void OnGrabRelease(InputAction.CallbackContext context);

		void OnRaiseLower(InputAction.CallbackContext context);

		void OnSteering(InputAction.CallbackContext context);

		void OnGas(InputAction.CallbackContext context);

		void OnBrake(InputAction.CallbackContext context);

		void OnBoost(InputAction.CallbackContext context);

		void OnToggleSteeringStyle(InputAction.CallbackContext context);

		void OnStationPlace(InputAction.CallbackContext context);

		void OnDrift(InputAction.CallbackContext context);

		void OnBeep(InputAction.CallbackContext context);

		void OnDMenuLeft(InputAction.CallbackContext context);

		void OnDMenuRight(InputAction.CallbackContext context);

		void OnOpenGameMenu(InputAction.CallbackContext context);

		void OnUseBox(InputAction.CallbackContext context);

		void OnTapTapMouseAxis(InputAction.CallbackContext context);

		void OnToggleTipTap(InputAction.CallbackContext context);

		void OnSwipeUpTipTap(InputAction.CallbackContext context);

		void OnSwipeDownTipTap(InputAction.CallbackContext context);

		void OnSwipeRightTipTap(InputAction.CallbackContext context);

		void OnSwipeLeftTipTap(InputAction.CallbackContext context);

		void OnStationRotateClockwise(InputAction.CallbackContext context);

		void OnStationRotateCounterClockwise(InputAction.CallbackContext context);
	}

	public interface IGame2Actions
	{
		void OnGrabRelease(InputAction.CallbackContext context);

		void OnRaiseLower(InputAction.CallbackContext context);

		void OnSteering(InputAction.CallbackContext context);

		void OnGas(InputAction.CallbackContext context);

		void OnBrake(InputAction.CallbackContext context);

		void OnBoost(InputAction.CallbackContext context);

		void OnToggleSteeringStyle(InputAction.CallbackContext context);

		void OnStationPlace(InputAction.CallbackContext context);

		void OnDrift(InputAction.CallbackContext context);

		void OnBeep(InputAction.CallbackContext context);

		void OnDMenuLeft(InputAction.CallbackContext context);

		void OnDMenuRight(InputAction.CallbackContext context);

		void OnOpenGameMenu(InputAction.CallbackContext context);

		void OnUseBox(InputAction.CallbackContext context);

		void OnTapTapMouseAxis(InputAction.CallbackContext context);

		void OnToggleTipTap(InputAction.CallbackContext context);

		void OnSwipeUpTipTap(InputAction.CallbackContext context);

		void OnSwipeDownTipTap(InputAction.CallbackContext context);

		void OnSwipeRightTipTap(InputAction.CallbackContext context);

		void OnSwipeLeftTipTap(InputAction.CallbackContext context);

		void OnStationRotateClockwise(InputAction.CallbackContext context);

		void OnStationRotateCounterClockwise(InputAction.CallbackContext context);
	}

	public interface IGame3Actions
	{
		void OnGrabRelease(InputAction.CallbackContext context);

		void OnRaiseLower(InputAction.CallbackContext context);

		void OnSteering(InputAction.CallbackContext context);

		void OnGas(InputAction.CallbackContext context);

		void OnBrake(InputAction.CallbackContext context);

		void OnBoost(InputAction.CallbackContext context);

		void OnToggleSteeringStyle(InputAction.CallbackContext context);

		void OnStationPlace(InputAction.CallbackContext context);

		void OnDrift(InputAction.CallbackContext context);

		void OnBeep(InputAction.CallbackContext context);

		void OnDMenuLeft(InputAction.CallbackContext context);

		void OnDMenuRight(InputAction.CallbackContext context);

		void OnOpenGameMenu(InputAction.CallbackContext context);

		void OnUseBox(InputAction.CallbackContext context);

		void OnTapTapMouseAxis(InputAction.CallbackContext context);

		void OnToggleTipTap(InputAction.CallbackContext context);

		void OnSwipeUpTipTap(InputAction.CallbackContext context);

		void OnSwipeDownTipTap(InputAction.CallbackContext context);

		void OnSwipeRightTipTap(InputAction.CallbackContext context);

		void OnSwipeLeftTipTap(InputAction.CallbackContext context);

		void OnStationRotateClockwise(InputAction.CallbackContext context);

		void OnStationRotateCounterClockwise(InputAction.CallbackContext context);
	}

	public interface IDebugActions
	{
		void OnToggleConsoleGamePad(InputAction.CallbackContext context);

		void OnToggleConsoleKBM(InputAction.CallbackContext context);

		void OnToggleDebugGraphs(InputAction.CallbackContext context);

		void OnPrintGraphicsRaycast(InputAction.CallbackContext context);

		void OnToggleFreeCam(InputAction.CallbackContext context);
	}

	public interface IPopUpActions
	{
		void OnClose(InputAction.CallbackContext context);
	}

	public interface IQuotaReportActions
	{
		void OnContinue(InputAction.CallbackContext context);

		void OnSkip(InputAction.CallbackContext context);
	}

	public interface IUnlockMenuActions
	{
		void OnContinue(InputAction.CallbackContext context);
	}

	public interface IOptionsMenuActions
	{
		void OnBackOut(InputAction.CallbackContext context);
	}

	public interface IGameMenuActions
	{
		void OnBackOut(InputAction.CallbackContext context);

		void OnOpenProfile(InputAction.CallbackContext context);
	}

	public interface IChoiceMenuActions
	{
		void OnOpenGameMenu(InputAction.CallbackContext context);

		void OnChooseLeft(InputAction.CallbackContext context);

		void OnChooseRight(InputAction.CallbackContext context);
	}

	public interface ILobbyActions
	{
		void OnChooseLeft(InputAction.CallbackContext context);

		void OnChooseRight(InputAction.CallbackContext context);

		void OnConfirm(InputAction.CallbackContext context);

		void OnBackOut(InputAction.CallbackContext context);

		void OnOpenGameMenu(InputAction.CallbackContext context);
	}

	public interface IDialogueActions
	{
		void OnComplete(InputAction.CallbackContext context);
	}

	public interface ICreditsActions
	{
		void OnFastForward(InputAction.CallbackContext context);

		void OnExit(InputAction.CallbackContext context);
	}

	public interface IDebugCamActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnModifier(InputAction.CallbackContext context);

		void OnZoomIn(InputAction.CallbackContext context);

		void OnZoomOut(InputAction.CallbackContext context);
	}

	public interface IAlwaysActions
	{
		void OnPTT(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Game;

	private List<IGameActions> m_GameActionsCallbackInterfaces = new List<IGameActions>();

	private readonly InputAction m_Game_GrabRelease;

	private readonly InputAction m_Game_RaiseLower;

	private readonly InputAction m_Game_Steering;

	private readonly InputAction m_Game_Gas;

	private readonly InputAction m_Game_Brake;

	private readonly InputAction m_Game_Boost;

	private readonly InputAction m_Game_ToggleSteeringStyle;

	private readonly InputAction m_Game_StationPlace;

	private readonly InputAction m_Game_Drift;

	private readonly InputAction m_Game_Beep;

	private readonly InputAction m_Game_DMenuLeft;

	private readonly InputAction m_Game_DMenuRight;

	private readonly InputAction m_Game_OpenGameMenu;

	private readonly InputAction m_Game_UseBox;

	private readonly InputAction m_Game_TapTapMouseAxis;

	private readonly InputAction m_Game_ToggleTipTap;

	private readonly InputAction m_Game_SwipeUpTipTap;

	private readonly InputAction m_Game_SwipeDownTipTap;

	private readonly InputAction m_Game_SwipeRightTipTap;

	private readonly InputAction m_Game_SwipeLeftTipTap;

	private readonly InputAction m_Game_StationRotateClockwise;

	private readonly InputAction m_Game_StationRotateCounterClockwise;

	private readonly InputActionMap m_Game1;

	private List<IGame1Actions> m_Game1ActionsCallbackInterfaces = new List<IGame1Actions>();

	private readonly InputAction m_Game1_GrabRelease;

	private readonly InputAction m_Game1_RaiseLower;

	private readonly InputAction m_Game1_Steering;

	private readonly InputAction m_Game1_Gas;

	private readonly InputAction m_Game1_Brake;

	private readonly InputAction m_Game1_Boost;

	private readonly InputAction m_Game1_ToggleSteeringStyle;

	private readonly InputAction m_Game1_StationPlace;

	private readonly InputAction m_Game1_Drift;

	private readonly InputAction m_Game1_Beep;

	private readonly InputAction m_Game1_DMenuLeft;

	private readonly InputAction m_Game1_DMenuRight;

	private readonly InputAction m_Game1_OpenGameMenu;

	private readonly InputAction m_Game1_UseBox;

	private readonly InputAction m_Game1_TapTapMouseAxis;

	private readonly InputAction m_Game1_ToggleTipTap;

	private readonly InputAction m_Game1_SwipeUpTipTap;

	private readonly InputAction m_Game1_SwipeDownTipTap;

	private readonly InputAction m_Game1_SwipeRightTipTap;

	private readonly InputAction m_Game1_SwipeLeftTipTap;

	private readonly InputAction m_Game1_StationRotateClockwise;

	private readonly InputAction m_Game1_StationRotateCounterClockwise;

	private readonly InputActionMap m_Game2;

	private List<IGame2Actions> m_Game2ActionsCallbackInterfaces = new List<IGame2Actions>();

	private readonly InputAction m_Game2_GrabRelease;

	private readonly InputAction m_Game2_RaiseLower;

	private readonly InputAction m_Game2_Steering;

	private readonly InputAction m_Game2_Gas;

	private readonly InputAction m_Game2_Brake;

	private readonly InputAction m_Game2_Boost;

	private readonly InputAction m_Game2_ToggleSteeringStyle;

	private readonly InputAction m_Game2_StationPlace;

	private readonly InputAction m_Game2_Drift;

	private readonly InputAction m_Game2_Beep;

	private readonly InputAction m_Game2_DMenuLeft;

	private readonly InputAction m_Game2_DMenuRight;

	private readonly InputAction m_Game2_OpenGameMenu;

	private readonly InputAction m_Game2_UseBox;

	private readonly InputAction m_Game2_TapTapMouseAxis;

	private readonly InputAction m_Game2_ToggleTipTap;

	private readonly InputAction m_Game2_SwipeUpTipTap;

	private readonly InputAction m_Game2_SwipeDownTipTap;

	private readonly InputAction m_Game2_SwipeRightTipTap;

	private readonly InputAction m_Game2_SwipeLeftTipTap;

	private readonly InputAction m_Game2_StationRotateClockwise;

	private readonly InputAction m_Game2_StationRotateCounterClockwise;

	private readonly InputActionMap m_Game3;

	private List<IGame3Actions> m_Game3ActionsCallbackInterfaces = new List<IGame3Actions>();

	private readonly InputAction m_Game3_GrabRelease;

	private readonly InputAction m_Game3_RaiseLower;

	private readonly InputAction m_Game3_Steering;

	private readonly InputAction m_Game3_Gas;

	private readonly InputAction m_Game3_Brake;

	private readonly InputAction m_Game3_Boost;

	private readonly InputAction m_Game3_ToggleSteeringStyle;

	private readonly InputAction m_Game3_StationPlace;

	private readonly InputAction m_Game3_Drift;

	private readonly InputAction m_Game3_Beep;

	private readonly InputAction m_Game3_DMenuLeft;

	private readonly InputAction m_Game3_DMenuRight;

	private readonly InputAction m_Game3_OpenGameMenu;

	private readonly InputAction m_Game3_UseBox;

	private readonly InputAction m_Game3_TapTapMouseAxis;

	private readonly InputAction m_Game3_ToggleTipTap;

	private readonly InputAction m_Game3_SwipeUpTipTap;

	private readonly InputAction m_Game3_SwipeDownTipTap;

	private readonly InputAction m_Game3_SwipeRightTipTap;

	private readonly InputAction m_Game3_SwipeLeftTipTap;

	private readonly InputAction m_Game3_StationRotateClockwise;

	private readonly InputAction m_Game3_StationRotateCounterClockwise;

	private readonly InputActionMap m_Debug;

	private List<IDebugActions> m_DebugActionsCallbackInterfaces = new List<IDebugActions>();

	private readonly InputAction m_Debug_ToggleConsoleGamePad;

	private readonly InputAction m_Debug_ToggleConsoleKBM;

	private readonly InputAction m_Debug_ToggleDebugGraphs;

	private readonly InputAction m_Debug_PrintGraphicsRaycast;

	private readonly InputAction m_Debug_ToggleFreeCam;

	private readonly InputActionMap m_PopUp;

	private List<IPopUpActions> m_PopUpActionsCallbackInterfaces = new List<IPopUpActions>();

	private readonly InputAction m_PopUp_Close;

	private readonly InputActionMap m_QuotaReport;

	private List<IQuotaReportActions> m_QuotaReportActionsCallbackInterfaces = new List<IQuotaReportActions>();

	private readonly InputAction m_QuotaReport_Continue;

	private readonly InputAction m_QuotaReport_Skip;

	private readonly InputActionMap m_UnlockMenu;

	private List<IUnlockMenuActions> m_UnlockMenuActionsCallbackInterfaces = new List<IUnlockMenuActions>();

	private readonly InputAction m_UnlockMenu_Continue;

	private readonly InputActionMap m_OptionsMenu;

	private List<IOptionsMenuActions> m_OptionsMenuActionsCallbackInterfaces = new List<IOptionsMenuActions>();

	private readonly InputAction m_OptionsMenu_BackOut;

	private readonly InputActionMap m_GameMenu;

	private List<IGameMenuActions> m_GameMenuActionsCallbackInterfaces = new List<IGameMenuActions>();

	private readonly InputAction m_GameMenu_BackOut;

	private readonly InputAction m_GameMenu_OpenProfile;

	private readonly InputActionMap m_ChoiceMenu;

	private List<IChoiceMenuActions> m_ChoiceMenuActionsCallbackInterfaces = new List<IChoiceMenuActions>();

	private readonly InputAction m_ChoiceMenu_OpenGameMenu;

	private readonly InputAction m_ChoiceMenu_ChooseLeft;

	private readonly InputAction m_ChoiceMenu_ChooseRight;

	private readonly InputActionMap m_Lobby;

	private List<ILobbyActions> m_LobbyActionsCallbackInterfaces = new List<ILobbyActions>();

	private readonly InputAction m_Lobby_ChooseLeft;

	private readonly InputAction m_Lobby_ChooseRight;

	private readonly InputAction m_Lobby_Confirm;

	private readonly InputAction m_Lobby_BackOut;

	private readonly InputAction m_Lobby_OpenGameMenu;

	private readonly InputActionMap m_Dialogue;

	private List<IDialogueActions> m_DialogueActionsCallbackInterfaces = new List<IDialogueActions>();

	private readonly InputAction m_Dialogue_Complete;

	private readonly InputActionMap m_Credits;

	private List<ICreditsActions> m_CreditsActionsCallbackInterfaces = new List<ICreditsActions>();

	private readonly InputAction m_Credits_FastForward;

	private readonly InputAction m_Credits_Exit;

	private readonly InputActionMap m_DebugCam;

	private List<IDebugCamActions> m_DebugCamActionsCallbackInterfaces = new List<IDebugCamActions>();

	private readonly InputAction m_DebugCam_Move;

	private readonly InputAction m_DebugCam_Look;

	private readonly InputAction m_DebugCam_Modifier;

	private readonly InputAction m_DebugCam_ZoomIn;

	private readonly InputAction m_DebugCam_ZoomOut;

	private readonly InputActionMap m_Always;

	private List<IAlwaysActions> m_AlwaysActionsCallbackInterfaces = new List<IAlwaysActions>();

	private readonly InputAction m_Always_PTT;

	private int m_GamepadSchemeIndex = -1;

	private int m_KBMSchemeIndex = -1;

	public InputActionAsset asset { get; }

	public InputBinding? bindingMask
	{
		get
		{
			return asset.bindingMask;
		}
		set
		{
			asset.bindingMask = value;
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return asset.devices;
		}
		set
		{
			asset.devices = value;
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

	public IEnumerable<InputBinding> bindings => asset.bindings;

	public GameActions Game => new GameActions(this);

	public Game1Actions Game1 => new Game1Actions(this);

	public Game2Actions Game2 => new Game2Actions(this);

	public Game3Actions Game3 => new Game3Actions(this);

	public DebugActions Debug => new DebugActions(this);

	public PopUpActions PopUp => new PopUpActions(this);

	public QuotaReportActions QuotaReport => new QuotaReportActions(this);

	public UnlockMenuActions UnlockMenu => new UnlockMenuActions(this);

	public OptionsMenuActions OptionsMenu => new OptionsMenuActions(this);

	public GameMenuActions GameMenu => new GameMenuActions(this);

	public ChoiceMenuActions ChoiceMenu => new ChoiceMenuActions(this);

	public LobbyActions Lobby => new LobbyActions(this);

	public DialogueActions Dialogue => new DialogueActions(this);

	public CreditsActions Credits => new CreditsActions(this);

	public DebugCamActions DebugCam => new DebugCamActions(this);

	public AlwaysActions Always => new AlwaysActions(this);

	public InputControlScheme GamepadScheme
	{
		get
		{
			if (m_GamepadSchemeIndex == -1)
			{
				m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
			}
			return asset.controlSchemes[m_GamepadSchemeIndex];
		}
	}

	public InputControlScheme KBMScheme
	{
		get
		{
			if (m_KBMSchemeIndex == -1)
			{
				m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
			}
			return asset.controlSchemes[m_KBMSchemeIndex];
		}
	}

	public AggroInput()
	{
		asset = InputActionAsset.FromJson("{\r\n    \"name\": \"input-game\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Game\",\r\n            \"id\": \"c3339c1a-5d80-42ca-aaa8-9d6b20fee0e4\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"GrabRelease\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2fb5509a-48a5-4776-a690-89066874bc25\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RaiseLower\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"499f09bd-ff42-4d38-a285-25373cca3576\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Steering\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"dcab04d5-f013-41a1-bcc9-191a4e957caf\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gas\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"1134aff3-0344-42e8-bf54-a743ce5289c9\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Brake\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"e2a88a84-5e8c-4e08-9677-99619e7b45b4\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Boost\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0206ffc9-871a-4df1-a8e6-a4c7d1915611\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleSteeringStyle\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8b57517a-8f46-410c-97e1-5d10edb6a567\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationPlace\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"cde06e64-d345-472e-92cb-6273624064ba\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Drift\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"557f033c-54b6-4e8d-b547-f665ceec544b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Beep\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"6c4bfbc8-8584-4567-b80b-b0a80e6e9ad0\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuLeft\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"6721e73f-efcc-45d3-8f41-be21a2f8c2a9\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuRight\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c5e5ce78-7ba8-4570-8f2f-1805c26a273a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"OpenGameMenu\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"b8bf1df7-d06d-4071-bddd-4fd980b05f09\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"UseBox\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"effbd975-08e5-482a-9c91-7c077db7517e\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TapTapMouseAxis\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"986ed54f-f231-422d-96c4-c248f1f7fd3f\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ToggleTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"36db0cf0-709e-44d8-a2fe-dba729054cc7\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeUpTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"53c896dc-2973-4b46-af27-649b786bc10e\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeDownTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"d4805150-95f6-4bfe-85c6-f021d1638549\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeRightTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"1211bca0-1dba-43b3-a0c5-970e4e63d124\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeLeftTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"cf4802f3-a1b2-4531-b2bd-dfb807759155\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"24512af0-097a-4b98-ad85-b7f8fd26d3cd\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateCounterClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"86cc2b98-d095-4486-bd4b-635df4c7ae68\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"97f435c7-b2ce-4e62-83f0-0d699c33be3a\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4f16bf07-de8d-4624-b43d-60cc0e1b582a\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2c2b77e7-9e51-4daf-a01d-c1cf35517901\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"434294bb-88b6-4140-b1b1-74a3bc6d9755\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9372368c-bf21-44dc-94b8-ecd2e89429e1\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d5ae3f47-c1a5-49ed-857d-327ef513f23b\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6e84afb9-5096-4f71-9fe2-f8c753054d91\",\r\n                    \"path\": \"<Gamepad>/leftStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"219c1826-5a33-451e-9031-b5bebfb63f47\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"25b78a8a-b73b-4382-8910-80dec8dfc2a0\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"b7287f12-bbd3-436b-98fa-e185e7bbfc23\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"91e39913-ca2a-43b9-96c2-dea9b16d162c\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"b51a2fe4-58fc-48ae-8fc4-b68aa37ebc0f\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"24497b37-6385-4f06-9e84-987900ea00e4\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"929d4144-a710-497e-a7e9-a30fa8f61c69\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8712c0cc-77a3-4239-ab34-b25333772eb1\",\r\n                    \"path\": \"<Gamepad>/select\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c6ba91f0-bb90-4bd8-9d0b-742ce67383f1\",\r\n                    \"path\": \"<Keyboard>/tab\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a5f55fa0-2878-4a18-8e85-1acb98630b12\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f4ad5126-3d2d-425a-bbf5-60f3b08c61cd\",\r\n                    \"path\": \"<Gamepad>/dpad/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3c535271-4e36-4ad5-a51d-26d42de6cd51\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2acb4eb0-69f2-4c3b-9af1-2de867ed7054\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9d2c5fc6-8c07-4a4f-85e6-59c5600ed5e0\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ff8436f0-07db-46a6-bcb7-6cb18b8ed273\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"219126a4-1001-49da-97c4-881bd7e05ba4\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c1084d85-ed44-44a9-9005-6dc35898bb6e\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"dbb82ab7-97e8-4d3e-9146-fe1981b7e824\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"180109c0-2268-4ae7-b91d-f121716afad2\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"09650331-b258-40be-b0ec-ca85094879cd\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4f2a7309-cb07-41bd-8cb6-56e489732820\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b430a5c3-0eb0-47a7-bf28-b33f7addc965\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"280226f2-6daa-4969-b467-d002ec3f575a\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"054b60bf-cd98-4030-ac5f-9af8b8613f70\",\r\n                    \"path\": \"<Mouse>/scroll/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"TapTapMouseAxis\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8924b1f5-f814-4f73-8962-407105dabb23\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7c1a7ccc-01fb-4159-8471-b5db320ede98\",\r\n                    \"path\": \"<Keyboard>/t\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1393a228-5d4d-45a4-a410-e66d5786063d\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bb14e7c2-6102-4459-80fd-26a620cc5f90\",\r\n                    \"path\": \"<Mouse>/scroll/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2983b51b-7d5c-4f08-a426-715181c1f685\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"316fa1d7-6146-4667-a08d-621486d455db\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b3bc854c-1dce-4538-913f-654070ed2b27\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0751fa5d-79dc-42dd-b139-95697f9c6863\",\r\n                    \"path\": \"<Mouse>/scroll/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"91c6d656-f5dd-4f8d-8660-f08780bea790\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"33fe6dc8-a34f-4cde-8989-5f56b88d107a\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"41bd0b6e-3cef-410f-97df-8d51dba1fbd8\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8995cc2b-70ed-4a09-8eed-f99574a14643\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ed9c2b4e-f7bf-463a-b1ec-8fb18e8cb5b6\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1e1107e3-b67f-4952-ae34-64d026528daf\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Game1\",\r\n            \"id\": \"3355d567-6cc5-4480-bbb0-2a02b10eaea7\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"GrabRelease\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"21d4917e-9894-4329-90e6-aa285c4f5072\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RaiseLower\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0c6a7ff6-d90a-4760-842a-d26b886d0faf\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Steering\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"e88a79d6-78d0-4777-9783-6b1965f30b13\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gas\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"457ef961-9a78-4784-a29d-2c1069d29bc7\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Brake\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"a08a072f-3e42-41a4-a658-c788a5eab307\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Boost\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"3c4cd619-eb42-4ffe-bc6f-f0fa0612d4aa\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleSteeringStyle\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"6ef3f0d9-8070-4d22-9ddf-454f8f8ad64d\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationPlace\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c677df24-f791-4dc8-b9ac-5ccbb1349e5f\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Drift\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"eb7dd1a0-ce41-492f-aeae-431ce62e3ead\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Beep\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0a5868a7-5be8-4166-bc34-87a2271c916a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuLeft\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"541efcfd-9966-4f50-b21e-97778609956c\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuRight\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"04045503-3d5b-4bb0-9c7d-b5de0938661e\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"OpenGameMenu\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"d38de593-152f-4567-aa67-3a03705563a5\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"UseBox\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8ede5a1d-339e-4ccf-b436-d90cd314ef0a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TapTapMouseAxis\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"73a06079-a895-4b0d-857d-45df548a0780\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ToggleTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4a538973-87d8-4495-ac02-90dcbd2d4c3b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeUpTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"08366d2b-fdf0-4ad4-a7a7-2a8ef00785af\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeDownTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"b87ce95a-5a3a-4f39-ba1d-a269dbc13334\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeRightTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"3b287172-7321-4493-9191-2b5a4f48740a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeLeftTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"97ff201e-f6c2-43f2-8db8-146832e06a16\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"474ef1c4-4c8d-4cde-af83-6d7b5feed816\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateCounterClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"063baf00-30d9-414d-bf89-1156038f8739\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c7e1352e-3457-412d-b2f1-c6118585c95d\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bd02afc0-094d-4f43-b6c6-d9475462448b\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0efd655a-fa61-45ac-a6a0-5bc34871e99a\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"89684e30-dc31-4edf-9ce5-c21cbd15dbcc\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"95f17aa6-b0fa-4a96-98c7-253043a6d736\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2a0f403a-a7f2-46ae-8fdb-b3876edacb11\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"96852a08-7e20-42f7-9966-0f2173d8abe5\",\r\n                    \"path\": \"<Gamepad>/leftStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"7e5de308-014e-481f-afaf-9bbf8f447ee9\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"ffffdfe7-6c91-4d24-bc7a-1e1b509df322\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"6a91f1e5-91b4-4b77-9fdf-7043bd9e99ed\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"ab12eefa-ec07-415f-89ac-6baf2c190019\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"d38f9e5b-2959-420b-9763-9a76554d0f9c\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bddb3883-2f5d-444c-aacb-344f05024e00\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"aeb127e4-25ed-4b06-9785-7c0be5737d46\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6a35b003-a960-4b49-b7bc-4a9868af5f32\",\r\n                    \"path\": \"<Gamepad>/select\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4162fd54-03d5-477b-a50f-f914739347bc\",\r\n                    \"path\": \"<Keyboard>/tab\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8abede9a-fec8-4aac-a42a-0bf6d139c066\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"db2c3fb5-8a23-4afc-bc89-10df1e100792\",\r\n                    \"path\": \"<Gamepad>/dpad/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ffb32968-e91e-4f14-9068-263565d62d40\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7b6635f3-31c8-41dc-9e69-cf58af244df0\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a9c19cc2-14be-4f80-8ac5-850d2a0db4eb\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3471645d-30c5-4c16-97ca-2d0128417104\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a8fde7a1-186d-42cd-956c-2e1bf4f9f1f0\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d3d5e019-6b16-4866-8a96-765486ab06aa\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"28cb24b8-0ed7-4663-99d9-30b973217d8f\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"68e9ad95-914f-4345-9563-bb8220b559b6\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a2ec272c-f92d-4507-b483-b92570f70b0c\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"844ec81e-2b4f-4880-8372-38222ac09901\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b297d2c2-d8b9-4fca-abc4-956cd903552f\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b140bbe2-f639-4666-8d68-2e5507ecddec\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1f32f48b-eca9-40b7-a138-8e27cf1cb650\",\r\n                    \"path\": \"<Mouse>/scroll/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"TapTapMouseAxis\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"17dca848-bea1-4ac2-839c-f16f28ef91c2\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"80415efd-4134-4d25-bb46-689c4e3ecd5f\",\r\n                    \"path\": \"<Keyboard>/t\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"239c45e5-f571-42b4-8e90-260652ae0928\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f9b9982a-a896-45be-af77-91b892955204\",\r\n                    \"path\": \"<Mouse>/scroll/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7654ca5a-5d68-4fa0-8a03-99255523eb41\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"08a19211-818c-475e-a886-2b6019bbee20\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bb68d007-1261-4fe5-aa68-96a7728a0138\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d8c3813f-f288-4987-b762-32c7e051ba73\",\r\n                    \"path\": \"<Mouse>/scroll/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"64a6c14d-19ae-4cf6-93db-3349a372abc8\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3d83039a-070e-4b41-bdfe-6d2acc490dff\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a0155cb8-e2e7-4a44-8074-a64935b6e493\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"31b85b27-2b6a-44e3-a8c5-597f826d3be1\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7225d424-078a-4672-9bbe-50249c5608d7\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8a015262-060c-4778-bbce-400418030e50\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Game2\",\r\n            \"id\": \"4022a3bf-32f2-449d-bb4b-7869e6e4110a\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"GrabRelease\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"25885e6e-1f2d-4659-af98-e5e7dd6010ce\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RaiseLower\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"5fbb6a8f-9585-4875-871f-764a15538b59\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Steering\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"5eaaa403-b7a8-4f8d-ac93-636b43277656\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gas\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"ae2e3efe-f8d2-486d-b8a2-1c6f73b1a782\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Brake\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"8a8c71da-2dd2-4d30-b5fc-52c8831e6c8a\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Boost\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"254529c3-82b6-42bb-9cfa-796a367ec8d2\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleSteeringStyle\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c352990a-ef48-4fc5-af4a-20b0037eb6d8\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationPlace\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"d8075ae3-2bbd-44eb-82ef-f8a03f5b2850\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Drift\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"e9d4b6ed-5a23-494a-8450-7773ce4e6f4b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Beep\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"7dc2474c-5244-4ad1-bf04-66daab3d4d2b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuLeft\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"cc769230-50c5-4c3b-8485-84a935a1a9d1\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuRight\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"5706ec71-e532-4425-8f58-bda8afdddd6a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"OpenGameMenu\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"5bd827ef-7a96-425d-8be8-bb6058ee7ea8\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"UseBox\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2da3da66-7f54-4675-8c02-5f17955a7b31\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TapTapMouseAxis\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"bf3b86f4-6c2e-4847-8ac5-bb0e5f1ef2fe\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ToggleTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"7326c0f3-0771-479d-8b1a-d4f5fd30fad5\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeUpTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"45cc8570-4abc-490b-a92d-6035cc286c86\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeDownTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"5ac54519-f0bf-4062-8efd-a90e90b44165\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeRightTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"f64d0ffb-995d-495b-8914-fba1b17df6fa\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeLeftTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"53b28646-4a2c-496e-a4c0-18859365ec5f\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"ac79906c-a273-4580-ae3c-ef94a581fc63\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateCounterClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"a24d184b-e8e5-4f3b-8600-996995459347\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"97e6dc6c-f568-49a9-a9b5-2018b56015da\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6294bf81-ff7f-403e-9569-49b5af0ec7e0\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bb64ffaf-8aa5-40e5-bddb-14ae0151c8da\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4886ce48-4ab9-4e4d-9d46-f21b0c4a02a7\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"37e45fad-e285-4848-b384-7e9d0d033b58\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"320cf751-a1c5-4c8b-9dca-659b3caf02d6\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"daf20cd2-a482-48a0-80cd-6529874f5b39\",\r\n                    \"path\": \"<Gamepad>/leftStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"030f4c06-edc2-4b84-be7a-8b8797e78dc9\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"c5a22a1d-12e4-4bfa-b050-f34d358da163\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"eb9e15fc-3be6-4b1b-a759-b8a8697ecae0\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"14fa5080-d45f-496c-a9a4-d0ee38595bdf\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"2160dfe5-e39f-4e65-ae02-511125195f9d\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"5decbee3-014a-4064-bd4f-0a3f3f93bef0\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d2892625-cb1e-400d-8105-b810ed26cef9\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"64fffacd-f497-4f2c-aa8d-b00719dc381a\",\r\n                    \"path\": \"<Gamepad>/select\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f7e897dd-8306-472d-a46b-f6ec4560da23\",\r\n                    \"path\": \"<Keyboard>/tab\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d8a13525-3400-4520-92db-e28131d74838\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f9f6e5d3-89e0-4fda-bd05-1a53736c025e\",\r\n                    \"path\": \"<Gamepad>/dpad/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9db7dd67-0312-4899-8f00-2c9df5d06850\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"09d18a13-9094-4c43-80d7-4ccfa2f3bb7d\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"61c871ee-d998-4c9a-b47b-d7b070aea33a\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b7ea1cba-32fa-4273-bcfc-d47a96a54013\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1686f7fc-b827-4c5d-abc9-f7f26569a96b\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0998c0be-dae4-4e72-87ef-956daaa96a2c\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ee04ab81-e8fc-4dd7-ae5c-b42d0c484ec9\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"eabf9430-5ac1-447d-8091-e859d85f952b\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"408c4074-aeba-43ce-bd95-36958f9475de\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"dcf924cc-0dc5-4860-b12f-ec5a28f4daeb\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4b87bc09-0041-421d-821f-19bec8f35b87\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"63c3cbc7-e1f7-4c16-a03c-5d8dcd221eb7\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"76a3cf54-1766-4f1f-a6bd-6ca52e8c7054\",\r\n                    \"path\": \"<Mouse>/scroll/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"TapTapMouseAxis\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e37979e4-ebe3-4d61-8f33-77e4092ea573\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"efe34409-2fe8-4a9d-8496-2bf513e9193a\",\r\n                    \"path\": \"<Keyboard>/t\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"48d2f3bf-9de1-40e9-b4fb-750254b9ace0\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f7860593-49fa-4ec2-b5a9-adbdae220d42\",\r\n                    \"path\": \"<Mouse>/scroll/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"073b2d57-03ec-400a-87d2-cf9beef26121\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"46e6a5b1-a3ab-4f53-b7f9-458cdd2c1be4\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"16956cfb-fdca-4b0b-bb43-7fcbcf3f5463\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fc245432-e6cf-430b-8bbb-9739a1d664a2\",\r\n                    \"path\": \"<Mouse>/scroll/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b45e57e6-9378-437b-997d-8dd004940a5f\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f0f8a4be-c34f-45e7-8c1b-d07dddbc855b\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c632838e-f3d6-4605-bbc3-67cf11af4007\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c4166f9a-ffb1-467b-acd2-a7ac9eac62af\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f226d2d8-d63c-4ce5-8d7c-dc3ade37bdf5\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"98e5262f-1881-48c3-b5c6-677be2d21317\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Game3\",\r\n            \"id\": \"155dc02f-17f9-4abb-bcb8-560e4febfd2f\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"GrabRelease\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"fde5448d-da94-4f3a-afa5-ec9e7d44e4f3\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RaiseLower\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"9861c4eb-180d-41e1-abfe-8fb6ab0b5f4e\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Steering\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"f049abbe-9a74-4058-a00f-0d42ca32657a\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gas\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"018f2969-24a5-436d-8c05-cee7cdc34588\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Brake\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"e6805f6e-3920-4d75-ada8-905b3c6e132d\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Boost\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"707ea4ce-6843-4c84-bd4a-5ab7b727df43\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleSteeringStyle\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"d434ce90-c7d6-4fd1-83a0-341025a4a413\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationPlace\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"36502925-c338-4cfe-a90b-6528aab6d310\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Drift\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"149c348f-1500-41c2-8209-f693f108645d\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Beep\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"bf4ed748-7de1-45f1-97d6-29bc18bb40e7\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuLeft\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"dcbbc95c-47f0-410f-bb40-869ed4cc8d16\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DMenuRight\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"56dc06ca-5377-481a-885e-3c3b44e00523\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"OpenGameMenu\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"39c83213-4b7b-4dd6-a561-739aa81aeda6\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"UseBox\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8b0e063c-44ee-4ce5-bee2-46ad4396582a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TapTapMouseAxis\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"4941f833-dccf-44be-b40e-2622e911e7fe\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ToggleTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"6de0eeec-d524-4608-a7c4-a45f5fe3d60e\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeUpTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"28936778-403a-4d7c-b03f-7d219b78c835\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeDownTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"ac3914ad-092a-453f-a5d0-0ebfe7d8bdb3\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeRightTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"b7c66ce0-d8e3-4710-8e10-cae5422d2902\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"SwipeLeftTipTap\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"b185c1b4-9277-4b05-bf18-4930d7793750\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0ae28d59-005d-408e-b913-be274b18da1b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"StationRotateCounterClockwise\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2ce017dd-a4d8-41f2-b353-2781b096ef69\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"5ffdd6ec-ed4b-4bad-aa79-e41e611a44db\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c812ab16-01fe-49d4-b0b6-69c5d06a446e\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"GrabRelease\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6c86d7c9-716f-4250-944e-02f0acfcccd8\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a131a094-8009-4c29-a5ed-77478f373a93\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Brake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a1d0dd71-bd05-4784-a610-b4dd663a4a78\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"efe40953-ed11-4afd-bd93-b16b1f92be01\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Gas\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d96ea730-98a2-487b-bde2-f3791998286d\",\r\n                    \"path\": \"<Gamepad>/leftStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"46c2df81-2f0d-45e7-8c76-7fc64254f89f\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"978846ae-4a63-4cdc-bb41-d41202677cc2\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"7e50fe1b-0d21-48d4-a66b-147b86a39a3c\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"dffe6cf9-f7c7-4d46-9b1b-2ae5026605e8\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"eb45bc5b-397b-4333-a400-5baa2234cb8c\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ceb15e56-075e-4e0e-a068-27f46658a8b2\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d812db08-a434-45be-826c-95dbb2809320\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"RaiseLower\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"971427fb-c76d-4a21-b4eb-f9f59a6a10ef\",\r\n                    \"path\": \"<Gamepad>/select\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ffc14039-d12b-4e85-81bf-05f44e881b04\",\r\n                    \"path\": \"<Keyboard>/tab\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleSteeringStyle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ad4f71ce-c689-476f-a92e-f94a9926dd6e\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fea13ade-7a01-4552-8181-346d8ae1da2c\",\r\n                    \"path\": \"<Gamepad>/dpad/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationPlace\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ab2d49be-7fac-4716-bdec-4f8a14ad2055\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e15cfb0f-e581-441f-acb0-84fe0f7c08b0\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Drift\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"179897cf-f4fd-485e-b045-b413295b4469\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f98c04a0-4d53-4f93-997d-107755c11ee7\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Beep\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fe734014-10fd-4cf5-b14e-bf4dfe053753\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2c804a73-516f-455a-9356-11f85f96df04\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d42bd4c2-3645-4f14-898c-6da6244d7a0d\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f18988ce-c942-4809-b32d-4fba136822b8\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"DMenuRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"aa4b89a3-4358-4e96-a01a-eb2baddcf258\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fdf45de4-7627-4b67-9ab7-f1bf5b6a41ca\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"92468730-0405-4874-b21e-d9753cd0af9c\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"10373773-5630-4e34-bef2-6746d8ea8366\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"UseBox\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"06f8b392-8f9e-4268-b9ae-ef9ee1a1348a\",\r\n                    \"path\": \"<Mouse>/scroll/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"TapTapMouseAxis\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1d4a7ba7-5945-4b48-9deb-81e394f8956c\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8f908412-282e-4fbc-8f63-4dced5bd64ad\",\r\n                    \"path\": \"<Keyboard>/t\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ToggleTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3b27201f-0c77-440c-87ea-98461ea72450\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2b4d5e6a-0c1d-476b-8041-23b477ddf42d\",\r\n                    \"path\": \"<Mouse>/scroll/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeUpTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7b0b4a02-0fbf-46d9-8a3a-0bd5c6248871\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c86b11c5-8f65-40ff-9658-b4c867a416ac\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeRightTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ad20b36e-df6f-489d-b420-3723c02b5776\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fcb904da-df01-40f5-871b-a6d9e7483174\",\r\n                    \"path\": \"<Mouse>/scroll/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeDownTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"859d6412-c552-4839-bdea-c298328ac8ed\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f2e12d45-8c2c-40a8-97bc-23c03461616d\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"SwipeLeftTipTap\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"853786e4-43fc-4e16-8c2b-583eb97b2156\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8046c5c7-92e1-4bff-9eb2-4b7225d03bff\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9e4d6b4c-3611-46e5-a0e8-700d72715bd7\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"46d84b97-d874-4e1c-a8d0-c816120637b7\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"StationRotateCounterClockwise\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Debug\",\r\n            \"id\": \"e71c538b-ef92-49ae-96dc-cb59481d5bcc\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"ToggleConsoleGamePad\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"247e0888-0f09-47ce-86e6-4352f0363305\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleConsoleKBM\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2f85b444-cb79-472e-939a-245544e47c02\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleDebugGraphs\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"3ec86097-fcbf-49c1-a7fe-1af99ca37563\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"PrintGraphicsRaycast\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"a93a1718-8533-4a8e-a808-ffce31881e4a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleFreeCam\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c904b414-fdf7-449a-9b50-8f1b49bc8465\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"5c5db846-ce2c-4e0e-8fcd-8251629ee2f0\",\r\n                    \"path\": \"<Keyboard>/backquote\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM;Gamepad\",\r\n                    \"action\": \"ToggleConsoleKBM\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"29d82bd1-ced9-4b4d-8684-7e9e817c1bc3\",\r\n                    \"path\": \"<Gamepad>/select\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM;Gamepad\",\r\n                    \"action\": \"ToggleConsoleGamePad\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"dcc30429-ce4f-4e7c-ac86-bf317807ddff\",\r\n                    \"path\": \"<Keyboard>/f7\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad;KBM\",\r\n                    \"action\": \"ToggleDebugGraphs\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2e488866-f5bf-41f8-9ccd-9643024f4530\",\r\n                    \"path\": \"<Keyboard>/f8\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad;KBM\",\r\n                    \"action\": \"PrintGraphicsRaycast\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"30161529-cde3-4e92-b89c-758554504649\",\r\n                    \"path\": \"<Keyboard>/f9\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad;KBM\",\r\n                    \"action\": \"ToggleFreeCam\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"PopUp\",\r\n            \"id\": \"d64197e8-419f-4333-9379-eddb679234b6\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Close\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2b0e12e4-6ceb-4cd7-96f8-a4e5a3111cce\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"180904f9-3a4d-4f62-9992-c59ea61491a0\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Close\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"62406ac0-2308-4d4b-88a8-4419c681da3c\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Close\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"QuotaReport\",\r\n            \"id\": \"5e51b4d0-fe29-42b5-aace-37b585539667\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Continue\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"06aa60c0-1ef6-4f0d-a4dc-63b597ea6401\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Skip\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"1428d951-d8b7-48c2-9413-56c4590bb654\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b5832045-f403-4ab8-938b-332abc103300\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Continue\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"becc36f8-72c9-4136-baf5-99b00650adee\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Continue\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"05e650c7-265d-4d07-b5d1-dbae104f241d\",\r\n                    \"path\": \"<Keyboard>/anyKey\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Skip\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f4c305be-1f6b-4a87-8ed8-d615cb790020\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Skip\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"UnlockMenu\",\r\n            \"id\": \"18af2725-7e2d-4a37-b335-3e6a075a8003\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Continue\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"052b2d59-a73d-4e99-9196-2e53f334138f\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3de22e46-b4b3-4ab1-87d6-d8802159825e\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Continue\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"04f8f8cc-4e3c-410e-92eb-e4379fe00c18\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Continue\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"OptionsMenu\",\r\n            \"id\": \"cf75803b-8539-4311-a1dd-443e5200d15e\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"BackOut\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"9f9ab193-feac-4bd2-9d71-a08ebd72ef6c\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0a7647d3-32ff-41f8-b7d8-02e0c95a500e\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"BackOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"92267198-6999-4dfa-9bad-fced65d6a49a\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"BackOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3f7bd583-2dd2-4554-b727-af8fcd669ada\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"BackOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"GameMenu\",\r\n            \"id\": \"bcd23e0b-65c8-4e05-9237-d00f2771f791\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"BackOut\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"e4598120-c033-4629-828a-a0afffd05bfa\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"OpenProfile\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4e2598f6-9f6e-4e0e-bd2e-4c3b76dfb552\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1b676d04-f182-4cc2-8383-d85861e9799e\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"BackOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a0b0ebaa-d9ce-47a6-90da-3d22b6ecfb35\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"BackOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8ac7bbdf-1778-472f-b8a7-23fe6e748b4a\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"BackOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f706c3bb-a08c-4958-a882-e3151eb1b807\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"OpenProfile\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"ChoiceMenu\",\r\n            \"id\": \"1c7a77a8-0960-438d-807c-9932721dfb20\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"OpenGameMenu\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"347b104a-2127-4912-9f37-c58839b2264a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ChooseLeft\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"07f2c854-6d72-4a68-a817-37793d57111d\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ChooseRight\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8b25800f-3011-4300-96e8-21fb3120f904\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6a85e00b-7b50-418a-8d4b-f0643da4044b\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ChooseLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"dbd26c47-a0d2-4b90-b521-302ee8b55c2e\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ChooseLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"794733f8-0d7a-474c-a0c3-74c97f327783\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChooseLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"37f21790-f430-4208-b42e-4663629c8c44\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ChooseRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"20388625-9e7f-4df1-9827-1c2cd14866f2\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ChooseRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c6ed6022-c1c1-4007-9a1e-eb2077772764\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChooseRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c9bb9d17-c0f8-4c58-8b7a-b6d274baddae\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"97600bac-da7c-4486-95db-3d8af90a4912\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Lobby\",\r\n            \"id\": \"abb1a5ca-af3e-459a-bd3c-a7227d602822\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"ChooseLeft\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"22e3f541-49ea-4955-a543-5fd21a829694\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ChooseRight\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"17a2b642-9ae6-42db-8507-07ad76d39a66\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Confirm\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"00126d24-697d-49dd-9425-d646bfe3289b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"BackOut\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"fc3b0294-b584-4de0-92fd-a84ba53f82fc\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"OpenGameMenu\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"bff763f6-18c5-4237-bafc-8f8c8a078c84\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fe69c7bb-bde7-487e-abef-6695db3ea034\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ChooseLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d5b9f936-0d33-4bac-bbe6-91685a96d1b5\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ChooseLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"5e024326-5604-4268-addf-3c78f84b1aeb\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChooseLeft\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d673b698-1c87-4c97-8971-a4a21d1aab3c\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ChooseRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f4c2cb7c-f049-4f62-9d60-2966262a986f\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ChooseRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fc7b0c04-2c7e-4fc3-b0ce-5445d6df065e\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChooseRight\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"979aa76c-3f11-4032-860f-3fca06109b16\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Confirm\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"12ff8bcd-60af-42d2-9155-c19e2d258b16\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Confirm\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f00db3d4-5bae-486f-8c94-2fc84d1f4f92\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"BackOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ef198160-5afe-4e14-8339-522f0398d7b4\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"40456283-cd2c-42fa-a05b-3f40d3989c29\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"OpenGameMenu\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Dialogue\",\r\n            \"id\": \"02c7cdaf-8a10-4a19-b586-d89b3860d03e\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Complete\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"82bb53d2-758a-492b-9c40-e27d63004ba0\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ee8974d7-584d-4310-b523-28f6b538f80b\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Complete\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9b1a024d-ee79-45b5-8e12-2f68d3d0d390\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Complete\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"90ecb2a7-2278-4490-9f01-4a1a8ae72a6b\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Complete\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Credits\",\r\n            \"id\": \"b359a915-d1b9-4a9f-8caf-f74008d59954\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"FastForward\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"473c99b3-756f-4f18-867a-b033b3f6aa96\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Exit\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c2ac6dda-a9ef-422b-8e05-17155a7f0470\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"066f633f-8091-4ad5-89b6-8cda97ceb95d\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"FastForward\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a3698bbf-1370-4dec-95e5-67cb26c5239a\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"FastForward\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"55e67ffe-19a6-4433-aa61-d67b733c0975\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"FastForward\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6859ca4a-5424-451c-b4a1-eac2e59481c3\",\r\n                    \"path\": \"<Keyboard>/escape\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Exit\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"215c451a-1cb2-4013-ae46-5aa7cec96192\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Exit\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"DebugCam\",\r\n            \"id\": \"f5c5627b-7458-4c14-a4f3-e9a17c701fb2\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Move\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"55b694cb-8f34-44b8-bb15-2021d8282d1c\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Look\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"9988e9f2-5d61-4b70-a611-feba9fe19507\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Modifier\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2e7684d3-ee24-4122-a770-b0e131d9ed78\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ZoomIn\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"24f91634-efc0-4092-9588-7df060571b38\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ZoomOut\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"bbb2a9c7-d70d-4007-baa4-b387828dde11\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7ba383b7-f63f-4263-b36d-5f0e26e1997f\",\r\n                    \"path\": \"<Gamepad>/leftStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"d1dedb30-eb61-4343-aa6d-a799dbf5be4d\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"6b35ab7d-cae9-418e-97b7-1dfceae15c36\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"8bb891de-48ef-4545-afb9-59dc4941eb23\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"39ac45ea-e7e1-48c0-a19d-e7858ea5ab52\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"b12dbf37-d06e-4dbe-8c08-84b46678c622\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"eccd8e20-5317-40ea-8da9-77f461d88f6d\",\r\n                    \"path\": \"<Mouse>/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Look\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fa0769e9-5dc0-4dca-91ce-64ff8ce0aa48\",\r\n                    \"path\": \"<Gamepad>/rightStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Look\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9da9aa8e-8e05-49bb-9c31-493e42c11c03\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"Modifier\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"cf9bab06-9af9-46f3-91b3-5e3f3c46dbec\",\r\n                    \"path\": \"<Mouse>/scroll/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ZoomIn\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4ca99d5f-8369-4aa7-be2d-192e0f0cc79d\",\r\n                    \"path\": \"<Mouse>/scroll/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"ZoomOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Always\",\r\n            \"id\": \"c3dc106a-2617-4604-9c53-047c6238ce00\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"PTT\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0948f0b3-b075-452a-9a98-0090e9ffbbc3\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"594705d9-79be-4068-9793-6894c8167bba\",\r\n                    \"path\": \"<Keyboard>/v\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"KBM\",\r\n                    \"action\": \"PTT\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ce5890af-18d2-41de-8820-f21ad8ace84c\",\r\n                    \"path\": \"<Gamepad>/rightStickPress\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"PTT\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": [\r\n        {\r\n            \"name\": \"Gamepad\",\r\n            \"bindingGroup\": \"Gamepad\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Gamepad>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"KBM\",\r\n            \"bindingGroup\": \"KBM\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Keyboard>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                },\r\n                {\r\n                    \"devicePath\": \"<Mouse>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        }\r\n    ]\r\n}");
		m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
		m_Game_GrabRelease = m_Game.FindAction("GrabRelease", throwIfNotFound: true);
		m_Game_RaiseLower = m_Game.FindAction("RaiseLower", throwIfNotFound: true);
		m_Game_Steering = m_Game.FindAction("Steering", throwIfNotFound: true);
		m_Game_Gas = m_Game.FindAction("Gas", throwIfNotFound: true);
		m_Game_Brake = m_Game.FindAction("Brake", throwIfNotFound: true);
		m_Game_Boost = m_Game.FindAction("Boost", throwIfNotFound: true);
		m_Game_ToggleSteeringStyle = m_Game.FindAction("ToggleSteeringStyle", throwIfNotFound: true);
		m_Game_StationPlace = m_Game.FindAction("StationPlace", throwIfNotFound: true);
		m_Game_Drift = m_Game.FindAction("Drift", throwIfNotFound: true);
		m_Game_Beep = m_Game.FindAction("Beep", throwIfNotFound: true);
		m_Game_DMenuLeft = m_Game.FindAction("DMenuLeft", throwIfNotFound: true);
		m_Game_DMenuRight = m_Game.FindAction("DMenuRight", throwIfNotFound: true);
		m_Game_OpenGameMenu = m_Game.FindAction("OpenGameMenu", throwIfNotFound: true);
		m_Game_UseBox = m_Game.FindAction("UseBox", throwIfNotFound: true);
		m_Game_TapTapMouseAxis = m_Game.FindAction("TapTapMouseAxis", throwIfNotFound: true);
		m_Game_ToggleTipTap = m_Game.FindAction("ToggleTipTap", throwIfNotFound: true);
		m_Game_SwipeUpTipTap = m_Game.FindAction("SwipeUpTipTap", throwIfNotFound: true);
		m_Game_SwipeDownTipTap = m_Game.FindAction("SwipeDownTipTap", throwIfNotFound: true);
		m_Game_SwipeRightTipTap = m_Game.FindAction("SwipeRightTipTap", throwIfNotFound: true);
		m_Game_SwipeLeftTipTap = m_Game.FindAction("SwipeLeftTipTap", throwIfNotFound: true);
		m_Game_StationRotateClockwise = m_Game.FindAction("StationRotateClockwise", throwIfNotFound: true);
		m_Game_StationRotateCounterClockwise = m_Game.FindAction("StationRotateCounterClockwise", throwIfNotFound: true);
		m_Game1 = asset.FindActionMap("Game1", throwIfNotFound: true);
		m_Game1_GrabRelease = m_Game1.FindAction("GrabRelease", throwIfNotFound: true);
		m_Game1_RaiseLower = m_Game1.FindAction("RaiseLower", throwIfNotFound: true);
		m_Game1_Steering = m_Game1.FindAction("Steering", throwIfNotFound: true);
		m_Game1_Gas = m_Game1.FindAction("Gas", throwIfNotFound: true);
		m_Game1_Brake = m_Game1.FindAction("Brake", throwIfNotFound: true);
		m_Game1_Boost = m_Game1.FindAction("Boost", throwIfNotFound: true);
		m_Game1_ToggleSteeringStyle = m_Game1.FindAction("ToggleSteeringStyle", throwIfNotFound: true);
		m_Game1_StationPlace = m_Game1.FindAction("StationPlace", throwIfNotFound: true);
		m_Game1_Drift = m_Game1.FindAction("Drift", throwIfNotFound: true);
		m_Game1_Beep = m_Game1.FindAction("Beep", throwIfNotFound: true);
		m_Game1_DMenuLeft = m_Game1.FindAction("DMenuLeft", throwIfNotFound: true);
		m_Game1_DMenuRight = m_Game1.FindAction("DMenuRight", throwIfNotFound: true);
		m_Game1_OpenGameMenu = m_Game1.FindAction("OpenGameMenu", throwIfNotFound: true);
		m_Game1_UseBox = m_Game1.FindAction("UseBox", throwIfNotFound: true);
		m_Game1_TapTapMouseAxis = m_Game1.FindAction("TapTapMouseAxis", throwIfNotFound: true);
		m_Game1_ToggleTipTap = m_Game1.FindAction("ToggleTipTap", throwIfNotFound: true);
		m_Game1_SwipeUpTipTap = m_Game1.FindAction("SwipeUpTipTap", throwIfNotFound: true);
		m_Game1_SwipeDownTipTap = m_Game1.FindAction("SwipeDownTipTap", throwIfNotFound: true);
		m_Game1_SwipeRightTipTap = m_Game1.FindAction("SwipeRightTipTap", throwIfNotFound: true);
		m_Game1_SwipeLeftTipTap = m_Game1.FindAction("SwipeLeftTipTap", throwIfNotFound: true);
		m_Game1_StationRotateClockwise = m_Game1.FindAction("StationRotateClockwise", throwIfNotFound: true);
		m_Game1_StationRotateCounterClockwise = m_Game1.FindAction("StationRotateCounterClockwise", throwIfNotFound: true);
		m_Game2 = asset.FindActionMap("Game2", throwIfNotFound: true);
		m_Game2_GrabRelease = m_Game2.FindAction("GrabRelease", throwIfNotFound: true);
		m_Game2_RaiseLower = m_Game2.FindAction("RaiseLower", throwIfNotFound: true);
		m_Game2_Steering = m_Game2.FindAction("Steering", throwIfNotFound: true);
		m_Game2_Gas = m_Game2.FindAction("Gas", throwIfNotFound: true);
		m_Game2_Brake = m_Game2.FindAction("Brake", throwIfNotFound: true);
		m_Game2_Boost = m_Game2.FindAction("Boost", throwIfNotFound: true);
		m_Game2_ToggleSteeringStyle = m_Game2.FindAction("ToggleSteeringStyle", throwIfNotFound: true);
		m_Game2_StationPlace = m_Game2.FindAction("StationPlace", throwIfNotFound: true);
		m_Game2_Drift = m_Game2.FindAction("Drift", throwIfNotFound: true);
		m_Game2_Beep = m_Game2.FindAction("Beep", throwIfNotFound: true);
		m_Game2_DMenuLeft = m_Game2.FindAction("DMenuLeft", throwIfNotFound: true);
		m_Game2_DMenuRight = m_Game2.FindAction("DMenuRight", throwIfNotFound: true);
		m_Game2_OpenGameMenu = m_Game2.FindAction("OpenGameMenu", throwIfNotFound: true);
		m_Game2_UseBox = m_Game2.FindAction("UseBox", throwIfNotFound: true);
		m_Game2_TapTapMouseAxis = m_Game2.FindAction("TapTapMouseAxis", throwIfNotFound: true);
		m_Game2_ToggleTipTap = m_Game2.FindAction("ToggleTipTap", throwIfNotFound: true);
		m_Game2_SwipeUpTipTap = m_Game2.FindAction("SwipeUpTipTap", throwIfNotFound: true);
		m_Game2_SwipeDownTipTap = m_Game2.FindAction("SwipeDownTipTap", throwIfNotFound: true);
		m_Game2_SwipeRightTipTap = m_Game2.FindAction("SwipeRightTipTap", throwIfNotFound: true);
		m_Game2_SwipeLeftTipTap = m_Game2.FindAction("SwipeLeftTipTap", throwIfNotFound: true);
		m_Game2_StationRotateClockwise = m_Game2.FindAction("StationRotateClockwise", throwIfNotFound: true);
		m_Game2_StationRotateCounterClockwise = m_Game2.FindAction("StationRotateCounterClockwise", throwIfNotFound: true);
		m_Game3 = asset.FindActionMap("Game3", throwIfNotFound: true);
		m_Game3_GrabRelease = m_Game3.FindAction("GrabRelease", throwIfNotFound: true);
		m_Game3_RaiseLower = m_Game3.FindAction("RaiseLower", throwIfNotFound: true);
		m_Game3_Steering = m_Game3.FindAction("Steering", throwIfNotFound: true);
		m_Game3_Gas = m_Game3.FindAction("Gas", throwIfNotFound: true);
		m_Game3_Brake = m_Game3.FindAction("Brake", throwIfNotFound: true);
		m_Game3_Boost = m_Game3.FindAction("Boost", throwIfNotFound: true);
		m_Game3_ToggleSteeringStyle = m_Game3.FindAction("ToggleSteeringStyle", throwIfNotFound: true);
		m_Game3_StationPlace = m_Game3.FindAction("StationPlace", throwIfNotFound: true);
		m_Game3_Drift = m_Game3.FindAction("Drift", throwIfNotFound: true);
		m_Game3_Beep = m_Game3.FindAction("Beep", throwIfNotFound: true);
		m_Game3_DMenuLeft = m_Game3.FindAction("DMenuLeft", throwIfNotFound: true);
		m_Game3_DMenuRight = m_Game3.FindAction("DMenuRight", throwIfNotFound: true);
		m_Game3_OpenGameMenu = m_Game3.FindAction("OpenGameMenu", throwIfNotFound: true);
		m_Game3_UseBox = m_Game3.FindAction("UseBox", throwIfNotFound: true);
		m_Game3_TapTapMouseAxis = m_Game3.FindAction("TapTapMouseAxis", throwIfNotFound: true);
		m_Game3_ToggleTipTap = m_Game3.FindAction("ToggleTipTap", throwIfNotFound: true);
		m_Game3_SwipeUpTipTap = m_Game3.FindAction("SwipeUpTipTap", throwIfNotFound: true);
		m_Game3_SwipeDownTipTap = m_Game3.FindAction("SwipeDownTipTap", throwIfNotFound: true);
		m_Game3_SwipeRightTipTap = m_Game3.FindAction("SwipeRightTipTap", throwIfNotFound: true);
		m_Game3_SwipeLeftTipTap = m_Game3.FindAction("SwipeLeftTipTap", throwIfNotFound: true);
		m_Game3_StationRotateClockwise = m_Game3.FindAction("StationRotateClockwise", throwIfNotFound: true);
		m_Game3_StationRotateCounterClockwise = m_Game3.FindAction("StationRotateCounterClockwise", throwIfNotFound: true);
		m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
		m_Debug_ToggleConsoleGamePad = m_Debug.FindAction("ToggleConsoleGamePad", throwIfNotFound: true);
		m_Debug_ToggleConsoleKBM = m_Debug.FindAction("ToggleConsoleKBM", throwIfNotFound: true);
		m_Debug_ToggleDebugGraphs = m_Debug.FindAction("ToggleDebugGraphs", throwIfNotFound: true);
		m_Debug_PrintGraphicsRaycast = m_Debug.FindAction("PrintGraphicsRaycast", throwIfNotFound: true);
		m_Debug_ToggleFreeCam = m_Debug.FindAction("ToggleFreeCam", throwIfNotFound: true);
		m_PopUp = asset.FindActionMap("PopUp", throwIfNotFound: true);
		m_PopUp_Close = m_PopUp.FindAction("Close", throwIfNotFound: true);
		m_QuotaReport = asset.FindActionMap("QuotaReport", throwIfNotFound: true);
		m_QuotaReport_Continue = m_QuotaReport.FindAction("Continue", throwIfNotFound: true);
		m_QuotaReport_Skip = m_QuotaReport.FindAction("Skip", throwIfNotFound: true);
		m_UnlockMenu = asset.FindActionMap("UnlockMenu", throwIfNotFound: true);
		m_UnlockMenu_Continue = m_UnlockMenu.FindAction("Continue", throwIfNotFound: true);
		m_OptionsMenu = asset.FindActionMap("OptionsMenu", throwIfNotFound: true);
		m_OptionsMenu_BackOut = m_OptionsMenu.FindAction("BackOut", throwIfNotFound: true);
		m_GameMenu = asset.FindActionMap("GameMenu", throwIfNotFound: true);
		m_GameMenu_BackOut = m_GameMenu.FindAction("BackOut", throwIfNotFound: true);
		m_GameMenu_OpenProfile = m_GameMenu.FindAction("OpenProfile", throwIfNotFound: true);
		m_ChoiceMenu = asset.FindActionMap("ChoiceMenu", throwIfNotFound: true);
		m_ChoiceMenu_OpenGameMenu = m_ChoiceMenu.FindAction("OpenGameMenu", throwIfNotFound: true);
		m_ChoiceMenu_ChooseLeft = m_ChoiceMenu.FindAction("ChooseLeft", throwIfNotFound: true);
		m_ChoiceMenu_ChooseRight = m_ChoiceMenu.FindAction("ChooseRight", throwIfNotFound: true);
		m_Lobby = asset.FindActionMap("Lobby", throwIfNotFound: true);
		m_Lobby_ChooseLeft = m_Lobby.FindAction("ChooseLeft", throwIfNotFound: true);
		m_Lobby_ChooseRight = m_Lobby.FindAction("ChooseRight", throwIfNotFound: true);
		m_Lobby_Confirm = m_Lobby.FindAction("Confirm", throwIfNotFound: true);
		m_Lobby_BackOut = m_Lobby.FindAction("BackOut", throwIfNotFound: true);
		m_Lobby_OpenGameMenu = m_Lobby.FindAction("OpenGameMenu", throwIfNotFound: true);
		m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
		m_Dialogue_Complete = m_Dialogue.FindAction("Complete", throwIfNotFound: true);
		m_Credits = asset.FindActionMap("Credits", throwIfNotFound: true);
		m_Credits_FastForward = m_Credits.FindAction("FastForward", throwIfNotFound: true);
		m_Credits_Exit = m_Credits.FindAction("Exit", throwIfNotFound: true);
		m_DebugCam = asset.FindActionMap("DebugCam", throwIfNotFound: true);
		m_DebugCam_Move = m_DebugCam.FindAction("Move", throwIfNotFound: true);
		m_DebugCam_Look = m_DebugCam.FindAction("Look", throwIfNotFound: true);
		m_DebugCam_Modifier = m_DebugCam.FindAction("Modifier", throwIfNotFound: true);
		m_DebugCam_ZoomIn = m_DebugCam.FindAction("ZoomIn", throwIfNotFound: true);
		m_DebugCam_ZoomOut = m_DebugCam.FindAction("ZoomOut", throwIfNotFound: true);
		m_Always = asset.FindActionMap("Always", throwIfNotFound: true);
		m_Always_PTT = m_Always.FindAction("PTT", throwIfNotFound: true);
	}

	public void Dispose()
	{
		UnityEngine.Object.Destroy(asset);
	}

	public bool Contains(InputAction action)
	{
		return asset.Contains(action);
	}

	public IEnumerator<InputAction> GetEnumerator()
	{
		return asset.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Enable()
	{
		asset.Enable();
	}

	public void Disable()
	{
		asset.Disable();
	}

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return asset.FindAction(actionNameOrId, throwIfNotFound);
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		return asset.FindBinding(bindingMask, out action);
	}
}
