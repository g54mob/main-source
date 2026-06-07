using System.Collections.Generic;
using UI.Utilities;

namespace Document
{
	public class DocumentsManager : MonoSingleton<DocumentsManager>, ILogOrigin
	{
		public List<MagazineInfo> magazines;

		private DeskDocument deskDocument;

		private void Start()
		{
		}

		public void ShowMagazine(MagazinesName magazineName, int magazineNumber)
		{
		}

		private MagazineInfo GetDocumentInfo(MagazinesName magazineName, int magazineNumber)
		{
			return null;
		}
	}
}
