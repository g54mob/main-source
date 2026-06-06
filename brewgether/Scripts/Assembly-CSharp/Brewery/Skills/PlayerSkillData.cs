using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Unity.Netcode;

namespace Brewery.Skills
{
	public class PlayerSkillData : NetworkBehaviour, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CDeferredRegistration_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerSkillData _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

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
			public _003CDeferredRegistration_003Ed__30(int _003C_003E1__state)
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
		private sealed class _003CDeferredSaveableRegistration_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerSkillData _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

			private string _003CclientIdFallback_003E5__4;

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
			public _003CDeferredSaveableRegistration_003Ed__29(int _003C_003E1__state)
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

		private NetworkList<int> skillLevels;

		private NetworkVariable<int> availableSkillPoints;

		private NetworkVariable<float> skillProgress;

		private string cachedSteamId;

		public int AvailableSkillPoints => 0;

		public float CurrentSkillProgress => 0f;

		public int ProgressPerLevel => 0;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<SkillType, int> OnSkillLevelChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<int> OnSkillPointsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float, int> OnSkillProgressChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private string GetPlayerSteamId()
		{
			return null;
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		[IteratorStateMachine(typeof(_003CDeferredSaveableRegistration_003Ed__29))]
		private IEnumerator DeferredSaveableRegistration()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDeferredRegistration_003Ed__30))]
		private IEnumerator DeferredRegistration()
		{
			return null;
		}

		private void InitializeSkillLevels()
		{
		}

		private void OnSkillLevelsChanged(NetworkListEvent<int> changeEvent)
		{
		}

		private void OnAvailableSkillPointsChanged(int oldValue, int newValue)
		{
		}

		private void OnSkillProgressValueChanged(float oldValue, float newValue)
		{
		}

		public int GetSkillLevel(SkillType skill)
		{
			return 0;
		}

		public float GetDurationMultiplier(SkillType skill)
		{
			return 0f;
		}

		public bool CanUpgradeSkill(SkillType skill)
		{
			return false;
		}

		public bool CanAffordUpgrade(SkillType skill)
		{
			return false;
		}

		public int GetNextUpgradeCost(SkillType skill)
		{
			return 0;
		}

		public void RequestUpgradeSkill(SkillType skill)
		{
		}

		[ServerRpc]
		private void UpgradeSkillServerRpc(SkillType skill)
		{
		}

		public void ServerAddSkillPoints(int amount)
		{
		}

		public void ServerAddSkillProgress(float amount)
		{
		}

		public bool IsSkillMaxed(SkillType skill)
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3387127759(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
