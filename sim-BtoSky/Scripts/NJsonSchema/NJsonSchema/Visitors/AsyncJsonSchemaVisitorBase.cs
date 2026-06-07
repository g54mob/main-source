using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.References;

namespace NJsonSchema.Visitors
{
	public abstract class AsyncJsonSchemaVisitorBase : AsyncJsonReferenceVisitorBase
	{
		protected abstract Task<JsonSchema> VisitSchemaAsync(JsonSchema schema, string path, string typeNameHint, CancellationToken cancellationToken);

		protected override async Task<IJsonReference> VisitJsonReferenceAsync(IJsonReference reference, string path, string typeNameHint, CancellationToken cancellationToken)
		{
			if (reference is JsonSchema schema)
			{
				return await VisitSchemaAsync(schema, path, typeNameHint, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return reference;
		}
	}
}
