using System.Collections.Generic;
using UnityEngine;

namespace Document
{
	[ExecuteInEditMode]
	public class MagazineCreator : MonoBehaviour
	{
		public GameObject magazineCoverFront;

		public GameObject magazineCoverBack;

		public GameObject directorColumnFront;

		public GameObject directorColumnBack;

		public GameObject genericPageFront;

		public GameObject genericPageBack;

		public DocumentLayout documentLayout;

		public List<GameObject> originalPrefabListForSOCreation;

		public Transform backPages;

		public Transform frontPages;

		[SerializeField]
		private DocumentData currentUsedData;
	}
}
