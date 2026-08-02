using System.Collections.Generic;
using Rhizomatic;
using UnityEngine;

namespace GRP.Net
{
	[CreateAssetMenu(menuName = "GRP/Net/NetGameConfig", fileName = "NetGameConfig")]
	[AssetCreator(typeof(NetAssetCategory))]
	public class NetGameConfig : ScriptableObject
	{
		public NetPartyConfig party;

		public NetPresenceConfig presence;

		public NetProjectSessionConfig projectSession;

		public NetSimSessionConfig simSession;

		public ProjectConfigEntry project;

		public ProjectSessionConfig projectSessionDomain;

		public List<DomainConfig> domains;

		public DomainConfig GetDomain(string key)
		{
			return null;
		}
	}
}
