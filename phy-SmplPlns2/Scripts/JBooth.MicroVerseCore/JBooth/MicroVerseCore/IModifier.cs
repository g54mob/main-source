using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public interface IModifier
	{
		void Initialize();

		void Dispose();

		Bounds GetBounds();

		bool IsEnabled();

		void StripInBuild();
	}
}
