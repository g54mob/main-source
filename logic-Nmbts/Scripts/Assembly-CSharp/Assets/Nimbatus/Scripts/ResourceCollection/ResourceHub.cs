using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.ResourceCollection
{
	public class ResourceHub
	{
		private readonly Dictionary<EResourceType, DronePartResourceManager> _resourceDict = new Dictionary<EResourceType, DronePartResourceManager>();

		private readonly List<ResourceHub> _connectedHubs = new List<ResourceHub>();

		public void Init()
		{
			_resourceDict.Clear();
			foreach (EResourceType value in Enum.GetValues(typeof(EResourceType)))
			{
				_resourceDict.Add(value, new DronePartResourceManager(value));
			}
		}

		public void Reset()
		{
			if (_resourceDict == null)
			{
				return;
			}
			foreach (KeyValuePair<EResourceType, DronePartResourceManager> item in _resourceDict)
			{
				item.Value.Reset();
			}
		}

		public void AddConnectedHub(ResourceHub hub)
		{
			if (this != hub)
			{
				_connectedHubs.Add(hub);
			}
		}

		public void RemoveConnectedHub(ResourceHub hub)
		{
			if (this != hub)
			{
				_connectedHubs.Remove(hub);
			}
		}

		public bool HasCapacity(EResourceType mat, float amount)
		{
			return CheckRecursive((ResourceHub hub, EResourceType m, float a) => hub._resourceDict[m].HasCapacity(a), null, mat, amount, this);
		}

		public bool HasResource(EResourceType mat, float amount)
		{
			return CheckRecursive((ResourceHub hub, EResourceType m, float a) => hub._resourceDict[m].HasResource(a), null, mat, amount, this);
		}

		public bool UseResourceFromParts(EResourceType mat, float amount)
		{
			return CheckRecursive((ResourceHub hub, EResourceType m, float a) => hub._resourceDict[m].HasResource(a), delegate(ResourceHub hub, EResourceType m, float a)
			{
				hub._resourceDict[m].UseResourceFromParts(a);
			}, mat, amount, this);
		}

		public bool AddResourceToParts(EResourceType mat, float amount)
		{
			return CheckRecursive((ResourceHub hub, EResourceType m, float a) => hub._resourceDict[m].HasCapacity(a), delegate(ResourceHub hub, EResourceType m, float a)
			{
				hub._resourceDict[m].AddResourceToParts(a);
			}, mat, amount, this);
		}

		private bool CheckRecursive(Func<ResourceHub, EResourceType, float, bool> check, Action<ResourceHub, EResourceType, float> action, EResourceType mat, float amount, ResourceHub previousHub)
		{
			if (check(this, mat, amount))
			{
				if (action != null)
				{
					action(this, mat, amount);
				}
				return true;
			}
			foreach (ResourceHub connectedHub in _connectedHubs)
			{
				if (connectedHub != previousHub && connectedHub.CheckRecursive(check, action, mat, amount, this))
				{
					return true;
				}
			}
			return false;
		}

		public void RegisterPart(EResourceType mat, IHasResources part)
		{
			_resourceDict[mat].RegisterPart(part);
		}

		public void UnregisterPart(EResourceType mat, IHasResources part, bool hasDestroyed = true)
		{
			_resourceDict[mat].UnregisterPart(part, hasDestroyed);
		}

		public void Update()
		{
			foreach (DronePartResourceManager value in _resourceDict.Values)
			{
				value.Update();
			}
		}
	}
}
