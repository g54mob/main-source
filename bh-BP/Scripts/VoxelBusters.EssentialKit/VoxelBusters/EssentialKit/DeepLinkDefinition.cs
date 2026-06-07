using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class DeepLinkDefinition
	{
		[SerializeField]
		[DefaultValue("identifier")]
		private string m_identifier;

		[SerializeField]
		[DefaultValue("applinks")]
		private string m_serviceType;

		[SerializeField]
		private string m_scheme;

		[SerializeField]
		private string m_host;

		[SerializeField]
		private string m_path;

		public string Identifier => null;

		public string ServiceType => null;

		public string Scheme => null;

		public string Host => null;

		public string Path => null;

		public DeepLinkDefinition(string identifier = null, string serviceType = null, string scheme = null, string host = null, string path = null)
		{
		}
	}
}
