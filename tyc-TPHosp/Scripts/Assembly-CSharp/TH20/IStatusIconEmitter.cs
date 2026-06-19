using UnityEngine;

namespace TH20
{
	public interface IStatusIconEmitter
	{
		Vector3 GetStatusIconPosition();

		bool IsStatusIconEmitterVisible();
	}
}
