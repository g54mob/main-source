using Coherence.Common;
using UnityEngine;

namespace Coherence
{
	public class VersionInfo : ScriptableObject, IVersionInfo
	{
		[SerializeField]
		private string sdk;

		[SerializeField]
		private string sdkRevisionHash;

		[SerializeField]
		private string engine;

		[SerializeField]
		private string docsSlug;

		public string Sdk => null;

		public string SdkRevisionHash
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string SdkRevisionOrVersion => null;

		public string Engine => null;

		public string DocsSlug => null;
	}
}
