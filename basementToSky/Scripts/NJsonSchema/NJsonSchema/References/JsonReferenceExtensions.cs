namespace NJsonSchema.References
{
	public static class JsonReferenceExtensions
	{
		public static object FindParentDocument(this IJsonReference obj)
		{
			if (obj.DocumentPath != null)
			{
				return obj;
			}
			object possibleRoot = obj.PossibleRoot;
			if (possibleRoot == null)
			{
				return obj;
			}
			while ((possibleRoot as IJsonReference)?.PossibleRoot != null)
			{
				possibleRoot = ((IJsonReference)possibleRoot).PossibleRoot;
				if (possibleRoot is IDocumentPathProvider { DocumentPath: not null })
				{
					return possibleRoot;
				}
			}
			return possibleRoot;
		}
	}
}
