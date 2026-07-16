using System;
using UnityEngine;

namespace Codecks.Runtime
{
	[Serializable]
	internal struct CardCreateResponseData
	{
		[SerializeField]
		public bool ok;

		[SerializeField]
		public string cardId;

		[SerializeField]
		public CardCreateFileResponseData[] uploadUrls;
	}
}
