using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class BackButtonController : MonoBehaviour
	{
		public static BackButtonController Instance;

		public static bool BackButtonClosesPage;

		public static bool IgnoreNextAdditionalListner;

		public bool ListenForControllerInput;

		private SignalBus _signalBus;

		private SelectableUI _selectable;

		private Selectable _rawSelectable;

		private Rewired.Player Player;

		private MultiplayerManager _multiplayer;

		private List<Action> _backtions;

		[SerializeField]
		private GameObject randomize;

		[SerializeField]
		private GameObject musicSelection;

		[Inject]
		private void Construct(SignalBus signal, MultiplayerManager multi)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public static void AddListener(Action b)
		{
		}

		public static void TryRemoveListener(Action b)
		{
		}

		private void RunLastAction()
		{
		}

		public static void FireBack()
		{
		}

		public static void GoBack()
		{
		}

		private void Show(UISignals.ShowBackButtonSignal sig)
		{
		}

		private void SetNavigation(UISignals.ForceBackButtonNavigation sig)
		{
		}

		private void ResetNavigation(UISignals.ResetBackButtonNavigation sig)
		{
		}

		private void Hide()
		{
		}
	}
}
