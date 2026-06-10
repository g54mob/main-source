using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

internal class SeeThrough : CustomPass
{
	[CompilerGenerated]
	private sealed class _003CRegisterMaterialForInspector_003Ed__7 : IEnumerable<Material>, IEnumerable, IEnumerator<Material>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Material _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public SeeThrough _003C_003E4__this;

		Material IEnumerator<Material>.Current
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
		public _003CRegisterMaterialForInspector_003Ed__7(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Material> IEnumerable<Material>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public LayerMask seeThroughLayer;

	public Material seeThroughMaterial;

	[HideInInspector]
	[SerializeField]
	private Shader stencilShader;

	private Material stencilMaterial;

	private ShaderTagId[] shaderTags;

	protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
	{
	}

	protected override void Execute(CustomPassContext ctx)
	{
	}

	[IteratorStateMachine(typeof(_003CRegisterMaterialForInspector_003Ed__7))]
	public override IEnumerable<Material> RegisterMaterialForInspector()
	{
		return null;
	}

	private void RenderObjects(ScriptableRenderContext renderContext, CommandBuffer cmd, Material overrideMaterial, int passIndex, CompareFunction depthCompare, CullingResults cullingResult, HDCamera hdCamera, StencilState? overrideStencil = null)
	{
	}

	protected override void Cleanup()
	{
	}
}
