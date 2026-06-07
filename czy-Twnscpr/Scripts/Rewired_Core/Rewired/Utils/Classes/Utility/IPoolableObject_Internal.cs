using System;
using Rewired.Interfaces;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IPoolableObject_Internal : IDisposable, IPoolableObject
	{
		IObjectPool pool { get; set; }

		void Clear();
	}
}
