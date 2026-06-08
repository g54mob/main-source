namespace ImGuiNET
{
	public struct ImGuiTextFilter
	{
		public unsafe fixed byte InputBuf[256];

		public ImVector Filters;

		public int CountGrep;
	}
}
