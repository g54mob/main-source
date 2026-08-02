namespace GRP
{
	public class DeleteTool : Tool
	{
		public override bool canInteractPart => false;

		protected override ToolViewable DoCreateViewable()
		{
			return null;
		}
	}
}
