namespace QFSW.QC.Suggestors
{
	public struct GlobalCommand
	{
		public CommandData Command;

		public string ExpandedSignature;

		public int BakedParamCount;

		public int NumOptionalParams;

		public GlobalCommand(CommandData command, string expandedSignature, int bakedParamCount, int numOptionalParams = 0)
		{
			Command = command;
			ExpandedSignature = expandedSignature;
			BakedParamCount = bakedParamCount;
			NumOptionalParams = numOptionalParams;
		}
	}
}
