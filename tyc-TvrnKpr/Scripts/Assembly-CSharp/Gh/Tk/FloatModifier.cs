using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class FloatModifier : IPersistable
	{
		public float factor;

		public string key;

		[FormerlySerializedAs("displayName")]
		public string displayNameKey;
	}
}
