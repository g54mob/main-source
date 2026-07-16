using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codecks.Runtime
{
	[Serializable]
	public struct CardCreateFileResponseData
	{
		[SerializeField]
		public string fileName;

		[SerializeField]
		public string url;

		[SerializeField]
		public Dictionary<string, string> fields;
	}
}
