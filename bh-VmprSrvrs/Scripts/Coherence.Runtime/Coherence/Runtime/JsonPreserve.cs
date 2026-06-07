using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Coherence.Runtime
{
	[Preserve]
	internal static class JsonPreserve
	{
		[Preserve]
		internal static StringEnumConverter _ => null;
	}
}
