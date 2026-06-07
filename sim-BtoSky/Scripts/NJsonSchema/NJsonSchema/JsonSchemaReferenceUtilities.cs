using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.References;
using NJsonSchema.Visitors;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema
{
	public static class JsonSchemaReferenceUtilities
	{
		private sealed class JsonReferenceUpdater : AsyncJsonReferenceVisitorBase
		{
			private readonly object _rootObject;

			private readonly JsonReferenceResolver _referenceResolver;

			private readonly IContractResolver _contractResolver;

			private bool _replaceRefsRound;

			public JsonReferenceUpdater(object rootObject, JsonReferenceResolver referenceResolver, IContractResolver contractResolver)
				: base(contractResolver)
			{
				_rootObject = rootObject;
				_referenceResolver = referenceResolver;
				_contractResolver = contractResolver;
			}

			public override async Task VisitAsync(object obj, CancellationToken cancellationToken = default(CancellationToken))
			{
				_replaceRefsRound = true;
				await base.VisitAsync(obj, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				_replaceRefsRound = false;
				await base.VisitAsync(obj, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}

			protected override async Task<IJsonReference> VisitJsonReferenceAsync(IJsonReference reference, string path, string typeNameHint, CancellationToken cancellationToken)
			{
				cancellationToken.ThrowIfCancellationRequested();
				if (reference.ReferencePath != null && reference.Reference == null)
				{
					if (_replaceRefsRound)
					{
						if (path.EndsWith("/definitions/" + typeNameHint) || path.EndsWith("/schemas/" + typeNameHint))
						{
							return await _referenceResolver.ResolveReferenceWithoutAppendAsync(_rootObject, reference.ReferencePath, reference.GetType(), _contractResolver).ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					else
					{
						reference.Reference = await _referenceResolver.ResolveReferenceAsync(_rootObject, reference.ReferencePath, reference.GetType(), _contractResolver).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				return reference;
			}
		}

		private sealed class JsonReferencePathUpdater : JsonReferenceVisitorBase
		{
			private readonly object _rootObject;

			private readonly Dictionary<IJsonReference, IJsonReference> _schemaReferences;

			private readonly bool _removeExternalReferences;

			private readonly IContractResolver _contractResolver;

			public JsonReferencePathUpdater(object rootObject, Dictionary<IJsonReference, IJsonReference> schemaReferences, bool removeExternalReferences, IContractResolver contractResolver)
				: base(contractResolver)
			{
				_rootObject = rootObject;
				_schemaReferences = schemaReferences;
				_removeExternalReferences = removeExternalReferences;
				_contractResolver = contractResolver;
			}

			protected override IJsonReference VisitJsonReference(IJsonReference reference, string path, string typeNameHint)
			{
				if (reference.Reference != null)
				{
					if (!_removeExternalReferences || reference.Reference.DocumentPath == null)
					{
						_schemaReferences[reference] = reference.Reference.ActualObject;
					}
					else
					{
						IJsonReference reference2 = reference.Reference;
						object rootObject = reference2.FindParentDocument();
						reference.ReferencePath = reference2.DocumentPath + JsonPathUtilities.GetJsonPath(rootObject, reference2, _contractResolver).TrimEnd(new char[1] { '#' });
					}
				}
				else if (_removeExternalReferences && _rootObject != reference && reference.DocumentPath != null)
				{
					throw new NotSupportedException("removeExternalReferences not supported");
				}
				return reference;
			}
		}

		public static Task UpdateSchemaReferencesAsync(object rootObject, JsonReferenceResolver referenceResolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			return UpdateSchemaReferencesAsync(rootObject, referenceResolver, new DefaultContractResolver(), cancellationToken);
		}

		public static async Task UpdateSchemaReferencesAsync(object rootObject, JsonReferenceResolver referenceResolver, IContractResolver contractResolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			JsonReferenceUpdater jsonReferenceUpdater = new JsonReferenceUpdater(rootObject, referenceResolver, contractResolver);
			await jsonReferenceUpdater.VisitAsync(rootObject, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static void UpdateSchemaReferencePaths(object rootObject)
		{
			UpdateSchemaReferencePaths(rootObject, removeExternalReferences: false, new DefaultContractResolver());
		}

		public static void UpdateSchemaReferencePaths(object rootObject, bool removeExternalReferences, IContractResolver contractResolver)
		{
			Dictionary<IJsonReference, IJsonReference> dictionary = new Dictionary<IJsonReference, IJsonReference>();
			JsonReferencePathUpdater jsonReferencePathUpdater = new JsonReferencePathUpdater(rootObject, dictionary, removeExternalReferences, contractResolver);
			jsonReferencePathUpdater.Visit(rootObject);
			IEnumerable<IJsonReference> searchedObjects = dictionary.Select((KeyValuePair<IJsonReference, IJsonReference> p) => p.Value).Distinct();
			IReadOnlyDictionary<object, string> jsonPaths = JsonPathUtilities.GetJsonPaths(rootObject, searchedObjects, contractResolver);
			foreach (KeyValuePair<IJsonReference, IJsonReference> item in dictionary)
			{
				item.Key.ReferencePath = jsonPaths[item.Value];
			}
		}
	}
}
