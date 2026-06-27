using Restory.Gameplay.Devices;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementSocketProjectionHandler : MonoBehaviour
	{
		[SerializeField]
		private Device device;

		[SerializeField]
		private ElementSocket elementSocket;

		private ElementProjectionFactory elementProjectionFactory;

		private ElementProjectionData elementProjectionData;

		private ElementProjection elementProjection;

		[Inject]
		private void Construct(ElementProjectionFactory elementProjectionFactory)
		{
			this.elementProjectionFactory = elementProjectionFactory;
			elementProjectionData = CreateProjectionData();
		}

		private void OnEnable()
		{
			device.OnActivated += ResolveDeviceActivated;
			device.OnDeactivated += ResolveDeviceDeactivated;
			elementSocket.OnNestedElementChanged += ResolveNestedElementChanged;
		}

		private void OnDisable()
		{
			device.OnActivated -= ResolveDeviceActivated;
			device.OnDeactivated -= ResolveDeviceDeactivated;
			elementSocket.OnNestedElementChanged -= ResolveNestedElementChanged;
		}

		private ElementProjectionData CreateProjectionData()
		{
			ElementBase prefab = elementSocket.CompatibleElementInfo.Prefab;
			return new ElementProjectionData(prefab.transform, Vector3.zero, prefab.BehaviorSwitcher.CastCollider);
		}

		private void ResolveDeviceActivated()
		{
			if (!elementSocket.NestedElement)
			{
				CreateProjection();
			}
		}

		private void ResolveDeviceDeactivated()
		{
			if ((bool)elementProjection)
			{
				DestroyProjection();
			}
		}

		private void ResolveNestedElementChanged(ElementSocket _)
		{
			if (device.IsActivated)
			{
				if ((bool)elementSocket.NestedElement)
				{
					DestroyProjection();
				}
				else
				{
					CreateProjection();
				}
			}
		}

		private void CreateProjection()
		{
			if (!elementProjection)
			{
				elementProjection = elementProjectionFactory.CreateElementProjection(elementProjectionData, elementSocket.transform);
				elementProjection.MakeFilled();
			}
		}

		private void DestroyProjection()
		{
			if ((bool)elementProjection)
			{
				elementProjectionFactory.DestroyElementProjection(elementProjection);
				elementProjection = null;
			}
		}
	}
}
