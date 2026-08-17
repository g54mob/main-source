using Coherence.Common;
using UnityEngine;

namespace Coherence;

public class VersionInfo : ScriptableObject, IVersionInfo
{
	private string sdk;

	private string sdkRevisionHash;

	private string engine;

	private string docsSlug;

	public string Sdk => sdk;

	public string SdkRevisionHash
	{
		get
		{
			return sdkRevisionHash;
		}
		internal set
		{
			sdkRevisionHash = value;
		}
	}

	public string SdkRevisionOrVersion
	{
		get
		{
			string text = sdkRevisionHash;
			if (sdkRevisionHash == null || text._stringLength <= 0)
			{
				text = sdk;
			}
			return text;
		}
	}

	public string Engine => engine;

	public string DocsSlug => docsSlug;
}
