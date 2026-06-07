using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using PajamaLlama.Serialization;
using UnityEngine;

namespace PajamaLlama.Persistence
{
	public static class PersistenceLifeCycle
	{
		private static List<IPersistentReferenceLifeCycle> _persistentReferenceLifeCycles;

		private static IFormatter _formatter;

		public static PersistenceState State { get; private set; }

		public static void OnPrePersistenceAction(PersistenceState state)
		{
			State = state;
			Initialize();
			foreach (IPersistentReferenceLifeCycle persistentReferenceLifeCycle in _persistentReferenceLifeCycles)
			{
				persistentReferenceLifeCycle.OnPrePersistenceAction();
			}
			switch (state)
			{
			case PersistenceState.Loading:
				InventoryPersistentData.InitializeRestoredInventories();
				break;
			case PersistenceState.Saving:
				InventoryPersistentData.InitialzeSavedInventories();
				break;
			}
		}

		public static void OnPostPersistenceAction()
		{
			if (State != PersistenceState.None)
			{
				State = PersistenceState.None;
				Initialize();
				{
					foreach (IPersistentReferenceLifeCycle persistentReferenceLifeCycle in _persistentReferenceLifeCycles)
					{
						persistentReferenceLifeCycle.OnPostPersistenceAction();
					}
					return;
				}
			}
			Debug.LogException(new Exception("OnPostPersistenceAction was triggered, but OnPrePersistenceAction was not triggered yet."));
		}

		public static byte[] Serialize(object graph)
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				GetFormatter().Serialize(memoryStream, graph);
				return memoryStream.ToArray();
			}
			finally
			{
				memoryStream.Close();
			}
		}

		public static object Deserialize(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			try
			{
				return GetFormatter().Deserialize(memoryStream);
			}
			finally
			{
				memoryStream.Close();
			}
		}

		private static void Initialize()
		{
			if (_persistentReferenceLifeCycles == null)
			{
				_persistentReferenceLifeCycles = new List<IPersistentReferenceLifeCycle>
				{
					new PersistentReferenceLifeCycle<global::Flotsam>(),
					new PersistentReferenceLifeCycle<Agent>(),
					new PersistentReferenceLifeCycle<Bird>(),
					new PersistentReferenceLifeCycle<Buildable>(),
					new PersistentReferenceLifeCycle<WalkwaySegment>(),
					new PersistentReferenceLifeCycle<WalkwayPonton>(),
					new PersistentReferenceLifeCycle<Construction>(),
					new PersistentReferenceLifeCycle<Storage>(),
					new PersistentReferenceLifeCycle<Boat>(),
					new PersistentReferenceLifeCycle<MooringPoint>(),
					new PersistentReferenceLifeCycle<Rejuvenator>(),
					new PersistentReferenceLifeCycle<House>(),
					new PersistentReferenceLifeCycle<Producer>(),
					new PersistentReferenceLifeCycle<Engine>(),
					new PersistentReferenceLifeCycle<ResearchStation>(),
					new PersistentReferenceLifeCycle<BirdHouse>(),
					new PersistentReferenceLifeCycle<EnergyStorage>(),
					new PersistentReferenceLifeCycle<EnergyManualProducer>(),
					new PersistentReferenceLifeCycle<EnergyItemProducer>(),
					new PersistentReferenceLifeCycle<EnergyGridBuildableComponent>(),
					new PersistentReferenceLifeCycle<EnergyGridConnector>(),
					new PersistentReferenceLifeCycle<EnergyGridPole>(),
					new PersistentReferenceLifeCycle<EnergyPassiveGenerator>(),
					new PersistentReferenceLifeCycle<Salvager>(),
					new PersistentReferenceLifeCycle<Hookable>(),
					new PersistentReferenceLifeCycle<School>(),
					new PersistentReferenceLifeCycle<Clinic>(),
					new PersistentReferenceLifeCycle<MedPod>(),
					new PersistentReferenceLifeCycle<DecorationSlots>(),
					new PersistentReferenceLifeCycle<Decoration>(),
					new PersistentReferenceLifeCycle<EnergyGrid>(),
					new PersistentReferenceLifeCycle<Item>(),
					new PersistentReferenceLifeCycle<Project>(),
					new PersistentReferenceLifeCycle<Marker>(),
					new PersistentReferenceLifeCycle<World>(),
					new PersistentReferenceLifeCycle<WorldTile>(),
					new PersistentReferenceLifeCycle<Landmark>(),
					new PersistentReferenceLifeCycle<LandmarkMooringPoint>(),
					new PersistentReferenceLifeCycle<Quest>()
				};
			}
		}

		private static IFormatter GetFormatter()
		{
			if (_formatter == null)
			{
				_formatter = new BinaryFormatter();
				SurrogateSelector surrogateSelector = new SurrogateSelector();
				StreamingContext context = new StreamingContext(StreamingContextStates.All);
				surrogateSelector.AddSurrogate(typeof(Vector2), context, new Vector2SerializationSurrogate());
				surrogateSelector.AddSurrogate(typeof(Vector3), context, new Vector3SerializationSurrogate());
				surrogateSelector.AddSurrogate(typeof(Quaternion), context, new QuaternionSerializationSurrogate());
				surrogateSelector.AddSurrogate(typeof(Rect), context, new RectSerializationSurrogate());
				_formatter.SurrogateSelector = surrogateSelector;
			}
			return _formatter;
		}
	}
}
