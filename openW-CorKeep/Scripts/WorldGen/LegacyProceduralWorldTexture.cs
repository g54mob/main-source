using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class LegacyProceduralWorldTexture : MonoBehaviour
{
	private enum UpdateStatus
	{
		None = 0,
		Pending = 1,
		Done = 2
	}

	public struct TileTypeExtractor
	{
		[ReadOnly]
		private NativeArray<byte> _texelData;

		private NativeHashMap<PugColor32, TileCD> _tileColorToType;

		private readonly int _textureSize;

		[ReadOnly]
		private NativeList<PugColor32> _tileColors;

		[ReadOnly]
		private NativeList<TileCD> _tiles;

		public TileTypeExtractor(in NativeArray<byte> texelData, int textureSize, NativeHashMap<PugColor32, TileCD> tileColorToType, NativeList<PugColor32> tileColors, NativeList<TileCD> tiles, AllocatorManager.AllocatorHandle allocatorHandle)
		{
			_tileColorToType = tileColorToType;
			_texelData = CollectionHelper.CreateNativeArray(texelData, allocatorHandle);
			_textureSize = textureSize;
			_tileColors = tileColors;
			_tiles = tiles;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[GenerateTestsForBurstCompatibility]
		public TileCD GetTileType(int2 localPosition)
		{
			int num = 3 * (localPosition.y * _textureSize + localPosition.x);
			PugColor32 pugColor = new PugColor32(_texelData[num], _texelData[num + 1], _texelData[num + 2], byte.MaxValue);
			if (pugColor.r == 0 && pugColor.g == 0 && pugColor.b == 0)
			{
				return default(TileCD);
			}
			if (!_tileColorToType.TryGetValue(pugColor, out var item))
			{
				Debug.LogWarning("Using closest match in world generation for missing tile color");
				float num2 = float.MaxValue;
				int index = -1;
				for (int i = 0; i < _tileColors.Length; i++)
				{
					PugColor32 pugColor2 = _tileColors[i];
					float num3 = DistanceSq(pugColor, pugColor2);
					if (num3 < num2)
					{
						index = i;
						num2 = num3;
					}
				}
				if (num2 < 10f)
				{
					item = _tiles[index];
				}
				_tileColorToType.Add(pugColor, item);
			}
			return item;
		}

		private float DistanceSq(Color32 a, Color32 b)
		{
			float num = (float)(int)b.r - (float)(int)a.r;
			float num2 = (float)(int)b.g - (float)(int)a.g;
			float num3 = (float)(int)b.b - (float)(int)a.b;
			return num * num + num2 * num2 + num3 * num3;
		}
	}

	public Transform worldRenderRoot;

	public Camera worldPixelCamera;

	public MeshRenderer worldRenderQuad;

	public TileTypeColorTable tileTypeColorTable;

	public SpriteRenderer debugSprite;

	[SerializeField]
	private int m_textureSize = 64;

	private NativeArray<byte> m_texels;

	private Texture2D m_proceduralWorldTexture;

	private RenderTexture m_internalTarget;

	private CommandBuffer m_cmd;

	private NativeHashMap<PugColor32, TileCD> tileColorToType;

	private NativeList<PugColor32> tileColors;

	private NativeList<TileCD> tiles;

	private bool m_asyncGpuReadbackSupported;

	private UpdateStatus Status { get; set; }

	private void Awake()
	{
		worldPixelCamera.enabled = false;
		m_internalTarget = new RenderTexture(m_textureSize, m_textureSize, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear)
		{
			useMipMap = false,
			name = "ProceduralWorldTextureTarget_" + base.name
		};
		m_internalTarget.Create();
		m_internalTarget.filterMode = FilterMode.Point;
		m_internalTarget.anisoLevel = 0;
		m_proceduralWorldTexture = new Texture2D(m_internalTarget.width, m_internalTarget.height, TextureFormat.RGB24, mipChain: false);
		m_proceduralWorldTexture.filterMode = FilterMode.Point;
		debugSprite.gameObject.SetActive(value: false);
		m_cmd = new CommandBuffer
		{
			name = "ProceduralWorldTexture"
		};
		m_texels = new NativeArray<byte>(m_textureSize * m_textureSize * 3, Allocator.Persistent);
		Status = UpdateStatus.None;
		tileColorToType = new NativeHashMap<PugColor32, TileCD>(128, Allocator.Persistent);
		tileColors = new NativeList<PugColor32>(128, Allocator.Persistent);
		tiles = new NativeList<TileCD>(128, Allocator.Persistent);
		foreach (TileTypeColorTable.TileSetColors tileSetColor in tileTypeColorTable.tileSetColors)
		{
			foreach (TileTypeColorTable.TileColor tileColor in tileSetColor.tileColors)
			{
				TileCD value = new TileCD
				{
					tileset = (int)tileSetColor.pugMapTileset,
					tileType = tileColor.tileType
				};
				if (tileColorToType.TryAdd(tileColor.color, value))
				{
					tileColors.Add((PugColor32)tileColor.color);
					tiles.Add(in value);
				}
			}
		}
		m_asyncGpuReadbackSupported = SystemInfo.supportsAsyncGPUReadback;
		if (!m_asyncGpuReadbackSupported)
		{
			Debug.LogWarning("Async GPU readback is not supported. Procedural world generation will not work as intended.");
		}
	}

	private void OnDestroy()
	{
		m_internalTarget.Release();
		Object.Destroy(m_proceduralWorldTexture);
		m_texels.Dispose();
		tileColorToType.Dispose();
		tileColors.Dispose();
		tiles.Dispose();
	}

	public void ScheduleWorldPixelUpdate(int2 position, int2 size)
	{
		worldRenderRoot.transform.position = new Vector3(position.x, worldRenderRoot.transform.position.y, position.y) + 0.5f * new Vector3(m_internalTarget.width, 0f, m_internalTarget.height);
		RenderWorld();
	}

	public bool IsUpdating()
	{
		return Status == UpdateStatus.Pending;
	}

	public TileTypeExtractor GetTileTypeExtractor(AllocatorManager.AllocatorHandle allocatorHandle)
	{
		return new TileTypeExtractor(in m_texels, m_proceduralWorldTexture.width, tileColorToType, tileColors, tiles, allocatorHandle);
	}

	private void RenderWorld()
	{
		if (!m_asyncGpuReadbackSupported)
		{
			Status = UpdateStatus.Done;
			return;
		}
		Matrix4x4 inverse = Matrix4x4.TRS(worldPixelCamera.transform.position, worldPixelCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
		float num = worldPixelCamera.orthographicSize * worldPixelCamera.aspect;
		float orthographicSize = worldPixelCamera.orthographicSize;
		Matrix4x4 proj = Matrix4x4.Ortho(0f - num, num, 0f - orthographicSize, orthographicSize, worldPixelCamera.nearClipPlane, worldPixelCamera.farClipPlane);
		m_cmd.Clear();
		m_cmd.SetRenderTarget(m_internalTarget);
		m_cmd.ClearRenderTarget(clearDepth: false, clearColor: true, worldPixelCamera.backgroundColor);
		m_cmd.SetViewProjectionMatrices(inverse, proj);
		m_cmd.DrawRenderer(worldRenderQuad, worldRenderQuad.sharedMaterial);
		m_cmd.RequestAsyncReadbackIntoNativeArray(ref m_texels, m_internalTarget, 0, 0, m_textureSize, 0, m_textureSize, 0, 1, TextureFormat.RGB24, delegate(AsyncGPUReadbackRequest action)
		{
			if (action.hasError)
			{
				Debug.LogError("Failed to request async readback of procedural texture.");
				ClearArrayContents(ref m_texels);
			}
			Status = UpdateStatus.Done;
		});
		Status = UpdateStatus.Pending;
		Graphics.ExecuteCommandBuffer(m_cmd);
	}

	private static void ClearArrayContents(ref NativeArray<byte> array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 0;
		}
	}
}
