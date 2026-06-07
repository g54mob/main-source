using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;

namespace Assets.Scripts.Craft.Parts
{
	public class PreStartInitializationPlan
	{
		private SortedList<int, List<PreStartInitializationDelegate>> _initDelegates;

		public AircraftScript CraftScript { get; }

		public PreStartInitializationFlags Flags { get; }

		public CraftLoadContext LoadContext { get; }

		public PreStartInitializationPlan(AircraftScript craftScript)
		{
			CraftScript = craftScript;
			LoadContext = craftScript.LoadContext;
			Flags = (craftScript.RemoteAircraft ? PreStartInitializationFlags.Remote : PreStartInitializationFlags.Local);
			PreStartInitializationFlags flags = Flags;
			Flags = (PreStartInitializationFlags)((int)flags | (LoadContext switch
			{
				CraftLoadContext.Default => 1, 
				CraftLoadContext.Menu => 8, 
				CraftLoadContext.Designer => 4, 
				CraftLoadContext.Flight => 2, 
				CraftLoadContext.Studio => 16, 
				_ => 0, 
			}));
			_initDelegates = new SortedList<int, List<PreStartInitializationDelegate>>();
		}

		public IEnumerable<(int Order, List<PreStartInitializationDelegate> List)> GetInitializationDelegates()
		{
			foreach (KeyValuePair<int, List<PreStartInitializationDelegate>> initDelegate in _initDelegates)
			{
				yield return (Order: initDelegate.Key, List: initDelegate.Value);
			}
		}

		public void Register(PreStartInitializationDelegate initDelegate, PreStartInitializationFlags flags, int initializationOrder)
		{
			if ((flags & Flags) == Flags)
			{
				if (!_initDelegates.TryGetValue(initializationOrder, out var value))
				{
					value = new List<PreStartInitializationDelegate>();
					_initDelegates[initializationOrder] = value;
				}
				value.Add(initDelegate);
			}
		}

		public void Register(BodyScript bodyScript, PreStartInitializationDelegate initDelegate, PreStartInitializationFlags flags = PreStartInitializationFlags.Default, int? initializationOrder = null)
		{
			Register(initDelegate, flags, initializationOrder ?? 100);
		}

		public void Register(PartGroupScript partGroupScript, PreStartInitializationDelegate initDelegate, PreStartInitializationFlags flags = PreStartInitializationFlags.Default, int? initializationOrder = null)
		{
			Register(initDelegate, flags, initializationOrder ?? 200);
		}

		public void Register(PartScript partScript, PreStartInitializationDelegate initDelegate, PreStartInitializationFlags flags = PreStartInitializationFlags.Default, int? initializationOrder = null)
		{
			Register(initDelegate, flags, initializationOrder ?? 300);
		}

		public void Register(PartMaterialScript partMaterialScript, PreStartInitializationDelegate initDelegate, PreStartInitializationFlags flags = PreStartInitializationFlags.Default, int? initializationOrder = null)
		{
			Register(initDelegate, flags, initializationOrder ?? 400);
		}

		public void Register(PartModifierScript partModifierScript, PreStartInitializationDelegate initDelegate, PreStartInitializationFlags flags = PreStartInitializationFlags.Default, int? initializationOrder = null)
		{
			Register(initDelegate, flags, initializationOrder ?? 500);
		}
	}
}
