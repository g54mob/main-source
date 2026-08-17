using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Rewired.Glyphs;

[Serializable]
public class GlyphSetCollection : ScriptableObject
{
	private sealed class _003CIterateSetsRecursively_003Ed__9 : IEnumerable<GlyphSet>, IEnumerable, IEnumerator<GlyphSet>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GlyphSet _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private List<GlyphSetCollection> processedCollections;

		public List<GlyphSetCollection> _003C_003E3__processedCollections;

		public GlyphSetCollection _003C_003E4__this;

		private int _003CsetCount_003E5__2;

		private int _003CcollectionCount_003E5__3;

		private int _003Ci_003E5__4;

		private IEnumerator<GlyphSet> _003C_003E7__wrap4;

		GlyphSet IEnumerator<GlyphSet>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CIterateSetsRecursively_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181532CB0");
			int num = default(int);
			_003C_003El__initialThreadId = num;
		}

		void IDisposable.Dispose()
		{
			if (_003C_003E1__state == -3 || _003C_003E1__state == 2)
			{
				_ = 4294967295L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v3+50]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
			}
		}

		private bool MoveNext()
		{
			//IL_0802: Expected O, but got I
			//IL_00a4: Expected I, but got I8
			//IL_007a: Expected I, but got I8
			//IL_0063: Expected I, but got I8
			//IL_0172: Expected I, but got O
			//IL_013b: Expected O, but got I
			//IL_02b0: Expected O, but got I
			//IL_08ad: Expected I, but got O
			//IL_01c2: Expected O, but got I
			//IL_08ca: Expected I, but got I8
			//IL_063d: Expected I, but got O
			//IL_022c: Expected O, but got I
			//IL_065b: Expected I4, but got O
			//IL_020a: Expected I, but got O
			//IL_033f: Expected O, but got I
			//IL_035b: Expected I, but got O
			//IL_0385: Expected I, but got O
			//IL_0777: Expected O, but got I4
			//IL_03c9: Expected O, but got I
			//IL_040d: Expected O, but got I
			//IL_0444: Expected I4, but got O
			//IL_047f: Expected O, but got I
			//IL_04c3: Expected O, but got I
			//IL_04e8: Expected I4, but got O
			//IL_0523: Expected O, but got I
			//IL_0552: Expected I, but got O
			//IL_0577: Expected O, but got I
			//IL_05ce: Expected I, but got I8
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+38]");
			object obj = 0;
			UnityEngine.Object obj2 = default(UnityEngine.Object);
			bool flag = obj2.m_CachedPtr == (IntPtr)0;
			nint num;
			if (!flag)
			{
				num = (nint)obj2.m_CachedPtr - 1;
				if (!flag)
				{
					if (num != 1)
					{
						return false;
					}
					obj2.m_CachedPtr = unchecked((nint)4294967293L);
					goto IL_0829;
				}
				obj2.m_CachedPtr = unchecked((nint)4294967295L);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
				_ = (nint)0 + (nint)1;
			}
			else
			{
				obj2.m_CachedPtr = unchecked((nint)4294967295L);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+28]");
				bool flag2 = (nint)0 == 0;
				UnityEngine.Object item = obj2;
				if (flag2)
				{
					bool flag3 = ((List<GlyphSetCollection>)(object)typeof(ArgumentNullException)).Contains((GlyphSetCollection)item);
					ArgumentNullException ex = new ArgumentNullException("processedCollections");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+38]");
				bool flag4 = (nint)0 == 0;
				item = obj2;
				if (flag4)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+18]");
				bool flag5 = (nint)0 == 0;
				item = obj2;
				if (flag5)
				{
					goto IL_0256;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v94+18]");
				_ = 0;
				_ = 0;
			}
			nint num6;
			nint num4 = default(nint);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+40]");
				bool flag6 = num2 >= 0;
				UnityEngine.Object item = obj2;
				if (flag6)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+38]");
				bool flag7 = (nint)0 == 0;
				num = (nint)obj2;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
						GlyphSet glyphSet = ((List<GlyphSet>)num3).get_Item(0);
						if (glyphSet == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
							_ = (nint)0 + (nint)1;
							num4 = unchecked((nint)null);
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+18]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
						GlyphSet glyphSet2 = ((List<GlyphSet>)num5).get_Item(0);
						obj2.m_CachedPtr = (IntPtr)1;
						return true;
					}
					num = (nint)obj2;
					throw new NullReferenceException();
				}
				num6 = num4;
				throw new NullReferenceException();
			}
			goto IL_0256;
			IL_0256:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+38]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
				if ((nint)0 == 0)
				{
					goto IL_06e6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v92+18]");
				_ = 0;
				_ = 0;
				goto IL_08ef;
			}
			throw new NullReferenceException();
			IL_06be:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
			_ = (nint)0 + (nint)1;
			goto IL_08ef;
			IL_0829:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+50]");
			num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+50]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+50]");
			num6 = 0;
			if (!flag8)
			{
				if (((List<GlyphSetCollection>)null).Contains((GlyphSetCollection)(object)typeof(IEnumerator)))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+50]");
					num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+50]");
					bool flag9 = (nint)0 == 0;
					num = (nint)typeof(IEnumerator);
					if (!flag9)
					{
						GlyphSetCollection glyphSetCollection = ((List<GlyphSetCollection>)null).get_Item((int)typeof(IEnumerator<GlyphSet>));
						obj2.m_CachedPtr = (IntPtr)2;
						return true;
					}
					throw new NullReferenceException();
				}
				obj2.m_CachedPtr = unchecked((nint)4294967295L);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+50]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+50]");
					num4 = 0;
					bool flag10 = ((List<GlyphSetCollection>)null).Contains((GlyphSetCollection)(object)typeof(IDisposable));
				}
				_ = 0;
				goto IL_06be;
			}
			int num7 = (int)num;
			throw new NullReferenceException();
			IL_06e6:
			return false;
			IL_08ef:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+44]");
			if (num8 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+38]");
				bool flag11 = (nint)0 == 0;
				UnityEngine.Object item = obj2;
				if (!flag11)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
					bool flag12 = (nint)0 == 0;
					item = obj2;
					if (!flag12)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
						GlyphSetCollection glyphSetCollection2 = ((List<GlyphSetCollection>)num9).get_Item(0);
						bool flag13 = glyphSetCollection2 != null;
						num4 = unchecked((nint)null);
						if (flag13)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
							bool flag14 = (nint)0 == 0;
							num6 = unchecked((nint)null);
							num7 = 0;
							if (flag14)
							{
								num4 = num6;
								item = (UnityEngine.Object)num7;
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
							num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
							GlyphSetCollection glyphSetCollection3 = ((List<GlyphSetCollection>)num10).get_Item(0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+28]");
							bool flag15 = (nint)0 == 0;
							num6 = 0;
							if (flag15)
							{
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+28]");
							if (!((List<object>)0).Contains(glyphSetCollection3))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
								bool flag16 = (nint)0 == 0;
								num6 = 0;
								num7 = (int)glyphSetCollection3;
								if (!flag16)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
									num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
									nint num11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
									GlyphSetCollection glyphSetCollection4 = ((List<GlyphSetCollection>)num11).get_Item(0);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+28]");
									bool flag17 = (nint)0 == 0;
									num6 = 0;
									if (!flag17)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+28]");
										((List<GlyphSetCollection>)0).Add(glyphSetCollection4);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
										bool flag18 = (nint)0 == 0;
										num6 = 0;
										num7 = (int)glyphSetCollection4;
										if (!flag18)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
											num7 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbx_v1+20]");
											nint num12 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+48]");
											GlyphSetCollection glyphSetCollection5 = ((List<GlyphSetCollection>)num12).get_Item(0);
											bool flag19 = (object)glyphSetCollection5 == null;
											num6 = 0;
											if (!flag19)
											{
												nint num13 = (nint)glyphSetCollection5;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rax_v14 (Il2CppClass<Rewired.Glyphs.GlyphSetCollection>)+190]");
												num6 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+28]");
												IEnumerable<GlyphSet> enumerable = glyphSetCollection5.IterateSetsRecursively((List<GlyphSetCollection>)0);
												bool flag20 = enumerable == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2 (UnityEngine.Object)+28]");
												num7 = 0;
												if (!flag20)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
													obj2.m_CachedPtr = unchecked((nint)4294967293L);
													IntPtr intPtr = default(IntPtr);
													num = intPtr;
													goto IL_0829;
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							LogCircularDependency();
							num4 = 0;
						}
						goto IL_06be;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			goto IL_06e6;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			//IL_0031: Expected I4, but got I8
			bool flag = _003C_003E7__wrap4 == null;
			_003C_003E1__state = -1;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
			}
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}

		IEnumerator<GlyphSet> IEnumerable<GlyphSet>.GetEnumerator()
		{
			_003CIterateSetsRecursively_003Ed__9 obj2;
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181532CB0");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					obj2 = this;
					goto IL_009a;
				}
			}
			_003CIterateSetsRecursively_003Ed__9 obj3 = new _003CIterateSetsRecursively_003Ed__9(0);
			obj3._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181532CB0");
			int num = default(int);
			obj3._003C_003El__initialThreadId = num;
			obj3._003C_003E4__this = _003C_003E4__this;
			obj2 = obj3;
			goto IL_009a;
			IL_009a:
			if (obj2 != null)
			{
				obj2.processedCollections = _003C_003E3__processedCollections;
				return obj2;
			}
			return (IEnumerator<GlyphSet>)new NullReferenceException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			_003CIterateSetsRecursively_003Ed__9 obj2;
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181532CB0");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					obj2 = this;
					goto IL_009a;
				}
			}
			_003CIterateSetsRecursively_003Ed__9 obj3 = new _003CIterateSetsRecursively_003Ed__9(0);
			obj3._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181532CB0");
			int num = default(int);
			obj3._003C_003El__initialThreadId = num;
			obj3._003C_003E4__this = _003C_003E4__this;
			obj2 = obj3;
			goto IL_009a;
			IL_009a:
			if (obj2 != null)
			{
				obj2.processedCollections = _003C_003E3__processedCollections;
				return obj2;
			}
			return (IEnumerator)new NullReferenceException();
		}
	}

	private List<GlyphSet> _sets;

	private List<GlyphSetCollection> _collections;

	public List<GlyphSet> sets
	{
		get
		{
			return _sets;
		}
		set
		{
			_sets = value;
		}
	}

	public List<GlyphSetCollection> collections
	{
		get
		{
			return _collections;
		}
		set
		{
			if (value != null && ((List<object>)(object)value).Contains((object)this))
			{
				LogCircularDependency();
				Debug.LogWarning("Rewired: Set collections aborted due to circular dependency.");
			}
			else
			{
				_collections = value;
			}
		}
	}

	public virtual IEnumerable<GlyphSet> IterateSetsRecursively()
	{
		List<GlyphSetCollection> list = new List<GlyphSetCollection>();
		int version = list._version + 1;
		list._version = version;
		GlyphSetCollection[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)this);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			if (list._size >= items.Length)
			{
				return (IEnumerable<GlyphSet>)(object)new IndexOutOfRangeException();
			}
			int num = default(int);
			items[num] = this;
		}
		return IterateSetsRecursively(list);
	}

	protected virtual IEnumerable<GlyphSet> IterateSetsRecursively(List<GlyphSetCollection> processedCollections)
	{
		//IL_0054: Expected I4, but got I8
		_003CIterateSetsRecursively_003Ed__9 obj = new _003CIterateSetsRecursively_003Ed__9(0);
		obj._003C_003E1__state = -2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181532CB0");
		int num = default(int);
		obj._003C_003El__initialThreadId = num;
		obj._003C_003E4__this = this;
		obj._003C_003E3__processedCollections = processedCollections;
		return obj;
	}

	private static void LogCircularDependency()
	{
		Debug.LogError("Rewired: Circular dependency detected. This collection is referenced in a child collection. This is not allowed.");
	}
}
