using System;

namespace Dorfromantik
{
	[Serializable]
	public class CustomElementTypeTextures
	{
		public ElementType elementType;

		public CustomInstanceTexture[] textures = new CustomInstanceTexture[3];
	}
}
