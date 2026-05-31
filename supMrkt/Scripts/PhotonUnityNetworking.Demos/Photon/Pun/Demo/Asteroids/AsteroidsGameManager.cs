using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Asteroids
{
	public class AsteroidsGameManager : MonoBehaviourPunCallbacks
	{
		[CompilerGenerated]
		private sealed class _003CEndOfGame_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AsteroidsGameManager _003C_003E4__this;

			public string winner;

			public int score;

			private float _003Ctimer_003E5__2;

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
			public _003CEndOfGame_003Ed__8(int _003C_003E1__state)
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
		private sealed class _003CSpawnAsteroid_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CSpawnAsteroid_003Ed__7(int _003C_003E1__state)
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

		public static AsteroidsGameManager Instance;

		public Text InfoText;

		public GameObject[] AsteroidPrefabs;

		public void Awake()
		{
		}

		public override void OnEnable()
		{
		}

		public void Start()
		{
		}

		public override void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnAsteroid_003Ed__7))]
		private IEnumerator SpawnAsteroid()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEndOfGame_003Ed__8))]
		private IEnumerator EndOfGame(string winner, int score)
		{
			return null;
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
		}

		public override void OnLeftRoom()
		{
		}

		public override void OnMasterClientSwitched(Player newMasterClient)
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
		{
		}

		private void StartGame()
		{
		}

		private bool CheckAllPlayerLoadedLevel()
		{
			return false;
		}

		private void CheckEndOfGame()
		{
		}

		private void OnCountdownTimerIsExpired()
		{
		}
	}
}
