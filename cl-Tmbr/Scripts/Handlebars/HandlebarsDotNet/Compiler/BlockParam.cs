using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Compiler
{
	internal class BlockParam
	{
		public string Action { get; set; }

		public ChainSegment[] Parameters { get; set; }
	}
}
