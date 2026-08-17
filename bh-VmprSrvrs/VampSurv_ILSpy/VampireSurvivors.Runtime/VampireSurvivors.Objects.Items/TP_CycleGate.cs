using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Items;

public class TP_CycleGate : PickupTeleporter
{
	private MapToken _mapToken;

	public void SetGateIndex(int index)
	{
		//IL_00ae: Expected O, but got I8
		//IL_001f: Expected O, but got I8
		//IL_0053: Expected F4, but got O
		GateIndex = index;
		object obj = 6442450944L;
		MapToken mapToken = default(MapToken);
		if (index <= 6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rbp_v1+7379264+index @ rdx (System.Int32)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ rcx_v24 (should have been resolved before IL gen)");
		}
		else
		{
			mapToken = new MapToken();
		}
		mapToken.texture = "TP_items";
		mapToken.frameName = "";
		float2 float5 = base.position;
		mapToken.x = (float)float5;
		float2 float6 = base.position;
		float y = default(float);
		mapToken.y = y;
		_mapToken = mapToken;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
	}

	protected override void GenerateSpritesAndAnims()
	{
		PhaserSprite door = _door;
		_hasDoorAnimation = false;
		if ((object)_door == null || ((UnityEngine.Object)door).m_CachedPtr == (IntPtr)0)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "NoDraw");
			GameObject gameObject = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName("PickupTeleporter - Door");
			_door = phaserSprite;
		}
	}

	public override void Despawn()
	{
		if (_mapToken != null)
		{
			GameManager core = GM.Core;
			bool flag = ((List<object>)(object)core._mapTokens).Remove((object)_mapToken);
			_mapToken = null;
		}
	}

	protected override void OnGateIndexChanged(int oldValue, int newValue)
	{
		SetGateIndex(newValue);
	}

	public TP_CycleGate()
	{
		base._canTeleport = true;
		_hasDoorAnimation = true;
		_triggerDelay = 10000f;
		((PickupGuarded)this)._002Ector();
	}
}
