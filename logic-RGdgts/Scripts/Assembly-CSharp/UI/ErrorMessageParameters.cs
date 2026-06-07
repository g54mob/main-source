using UnityEngine.Localization.Tables;

namespace UI
{
	public class ErrorMessageParameters
	{
		public TableReference tableRef;

		public TableEntryReference messageEntryRef;

		public MiniTool.MessageType messageType;

		public bool persistent;

		public ErrorMessageParameters(TableReference tableRef, TableEntryReference messageEntryRef, MiniTool.MessageType messageType, bool persistent)
		{
		}
	}
}
