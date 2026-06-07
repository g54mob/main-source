using UnityEngine;

namespace Ludiq
{
	public interface IUnityObjectOwnable
	{
		Object owner { get; set; }
	}
}
