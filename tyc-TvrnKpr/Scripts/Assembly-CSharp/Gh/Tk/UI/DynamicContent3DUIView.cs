using UnityEngine;

namespace Gh.Tk.UI
{
	public class DynamicContent3DUIView : MonoBehaviour
	{
		[SerializeField]
		private ContentBlockLayout _contentBlockLayout;

		public RelativeScaler3DUIView relativeScaler;

		public void SetContent(string richTextString)
		{
		}

		public void ClearContent()
		{
		}
	}
}
