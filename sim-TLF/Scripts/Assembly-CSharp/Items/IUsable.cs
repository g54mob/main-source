using System;

namespace Items
{
	public interface IUsable
	{
		void Use();

		[Obsolete]
		void UnUse();
	}
}
