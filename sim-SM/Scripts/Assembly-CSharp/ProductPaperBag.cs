using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ProductPaperBag : MonoBehaviour, IPoolable
{
	[CompilerGenerated]
	private sealed class _003CRenderCode_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ProductPaperBag _003C_003E4__this;

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
		public _003CRenderCode_003Ed__27(int _003C_003E1__state)
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

	[SerializeField]
	private TMP_Text m_CodeText;

	[SerializeField]
	private DecalProjector m_Decal;

	[SerializeField]
	private DecalProjector m_CodeDecal;

	[SerializeField]
	private Material m_StickerMaterial;

	[SerializeField]
	private Transform m_CodeRendererContainer;

	[SerializeField]
	private Camera m_CodeCamera;

	[SerializeField]
	private bool m_WriteCode;

	private static RTPool m_RTPool;

	private WeightedProductSO m_Product;

	private GameObject m_StickerDecalInstance;

	private RenderTexture m_Rt;

	public WeightedProductSO Product
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int Count { get; set; }

	public float Weight => 0f;

	public bool IsStickerApplied { get; private set; }

	private void UpdateDisplay()
	{
	}

	private void Awake()
	{
	}

	public void ApplySticker(Vector3 point, Vector3 normal, Vector3 size, RenderTexture rt)
	{
	}

	[IteratorStateMachine(typeof(_003CRenderCode_003Ed__27))]
	private IEnumerator RenderCode()
	{
		return null;
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}
}
