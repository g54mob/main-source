using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FractureField
{
	public class SaveDataContractResolver : CamelCasePropertyNamesContractResolver
	{
		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			return null;
		}

		private bool ShouldSkipPropertyDueToHiding(MemberInfo candidateToSkip, MemberInfo candidateToKeep, Type type)
		{
			return false;
		}
	}
}
