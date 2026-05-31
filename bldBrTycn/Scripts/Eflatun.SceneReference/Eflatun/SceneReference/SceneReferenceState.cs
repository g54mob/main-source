using JetBrains.Annotations;

namespace Eflatun.SceneReference
{
	[PublicAPI]
	public enum SceneReferenceState
	{
		Unsafe = 0,
		Regular = 1,
		Addressable = 2
	}
}
