using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Coherence.Transport.Web
{
	[Preserve]
	internal static class JsonPreserve
	{
		[Preserve]
		internal static StringEnumConverter _ => null;
	}
}
