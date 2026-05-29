using JetBrains.Annotations;

namespace Eflatun.SceneReference
{
	[PublicAPI]
	public enum SceneReferenceUnsafeReason
	{
		None = 0,
		Empty = 1,
		NotInMaps = 2,
		NotInBuild = 3
	}
}
