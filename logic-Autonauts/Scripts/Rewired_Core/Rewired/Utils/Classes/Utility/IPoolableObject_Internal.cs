using System;
using Rewired.Interfaces;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal interface IPoolableObject_Internal : IDisposable, IPoolableObject
	{
		IObjectPool pool { get; set; }

		void Clear();
	}
}
