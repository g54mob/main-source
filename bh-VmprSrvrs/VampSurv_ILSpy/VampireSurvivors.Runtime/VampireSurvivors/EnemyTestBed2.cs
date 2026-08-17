using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors;

public class EnemyTestBed2 : ArcadeSprite
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
		Group obj = sInstance.Enemies.add(this);
		goto IL_0088;
		IL_0088:
		BaseBody baseBody2 = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody3 = body;
		float2 float5 = default(float2);
		baseBody3._transform.setOrigin(float5);
	}

	protected override void OnUpdate()
	{
		//IL_005c: Expected I, but got O
		//IL_0022: Expected O, but got I
		nint num = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v3 (BaseBody)+54]");
		object obj = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		BaseBody baseBody2 = body;
		float2 velocity = default(float2);
		baseBody2._velocity = velocity;
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
			Group obj = sInstance.Enemies.add(this);
		}
	}

	public EnemyTestBed2()
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
