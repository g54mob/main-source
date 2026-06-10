using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WizcardsApp : CruncherAppContent
{
	[CompilerGenerated]
	private sealed class _003CCO_EnemyTurn_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WizcardsApp _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCO_EnemyTurn_003Ed__26(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWarTurn_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WizcardsApp _003C_003E4__this;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CWarTurn_003Ed__28(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public WizcardEnemyPlayer enemyPlayer;

	public Wizcard selectedWizcard;

	public List<Wizcard> wizcards;

	public List<BoardSpace> boardSpaces;

	public TextMeshProUGUI titleText;

	public TextMeshProUGUI infoText;

	public RawImage actorImage;

	public WizcardPlayer player;

	public bool currentlyAnimating;

	public bool isPlayerTurn;

	public GameObject crystalWizcard;

	public Wizcard playersCrystal;

	public Wizcard enemiesCrystal;

	public MatchEndText matchEndText;

	public GameObject MainMenuScene;

	public GameObject MatchScene;

	public GameObject EndTurnButton;

	public DrawPile drawPile;

	[Space(7f)]
	[Header("Feedback")]
	public JuiceController manaBarJuice;

	public JuiceController manaStarJuice;

	public JuiceController deckPileJuice;

	public AudioEvent lowManaAudioEvent;

	private bool completedWarTurn;

	public void StartMatch()
	{
	}

	public void PlayerTurn()
	{
	}

	public void EnemyTurn()
	{
	}

	[IteratorStateMachine(typeof(_003CCO_EnemyTurn_003Ed__26))]
	private IEnumerator CO_EnemyTurn()
	{
		return null;
	}

	public List<BoardSpace> UnoccupiedEnemyTerritory()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWarTurn_003Ed__28))]
	[Button(null, EButtonEnableMode.Always)]
	public IEnumerator WarTurn()
	{
		return null;
	}

	public void Concede()
	{
	}

	public void GoToMainMenu()
	{
	}

	public void ExitButton()
	{
	}
}
