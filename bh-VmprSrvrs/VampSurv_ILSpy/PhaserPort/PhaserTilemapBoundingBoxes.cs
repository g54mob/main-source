using System;
using Cpp2ILInjected;
using UnityEngine;

public class PhaserTilemapBoundingBoxes : MonoBehaviour
{
	public static readonly string GuideUrl = "https://drive.google.com/file/d/1mJgWiDhYVufSAGHzAuLrhx2pikdKpZXn/view?usp=sharing";

	public PhaserTilemapBoundingBoxesAsset _asset;

	public PhaserTilemap tilemap;

	protected float gizmosAlpha;

	protected int gizmosSeed;

	public void Clear()
	{
		PhaserTilemap phaserTilemap = tilemap;
		if ((object)tilemap == null || ((UnityEngine.Object)phaserTilemap).m_CachedPtr == (IntPtr)0)
		{
			PhaserTilemap component = GetComponent<PhaserTilemap>();
			tilemap = component;
		}
		_asset.Setup(tilemap);
	}

	public void MakeSingle()
	{
		PhaserTilemap phaserTilemap = tilemap;
		if ((object)tilemap == null || ((UnityEngine.Object)phaserTilemap).m_CachedPtr == (IntPtr)0)
		{
			PhaserTilemap component = GetComponent<PhaserTilemap>();
			tilemap = component;
		}
		_asset.MakeWholeBound(tilemap);
	}

	public PhaserTilemapBoundingBoxes()
	{
		//IL_002b: Expected I, but got O
		gizmosAlpha = 0.75f;
		gizmosSeed = 1111;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
