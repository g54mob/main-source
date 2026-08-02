using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class PartThumbnailBuilder : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass22_0
		{
			public Bounds bounds;

			public PartView view;
		}

		[CompilerGenerated]
		private sealed class _003CBake_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PartThumbnailBuilder _003C_003E4__this;

			public PartThumbnailBuilderItem item;

			private _003C_003Ec__DisplayClass22_0 _003C_003E8__1;

			private Part _003Cpart_003E5__2;

			private Highlightable _003CviewHighlightable_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CBake_003Ed__22(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public Camera cam;

		public GameObject scene;

		public Transform ground;

		public ViewLoader viewLoader;

		public ProjectConfigEntry projectConfig;

		public HighlightConfig highlightConfig;

		public float size;

		public Vector2Int resolution;

		public float pixelPerUnit;

		public Vector3 fitRotation;

		public List<PartThumbnailBuilderItem> queue;

		private Context context;

		private Project project;

		private bool isBaking;

		private RenderTexture renderTexture;

		private Highlight highlight;

		public Dictionary<PartThumbnailBuilderItem, Texture2D> bakedTextures;

		public static PartThumbnailBuilder instance;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public Task<Texture2D> Build(PartThumbnailBuilderItem item)
		{
			return null;
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CBake_003Ed__22))]
		private IEnumerator Bake(PartThumbnailBuilderItem item)
		{
			return null;
		}
	}
}
