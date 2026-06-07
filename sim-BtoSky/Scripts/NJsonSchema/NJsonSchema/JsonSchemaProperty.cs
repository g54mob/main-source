using System.ComponentModel;
using Newtonsoft.Json;

namespace NJsonSchema
{
	public class JsonSchemaProperty : JsonSchema
	{
		private object _parent;

		[JsonIgnore]
		public string Name { get; internal set; }

		[JsonIgnore]
		public override object Parent
		{
			get
			{
				return _parent;
			}
			set
			{
				bool flag = _parent == null;
				_parent = value;
				if (flag && InitialIsRequired)
				{
					IsRequired = InitialIsRequired;
				}
			}
		}

		[JsonIgnore]
		public bool IsRequired
		{
			get
			{
				return base.ParentSchema.RequiredProperties.Contains(Name);
			}
			set
			{
				if (base.ParentSchema == null)
				{
					InitialIsRequired = value;
				}
				else if (value)
				{
					if (!base.ParentSchema.RequiredProperties.Contains(Name))
					{
						base.ParentSchema.RequiredProperties.Add(Name);
					}
				}
				else if (base.ParentSchema.RequiredProperties.Contains(Name))
				{
					base.ParentSchema.RequiredProperties.Remove(Name);
				}
			}
		}

		[JsonIgnore]
		internal bool InitialIsRequired { get; set; }

		[DefaultValue(false)]
		[JsonProperty("x-readOnly", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsReadOnly { get; set; }

		[DefaultValue(false)]
		[JsonProperty("x-writeOnly", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsWriteOnly { get; set; }

		[JsonIgnore]
		public bool IsInheritanceDiscriminator => base.ParentSchema.ActualDiscriminator == Name;

		public override bool IsNullable(SchemaType schemaType)
		{
			if (schemaType == SchemaType.Swagger2 && !IsRequired)
			{
				return true;
			}
			return base.IsNullable(schemaType);
		}
	}
}
