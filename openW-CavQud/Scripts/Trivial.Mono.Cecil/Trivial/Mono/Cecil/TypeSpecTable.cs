using Trivial.Mono.Cecil.Metadata;

namespace Trivial.Mono.Cecil
{
	internal sealed class TypeSpecTable : MetadataTable<uint>
	{
		public override void Write(TableHeapBuffer buffer)
		{
			for (int i = 0; i < length; i++)
			{
				buffer.WriteBlob(rows[i]);
			}
		}
	}
}
