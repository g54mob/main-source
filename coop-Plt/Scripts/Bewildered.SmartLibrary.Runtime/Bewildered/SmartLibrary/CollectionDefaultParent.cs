using System.Collections.Generic;
using UnityEngine;

namespace Bewildered.SmartLibrary
{
	[AddComponentMenu("")]
	internal class CollectionDefaultParent : MonoBehaviour
	{
		[SerializeField]
		private List<UniqueID> _collectionIds = new List<UniqueID>();

		public List<UniqueID> CollectionIds => _collectionIds;
	}
}
