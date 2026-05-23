using UnityEngine;

namespace Presentation.FactoryFloor
{
	public interface IResourceHolderView
	{
		public delegate void ReceiveResourceViewEvent(ResourceView resourceView, int inputIndex, Vector3 targetPos);

		void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true);

		void AddReceiveResourceViewListener(int createdId, ReceiveResourceViewEvent resourceViewEvent);

		void RemoveReceiveResourceViewListener(int createdId, ReceiveResourceViewEvent resourceViewEvent);
	}
}
