using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic;
using Rhizomatic.ImUI;
using Rhizomatic.Pooling;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public class KitGeneratorPart : Part<KitGeneratorPartConfig>, IMissionBake
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			public Dictionary<Part, EntityData> partsData;

			public Dictionary<Id, Part> partsId;

			public Dictionary<PartConfig, int> partOrders;

			internal int _003CGenerateCatalog_003Eb__4(KitPart a, KitPart b)
			{
				return 0;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass21_0
		{
			public Module module;

			internal bool _003CGenerateManual_003Eb__0(KitPart e)
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBakeMission_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public KitGeneratorPart _003C_003E4__this;

			public ProgressTaskGroup task;

			public BakedMission mission;

			private TaskAwaiter<Kit> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGenerateCatalog_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ProgressTaskGroup taskGroup;

			public KitGeneratorPart _003C_003E4__this;

			public Kit kit;

			private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

			private ProgressTaskNode _003Cprogress_003E5__2;

			private Highlight _003CkitHighlight_003E5__3;

			private Dictionary<string, KitPart> _003CpartsChecksum_003E5__4;

			private int _003Ci_003E5__5;

			private List<KitPart>.Enumerator _003C_003E7__wrap5;

			private KitPart _003C_003E7__wrap6;

			private TaskAwaiter<Texture2D> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGenerateKit_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Kit> _003C_003Et__builder;

			public ProgressTaskGroup taskGroup;

			public KitGeneratorPart _003C_003E4__this;

			private Kit _003Ckit_003E5__2;

			private ProgressTaskGroup _003CmanualTask_003E5__3;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGenerateKitCached_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Kit> _003C_003Et__builder;

			public KitGeneratorPart _003C_003E4__this;

			public ProgressTaskGroup taskGroup;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

			private TaskAwaiter<Kit> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGenerateManual_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ProgressTaskGroup taskGroup;

			public KitGeneratorPart _003C_003E4__this;

			private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

			public Kit kit;

			private ProgressTaskNode _003Cprogress_003E5__2;

			private ProjectThumbnailBuilder _003Cptb_003E5__3;

			private Project _003CexhibitProject_003E5__4;

			private ExhibitBuilder _003CexhibitBuilder_003E5__5;

			private Highlight _003CkitHighlight_003E5__6;

			private Highlight _003CkitGreyHighlight_003E5__7;

			private List<Id> _003CdisplayParts_003E5__8;

			private Dictionary<Part, EntityData> _003CoriginalData_003E5__9;

			private KitStep _003Cstep_003E5__10;

			private List<PoolObject> _003Carrows_003E5__11;

			private Dictionary<Id, Vector3> _003Coffsets_003E5__12;

			private bool _003CrotationSet_003E5__13;

			private List<Highlightable> _003Chighlightables_003E5__14;

			private List<PartView> _003CpartViews_003E5__15;

			private int _003Cindex_003E5__16;

			private KitStep _003CfinalStep_003E5__17;

			private List<KitGeneratorPartItem>.Enumerator _003C_003E7__wrap17;

			private KitGeneratorPartItem _003CitemData_003E5__19;

			private bool _003Cmerge_003E5__20;

			private Part _003Cpart_003E5__21;

			private EntityData _003CpartData_003E5__22;

			private Texture2D _003CpartImage_003E5__23;

			private TaskAwaiter<Texture2D> _003C_003Eu__1;

			private KitStep _003C_003E7__wrap23;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[JsonDataState(null)]
		public State<bool> recording;

		public List<KitGeneratorPartItem> parts;

		private Texture2D preview;

		private Part lastPart;

		public static FilePrefs kitCacheFilePrefs;

		public string bakeKey => null;

		protected override PartViewable DoCreateViewable()
		{
			return null;
		}

		protected override void OnCreated()
		{
		}

		protected override void OnDestroyed()
		{
		}

		private void OnEditStart()
		{
		}

		private void OnUI(ImUIBuilder ui)
		{
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		public string GetKitHash()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CBakeMission_003Ed__13))]
		public Task BakeMission(BakedMission mission, ProgressTaskGroup task)
		{
			return null;
		}

		protected override void Save(JsonData data)
		{
		}

		protected override void Load(JsonData data)
		{
		}

		protected override void LoadDiff(JsonData data)
		{
		}

		[AsyncStateMachine(typeof(_003CGenerateKitCached_003Ed__18))]
		public Task<Kit> GenerateKitCached(ProgressTaskGroup taskGroup)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGenerateKit_003Ed__19))]
		public Task<Kit> GenerateKit(ProgressTaskGroup taskGroup)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGenerateCatalog_003Ed__20))]
		public Task GenerateCatalog(Kit kit, ProgressTaskGroup taskGroup)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGenerateManual_003Ed__21))]
		public Task GenerateManual(Kit kit, ProgressTaskGroup taskGroup)
		{
			return null;
		}
	}
}
