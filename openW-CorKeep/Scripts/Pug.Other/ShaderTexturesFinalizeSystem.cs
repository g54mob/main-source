using PugTilemap;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(PresentationSystemGroup))]
public class ShaderTexturesFinalizeSystem : SystemBase
{
	private const int width = 36;

	private const int height = 24;

	public Texture2D electricityTex;

	public Texture2D groundFogTintTex;

	private Texture2D[] ignoreVertexOffsetTextures;

	private int ignoreVertexOffsetTextureWriteIndex;

	private ShaderTexturesSystem scheduledSystem;

	private SinglePugMap pugMap;

	private static readonly int ElectricityTex = Shader.PropertyToID("ElectricityTex");

	private static readonly int GroundFogTintTex = Shader.PropertyToID("GroundFogTintTex");

	private static readonly int IgnoreVertexOffsetTex = Shader.PropertyToID("_IgnoreVertexOffsetTex");

	private static readonly int Origo = Shader.PropertyToID("Origo");

	private static readonly int PlayerPosition = Shader.PropertyToID("PlayerPosition");

	private static readonly int PlayerPositionSmooth = Shader.PropertyToID("PlayerPositionSmooth");

	private static readonly int VisibleOreDistance = Shader.PropertyToID("VisibleOreDistance");

	public Texture2D CurrentIgnoreVertexOffsetTex => ignoreVertexOffsetTextures[ignoreVertexOffsetTextureWriteIndex];

	public NativeArray<Color32> BeginWriteIgnoreVertexOffsets()
	{
		ignoreVertexOffsetTextureWriteIndex = (ignoreVertexOffsetTextureWriteIndex + 1) % ignoreVertexOffsetTextures.Length;
		return CurrentIgnoreVertexOffsetTex.GetRawTextureData<Color32>();
	}

	[Preserve]
	protected override void OnCreate()
	{
		electricityTex = new Texture2D(36, 24, TextureFormat.RGBA32, mipChain: false);
		electricityTex.filterMode = FilterMode.Point;
		electricityTex.wrapMode = TextureWrapMode.Clamp;
		groundFogTintTex = new Texture2D(36, 24, TextureFormat.RGBA32, mipChain: false);
		groundFogTintTex.filterMode = FilterMode.Point;
		groundFogTintTex.wrapMode = TextureWrapMode.Clamp;
		ignoreVertexOffsetTextures = new Texture2D[1];
		ignoreVertexOffsetTextureWriteIndex = ignoreVertexOffsetTextures.Length - 1;
		for (int i = 0; i < ignoreVertexOffsetTextures.Length; i++)
		{
			ignoreVertexOffsetTextures[i] = new Texture2D(36, 24, TextureFormat.RGBA32, mipChain: false);
			ignoreVertexOffsetTextures[i].filterMode = FilterMode.Point;
			ignoreVertexOffsetTextures[i].wrapMode = TextureWrapMode.Clamp;
		}
		scheduledSystem = base.World.GetOrCreateSystemManaged<ShaderTexturesSystem>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		Object.Destroy(electricityTex);
		Object.Destroy(groundFogTintTex);
		Texture2D[] array = ignoreVertexOffsetTextures;
		for (int i = 0; i < array.Length; i++)
		{
			Object.Destroy(array[i]);
		}
		base.OnDestroy();
	}

	[Preserve]
	protected unsafe override void OnUpdate()
	{
		if ((Application.isPlaying && (Manager.sceneHandler == null || !Manager.sceneHandler.isInGame)) || !PugDatabase.inited)
		{
			return;
		}
		pugMap = Manager.multiMap;
		if (pugMap == null)
		{
			Debug.Log("no pugmap");
			return;
		}
		scheduledSystem.GetOutputDependency().Complete();
		if (!Application.isPlaying)
		{
			NativeArray<Color32> rawTextureData = CurrentIgnoreVertexOffsetTex.GetRawTextureData<Color32>();
			UnsafeUtility.MemClear(rawTextureData.GetUnsafePtr(), rawTextureData.Length * UnsafeUtility.SizeOf<Color32>());
		}
		electricityTex.Apply();
		groundFogTintTex.Apply();
		CurrentIgnoreVertexOffsetTex.Apply();
		Shader.SetGlobalTexture(ElectricityTex, electricityTex);
		Shader.SetGlobalTexture(GroundFogTintTex, groundFogTintTex);
		Shader.SetGlobalTexture(IgnoreVertexOffsetTex, CurrentIgnoreVertexOffsetTex);
		Shader.SetGlobalVector(Origo, (Vector3)Manager.camera.RenderOrigo);
		if (Manager.main.player != null)
		{
			Shader.SetGlobalVector(PlayerPosition, Manager.main.player.RenderPosition);
			Shader.SetGlobalVector(PlayerPositionSmooth, EntityMonoBehaviour.ToRenderFromWorld(Manager.main.player.SmoothWorldPosition));
			int conditionEffectValue = EntityUtility.GetConditionEffectValue(ConditionEffect.VisibleOreDistance, Manager.main.player.entity, base.World);
			Shader.SetGlobalFloat(VisibleOreDistance, conditionEffectValue);
		}
	}

	[Preserve]
	public ShaderTexturesFinalizeSystem()
	{
	}
}
