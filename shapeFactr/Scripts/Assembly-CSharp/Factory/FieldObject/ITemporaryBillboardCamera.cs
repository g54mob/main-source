using UnityEngine;
using UnityEngine.EventSystems;

namespace Factory.FieldObject
{
	public interface ITemporaryBillboardCamera : IEventSystemHandler
	{
		void OnChangeCamera(Camera camera);
	}
}
