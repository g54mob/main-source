using System;

namespace GLTFast
{
	public enum AnimationMethod
	{
		None = 0,
		Legacy = 1,
		Mecanim = 2,
		[Obsolete("Playables support has been removed since it was not usable in builds. Use LegacyAnimation instead. See: <a href=\"https://docs.unity3d.com/Packages/com.unity.cloud.gltfast@6.13/manual/UseCaseCustomPlayablesAnimation.html\">UseCaseCustomPlayablesAnimation</a>")]
		Playables = 3
	}
}
