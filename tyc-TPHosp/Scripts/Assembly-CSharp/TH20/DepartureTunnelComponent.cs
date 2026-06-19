using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DepartureTunnelComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform _spawnPoint;

		private static readonly List<DepartureTunnelComponent> _tunnels = new List<DepartureTunnelComponent>();

		public static List<DepartureTunnelComponent> Tunnels => _tunnels;

		public static DepartureTunnelComponent RandomTunnel()
		{
			if (_tunnels.Count != 0)
			{
				return _tunnels.RandomItem();
			}
			return null;
		}

		private void Awake()
		{
			_tunnels.Add(this);
		}

		private void OnDestroy()
		{
			_tunnels.Remove(this);
		}

		public Transform GetTransform()
		{
			return _spawnPoint;
		}
	}
}
