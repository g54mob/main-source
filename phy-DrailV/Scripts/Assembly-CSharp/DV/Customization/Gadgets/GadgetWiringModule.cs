using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public class GadgetWiringModule
	{
		public abstract class WireLinkPort
		{
			public readonly GadgetBase owner;

			public readonly bool isPassive;

			protected abstract bool CanBeLinked { get; }

			public static bool AreCompatible(WireLinkPort a, WireLinkPort b)
			{
				if (a.CanLinkTo(b))
				{
					return b.CanLinkTo(a);
				}
				return false;
			}

			public static bool ReadyToWire(WireLinkPort a, WireLinkPort b)
			{
				if (a.CanLinkTo(b) && b.CanLinkTo(a) && !AreWired(a, b) && a.CanBeLinked)
				{
					return b.CanBeLinked;
				}
				return false;
			}

			public static bool Wire(WireLinkPort a, WireLinkPort b)
			{
				if (!ReadyToWire(a, b))
				{
					return false;
				}
				a.Add(b);
				b.Add(a);
				a.CallAdd(b);
				b.CallAdd(a);
				return true;
			}

			public static bool Unwire(WireLinkPort a, WireLinkPort b)
			{
				if (!AreWired(a, b))
				{
					return false;
				}
				a.Remove(b);
				b.Remove(a);
				a.CallRemove(b);
				b.CallRemove(a);
				return true;
			}

			public static bool AreWired(WireLinkPort a, WireLinkPort b)
			{
				return a.IsLinkedTo(b);
			}

			public static bool Unwire(WireLinkPort a)
			{
				bool result = false;
				buffer.Clear();
				a.GetLinks(buffer);
				foreach (WireLinkPort item in buffer)
				{
					if (Unwire(a, item))
					{
						result = true;
					}
				}
				buffer.Clear();
				return result;
			}

			protected WireLinkPort(GadgetBase owner, bool passive)
			{
				this.owner = owner;
				owner.wiring.wirePorts.Add(this);
				isPassive = passive;
			}

			protected virtual bool CanLinkTo(WireLinkPort port)
			{
				if (port?.owner.Custom != null && port.owner.Custom == owner.Custom)
				{
					if (isPassive)
					{
						return !port.isPassive;
					}
					return true;
				}
				return false;
			}

			protected abstract bool IsLinkedTo(WireLinkPort port);

			protected abstract void Add(WireLinkPort port);

			protected abstract void Remove(WireLinkPort port);

			protected abstract void CallAdd(WireLinkPort port);

			protected abstract void CallRemove(WireLinkPort port);

			public abstract void GetLinks(List<WireLinkPort> destination);
		}

		public abstract class WireLinkPort<T> : WireLinkPort where T : GadgetBase
		{
			protected readonly Action<T> onWired;

			protected readonly Action<T> onUnwired;

			protected override bool CanLinkTo(WireLinkPort port)
			{
				if (base.CanLinkTo(port))
				{
					return port.owner is T;
				}
				return false;
			}

			protected override void CallAdd(WireLinkPort port)
			{
				onWired?.Invoke(port.owner as T);
			}

			protected override void CallRemove(WireLinkPort port)
			{
				onUnwired?.Invoke(port.owner as T);
			}

			protected WireLinkPort(GadgetBase owner, bool passive, Action<T> onWired, Action<T> onUnwired)
				: base(owner, passive)
			{
				this.onWired = onWired;
				this.onUnwired = onUnwired;
			}
		}

		public class WireLinkPortMono<T> : WireLinkPort<T> where T : GadgetBase
		{
			private WireLinkPort linkedTo;

			protected override bool CanBeLinked => linkedTo == null;

			internal WireLinkPortMono(GadgetBase owner, bool passive, Action<T> onWired, Action<T> onUnwired)
				: base(owner, passive, onWired, onUnwired)
			{
			}

			protected override bool IsLinkedTo(WireLinkPort port)
			{
				if (port != null)
				{
					return linkedTo == port;
				}
				return false;
			}

			protected override void Add(WireLinkPort port)
			{
				if (linkedTo != null)
				{
					Debug.LogError("[CUSTOMIZATION] Cannot wire a mono link port: It does not accept any more connections!");
				}
				else
				{
					linkedTo = port;
				}
			}

			protected override void Remove(WireLinkPort port)
			{
				if (linkedTo == port)
				{
					linkedTo = null;
				}
			}

			public override void GetLinks(List<WireLinkPort> destination)
			{
				if (linkedTo != null)
				{
					destination.Add(linkedTo);
				}
			}
		}

		public class WireLinkPortMulti<T> : WireLinkPort<T> where T : GadgetBase
		{
			private readonly HashSet<WireLinkPort> links = new HashSet<WireLinkPort>();

			protected override bool CanBeLinked => true;

			internal WireLinkPortMulti(GadgetBase owner, bool passive, Action<T> onWired, Action<T> onUnwired)
				: base(owner, passive, onWired, onUnwired)
			{
			}

			protected override bool IsLinkedTo(WireLinkPort port)
			{
				if (port != null)
				{
					return links.Contains(port);
				}
				return false;
			}

			protected override void Add(WireLinkPort port)
			{
				if (!links.Add(port))
				{
					Debug.LogError("[CUSTOMIZATION] Cannot wire a multi link port: The provided counterpart is already linked!");
				}
			}

			protected override void Remove(WireLinkPort port)
			{
				links.Remove(port);
			}

			public override void GetLinks(List<WireLinkPort> destination)
			{
				destination.AddRange(links);
			}
		}

		private static readonly List<WireLinkPort> buffer = new List<WireLinkPort>();

		private readonly List<WireLinkPort> wirePorts = new List<WireLinkPort>();

		public ReadOnlyCollection<WireLinkPort> wireLinkPorts;

		public GadgetWiringModule()
		{
			wireLinkPorts = wirePorts.AsReadOnly();
		}

		public bool TryGetCompatiblePorts(GadgetWiringModule other, out WireLinkPort myPort, out WireLinkPort otherPort)
		{
			myPort = null;
			otherPort = null;
			if (this == other)
			{
				return false;
			}
			foreach (WireLinkPort wirePort in wirePorts)
			{
				foreach (WireLinkPort wirePort2 in other.wirePorts)
				{
					if (WireLinkPort.AreCompatible(wirePort, wirePort2))
					{
						myPort = wirePort;
						otherPort = wirePort2;
						return true;
					}
				}
			}
			return false;
		}

		public void UnwireAll()
		{
			foreach (WireLinkPort wirePort in wirePorts)
			{
				WireLinkPort.Unwire(wirePort);
			}
		}
	}
}
