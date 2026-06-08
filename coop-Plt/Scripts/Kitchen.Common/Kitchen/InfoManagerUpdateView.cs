#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Kitchen.NetworkSupport;
using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class InfoManagerUpdateView : ResponsiveViewSystemBase<InfoManagerViewData, InfoManagerResponseData>
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass7_0
		{
			public InfoManagerUpdateView _003C_003E4__this;

			public bool cache_updated;

			internal void _003COnUpdate_003Eb__0(Entity entity, in CLinkedView linked_view, in SPlayerInfoManager man)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public StructuralChangeEntityProvider _entityProvider;

					public LambdaParameterValueProvider_Entity.StructuralChangeRuntime runtime_entity;

					public LambdaParameterValueProvider_IComponentData<CLinkedView>.StructuralChangeRuntime runtime_linked_view;

					public LambdaParameterValueProvider_IComponentData_Tag<SPlayerInfoManager>.StructuralChangeRuntime runtime_man;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<SPlayerInfoManager> forParameter_man;

				public void ScheduleTimeInitialize(InfoManagerUpdateView componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_man.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteWithStructuralChanges(ComponentSystemBase p0, EntityQuery p1)
				{
					Runtimes result = default(Runtimes);
					result._entityProvider.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_entity = forParameter_entity.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_linked_view = forParameter_linked_view.PrepareToExecuteWithStructuralChanges(p0, p1);
					result.runtime_man = forParameter_man.PrepareToExecuteWithStructuralChanges(p0, p1);
					return result;
				}
			}

			public InfoManagerUpdateView _003C_003E4__this;

			public bool cache_updated;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			public unsafe static StructuralChangeEntityProvider.PerformLambdaDelegate _performLambdaDelegate = PerformLambda;

			internal void OriginalLambdaBody(Entity entity, in CLinkedView linked_view, in SPlayerInfoManager man)
			{
				if (!_003C_003E4__this.LinkedViewCache.Contains(linked_view.Identifier.Identifier))
				{
					_003C_003E4__this.LinkedViewCache.Add(linked_view.Identifier.Identifier);
					if (!cache_updated)
					{
						cache_updated = true;
						_003C_003E4__this._TransmitCache.Players.Clear();
						_003C_003E4__this._TransmitCache.Peers.Clear();
						foreach (InfoManagerPeerDetail item in _003C_003E4__this.PeerInfoCache)
						{
							_003C_003E4__this._TransmitCache.Peers.Add(item);
						}
						foreach (InfoManagerPlayerDetail item2 in _003C_003E4__this.PlayerInfoCache)
						{
							_003C_003E4__this._TransmitCache.Players.Add(item2);
						}
					}
					_003C_003E4__this.SendUpdate(linked_view, _003C_003E4__this._TransmitCache);
				}
				_003C_003E4__this.ApplyUpdates(linked_view.Identifier, _003C_003E4__this.HandleResponse);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass7_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				cache_updated = displayClass.cache_updated;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass7_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.cache_updated = cache_updated;
			}

			public unsafe static void PerformLambda(void* jobStructPtr, void* runtimesPtr, Entity entity)
			{
				ref LambdaParameterValueProviders.Runtimes reference = ref UnsafeUtility.AsRef<LambdaParameterValueProviders.Runtimes>(runtimesPtr);
				Entity entity2 = reference.runtime_entity.For(entity);
				CLinkedView originalComponent;
				CLinkedView linked_view = reference.runtime_linked_view.For(entity, out originalComponent);
				SPlayerInfoManager originalComponent2;
				SPlayerInfoManager man = reference.runtime_man.For(entity, out originalComponent2);
				UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobStructPtr).OriginalLambdaBody(entity2, in linked_view, in man);
			}

			public unsafe void Execute(ComponentSystemBase componentSystem, EntityQuery query)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteWithStructuralChanges(componentSystem, query);
				_runtimes = &runtimes;
				runtimes._entityProvider.IterateEntities(System.Runtime.CompilerServices.Unsafe.AsPointer(ref this), _runtimes, _performLambdaDelegate);
			}

			public void ScheduleTimeInitialize(InfoManagerUpdateView componentSystem, ref _003C_003Ec__DisplayClass7_0 displayClass)
			{
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private EntityQuery PlayerEntities;

		private List<InfoManagerPlayerDetail> PlayerInfoCache = new List<InfoManagerPlayerDetail>();

		private List<InfoManagerPeerDetail> PeerInfoCache = new List<InfoManagerPeerDetail>();

		private List<int> LinkedViewCache = new List<int>();

		private InfoManagerViewData _TransmitCache = new InfoManagerViewData
		{
			Players = new List<InfoManagerPlayerDetail>(),
			Peers = new List<InfoManagerPeerDetail>()
		};

		private Dictionary<int, string> PlayerNameCache = new Dictionary<int, string>();

		private List<InfoManagerPlayerDetail> _TempPlayerCache = new List<InfoManagerPlayerDetail>();

		private List<InfoManagerPeerDetail> _TempPeerCache = new List<InfoManagerPeerDetail>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			PlayerEntities = GetEntityQuery(typeof(CPlayer), typeof(CPlayerColour));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass7_0 displayClass = new _003C_003Ec__DisplayClass7_0
			{
				_003C_003E4__this = this
			};
			EnsureSingleton();
			using NativeArray<Entity> user_entities = PlayerEntities.ToEntityArray(Allocator.TempJob);
			if (UpdateInfo(user_entities))
			{
				LinkedViewCache.Clear();
			}
			displayClass.cache_updated = false;
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
			try
			{
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.Execute(this, query);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
			}
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.WriteToDisplayClass(ref displayClass);
		}

		protected bool UpdateInfo(NativeArray<Entity> user_entities)
		{
			_TempPlayerCache.Clear();
			_TempPeerCache.Clear();
			foreach (Entity item in user_entities)
			{
				_TempPlayerCache.Add(PlayerInfoFromEntity(item));
			}
			List<NetworkTargetDescription> users = new List<NetworkTargetDescription>();
			Session.GetConnectedPlayers(ref users);
			_TempPeerCache.Add(new InfoManagerPeerDetail
			{
				Identifier = InputSourceIdentifier.Identifier,
				MainName = Platform.Current.GetDisplayName(Platform.Current.PrimaryUser)
			});
			foreach (NetworkTargetDescription item2 in users)
			{
				_TempPeerCache.Add(PeerInfoFromDescription(item2));
			}
			for (int i = 0; i < _TempPeerCache.Count; i++)
			{
				InfoManagerPeerDetail value = _TempPeerCache[i];
				foreach (InfoManagerPlayerDetail item3 in _TempPlayerCache)
				{
					if (item3.Identifier == value.Identifier)
					{
						value.HasPlayers = true;
						_TempPeerCache[i] = value;
						break;
					}
				}
			}
			bool result = HasChangesInCache();
			List<InfoManagerPlayerDetail> playerInfoCache = PlayerInfoCache;
			List<InfoManagerPlayerDetail> tempPlayerCache = _TempPlayerCache;
			_TempPlayerCache = playerInfoCache;
			PlayerInfoCache = tempPlayerCache;
			List<InfoManagerPeerDetail> peerInfoCache = PeerInfoCache;
			List<InfoManagerPeerDetail> tempPeerCache = _TempPeerCache;
			_TempPeerCache = peerInfoCache;
			PeerInfoCache = tempPeerCache;
			return result;
		}

		private bool HasChangesInCache()
		{
			if (_TempPeerCache.Count != PeerInfoCache.Count)
			{
				return true;
			}
			if (_TempPlayerCache.Count != PlayerInfoCache.Count)
			{
				return true;
			}
			foreach (InfoManagerPeerDetail item in _TempPeerCache)
			{
				bool flag = false;
				foreach (InfoManagerPeerDetail item2 in PeerInfoCache)
				{
					if (!item2.IsChangedFrom(item))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			foreach (InfoManagerPlayerDetail item3 in _TempPlayerCache)
			{
				bool flag2 = false;
				foreach (InfoManagerPlayerDetail item4 in PlayerInfoCache)
				{
					if (!item4.IsChangedFrom(item3))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return true;
				}
			}
			return false;
		}

		private InfoManagerPeerDetail PeerInfoFromDescription(NetworkTargetDescription description)
		{
			if (Session.GetPeerInfo(description.Target, out var result))
			{
				return new InfoManagerPeerDetail
				{
					Identifier = result.Item1,
					MainName = result.Item2.Name
				};
			}
			return default(InfoManagerPeerDetail);
		}

		private InfoManagerPlayerDetail PlayerInfoFromEntity(Entity user)
		{
			CPlayer component = GetComponent<CPlayer>(user);
			string text = PlatformSettings.MissingUserName;
			NetworkPeerInformation result;
			if (component.InputSource == InputSourceIdentifier.Identifier)
			{
				PlatformUser platformUser = Session.GameCreator.InputSource.GetPlatformUser(component.ID);
				text = Platform.Current.GetDisplayName(platformUser);
			}
			else if (Session.GetPeerInfo(component.InputSource, out result))
			{
				text = result.Name;
			}
			PlayerNameCache.TryGetValue(component.ID, out var value);
			value = (string.IsNullOrEmpty(value) ? text : value);
			CJoiningPlayer comp;
			CPlayerCosmetics comp2;
			return new InfoManagerPlayerDetail
			{
				ID = component.ID,
				Identifier = component.InputSource,
				MainName = text,
				SubName = value,
				Index = component.Index,
				JoinProgress = (Require<CJoiningPlayer>(user, out comp) ? comp.Progress : (-1f)),
				Colour = GetComponent<CPlayerColour>(user).Color,
				Cosmetics = (Require<CPlayerCosmetics>(user, out comp2) ? comp2.Cosmetics : default(DataObjectList))
			};
		}

		private void HandleResponse(InfoManagerResponseData responses)
		{
			foreach (InfoManagerResponseUpdate update in responses.Updates)
			{
				PlayerNameCache[update.PlayerID] = update.Profile.Name;
				if (update.Profile.Colour != default(Color))
				{
					Entity entity = base.EntityManager.CreateEntity();
					base.EntityManager.AddComponentData(entity, new CSetPlayerProfile
					{
						PlayerID = update.PlayerID,
						Colour = update.Profile.Colour,
						Cosmetics = update.Profile.Cosmetics
					});
				}
			}
		}

		private void EnsureSingleton()
		{
			if (!HasSingleton<SPlayerInfoManager>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SPlayerInfoManager), typeof(CRequiresView), typeof(CPosition), typeof(CPersistThroughSceneChanges));
				base.EntityManager.SetComponentData(entity, new CRequiresView
				{
					Type = ViewType.PlayerInfoManager,
					ViewMode = ViewMode.Screen
				});
				base.EntityManager.SetComponentData(entity, new CPosition(new Vector3(0.5f, 0f, 0f)));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadOnly<SPlayerInfoManager>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
