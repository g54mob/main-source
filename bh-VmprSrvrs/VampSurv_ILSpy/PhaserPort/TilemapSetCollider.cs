using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;

public class TilemapSetCollider : Collider
{
	private struct TilemapSet
	{
		public List<PhaserTilemap> _tilemaps;
	}

	private TilemapSet[] _tilemapSets;

	private float4[] _tilemapSetBounds;

	public TilemapSetCollider(World world, bool overlapOnly, ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		TilemapSet[] tilemapSets = new TilemapSet[4];
		_tilemapSets = tilemapSets;
		_tilemapSetBounds = new float4[4];
		bool overlapOnly2 = default(bool);
		ArcadeColliderType object3 = default(ArcadeColliderType);
		ArcadeColliderType object4 = default(ArcadeColliderType);
		ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext2 = default(CallbackContext);
		base._002Ector(world, overlapOnly2, object3, object4, collideCallback2, processCallback2, callbackContext2);
		TilemapSet[] tilemapSets2 = _tilemapSets;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < tilemapSets2.Length)
		{
			TilemapSet[] tilemapSets3 = _tilemapSets;
			_ = 0;
			TilemapSet[] tilemapSets4 = _tilemapSets;
			List<PhaserTilemap> list = new List<PhaserTilemap>();
			tilemapSets2 = _tilemapSets;
			obj++;
			obj2 = obj;
		}
	}

	public void AddTilemap(int setID, PhaserTilemap tilemap)
	{
		TilemapSet[] tilemapSets = _tilemapSets;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B44C0");
	}

	public unsafe override void update()
	{
		//IL_0de6: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_009f: Expected O, but got I4
		//IL_00a9: Expected O, but got I4
		//IL_00bf: Expected O, but got Ref
		//IL_0e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e18: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0130: Expected O, but got I
		//IL_015f: Expected O, but got Ref
		ArcadeColliderType @object = _object1;
		nint num = (nint)typeof(PhysicsGroup);
		nint num2 = (nint)@object;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v1 (Il2CppClass<PhysicsGroup>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r9_v9 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v1 (Il2CppClass<PhysicsGroup>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r9_v9 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v8+FFFFFFF8+v64 @ rax_v5*8]");
			if (0 == (nint)typeof(PhysicsGroup))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ r8_v9 (ArcadeColliderType)+18]");
				TilemapSet tilemapSet = (TilemapSet)0;
				object obj3 = 0;
				object obj4 = 0;
				do
				{
					TilemapSet[] tilemapSets = _tilemapSets;
					TilemapSet tilemapSet2 = (TilemapSet)System.Runtime.CompilerServices.Unsafe.AsPointer(ref tilemapSets[obj4]);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v9 (TilemapSetCollider+TilemapSet)+18]");
					if ((nint)0 > (nint)0)
					{
						float4[] tilemapSetBounds = _tilemapSetBounds;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						object obj5 = obj4 + 2;
						object obj6 = obj5 + obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v73+90]");
						obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v73+90]");
						_ = 0;
					}
					obj4++;
				}
				while ((nint)obj4 < 4);
				PhaserGameObject phaserGameObject = null;
				HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
				if (enumerator.MoveNext())
				{
					PhaserGameObject phaserGameObject2 = null;
					HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				return;
			}
		}
		throw new InvalidCastException();
	}
}
