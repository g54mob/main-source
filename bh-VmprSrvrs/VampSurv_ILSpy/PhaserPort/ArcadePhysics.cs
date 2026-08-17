using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

public class ArcadePhysics : GameMonoBehaviour
{
	private ArcadeWorldConfig _config;

	private static ArcadePhysics s_instance;

	private static ArcadeWorldConfig s_currentConfig;

	private static PhaserScene s_scene;

	public static World s_world;

	public Factory add;

	private List<BaseBody> _overlapCache;

	private List<BaseBody> _overlapCache2;

	private RBush.RectangularBox searchRect;

	private List<BaseBody> _overlapCircBodyCache;

	private List<BaseBody> _overlapLineBodyCache;

	public static ArcadePhysics Instance => s_instance;

	public static ArcadeWorldConfig Config => s_currentConfig;

	public static PhaserScene scene => s_scene;

	public World world => s_world;

	private void Awake()
	{
		s_instance = this;
		PhaserScene phaserScene = new PhaserScene();
		s_scene = phaserScene;
		s_currentConfig = _config;
		World world = new World(s_scene, _config);
		s_world = world;
		PhaserScene phaserScene2 = s_scene;
		World world2 = s_world;
		Factory factory = null;
		factory._world = s_world;
		factory._scene = world2._scene;
		phaserScene2.add = factory;
		PhaserScene phaserScene3 = s_scene;
		add = phaserScene3.add;
		PhaserScene phaserScene4 = s_scene;
		phaserScene4.physics = this;
	}

	private void Update()
	{
		s_scene.UpdateRendererCache();
	}

	public void Cleanup()
	{
		if (s_world != null)
		{
			s_world.destroy();
		}
		s_world = null;
		s_scene = null;
	}

	public unsafe List<BaseBody> OverlapRect(float x, float y, float width, float height, bool includeDynamic = true, bool includeStatic = false, Group specificGroup = null)
	{
		//IL_0355: Expected O, but got F4
		//IL_0367: Expected O, but got F4
		//IL_0396: Expected O, but got Ref
		World world = s_world;
		List<BaseBody> overlapCache = _overlapCache;
		int version = overlapCache._version + 1;
		overlapCache._version = version;
		overlapCache._size = 0;
		if (overlapCache._size > 0)
		{
			Array.Clear(overlapCache._items, 0, overlapCache._size);
		}
		List<object> overlapCache2 = (List<object>)(object)_overlapCache2;
		int version2 = overlapCache2._version + 1;
		overlapCache2._version = version2;
		overlapCache2._size = 0;
		if (overlapCache2._size > 0)
		{
			Array.Clear(overlapCache2._items, 0, overlapCache2._size);
		}
		RBush.IRectangular rectangular = searchRect;
		rectangular.MinX = x;
		rectangular.MinY = y;
		float maxX = x + width;
		rectangular.MaxX = maxX;
		object obj = default(object);
		float maxY = y + (float)obj;
		rectangular.MaxY = maxY;
		object obj2 = default(object);
		if (obj2 != null)
		{
			List<BaseBody> collection = world._staticTree.search(rectangular);
			overlapCache2.InsertRange(overlapCache2._size, collection);
		}
		object obj3 = default(object);
		bool flag = obj3 == null;
		List<BaseBody> list = overlapCache;
		if (!flag)
		{
			Group obj4 = default(Group);
			if (world._useTree && obj4 != null)
			{
				RBush tree = world.GetTree(obj4);
				List<BaseBody> list2 = tree.search(searchRect);
				bool flag2 = (nint)list2 < 0;
				int num = list2._size - 1;
				list = list2;
				if (!flag2)
				{
					bool flag3;
					do
					{
						if (num < list2._size)
						{
							BaseBody[] items = list2._items;
							BaseBody baseBody = items[num];
							flag3 = ((HashSet<object>)(object)obj4.children).Contains((object)baseBody._gameObject);
							if (!flag3)
							{
								list2.RemoveAt(num);
							}
							num--;
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw null;
					}
					while ((flag3 ? 1 : 0) >= (false ? 1 : 0));
					list = list2;
				}
			}
			else
			{
				Body body = new Body();
				body._position = (float2)x;
				body._size = (float2)width;
				body._isCircle = false;
				HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
				object obj5 = default(object);
				while (enumerator.MoveNext())
				{
					((List<BaseBody>)(&enumerator)).InsertRange(0, (IEnumerable<BaseBody>)body);
					if (obj5 != null)
					{
						overlapCache.Add(null);
					}
				}
				list = overlapCache;
			}
		}
		if (obj2 != null)
		{
			((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)overlapCache2);
		}
		return list;
	}

	public unsafe List<BaseBody> OverlapCirc(float x, float y, float radius, bool includeDynamic = true, bool includeStatic = false, Group specificGroup = null)
	{
		//IL_00da: Expected O, but got I4
		//IL_00a0: Expected O, but got I
		//IL_00c2: Expected O, but got I
		//IL_00cc: Expected O, but got I4
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_016e: Expected O, but got Ref
		//IL_016e: Expected O, but got Ref
		//IL_018a: Expected F4, but got O
		//IL_0194: Expected O, but got I4
		//IL_01c8: Expected F4, but got O
		//IL_01d1: Expected O, but got I4
		float width = radius + radius;
		float num = y - radius;
		float num2 = x - radius;
		float height = default(float);
		bool includeDynamic2 = default(bool);
		bool includeStatic2 = default(bool);
		Group specificGroup2 = default(Group);
		List<BaseBody> list = OverlapRect(num2, num, width, height, includeDynamic2, includeStatic2, specificGroup2);
		if (list._size != 0)
		{
			Array overlapCircBodyCache = (Array)(object)_overlapCircBodyCache;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v11 (System.Array)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v11 (System.Array)+18]");
			object obj = default(object);
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v11 (System.Array)+10]");
				overlapCircBodyCache = (Array)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v11 (System.Array)+10]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v11 (System.Array)+18]");
				Array.Clear((Array)num3, 0, 0);
				obj = 0;
			}
			object obj2 = 0;
			float num4 = radius;
			float num5 = x;
			object obj3;
			float num7;
			float num6 = default(float);
			List<BaseBody> result = default(List<BaseBody>);
			for (; (nint)obj2 < list._size; obj2++, obj = obj3, num4 = num7)
			{
				if ((nint)obj2 < list._size)
				{
					BaseBody[] items = list._items;
					BaseBody baseBody = items[obj2];
					float num8;
					float num9;
					if (!baseBody._isCircle)
					{
						bool flag = CircleToRectangle((ArcadeCircle)(&num5), (ArcadeRect)(&num6));
						bool flag2 = !flag;
						num6 = (float)baseBody._position;
						obj3 = 0;
						num7 = radius;
						if (flag2)
						{
							continue;
						}
						num8 = num2;
						num9 = num;
						num6 = (float)baseBody._position;
						obj = 0;
						num4 = radius;
						num5 = x;
					}
					else
					{
						float num10 = (float)baseBody._center - x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v8 (BaseBody)+6C]");
						float num11 = 0f - y;
						float num12 = (float)baseBody._halfSize + radius;
						float num13 = num10 * num10;
						float num14 = num11 * num11;
						num8 = num12 * num12;
						num9 = num14 + num13;
						bool flag3 = num8 < num9;
						num2 = num8;
						num = num9;
						obj3 = obj;
						num7 = num4;
						if (flag3)
						{
							continue;
						}
					}
					_overlapCircBodyCache.Add(baseBody);
					num2 = num8;
					num = num9;
					obj3 = obj;
					num7 = num4;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			list = _overlapCircBodyCache;
		}
		return list;
	}

	private bool CircleToCircle(ArcadeCircle a, ArcadeCircle b)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0083: Invalid comparison between F4 and O
		object obj = b.pos - a.pos;
		float num = a.radius + b.radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ r8 (ArcadeCircle)+4]");
		object obj3 = default(object);
		object obj2 = 0 - obj3;
		object obj4 = obj * obj;
		float num2 = num * num;
		object obj5 = obj2 * obj2;
		object obj6 = obj5 + obj4;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
		return !flag;
	}

	private bool CircleToRectangle(ArcadeCircle circle, ArcadeRect rect)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_009a: Invalid comparison between O and F4
		//IL_00ca: Invalid comparison between O and F4
		//IL_00e6: Invalid comparison between F4 and O
		//IL_0105: Invalid comparison between F4 and O
		float num = rect.width * 0.5f;
		float num2 = rect.height * 0.5f;
		object obj = circle.pos - rect.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [circle @ rdx (ArcadeCircle)+4]");
		object obj2 = 0 - rect.y;
		float num3 = num + circle.radius;
		float num4 = (float)obj - num;
		float num5 = (float)obj2 - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num4 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num5 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
		{
			float num6 = num2 + circle.radius;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
				{
					float num7 = (float)obj3 - num;
					float num8 = (float)obj4 - num2;
					float num9 = circle.radius * circle.radius;
					float num10 = num7 * num7;
					float num11 = num8 * num8;
					float num12 = num10 + num11;
					bool flag = num9 < num12;
					return !flag;
				}
				return true;
			}
		}
		return false;
	}

	public unsafe List<BaseBody> OverlapLine(float2 lineStart, float2 lineEnd, float lineWidth, bool includeDynamic = true, bool includeStatic = false, Group specificGroup = null)
	{
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		//IL_0241: Expected O, but got Ref
		float num = lineWidth * 0.5f;
		object obj = lineEnd & -2147483649L;
		float2 float5 = (((nint)obj > 2139095040 || lineEnd > lineStart != 0) ? lineStart : lineEnd);
		float num2 = default(float);
		object obj2 = num2 & -2147483649L;
		float num4 = default(float);
		float num3 = (((nint)obj2 > 2139095040 || num2 > num4) ? num4 : num2);
		float num5 = (float)float5 - num;
		float y = num3 - num;
		object obj3 = lineEnd & -2147483649L;
		float2 float6;
		if ((nint)obj3 <= 2139095040)
		{
			bool flag = (byte)(lineStart <= lineEnd) != 0;
			float6 = lineEnd;
			if (flag)
			{
				goto IL_037c;
			}
		}
		float6 = lineStart;
		goto IL_037c;
		IL_037c:
		object obj4 = num2 & -2147483649L;
		if ((nint)obj4 > 2139095040 || num4 > num2)
		{
		}
		float num6 = (float)float6 + num;
		float width = num6 - num5;
		float num7 = default(float);
		bool includeDynamic2 = default(bool);
		bool includeStatic2 = default(bool);
		Group specificGroup2 = default(Group);
		List<BaseBody> list = OverlapRect(num5, y, width, num7, includeDynamic2, includeStatic2, specificGroup2);
		if (list._size != 0)
		{
			List<BaseBody> overlapLineBodyCache = _overlapLineBodyCache;
			int version = overlapLineBodyCache._version + 1;
			overlapLineBodyCache._version = version;
			overlapLineBodyCache._size = 0;
			if (overlapLineBodyCache._size > 0)
			{
				Array.Clear(overlapLineBodyCache._items, 0, overlapLineBodyCache._size);
			}
			int num8 = 0;
			float2 float7 = lineStart;
			int num9 = 0;
			float2 circlePos = default(float2);
			List<BaseBody> result = default(List<BaseBody>);
			while (num9 < list._size)
			{
				if (num8 < list._size)
				{
					BaseBody[] items = list._items;
					BaseBody baseBody = items[num8];
					bool flag2;
					if (!baseBody._isCircle)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rbx_v8 (BaseBody)+5C]");
						width = 0f + lineWidth;
						flag2 = LineToRectangle(lineStart, lineEnd, (ArcadeRect)(&float7));
					}
					else
					{
						flag2 = LineToCircle(lineStart, lineEnd, circlePos, num7);
					}
					if (flag2)
					{
						_overlapLineBodyCache.Add(baseBody);
					}
					num8++;
					num9 = num8;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			list = _overlapLineBodyCache;
		}
		return list;
	}

	private bool LineToCircle(float2 lineStart, float2 lineEnd, float2 circlePos, float circleRadius)
	{
		//IL_0013: Expected I, but got O
		nint num = (nint)typeof(float2);
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004360");
		object obj4 = obj2 + obj3;
		object obj6 = default(object);
		object obj5 = obj6 + (object)lineStart;
		object obj8 = default(object);
		object obj7 = obj8 - obj4;
		object obj10 = default(object);
		object obj9 = obj10 * obj10;
		object obj11 = (object)circlePos - obj5;
		object obj12 = obj7 * obj7;
		object obj13 = obj11 * obj11;
		object obj14 = obj12 + obj13;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14);
		return !flag;
	}

	private bool LineToRectangle(float2 lineStart, float2 lineEnd, ArcadeRect rect)
	{
		//IL_000d: Invalid comparison between F4 and O
		//IL_001f: Expected O, but got I4
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e7: Invalid comparison between O and F4
		//IL_0036: Expected O, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_02d8: Invalid comparison between F4 and O
		//IL_02ea: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_025c: Invalid comparison between O and F4
		//IL_0071: Expected O, but got I4
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I4
		float x = rect.x;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref lineStart);
		object obj = 0;
		if (!flag)
		{
			obj = 8;
		}
		float2 float5 = default(float2);
		float num = (float)float5 + rect.x;
		object obj2 = obj | 4;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref lineStart) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
		{
			obj2 = obj;
		}
		object obj3 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			obj2 |= 2;
		}
		object obj4 = obj2 | 1;
		object obj5 = float5 + float5;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			obj4 = obj2;
		}
		float x2 = rect.x;
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref lineEnd);
		object obj6 = 0;
		if (!flag2)
		{
			obj6 = 8;
		}
		object obj7 = obj6 | 4;
		float num2 = (float)float5 + rect.x;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref lineEnd) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
		{
			obj7 = obj6;
		}
		object obj8 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			obj7 |= 2;
		}
		object obj9 = obj7 | 1;
		object obj10 = float5 + float5;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
		{
			obj9 = obj7;
		}
		if (obj4 != null && obj9 != null)
		{
			object obj11 = obj4 & obj9;
			bool flag3 = obj11 == null;
			object obj12 = !flag3;
			ref float2 intersection = default(ref float2);
			if (obj12 != null || (!MathUtils.LineToLineIntersection(lineStart, lineEnd, float5, float5, out intersection) && !MathUtils.LineToLineIntersection(lineStart, lineEnd, float5, float5, out intersection) && !MathUtils.LineToLineIntersection(lineStart, lineEnd, float5, float5, out intersection) && !MathUtils.LineToLineIntersection(lineStart, lineEnd, float5, float5, out intersection)))
			{
				return false;
			}
		}
		return true;
	}

	private int CohenSutherlandCode(ArcadeRect rect, float2 position)
	{
		//IL_000d: Invalid comparison between F4 and O
		//IL_0095: Invalid comparison between O and F4
		//IL_00f1: Invalid comparison between F4 and O
		//IL_00cd: Invalid comparison between O and F4
		float x = rect.x;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position);
		int num = 0;
		if (!flag)
		{
			num = 8;
		}
		float num2 = rect.width + rect.x;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
		{
			num |= 4;
		}
		float y = rect.y;
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			num |= 2;
		}
		float num3 = rect.height + rect.y;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
		{
			num |= 1;
		}
		return num;
	}

	public unsafe PhaserGameObject closest(ArcadeSprite source, ICollection<PhaserGameObject> targets)
	{
		//IL_0041: Expected O, but got Ref
		//IL_00aa: Expected I, but got O
		//IL_0139: Expected O, but got I4
		//IL_00e2: Expected O, but got I
		//IL_016d: Expected I, but got O
		//IL_01f1: Expected O, but got I
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0413: Expected I, but got O
		//IL_0456: Expected I, but got O
		//IL_025e: Expected I, but got O
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02db: Expected I, but got O
		//IL_0307: Expected I, but got O
		if ((object)source != null)
		{
			float2 position = source.position;
			if (targets != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				ArcadeSprite arcadeSprite = default(ArcadeSprite);
				object obj = (object)(&arcadeSprite);
				float num = 3.4028235E+38f;
				PhaserGameObject result = null;
				ArcadeSprite arcadeSprite2 = null;
				object obj2 = default(object);
				object obj9 = default(object);
				PhaserGameObject phaserGameObject3 = default(PhaserGameObject);
				object obj14 = default(object);
				while (true)
				{
					object obj8;
					object obj3;
					if ((object)arcadeSprite != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 != null)
						{
							bool flag = (object)arcadeSprite == null;
							arcadeSprite2 = null;
							if (!flag)
							{
								nint num2 = (nint)arcadeSprite;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppClass<ArcadeSprite>)+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_011e;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppClass<ArcadeSprite>)+B0]");
								obj3 = 0;
								PhaserGameObject phaserGameObject = null;
								while (true)
								{
									object obj4 = (object)phaserGameObject + (object)phaserGameObject;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r8_v9+v453 @ rax_v46*8]");
									if (0 == (nint)typeof(IEnumerator<PhaserGameObject>))
									{
										break;
									}
									phaserGameObject = (PhaserGameObject)(phaserGameObject + 1);
									PhaserGameObject phaserGameObject2 = phaserGameObject;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r10_v5 (Il2CppClass<ArcadeSprite>)+12E]");
									if ((nint)phaserGameObject2 < 0)
									{
										continue;
									}
									goto IL_011e;
								}
								object obj5 = (object)phaserGameObject + (object)phaserGameObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r8_v9+8+v512 @ rcx_v33*8]");
								object obj6 = (nint)0 << 4;
								object obj7 = obj6 + 312;
								obj8 = obj7 + num2;
								goto IL_0464;
							}
							throw new NullReferenceException();
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						break;
					}
					throw new NullReferenceException();
					IL_011e:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj8 = obj9;
					obj3 = 0;
					goto IL_0464;
					IL_0464:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v517 @ rdx_v10] (should have been resolved before IL gen)");
					if ((object)phaserGameObject3 != null)
					{
						BaseBody body = phaserGameObject3.body;
						bool flag2 = phaserGameObject3.body == null;
						nint num3 = (nint)typeof(IEnumerator<PhaserGameObject>);
						if (flag2)
						{
							continue;
						}
						arcadeSprite2 = (ArcadeSprite)(object)typeof(UnityEngine.Object);
						object obj10 = (object)source - (object)phaserGameObject3;
						bool flag3 = obj10 == null;
						num3 = (nint)typeof(IEnumerator<PhaserGameObject>);
						if (flag3)
						{
							continue;
						}
						bool flag4;
						if ((object)body._gameObject != null)
						{
							object obj11 = (object)source - (object)body._gameObject;
							flag4 = obj11 == null;
						}
						else
						{
							flag4 = ((UnityEngine.Object)source).m_CachedPtr == (IntPtr)0;
							arcadeSprite2 = (ArcadeSprite)(object)typeof(UnityEngine.Object);
						}
						num3 = (nint)typeof(IEnumerator<PhaserGameObject>);
						if (flag4)
						{
							continue;
						}
						bool flag5 = body._enable == flag4;
						num3 = (nint)typeof(IEnumerator<PhaserGameObject>);
						if (!flag5)
						{
							object obj12 = body._center - position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rsi_v6 (BaseBody)+6C]");
							object obj13 = 0 - obj14;
							object obj15 = obj12 * obj12;
							object obj16 = obj13 * obj13;
							float num4 = (float)obj15 + (float)obj16;
							bool flag6 = !(num > num4);
							num3 = (nint)typeof(IEnumerator<PhaserGameObject>);
							if (!flag6)
							{
								num = num4;
								result = phaserGameObject3;
								num3 = (nint)typeof(IEnumerator<PhaserGameObject>);
							}
						}
						continue;
					}
					throw new NullReferenceException();
				}
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe float2 velocityFromAngle(float angle, float speed, ref float2 vec2)
	{
		float num = angle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float2 float5 = default(float2);
		ref float2 reference = ref *(float2*)float5;
		return float5;
	}

	public unsafe float2 velocityFromRotation(float rotation, float speed, ref float2 vec2)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float2 float5 = default(float2);
		ref float2 reference = ref *(float2*)float5;
		return float5;
	}

	public ArcadePhysics()
	{
		List<BaseBody> overlapCache = new List<BaseBody>();
		_overlapCache = overlapCache;
		List<BaseBody> overlapCache2 = new List<BaseBody>();
		_overlapCache2 = overlapCache2;
		RBush.RectangularBox rectangularBox = new RBush.RectangularBox();
		searchRect = rectangularBox;
		List<BaseBody> overlapCircBodyCache = new List<BaseBody>();
		_overlapCircBodyCache = overlapCircBodyCache;
		List<BaseBody> overlapLineBodyCache = new List<BaseBody>();
		_overlapLineBodyCache = overlapLineBodyCache;
		base._onResumeSent = true;
	}
}
