using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class ArcadeSpriteTester : ArcadeSprite
{
	public Vector2 _desiredOrigin;

	public float _desiredRadius;

	public Vector2 _desiredOffset;

	protected override void OnEnable()
	{
		//IL_0062: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0077: Expected F4, but got O
		base.OnEnable();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		Factory add = physics.add;
		PhaserGameObject phaserGameObject = add._world.enableBody(this);
		BaseBody baseBody = body.setCircle(_desiredRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setOrigin((float)_desiredOrigin, (float?)(object)1);
	}

	protected override void OnUpdate()
	{
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0036: Expected F4, but got O
		BaseBody baseBody = body.setCircle(_desiredRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setOrigin((float)_desiredOrigin, (float?)(object)1);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		body.destroy();
	}

	public ArcadeSpriteTester()
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
