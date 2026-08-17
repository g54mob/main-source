using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.MapGeneration;
using Cpp2ILInjected;
using UnityEngine;

public class MapGenerationFinalBoss : MonoBehaviour
{
	private sealed class _003CGenerateMap_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapGenerationFinalBoss _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CGenerateMap_003Ed__15(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_001e: Expected I4, but got I8
			//IL_04bd: Expected I4, but got O
			//IL_04d5: Expected I, but got O
			//IL_04f3: Expected I, but got O
			//IL_00ca: Expected O, but got F4
			//IL_011a: Expected O, but got F4
			//IL_01b3: Expected O, but got I4
			//IL_01bc: Expected O, but got I4
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Expected O, but got Unknown
			//IL_037d: Expected O, but got Ref
			//IL_03db: Expected O, but got Ref
			//IL_0410: Expected I, but got O
			//IL_054d: Expected I, but got O
			//IL_0481: Expected O, but got Ref
			if (_003C_003E1__state == 0)
			{
				MapGenerationFinalBoss mapGenerationFinalBoss = _003C_003E4__this;
				_003C_003E1__state = -1;
				int num = UnityEngine.Random.Range(0, 2147483647);
				if ((object)_003C_003E4__this != null && (object)mapGenerationFinalBoss.gameManager != null)
				{
					mapGenerationFinalBoss.gameManager.CreateInstances();
					StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
					MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
					nint num2 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rcx_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num3 = 0;
					nint num4 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v13 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
					float num6 = 0f * 300f;
					if ((object)mapGenerationFinalBoss.spawnTransform != null)
					{
						Vector3 position = mapGenerationFinalBoss.spawnTransform.position;
						mapGenerationFinalBoss.spawnPosition = (Vector3)position.x;
						_ = position.z;
						if ((object)mapGenerationFinalBoss.spawnTransform != null)
						{
							Vector3 forward = mapGenerationFinalBoss.spawnTransform.forward;
							mapGenerationFinalBoss.spawnDirection = (Vector3)forward.x;
							_ = forward.z;
							if ((object)MapController._003CcurrentMap_003Ek__BackingField != null && (object)mapGenerationFinalBoss.worldMeshRenderer != null)
							{
								((Renderer)mapGenerationFinalBoss.worldMeshRenderer).SetMaterial(mapData.finalStageMaterial);
								MeshRenderer[] renderersForMaterial = mapGenerationFinalBoss.renderersForMaterial;
								if (mapGenerationFinalBoss.renderersForMaterial != null)
								{
									object obj = 0;
									object obj2 = 0;
									float num7 = default(float);
									Vector3 vector = default(Vector3);
									Vector3 vector2 = default(Vector3);
									while (true)
									{
										if ((nint)obj < renderersForMaterial.Length)
										{
											if ((object)renderersForMaterial[obj2] == null)
											{
												break;
											}
											((Renderer)renderersForMaterial[obj2]).SetMaterial(mapData.finalStageMaterial);
											obj2++;
											obj = obj2;
											continue;
										}
										if ((object)MapController._003CcurrentStage_003Ek__BackingField == null)
										{
											break;
										}
										if (stageData.grassMaterial != null && stageData.grassPerChunk > 0)
										{
											if ((object)mapGenerationFinalBoss.grassRenderer == null)
											{
												break;
											}
											mapGenerationFinalBoss.grassRenderer.Set(stageData.grassMaterial, stageData.grassPerChunk);
											if ((object)mapGenerationFinalBoss.grassRenderer == null)
											{
												break;
											}
											GameObject gameObject = mapGenerationFinalBoss.grassRenderer.gameObject;
											if ((object)gameObject == null)
											{
												break;
											}
											gameObject.SetActive(value: true);
										}
										if ((object)mapGenerationFinalBoss.colliderBox == null)
										{
											break;
										}
										Transform transform = mapGenerationFinalBoss.colliderBox.transform;
										if ((object)transform == null)
										{
											break;
										}
										transform.position = (Vector3)(&num7);
										if ((object)mapGenerationFinalBoss.colliderBox == null)
										{
											break;
										}
										Transform transform2 = mapGenerationFinalBoss.colliderBox.transform;
										if ((object)transform2 == null)
										{
											break;
										}
										transform2.localScale = (Vector3)(&num7);
										float num8 = num6 * 0.5f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
										float num9 = 0f - num8;
										nint num10 = (nint)typeof(MapInfo);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ rcx_v31 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
										nint num11 = 0;
										MapInfo.mapBoundsLower = vector;
										nint num12 = (nint)typeof(MapInfo);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rax_v35 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
										nint num13 = 0;
										float num14 = num6 * 0.5f;
										float num15 = num14;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
										float num16 = num15 + 0f;
										MapInfo.mapBoundsUpper = vector;
										MapController._003CcurrentStage_003Ek__BackingField.ApplyFogAndSky(mapGenerationFinalBoss.sunLight);
										GameObject gameObject2 = MapController._003CcurrentStage_003Ek__BackingField.SpawnParticles();
										RenderSettings.fogDensity = 0.005f;
										if ((object)mapGenerationFinalBoss.worldMeshFilter == null)
										{
											break;
										}
										Mesh sharedMesh = mapGenerationFinalBoss.worldMeshFilter.sharedMesh;
										if ((object)mapGenerationFinalBoss.minimapMesh == null)
										{
											break;
										}
										mapGenerationFinalBoss.minimapMesh.Set(sharedMesh, (Color)(&vector2));
										return false;
									}
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
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
		_003CGenerateMap_003Ed__15 obj = new _003CGenerateMap_003Ed__15(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator GenerateMap()
	{
		_003CGenerateMap_003Ed__15 obj = new _003CGenerateMap_003Ed__15(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe GameObject Spawn()
	{
		//IL_0089: Expected O, but got Ref
		//IL_0018: Expected O, but got Ref
		//IL_0018: Expected O, but got Ref
		object obj = default(object);
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&obj));
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(spawnPortal, (Vector3)(&obj), (Quaternion)(&obj2));
		if ((object)gameObject != null)
		{
			SpawnPlayerPortal component = gameObject.GetComponent<SpawnPlayerPortal>();
			if ((object)component != null)
			{
				component.StartPortal();
				return gameObject;
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}
}
