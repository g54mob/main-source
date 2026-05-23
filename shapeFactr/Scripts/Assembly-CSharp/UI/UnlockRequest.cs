using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class UnlockRequest : MonoBehaviour
	{
		public RequestGage requestGagePrefab;

		public RectTransform contentParent;

		private List<RequestGage> _requestGages;
	}
}
