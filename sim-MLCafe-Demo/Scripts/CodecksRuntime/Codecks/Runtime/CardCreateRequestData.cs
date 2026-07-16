using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codecks.Runtime
{
	[Serializable]
	public struct CardCreateRequestData
	{
		[SerializeField]
		public string content;

		[SerializeField]
		public List<string> fileNames;

		[SerializeField]
		public string severity;

		[SerializeField]
		public string userEmail;
	}
}
