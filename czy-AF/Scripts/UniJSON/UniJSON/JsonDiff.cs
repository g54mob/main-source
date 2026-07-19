using System;

namespace UniJSON
{
	public struct JsonDiff
	{
		public JsonPointer Path;

		public JsonDiffType DiffType;

		public string Msg;

		public static JsonDiff Create<T>(ListTreeNode<T> node, JsonDiffType diffType, string msg) where T : IListTreeItem, IValue<T>
		{
			return new JsonDiff
			{
				Path = JsonPointer.Create(node),
				DiffType = diffType,
				Msg = msg
			};
		}

		public override string ToString()
		{
			return DiffType switch
			{
				JsonDiffType.KeyAdded => $"+ {Path}: {Msg}", 
				JsonDiffType.KeyRemoved => $"- {Path}: {Msg}", 
				JsonDiffType.ValueChanged => $"= {Path}: {Msg}", 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
