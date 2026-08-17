using System;
using System.Collections.Generic;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using Cpp2ILInjected;
using UnityEngine;

[Serializable]
public class ProceduralTile : MonoBehaviour
{
	public List<TileEdge> edges;

	public Renderer renderer;

	private Vector2Int[] globalDirections;

	public int posY;

	public bool isFlat;

	private Vector3 _003Cdir_003Ek__BackingField;

	private Vector3 _003CparentDir_003Ek__BackingField;

	public unsafe Vector3 dir
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003Cdir_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ProceduralTile)+48]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003Cdir_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe Vector3 parentDir
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CparentDir_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ProceduralTile)+54]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003CparentDir_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe TileEdge GetEdge(Vector2Int globalDirection)
	{
		//IL_0012: Expected O, but got Ref
		//IL_0070: Expected O, but got Ref
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector2Int vector2Int = default(Vector2Int);
			Vector3 vector = transform.InverseTransformDirection((Vector3)(&vector2Int));
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,dword ptr [rax+8]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,dword ptr [rax]\"");
			if (edges != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				TileEdge tileEdge = default(TileEdge);
				object obj = default(object);
				object obj4 = default(object);
				while (true)
				{
					if (enumerator.MoveNext())
					{
						bool flag = tileEdge == null;
						List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
						if (flag)
						{
							break;
						}
						bool flag2;
						if ((object)tileEdge.direction != obj)
						{
							flag2 = false;
						}
						else
						{
							object obj2 = (object)tileEdge.direction >> 32;
							object obj3 = obj2 - obj4;
							bool flag3 = obj3 == null;
							flag2 = flag3;
						}
						if (flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
							return tileEdge;
						}
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					return null;
				}
				throw new NullReferenceException();
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetGlobalRotation(Vector2Int direction)
	{
		//IL_0013: Expected O, but got Ref
		//IL_0029: Expected O, but got Ref
		Transform transform = base.transform;
		Vector2Int vector2Int = default(Vector2Int);
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&vector2Int));
		transform.rotation = (Quaternion)(&vector2Int);
	}

	public unsafe Vector2Int GlobalToLocalDirection(Vector2Int dir)
	{
		//IL_0034: Expected O, but got Ref
		//IL_0051: Expected O, but got Ref
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector2Int vector2Int = default(Vector2Int);
			Vector3 vector = transform.InverseTransformDirection((Vector3)(&vector2Int));
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rax]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+8]\"");
			object obj = default(object);
			return (Vector2Int)(&obj);
		}
		return (Vector2Int)new NullReferenceException();
	}

	public void SetPosY(int y, StageData stageData, bool isFlat, Vector3 dir, Vector3 parentDir)
	{
		posY = y;
		this.isFlat = isFlat;
		object obj = default(object);
		_003Cdir_003Ek__BackingField = (Vector3)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ stack_28+8]");
		_ = 0;
		object obj2 = default(object);
		_003CparentDir_003Ek__BackingField = (Vector3)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ stack_30+8]");
		_ = 0;
		Material topMaterial = stageData.GetTopMaterial();
		renderer.SetMaterial(topMaterial);
	}

	public int GetY()
	{
		return posY;
	}

	public ProceduralTile()
	{
		Vector2Int[] array = new Vector2Int[4];
		_ = 1;
		_ = 4294967295L;
		_ = 0;
		_ = 0;
		globalDirections = array;
		base._002Ector();
	}
}
