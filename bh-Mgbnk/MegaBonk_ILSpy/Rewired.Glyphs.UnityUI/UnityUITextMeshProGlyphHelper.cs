using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore;

namespace Rewired.Glyphs.UnityUI;

public class UnityUITextMeshProGlyphHelper : MonoBehaviour
{
	private delegate bool ParseTagAttributesHandler(string text, int startIndex, int count, out string replacement);

	private abstract class Tag
	{
		public enum TagType
		{
			ControllerElement,
			Action,
			Player
		}

		public abstract class Pool
		{
			public abstract bool Return(Tag obj);
		}

		public sealed class Pool<T> : Pool where T : Tag, new()
		{
			private readonly List<T> _list;

			public Pool()
			{
				nint num = 0;
				List<T> list = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18112DF20");
				_list = list;
			}

			public T Get()
			{
				//IL_005e: Expected O, but got I4
				List<T> list = _list;
				if (_list != null)
				{
					if (list._size == 0)
					{
						object obj = Activator.CreateInstance<object>();
						if (obj != null)
						{
						}
						return (T)obj;
					}
					object obj2 = list._size - 1;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18112EB40");
					if (_list != null)
					{
						int index = list._size - 1;
						((List<object>)(object)_list).RemoveAt(index);
						T result = default(T);
						return result;
					}
				}
				return (T)(object)new NullReferenceException();
			}

			public override bool Return(Tag obj)
			{
				//IL_005e: Expected I, but got O
				//IL_01ad: Expected I4, but got O
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj2 = default(object);
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v4 (System.Object)+18]");
					if (0 == (nint)this)
					{
						nint num2 = (nint)obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v91 @ r8_v2 (Il2CppClass<System.Object>)+178] (should have been resolved before IL gen)");
						if (_list != null)
						{
							if (((List<object>)(object)_list).Contains(obj2))
							{
								goto IL_0199;
							}
							List<object> list = (List<object>)(object)_list;
							if (_list != null)
							{
								object[] items = list._items;
								int version = list._version + 1;
								list._version = version;
								if (list._items != null)
								{
									if (list._size >= items.Length)
									{
										((List<object>)(object)_list).AddWithResize(obj2);
										return true;
									}
									int size = list._size + 1;
									list._size = size;
									int num3 = default(int);
									items[num3] = obj2;
									return true;
								}
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
				}
				goto IL_0199;
				IL_0199:
				return false;
			}
		}

		public readonly TagType tagType;

		private Pool _pool;

		protected Pool pool
		{
			get
			{
				return _pool;
			}
			set
			{
				_pool = value;
			}
		}

		protected Tag(TagType tagType)
		{
			this.tagType = tagType;
		}

		public void ReturnToPool()
		{
			if (_pool != null)
			{
				bool flag = _pool.Return(this);
			}
		}

		protected abstract void Clear();

		public static void Clear(List<Tag> list)
		{
			bool flag = list._size <= 0;
			int num = 0;
			if (!flag)
			{
				do
				{
					Tag tag = list.get_Item(num);
					if (tag != null)
					{
						Tag tag2 = list.get_Item(num);
						if (tag2._pool != null)
						{
							Pool pool = tag2._pool;
							bool flag2 = pool.Return(tag2);
						}
					}
					num++;
				}
				while (num < list._size);
			}
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
		}
	}

	private sealed class ControllerElementTag : Tag
	{
		public DisplayType type;

		public int playerId;

		public int actionId;

		public AxisRange actionRange;

		private readonly List<GlyphOrText> _glyphsOrText;

		public List<GlyphOrText> glyphsOrText => _glyphsOrText;

		public override string ToString()
		{
			//IL_00a2: Expected I4, but got O
			//IL_0130: Expected I4, but got O
			StringBuilder stringBuilder = new StringBuilder();
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ControllerElementTag));
			if ((object)typeFromHandle != null)
			{
				string name = typeFromHandle.Name;
				if (stringBuilder != null)
				{
					StringBuilder stringBuilder2 = stringBuilder.Append(name);
					StringBuilder stringBuilder3 = stringBuilder.Append(": ");
					StringBuilder stringBuilder4 = stringBuilder.Append("type = ");
					object obj = default(object);
					object value = (DisplayType)obj;
					StringBuilder stringBuilder5 = stringBuilder.Append(value);
					StringBuilder stringBuilder6 = stringBuilder.Append(", playerId = ");
					StringBuilder stringBuilder7 = stringBuilder.Append(playerId);
					StringBuilder stringBuilder8 = stringBuilder.Append(", actionId = ");
					StringBuilder stringBuilder9 = stringBuilder.Append(actionId);
					StringBuilder stringBuilder10 = stringBuilder.Append(", actionRange = ");
					object obj2 = default(object);
					object value2 = (AxisRange)obj2;
					StringBuilder stringBuilder11 = stringBuilder.Append(value2);
					return stringBuilder.ToString();
				}
			}
			return (string)(object)new NullReferenceException();
		}

		public ControllerElementTag()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			tagType = TagType.ControllerElement;
			List<GlyphOrText> list = new List<GlyphOrText>();
			_glyphsOrText = list;
			Clear();
		}

		protected override void Clear()
		{
			//IL_0068: Expected O, but got I
			List<GlyphOrText> list = _glyphsOrText;
			type = DisplayType.GlyphOrText;
			playerId = -1;
			actionRange = AxisRange.Full;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
				Array.Clear((Array)num, 0, 0);
			}
		}

		public unsafe static bool TryParseString(string text, int startIndex, int count, StringBuilder sb1, StringBuilder sb2, Dictionary<string, string> workDictionary, Pool<ControllerElementTag> pool, out ControllerElementTag result)
		{
			//IL_0cdb: Expected O, but got I4
			//IL_0881: Expected I, but got O
			//IL_0889: Expected O, but got I4
			//IL_0055: Expected O, but got I4
			//IL_0cd2: Expected I4, but got O
			//IL_0cb1: Expected O, but got I
			//IL_0455: Expected I, but got O
			//IL_08e0: Expected O, but got I
			//IL_0275: Expected I, but got O
			//IL_0292: Expected I, but got O
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Expected O, but got Unknown
			//IL_0257: Expected I, but got O
			//IL_02c1: Expected I, but got O
			//IL_02f4: Expected I, but got O
			//IL_0941: Expected O, but got I
			//IL_05e8: Expected I, but got O
			//IL_095b: Expected O, but got I4
			//IL_063b: Expected I, but got O
			//IL_09b1: Expected O, but got I
			//IL_0a12: Expected O, but got I
			//IL_0ac2: Expected O, but got I
			//IL_07f4: Expected I, but got O
			//IL_0811: Expected I, but got O
			//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e2: Expected O, but got Unknown
			//IL_07e7: Expected I, but got O
			//IL_0837: Expected I, but got O
			//IL_0859: Expected I, but got O
			string text2 = (string)0;
			if (!string.IsNullOrEmpty(text) && startIndex >= 0)
			{
				bool flag = text == null;
				int num = 0;
				StringBuilder stringBuilder = default(StringBuilder);
				nint num3;
				object obj2;
				if (!flag)
				{
					int num2 = default(int);
					object obj = startIndex + num2;
					if ((nint)obj >= text._stringLength)
					{
						goto IL_0cf6;
					}
					StringBuilder sbValue = default(StringBuilder);
					Dictionary<string, string> results = default(Dictionary<string, string>);
					ParseAttributes(text, startIndex, num2, stringBuilder, sbValue, results);
					Dictionary<string, string> dictionary = default(Dictionary<string, string>);
					bool flag2 = dictionary == null;
					num = startIndex;
					if (!flag2)
					{
						if (dictionary.Count == 0)
						{
							goto IL_0cf6;
						}
						Pool<ControllerElementTag> pool2 = default(Pool<ControllerElementTag>);
						bool flag3 = pool2 == null;
						num = 0;
						if (!flag3)
						{
							ControllerElementTag controllerElementTag = pool2.Get();
							text2 = (string)(object)controllerElementTag;
							if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"type", out object value))
							{
								bool flag4 = text2 == null;
								num2 = (int)(&value);
								num3 = 0;
								obj2 = "type";
								if (flag4)
								{
									throw new NullReferenceException();
								}
								_ = 2;
							}
							else
							{
								num2 = (int)(&value);
								num3 = 0;
								obj2 = "type";
								object obj3 = null;
								string[] s_displayTypeNames2;
								while (true)
								{
									string[] s_displayTypeNames = UnityUITextMeshProGlyphHelper.s_displayTypeNames;
									if (s_displayTypeNames != null)
									{
										if ((nint)obj3 < s_displayTypeNames.Length)
										{
											s_displayTypeNames2 = UnityUITextMeshProGlyphHelper.s_displayTypeNames;
											if (s_displayTypeNames2 != null)
											{
												if ((nint)obj3 < s_displayTypeNames2.Length)
												{
													if (string.Equals((string)value, s_displayTypeNames2[obj3], StringComparison.OrdinalIgnoreCase))
													{
														break;
													}
													obj3++;
													num2 = 5;
													num3 = unchecked((nint)null);
													obj2 = s_displayTypeNames2[obj3];
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										string text3 = "Invalid type: " + null;
										bool flag5 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)null, out *(string*)null);
										Exception ex = new Exception(text3);
										bool flag6 = ((Dictionary<string, string>)0).TryGetValue(text3, out *(string*)null);
										throw ex;
									}
									NullReferenceException ex2 = new NullReferenceException();
									return (byte)(int)ex2 != 0;
								}
								nint num4 = (nint)text2;
								DisplayType[] s_displayTypeValues = UnityUITextMeshProGlyphHelper.s_displayTypeValues;
								bool flag7 = s_displayTypeValues == null;
								num3 = unchecked((nint)null);
								if (flag7)
								{
									throw new NullReferenceException();
								}
								bool flag8 = (nint)obj3 >= s_displayTypeValues.Length;
								num2 = 5;
								num3 = unchecked((nint)null);
								obj2 = s_displayTypeNames2[obj3];
								if (flag8)
								{
									throw new IndexOutOfRangeException();
								}
								bool flag9 = text2 == null;
								nint num5 = unchecked((nint)null);
								if (flag9)
								{
									num3 = num5;
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v171 (DisplayType[])+20+v391 @ rbx_v62 (System.Object)*4]");
								_ = 0;
							}
							if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"playerid", out value))
							{
								bool flag10 = ((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"playername", out value);
								bool flag11 = !flag10;
								num2 = (int)(&value);
								num3 = 0;
								obj2 = "playername";
								if (flag11)
								{
									bool flag12 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)obj2, out *(string*)num2);
									Exception ex3 = new Exception("Player name/id missing.");
									bool flag13 = ((Dictionary<string, string>)0).TryGetValue("Player name/id missing.", out *(string*)null);
									throw ex3;
								}
								ReInput.PlayerHelper players = ReInput.players;
								bool flag14 = players == null;
								int num6 = (int)(&value);
								num3 = 0;
								object obj4 = "playername";
								if (flag14)
								{
									throw new NullReferenceException();
								}
								Player player = players.GetPlayer((string)value);
								bool flag15 = player == null;
								num3 = 0;
								if (flag15)
								{
									string text4 = "Invalid Player name: " + null;
									bool flag16 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)null, out *(string*)null);
									Exception ex4 = new Exception(text4);
									bool flag17 = ((Dictionary<string, string>)0).TryGetValue(text4, out *(string*)null);
									num6 = 0;
									obj4 = flag17;
									throw ex4;
								}
								int id = player.id;
								bool flag18 = text2 == null;
								num3 = 0;
								if (flag18)
								{
									throw new NullReferenceException();
								}
							}
							else
							{
								int num7 = int.Parse((string)value);
								bool flag19 = text2 == null;
								nint num5 = 0;
								if (flag19)
								{
									throw new NullReferenceException();
								}
								ReInput.PlayerHelper players2 = ReInput.players;
								nint num8 = (nint)text2;
								bool flag20 = text2 == null;
								num5 = 0;
								if (flag20)
								{
									throw new NullReferenceException();
								}
								bool flag21 = players2 == null;
								num5 = 0;
								if (flag21)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ rdx_v83 (Il2CppClass<System.String>)+24]");
								Player player2 = players2.GetPlayer(0);
								bool flag22 = player2 == null;
								string text5 = text2;
								num5 = 0;
								if (flag22)
								{
									throw new NullReferenceException();
								}
							}
							if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"actionid", out value))
							{
								bool flag23 = ((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"actionname", out value);
								bool flag24 = !flag23;
								int num6 = (int)(&value);
								num3 = 0;
								object obj4 = "actionname";
								if (flag24)
								{
									bool flag25 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)obj4, out *(string*)num6);
									Exception ex5 = new Exception("Action name/id missing.");
									bool flag26 = ((Dictionary<string, string>)0).TryGetValue("Action name/id missing.", out *(string*)null);
									throw ex5;
								}
								ReInput.MappingHelper mapping = ReInput.mapping;
								bool flag27 = mapping == null;
								num3 = 0;
								if (flag27)
								{
									throw new NullReferenceException();
								}
								InputAction action = mapping.GetAction((string)value);
								bool flag28 = action == null;
								num3 = 0;
								if (flag28)
								{
									string text6 = "Invalid Action name: " + null;
									bool flag29 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)null, out *(string*)null);
									Exception ex6 = new Exception(text6);
									bool flag30 = ((Dictionary<string, string>)0).TryGetValue(text6, out *(string*)null);
									throw ex6;
								}
								bool flag31 = text2 == null;
								num3 = 0;
								if (flag31)
								{
									throw new NullReferenceException();
								}
								_ = action._id;
							}
							else
							{
								nint num9 = (nint)text2;
								int num10 = int.Parse((string)value);
								bool flag32 = text2 == null;
								string text5 = text2;
								nint num5 = 0;
								if (flag32)
								{
									throw new NullReferenceException();
								}
								ReInput.MappingHelper mapping2 = ReInput.mapping;
								nint num11 = (nint)text2;
								bool flag33 = text2 == null;
								text5 = text2;
								num5 = 0;
								if (flag33)
								{
									throw new NullReferenceException();
								}
								bool flag34 = mapping2 == null;
								text5 = text2;
								num5 = 0;
								if (flag34)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1360 @ rdx_v78 (Il2CppClass<System.String>)+28]");
								InputAction action2 = mapping2.GetAction(0);
								bool flag35 = action2 == null;
								string text7 = text2;
								num5 = 0;
								if (flag35)
								{
									throw new NullReferenceException();
								}
							}
							if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"actionrange", out value))
							{
								bool flag36 = text2 == null;
								num3 = 0;
								if (flag36)
								{
									throw new NullReferenceException();
								}
								_ = 0;
							}
							else
							{
								num3 = 0;
								object obj5 = null;
								while (true)
								{
									string[] s_axisRangeNames = UnityUITextMeshProGlyphHelper.s_axisRangeNames;
									bool flag37 = s_axisRangeNames == null;
									string text7 = text2;
									nint num5 = num3;
									if (!flag37)
									{
										bool flag38 = (nint)obj5 >= s_axisRangeNames.Length;
										num5 = num3;
										if (!flag38)
										{
											string[] s_axisRangeNames2 = UnityUITextMeshProGlyphHelper.s_axisRangeNames;
											if (s_axisRangeNames2 != null)
											{
												if ((nint)obj5 < s_axisRangeNames2.Length)
												{
													if (string.Equals((string)value, s_axisRangeNames2[obj5], StringComparison.OrdinalIgnoreCase))
													{
														break;
													}
													obj5++;
													num3 = unchecked((nint)null);
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											num5 = num3;
											throw new NullReferenceException();
										}
										string text8 = "Invalid Action Range: " + null;
										bool flag39 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)null, out *(string*)null);
										Exception ex7 = new Exception(text8);
										bool flag40 = ((Dictionary<string, string>)0).TryGetValue(text8, out *(string*)null);
										text7 = text8;
										throw ex7;
									}
									throw new NullReferenceException();
								}
								nint num12 = (nint)text2;
								AxisRange[] s_axisRangeValues = UnityUITextMeshProGlyphHelper.s_axisRangeValues;
								bool flag41 = s_axisRangeValues == null;
								num3 = unchecked((nint)null);
								if (flag41)
								{
									throw new NullReferenceException();
								}
								bool flag42 = (nint)obj5 >= s_axisRangeValues.Length;
								num3 = unchecked((nint)null);
								if (flag42)
								{
									throw new IndexOutOfRangeException();
								}
								bool flag43 = text2 == null;
								num3 = unchecked((nint)null);
								if (flag43)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1588 @ rax_v142 (Rewired.AxisRange[])+20+v1557 @ rbx_v56 (System.Object)*4]");
								_ = 0;
							}
							return true;
						}
					}
				}
				num3 = (nint)stringBuilder;
				obj2 = num;
				throw new NullReferenceException();
			}
			goto IL_0cf6;
			IL_0cf6:
			return false;
		}
	}

	private sealed class ActionTag : Tag
	{
		public int actionId;

		public AxisRange actionRange;

		private string _displayName;

		public string displayName
		{
			get
			{
				return _displayName;
			}
			set
			{
				_displayName = value;
			}
		}

		public override string ToString()
		{
			//IL_00cc: Expected I4, but got O
			StringBuilder stringBuilder = new StringBuilder();
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ControllerElementTag));
			if ((object)typeFromHandle != null)
			{
				string name = typeFromHandle.Name;
				if (stringBuilder != null)
				{
					StringBuilder stringBuilder2 = stringBuilder.Append(name);
					StringBuilder stringBuilder3 = stringBuilder.Append(": ");
					StringBuilder stringBuilder4 = stringBuilder.Append("actionId = ");
					StringBuilder stringBuilder5 = stringBuilder.Append(actionId);
					StringBuilder stringBuilder6 = stringBuilder.Append(", actionRange = ");
					object obj = default(object);
					object value = (AxisRange)obj;
					StringBuilder stringBuilder7 = stringBuilder.Append(value);
					return stringBuilder.ToString();
				}
			}
			return (string)(object)new NullReferenceException();
		}

		public ActionTag()
		{
			tagType = TagType.Action;
			Clear();
		}

		protected override void Clear()
		{
			//IL_000f: Expected I4, but got I8
			actionId = -1;
			actionRange = AxisRange.Full;
			_displayName = null;
		}

		public unsafe static bool TryParseString(string text, int startIndex, int count, StringBuilder sb1, StringBuilder sb2, Dictionary<string, string> workDictionary, Pool<ActionTag> pool, out ActionTag result)
		{
			//IL_0695: Expected O, but got I4
			//IL_048e: Expected O, but got I4
			//IL_0055: Expected O, but got I4
			//IL_068c: Expected I4, but got O
			//IL_04b4: Expected O, but got I
			//IL_051a: Expected O, but got I
			//IL_05c3: Expected O, but got I
			//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fe: Expected O, but got Unknown
			object obj = 0;
			if (!string.IsNullOrEmpty(text) && startIndex >= 0)
			{
				bool flag = text == null;
				int num = 0;
				object key;
				if (!flag)
				{
					int num2 = default(int);
					object obj2 = startIndex + num2;
					if ((nint)obj2 >= text._stringLength)
					{
						goto IL_06b0;
					}
					StringBuilder sbKey = default(StringBuilder);
					StringBuilder sbValue = default(StringBuilder);
					Dictionary<string, string> results = default(Dictionary<string, string>);
					ParseAttributes(text, startIndex, num2, sbKey, sbValue, results);
					Dictionary<string, string> dictionary = default(Dictionary<string, string>);
					bool flag2 = dictionary == null;
					num = startIndex;
					if (!flag2)
					{
						if (dictionary.Count == 0)
						{
							goto IL_06b0;
						}
						Pool<ActionTag> pool2 = default(Pool<ActionTag>);
						bool flag3 = pool2 == null;
						num = 0;
						if (!flag3)
						{
							ActionTag actionTag = pool2.Get();
							obj = actionTag;
							if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"id", out object value) && !((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"actionid", out value))
							{
								if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"name", out value))
								{
									bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"actionname", out value);
									bool flag5 = !flag4;
									key = "actionname";
									if (flag5)
									{
										bool flag6 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)key, out *(string*)(&value));
										Exception ex = new Exception("Action name/id missing.");
										ex._002Ector("Action name/id missing.");
										bool flag7 = ((Dictionary<string, string>)0).TryGetValue("Action name/id missing.", out *(string*)null);
										throw ex;
									}
								}
								ReInput.MappingHelper mapping = ReInput.mapping;
								if (mapping == null)
								{
									throw new NullReferenceException();
								}
								InputAction action = mapping.GetAction((string)value);
								if (action == null)
								{
									string text2 = "Invalid Action name: " + null;
									bool flag8 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)null, out *(string*)null);
									Exception ex2 = new Exception(text2);
									bool flag9 = ((Dictionary<string, string>)0).TryGetValue(text2, out *(string*)null);
									throw ex2;
								}
								object obj3 = obj;
								if (obj == null)
								{
									throw new NullReferenceException();
								}
								_ = action._id;
							}
							else
							{
								int num3 = int.Parse((string)value);
								if (obj == null)
								{
									NullReferenceException ex3 = new NullReferenceException();
									return (byte)(int)ex3 != 0;
								}
								ReInput.MappingHelper mapping2 = ReInput.mapping;
								object obj4 = obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rdx_v49+20]");
								InputAction action2 = mapping2.GetAction(0);
								if (action2 == null)
								{
									throw new NullReferenceException();
								}
							}
							if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"range", out value) && !((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"actionrange", out value))
							{
								if (obj == null)
								{
									throw new NullReferenceException();
								}
								_ = 0;
							}
							else
							{
								object obj5 = null;
								while (true)
								{
									string[] s_axisRangeNames = UnityUITextMeshProGlyphHelper.s_axisRangeNames;
									if (s_axisRangeNames != null)
									{
										if ((nint)obj5 < s_axisRangeNames.Length)
										{
											string[] s_axisRangeNames2 = UnityUITextMeshProGlyphHelper.s_axisRangeNames;
											if (s_axisRangeNames2 != null)
											{
												if ((nint)obj5 < s_axisRangeNames2.Length)
												{
													if (string.Equals((string)value, s_axisRangeNames2[obj5], StringComparison.OrdinalIgnoreCase))
													{
														break;
													}
													obj5++;
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										string text3 = "Invalid Action Range: " + null;
										bool flag10 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)null, out *(string*)null);
										Exception ex4 = new Exception(text3);
										bool flag11 = ((Dictionary<string, string>)0).TryGetValue(text3, out *(string*)null);
										throw ex4;
									}
									throw new NullReferenceException();
								}
								object obj6 = obj;
								AxisRange[] s_axisRangeValues = UnityUITextMeshProGlyphHelper.s_axisRangeValues;
								if (s_axisRangeValues == null)
								{
									throw new NullReferenceException();
								}
								if ((nint)obj5 >= s_axisRangeValues.Length)
								{
									throw new IndexOutOfRangeException();
								}
								if (obj == null)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rax_v82 (Rewired.AxisRange[])+20+v774 @ rbx_v32 (System.Object)*4]");
								_ = 0;
							}
							return true;
						}
					}
				}
				key = num;
				throw new NullReferenceException();
			}
			goto IL_06b0;
			IL_06b0:
			return false;
		}
	}

	private sealed class PlayerTag : Tag
	{
		public int playerId;

		private string _displayName;

		public string displayName
		{
			get
			{
				return _displayName;
			}
			set
			{
				_displayName = value;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ControllerElementTag));
			if ((object)typeFromHandle != null)
			{
				string name = typeFromHandle.Name;
				if (stringBuilder != null)
				{
					StringBuilder stringBuilder2 = stringBuilder.Append(name);
					StringBuilder stringBuilder3 = stringBuilder.Append(": ");
					StringBuilder stringBuilder4 = stringBuilder.Append("playerId = ");
					StringBuilder stringBuilder5 = stringBuilder.Append(playerId);
					return stringBuilder.ToString();
				}
			}
			return (string)(object)new NullReferenceException();
		}

		public PlayerTag()
		{
			tagType = TagType.Player;
			Clear();
		}

		protected override void Clear()
		{
			//IL_000f: Expected I4, but got I8
			playerId = -1;
			_displayName = null;
		}

		public unsafe static bool TryParseString(string text, int startIndex, int count, StringBuilder sb1, StringBuilder sb2, Dictionary<string, string> workDictionary, Pool<PlayerTag> pool, out PlayerTag result)
		{
			//IL_0471: Expected O, but got I4
			//IL_030b: Expected O, but got I4
			//IL_0055: Expected O, but got I4
			//IL_0468: Expected I4, but got O
			//IL_02b0: Expected I, but got O
			//IL_0331: Expected O, but got I
			//IL_0236: Expected I, but got O
			//IL_0397: Expected O, but got I
			Exception ex = (Exception)0;
			if (!string.IsNullOrEmpty(text) && startIndex >= 0)
			{
				bool flag = text == null;
				int num = 0;
				object key;
				if (!flag)
				{
					int num2 = default(int);
					object obj = startIndex + num2;
					if ((nint)obj >= text._stringLength)
					{
						goto IL_048c;
					}
					StringBuilder sbKey = default(StringBuilder);
					StringBuilder sbValue = default(StringBuilder);
					Dictionary<string, string> results = default(Dictionary<string, string>);
					ParseAttributes(text, startIndex, num2, sbKey, sbValue, results);
					Dictionary<string, string> dictionary = default(Dictionary<string, string>);
					bool flag2 = dictionary == null;
					num = startIndex;
					if (!flag2)
					{
						if (dictionary.Count == 0)
						{
							goto IL_048c;
						}
						Pool<PlayerTag> pool2 = default(Pool<PlayerTag>);
						bool flag3 = pool2 == null;
						num = 0;
						if (!flag3)
						{
							PlayerTag playerTag = pool2.Get();
							ex = (Exception)(object)playerTag;
							if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"id", out object value) && !((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"playerid", out value))
							{
								if (!((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"name", out value))
								{
									bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryGetValue((object)"playername", out value);
									bool flag5 = !flag4;
									key = "playername";
									if (flag5)
									{
										bool flag6 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)key, out *(string*)(&value));
										Exception ex2 = new Exception("Player name/id missing.");
										ex2._002Ector("Player name/id missing.");
										bool flag7 = ((Dictionary<string, string>)0).TryGetValue("Player name/id missing.", out *(string*)null);
										throw ex2;
									}
								}
								ReInput.PlayerHelper players = ReInput.players;
								bool flag8 = players == null;
								Exception ex3 = ex;
								if (flag8)
								{
									throw new NullReferenceException();
								}
								Player player = players.GetPlayer((string)value);
								if (player == null)
								{
									string text2 = "Invalid Player name: " + null;
									bool flag9 = ((Dictionary<string, string>)(object)typeof(Exception)).TryGetValue((string)null, out *(string*)null);
									Exception ex4 = new Exception(text2);
									bool flag10 = ((Dictionary<string, string>)0).TryGetValue(text2, out *(string*)null);
									ex3 = ex4;
									throw ex4;
								}
								nint num3 = (nint)ex;
								int id = player.id;
								if (ex == null)
								{
									throw new NullReferenceException();
								}
							}
							else
							{
								int num4 = int.Parse((string)value);
								if (ex == null)
								{
									NullReferenceException ex5 = new NullReferenceException();
									return (byte)(int)ex5 != 0;
								}
								ReInput.PlayerHelper players2 = ReInput.players;
								nint num5 = (nint)ex;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rdx_v31 (Il2CppClass<System.Exception>)+20]");
								Player player2 = players2.GetPlayer(0);
								bool flag11 = player2 == null;
								Exception ex3 = ex;
								if (flag11)
								{
									throw new NullReferenceException();
								}
							}
							return true;
						}
					}
				}
				key = num;
				throw new NullReferenceException();
			}
			goto IL_048c;
			IL_048c:
			return false;
		}
	}

	private struct GlyphOrText : IEquatable<GlyphOrText>
	{
		public string glyphKey;

		public Sprite sprite;

		public string name;

		public override bool Equals(object obj)
		{
			//IL_0013: Expected I, but got O
			//IL_0057: Expected I, but got O
			//IL_00e2: Expected O, but got I
			//IL_011b: Expected O, but got I
			if (obj != null)
			{
				nint num = (nint)typeof(GlyphOrText);
				bool flag = (object)obj.GetType() != typeof(GlyphOrText);
				object obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				if (obj2 != null)
				{
					nint num2 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v3 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+40]");
					if (num3 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						bool result = default(bool);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					object a = default(object);
					if (string.Equals((string)a, glyphKey, StringComparison.Ordinal))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v9+8]");
						if ((UnityEngine.Object)0 == sprite)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v9+10]");
							return string.Equals((string)0, name, StringComparison.Ordinal);
						}
					}
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			//IL_00e1: Expected I4, but got O
			//IL_0098: Expected O, but got I4
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected I4, but got Unknown
			if (glyphKey != null)
			{
				int hashCode = glyphKey.GetHashCode();
				if ((object)sprite != null)
				{
					int hashCode2 = sprite.GetHashCode();
					if (name != null)
					{
						int hashCode3 = name.GetHashCode();
						object obj = hashCode + 493;
						object obj2 = obj * 29;
						object obj3 = obj2 + hashCode2;
						object obj4 = obj3 * 29;
						return hashCode3 + obj4;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		public bool Equals(GlyphOrText other)
		{
			if (string.Equals(other.glyphKey, glyphKey, StringComparison.Ordinal) && other.sprite == sprite)
			{
				return string.Equals(other.name, name, StringComparison.Ordinal);
			}
			return false;
		}

		public static bool operator ==(GlyphOrText a, GlyphOrText b)
		{
			if (string.Equals(a.glyphKey, b.glyphKey, StringComparison.Ordinal) && a.sprite == b.sprite)
			{
				return string.Equals(a.name, b.name, StringComparison.Ordinal);
			}
			return false;
		}

		public static bool operator !=(GlyphOrText a, GlyphOrText b)
		{
			if (string.Equals(a.glyphKey, b.glyphKey, StringComparison.Ordinal) && a.sprite == b.sprite)
			{
				bool flag = string.Equals(a.name, b.name, StringComparison.Ordinal);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
			return true;
		}
	}

	private class Asset
	{
		public readonly uint id;

		private ITMProSpriteAsset _spriteAsset;

		private Material _material;

		private static uint s_idCounter;

		private static Shader __tmProShader;

		public ITMProSpriteAsset spriteAsset => _spriteAsset;

		public Material material => _material;

		private static Shader tmProShader
		{
			get
			{
				if (__tmProShader == null)
				{
					ShaderUtilities.GetShaderPropertyIDs();
					Shader _tmProShader = Shader.Find("TextMeshPro/Sprite");
					__tmProShader = _tmProShader;
				}
				return __tmProShader;
			}
		}

		public unsafe Asset(Material baseMaterial)
		{
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected I4, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			uint num = s_idCounter + 1;
			s_idCounter = num;
			id = s_idCounter;
			bool flag = TMProSprite_AssetV1_1_0.CheckVersionSupported();
			if (!TMProAssetVersionHelper._isVersionSupportedChecked)
			{
				TMProAssetVersionHelper._isVersionSupportedChecked = true;
			}
			TMProSprite_AssetV1_0_0.TMPro_SpriteAsset tMPro_SpriteAsset2;
			if (flag)
			{
				TMProSprite_AssetV1_1_0.TMPro_SpriteAsset tMPro_SpriteAsset = new TMProSprite_AssetV1_1_0.TMPro_SpriteAsset();
				tMPro_SpriteAsset2 = (TMProSprite_AssetV1_0_0.TMPro_SpriteAsset)(object)tMPro_SpriteAsset;
			}
			else
			{
				TMProSprite_AssetV1_0_0.TMPro_SpriteAsset tMPro_SpriteAsset3 = new TMProSprite_AssetV1_0_0.TMPro_SpriteAsset();
				TMP_SpriteAsset tMP_SpriteAsset = ScriptableObject.CreateInstance<TMP_SpriteAsset>();
				tMPro_SpriteAsset3._spriteAsset = tMP_SpriteAsset;
				tMPro_SpriteAsset3._spriteAsset.hideFlags = HideFlags.DontSave;
				TMP_SpriteAsset tMP_SpriteAsset2 = tMPro_SpriteAsset3._spriteAsset;
				if (tMP_SpriteAsset2.spriteInfoList == null)
				{
					List<TMP_Sprite> spriteInfoList = new List<TMP_Sprite>();
					tMP_SpriteAsset2.spriteInfoList = spriteInfoList;
				}
				List<TMProSprite_AssetV1_0_0> sprites = new List<TMProSprite_AssetV1_0_0>();
				tMPro_SpriteAsset3._sprites = sprites;
				tMPro_SpriteAsset2 = tMPro_SpriteAsset3;
			}
			_spriteAsset = tMPro_SpriteAsset2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(UnityUITextMeshProGlyphHelper));
			string name = typeFromHandle.Name;
			uint num2 = (uint)(this + 16);
			string text = ((uint*)num2)->ToString();
			string name2 = name + " SpriteAsset " + text;
			UnityEngine.Object obj = default(UnityEngine.Object);
			obj.name = name2;
			string name3 = obj.name;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182155640");
			Material material = CreateMaterial(baseMaterial, id);
			_material = material;
			if (_spriteAsset != null)
			{
				_ = _material;
				string name4 = _material.name;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182155640");
			}
		}

		public static Material CreateMaterial(Material baseMaterial, uint id)
		{
			Material material2;
			if (baseMaterial != null)
			{
				Material material = new Material(baseMaterial);
				material2 = material;
			}
			else
			{
				if (__tmProShader == null)
				{
					ShaderUtilities.GetShaderPropertyIDs();
					Shader _tmProShader = Shader.Find("TextMeshPro/Sprite");
					__tmProShader = _tmProShader;
				}
				Material material3 = new Material(__tmProShader);
				material2 = material3;
			}
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(UnityUITextMeshProGlyphHelper));
			if ((object)typeFromHandle != null)
			{
				string name = typeFromHandle.Name;
				uint num = default(uint);
				string text = num.ToString();
				string name2 = name + " Material " + text;
				if ((object)material2 != null)
				{
					material2.name = name2;
					material2.hideFlags = HideFlags.HideInHierarchy;
					return material2;
				}
			}
			return (Material)(object)new NullReferenceException();
		}

		public void Destroy()
		{
			if (_spriteAsset != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				_spriteAsset = null;
			}
			if (_material != null)
			{
				UnityEngine.Object.Destroy(_material);
				_material = null;
			}
		}
	}

	[Serializable]
	public struct TMProSpriteOptions : IEquatable<TMProSpriteOptions>
	{
		private float _scale;

		private Vector2 _offsetSizeMultiplier;

		private Vector2 _extraOffset;

		private float _xAdvanceWidthMultiplier;

		private float _extraXAdvance;

		public float scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public Vector2 offsetSizeMultiplier
		{
			get
			{
				return _offsetSizeMultiplier;
			}
			set
			{
				_offsetSizeMultiplier = value;
			}
		}

		public Vector2 extraOffset
		{
			get
			{
				return _extraOffset;
			}
			set
			{
				_extraOffset = value;
			}
		}

		public float xAdvanceWidthMultiplier
		{
			get
			{
				return _xAdvanceWidthMultiplier;
			}
			set
			{
				_xAdvanceWidthMultiplier = value;
			}
		}

		public float extraXAdvance
		{
			get
			{
				return _extraXAdvance;
			}
			set
			{
				_extraXAdvance = value;
			}
		}

		public unsafe static TMProSpriteOptions Default
		{
			get
			{
				//IL_0009: Expected native int or pointer, but got O
				//IL_001c: Expected O, but got I4
				//IL_0017: Expected native int or pointer, but got O
				//IL_0025: Expected native int or pointer, but got O
				TMProSpriteOptions tMProSpriteOptions = default(TMProSpriteOptions);
				((TMProSpriteOptions*)(nint)tMProSpriteOptions)->_xAdvanceWidthMultiplier = 1f;
				((TMProSpriteOptions*)(nint)tMProSpriteOptions)->_extraOffset = (Vector2)0;
				((TMProSpriteOptions*)(nint)tMProSpriteOptions)->_scale = 1.5f;
				_ = 1061158912;
				return tMProSpriteOptions;
			}
		}

		public override bool Equals(object obj)
		{
			//IL_0013: Expected I, but got O
			//IL_0057: Expected I, but got O
			//IL_00a4: Invalid comparison between O and F4
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_010f: Invalid comparison between F4 and O
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Expected O, but got Unknown
			//IL_0182: Invalid comparison between F4 and O
			//IL_01ad: Invalid comparison between O and F4
			//IL_01d8: Invalid comparison between O and F4
			if (obj != null)
			{
				nint num = (nint)typeof(TMProSpriteOptions);
				bool flag = (object)obj.GetType() != typeof(TMProSpriteOptions);
				object obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				if (obj2 != null)
				{
					nint num2 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v3 (Il2CppClass<System.Object>)+40]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions>)+40]");
					if (num3 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						bool result = default(bool);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C89ECh\"");
					object obj3 = default(object);
					if (obj3 == (object)_scale)
					{
						object obj5 = default(object);
						object obj4 = obj5 - (object)_offsetSizeMultiplier;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+8]");
						object obj7 = default(object);
						object obj6 = obj7 - 0;
						object obj8 = obj6 * obj6;
						object obj9 = obj4 * obj4;
						object obj10 = obj8 + obj9;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v8+C]");
							object obj11 = 0 - _extraOffset;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+10]");
							object obj13 = default(object);
							object obj12 = obj13 - 0;
							object obj14 = obj12 * obj12;
							object obj15 = obj11 * obj11;
							object obj16 = obj14 + obj15;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C89ECh\"");
								if (obj13 == (object)_xAdvanceWidthMultiplier)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C89ECh\"");
									if (obj13 == (object)_extraXAdvance)
									{
										return true;
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		public unsafe override int GetHashCode()
		{
			//IL_0020: Expected Ref, but got F4
			//IL_003f: Expected Ref, but got F4
			//IL_0074: Expected Ref, but got F4
			//IL_0093: Expected Ref, but got F4
			//IL_00c8: Expected Ref, but got F4
			//IL_00e7: Expected Ref, but got F4
			//IL_00f9: Expected O, but got I4
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Expected O, but got Unknown
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Expected O, but got Unknown
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected I4, but got Unknown
			int hashCode = ((float)this).GetHashCode();
			float num = (float)(ref this) + 4f;
			int hashCode2 = ((float*)num)->GetHashCode();
			float num2 = (float)(ref this) + 8f;
			int hashCode3 = ((float*)num2)->GetHashCode();
			float num3 = (float)(ref this) + 12f;
			int num4 = hashCode3 << 2;
			int num5 = num4 ^ hashCode2;
			int hashCode4 = ((float*)num3)->GetHashCode();
			float num6 = (float)(ref this) + 16f;
			int hashCode5 = ((float*)num6)->GetHashCode();
			float num7 = (float)(ref this) + 20f;
			int num8 = hashCode5 << 2;
			int num9 = num8 ^ hashCode4;
			int hashCode6 = ((float*)num7)->GetHashCode();
			float num10 = (float)(ref this) + 24f;
			int hashCode7 = ((float*)num10)->GetHashCode();
			object obj = hashCode + 493;
			object obj2 = obj * 29;
			object obj3 = obj2 + num5;
			object obj4 = obj3 * 29;
			object obj5 = obj4 + num9;
			object obj6 = obj5 * 29;
			object obj7 = obj6 + hashCode6;
			object obj8 = obj7 * 29;
			return hashCode7 + obj8;
		}

		public bool Equals(TMProSpriteOptions other)
		{
			//IL_0061: Expected O, but got I
			//IL_0091: Invalid comparison between F4 and O
			//IL_00d9: Expected O, but got I
			//IL_0109: Invalid comparison between F4 and O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8A7Ah\"");
			if (other._scale == _scale)
			{
				object obj = other._offsetSizeMultiplier - _offsetSizeMultiplier;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [other @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+8]");
				object obj2 = num - 0;
				object obj3 = obj2 * obj2;
				object obj4 = obj * obj;
				object obj5 = obj3 + obj4;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
				{
					object obj6 = other._extraOffset - _extraOffset;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [other @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+10]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+10]");
					object obj7 = num2 - 0;
					object obj8 = obj7 * obj7;
					object obj9 = obj6 * obj6;
					object obj10 = obj8 + obj9;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8A7Ah\"");
						if (other._xAdvanceWidthMultiplier == _xAdvanceWidthMultiplier)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8A7Ah\"");
							if (other._extraXAdvance == _extraXAdvance)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public static bool operator ==(TMProSpriteOptions a, TMProSpriteOptions b)
		{
			//IL_0067: Expected O, but got I
			//IL_0097: Invalid comparison between F4 and O
			//IL_00e2: Expected O, but got I
			//IL_0112: Invalid comparison between F4 and O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8BEAh\"");
			if (a._scale == b._scale)
			{
				object obj = a._offsetSizeMultiplier - b._offsetSizeMultiplier;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+8]");
				object obj2 = num - 0;
				object obj3 = obj2 * obj2;
				object obj4 = obj * obj;
				object obj5 = obj3 + obj4;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
				{
					object obj6 = a._extraOffset - b._extraOffset;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+10]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSpriteOptions)+10]");
					object obj7 = num2 - 0;
					object obj8 = obj7 * obj7;
					object obj9 = obj6 * obj6;
					object obj10 = obj8 + obj9;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8BEAh\"");
						if (a._xAdvanceWidthMultiplier == b._xAdvanceWidthMultiplier)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8BEAh\"");
							if (a._extraXAdvance == b._extraXAdvance)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public static bool operator !=(TMProSpriteOptions a, TMProSpriteOptions b)
		{
			//IL_007d: Invalid comparison between F4 and O
			//IL_00e8: Invalid comparison between F4 and O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001803C8CA7h\"");
			if (a._scale == b._scale)
			{
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				object obj5 = default(object);
				object obj6 = default(object);
				object obj4 = obj5 - obj6;
				object obj7 = obj4 * obj4;
				object obj8 = obj * obj;
				object obj9 = obj7 + obj8;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
				{
					object obj10 = a._extraOffset - b._extraOffset;
					object obj12 = default(object);
					object obj11 = obj12 - obj12;
					object obj13 = obj11 * obj11;
					object obj14 = obj10 * obj10;
					object obj15 = obj13 + obj14;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8CA7h\"");
						if (obj12 == obj12)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C8CA7h\"");
							if (obj12 == obj12)
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}
	}

	[Serializable]
	public struct SpriteMaterialProperties
	{
		private Color _color;

		public unsafe Color color
		{
			get
			{
				//IL_000f: Expected F4, but got O
				//IL_000a: Expected native int or pointer, but got O
				Color color = default(Color);
				((Color*)(nint)color)->r = (float)_color;
				return color;
			}
			set
			{
				//IL_000f: Expected O, but got F4
				_color = (Color)value.r;
			}
		}

		public unsafe static SpriteMaterialProperties Default
		{
			get
			{
				//IL_000e: Expected O, but got I4
				//IL_0009: Expected native int or pointer, but got O
				SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
				((SpriteMaterialProperties*)(nint)spriteMaterialProperties)->_color = (Color)1065353216;
				_ = 1065353216;
				_ = 1065353216;
				_ = 1065353216;
				return spriteMaterialProperties;
			}
		}
	}

	private interface ITMProSprite
	{
		uint id { get; set; }

		float width { get; set; }

		float height { get; set; }

		float xOffset { get; set; }

		float yOffset { get; set; }

		float xAdvance { get; set; }

		Vector2 position { get; set; }

		Vector2 pivot { get; set; }

		float scale { get; set; }

		string name { get; set; }

		uint unicode { get; set; }

		int hashCode { get; set; }

		Sprite sprite { get; set; }
	}

	private interface ITMProSpriteAsset
	{
		int spriteCount { get; }

		Texture spriteSheet { get; set; }

		TMP_SpriteAsset GetSpriteAsset();

		ITMProSprite GetSprite(int index);

		void AddSprite(ITMProSprite sprite);

		bool Contains(string spriteName);

		void Clear();

		void UpdateLookupTables();

		void Destroy();
	}

	private static class TMProAssetVersionHelper
	{
		private static bool _isVersionSupportedChecked;

		private static bool CheckVersionSupported()
		{
			bool result = TMProSprite_AssetV1_1_0.CheckVersionSupported();
			if (!_isVersionSupportedChecked)
			{
				_isVersionSupportedChecked = true;
			}
			return result;
		}

		public static ITMProSprite CreateSprite()
		{
			bool flag = TMProSprite_AssetV1_1_0.CheckVersionSupported();
			if (!_isVersionSupportedChecked)
			{
				_isVersionSupportedChecked = true;
			}
			if (flag)
			{
				TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_ = new TMProSprite_AssetV1_1_0();
				TMProSprite_AssetV1_1_0.TMPro_SpriteGlyph spriteGlyph = new TMProSprite_AssetV1_1_0.TMPro_SpriteGlyph();
				tMProSprite_AssetV1_1_._spriteGlyph = spriteGlyph;
				TMProSprite_AssetV1_1_0.TMPro_SpriteCharacter spriteCharacter = new TMProSprite_AssetV1_1_0.TMPro_SpriteCharacter();
				tMProSprite_AssetV1_1_._spriteCharacter = spriteCharacter;
				TMProSprite_AssetV1_1_0.TMPro_SpriteGlyph spriteGlyph2 = tMProSprite_AssetV1_1_._spriteGlyph;
				if (tMProSprite_AssetV1_1_._spriteGlyph != null)
				{
					TMProSprite_AssetV1_1_0.TMPro_SpriteCharacter spriteCharacter2 = tMProSprite_AssetV1_1_._spriteCharacter;
					if (tMProSprite_AssetV1_1_._spriteCharacter != null && (object)spriteCharacter2._glyph != null)
					{
						spriteCharacter2._glyph.SetValue(spriteCharacter2._source, spriteGlyph2._source);
						return tMProSprite_AssetV1_1_;
					}
				}
				return (ITMProSprite)new NullReferenceException();
			}
			TMProSprite_AssetV1_0_0 tMProSprite_AssetV1_0_ = new TMProSprite_AssetV1_0_0();
			TMP_Sprite spriteInfo = new TMP_Sprite();
			tMProSprite_AssetV1_0_.spriteInfo = spriteInfo;
			return tMProSprite_AssetV1_0_;
		}

		public static ITMProSpriteAsset CreateSpriteAsset()
		{
			bool flag = TMProSprite_AssetV1_1_0.CheckVersionSupported();
			if (!_isVersionSupportedChecked)
			{
				_isVersionSupportedChecked = true;
			}
			if (flag)
			{
				return new TMProSprite_AssetV1_1_0.TMPro_SpriteAsset();
			}
			TMProSprite_AssetV1_0_0.TMPro_SpriteAsset tMPro_SpriteAsset = new TMProSprite_AssetV1_0_0.TMPro_SpriteAsset();
			TMP_SpriteAsset spriteAsset = ScriptableObject.CreateInstance<TMP_SpriteAsset>();
			tMPro_SpriteAsset._spriteAsset = spriteAsset;
			if ((object)tMPro_SpriteAsset._spriteAsset != null)
			{
				tMPro_SpriteAsset._spriteAsset.hideFlags = HideFlags.DontSave;
				TMP_SpriteAsset spriteAsset2 = tMPro_SpriteAsset._spriteAsset;
				if ((object)tMPro_SpriteAsset._spriteAsset != null)
				{
					if (spriteAsset2.spriteInfoList == null)
					{
						List<TMP_Sprite> spriteInfoList = new List<TMP_Sprite>();
						spriteAsset2.spriteInfoList = spriteInfoList;
					}
					List<TMProSprite_AssetV1_0_0> sprites = new List<TMProSprite_AssetV1_0_0>();
					tMPro_SpriteAsset._sprites = sprites;
					return tMPro_SpriteAsset;
				}
			}
			return (ITMProSpriteAsset)new NullReferenceException();
		}
	}

	private class TMProSprite_AssetV1_0_0 : ITMProSprite
	{
		public class TMPro_SpriteAsset : ITMProSpriteAsset
		{
			private TMP_SpriteAsset _spriteAsset;

			private readonly List<TMProSprite_AssetV1_0_0> _sprites;

			public int spriteCount
			{
				get
				{
					//IL_001d: Expected I4, but got O
					List<TMProSprite_AssetV1_0_0> sprites = _sprites;
					if (_sprites != null)
					{
						return sprites._size;
					}
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
			}

			public Texture spriteSheet
			{
				get
				{
					TMP_SpriteAsset spriteAsset = _spriteAsset;
					if ((object)_spriteAsset != null)
					{
						return spriteAsset.spriteSheet;
					}
					return (Texture)(object)new NullReferenceException();
				}
				set
				{
					TMP_SpriteAsset spriteAsset = _spriteAsset;
					spriteAsset.spriteSheet = value;
				}
			}

			public TMPro_SpriteAsset()
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				TMP_SpriteAsset spriteAsset = ScriptableObject.CreateInstance<TMP_SpriteAsset>();
				_spriteAsset = spriteAsset;
				_spriteAsset.hideFlags = HideFlags.DontSave;
				TMP_SpriteAsset spriteAsset2 = _spriteAsset;
				if (spriteAsset2.spriteInfoList == null)
				{
					List<TMP_Sprite> spriteInfoList = new List<TMP_Sprite>();
					spriteAsset2.spriteInfoList = spriteInfoList;
				}
				List<TMProSprite_AssetV1_0_0> sprites = new List<TMProSprite_AssetV1_0_0>();
				_sprites = sprites;
			}

			public TMP_SpriteAsset GetSpriteAsset()
			{
				return _spriteAsset;
			}

			public ITMProSprite GetSprite(int index)
			{
				List<TMProSprite_AssetV1_0_0> sprites = _sprites;
				if (_sprites != null)
				{
					if (index < sprites._size)
					{
						return _sprites.get_Item(index);
					}
					return null;
				}
				return (ITMProSprite)new NullReferenceException();
			}

			public void AddSprite(ITMProSprite sprite)
			{
				//IL_0013: Expected I, but got O
				//IL_001b: Expected I, but got O
				//IL_002b: Expected O, but got I
				//IL_0067: Expected O, but got I
				//IL_00c5: Expected O, but got I
				//IL_01af: Expected O, but got I
				//IL_016c: Expected O, but got I
				if (sprite != null)
				{
					nint num = (nint)typeof(TMProSprite_AssetV1_0_0);
					nint num2 = (nint)sprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v5 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSprite_AssetV1_0_0>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v5 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSprite_AssetV1_0_0>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v12+FFFFFFF8+v46 @ rax_v11*8]");
						if (0 == (nint)typeof(TMProSprite_AssetV1_0_0))
						{
							TMP_SpriteAsset spriteAsset = _spriteAsset;
							List<TMP_Sprite> spriteInfoList = spriteAsset.spriteInfoList;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sprite @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite)+10]");
							object obj3 = 0;
							_ = spriteInfoList._size;
							TMP_SpriteAsset spriteAsset2 = _spriteAsset;
							List<object> spriteInfoList2 = (List<object>)(object)spriteAsset2.spriteInfoList;
							int version = spriteInfoList2._version + 1;
							spriteInfoList2._version = version;
							object[] items = spriteInfoList2._items;
							int size = spriteInfoList2._size;
							if (spriteInfoList2._size >= items.Length)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sprite @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite)+10]");
								spriteInfoList2.AddWithResize((object)0);
							}
							else
							{
								int size2 = spriteInfoList2._size + 1;
								spriteInfoList2._size = size2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sprite @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite)+10]");
								items[size] = 0;
							}
							List<object> sprites = (List<object>)(object)_sprites;
							int version2 = sprites._version + 1;
							sprites._version = version2;
							object[] items2 = sprites._items;
							if (sprites._size >= items2.Length)
							{
								sprites.AddWithResize((object)sprite);
								return;
							}
							int size3 = sprites._size + 1;
							sprites._size = size3;
							int num4 = default(int);
							items2[num4] = sprite;
							return;
						}
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentException ex = new ArgumentException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}

			public void Clear()
			{
				TMP_SpriteAsset spriteAsset = _spriteAsset;
				List<TMP_Sprite> spriteInfoList = spriteAsset.spriteInfoList;
				int version = spriteInfoList._version + 1;
				spriteInfoList._version = version;
				spriteInfoList._size = 0;
				if (spriteInfoList._size > 0)
				{
					Array.Clear(spriteInfoList._items, 0, spriteInfoList._size);
				}
				List<TMProSprite_AssetV1_0_0> sprites = _sprites;
				int version2 = sprites._version + 1;
				sprites._version = version2;
				sprites._size = 0;
				if (sprites._size > 0)
				{
					Array.Clear(sprites._items, 0, sprites._size);
				}
			}

			public bool Contains(string spriteName)
			{
				//IL_0133: Expected I4, but got O
				List<TMProSprite_AssetV1_0_0> sprites = _sprites;
				if (_sprites != null)
				{
					bool flag = sprites._size <= 0;
					int num = 0;
					if (flag)
					{
						goto IL_0109;
					}
					while (_sprites != null)
					{
						TMProSprite_AssetV1_0_0 tMProSprite_AssetV1_0_ = _sprites.get_Item(num);
						if (tMProSprite_AssetV1_0_ == null)
						{
							break;
						}
						TMP_Sprite spriteInfo = tMProSprite_AssetV1_0_.spriteInfo;
						if (tMProSprite_AssetV1_0_.spriteInfo == null)
						{
							break;
						}
						if (!string.Equals(spriteInfo.name, spriteName, StringComparison.Ordinal))
						{
							num++;
							if (num < sprites._size)
							{
								continue;
							}
							goto IL_0109;
						}
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
				IL_0109:
				return false;
			}

			public void UpdateLookupTables()
			{
				_spriteAsset.UpdateLookupTables();
			}

			public void Destroy()
			{
				if (_spriteAsset != null)
				{
					UnityEngine.Object.Destroy(_spriteAsset);
					_spriteAsset = null;
				}
			}
		}

		public TMP_Sprite spriteInfo;

		public uint id
		{
			get
			{
				//IL_0041: Expected I4, but got O
				TMP_Sprite tMP_Sprite = spriteInfo;
				if (spriteInfo != null)
				{
					return (uint)tMP_Sprite.id;
				}
				NullReferenceException ex = new NullReferenceException();
				return (uint)(int)ex;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.id = (int)value;
			}
		}

		public float width
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				return tMP_Sprite.width;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.width = value;
			}
		}

		public float height
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				return tMP_Sprite.height;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.height = value;
			}
		}

		public float xOffset
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				return tMP_Sprite.xOffset;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.xOffset = value;
			}
		}

		public float yOffset
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				return tMP_Sprite.yOffset;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.yOffset = value;
			}
		}

		public float xAdvance
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				return tMP_Sprite.xAdvance;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.xAdvance = value;
			}
		}

		public Vector2 position
		{
			get
			{
				Vector2 result = default(Vector2);
				if (spriteInfo != null)
				{
					return result;
				}
				return (Vector2)new NullReferenceException();
			}
			set
			{
				//IL_001c: Expected F4, but got O
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.x = (float)value;
				float y = default(float);
				tMP_Sprite.y = y;
			}
		}

		public Vector2 pivot
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				if (spriteInfo != null)
				{
					return tMP_Sprite.pivot;
				}
				return (Vector2)new NullReferenceException();
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.pivot = value;
			}
		}

		public float scale
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				return tMP_Sprite.scale;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.scale = value;
			}
		}

		public string name
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				if (spriteInfo != null)
				{
					return tMP_Sprite.name;
				}
				return (string)(object)new NullReferenceException();
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.name = value;
			}
		}

		public uint unicode
		{
			get
			{
				//IL_0041: Expected I4, but got O
				TMP_Sprite tMP_Sprite = spriteInfo;
				if (spriteInfo != null)
				{
					return (uint)tMP_Sprite.unicode;
				}
				NullReferenceException ex = new NullReferenceException();
				return (uint)(int)ex;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.unicode = (int)value;
			}
		}

		public int hashCode
		{
			get
			{
				//IL_0041: Expected I4, but got O
				TMP_Sprite tMP_Sprite = spriteInfo;
				if (spriteInfo != null)
				{
					return tMP_Sprite.hashCode;
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.hashCode = value;
			}
		}

		public Sprite sprite
		{
			get
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				if (spriteInfo != null)
				{
					return tMP_Sprite.sprite;
				}
				return (Sprite)(object)new NullReferenceException();
			}
			set
			{
				TMP_Sprite tMP_Sprite = spriteInfo;
				tMP_Sprite.sprite = value;
			}
		}

		public TMProSprite_AssetV1_0_0()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			TMP_Sprite tMP_Sprite = new TMP_Sprite();
			spriteInfo = tMP_Sprite;
		}
	}

	private class TMProSprite_AssetV1_1_0 : ITMProSprite
	{
		public class TMPro_SpriteCharacter
		{
			private const string typeFullName = "TMPro.TMP_SpriteCharacter";

			private readonly object _source;

			private readonly PropertyInfo _glyph;

			private readonly PropertyInfo _unicode;

			private readonly PropertyInfo _name;

			private readonly PropertyInfo _scale;

			private readonly PropertyInfo _glyphIndex;

			private static Type s_type;

			public object source => _source;

			public Glyph glyph
			{
				get
				{
					//IL_004d: Expected I, but got O
					//IL_0055: Expected I, but got O
					//IL_0065: Expected O, but got I
					//IL_0091: Expected I, but got O
					//IL_00b7: Expected O, but got I
					//IL_00e4: Expected I, but got O
					Glyph value;
					if ((object)_glyph != null)
					{
						value = (Glyph)_glyph.GetValue(_source);
						if (value == null)
						{
							goto IL_003a;
						}
						nint num = (nint)typeof(Glyph);
						nint num2 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v3 (Il2CppClass<UnityEngine.TextCore.Glyph>)+130]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r9_v1 (Il2CppClass<UnityEngine.TextCore.Glyph>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v3 (Il2CppClass<UnityEngine.TextCore.Glyph>)+130]");
						bool flag = num3 < 0;
						nint num4 = (nint)typeof(Glyph);
						NullReferenceException ex = (NullReferenceException)(object)value;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r9_v1 (Il2CppClass<UnityEngine.TextCore.Glyph>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v6+FFFFFFF8+v84 @ rcx_v5*8]");
							bool flag2 = 0 != (nint)typeof(Glyph);
							num4 = (nint)typeof(Glyph);
							ex = (NullReferenceException)(object)value;
							if (!flag2)
							{
								goto IL_003a;
							}
						}
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					Glyph result = default(Glyph);
					return result;
					IL_003a:
					return value;
				}
				set
				{
					_glyph.SetValue(_source, value);
				}
			}

			public uint unicode
			{
				get
				{
					//IL_0056: Expected O, but got I4
					//IL_0074: Expected O, but got I
					//IL_007c: Expected I, but got O
					//IL_00c2: Expected I4, but got O
					if ((object)_unicode != null)
					{
						object value = _unicode.GetValue(_source);
						bool flag = value == null;
						TMPro_SpriteCharacter tMPro_SpriteCharacter = (TMPro_SpriteCharacter)(object)_unicode;
						object obj = 0;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B30]");
							obj = 0;
							nint num = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v1+40]");
							bool flag2 = num2 != 0;
							tMPro_SpriteCharacter = (TMPro_SpriteCharacter)value;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								return (uint)(int)obj2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							uint result = default(uint);
							return result;
						}
					}
					throw new NullReferenceException();
				}
				set
				{
					if (value == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					}
					object value2 = default(object);
					_unicode.SetValue(_source, value2);
				}
			}

			public string name
			{
				get
				{
					object value = _name.GetValue(_source);
					bool flag = value != null;
					string text = (string)value;
					if (flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
						bool flag2 = value != null;
						text = null;
						if (!flag2)
						{
							text = (string)value;
						}
						if (text == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							string result = default(string);
							return result;
						}
					}
					return text;
				}
				set
				{
					_name.SetValue(_source, value);
				}
			}

			public float scale
			{
				get
				{
					//IL_0056: Expected O, but got I4
					//IL_0074: Expected O, but got I
					//IL_007c: Expected I, but got O
					//IL_00c2: Expected F4, but got O
					if ((object)_scale != null)
					{
						object value = _scale.GetValue(_source);
						bool flag = value == null;
						TMPro_SpriteCharacter tMPro_SpriteCharacter = (TMPro_SpriteCharacter)(object)_scale;
						object obj = 0;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
							obj = 0;
							nint num = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v1+40]");
							bool flag2 = num2 != 0;
							tMPro_SpriteCharacter = (TMPro_SpriteCharacter)value;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								return (float)obj2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							float result = default(float);
							return result;
						}
					}
					throw new NullReferenceException();
				}
				set
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object value2 = default(object);
					_scale.SetValue(_source, value2);
				}
			}

			public uint glyphIndex
			{
				get
				{
					//IL_0056: Expected O, but got I4
					//IL_0074: Expected O, but got I
					//IL_007c: Expected I, but got O
					//IL_00c2: Expected I4, but got O
					if ((object)_glyphIndex != null)
					{
						object value = _glyphIndex.GetValue(_source);
						bool flag = value == null;
						TMPro_SpriteCharacter tMPro_SpriteCharacter = (TMPro_SpriteCharacter)(object)_glyphIndex;
						object obj = 0;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B30]");
							obj = 0;
							nint num = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v1+40]");
							bool flag2 = num2 != 0;
							tMPro_SpriteCharacter = (TMPro_SpriteCharacter)value;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								return (uint)(int)obj2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							uint result = default(uint);
							return result;
						}
					}
					throw new NullReferenceException();
				}
				set
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object value2 = default(object);
					_glyphIndex.SetValue(_source, value2);
				}
			}

			public TMPro_SpriteCharacter()
			{
				//IL_026d: Expected I, but got O
				//IL_008e: Expected I, but got O
				//IL_00a4: Expected I, but got O
				//IL_00b4: Expected O, but got I
				//IL_02b5: Expected I, but got O
				//IL_00e6: Expected I, but got O
				//IL_00f6: Expected O, but got I
				//IL_02df: Expected I, but got O
				//IL_0338: Expected O, but got I4
				//IL_0341: Expected O, but got I4
				//IL_034a: Expected O, but got I4
				//IL_0184: Expected O, but got I
				//IL_03a3: Expected O, but got I4
				//IL_03ac: Expected O, but got I4
				//IL_03b5: Expected O, but got I4
				//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e9: Expected O, but got Unknown
				//IL_01f7: Expected I, but got O
				//IL_040e: Expected O, but got I4
				//IL_0417: Expected O, but got I4
				//IL_0420: Expected O, but got I4
				//IL_0223: Expected I, but got O
				//IL_0242: Expected O, but got I
				//IL_0479: Expected O, but got I4
				//IL_0483: Expected I, but got O
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172463]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
				object obj = default(object);
				if (obj != null)
				{
					goto IL_0247;
				}
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(TMP_SpriteAsset));
				bool flag = (object)typeFromHandle == null;
				string text = null;
				nint num = unchecked((nint)null);
				Type type2;
				if (!flag)
				{
					num = (nint)typeFromHandle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ r8_v2 (Il2CppClass<System.Type>)+2F0]");
					text = (string)0;
					Assembly assembly = typeFromHandle.Assembly;
					if ((object)assembly != null)
					{
						num = (nint)assembly;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ r8_v2 (Il2CppClass<System.Type>)+270]");
						text = (string)0;
						bool flag2 = !((Type)(object)assembly).IsSerializable;
						Type type = null;
						type2 = null;
						if (!flag2)
						{
							string text2 = default(string);
							while (true)
							{
								Type type3 = type;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v85 (System.Boolean)+18]");
								if ((nint)type3 >= 0)
								{
									break;
								}
								Type type4 = type;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v85 (System.Boolean)+18]");
								if ((nint)type4 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v85 (System.Boolean)+20+v110 @ rbx_v23 (System.Type)*8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v85 (System.Boolean)+20+v110 @ rbx_v23 (System.Type)*8]");
									if ((nint)0 == 0)
									{
										goto IL_0681;
									}
									object obj3 = obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v455 @ rax_v89+2D8] (should have been resolved before IL gen)");
									if (text2 != "TMPro.TMP_SpriteCharacter")
									{
										type = (Type)(type + 1);
										text = "TMPro.TMP_SpriteCharacter";
										num = unchecked((nint)null);
										continue;
									}
									Type type5 = type;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v85 (System.Boolean)+18]");
									bool flag3 = (nint)type5 >= 0;
									text = "TMPro.TMP_SpriteCharacter";
									num = unchecked((nint)null);
									if (!flag3)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v85 (System.Boolean)+20+v110 @ rbx_v23 (System.Type)*8]");
										s_type = (Type)0;
										break;
									}
								}
								throw new IndexOutOfRangeException();
							}
							goto IL_0247;
						}
						goto IL_0255;
					}
				}
				goto IL_0681;
				IL_0247:
				type2 = s_type;
				goto IL_0255;
				IL_0255:
				bool flag4 = ((object)type2).Equals((object)null);
				object obj4 = null;
				nint num2 = unchecked((nint)null);
				if (flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					ArgumentNullException ex = new ArgumentNullException("type");
					ex._002Ector("type");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					throw ex;
				}
				object obj5 = (_source = Activator.CreateInstance(type2));
				bool flag5 = _source == null;
				text = (string)obj5;
				num = unchecked((nint)null);
				if (!flag5)
				{
					bool flag6 = (object)type2 == null;
					text = (string)obj5;
					num = unchecked((nint)null);
					if (!flag6)
					{
						_glyph = type2.GetProperty("glyph", (BindingFlags)20);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
						object obj6 = default(object);
						bool flag7 = obj6 != null;
						object obj7 = 0;
						object obj8 = 0;
						object obj9 = 0;
						if (!flag7)
						{
							_unicode = type2.GetProperty("unicode", (BindingFlags)20);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
							object obj10 = default(object);
							bool flag8 = obj10 != null;
							obj7 = 0;
							object obj11 = 0;
							object obj12 = 0;
							if (!flag8)
							{
								_name = type2.GetProperty("name", (BindingFlags)20);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
								object obj13 = default(object);
								bool flag9 = obj13 != null;
								obj7 = 0;
								object obj14 = 0;
								object obj15 = 0;
								if (!flag9)
								{
									_scale = type2.GetProperty("scale", (BindingFlags)20);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
									object obj16 = default(object);
									bool flag10 = obj16 != null;
									obj7 = 0;
									text = null;
									num = unchecked((nint)null);
									if (!flag10)
									{
										_glyphIndex = type2.GetProperty("glyphIndex", (BindingFlags)20);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
										object obj17 = default(object);
										if (obj17 == null)
										{
											return;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
										ArgumentNullException ex2 = new ArgumentNullException("glyphIndex");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
										throw ex2;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
									ArgumentNullException ex3 = new ArgumentNullException("scale");
									ex3._002Ector("scale");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
									throw ex3;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
								ArgumentNullException ex4 = new ArgumentNullException("name");
								ex4._002Ector("name");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
								throw ex4;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							ArgumentNullException ex5 = new ArgumentNullException("unicode");
							ex5._002Ector("unicode");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							throw ex5;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						ArgumentNullException ex6 = new ArgumentNullException("glyph");
						ex6._002Ector("glyph");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						throw ex6;
					}
					goto IL_0681;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentNullException ex7 = new ArgumentNullException("source");
				ex7._002Ector("source");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex7;
				IL_0681:
				throw new NullReferenceException();
			}

			private static Type GetReflectedType()
			{
				//IL_0096: Expected I, but got O
				//IL_00c9: Expected O, but got I4
				//IL_00d2: Expected O, but got I4
				//IL_00e7: Expected O, but got I
				//IL_0147: Unknown result type (might be due to invalid IL or missing references)
				//IL_014c: Expected O, but got Unknown
				//IL_0151: Expected I, but got O
				//IL_016f: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
				object obj = default(object);
				if (obj == null)
				{
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(TMP_SpriteAsset));
					if ((object)typeFromHandle != null)
					{
						Assembly assembly = typeFromHandle.Assembly;
						if ((object)assembly != null)
						{
							nint num = (nint)assembly;
							Type types = (Type)(object)assembly.GetTypes();
							if ((object)types == null)
							{
								return types;
							}
							object obj2 = 0;
							object obj3 = 0;
							string text = default(string);
							while (true)
							{
								object obj4 = obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+18]");
								if ((nint)obj4 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+20+v180 @ rbx_v7*8]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+20+v180 @ rbx_v7*8]");
									if ((nint)0 == 0)
									{
										break;
									}
									object obj6 = obj5;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v283 @ rax_v23+2D8] (should have been resolved before IL gen)");
									if (text != "TMPro.TMP_SpriteCharacter")
									{
										obj2++;
										num = unchecked((nint)null);
										obj3 = obj2;
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+20+v180 @ rbx_v7*8]");
									s_type = (Type)0;
								}
								return s_type;
							}
						}
					}
					return (Type)(object)new NullReferenceException();
				}
				return s_type;
			}
		}

		public class TMPro_SpriteGlyph
		{
			private const string typeFullName = "TMPro.TMP_SpriteGlyph";

			private readonly Glyph _source;

			private readonly FieldInfo _sprite;

			private static Type s_type;

			public Glyph source => _source;

			public Sprite sprite
			{
				get
				{
					FieldInfo fieldInfo = _sprite;
					Sprite sprite = (Sprite)fieldInfo.GetValue(_source);
					if ((object)sprite != null)
					{
						bool flag = (object)sprite.GetType() != typeof(Sprite);
						Sprite sprite2 = null;
						if (!flag)
						{
							sprite2 = sprite;
						}
						if ((object)sprite2 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							Sprite result = default(Sprite);
							return result;
						}
						sprite = sprite2;
					}
					return sprite;
				}
				set
				{
					_sprite.SetValue(_source, value);
				}
			}

			public TMPro_SpriteGlyph()
			{
				//IL_0060: Expected I, but got O
				//IL_0076: Expected I, but got O
				//IL_0086: Expected O, but got I
				//IL_027f: Expected I, but got O
				//IL_028d: Expected I, but got O
				//IL_029d: Expected O, but got I
				//IL_02c9: Expected I, but got O
				//IL_02d1: Expected I, but got O
				//IL_00b8: Expected I, but got O
				//IL_00c8: Expected O, but got I
				//IL_02ef: Expected O, but got I
				//IL_031c: Expected I, but got O
				//IL_0324: Expected I, but got O
				//IL_0420: Expected I, but got O
				//IL_00f7: Expected O, but got I4
				//IL_0100: Expected O, but got I4
				//IL_034a: Expected I, but got O
				//IL_0352: Expected I, but got O
				//IL_0362: Expected O, but got I
				//IL_038e: Expected I, but got O
				//IL_0396: Expected I, but got O
				//IL_044d: Expected I, but got O
				//IL_03b4: Expected O, but got I
				//IL_03e9: Expected I, but got O
				//IL_03f1: Expected I, but got O
				//IL_0463: Expected I, but got O
				//IL_04bf: Expected I, but got O
				//IL_013c: Expected O, but got I
				//IL_04e8: Expected I, but got O
				//IL_019c: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a1: Expected O, but got Unknown
				//IL_01af: Expected I, but got O
				//IL_01e3: Expected I, but got O
				//IL_0202: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
				object obj = default(object);
				if (obj != null)
				{
					goto IL_0207;
				}
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(TMP_SpriteAsset));
				bool flag = (object)typeFromHandle == null;
				string text = null;
				nint num = unchecked((nint)null);
				Type type;
				if (!flag)
				{
					num = (nint)typeFromHandle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ r8_v2 (Il2CppClass<System.Type>)+2F0]");
					text = (string)0;
					Assembly assembly = typeFromHandle.Assembly;
					if ((object)assembly != null)
					{
						num = (nint)assembly;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ r8_v2 (Il2CppClass<System.Type>)+270]");
						text = (string)0;
						if (((Type)(object)assembly).IsSerializable)
						{
							object obj2 = 0;
							object obj3 = 0;
							string text2 = default(string);
							while (true)
							{
								object obj4 = obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v57 (System.Boolean)+18]");
								if ((nint)obj4 >= 0)
								{
									break;
								}
								object obj5 = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v57 (System.Boolean)+18]");
								if ((nint)obj5 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v57 (System.Boolean)+20+v104 @ rbx_v19*8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v57 (System.Boolean)+20+v104 @ rbx_v19*8]");
									if ((nint)0 == 0)
									{
										goto IL_05ec;
									}
									object obj7 = obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v557 @ rax_v61+2D8] (should have been resolved before IL gen)");
									if (text2 != "TMPro.TMP_SpriteGlyph")
									{
										obj2++;
										text = "TMPro.TMP_SpriteGlyph";
										num = unchecked((nint)null);
										obj3 = obj2;
										continue;
									}
									object obj8 = obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v57 (System.Boolean)+18]");
									bool flag2 = (nint)obj8 >= 0;
									text = "TMPro.TMP_SpriteGlyph";
									num = unchecked((nint)null);
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v57 (System.Boolean)+20+v104 @ rbx_v19*8]");
										s_type = (Type)0;
										break;
									}
								}
								throw new IndexOutOfRangeException();
							}
							goto IL_0207;
						}
						type = null;
						goto IL_0215;
					}
				}
				goto IL_05ec;
				IL_05ec:
				throw new NullReferenceException();
				IL_0207:
				type = s_type;
				goto IL_0215;
				IL_03ff:
				bool flag3 = _source == null;
				object obj9;
				text = (string)obj9;
				num = (nint)obj9;
				if (!flag3)
				{
					bool flag4 = (object)type == null;
					text = (string)obj9;
					num = (nint)obj9;
					if (!flag4)
					{
						nint num2 = (nint)type;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rax_v37 (Il2CppClass<System.Type>)+6D0]");
						nint num3 = 0;
						_sprite = type.GetField("sprite", (BindingFlags)20);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
						object obj10 = default(object);
						bool flag5 = obj10 != null;
						text = null;
						num = unchecked((nint)null);
						if (flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							ArgumentNullException ex = new ArgumentNullException("sprite");
							ex._002Ector("sprite");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							throw ex;
						}
						bool flag6 = _source == null;
						text = null;
						num = unchecked((nint)null);
						if (!flag6)
						{
							_source.scale = 1f;
							_source.atlasIndex = 0;
							return;
						}
					}
					goto IL_05ec;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentNullException ex2 = new ArgumentNullException("glyph");
				ex2._002Ector("glyph");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex2;
				IL_0215:
				if (!((object)type).Equals((object)null))
				{
					obj9 = Activator.CreateInstance(type);
					if (obj9 == null)
					{
						_source = (Glyph)obj9;
						goto IL_03ff;
					}
					nint num4 = (nint)obj9;
					nint num5 = (nint)typeof(Glyph);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rdx_v22 (Il2CppClass<UnityEngine.TextCore.Glyph>)+130]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ r9_v4 (Il2CppClass<System.Object>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rdx_v22 (Il2CppClass<UnityEngine.TextCore.Glyph>)+130]");
					bool flag7 = num6 < 0;
					nint num7 = (nint)typeof(Glyph);
					nint num8 = (nint)obj9;
					if (!flag7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ r9_v4 (Il2CppClass<System.Object>)+C8]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v44+FFFFFFF8+v406 @ rax_v43*8]");
						bool flag8 = 0 != (nint)typeof(Glyph);
						num7 = (nint)typeof(Glyph);
						num8 = (nint)obj9;
						if (!flag8)
						{
							_source = (Glyph)obj9;
							nint num9 = (nint)typeof(Glyph);
							num4 = (nint)obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rdx_v23 (Il2CppClass<UnityEngine.TextCore.Glyph>)+130]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ r9_v4 (Il2CppClass<System.Object>)+130]");
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rdx_v23 (Il2CppClass<UnityEngine.TextCore.Glyph>)+130]");
							bool flag9 = num10 < 0;
							num7 = (nint)typeof(Glyph);
							num8 = (nint)obj9;
							if (!flag9)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ r9_v4 (Il2CppClass<System.Object>)+C8]");
								object obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rax_v46+FFFFFFF8+v542 @ rax_v45*8]");
								bool flag10 = 0 != (nint)typeof(Glyph);
								nint num3 = num4;
								num7 = (nint)typeof(Glyph);
								num8 = (nint)obj9;
								if (!flag10)
								{
									goto IL_03ff;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentNullException ex3 = new ArgumentNullException("type");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex3;
			}

			private static Type GetReflectedType()
			{
				//IL_0096: Expected I, but got O
				//IL_00c9: Expected O, but got I4
				//IL_00d2: Expected O, but got I4
				//IL_00e7: Expected O, but got I
				//IL_0147: Unknown result type (might be due to invalid IL or missing references)
				//IL_014c: Expected O, but got Unknown
				//IL_0151: Expected I, but got O
				//IL_016f: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5BF0");
				object obj = default(object);
				if (obj == null)
				{
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(TMP_SpriteAsset));
					if ((object)typeFromHandle != null)
					{
						Assembly assembly = typeFromHandle.Assembly;
						if ((object)assembly != null)
						{
							nint num = (nint)assembly;
							Type types = (Type)(object)assembly.GetTypes();
							if ((object)types == null)
							{
								return types;
							}
							object obj2 = 0;
							object obj3 = 0;
							string text = default(string);
							while (true)
							{
								object obj4 = obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+18]");
								if ((nint)obj4 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+20+v180 @ rbx_v7*8]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+20+v180 @ rbx_v7*8]");
									if ((nint)0 == 0)
									{
										break;
									}
									object obj6 = obj5;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v283 @ rax_v23+2D8] (should have been resolved before IL gen)");
									if (text != "TMPro.TMP_SpriteGlyph")
									{
										obj2++;
										num = unchecked((nint)null);
										obj3 = obj2;
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v13 (System.Type)+20+v180 @ rbx_v7*8]");
									s_type = (Type)0;
								}
								return s_type;
							}
						}
					}
					return (Type)(object)new NullReferenceException();
				}
				return s_type;
			}

			private static void Initialize(Glyph glyph)
			{
				glyph.scale = 1f;
				glyph.atlasIndex = 0;
			}
		}

		public class TMPro_SpriteAsset : ITMProSpriteAsset
		{
			private readonly PropertyInfo _spriteCharacterTable;

			private readonly PropertyInfo _spriteGlyphTable;

			private readonly IList _spriteCharacterTableList;

			private readonly IList _spriteGlyphTableList;

			private readonly List<TMProSprite_AssetV1_1_0> _sprites;

			private TMP_SpriteAsset _spriteAsset;

			public int spriteCount
			{
				get
				{
					//IL_001d: Expected I4, but got O
					List<TMProSprite_AssetV1_1_0> sprites = _sprites;
					if (_sprites != null)
					{
						return sprites._size;
					}
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
			}

			public Texture spriteSheet
			{
				get
				{
					TMP_SpriteAsset spriteAsset = _spriteAsset;
					if ((object)_spriteAsset != null)
					{
						return spriteAsset.spriteSheet;
					}
					return (Texture)(object)new NullReferenceException();
				}
				set
				{
					TMP_SpriteAsset spriteAsset = _spriteAsset;
					spriteAsset.spriteSheet = value;
				}
			}

			public TMPro_SpriteAsset()
			{
				//IL_0070: Expected O, but got I4
				//IL_00a3: Expected O, but got I4
				//IL_00f7: Expected O, but got I4
				//IL_0100: Expected O, but got I4
				//IL_012b: Expected O, but got I4
				//IL_013c: Expected O, but got I4
				//IL_01b3: Expected O, but got I4
				//IL_01bc: Expected O, but got I4
				//IL_01e9: Expected O, but got I4
				//IL_01fa: Expected O, but got I4
				//IL_0288: Expected I, but got O
				//IL_0291: Expected O, but got I4
				//IL_029a: Expected O, but got I4
				//IL_076a: Expected O, but got I
				//IL_02e1: Expected I, but got O
				//IL_02ef: Expected I, but got O
				//IL_02f8: Expected O, but got I4
				//IL_0309: Expected O, but got I4
				//IL_0339: Expected O, but got I4
				//IL_0342: Expected O, but got I4
				//IL_03ab: Expected O, but got I4
				//IL_03b4: Expected O, but got I4
				//IL_03b9: Expected I, but got O
				//IL_03e9: Expected O, but got I4
				//IL_03fa: Expected O, but got I4
				//IL_048b: Expected O, but got I4
				//IL_0499: Expected I, but got O
				//IL_04a2: Expected O, but got I4
				//IL_0454: Expected I, but got O
				//IL_04e9: Expected I, but got O
				//IL_04fa: Expected O, but got I4
				//IL_0508: Expected I, but got O
				//IL_0519: Expected O, but got I4
				//IL_0549: Expected O, but got I4
				//IL_055a: Expected O, but got I4
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				TMP_SpriteAsset tMP_SpriteAsset = (_spriteAsset = ScriptableObject.CreateInstance<TMP_SpriteAsset>());
				bool flag = (object)_spriteAsset == null;
				TMP_SpriteAsset tMP_SpriteAsset2 = tMP_SpriteAsset;
				Type typeFromHandle;
				nint num;
				object obj8 = default(object);
				object obj2;
				nint num2 = default(nint);
				object obj4;
				if (!flag)
				{
					_spriteAsset.hideFlags = HideFlags.DontSave;
					typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(TMP_SpriteAsset));
					bool flag2 = ((object)typeFromHandle).Equals((object)null);
					object obj = 0;
					TMP_SpriteAsset tMP_SpriteAsset3 = null;
					if (flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						ArgumentNullException ex = new ArgumentNullException("type");
						ex._002Ector("type");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						throw ex;
					}
					bool flag3 = (object)typeFromHandle == null;
					Type type = typeFromHandle;
					obj2 = 0;
					tMP_SpriteAsset2 = null;
					if (!flag3)
					{
						PropertyInfo property = typeFromHandle.GetProperty("version", (BindingFlags)20);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
						object obj3 = default(object);
						bool flag4 = obj3 != null;
						obj4 = 0;
						object obj5 = 0;
						TMP_SpriteAsset tMP_SpriteAsset4 = null;
						if (flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							ArgumentNullException ex2 = new ArgumentNullException("version");
							ex2._002Ector("version");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							throw ex2;
						}
						bool flag5 = (object)property == null;
						obj4 = 0;
						type = typeFromHandle;
						obj2 = 0;
						tMP_SpriteAsset2 = null;
						if (!flag5)
						{
							property.SetValue(_spriteAsset, "1.1.0");
							_spriteCharacterTable = typeFromHandle.GetProperty("spriteCharacterTable", (BindingFlags)20);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
							object obj6 = default(object);
							bool flag6 = obj6 != null;
							obj4 = 0;
							object obj7 = 0;
							TMP_SpriteAsset tMP_SpriteAsset5 = null;
							if (!flag6)
							{
								bool flag7 = (object)_spriteCharacterTable == null;
								obj4 = 0;
								type = typeFromHandle;
								obj2 = 0;
								tMP_SpriteAsset2 = null;
								if (flag7)
								{
									goto IL_058a;
								}
								object value = _spriteCharacterTable.GetValue(_spriteAsset);
								if (value == null)
								{
									_spriteCharacterTableList = (IList)value;
									num = num2;
									obj8 = value;
									goto IL_0317;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
								IList list = default(IList);
								bool flag8 = list == null;
								num2 = (nint)typeof(IList);
								obj4 = 0;
								obj7 = 0;
								ArgumentNullException ex3 = (ArgumentNullException)value;
								if (!flag8)
								{
									_spriteCharacterTableList = list;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									bool flag9 = obj8 == null;
									num = (nint)typeof(IList);
									num2 = (nint)typeof(IList);
									obj4 = 0;
									ArgumentNullException ex4 = (ArgumentNullException)value;
									obj7 = 0;
									if (!flag9)
									{
										goto IL_0317;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
									ex3 = ex4;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
								tMP_SpriteAsset5 = (TMP_SpriteAsset)num2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							ArgumentNullException ex5 = new ArgumentNullException("spriteCharacterTable");
							ex5._002Ector("spriteCharacterTable");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							throw ex5;
						}
					}
				}
				goto IL_058a;
				IL_058a:
				throw new NullReferenceException();
				IL_0527:
				bool flag10 = _spriteGlyphTableList == null;
				num2 = num;
				obj4 = 0;
				nint num4;
				nint num3 = num4;
				obj2 = 0;
				object obj9 = default(object);
				tMP_SpriteAsset2 = (TMP_SpriteAsset)obj9;
				if (!flag10)
				{
					_sprites = new List<TMProSprite_AssetV1_1_0>();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentNullException ex6 = new ArgumentNullException("spriteGlyphTableList");
				ex6._002Ector("spriteGlyphTableList");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex6;
				IL_0317:
				bool flag11 = _spriteCharacterTableList == null;
				num2 = num;
				obj4 = 0;
				object obj10 = 0;
				object obj11 = obj8;
				if (!flag11)
				{
					_spriteGlyphTable = typeFromHandle.GetProperty("spriteGlyphTable", (BindingFlags)20);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EBAE0");
					object obj12 = default(object);
					bool flag12 = obj12 != null;
					num2 = num;
					obj4 = 0;
					object obj13 = 0;
					nint num5 = unchecked((nint)null);
					if (!flag12)
					{
						bool flag13 = (object)_spriteGlyphTable == null;
						num2 = num;
						obj4 = 0;
						Type type = typeFromHandle;
						obj2 = 0;
						tMP_SpriteAsset2 = null;
						if (flag13)
						{
							goto IL_058a;
						}
						object value2 = _spriteGlyphTable.GetValue(_spriteAsset);
						if (value2 == null)
						{
							_spriteGlyphTableList = (IList)value2;
							num4 = (nint)typeFromHandle;
							obj9 = value2;
							goto IL_0527;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						IList list2 = default(IList);
						bool flag14 = list2 == null;
						num2 = num;
						obj4 = 0;
						num3 = (nint)typeof(IList);
						obj13 = 0;
						ArgumentNullException ex7 = (ArgumentNullException)value2;
						if (!flag14)
						{
							_spriteGlyphTableList = list2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							bool flag15 = obj9 == null;
							num4 = (nint)typeof(IList);
							num2 = num;
							obj4 = 0;
							num3 = (nint)typeof(IList);
							ArgumentNullException ex8 = (ArgumentNullException)value2;
							obj13 = 0;
							if (!flag15)
							{
								goto IL_0527;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							ex7 = ex8;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						num5 = num3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					ArgumentNullException ex9 = new ArgumentNullException("spriteGlyphTable");
					ex9._002Ector("spriteGlyphTable");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					throw ex9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentNullException ex10 = new ArgumentNullException("spriteCharacterTableList");
				ex10._002Ector("spriteCharacterTableList");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex10;
			}

			public TMP_SpriteAsset GetSpriteAsset()
			{
				return _spriteAsset;
			}

			public ITMProSprite GetSprite(int index)
			{
				List<TMProSprite_AssetV1_1_0> sprites = _sprites;
				if (_sprites != null)
				{
					if (index < sprites._size)
					{
						return _sprites.get_Item(index);
					}
					return null;
				}
				return (ITMProSprite)new NullReferenceException();
			}

			public void AddSprite(ITMProSprite sprite)
			{
				//IL_0260: Expected I, but got O
				//IL_0013: Expected I, but got O
				//IL_001b: Expected I, but got O
				//IL_002b: Expected O, but got I
				//IL_0057: Expected I, but got O
				//IL_0075: Expected O, but got I
				//IL_00a2: Expected I, but got O
				//IL_00ca: Expected O, but got I
				//IL_00e9: Expected O, but got I
				//IL_011e: Expected O, but got I
				//IL_011e: Expected O, but got I
				//IL_012e: Expected O, but got I
				//IL_014d: Expected O, but got I
				bool flag = sprite == null;
				IntPtr intPtr = default(IntPtr);
				nint num = intPtr;
				nint num2 = (nint)sprite;
				if (!flag)
				{
					nint num3 = (nint)typeof(TMProSprite_AssetV1_1_0);
					num = (nint)sprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v7 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSprite_AssetV1_1_0>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v4 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v7 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSprite_AssetV1_1_0>)+130]");
					bool flag2 = num4 < 0;
					num2 = (nint)typeof(TMProSprite_AssetV1_1_0);
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v4 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v15+FFFFFFF8+v46 @ rax_v14*8]");
						bool flag3 = 0 != (nint)typeof(TMProSprite_AssetV1_1_0);
						num2 = (nint)typeof(TMProSprite_AssetV1_1_0);
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sprite @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite)+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039F380");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sprite @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite)+18]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v10+38]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v10+10]");
							object value = default(object);
							((PropertyInfo)num5).SetValue(0, value);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sprite @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite)+18]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003110");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sprite @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite)+10]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003110");
							List<object> sprites = (List<object>)(object)_sprites;
							int version = sprites._version + 1;
							sprites._version = version;
							object[] items = sprites._items;
							if (sprites._size >= items.Length)
							{
								sprites.AddWithResize((object)sprite);
								return;
							}
							int size = sprites._size + 1;
							sprites._size = size;
							int num6 = default(int);
							items[num6] = sprite;
							return;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentException ex = new ArgumentException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}

			public void Clear()
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				List<TMProSprite_AssetV1_1_0> sprites = _sprites;
				int version = sprites._version + 1;
				sprites._version = version;
				sprites._size = 0;
				if (sprites._size > 0)
				{
					Array.Clear(sprites._items, 0, sprites._size);
				}
			}

			public bool Contains(string spriteName)
			{
				//IL_0201: Expected I4, but got O
				//IL_026b: Expected I4, but got O
				//IL_0024: Expected I4, but got O
				//IL_0082: Expected I4, but got O
				//IL_00e8: Expected O, but got I
				//IL_00e8: Expected O, but got I
				//IL_01a4: Expected I4, but got O
				List<TMProSprite_AssetV1_1_0> sprites = _sprites;
				bool flag = _sprites == null;
				int index = (int)spriteName;
				NullReferenceException ex;
				if (!flag)
				{
					bool flag2 = sprites._size <= 0;
					index = (int)spriteName;
					int num = 0;
					if (flag2)
					{
						goto IL_01b3;
					}
					while (_sprites != null)
					{
						TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_ = _sprites.get_Item(num);
						bool flag3 = tMProSprite_AssetV1_1_ == null;
						index = num;
						if (flag3)
						{
							break;
						}
						index = (int)tMProSprite_AssetV1_1_._spriteCharacter;
						if (tMProSprite_AssetV1_1_._spriteCharacter == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdx_v1 (System.Int32)+28]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdx_v1 (System.Int32)+28]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdx_v1 (System.Int32)+10]");
						object value = ((PropertyInfo)num2).GetValue(0);
						bool flag4 = value == null;
						string text = null;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
							index = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
							bool flag5 = value != null;
							text = null;
							if (!flag5)
							{
								text = (string)value;
							}
							bool flag6 = text == null;
							ex = (NullReferenceException)value;
							if (flag6)
							{
								goto IL_025a;
							}
						}
						if (!string.Equals(text, spriteName, StringComparison.Ordinal))
						{
							num++;
							bool flag7 = num < sprites._size;
							index = (int)spriteName;
							if (flag7)
							{
								continue;
							}
							goto IL_01b3;
						}
						return true;
					}
				}
				ex = new NullReferenceException();
				goto IL_025a;
				IL_025a:
				return (byte)(int)((List<TMProSprite_AssetV1_1_0>)(object)ex).get_Item(index) != 0;
				IL_01b3:
				return false;
			}

			public void UpdateLookupTables()
			{
				_spriteAsset.UpdateLookupTables();
			}

			public void Destroy()
			{
				if (_spriteAsset != null)
				{
					UnityEngine.Object.Destroy(_spriteAsset);
					_spriteAsset = null;
				}
			}
		}

		private readonly TMPro_SpriteGlyph _spriteGlyph;

		private readonly TMPro_SpriteCharacter _spriteCharacter;

		private static bool? s_isVersionSupported;

		public TMPro_SpriteGlyph spriteGlyph => _spriteGlyph;

		public TMPro_SpriteCharacter spriteCharacter => _spriteCharacter;

		public uint id
		{
			get
			{
				//IL_0070: Expected I4, but got O
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				if (_spriteGlyph != null && tMPro_SpriteGlyph._source != null)
				{
					return tMPro_SpriteGlyph._source.index;
				}
				NullReferenceException ex = new NullReferenceException();
				return (uint)(int)ex;
			}
			set
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				tMPro_SpriteGlyph._source.index = value;
				TMPro_SpriteCharacter tMPro_SpriteCharacter = _spriteCharacter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object value2 = default(object);
				tMPro_SpriteCharacter._glyphIndex.SetValue(tMPro_SpriteCharacter._source, value2);
			}
		}

		public unsafe float width
		{
			get
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182276030");
				float result = default(float);
				return result;
			}
			set
			{
				//IL_0048: Expected O, but got Ref
				//IL_00a3: Expected O, but got Ref
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803C8CE0");
				TMPro_SpriteGlyph tMPro_SpriteGlyph2 = _spriteGlyph;
				float num = default(float);
				tMPro_SpriteGlyph2._source.metrics = (GlyphMetrics)(&num);
				TMPro_SpriteGlyph tMPro_SpriteGlyph3 = _spriteGlyph;
				GlyphRect glyphRect = tMPro_SpriteGlyph3._source.glyphRect;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809A53E0");
				TMPro_SpriteGlyph tMPro_SpriteGlyph4 = _spriteGlyph;
				tMPro_SpriteGlyph4._source.glyphRect = (GlyphRect)(&num);
			}
		}

		public unsafe float height
		{
			get
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18224D8C0");
				float result = default(float);
				return result;
			}
			set
			{
				//IL_0048: Expected O, but got Ref
				//IL_00a3: Expected O, but got Ref
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D3CDE0");
				TMPro_SpriteGlyph tMPro_SpriteGlyph2 = _spriteGlyph;
				float num = default(float);
				tMPro_SpriteGlyph2._source.metrics = (GlyphMetrics)(&num);
				TMPro_SpriteGlyph tMPro_SpriteGlyph3 = _spriteGlyph;
				GlyphRect glyphRect = tMPro_SpriteGlyph3._source.glyphRect;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181478160");
				TMPro_SpriteGlyph tMPro_SpriteGlyph4 = _spriteGlyph;
				tMPro_SpriteGlyph4._source.glyphRect = (GlyphRect)(&num);
			}
		}

		public unsafe float xOffset
		{
			get
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182276020");
				float result = default(float);
				return result;
			}
			set
			{
				//IL_0051: Expected O, but got Ref
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181911770");
				TMPro_SpriteGlyph tMPro_SpriteGlyph2 = _spriteGlyph;
				object obj = default(object);
				tMPro_SpriteGlyph2._source.metrics = (GlyphMetrics)(&obj);
			}
		}

		public unsafe float yOffset
		{
			get
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18225F9B0");
				float result = default(float);
				return result;
			}
			set
			{
				//IL_0051: Expected O, but got Ref
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181911340");
				TMPro_SpriteGlyph tMPro_SpriteGlyph2 = _spriteGlyph;
				object obj = default(object);
				tMPro_SpriteGlyph2._source.metrics = (GlyphMetrics)(&obj);
			}
		}

		public unsafe float xAdvance
		{
			get
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				GlyphMetrics glyphMetrics = default(GlyphMetrics);
				return glyphMetrics.horizontalAdvance;
			}
			set
			{
				//IL_0051: Expected O, but got Ref
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphMetrics metrics = tMPro_SpriteGlyph._source.metrics;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804B7D90");
				TMPro_SpriteGlyph tMPro_SpriteGlyph2 = _spriteGlyph;
				object obj = default(object);
				tMPro_SpriteGlyph2._source.metrics = (GlyphMetrics)(&obj);
			}
		}

		public unsafe Vector2 position
		{
			get
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				if (_spriteGlyph != null && tMPro_SpriteGlyph._source != null)
				{
					GlyphRect glyphRect = tMPro_SpriteGlyph._source.glyphRect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DD6D0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DB5A0");
					Vector2 result = default(Vector2);
					return result;
				}
				return (Vector2)new NullReferenceException();
			}
			set
			{
				//IL_006a: Expected O, but got Ref
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				GlyphRect glyphRect = tMPro_SpriteGlyph._source.glyphRect;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B5D20");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+24h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F68E0");
				TMPro_SpriteGlyph tMPro_SpriteGlyph2 = _spriteGlyph;
				object obj = default(object);
				tMPro_SpriteGlyph2._source.glyphRect = (GlyphRect)(&obj);
			}
		}

		public Vector2 pivot
		{
			get
			{
				//IL_0006: Expected O, but got I4
				return (Vector2)0;
			}
			set
			{
			}
		}

		public float scale
		{
			get
			{
				//IL_008b: Expected O, but got I4
				//IL_00b6: Expected O, but got I
				//IL_00be: Expected I, but got O
				//IL_0104: Expected F4, but got O
				TMPro_SpriteCharacter tMPro_SpriteCharacter = _spriteCharacter;
				if (_spriteCharacter != null)
				{
					bool flag = (object)tMPro_SpriteCharacter._scale == null;
					TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)(object)tMPro_SpriteCharacter._scale;
					if (!flag)
					{
						object value = tMPro_SpriteCharacter._scale.GetValue(tMPro_SpriteCharacter._source);
						bool flag2 = value == null;
						object obj = 0;
						tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)(object)tMPro_SpriteCharacter._scale;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
							obj = 0;
							nint num = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v6 (Il2CppClass<System.Object>)+40]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v1+40]");
							bool flag3 = num2 != 0;
							tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)value;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								return (float)obj2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							float result = default(float);
							return result;
						}
					}
				}
				throw new NullReferenceException();
			}
			set
			{
				TMPro_SpriteCharacter tMPro_SpriteCharacter = _spriteCharacter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object value2 = default(object);
				tMPro_SpriteCharacter._scale.SetValue(tMPro_SpriteCharacter._source, value2);
			}
		}

		public string name
		{
			get
			{
				//IL_00b0: Expected O, but got I
				TMPro_SpriteCharacter tMPro_SpriteCharacter = _spriteCharacter;
				if (_spriteCharacter != null)
				{
					bool flag = (object)tMPro_SpriteCharacter._name == null;
					TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)(object)tMPro_SpriteCharacter._name;
					if (!flag)
					{
						object value = tMPro_SpriteCharacter._name.GetValue(tMPro_SpriteCharacter._source);
						bool flag2 = value != null;
						string text = (string)value;
						if (flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
							tMPro_SpriteCharacter = (TMPro_SpriteCharacter)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
							bool flag3 = value != null;
							text = null;
							if (!flag3)
							{
								text = (string)value;
							}
							bool flag4 = text == null;
							tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)value;
							if (flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
								string result = default(string);
								return result;
							}
						}
						return text;
					}
				}
				throw new NullReferenceException();
			}
			set
			{
				TMPro_SpriteCharacter tMPro_SpriteCharacter = _spriteCharacter;
				tMPro_SpriteCharacter._name.SetValue(tMPro_SpriteCharacter._source, value);
			}
		}

		public uint unicode
		{
			get
			{
				//IL_008b: Expected O, but got I4
				//IL_00b6: Expected O, but got I
				//IL_00be: Expected I, but got O
				//IL_0104: Expected I4, but got O
				TMPro_SpriteCharacter tMPro_SpriteCharacter = _spriteCharacter;
				if (_spriteCharacter != null)
				{
					bool flag = (object)tMPro_SpriteCharacter._unicode == null;
					TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)(object)tMPro_SpriteCharacter._unicode;
					if (!flag)
					{
						object value = tMPro_SpriteCharacter._unicode.GetValue(tMPro_SpriteCharacter._source);
						bool flag2 = value == null;
						object obj = 0;
						tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)(object)tMPro_SpriteCharacter._unicode;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B30]");
							obj = 0;
							nint num = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v6 (Il2CppClass<System.Object>)+40]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v1+40]");
							bool flag3 = num2 != 0;
							tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)value;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								return (uint)(int)obj2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							uint result = default(uint);
							return result;
						}
					}
				}
				throw new NullReferenceException();
			}
			set
			{
				TMPro_SpriteCharacter tMPro_SpriteCharacter = _spriteCharacter;
				if (value == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				}
				object value2 = default(object);
				tMPro_SpriteCharacter._unicode.SetValue(tMPro_SpriteCharacter._source, value2);
			}
		}

		public int hashCode
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Sprite sprite
		{
			get
			{
				//IL_0033: Expected I, but got O
				//IL_0045: Expected O, but got I4
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				if (_spriteGlyph != null)
				{
					TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_ = (TMProSprite_AssetV1_1_0)(object)tMPro_SpriteGlyph._sprite;
					if ((object)tMPro_SpriteGlyph._sprite != null)
					{
						nint num = (nint)this;
						TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_2 = (TMProSprite_AssetV1_1_0)((TMProSprite_AssetV1_1_0)(object)tMPro_SpriteGlyph._sprite).hashCode;
						bool flag = tMProSprite_AssetV1_1_2 != null;
						Sprite sprite = (Sprite)(object)tMProSprite_AssetV1_1_2;
						if (flag)
						{
							bool flag2 = (object)tMProSprite_AssetV1_1_2.GetType() != typeof(Sprite);
							sprite = null;
							if (!flag2)
							{
								sprite = (Sprite)(object)tMProSprite_AssetV1_1_2;
							}
							bool flag3 = (object)sprite == null;
							tMProSprite_AssetV1_1_ = tMProSprite_AssetV1_1_2;
							if (flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
								Sprite result = default(Sprite);
								return result;
							}
						}
						return sprite;
					}
				}
				throw new NullReferenceException();
			}
			set
			{
				TMPro_SpriteGlyph tMPro_SpriteGlyph = _spriteGlyph;
				tMPro_SpriteGlyph._sprite.SetValue(tMPro_SpriteGlyph._source, value);
			}
		}

		public TMProSprite_AssetV1_1_0()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			TMPro_SpriteGlyph tMPro_SpriteGlyph = new TMPro_SpriteGlyph();
			_spriteGlyph = tMPro_SpriteGlyph;
			TMPro_SpriteCharacter tMPro_SpriteCharacter = new TMPro_SpriteCharacter();
			_spriteCharacter = tMPro_SpriteCharacter;
			TMPro_SpriteGlyph tMPro_SpriteGlyph2 = _spriteGlyph;
			TMPro_SpriteCharacter tMPro_SpriteCharacter2 = _spriteCharacter;
			tMPro_SpriteCharacter2._glyph.SetValue(tMPro_SpriteCharacter2._source, tMPro_SpriteGlyph2._source);
		}

		public unsafe static bool CheckVersionSupported()
		{
			//IL_006e: Expected I, but got O
			//IL_00ad: Expected I, but got O
			nint num = (nint)typeof(TMProSprite_AssetV1_1_0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rcx_v2 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSprite_AssetV1_1_0>)+B8]");
			nint num2 = 0;
			if ((object)s_isVersionSupported == null)
			{
				TMPro_SpriteCharacter tMPro_SpriteCharacter = new TMPro_SpriteCharacter();
				TMPro_SpriteGlyph tMPro_SpriteGlyph = new TMPro_SpriteGlyph();
				TMPro_SpriteAsset tMPro_SpriteAsset = new TMPro_SpriteAsset();
				bool? flag = true;
				s_isVersionSupported = flag;
				nint num3 = (nint)typeof(TMProSprite_AssetV1_1_0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v12 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+TMProSprite_AssetV1_1_0>)+B8]");
				return ((bool?*)null)->Value;
			}
			return ((bool?*)num2)->Value;
		}
	}

	private enum DisplayType
	{
		Glyph,
		Text,
		GlyphOrText
	}

	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public Material sourceMaterial;

		public UnityUITextMeshProGlyphHelper _003C_003E4__this;

		internal unsafe void _003Cset_baseSpriteMaterial_003Eb__0(Asset asset)
		{
			//IL_00e4: Expected O, but got Ref
			CopyMaterialProperties(sourceMaterial, asset._material);
			UnityUITextMeshProGlyphHelper unityUITextMeshProGlyphHelper = _003C_003E4__this;
			if (unityUITextMeshProGlyphHelper._overrideSpriteMaterialProperties)
			{
				bool flag = asset._material == null;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
					if ((nint)0 == (flag ? 1 : 0))
					{
						_ = 1;
					}
					int nameID = Shader.PropertyToID("_Color");
					if (asset._material.HasProperty(nameID))
					{
						SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
						asset._material.color = (Color)(&spriteMaterialProperties);
					}
				}
			}
			TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
		}
	}

	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public Material sourceMaterial;

		internal void _003Cset_overrideSpriteMaterialProperties_003Eb__1(Asset asset)
		{
			CopyMaterialProperties(sourceMaterial, asset._material);
			TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
		}
	}

	private string _text;

	private ControllerElementGlyphSelectorOptionsSOBase _options;

	private TMProSpriteOptions _spriteOptions;

	private Material _baseSpriteMaterial;

	private bool _overrideSpriteMaterialProperties;

	private SpriteMaterialProperties _spriteMaterialProperties;

	[NonSerialized]
	private TextMeshProUGUI _tmProText;

	[NonSerialized]
	private string _textPrev;

	[NonSerialized]
	private readonly StringBuilder _processTagSb;

	[NonSerialized]
	private readonly StringBuilder _tempSb;

	[NonSerialized]
	private readonly StringBuilder _tempSb2;

	[NonSerialized]
	private Asset _primaryAsset;

	[NonSerialized]
	private readonly List<Asset> _assignedAssets;

	[NonSerialized]
	private readonly List<Asset> _assetsPool;

	[NonSerialized]
	private readonly List<ActionElementMap> _tempAems;

	[NonSerialized]
	private readonly List<Sprite> _tempGlyphs;

	[NonSerialized]
	private readonly List<Asset> _dirtyAssets;

	[NonSerialized]
	private readonly List<string> _tempKeys;

	[NonSerialized]
	private readonly List<GlyphOrText> _glyphsOrTextTemp;

	[NonSerialized]
	private readonly List<Asset> _currentlyUsedAssets;

	[NonSerialized]
	private readonly List<Tag> _currentTags;

	[NonSerialized]
	private Dictionary<string, string> _tempStringDictionary;

	[NonSerialized]
	private bool _initialized;

	[NonSerialized]
	private bool _rebuildRequired;

	[NonSerialized]
	private Texture2D _stubTexture;

	private Tag.Pool<ControllerElementTag> __controllerElementTagPool;

	private Tag.Pool<ActionTag> __actionTagPool;

	private Tag.Pool<PlayerTag> __playerTagPool;

	[NonSerialized]
	private Dictionary<string, ParseTagAttributesHandler> __tagHandlers;

	private static string[] __s_displayTypeNames;

	private static DisplayType[] __s_displayTypeValues;

	private static string[] __s_axisRangeNames;

	private static AxisRange[] __s_axisRangeValues;

	private Tag.Pool<ControllerElementTag> controllerElementTagPool
	{
		get
		{
			if (__controllerElementTagPool != null)
			{
				return __controllerElementTagPool;
			}
			return __controllerElementTagPool = new Tag.Pool<ControllerElementTag>();
		}
	}

	private Tag.Pool<ActionTag> actionTagPool
	{
		get
		{
			if (__actionTagPool != null)
			{
				return __actionTagPool;
			}
			return __actionTagPool = new Tag.Pool<ActionTag>();
		}
	}

	private Tag.Pool<PlayerTag> playerTagPool
	{
		get
		{
			if (__playerTagPool != null)
			{
				return __playerTagPool;
			}
			return __playerTagPool = new Tag.Pool<PlayerTag>();
		}
	}

	private unsafe Dictionary<string, ParseTagAttributesHandler> tagHandlers
	{
		get
		{
			//IL_0066: Expected I, but got O
			//IL_0113: Expected I, but got O
			//IL_035a: Expected I, but got I8
			//IL_00fc: Expected I, but got I8
			//IL_00c2: Expected I, but got I8
			//IL_0182: Expected I, but got O
			//IL_018e: Expected O, but got I
			//IL_0236: Expected I, but got O
			//IL_0396: Expected I, but got I8
			//IL_021f: Expected I, but got I8
			//IL_0255: Expected I, but got O
			//IL_0261: Expected O, but got I
			//IL_01e5: Expected I, but got I8
			//IL_02cf: Expected I, but got O
			//IL_02a2: Expected I, but got I8
			//IL_0405: Expected I, but got I8
			//IL_0309: Expected I, but got I8
			if (__tagHandlers != null)
			{
				return __tagHandlers;
			}
			Dictionary<string, ParseTagAttributesHandler> dictionary = new Dictionary<string, ParseTagAttributesHandler>();
			ParseTagAttributesHandler parseTagAttributesHandler = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v1 (Il2CppMethodInfo)+8]");
			((Delegate)parseTagAttributesHandler).method_ptr = (IntPtr)0;
			((Delegate)parseTagAttributesHandler).method = (nint)__ldftn(UnityUITextMeshProGlyphHelper.ProcessTag_ControllerElement);
			((Delegate)parseTagAttributesHandler).m_target = this;
			((Delegate)parseTagAttributesHandler).method_code = (IntPtr)parseTagAttributesHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B50");
			object obj = default(object);
			nint invoke_impl;
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v1 (Il2CppMethodInfo)+52]");
				if ((nint)0 != 4)
				{
					goto IL_0101;
				}
				invoke_impl = unchecked((nint)6442466912L);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v1 (Il2CppMethodInfo)+52]");
				if ((nint)0 != 3)
				{
					goto IL_0101;
				}
				invoke_impl = unchecked((nint)6442466832L);
			}
			goto IL_033b;
			IL_033b:
			((Delegate)parseTagAttributesHandler).invoke_impl = invoke_impl;
			((Delegate)parseTagAttributesHandler).extra_arg = unchecked((nint)6442466688L);
			ParseTagAttributesHandler parseTagAttributesHandler2;
			nint invoke_impl2;
			if (dictionary != null)
			{
				((Dictionary<object, object>)(object)dictionary).Add((object)"rewiredelement", (object)parseTagAttributesHandler);
				parseTagAttributesHandler2 = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rbx_v2 (Il2CppMethodInfo)+8]");
				((Delegate)parseTagAttributesHandler2).method_ptr = (IntPtr)0;
				((Delegate)parseTagAttributesHandler2).method = (nint)__ldftn(UnityUITextMeshProGlyphHelper.ProcessTag_Action);
				((Delegate)parseTagAttributesHandler2).m_target = this;
				((Delegate)parseTagAttributesHandler2).method_code = (IntPtr)parseTagAttributesHandler2;
				((Dictionary<string, ParseTagAttributesHandler>)0).Add((string)(object)this, parseTagAttributesHandler);
				object obj2 = default(object);
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rbx_v2 (Il2CppMethodInfo)+52]");
					if ((nint)0 != 4)
					{
						goto IL_0224;
					}
					invoke_impl2 = unchecked((nint)6442466912L);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rbx_v2 (Il2CppMethodInfo)+52]");
					if ((nint)0 != 3)
					{
						goto IL_0224;
					}
					invoke_impl2 = unchecked((nint)6442466832L);
				}
				goto IL_0377;
			}
			return (Dictionary<string, ParseTagAttributesHandler>)(object)new NullReferenceException();
			IL_03e6:
			ParseTagAttributesHandler parseTagAttributesHandler3;
			nint invoke_impl3;
			((Delegate)parseTagAttributesHandler3).invoke_impl = invoke_impl3;
			((Delegate)parseTagAttributesHandler3).extra_arg = unchecked((nint)6442466688L);
			((Dictionary<object, object>)(object)dictionary).Add((object)"rewiredplayer", (object)parseTagAttributesHandler3);
			__tagHandlers = dictionary;
			return dictionary;
			IL_0377:
			((Delegate)parseTagAttributesHandler2).invoke_impl = invoke_impl2;
			((Delegate)parseTagAttributesHandler2).extra_arg = unchecked((nint)6442466688L);
			((Dictionary<object, object>)(object)dictionary).Add((object)"rewiredaction", (object)parseTagAttributesHandler2);
			parseTagAttributesHandler3 = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rbx_v3 (Il2CppMethodInfo)+8]");
			((Delegate)parseTagAttributesHandler3).method_ptr = (IntPtr)0;
			((Delegate)parseTagAttributesHandler3).method = (nint)__ldftn(UnityUITextMeshProGlyphHelper.ProcessTag_Player);
			((Delegate)parseTagAttributesHandler3).m_target = this;
			((Delegate)parseTagAttributesHandler3).method_code = (IntPtr)parseTagAttributesHandler3;
			((Dictionary<string, ParseTagAttributesHandler>)0).Add((string)(object)this, parseTagAttributesHandler2);
			object obj3 = default(object);
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rbx_v3 (Il2CppMethodInfo)+52]");
				bool flag = (nint)0 == 4;
				invoke_impl3 = unchecked((nint)6442466912L);
				if (!flag)
				{
					goto IL_02b0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rbx_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 != 3)
				{
					goto IL_02b0;
				}
				invoke_impl3 = unchecked((nint)6442466832L);
			}
			goto IL_03e6;
			IL_0224:
			((Delegate)parseTagAttributesHandler2).method_code = (IntPtr)((Delegate)parseTagAttributesHandler2).m_target;
			invoke_impl2 = ((Delegate)parseTagAttributesHandler2).method_ptr;
			goto IL_0377;
			IL_0101:
			((Delegate)parseTagAttributesHandler).method_code = (IntPtr)((Delegate)parseTagAttributesHandler).m_target;
			invoke_impl = ((Delegate)parseTagAttributesHandler).method_ptr;
			goto IL_033b;
			IL_02b0:
			invoke_impl3 = ((Delegate)parseTagAttributesHandler3).method_ptr;
			((Delegate)parseTagAttributesHandler3).method_code = (IntPtr)((Delegate)parseTagAttributesHandler3).m_target;
			goto IL_03e6;
		}
	}

	public virtual string text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			_rebuildRequired = true;
		}
	}

	public virtual ControllerElementGlyphSelectorOptionsSOBase options
	{
		get
		{
			return _options;
		}
		set
		{
			_options = value;
			_rebuildRequired = true;
		}
	}

	public unsafe virtual TMProSpriteOptions spriteOptions
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected O, but got I
			//IL_001f: Expected native int or pointer, but got O
			TMProSpriteOptions tMProSpriteOptions = default(TMProSpriteOptions);
			((TMProSpriteOptions*)(nint)tMProSpriteOptions)->_scale = (float)_spriteOptions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+3C]");
			((TMProSpriteOptions*)(nint)tMProSpriteOptions)->_extraOffset = (Vector2)0;
			return tMProSpriteOptions;
		}
		set
		{
			//IL_02f6: Expected O, but got F4
			//IL_0070: Expected O, but got I4
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Expected O, but got Unknown
			List<Asset> assignedAssets = _assignedAssets;
			_spriteOptions = (TMProSpriteOptions)value._scale;
			_ = value._extraOffset;
			bool flag = assignedAssets._size <= 0;
			int num = 0;
			if (flag)
			{
				return;
			}
			object obj = default(object);
			TMProSpriteOptions tMProSpriteOptions2 = default(TMProSpriteOptions);
			float num3 = default(float);
			float num5 = default(float);
			UnityEngine.Object obj4 = default(UnityEngine.Object);
			object obj5 = default(object);
			UnityEngine.Object obj6 = default(UnityEngine.Object);
			Sprite sprite = default(Sprite);
			UnityEngine.Object obj7 = default(UnityEngine.Object);
			bool flag5;
			do
			{
				Asset asset = _assignedAssets.get_Item(num);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				bool flag2 = (nint)obj <= 0;
				object obj2 = 0;
				TMProSpriteOptions tMProSpriteOptions = tMProSpriteOptions2;
				float num2 = num3;
				float num4 = num5;
				UnityEngine.Object obj3 = obj4;
				if (!flag2)
				{
					bool flag4;
					do
					{
						Asset asset2 = _assignedAssets.get_Item(num);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003080");
						if (obj5 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							bool flag3 = obj6 != null;
							obj4 = obj6;
							if (flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								Rect rect = sprite.rect;
								float num6 = rect.m_Width;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+34]");
								float num7 = num6 * 0f;
								float num8 = num7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+3C]");
								float num9 = num8 + 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
								float num10 = rect.m_Height;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+38]");
								float num11 = num10 * 0f;
								float num12 = num11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+40]");
								num3 = num12 + 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
								float num13 = rect.m_Width;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+44]");
								float num14 = num13 * 0f;
								float num15 = num14;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+48]");
								num5 = num15 + 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
								tMProSpriteOptions2 = _spriteOptions;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
								obj4 = obj6;
							}
						}
						obj2++;
						flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
						tMProSpriteOptions = tMProSpriteOptions2;
						num2 = num3;
						num4 = num5;
						obj3 = obj4;
					}
					while (flag4);
				}
				Asset asset3 = _assignedAssets.get_Item(num);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				TMPro_EventManager.ON_SPRITE_ASSET_PROPERTY_CHANGED(isChanged: true, obj7);
				num++;
				flag5 = num < assignedAssets._size;
				tMProSpriteOptions2 = tMProSpriteOptions;
				num3 = num2;
				num5 = num4;
				obj4 = obj3;
			}
			while (flag5);
		}
	}

	public unsafe virtual Material baseSpriteMaterial
	{
		get
		{
			return _baseSpriteMaterial;
		}
		set
		{
			_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass48_0();
			CS_0024_003C_003E8__locals4._003C_003E4__this = this;
			_baseSpriteMaterial = value;
			Material material;
			if (_baseSpriteMaterial != null)
			{
				material = _baseSpriteMaterial;
			}
			else
			{
				Asset primaryAsset = _primaryAsset;
				material = primaryAsset._material;
			}
			CS_0024_003C_003E8__locals4.sourceMaterial = material;
			Action<Asset> callback = delegate(Asset asset)
			{
				//IL_00e4: Expected O, but got Ref
				CopyMaterialProperties(CS_0024_003C_003E8__locals4.sourceMaterial, asset._material);
				UnityUITextMeshProGlyphHelper unityUITextMeshProGlyphHelper = CS_0024_003C_003E8__locals4._003C_003E4__this;
				if (unityUITextMeshProGlyphHelper._overrideSpriteMaterialProperties)
				{
					bool flag = asset._material == null;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
						if ((nint)0 == (flag ? 1 : 0))
						{
							_ = 1;
						}
						int nameID = Shader.PropertyToID("_Color");
						if (asset._material.HasProperty(nameID))
						{
							SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
							asset._material.color = (Color)(&spriteMaterialProperties);
						}
					}
				}
				TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
			};
			ForEachAsset(callback);
		}
	}

	public unsafe virtual bool overrideSpriteMaterialProperties
	{
		get
		{
			return _overrideSpriteMaterialProperties;
		}
		set
		{
			_overrideSpriteMaterialProperties = value;
			if (!value)
			{
				_003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass51_0();
				Material material;
				if (_baseSpriteMaterial != null)
				{
					material = _baseSpriteMaterial;
				}
				else
				{
					Asset primaryAsset = _primaryAsset;
					material = primaryAsset._material;
				}
				CS_0024_003C_003E8__locals2.sourceMaterial = material;
				Action<Asset> callback = delegate(Asset asset)
				{
					CopyMaterialProperties(CS_0024_003C_003E8__locals2.sourceMaterial, asset._material);
					TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
				};
				ForEachAsset(callback);
				return;
			}
			Action<Asset> callback2 = delegate(Asset asset)
			{
				//IL_009f: Expected O, but got Ref
				bool flag = asset._material == null;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
					if ((nint)0 == (flag ? 1 : 0))
					{
						_ = 1;
					}
					int nameID = Shader.PropertyToID("_Color");
					if (asset._material.HasProperty(nameID))
					{
						SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
						asset._material.color = (Color)(&spriteMaterialProperties);
					}
				}
				TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
			};
			ForEachAsset(callback2);
		}
	}

	public unsafe virtual SpriteMaterialProperties spriteMaterialProperties
	{
		get
		{
			//IL_000a: Expected native int or pointer, but got O
			SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
			((SpriteMaterialProperties*)(nint)spriteMaterialProperties)->_color = (Color)_spriteMaterialProperties;
			return spriteMaterialProperties;
		}
		set
		{
			bool flag = !_overrideSpriteMaterialProperties;
			_spriteMaterialProperties = (SpriteMaterialProperties)value._color;
			if (flag)
			{
				return;
			}
			Action<Asset> callback = delegate(Asset asset)
			{
				//IL_009f: Expected O, but got Ref
				bool flag2 = asset._material == null;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
					if ((nint)0 == (flag2 ? 1 : 0))
					{
						_ = 1;
					}
					int nameID = Shader.PropertyToID("_Color");
					if (asset._material.HasProperty(nameID))
					{
						SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
						asset._material.color = (Color)(&spriteMaterialProperties);
					}
				}
				TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
			};
			ForEachAsset(callback);
		}
	}

	private static int shaderPropertyId_color
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return Shader.PropertyToID("_Color");
		}
	}

	private static string[] s_displayTypeNames
	{
		get
		{
			if (__s_displayTypeNames != null)
			{
				return __s_displayTypeNames;
			}
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DisplayType));
			return __s_displayTypeNames = Enum.GetNames(typeFromHandle);
		}
	}

	private static DisplayType[] s_displayTypeValues
	{
		get
		{
			if (__s_displayTypeValues != null)
			{
				return __s_displayTypeValues;
			}
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DisplayType));
			Array values = Enum.GetValues(typeFromHandle);
			DisplayType[] array;
			if (values == null)
			{
				array = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				DisplayType[] array2 = default(DisplayType[]);
				bool flag = array2 == null;
				array = array2;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					DisplayType[] result = default(DisplayType[]);
					return result;
				}
			}
			__s_displayTypeValues = array;
			return array;
		}
	}

	private static string[] s_axisRangeNames
	{
		get
		{
			if (__s_axisRangeNames != null)
			{
				return __s_axisRangeNames;
			}
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(AxisRange));
			return __s_axisRangeNames = Enum.GetNames(typeFromHandle);
		}
	}

	private static AxisRange[] s_axisRangeValues
	{
		get
		{
			if (__s_axisRangeValues != null)
			{
				return __s_axisRangeValues;
			}
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(AxisRange));
			Array values = Enum.GetValues(typeFromHandle);
			AxisRange[] array;
			if (values == null)
			{
				array = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				AxisRange[] array2 = default(AxisRange[]);
				bool flag = array2 == null;
				array = array2;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					AxisRange[] result = default(AxisRange[]);
					return result;
				}
			}
			__s_axisRangeValues = array;
			return array;
		}
	}

	protected virtual void OnEnable()
	{
		if (!_initialized)
		{
			TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
			_tmProText = component;
			Texture2D stubTexture = new Texture2D(1, 1);
			_stubTexture = stubTexture;
			if (_primaryAsset == null)
			{
				Asset primaryAsset = new Asset(null);
				_primaryAsset = primaryAsset;
				Asset primaryAsset2 = _primaryAsset;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				TMP_SpriteAsset spriteAsset = default(TMP_SpriteAsset);
				_tmProText.spriteAsset = spriteAsset;
			}
			_initialized = true;
		}
	}

	protected virtual void Start()
	{
		MainUpdate();
	}

	protected virtual void Update()
	{
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			MainUpdate();
		}
	}

	protected virtual void OnDestroy()
	{
		//IL_01e7: Expected I, but got O
		//IL_031c: Expected I, but got O
		//IL_03db: Expected I, but got O
		if (_primaryAsset != null)
		{
			if (_tmProText != null)
			{
				TextMeshProUGUI tmProText = _tmProText;
				Asset primaryAsset = _primaryAsset;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				UnityEngine.Object obj = default(UnityEngine.Object);
				if (((TMP_Text)tmProText).m_spriteAsset == obj)
				{
					_tmProText.spriteAsset = null;
				}
			}
			_primaryAsset.Destroy();
			_primaryAsset = null;
		}
		List<Asset> assignedAssets = _assignedAssets;
		int num = 0;
		int num2 = 0;
		bool flag;
		do
		{
			List<Asset> assignedAssets2 = _assignedAssets;
			if (num < assignedAssets._size)
			{
				Asset asset = assignedAssets2.get_Item(num2);
				if (asset != null)
				{
					Asset asset2 = _assignedAssets.get_Item(num2);
					asset2.Destroy();
				}
				assignedAssets = _assignedAssets;
				num2++;
				flag = _assignedAssets != null;
				num = num2;
				continue;
			}
			int version = assignedAssets2._version + 1;
			assignedAssets2._version = version;
			assignedAssets2._size = 0;
			if (assignedAssets2._size > 0)
			{
				Array.Clear(assignedAssets2._items, 0, assignedAssets2._size);
				nint num3 = unchecked((nint)null);
			}
			List<Asset> assetsPool = _assetsPool;
			int num4 = 0;
			int num5 = 0;
			bool flag2;
			do
			{
				List<Asset> assetsPool2 = _assetsPool;
				if (num4 < assetsPool._size)
				{
					Asset asset3 = assetsPool2.get_Item(num5);
					if (asset3 != null)
					{
						Asset asset4 = _assetsPool.get_Item(num5);
						asset4.Destroy();
					}
					assetsPool = _assetsPool;
					num5++;
					flag2 = _assetsPool != null;
					num4 = num5;
					continue;
				}
				int version2 = assetsPool2._version + 1;
				assetsPool2._version = version2;
				assetsPool2._size = 0;
				if (assetsPool2._size > 0)
				{
					Array.Clear(assetsPool2._items, 0, assetsPool2._size);
					nint num3 = unchecked((nint)null);
				}
				if (_stubTexture != null)
				{
					UnityEngine.Object.Destroy(_stubTexture);
					_stubTexture = null;
				}
				List<Tag> currentTags = _currentTags;
				int num6 = 0;
				for (int num7 = 0; num7 < currentTags._size; num7 = num6)
				{
					Tag tag = _currentTags.get_Item(num6);
					if (tag._pool != null)
					{
						Tag.Pool pool = tag._pool;
						nint num3 = (nint)pool;
						bool flag3 = pool.Return(tag);
					}
					currentTags = _currentTags;
					num6++;
				}
				return;
			}
			while (flag2);
			break;
		}
		while (flag);
		throw new NullReferenceException();
	}

	public virtual void ForceUpdate()
	{
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			_rebuildRequired = true;
			Update();
		}
	}

	protected virtual ControllerElementGlyphSelectorOptions GetOptionsOrDefault()
	{
		if (_options != null)
		{
			if ((object)_options != null)
			{
				ControllerElementGlyphSelectorOptions controllerElementGlyphSelectorOptions = _options.options;
				if (controllerElementGlyphSelectorOptions != null)
				{
					goto IL_00fb;
				}
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ControllerElementGlyphSelectorOptions));
				if ((object)typeFromHandle != null)
				{
					string text = typeFromHandle.Name;
					string message = "Rewired: Options missing on " + text + ". Global default options will be used instead.";
					Debug.LogError(message);
					goto IL_00e8;
				}
			}
			goto IL_0157;
		}
		goto IL_00fb;
		IL_0157:
		return (ControllerElementGlyphSelectorOptions)(object)new NullReferenceException();
		IL_00e8:
		return ControllerElementGlyphSelectorOptions.defaultOptions;
		IL_00fb:
		if (!(_options != null))
		{
			goto IL_00e8;
		}
		if ((object)_options != null)
		{
			return _options.options;
		}
		goto IL_0157;
	}

	private bool Initialize()
	{
		//IL_010d: Expected I4, but got O
		if (!_initialized)
		{
			TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
			_tmProText = component;
			Texture2D stubTexture = new Texture2D(1, 1);
			_stubTexture = stubTexture;
			if (_primaryAsset == null)
			{
				Asset primaryAsset = new Asset(null);
				_primaryAsset = primaryAsset;
				Asset primaryAsset2 = _primaryAsset;
				if (_primaryAsset != null && primaryAsset2._spriteAsset != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					if ((object)_tmProText != null)
					{
						TMP_SpriteAsset spriteAsset = default(TMP_SpriteAsset);
						_tmProText.spriteAsset = spriteAsset;
						goto IL_00e8;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_00e8;
		}
		return true;
		IL_00e8:
		_initialized = true;
		return true;
	}

	private unsafe void MainUpdate()
	{
		//IL_0025: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_04dc: Expected I4, but got O
		//IL_048c: Expected I4, but got O
		//IL_04fa: Expected I, but got O
		//IL_052f: Expected I4, but got O
		//IL_09eb: Expected O, but got I4
		//IL_0522: Expected I4, but got O
		//IL_095c: Expected I, but got O
		//IL_00df: Expected O, but got I4
		//IL_02e6: Expected I4, but got O
		//IL_0923: Expected I, but got O
		//IL_0a95: Expected I, but got O
		//IL_0232: Expected O, but got I
		//IL_0803: Expected O, but got I
		//IL_0243: Expected I4, but got O
		//IL_08a3: Expected I4, but got O
		//IL_09a5: Expected I, but got O
		//IL_035d: Expected O, but got I
		//IL_05f7: Expected I, but got O
		//IL_0262: Expected I4, but got O
		//IL_0274: Expected O, but got I4
		//IL_0183: Expected O, but got I
		//IL_0683: Expected I4, but got O
		//IL_03c9: Expected O, but got I
		//IL_0194: Expected I4, but got O
		//IL_03e7: Expected I, but got O
		//IL_01b3: Expected I4, but got O
		//IL_01c5: Expected O, but got I4
		//IL_07bd: Expected O, but got I
		//IL_07d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Expected O, but got Unknown
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e6: Expected O, but got Unknown
		//IL_040a: Expected I, but got O
		//IL_0413: Expected O, but got I4
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		List<Tag> currentTags = _currentTags;
		bool flag = _currentTags == null;
		IntPtr intPtr = default(IntPtr);
		int num = (int)(nint)intPtr;
		object obj;
		nint num3;
		if (!flag)
		{
			bool flag2 = currentTags._size <= 0;
			obj = 0;
			if (flag2)
			{
				goto IL_0418;
			}
			string result = null;
			string result2 = null;
			Tag tag2 = default(Tag);
			Tag tag = tag2;
			num = (int)(nint)intPtr;
			int num2 = 0;
			object obj2 = 0;
			while (true)
			{
				bool flag3 = _currentTags == null;
				tag2 = tag;
				if (flag3)
				{
					break;
				}
				Tag tag3 = _currentTags.get_Item(num2);
				bool flag4 = tag3 == null;
				tag2 = tag3;
				num = num2;
				num3 = 0;
				if (flag4)
				{
					break;
				}
				bool flag5 = tag3.tagType == Tag.TagType.ControllerElement;
				NotImplementedException ex2;
				nint num5;
				nint num6;
				if (!flag5)
				{
					object obj3 = tag3.tagType - 1;
					if (!flag5)
					{
						bool flag6 = (nint)obj3 != 1;
						num = num2;
						num3 = 0;
						if (!flag6)
						{
							bool flag7 = (object)tag3.GetType() != typeof(PlayerTag);
							Tag tag4 = null;
							if (!flag7)
							{
								tag4 = tag3;
							}
							bool flag8 = tag4 == null;
							tag2 = tag3;
							num = (int)typeof(PlayerTag);
							num3 = 0;
							if (!flag8)
							{
								bool flag9 = TryGetPlayerDisplayName((PlayerTag)tag4, out result2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rsi_v22 (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Tag)+28]");
								bool flag10 = string.Equals((string)0, result2, StringComparison.Ordinal);
								num = (int)result2;
								num3 = 4;
								if (!flag10)
								{
									num = (int)result2;
									num3 = 4;
									obj2 = 1;
								}
								goto IL_08b7;
							}
							Tag tag5 = ((List<Tag>)(object)tag2).get_Item(num);
						}
						Tag tag6 = ((List<Tag>)(object)typeof(NotImplementedException)).get_Item(num);
						NotImplementedException ex = new NotImplementedException();
						Tag tag7 = ((List<Tag>)0).get_Item(0);
						throw ex;
					}
					bool flag11 = (object)tag3.GetType() != typeof(ActionTag);
					Tag tag8 = null;
					if (!flag11)
					{
						tag8 = tag3;
					}
					bool flag12 = tag8 == null;
					ex2 = (NotImplementedException)(object)tag3;
					nint num4 = (nint)typeof(ActionTag);
					num3 = 0;
					if (!flag12)
					{
						bool flag13 = TryGetActionDisplayName((ActionTag)tag8, out result);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rsi_v19 (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Tag)+28]");
						bool flag14 = string.Equals((string)0, result, StringComparison.Ordinal);
						num = (int)result;
						num3 = 4;
						if (!flag14)
						{
							num = (int)result;
							num3 = 4;
							obj2 = 1;
						}
						goto IL_08b7;
					}
					num5 = (nint)((List<Tag>)(object)ex2).get_Item((int)num4);
				}
				else
				{
					bool flag15 = (object)tag3.GetType() != typeof(ControllerElementTag);
					Tag tag9 = null;
					if (!flag15)
					{
						tag9 = tag3;
					}
					bool flag16 = tag9 == null;
					ex2 = (NotImplementedException)(object)tag3;
					num6 = (nint)typeof(ControllerElementTag);
					num3 = 0;
					if (flag16)
					{
						goto IL_0a9b;
					}
					List<GlyphOrText> glyphsOrTextTemp = _glyphsOrTextTemp;
					bool flag17 = _glyphsOrTextTemp == null;
					tag2 = tag3;
					num = (int)typeof(ControllerElementTag);
					num3 = 0;
					if (flag17)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v42 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v42 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v42 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+10]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v42 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
						Array.Clear((Array)num7, 0, 0);
					}
					bool flag18 = (object)tag3.GetType() != typeof(ControllerElementTag);
					ControllerElementTag controllerElementTag = null;
					if (!flag18)
					{
						controllerElementTag = (ControllerElementTag)tag3;
					}
					bool flag19 = controllerElementTag == null;
					ex2 = (NotImplementedException)(object)tag3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v42 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
					num3 = 0;
					num5 = (nint)typeof(ControllerElementTag);
					if (!flag19)
					{
						bool flag20 = TryGetControllerElementGlyphsOrText(controllerElementTag, _glyphsOrTextTemp);
						List<GlyphOrText> glyphsOrTextTemp2 = _glyphsOrTextTemp;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rsi_v16 (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Tag)+30]");
						bool flag21 = IsEqual(glyphsOrTextTemp2, (List<GlyphOrText>)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rsi_v16 (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Tag)+30]");
						num = 0;
						num3 = unchecked((nint)null);
						if (!flag21)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rsi_v16 (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Tag)+30]");
							num = 0;
							num3 = unchecked((nint)null);
							obj2 = 1;
						}
						goto IL_08b7;
					}
				}
				Tag tag10 = ((List<Tag>)(object)ex2).get_Item((int)num5);
				num6 = num5;
				goto IL_0a9b;
				IL_0a9b:
				Tag tag11 = ((List<Tag>)(object)ex2).get_Item((int)num6);
				return;
				IL_08b7:
				num2++;
				bool flag22 = num2 < currentTags._size;
				tag2 = tag3;
				obj = obj2;
				tag = tag3;
				if (flag22)
				{
					continue;
				}
				goto IL_0418;
			}
		}
		goto IL_07eb;
		IL_07eb:
		throw new NullReferenceException();
		IL_09b3:
		List<Asset> dirtyAssets = _dirtyAssets;
		if (_dirtyAssets != null)
		{
			if (dirtyAssets._size <= 0)
			{
				return;
			}
			int num8 = 0;
			while (_dirtyAssets != null)
			{
				Asset asset = _dirtyAssets.get_Item(num8);
				bool flag23 = asset == null;
				num = num8;
				num3 = 0;
				if (flag23)
				{
					break;
				}
				ITMProSpriteAsset spriteAsset = asset._spriteAsset;
				bool flag24 = asset._spriteAsset == null;
				Tag tag2 = (Tag)asset._spriteAsset;
				num = num8;
				num3 = 0;
				if (flag24)
				{
					break;
				}
				nint num9 = (nint)spriteAsset;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r10_v9 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSpriteAsset>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_066b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r10_v9 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSpriteAsset>)+B0]");
				num3 = 0;
				Tag tag12 = null;
				while (true)
				{
					object obj4 = (object)tag12 + (object)tag12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ r8_v2 (Il2CppMethodInfo)+v899 @ rcx_v31*8]");
					if (0 == (nint)typeof(ITMProSpriteAsset))
					{
						break;
					}
					tag12 = (Tag)(tag12 + 1);
					Tag obj5 = tag12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r10_v9 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSpriteAsset>)+12E]");
					if ((nint)obj5 < 0)
					{
						continue;
					}
					goto IL_066b;
				}
				object obj6 = (object)tag12 + (object)tag12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ r8_v2 (Il2CppMethodInfo)+8+v954 @ rcx_v33*8]");
				object obj7 = (nint)0 + (nint)8;
				object obj8 = obj7 << 4;
				object obj9 = obj8 + 312;
				Tag tag13 = (Tag)(obj9 + num9);
				goto IL_0695;
				IL_066b:
				tag13 = ((List<Tag>)asset._spriteAsset).get_Item((int)typeof(ITMProSpriteAsset));
				num3 = 8;
				goto IL_0695;
				IL_0695:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v951 @ rax_v26 (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Tag)+8]");
				num = 0;
				asset._spriteAsset.UpdateLookupTables();
				num8++;
				bool flag25 = num8 < dirtyAssets._size;
				tag2 = (Tag)asset._spriteAsset;
				if (!flag25)
				{
					List<Asset> dirtyAssets2 = _dirtyAssets;
					bool flag26 = _dirtyAssets == null;
					tag2 = (Tag)asset._spriteAsset;
					if (flag26)
					{
						break;
					}
					int version = dirtyAssets2._version + 1;
					dirtyAssets2._version = version;
					dirtyAssets2._size = 0;
					if (dirtyAssets2._size > 0)
					{
						Array.Clear(dirtyAssets2._items, 0, dirtyAssets2._size);
					}
					return;
				}
			}
		}
		goto IL_07eb;
		IL_0418:
		if (!string.Equals(_text, _textPrev, StringComparison.Ordinal))
		{
			_textPrev = _text;
		}
		else if (obj == null)
		{
			bool flag27 = !_rebuildRequired;
			num = (int)_textPrev;
			num3 = 4;
			if (flag27)
			{
				goto IL_09b3;
			}
		}
		bool flag28 = ParseText(_textPrev, out var newText);
		TextMeshProUGUI tmProText = _tmProText;
		bool flag29 = (object)_tmProText == null;
		num = (int)_textPrev;
		num3 = (nint)(&newText);
		if (flag29)
		{
			goto IL_07eb;
		}
		nint num10 = (nint)tmProText;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rax_v42 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
		num3 = 0;
		num = (flag28 ? ((int)newText) : ((int)_text));
		_tmProText.text = (string)num;
		goto IL_09b3;
	}

	private unsafe bool ParseText(string text, out string newText)
	{
		//IL_0233: Expected I4, but got O
		//IL_009a: Expected I, but got O
		ref string reference = ref *(string*)null;
		List<Tag> currentTags = _currentTags;
		if (_currentTags != null)
		{
			bool flag = currentTags._size <= 0;
			int num = 0;
			if (flag)
			{
				goto IL_00a9;
			}
			while (true)
			{
				Tag tag = _currentTags.get_Item(num);
				if (tag != null)
				{
					Tag tag2 = _currentTags.get_Item(num);
					if (tag2 == null)
					{
						break;
					}
					if (tag2._pool != null)
					{
						Tag.Pool pool = tag2._pool;
						nint num2 = (nint)pool;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v139 @ r9_v3 (Il2CppMethodInfo)+178] (should have been resolved before IL gen)");
					}
				}
				num++;
				if (num < currentTags._size)
				{
					continue;
				}
				goto IL_00a9;
			}
		}
		goto IL_0225;
		IL_0225:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_00a9:
		int version = currentTags._version + 1;
		currentTags._version = version;
		currentTags._size = 0;
		if (currentTags._size > 0)
		{
			Array.Clear(currentTags._items, 0, currentTags._size);
		}
		List<Asset> currentlyUsedAssets = _currentlyUsedAssets;
		if (_currentlyUsedAssets != null)
		{
			int version2 = currentlyUsedAssets._version + 1;
			currentlyUsedAssets._version = version2;
			currentlyUsedAssets._size = 0;
			if (currentlyUsedAssets._size > 0)
			{
				Array.Clear(currentlyUsedAssets._items, 0, currentlyUsedAssets._size);
			}
			string text2 = default(string);
			bool flag2 = ProcessNextTag(ref text2, _processTagSb);
			bool flag3 = !flag2;
			bool result = false;
			if (!flag3)
			{
				bool flag4;
				do
				{
					reference = ref *(string*)text2;
					flag4 = ProcessNextTag(ref text2, _processTagSb);
					result = true;
				}
				while (flag4);
			}
			RemoveUnusedAssets();
			if (_rebuildRequired)
			{
				_rebuildRequired = false;
			}
			return result;
		}
		goto IL_0225;
	}

	private unsafe bool ProcessNextTag(ref string text, StringBuilder sb)
	{
		//IL_053b: Expected I4, but got I8
		//IL_052e: Expected I4, but got O
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0419: Expected O, but got I4
		//IL_0165: Expected I4, but got O
		//IL_0383: Expected O, but got I4
		//IL_0203: Expected I4, but got O
		int num = -1;
		int num2 = 0;
		object value = null;
		object obj = null;
		object obj3 = default(object);
		string text3 = default(string);
		char c3 = default(char);
		while (true)
		{
			string text2 = text;
			if (text == null)
			{
				break;
			}
			if (num2 < text2._stringLength)
			{
				char c = text.get_Chars(num2);
				bool flag = obj == null;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 == 1)
						{
							int num3 = text.IndexOf('>', num2);
							bool flag2 = num3 < 0;
							int num4 = 0;
							char c2 = '>';
							int num5 = num2;
							if (!flag2)
							{
								bool flag3 = value == null;
								num4 = 0;
								c2 = '>';
								num5 = num2;
								if (!flag3)
								{
									num4 = num3 - num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v55 @ stack_-58_v2 (System.Object)+18] (should have been resolved before IL gen)");
									if (obj3 != null)
									{
										bool flag4 = sb == null;
										c2 = (char)(int)text;
										num5 = num2;
										if (!flag4)
										{
											sb.Length = 0;
											if (num > 0)
											{
												StringBuilder stringBuilder = sb.Append(text, 0, num);
												num4 = num;
											}
											StringBuilder stringBuilder2 = sb.Append(text3);
											string text4 = text;
											bool flag5 = text == null;
											c2 = (char)(int)text3;
											num5 = 0;
											if (!flag5)
											{
												int num6 = num3 + 1;
												if (num6 < text4._stringLength)
												{
													int count = text4._stringLength - num6;
													StringBuilder stringBuilder3 = sb.Append(text, num6, count);
												}
												string text5 = sb.ToString();
												ref string reference = ref *(string*)text5;
												return true;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
									Exception ex = new Exception("Error parsing attributes.");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
									c2 = c3;
									num5 = 0;
									throw ex;
								}
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							Exception ex2 = new Exception("Malformed tag.");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							throw ex2;
						}
					}
					else
					{
						if (IsValidKeyChar(c))
						{
							char value2 = char.ToLowerInvariant(c);
							StringBuilder stringBuilder4 = sb.Append(value2);
							num2++;
							continue;
						}
						if (char.IsWhiteSpace(c))
						{
							int length = sb.Length;
							if (length <= 0)
							{
								goto IL_0553;
							}
							Dictionary<string, ParseTagAttributesHandler> dictionary = tagHandlers;
							object key = sb.ToString();
							if (((Dictionary<object, object>)(object)dictionary).TryGetValue(key, out value))
							{
								sb.Length = 0;
								num2++;
								obj = 2;
								continue;
							}
						}
						num2--;
						obj = null;
					}
				}
				else if (c == '<')
				{
					sb.Length = 0;
					int num7 = num2 + 1;
					num = num2;
					num2 = num7;
					obj = 1;
					continue;
				}
				goto IL_0553;
			}
			return false;
			IL_0553:
			num2++;
		}
		NullReferenceException ex3 = new NullReferenceException();
		return (byte)(int)ex3 != 0;
	}

	private unsafe bool ProcessTag_ControllerElement(string text, int startIndex, int count, out string replacement)
	{
		//IL_02e3: Expected I4, but got O
		//IL_0183: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_0290: Expected O, but got I
		if (__controllerElementTagPool == null)
		{
			Tag.Pool<ControllerElementTag> _controllerElementTagPool = new Tag.Pool<ControllerElementTag>();
			__controllerElementTagPool = _controllerElementTagPool;
		}
		StringBuilder sb = default(StringBuilder);
		Dictionary<string, string> workDictionary = default(Dictionary<string, string>);
		Tag.Pool<ControllerElementTag> pool = default(Tag.Pool<ControllerElementTag>);
		ref ControllerElementTag result = default(ref ControllerElementTag);
		ref string reference = default(ref string);
		if (ControllerElementTag.TryParseString(text, startIndex, count, _tempSb, sb, workDictionary, pool, out result))
		{
			List<object> currentTags = (List<object>)(object)_currentTags;
			if (_currentTags != null)
			{
				int version = currentTags._version + 1;
				currentTags._version = version;
				object[] items = currentTags._items;
				if (currentTags._items != null)
				{
					object obj = default(object);
					if (currentTags._size >= items.Length)
					{
						((List<object>)(object)_currentTags).AddWithResize(obj);
					}
					else
					{
						int size = currentTags._size + 1;
						currentTags._size = size;
						int num = default(int);
						items[num] = obj;
					}
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_8_v2 (System.Object)+30]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_8_v2 (System.Object)+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v11+1C]");
							_ = (nint)0 + (nint)1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v11+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v11+10]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v11+18]");
								Array.Clear((Array)num2, 0, 0);
							}
							if (obj != null)
							{
								if (!TryGetControllerElementGlyphsOrText((ControllerElementTag)obj, ((ControllerElementTag)obj)._glyphsOrText))
								{
									reference = ref *(string*)null;
									return true;
								}
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_8_v2 (System.Object)+30]");
									bool flag = TryCreateTMProString((List<GlyphOrText>)0, out reference);
									return true;
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		reference = ref *(string*)null;
		return false;
	}

	private bool ProcessTag_Action(string text, int startIndex, int count, out string replacement)
	{
		//IL_0215: Expected O, but got I4
		//IL_0236: Expected I4, but got O
		//IL_01fe: Expected O, but got I4
		if (__actionTagPool == null)
		{
			Tag.Pool<ActionTag> _actionTagPool = new Tag.Pool<ActionTag>();
			__actionTagPool = _actionTagPool;
		}
		StringBuilder sb = default(StringBuilder);
		Dictionary<string, string> workDictionary = default(Dictionary<string, string>);
		Tag.Pool<ActionTag> pool = default(Tag.Pool<ActionTag>);
		ref ActionTag result = default(ref ActionTag);
		object obj2;
		if (ActionTag.TryParseString(text, startIndex, count, _tempSb, sb, workDictionary, pool, out result))
		{
			List<object> currentTags = (List<object>)(object)_currentTags;
			if (_currentTags != null)
			{
				int version = currentTags._version + 1;
				currentTags._version = version;
				object[] items = currentTags._items;
				if (currentTags._items != null)
				{
					object obj = default(object);
					if (currentTags._size >= items.Length)
					{
						((List<object>)(object)_currentTags).AddWithResize(obj);
					}
					else
					{
						int size = currentTags._size + 1;
						currentTags._size = size;
						int num = default(int);
						items[num] = obj;
					}
					if (obj != null)
					{
						ReInput.MappingHelper mapping = ReInput.mapping;
						if (mapping == null)
						{
							goto IL_0228;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_8_v2 (System.Object)+20]");
						InputAction action = mapping.GetAction(0);
						if (action != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_8_v2 (System.Object)+24]");
							string displayName = action.GetDisplayName(AxisRange.Full);
							obj2 = displayName;
							return true;
						}
					}
					obj2 = 0;
					return true;
				}
			}
			goto IL_0228;
		}
		obj2 = 0;
		return false;
		IL_0228:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool ProcessTag_Player(string text, int startIndex, int count, out string replacement)
	{
		//IL_01f2: Expected O, but got I4
		//IL_0213: Expected I4, but got O
		//IL_0239: Expected O, but got I4
		if (__playerTagPool == null)
		{
			Tag.Pool<PlayerTag> _playerTagPool = new Tag.Pool<PlayerTag>();
			__playerTagPool = _playerTagPool;
		}
		StringBuilder sb = default(StringBuilder);
		Dictionary<string, string> workDictionary = default(Dictionary<string, string>);
		Tag.Pool<PlayerTag> pool = default(Tag.Pool<PlayerTag>);
		ref PlayerTag result = default(ref PlayerTag);
		object obj2;
		if (PlayerTag.TryParseString(text, startIndex, count, _tempSb, sb, workDictionary, pool, out result))
		{
			List<object> currentTags = (List<object>)(object)_currentTags;
			if (_currentTags != null)
			{
				int version = currentTags._version + 1;
				currentTags._version = version;
				object[] items = currentTags._items;
				if (currentTags._items != null)
				{
					object obj = default(object);
					if (currentTags._size >= items.Length)
					{
						((List<object>)(object)_currentTags).AddWithResize(obj);
					}
					else
					{
						int size = currentTags._size + 1;
						currentTags._size = size;
						int num = default(int);
						items[num] = obj;
					}
					if (obj != null)
					{
						ReInput.PlayerHelper players = ReInput.players;
						if (players == null)
						{
							goto IL_0205;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_8_v2 (System.Object)+20]");
						Player player = players.GetPlayer(0);
						if (player != null)
						{
							string descriptiveName = player.descriptiveName;
							obj2 = descriptiveName;
							return true;
						}
					}
					obj2 = 0;
					return true;
				}
			}
			goto IL_0205;
		}
		obj2 = 0;
		return false;
		IL_0205:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool TryCreateTMProString(List<GlyphOrText> glyphs, out string result)
	{
		//IL_01a8: Expected I4, but got O
		//IL_0070: Expected O, but got I
		//IL_0079: Expected O, but got I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		if (_tempSb != null)
		{
			_tempSb.Length = 0;
			if (glyphs != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [glyphs @ rdx (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [glyphs @ rdx (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
					object obj = -1;
					object obj2 = 0;
					UnityEngine.Object obj3 = default(UnityEngine.Object);
					string text = default(string);
					string value = default(string);
					object obj4;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1811491F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1811491F0");
						if (obj3 != null && !string.IsNullOrEmpty(text))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1811491F0");
							if (TryAssignSprite((Sprite)obj3, text))
							{
								WriteSpriteKey(_tempSb, text);
								goto IL_0130;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1811491F0");
						StringBuilder stringBuilder = _tempSb.Append(value);
						goto IL_0130;
						IL_0130:
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
						{
							StringBuilder stringBuilder2 = _tempSb.Append(" ");
						}
						obj2++;
						obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [glyphs @ rdx (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
					}
					while ((nint)obj4 < 0);
				}
				string text2 = _tempSb.ToString();
				ref string reference = ref *(string*)text2;
				bool flag = string.IsNullOrEmpty(result);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool TryGetControllerElementGlyphsOrText(ControllerElementTag tag, List<GlyphOrText> results)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0dc7: Expected I4, but got O
		//IL_022a: Expected O, but got I
		//IL_0260: Expected O, but got I
		//IL_0277: Expected O, but got I8
		//IL_0291: Expected O, but got I4
		//IL_0401: Expected O, but got I4
		//IL_062e: Expected O, but got I8
		//IL_0648: Expected O, but got I4
		//IL_0e46: Expected O, but got I4
		//IL_08bf: Expected O, but got I
		//IL_066d: Expected O, but got I
		//IL_08db: Expected O, but got Ref
		//IL_06a8: Expected O, but got I
		//IL_03b9: Expected O, but got Ref
		//IL_0a9c: Expected O, but got I8
		//IL_0ab6: Expected O, but got I4
		//IL_0743: Expected O, but got I
		//IL_0f09: Expected O, but got I4
		//IL_0adb: Expected O, but got I
		//IL_07c4: Expected O, but got I
		//IL_0cfd: Expected O, but got I
		//IL_07e4: Expected O, but got I
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Expected O, but got Unknown
		//IL_0782: Expected O, but got Ref
		//IL_0d19: Expected O, but got Ref
		//IL_0b16: Expected O, but got I
		//IL_0828: Expected O, but got I
		//IL_0b9e: Expected O, but got I
		//IL_0c1f: Expected O, but got I
		//IL_0c3f: Expected O, but got I
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c54: Expected O, but got Unknown
		//IL_0bdd: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if (tag != null)
		{
			List<ActionElementMap> tempAems = _tempAems;
			if (_tempAems == null)
			{
				goto IL_0db9;
			}
			int version = tempAems._version + 1;
			tempAems._version = version;
			tempAems._size = 0;
			if (tempAems._size > 0)
			{
				Array.Clear(tempAems._items, 0, tempAems._size);
			}
			ControllerElementGlyphSelectorOptions optionsOrDefault = GetOptionsOrDefault();
			List<ActionElementMap> workingActionElementMaps = default(List<ActionElementMap>);
			ref ActionElementMap aemResult = default(ref ActionElementMap);
			ref ActionElementMap aemResult2 = default(ref ActionElementMap);
			if (GlyphTools.TryGetActionElementMaps(tag.playerId, tag.actionId, tag.actionRange, optionsOrDefault, workingActionElementMaps, out aemResult, out aemResult2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
					if ((nint)0 != 0)
					{
						List<ActionElementMap> tempAems2 = _tempAems;
						_ = 0;
						_ = 0;
						if (_tempAems != null)
						{
							int version2 = tempAems2._version + 1;
							tempAems2._version = version2;
							tempAems2._size = 0;
							if (tempAems2._size > 0)
							{
								Array.Clear(tempAems2._items, 0, tempAems2._size);
							}
							if (_tempAems != null)
							{
								List<ActionElementMap> tempAems3 = _tempAems;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
								tempAems3.Add((ActionElementMap)0);
								if (_tempAems != null)
								{
									List<ActionElementMap> tempAems4 = _tempAems;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
									tempAems4.Add((ActionElementMap)0);
									object obj3 = (long)tag.type & 0xFFFFFFFDL;
									bool flag = obj3 == null;
									object obj4 = !flag;
									if (obj4 == null && ActionElementMap.TryGetCombinedElementIdentifierGlyph(_tempAems, out System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 31)) && ActionElementMap.TryGetCombinedElementIdentifierFinalGlyphKey(_tempAems, out System.Runtime.CompilerServices.Unsafe.As<object, string>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23))))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+17]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1F]");
										int num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1F]");
										if ((nint)0 == 0)
										{
											_ = 0;
										}
										else
										{
											bool flag2 = ((int*)num)->m_value != (nint)typeof(Sprite);
											int num2 = 0;
											if (!flag2)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1F]");
												num2 = 0;
											}
											bool result = default(bool);
											if (((int*)num)->m_value == (nint)typeof(Sprite))
											{
												return result;
											}
										}
									}
									else
									{
										object obj5 = tag.type - 1;
										if ((nint)obj5 > 1 || !ActionElementMap.TryGetCombinedElementIdentifierName(_tempAems, out System.Runtime.CompilerServices.Unsafe.As<object, string>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39))))
										{
											goto IL_046a;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+27]");
										_ = 0;
									}
									if (results != null)
									{
										GlyphOrText item = (GlyphOrText)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
										_ = 0;
										results.Add(item);
										return true;
									}
								}
							}
						}
						goto IL_0db9;
					}
				}
				goto IL_046a;
			}
		}
		return false;
		IL_0db9:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_046a:
		List<Sprite> tempGlyphs = _tempGlyphs;
		int num7;
		if (_tempGlyphs != null)
		{
			int version3 = tempGlyphs._version + 1;
			tempGlyphs._version = version3;
			tempGlyphs._size = 0;
			if (tempGlyphs._size > 0)
			{
				Array.Clear(tempGlyphs._items, 0, tempGlyphs._size);
			}
			List<string> tempKeys = _tempKeys;
			if (_tempKeys != null)
			{
				int version4 = tempKeys._version + 1;
				tempKeys._version = version4;
				tempKeys._size = 0;
				if (tempKeys._size > 0)
				{
					Array.Clear(tempKeys._items, 0, tempKeys._size);
				}
				ICollection<string> tempKeys2 = _tempKeys;
				DisplayType displayType = tag.type;
				ICollection<Sprite> tempGlyphs2 = _tempGlyphs;
				_ = _tempKeys;
				_ = tag.type;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
				if ((nint)0 != 0 && _tempGlyphs != null && results != null)
				{
					object obj6 = (long)tag.type & 0xFFFFFFFDL;
					bool flag3 = obj6 == null;
					object obj7 = !flag3;
					if (obj7 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
						int elementIdentifierGlyphs = ((ActionElementMap)0).GetElementIdentifierGlyphs(_tempGlyphs);
						if (elementIdentifierGlyphs > 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
							int elementIdentifierFinalGlyphKeys = ((ActionElementMap)0).GetElementIdentifierFinalGlyphKeys(_tempKeys);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rsi_v6 (System.Collections.Generic.ICollection`1<System.String>)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r12_v5 (System.Collections.Generic.ICollection`1<UnityEngine.Sprite>)+18]");
							if (num3 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r12_v5 (System.Collections.Generic.ICollection`1<UnityEngine.Sprite>)+18]");
								bool flag4 = (nint)0 <= (nint)0;
								int num4 = 0;
								List<string> list = _tempKeys;
								if (!flag4)
								{
									int num6;
									do
									{
										_ = 0;
										string text = list.get_Item(num4);
										Sprite sprite = _tempGlyphs.get_Item(num4);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+10]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ r8_v35+18]");
										if (num5 >= 0)
										{
											GlyphOrText item2 = (GlyphOrText)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
											_ = 0;
											results.AddWithResize(item2);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
											object obj9 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
											object obj10 = (nint)0 * (nint)2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
											object obj11 = 0 + obj10;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
											_ = 0;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2F]");
										list = (List<string>)0;
										num4++;
										num6 = num4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r12_v5 (System.Collections.Generic.ICollection`1<UnityEngine.Sprite>)+18]");
									}
									while ((nint)num6 < (nint)0);
									_ = 1;
									goto IL_0e9a;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+6F]");
								displayType = DisplayType.Glyph;
							}
							else
							{
								Debug.LogError("Rewired: Glyph key count does not match glyph count.");
							}
						}
					}
					object obj12 = displayType - 1;
					if ((nint)obj12 > 1)
					{
						_ = 0;
						num7 = 0;
					}
					else
					{
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
						string elementIdentifierName = ((ActionElementMap)0).elementIdentifierName;
						GlyphOrText item3 = (GlyphOrText)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
						_ = 0;
						results.Add(item3);
						_ = 1;
						num7 = 0;
					}
					goto IL_0ea8;
				}
				_ = 0;
				goto IL_0e9a;
			}
		}
		goto IL_0db9;
		IL_0e9a:
		num7 = 0;
		goto IL_0ea8;
		IL_0ea8:
		List<Sprite> tempGlyphs3 = _tempGlyphs;
		if (_tempGlyphs != null)
		{
			int version5 = tempGlyphs3._version + 1;
			tempGlyphs3._version = version5;
			tempGlyphs3._size = num7;
			if (tempGlyphs3._size > 0)
			{
				Array.Clear(tempGlyphs3._items, 0, tempGlyphs3._size);
			}
			List<string> tempKeys3 = _tempKeys;
			if (_tempKeys != null)
			{
				int version6 = tempKeys3._version + 1;
				tempKeys3._version = version6;
				tempKeys3._size = num7;
				if (tempKeys3._size > 0)
				{
					Array.Clear(tempKeys3._items, 0, tempKeys3._size);
				}
				ICollection<Sprite> tempGlyphs4 = _tempGlyphs;
				ICollection<string> tempKeys4 = _tempKeys;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
				if ((nint)0 != 0 && _tempGlyphs != null && results != null)
				{
					object obj13 = (long)tag.type & 0xFFFFFFFDL;
					bool flag5 = obj13 == null;
					object obj14 = !flag5;
					if (obj14 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
						int elementIdentifierGlyphs2 = ((ActionElementMap)0).GetElementIdentifierGlyphs(_tempGlyphs);
						if (elementIdentifierGlyphs2 > 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
							int elementIdentifierFinalGlyphKeys2 = ((ActionElementMap)0).GetElementIdentifierFinalGlyphKeys(_tempKeys);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ r15_v7 (System.Collections.Generic.ICollection`1<System.String>)+18]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdi_v9 (System.Collections.Generic.ICollection`1<UnityEngine.Sprite>)+18]");
							if (num8 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdi_v9 (System.Collections.Generic.ICollection`1<UnityEngine.Sprite>)+18]");
								if ((nint)0 > (nint)0)
								{
									int num10;
									do
									{
										_ = 0;
										string text2 = _tempKeys.get_Item(num7);
										Sprite sprite2 = _tempGlyphs.get_Item(num7);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+10]");
										object obj15 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ r8_v22+18]");
										if (num9 >= 0)
										{
											GlyphOrText item4 = (GlyphOrText)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
											_ = 0;
											results.AddWithResize(item4);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
											object obj16 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
											object obj17 = (nint)0 * (nint)2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [results @ r8 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
											object obj18 = 0 + obj17;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
											_ = 0;
										}
										num7++;
										num10 = num7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdi_v9 (System.Collections.Generic.ICollection`1<UnityEngine.Sprite>)+18]");
									}
									while ((nint)num10 < (nint)0);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+6F]");
									return (byte)((nuint)1u | (nuint)0u) != 0;
								}
								num7 = 0;
							}
							else
							{
								Debug.LogError("Rewired: Glyph key count does not match glyph count.");
							}
						}
					}
					object obj19 = tag.type - 1;
					if ((nint)obj19 <= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
						string elementIdentifierName2 = ((ActionElementMap)0).elementIdentifierName;
						GlyphOrText item5 = (GlyphOrText)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
						_ = 0;
						results.Add(item5);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+6F]");
						return (byte)((nuint)1u | (nuint)0u) != 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+6F]");
				return false;
			}
		}
		goto IL_0db9;
	}

	private unsafe bool TryGetActionDisplayName(ActionTag tag, out string result)
	{
		//IL_00b7: Expected I4, but got O
		ref string reference;
		if (tag != null)
		{
			ReInput.MappingHelper mapping = ReInput.mapping;
			if (mapping == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			InputAction action = mapping.GetAction(tag.actionId);
			if (action != null)
			{
				string displayName = action.GetDisplayName(tag.actionRange);
				reference = ref *(string*)displayName;
				tag._displayName = result;
				return true;
			}
		}
		reference = ref *(string*)null;
		return false;
	}

	private unsafe bool TryGetPlayerDisplayName(PlayerTag tag, out string result)
	{
		//IL_00ae: Expected I4, but got O
		ref string reference;
		if (tag != null)
		{
			ReInput.PlayerHelper players = ReInput.players;
			if (players == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			Player player = players.GetPlayer(tag.playerId);
			if (player != null)
			{
				string descriptiveName = player.descriptiveName;
				reference = ref *(string*)descriptiveName;
				tag._displayName = result;
				return true;
			}
		}
		reference = ref *(string*)null;
		return false;
	}

	private bool TryAssignSprite(Sprite sprite, string key)
	{
		//IL_04d1: Expected I4, but got O
		//IL_0015: Expected O, but got I
		//IL_04c3: Expected I4, but got O
		//IL_0054: Expected O, but got I
		//IL_0460: Expected O, but got I4
		//IL_04a0: Expected O, but got I4
		//IL_01c3: Expected I, but got O
		//IL_018d: Expected I, but got O
		//IL_032f: Expected I, but got O
		//IL_0357: Expected I, but got O
		//IL_03d9: Expected O, but got I
		//IL_037e: Expected O, but got I4
		//IL_03ed: Expected O, but got I4
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected O, but got Unknown
		//IL_042d: Expected O, but got I4
		bool flag = (byte)(int)GetOrCreateAsset(sprite) != 0;
		ITMProSpriteAsset iTMProSpriteAsset;
		Rect rect;
		TMProSprite_AssetV1_0_0 tMProSprite_AssetV1_0_2;
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v2 (System.Boolean)+18]");
			iTMProSpriteAsset = (ITMProSpriteAsset)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v2 (System.Boolean)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v2 (System.Boolean)+18]");
				if (((ITMProSpriteAsset)0).Contains(key))
				{
					goto IL_0432;
				}
				if ((object)sprite != null)
				{
					rect = sprite.rect;
					bool flag2 = TMProSprite_AssetV1_1_0.CheckVersionSupported();
					if (!TMProAssetVersionHelper._isVersionSupportedChecked)
					{
						TMProAssetVersionHelper._isVersionSupportedChecked = true;
					}
					if (!flag2)
					{
						TMProSprite_AssetV1_0_0 tMProSprite_AssetV1_0_ = new TMProSprite_AssetV1_0_0();
						TMP_Sprite spriteInfo = new TMP_Sprite();
						tMProSprite_AssetV1_0_.spriteInfo = spriteInfo;
						tMProSprite_AssetV1_0_2 = tMProSprite_AssetV1_0_;
						nint num = (nint)typeof(ITMProSpriteAsset);
						goto IL_01c8;
					}
					TMProSprite_AssetV1_1_0 tMProSprite_AssetV1_1_ = new TMProSprite_AssetV1_1_0();
					TMProSprite_AssetV1_1_0.TMPro_SpriteGlyph spriteGlyph = new TMProSprite_AssetV1_1_0.TMPro_SpriteGlyph();
					tMProSprite_AssetV1_1_._spriteGlyph = spriteGlyph;
					TMProSprite_AssetV1_1_0.TMPro_SpriteCharacter spriteCharacter = new TMProSprite_AssetV1_1_0.TMPro_SpriteCharacter();
					tMProSprite_AssetV1_1_._spriteCharacter = spriteCharacter;
					TMProSprite_AssetV1_1_0.TMPro_SpriteGlyph spriteGlyph2 = tMProSprite_AssetV1_1_._spriteGlyph;
					if (tMProSprite_AssetV1_1_._spriteGlyph != null)
					{
						TMProSprite_AssetV1_1_0.TMPro_SpriteCharacter spriteCharacter2 = tMProSprite_AssetV1_1_._spriteCharacter;
						if (tMProSprite_AssetV1_1_._spriteCharacter != null && (object)spriteCharacter2._glyph != null)
						{
							spriteCharacter2._glyph.SetValue(spriteCharacter2._source, spriteGlyph2._source);
							tMProSprite_AssetV1_0_2 = (TMProSprite_AssetV1_0_0)(object)tMProSprite_AssetV1_1_;
							nint num = unchecked((nint)null);
							goto IL_01c8;
						}
					}
				}
			}
			goto IL_04b5;
		}
		return flag;
		IL_0432:
		if (_currentlyUsedAssets != null)
		{
			if (!((List<object>)(object)_currentlyUsedAssets).Contains((object)flag))
			{
				if (_currentlyUsedAssets == null)
				{
					goto IL_04b5;
				}
				_currentlyUsedAssets.Add((Asset)flag);
			}
			return true;
		}
		goto IL_04b5;
		IL_04b5:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_03b5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
		goto IL_03c4;
		IL_01c8:
		if (tMProSprite_AssetV1_0_2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003BA0");
			float num2 = rect.m_Width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+34]");
			float num3 = num2 * 0f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+3C]");
			float num5 = num4 + 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
			float num6 = rect.m_Height;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+38]");
			float num7 = num6 * 0f;
			float num8 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+40]");
			float num9 = num8 + 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
			float num10 = rect.m_Width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+44]");
			float num11 = num10 * 0f;
			float num12 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper)+48]");
			float num13 = num12 + 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003BA0");
			((ITMProSprite)tMProSprite_AssetV1_0_2).name = key;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182155640");
			int hashCode = default(int);
			((ITMProSprite)tMProSprite_AssetV1_0_2).hashCode = hashCode;
			((ITMProSprite)tMProSprite_AssetV1_0_2).sprite = sprite;
			nint num14 = (nint)iTMProSpriteAsset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r10_v7 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSpriteAsset>)+12E]");
			bool flag3 = (nint)0 >= (nint)0;
			nint num15 = (nint)typeof(ITMProSprite);
			if (flag3)
			{
				goto IL_03b5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r10_v7 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSpriteAsset>)+B0]");
			num15 = 0;
			object obj = 0;
			while (true)
			{
				object obj2 = obj + obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ r9_v11 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSprite>)+v1029 @ rax_v47*8]");
				if (0 != (nint)typeof(ITMProSpriteAsset))
				{
					obj++;
					object obj3 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r10_v7 (Il2CppClass<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+ITMProSpriteAsset>)+12E]");
					if ((nint)obj3 < 0)
					{
						continue;
					}
					goto IL_03b5;
				}
				break;
			}
			goto IL_03c4;
		}
		goto IL_04b5;
		IL_03c4:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v2 (System.Boolean)+18]");
		((ITMProSpriteAsset)0).AddSprite(tMProSprite_AssetV1_0_2);
		if (_dirtyAssets != null)
		{
			if (!((List<object>)(object)_dirtyAssets).Contains((object)flag))
			{
				if (_dirtyAssets == null)
				{
					goto IL_04b5;
				}
				_dirtyAssets.Add((Asset)flag);
			}
			goto IL_0432;
		}
		goto IL_04b5;
	}

	private void RequireRebuild()
	{
		_rebuildRequired = true;
	}

	private void CreatePrimaryAsset()
	{
		if (_primaryAsset == null)
		{
			Asset primaryAsset = new Asset(null);
			_primaryAsset = primaryAsset;
			Asset primaryAsset2 = _primaryAsset;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			TMP_SpriteAsset spriteAsset = default(TMP_SpriteAsset);
			_tmProText.spriteAsset = spriteAsset;
		}
	}

	private unsafe Asset GetOrCreateAsset(Sprite sprite)
	{
		//IL_041c: Expected O, but got Ref
		//IL_0525: Expected O, but got I
		if (!(sprite != null))
		{
			goto IL_0730;
		}
		if ((object)sprite != null)
		{
			Texture2D texture = sprite.texture;
			if (!(texture != null))
			{
				goto IL_0730;
			}
			List<Asset> assignedAssets = _assignedAssets;
			if (_assignedAssets != null)
			{
				bool flag = assignedAssets._size <= 0;
				int num = 0;
				if (flag)
				{
					goto IL_01d3;
				}
				UnityEngine.Object obj = default(UnityEngine.Object);
				while (_assignedAssets != null)
				{
					Asset asset = _assignedAssets.get_Item(num);
					if (asset != null)
					{
						if (_assignedAssets == null)
						{
							break;
						}
						Asset asset2 = _assignedAssets.get_Item(num);
						if (asset2 == null || asset2._spriteAsset == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						Texture2D texture2 = sprite.texture;
						if (!(obj != texture2))
						{
							if (_assignedAssets == null)
							{
								break;
							}
							return _assignedAssets.get_Item(num);
						}
					}
					num++;
					if (num < assignedAssets._size)
					{
						continue;
					}
					goto IL_01d3;
				}
			}
		}
		goto IL_073f;
		IL_044e:
		Texture2D texture3 = sprite.texture;
		Asset asset3;
		List<TMP_SpriteAsset> list;
		if (asset3._spriteAsset != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003110");
			Texture2D texture4 = sprite.texture;
			if ((object)asset3._material != null)
			{
				asset3._material.SetTextureImpl(ShaderUtilities.ID_MainTex, (Texture)texture4);
				Asset primaryAsset = _primaryAsset;
				if (_primaryAsset != null && primaryAsset._spriteAsset != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					object obj2 = default(object);
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v36+D8]");
						list = (List<TMP_SpriteAsset>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v36+D8]");
						if ((nint)0 != 0)
						{
							goto IL_05e0;
						}
						List<TMP_SpriteAsset> list2 = new List<TMP_SpriteAsset>();
						Asset primaryAsset2 = _primaryAsset;
						if (_primaryAsset != null && primaryAsset2._spriteAsset != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							object obj3 = default(object);
							if (obj3 != null)
							{
								list = list2;
								goto IL_05e0;
							}
						}
					}
				}
			}
		}
		goto IL_073f;
		IL_02c8:
		int num2;
		if (_assetsPool != null)
		{
			Asset asset4 = _assetsPool.get_Item(num2);
			if (_assetsPool != null)
			{
				((List<object>)(object)_assetsPool).RemoveAt(num2);
				bool flag2 = asset4 != null;
				asset3 = asset4;
				if (flag2)
				{
					goto IL_044e;
				}
				goto IL_0790;
			}
		}
		goto IL_073f;
		IL_0790:
		Asset asset5 = new Asset(_baseSpriteMaterial);
		if (_overrideSpriteMaterialProperties)
		{
			if (asset5 != null)
			{
				bool flag3 = asset5._material == null;
				asset3 = asset5;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
					if ((nint)0 == (flag3 ? 1 : 0))
					{
						_ = 1;
					}
					int nameID = Shader.PropertyToID("_Color");
					if ((object)asset5._material == null)
					{
						goto IL_073f;
					}
					bool flag4 = asset5._material.HasProperty(nameID);
					bool flag5 = !flag4;
					asset3 = asset5;
					if (!flag5)
					{
						SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
						asset5._material.color = (Color)(&spriteMaterialProperties);
						asset3 = asset5;
					}
				}
				goto IL_044e;
			}
		}
		else
		{
			bool flag6 = asset5 == null;
			asset3 = asset5;
			if (!flag6)
			{
				goto IL_044e;
			}
		}
		goto IL_073f;
		IL_0730:
		return null;
		IL_01d3:
		List<Asset> assetsPool = _assetsPool;
		if (_assetsPool != null)
		{
			bool flag7 = assetsPool._size <= 0;
			num2 = 0;
			if (flag7)
			{
				goto IL_0790;
			}
			while (_assetsPool != null)
			{
				Asset asset6 = _assetsPool.get_Item(num2);
				if (asset6 != null)
				{
					goto IL_02c8;
				}
				num2++;
				if (num2 < assetsPool._size)
				{
					continue;
				}
				goto IL_0790;
			}
		}
		goto IL_073f;
		IL_073f:
		return (Asset)(object)new NullReferenceException();
		IL_05e0:
		if (asset3._spriteAsset != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				TMP_SpriteAsset[] items = list._items;
				if (list._items != null)
				{
					int size = list._size;
					object obj4 = default(object);
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize(obj4);
					}
					else
					{
						int size2 = list._size + 1;
						list._size = size2;
						items[size] = (TMP_SpriteAsset)obj4;
					}
					if (_assignedAssets != null)
					{
						_assignedAssets.Add(asset3);
						return asset3;
					}
				}
			}
		}
		goto IL_073f;
	}

	private unsafe Asset CreateAsset()
	{
		//IL_00bc: Expected O, but got Ref
		Asset asset = new Asset(_baseSpriteMaterial);
		if (_overrideSpriteMaterialProperties)
		{
			if (asset == null)
			{
				goto IL_00c6;
			}
			bool flag = asset._material == null;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
				if ((nint)0 == (flag ? 1 : 0))
				{
					_ = 1;
				}
				int nameID = Shader.PropertyToID("_Color");
				if ((object)asset._material == null)
				{
					goto IL_00c6;
				}
				if (asset._material.HasProperty(nameID))
				{
					SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
					asset._material.color = (Color)(&spriteMaterialProperties);
				}
			}
		}
		return asset;
		IL_00c6:
		return (Asset)(object)new NullReferenceException();
	}

	private void RemoveUnusedAssets()
	{
		//IL_0021: Expected O, but got I4
		//IL_01c7: Expected O, but got I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0130: Expected O, but got I
		List<Asset> assignedAssets = _assignedAssets;
		bool flag = (nint)_assignedAssets < 0;
		int num = assignedAssets._size - 1;
		object obj = 0;
		if (flag)
		{
			return;
		}
		object item = default(object);
		object obj3;
		do
		{
			Asset asset = _assignedAssets.get_Item(num);
			bool flag2 = (nint)asset < 0;
			if (asset != null)
			{
				bool flag3 = ((List<object>)(object)_currentlyUsedAssets).Contains((object)asset);
				flag2 = (flag3 ? 1 : 0) < (false ? 1 : 0);
				if (!flag3)
				{
					object obj2 = obj - 2;
					flag2 = (nint)obj2 < 0;
					if ((nint)obj < 2)
					{
						obj++;
					}
					else
					{
						Asset primaryAsset = _primaryAsset;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v9+D8]");
						bool flag4 = ((List<object>)0).Remove(item);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003110");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
						asset._material.SetTextureImpl(ShaderUtilities.ID_MainTex, (Texture)_stubTexture);
						_assetsPool.Add(asset);
						flag2 = (nint)_assignedAssets < 0;
						((List<object>)(object)_assignedAssets).RemoveAt(num);
					}
				}
			}
			num--;
			obj3 = !flag2;
		}
		while (obj3 != null);
	}

	private void SetDirty(Asset asset)
	{
		if (!((List<object>)(object)_dirtyAssets).Contains((object)asset))
		{
			_dirtyAssets.Add(asset);
		}
	}

	private void ForEachAsset(Action<Asset> callback)
	{
		if (callback == null)
		{
			return;
		}
		List<Asset> assignedAssets = _assignedAssets;
		bool flag = assignedAssets._size <= 0;
		int num = 0;
		if (!flag)
		{
			do
			{
				Asset asset = _assignedAssets.get_Item(num);
				if (asset != null)
				{
					Asset asset2 = _assignedAssets.get_Item(num);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [callback @ rdx (System.Action`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Asset>)+18] (should have been resolved before IL gen)");
				}
				num++;
			}
			while (num < assignedAssets._size);
		}
		List<Asset> assetsPool = _assetsPool;
		bool flag2 = assetsPool._size <= 0;
		int num2 = 0;
		if (flag2)
		{
			return;
		}
		do
		{
			Asset asset3 = _assetsPool.get_Item(num2);
			if (asset3 != null)
			{
				Asset asset4 = _assetsPool.get_Item(num2);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [callback @ rdx (System.Action`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+Asset>)+18] (should have been resolved before IL gen)");
			}
			num2++;
		}
		while (num2 < assetsPool._size);
	}

	private static void ParseAttributes(string text, int startIndex, int count, StringBuilder sbKey, StringBuilder sbValue, Dictionary<string, string> results)
	{
		//IL_00f1: Expected O, but got I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0117: Expected O, but got I4
		//IL_068a: Expected O, but got I4
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_0569: Expected O, but got I4
		//IL_04e4: Expected O, but got I4
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_0509: Expected O, but got I4
		//IL_06fb: Expected O, but got I4
		//IL_0458: Expected O, but got I4
		//IL_02fb: Expected I4, but got O
		//IL_0348: Expected O, but got I
		//IL_0351: Expected O, but got I4
		if (string.IsNullOrEmpty(text) || startIndex < 0)
		{
			return;
		}
		StringBuilder stringBuilder2;
		if (text != null)
		{
			if (startIndex >= text._stringLength)
			{
				return;
			}
			Dictionary<string, string> dictionary = default(Dictionary<string, string>);
			if (dictionary != null)
			{
				dictionary.Clear();
				if (sbKey != null)
				{
					sbKey.Length = 0;
					StringBuilder stringBuilder = default(StringBuilder);
					if (stringBuilder != null)
					{
						stringBuilder.Length = 0;
						object obj = count - 1;
						object obj2 = obj + startIndex;
						stringBuilder2 = sbKey;
						int num = startIndex;
						object obj3 = 0;
						bool flag = true;
						Dictionary<string, string> dictionary2 = dictionary;
						int num2 = count;
						string text2 = text;
						object value = default(object);
						object obj8 = default(object);
						object obj10 = default(object);
						while (true)
						{
							object obj4 = num2 + startIndex;
							if (num >= (nint)obj4)
							{
								return;
							}
							char c = text2.get_Chars(num);
							bool flag2 = obj3 == null;
							if (!flag2)
							{
								object obj5 = obj3 - 1;
								if (!flag2)
								{
									object obj6 = obj5 - 1;
									if (flag2)
									{
										bool flag3 = c == '"';
										if (!flag3)
										{
											bool flag4 = char.IsDigit(c);
											bool flag5 = !flag4;
											flag = flag3;
											if (flag5)
											{
												goto IL_056e;
											}
										}
										int num3 = num - 1;
										if (c == '"')
										{
											num3 = num;
										}
										stringBuilder.Length = 0;
										num = num3 + 1;
										obj3 = 3;
										flag = flag3;
										num2 = count;
										text2 = text;
										continue;
									}
									if ((nint)obj6 == 1)
									{
										if (flag)
										{
											if (c != '"')
											{
												goto IL_023a;
											}
										}
										else if (num != (nint)obj2)
										{
											if (!char.IsWhiteSpace(c))
											{
												goto IL_023a;
											}
										}
										else
										{
											StringBuilder stringBuilder3 = stringBuilder.Append(c);
										}
										if (stringBuilder.Length != 0)
										{
											if (dictionary2 == null)
											{
												Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
												dictionary2 = dictionary3;
											}
											string key = sbKey.ToString();
											int num4 = (int)stringBuilder;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v272 @ r8_v20 (System.Int32)+168] (should have been resolved before IL gen)");
											if (dictionary2 == null)
											{
												break;
											}
											((Dictionary<object, object>)(object)dictionary2).Add((object)key, value);
											num++;
											stringBuilder2 = (StringBuilder)0;
											obj3 = 0;
											num2 = count;
											text2 = text;
											continue;
										}
										((Dictionary<string, string>)(object)typeof(Exception)).Clear();
										Exception ex = new Exception("Value was blank.");
										ex._002Ector("Value was blank.");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
										int num5 = 0;
										object obj7 = obj8;
										throw ex;
									}
								}
								else
								{
									if (c == '=')
									{
										int length = sbKey.Length;
										bool flag6 = length == 0;
										int num6 = 0;
										object obj9 = 0;
										if (!flag6)
										{
											num++;
											obj3 = 2;
											num2 = count;
											text2 = text;
											continue;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
										Exception ex2 = new Exception("Key was blank.");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
										throw ex2;
									}
									if (IsValidKeyChar(c))
									{
										char value2 = char.ToLowerInvariant(c);
										StringBuilder stringBuilder4 = sbKey.Append(value2);
										num++;
										num2 = count;
										text2 = text;
										continue;
									}
									bool flag7 = char.IsWhiteSpace(c);
									bool flag8 = !flag7;
									int num5 = 0;
									object obj7 = 0;
									if (flag8)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
										Exception ex3 = new Exception("Error parsing key.");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
										int num6 = 0;
										object obj9 = obj10;
										throw ex3;
									}
								}
							}
							else if (IsValidKeyChar(c))
							{
								num--;
								sbKey.Length = 0;
								obj3 = 1;
							}
							goto IL_056e;
							IL_023a:
							StringBuilder stringBuilder5 = stringBuilder.Append(c);
							num++;
							num2 = count;
							text2 = text;
							continue;
							IL_056e:
							num++;
							num2 = count;
							text2 = text;
						}
						throw new NullReferenceException();
					}
				}
			}
		}
		stringBuilder2 = sbKey;
		throw new NullReferenceException();
	}

	private static bool IsValidKeyChar(char c)
	{
		//IL_003f: Expected O, but got I4
		if (char.IsLetterOrDigit(c))
		{
			return true;
		}
		object obj = c - 95;
		return obj == null;
	}

	private static bool IsValidTagNameChar(char c)
	{
		//IL_003f: Expected O, but got I4
		if (char.IsLetterOrDigit(c))
		{
			return true;
		}
		object obj = c - 95;
		return obj == null;
	}

	private static bool IsValidNonQuotedValueChar(char c)
	{
		return char.IsDigit(c);
	}

	private static bool IsEqual(List<GlyphOrText> a, List<GlyphOrText> b)
	{
		//IL_013d: Expected I4, but got O
		//IL_005a: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		if (a != null && b != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [b @ rdx (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
			if (num == 0)
			{
				object obj = 0;
				object obj2 = 0;
				string text = default(string);
				string text2 = default(string);
				string a2 = default(string);
				string b2 = default(string);
				while (true)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [a @ rcx (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1811491F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1811491F0");
						if (!string.Equals(text, text2, StringComparison.Ordinal))
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
						if (!((UnityEngine.Object)(object)text == (UnityEngine.Object)(object)text2) || !string.Equals(a2, b2, StringComparison.Ordinal))
						{
							break;
						}
						obj++;
						obj2 = obj;
						continue;
					}
					return true;
				}
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static void WriteSpriteKey(StringBuilder sb, string key)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172439]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = sb.Append("<sprite name=\"");
		StringBuilder stringBuilder2 = sb.Append(key);
		StringBuilder stringBuilder3 = sb.Append("\">");
	}

	private unsafe static bool TryGetGlyphsOrText(ActionElementMap aem, DisplayType displayType, List<Sprite> glyphs, List<string> keys, List<GlyphOrText> results)
	{
		//IL_0051: Expected O, but got I8
		//IL_006b: Expected O, but got I4
		//IL_026e: Expected O, but got I4
		//IL_02bb: Expected O, but got Ref
		//IL_02f9: Expected I4, but got O
		//IL_0152: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_01eb: Expected O, but got I
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_01b0: Expected O, but got Ref
		List<GlyphOrText> list = default(List<GlyphOrText>);
		if (aem != null && glyphs != null && list != null)
		{
			object obj = (long)displayType & 0xFFFFFFFDL;
			bool flag = obj == null;
			object obj2 = !flag;
			object obj4 = default(object);
			if (obj2 == null)
			{
				int elementIdentifierGlyphs = aem.GetElementIdentifierGlyphs(glyphs);
				if (elementIdentifierGlyphs > 0)
				{
					int elementIdentifierFinalGlyphKeys = aem.GetElementIdentifierFinalGlyphKeys(keys);
					if (keys == null)
					{
						goto IL_02eb;
					}
					if (keys._size == glyphs._size)
					{
						bool flag2 = glyphs._size <= 0;
						int num = 0;
						if (!flag2)
						{
							while (true)
							{
								string text = keys.get_Item(num);
								Sprite sprite = glyphs.get_Item(num);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ stack_28 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ stack_28 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+10]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ stack_28 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ stack_28 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ r8_v12+18]");
								if (num2 >= 0)
								{
									list.AddWithResize((GlyphOrText)(&obj4));
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ stack_28 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
									object obj5 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ stack_28 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
									object obj6 = (nint)0 * (nint)2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ stack_28 (System.Collections.Generic.List`1<Rewired.Glyphs.UnityUI.UnityUITextMeshProGlyphHelper+GlyphOrText>)+18]");
									object obj7 = 0 + obj6;
								}
								num++;
								if (num < glyphs._size)
								{
									continue;
								}
								goto IL_023e;
							}
							goto IL_02eb;
						}
					}
					else
					{
						Debug.LogError("Rewired: Glyph key count does not match glyph count.");
					}
				}
			}
			object obj8 = displayType - 1;
			if ((nint)obj8 > 1)
			{
				return false;
			}
			string elementIdentifierName = aem.elementIdentifierName;
			list.Add((GlyphOrText)(&obj4));
			goto IL_023e;
		}
		return false;
		IL_023e:
		return true;
		IL_02eb:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static bool IsGlyphAllowed(DisplayType displayType)
	{
		//IL_0034: Expected O, but got I4
		if (displayType == DisplayType.Glyph)
		{
			return true;
		}
		object obj = displayType - 2;
		return obj == null;
	}

	private static bool IsTextAllowed(DisplayType displayType)
	{
		//IL_0033: Expected O, but got I4
		if (displayType == DisplayType.Text)
		{
			return (byte)displayType != 0;
		}
		object obj = displayType - 2;
		return obj == null;
	}

	private unsafe static void CopyMaterialProperties(Material source, Material destination)
	{
		//IL_018c: Expected O, but got Ref
		if (!(source != null) || !(destination != null))
		{
			return;
		}
		Shader shader = source.shader;
		destination.shader = shader;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279D40");
		object obj = default(object);
		if (obj == null)
		{
			Array array = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279D40");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v29+18]");
			string[] array2 = new string[0];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279D40");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182279D40");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v32+18]");
			Array sourceArray = default(Array);
			Array.Copy(sourceArray, array2, 0);
			Array array = array2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18227B830");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int nameID = Shader.PropertyToID("_Color");
		if (source.HasProperty(nameID))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			int nameID2 = Shader.PropertyToID("_Color");
			if (destination.HasProperty(nameID2))
			{
				Color color = source.color;
				object obj2 = default(object);
				destination.color = (Color)(&obj2);
			}
		}
		int renderQueue = source.renderQueue;
		destination.renderQueue = renderQueue;
		MaterialGlobalIlluminationFlags globalIlluminationFlags = source.globalIlluminationFlags;
		destination.globalIlluminationFlags = globalIlluminationFlags;
	}

	private unsafe static void CopySpriteMaterialPropertiesToMaterial(SpriteMaterialProperties properties, Material material)
	{
		//IL_008a: Expected O, but got Ref
		bool flag = material == null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
			if ((nint)0 == (flag ? 1 : 0))
			{
				_ = 1;
			}
			int nameID = Shader.PropertyToID("_Color");
			if (material.HasProperty(nameID))
			{
				object obj = default(object);
				material.color = (Color)(&obj);
			}
		}
	}

	public UnityUITextMeshProGlyphHelper()
	{
		//IL_016c: Expected O, but got I4
		//IL_017d: Expected O, but got I4
		_overrideSpriteMaterialProperties = true;
		_spriteOptions = (TMProSpriteOptions)1069547520;
		_ = 0;
		_spriteMaterialProperties = (SpriteMaterialProperties)1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		StringBuilder processTagSb = new StringBuilder();
		_processTagSb = processTagSb;
		_tempSb = new StringBuilder();
		_tempSb2 = new StringBuilder();
		_assignedAssets = new List<Asset>();
		_assetsPool = new List<Asset>();
		_tempAems = new List<ActionElementMap>();
		_tempGlyphs = new List<Sprite>();
		_dirtyAssets = new List<Asset>();
		_tempKeys = new List<string>();
		_glyphsOrTextTemp = new List<GlyphOrText>();
		_currentlyUsedAssets = new List<Asset>();
		_currentTags = new List<Tag>();
		_tempStringDictionary = new Dictionary<string, string>();
		base._002Ector();
	}

	private unsafe void _003Cset_overrideSpriteMaterialProperties_003Eb__51_0(Asset asset)
	{
		//IL_009f: Expected O, but got Ref
		bool flag = asset._material == null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
			if ((nint)0 == (flag ? 1 : 0))
			{
				_ = 1;
			}
			int nameID = Shader.PropertyToID("_Color");
			if (asset._material.HasProperty(nameID))
			{
				SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
				asset._material.color = (Color)(&spriteMaterialProperties);
			}
		}
		TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
	}

	private unsafe void _003Cset_spriteMaterialProperties_003Eb__54_0(Asset asset)
	{
		//IL_009f: Expected O, but got Ref
		bool flag = asset._material == null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172432]");
			if ((nint)0 == (flag ? 1 : 0))
			{
				_ = 1;
			}
			int nameID = Shader.PropertyToID("_Color");
			if (asset._material.HasProperty(nameID))
			{
				SpriteMaterialProperties spriteMaterialProperties = default(SpriteMaterialProperties);
				asset._material.color = (Color)(&spriteMaterialProperties);
			}
		}
		TMPro_EventManager.ON_MATERIAL_PROPERTY_CHANGED(isChanged: true, asset._material);
	}
}
