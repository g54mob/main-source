using System.Collections.Generic;
using Unity.Netcode;

namespace BrewGame.SaveSystem.Integration
{
	public abstract class SaveableNetworkBehaviour : NetworkBehaviour, ISaveable
	{
		public abstract string SaveableId { get; }

		public virtual int SavePriority => 0;

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public abstract Dictionary<string, object> CaptureState();

		public abstract void RestoreState(Dictionary<string, object> state);

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
