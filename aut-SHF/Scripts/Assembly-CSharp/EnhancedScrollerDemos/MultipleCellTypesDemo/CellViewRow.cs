using UnityEngine.UI;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	public class CellViewRow : CellView
	{
		private RowData _rowData;

		public Text userNameText;

		public Image userAvatarImage;

		public Text userHighScoreText;

		public override void SetData(Data data)
		{
		}
	}
}
