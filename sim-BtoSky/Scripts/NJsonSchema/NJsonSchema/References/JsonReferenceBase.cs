using Newtonsoft.Json;

namespace NJsonSchema.References
{
	public abstract class JsonReferenceBase<T> : IJsonReferenceBase, IDocumentPathProvider where T : class, IJsonReference
	{
		private T _reference;

		[JsonIgnore]
		public string DocumentPath { get; set; }

		[JsonProperty("$ref", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
		string IJsonReferenceBase.ReferencePath { get; set; }

		[JsonIgnore]
		public virtual T Reference
		{
			get
			{
				return _reference;
			}
			set
			{
				if (_reference != value)
				{
					_reference = value;
					((IJsonReferenceBase)this).ReferencePath = null;
				}
			}
		}

		[JsonIgnore]
		IJsonReference IJsonReferenceBase.Reference
		{
			get
			{
				return Reference;
			}
			set
			{
				Reference = (T)value;
			}
		}
	}
}
