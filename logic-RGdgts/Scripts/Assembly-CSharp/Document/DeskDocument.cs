using UnityEngine;

namespace Document
{
	public class DeskDocument : MonoBehaviour
	{
		public DocumentData documentData;

		public DocumentCanvas documentCanvas;

		public DeskDocumentPage[] pages;

		[SerializeField]
		private GameObject pageContainer;

		private bool pageMovementEvent;

		public void SetDocument(MagazineInfo info)
		{
		}

		public void OnPageMovement(int side)
		{
		}

		private void Refresh()
		{
		}
	}
}
