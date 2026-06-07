using System;

namespace MagicaCloth2
{
	[Serializable]
	public class MagicaClothCanceledException : Exception
	{
		public MagicaClothCanceledException()
		{
		}

		public MagicaClothCanceledException(string message)
		{
		}

		public MagicaClothCanceledException(string message, Exception inner)
		{
		}
	}
}
