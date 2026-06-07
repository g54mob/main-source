using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SLS.Widgets.Table
{
	public class HeaderCell : Cell
	{
		public Image icon;

		private Action<Column> clickCallback;

		private Action<Column, PointerEventData> clickCallbackWithData;

		public void Initialize(Column column, Action<Column> clickCallback)
		{
		}

		public void Initialize(Column column, Action<Column, PointerEventData> clickCallbackWithData)
		{
		}

		private void FinishInit(Column column, Action<Column> clickCallback, Action<Column, PointerEventData> clickCallbackWithData)
		{
		}

		public void UpdateDatum()
		{
		}

		public override void HandleClick(PointerEventData data)
		{
		}

		public override void SetColor()
		{
		}
	}
}
