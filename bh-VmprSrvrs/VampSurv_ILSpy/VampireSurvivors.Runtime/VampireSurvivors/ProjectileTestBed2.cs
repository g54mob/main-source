using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors;

public class ProjectileTestBed2 : ArcadeSprite
{
	private void Start()
	{
		//IL_00a3: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		if (body == null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			Factory add = s_scene.add;
			PhaserGameObject phaserGameObject = add._world.enableBody(this);
			if (body == null)
			{
				goto IL_0088;
			}
		}
		BaseBody baseBody = body;
		baseBody._enable = true;
		PhysicsTestbed2 sInstance = PhysicsTestbed2._sInstance;
		Group obj = sInstance.Projectiles.add(this);
		goto IL_0088;
		IL_0088:
		BaseBody baseBody2 = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody3 = body;
		float2 float5 = default(float2);
		baseBody3._transform.setOrigin(float5);
	}

	protected override void OnUpdate()
	{
		//IL_0019: Expected O, but got I4
		BaseBody baseBody = body;
		_ = 0;
		baseBody._velocity = (float2)0;
	}

	private void InitPhysics()
	{
		if (body == null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			Factory add = s_scene.add;
			PhaserGameObject phaserGameObject = add._world.enableBody(this);
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._enable = true;
			PhysicsTestbed2 sInstance = PhysicsTestbed2._sInstance;
			Group obj = sInstance.Projectiles.add(this);
		}
	}

	public ProjectileTestBed2()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
