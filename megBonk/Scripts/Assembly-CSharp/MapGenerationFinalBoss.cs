using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapGenerationFinalBoss : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGenerateMap_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapGenerationFinalBoss _003C_003E4__this;

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
		public _003CGenerateMap_003Ed__15(int _003C_003E1__state)
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

	public MapData testMapData;

	public StageData testStageData;

	public GameManager gameManager;

	public Transform spawnTransform;

	public GrassChunkManager grassRenderer;

	public GameObject colliderBox;

	public MinimapMesh minimapMesh;

	public GameObject spawnPortal;

	public MeshRenderer worldMeshRenderer;

	public MeshFilter worldMeshFilter;

	public MeshRenderer[] renderersForMaterial;

	public Light sunLight;

	private Vector3 spawnPosition;

	private Vector3 spawnDirection;

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003CGenerateMap_003Ed__15))]
	private IEnumerator GenerateMap()
	{
		return null;
	}

	public GameObject Spawn()
	{
		return null;
	}
}
