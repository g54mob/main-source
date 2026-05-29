using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class PlayerDetailsController : MonoBehaviourPunCallbacks
	{
		[CompilerGenerated]
		private sealed class _003CUpdateUIPing_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerDetailsController _003C_003E4__this;

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
			public _003CUpdateUIPing_003Ed__25(int _003C_003E1__state)
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

		public GameObject ContentPanel;

		public PropertyCell PropertyCellPrototype;

		public Text UpdateStatusText;

		public Transform BuiltInPropertiesPanel;

		public Transform PlayerNumberingExtensionPanel;

		public Transform ScoreExtensionPanel;

		public Transform TeamExtensionPanel;

		public Transform TurnExtensionPanel;

		public Transform CustomPropertiesPanel;

		public GameObject MasterClientToolBar;

		public GameObject NotInRoomLabel;

		private Dictionary<string, PropertyCell> builtInPropsCellList;

		private Player _player;

		private void Awake()
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public void SetPlayerTarget(Player player)
		{
		}

		private void AddProperty(string property, string value, Transform parent)
		{
		}

		private string ParseKey(object key)
		{
			return null;
		}

		public void KickOutPlayer()
		{
		}

		public void SetAsMaster()
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public override void OnMasterClientSwitched(Player newMasterClient)
		{
		}

		public override void OnPlayerPropertiesUpdate(Player target, ExitGames.Client.Photon.Hashtable changedProps)
		{
		}

		private void OnPlayerNumberingChanged()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateUIPing_003Ed__25))]
		private IEnumerator UpdateUIPing()
		{
			return null;
		}

		public void ResetList()
		{
		}

		private ExitGames.Client.Photon.Hashtable GetAllPlayerBuiltIntProperties()
		{
			return null;
		}
	}
}
