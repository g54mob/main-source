using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

public class StaticBody : BaseBody
{
	public StaticBody(World world, PhaserGameObject gameObject)
	{
		//IL_003b: Expected O, but got I8
		Transform transform = gameObject.transform;
		SpriteRenderer componentInChildren = gameObject.GetComponentInChildren<SpriteRenderer>();
		ArcadeTransform arcadeTransform = null;
		arcadeTransform.cachedLocalPosition = (float2)3323739136L;
		_ = 1176255488;
		arcadeTransform.Reset(transform, componentInChildren, this);
		_transform = arcadeTransform;
	}

	public override void drawDebug()
	{
		//IL_0072: Expected F8, but got I
		//IL_0072: Expected F8, but got O
		//IL_0072: Expected F8, but got I
		//IL_0072: Expected F8, but got O
		double num = (double)_position + (double)_halfSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+54]");
		double num2 = 0.0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+64]");
		double num3 = num2 + 0.0;
		if (willDrawDebug())
		{
			if (!_isCircle)
			{
				float2 position = _position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+54]");
				nint num4 = 0;
				float2 size = _size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+5C]");
				Color colour = default(Color);
				VSDebug.DrawDebugRect((double)position, num4, (double)size, 0.0, colour);
			}
			else
			{
				float num5 = (float)_size * 0.5f;
				VSDebug.DrawDebugCircle(num, num3, num5);
			}
		}
	}

	public override bool willDrawDebug()
	{
		return true;
	}

	public override BaseBody setOffset(float x, float? y = null)
	{
		//IL_000e: Expected O, but got I4
		//IL_007c: Expected O, but got I
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00c7: Expected O, but got F4
		//IL_00e5: Expected O, but got F4
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_010b: Expected F4, but got O
		//IL_011d: Expected F4, but got I
		//IL_017c: Expected O, but got F4
		//IL_0199: Expected O, but got I
		float? num;
		float num2;
		if ((object)y == null)
		{
			num = (float?)(object)1;
			num2 = x;
		}
		else
		{
			num = y;
			float num3 = default(float);
			num2 = num3;
		}
		World world = _world;
		RBush rBush = world._staticTree.remove(this);
		float2 float5 = (_position -= _offset);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+54]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+4C]");
		object obj = num4 - 0;
		if ((object)num != null)
		{
			float num5 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = num5 ^ 0;
			World world2 = _world;
			_offset = (float2)x;
			float num6 = x + (float)float5;
			_position = (float2)num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+4C]");
			object obj3 = 0 + obj;
			MinX = (float)_position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+54]");
			MinY = 0f;
			float maxX = (float)_size + num6;
			MaxX = maxX;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+5C]");
			float num7 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+54]");
			float maxY = num7 + 0f;
			MaxY = maxY;
			float num8 = (float)_halfSize + num6;
			_center = (float2)num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+64]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StaticBody)+54]");
			object obj4 = num9 + 0;
			RBush staticTree = world2._staticTree;
			RBush.Node data = staticTree.data;
			int level = data.height - 1;
			staticTree._insert((RBush.IRectangular)this, level, false);
			return this;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		BaseBody result = default(BaseBody);
		return result;
	}
}
