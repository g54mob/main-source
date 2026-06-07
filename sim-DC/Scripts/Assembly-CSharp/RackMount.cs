using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EPOOutline;
using UnityEngine;

public class RackMount : Interact
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public RackMount _003C_003E4__this;

		public Renderer boxedRackRenderer;

		public string cutoffPropertyName;

		public Renderer rackRenderer;

		internal void _003CInstallRack_003Eb__0(float val)
		{
		}

		internal void _003CInstallRack_003Eb__2(float val)
		{
		}

		internal void _003CInstallRack_003Eb__3()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CInstallRack_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RackMount _003C_003E4__this;

		public bool cheat;

		public int type;

		private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

		private Color? _003CcustomColor_003E5__2;

		private GameObject _003Cgo_003E5__3;

		private LODGroup _003ClodGroup_003E5__4;

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
		public _003CInstallRack_003Ed__6(int _003C_003E1__state)
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

	private Outlinable outlineEffect;

	public bool isRackInstantiated;

	[SerializeField]
	private Material disolveMaterial;

	private Material originalRackMaterial;

	public override void Awake()
	{
	}

	public override void InteractOnClick()
	{
	}

	[IteratorStateMachine(typeof(_003CInstallRack_003Ed__6))]
	private IEnumerator InstallRack(bool cheat = false, int type = 0)
	{
		return null;
	}

	public GameObject InstantiateRack(InteractObjectData saveData = null)
	{
		return null;
	}

	private void ApplyMaterialToLODs(GameObject rackGO, Material mat)
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}

	private void OnLoad()
	{
	}

	private void OnDestroy()
	{
	}

	private void CheatInsertRack(GameObject go, int type)
	{
	}
}
