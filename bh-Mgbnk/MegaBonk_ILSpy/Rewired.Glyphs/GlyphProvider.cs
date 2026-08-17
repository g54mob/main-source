using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Glyphs;

public class GlyphProvider : MonoBehaviour, IGlyphProvider
{
	private bool _prefetch;

	private List<GlyphSetCollection> _glyphSetCollections;

	[NonSerialized]
	private readonly Dictionary<string, object> _glyphs;

	[NonSerialized]
	private bool _initialized;

	public bool prefetch
	{
		get
		{
			return _prefetch;
		}
		set
		{
			_prefetch = value;
			if (base.isActiveAndEnabled && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.GlyphHelper glyphHelper = ReInput.glyphs;
				IGlyphProvider glyphProvider = glyphHelper.glyphProvider;
				if (glyphProvider == this)
				{
					ReInput.GlyphHelper glyphHelper2 = ReInput.glyphs;
					glyphHelper2.prefetch = value;
				}
			}
		}
	}

	public List<GlyphSetCollection> glyphSetCollections
	{
		get
		{
			return _glyphSetCollections;
		}
		set
		{
			_glyphSetCollections = value;
			bool flag = Initialize();
			if (base.isActiveAndEnabled && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				ReInput.GlyphHelper glyphHelper = ReInput.glyphs;
				IGlyphProvider glyphProvider = glyphHelper.glyphProvider;
				if (glyphProvider == this)
				{
					ReInput.GlyphHelper glyphHelper2 = ReInput.glyphs;
					glyphHelper2.Reload();
				}
			}
		}
	}

	protected Dictionary<string, object> glyphs => _glyphs;

	protected virtual void OnEnable()
	{
		if (!_initialized)
		{
			bool flag = Initialize();
		}
		TrySetGlyphProvider();
	}

	protected virtual void OnDisable()
	{
		//IL_0083: Expected I, but got O
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.GlyphHelper glyphHelper = ReInput.glyphs;
			IGlyphProvider glyphProvider = glyphHelper.glyphProvider;
			if (glyphProvider == this)
			{
				ReInput.GlyphHelper glyphHelper2 = ReInput.glyphs;
				glyphHelper2.glyphProvider = null;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ r8_v3 (Il2CppClass<Rewired.Glyphs.GlyphProvider>)+1C0]");
		Action value = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		ReInput.InitializedEvent -= value;
	}

	protected virtual void Update()
	{
	}

	protected virtual void TrySetGlyphProvider()
	{
		//IL_000a: Expected I, but got O
		//IL_004e: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<Rewired.Glyphs.GlyphProvider>)+1C0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<Rewired.Glyphs.GlyphProvider>)+1C0]");
		action._002Ector(this, (IntPtr)0);
		ReInput.InitializedEvent -= action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ r8_v4 (Il2CppClass<Rewired.Glyphs.GlyphProvider>)+1C0]");
		Action value = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		ReInput.InitializedEvent += value;
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.GlyphHelper glyphHelper = ReInput.glyphs;
			IGlyphProvider glyphProvider = glyphHelper.glyphProvider;
			if (UnityTools.IsNullOrDestroyed(glyphProvider))
			{
				ReInput.GlyphHelper glyphHelper2 = ReInput.glyphs;
				glyphHelper2.glyphProvider = this;
				ReInput.GlyphHelper glyphHelper3 = ReInput.glyphs;
				glyphHelper3.prefetch = _prefetch;
			}
			else
			{
				Debug.LogWarning("Rewired: A glyph provider is already set. Only one glyph provider can exist at a time.");
			}
		}
	}

	protected unsafe virtual bool Initialize()
	{
		//IL_05d8: Expected I4, but got O
		//IL_0047: Expected O, but got I4
		//IL_010e: Expected O, but got Ref
		//IL_01ee: Expected O, but got I
		//IL_01f7: Expected O, but got I4
		//IL_0219: Expected O, but got I
		//IL_024f: Expected O, but got I
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_0269: Expected I, but got O
		//IL_027c: Expected O, but got I4
		//IL_0289: Expected I, but got O
		//IL_0299: Expected O, but got I
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Expected O, but got Unknown
		//IL_02d6: Expected O, but got I
		//IL_02f8: Expected I, but got O
		//IL_0337: Expected O, but got I
		//IL_03b5: Expected O, but got I
		//IL_03e2: Expected O, but got I
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Expected O, but got Unknown
		//IL_044e: Expected I, but got O
		_initialized = false;
		if (_glyphSetCollections != null)
		{
			if (_glyphs != null)
			{
				_glyphs.Clear();
				StringBuilder stringBuilder = new StringBuilder();
				object obj = 0;
				int num = 0;
				GlyphProvider glyphProvider = this;
				object obj4 = default(object);
				UnityEngine.Object obj5 = default(UnityEngine.Object);
				object obj13 = default(object);
				UnityEngine.Object obj14 = default(UnityEngine.Object);
				object obj15 = default(object);
				object obj18 = default(object);
				while (true)
				{
					List<GlyphSetCollection> list = glyphProvider._glyphSetCollections;
					if (glyphProvider._glyphSetCollections == null)
					{
						break;
					}
					if (num < list._size)
					{
						GlyphSetCollection glyphSetCollection = glyphProvider._glyphSetCollections.get_Item(num);
						if (glyphSetCollection != null)
						{
							if ((object)glyphSetCollection == null)
							{
								break;
							}
							IEnumerable<GlyphSet> enumerable = glyphSetCollection.IterateSetsRecursively();
							if (enumerable == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							object obj2 = (object)(&obj);
							UnityEngine.Object obj3 = null;
							while (true)
							{
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
									if (obj4 == null)
									{
										break;
									}
									bool flag = obj == null;
									obj3 = null;
									if (!flag)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
										bool flag2 = obj5 != null;
										UnityEngine.Object obj6 = obj5;
										if (!flag2)
										{
											continue;
										}
										if ((object)obj5 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v27 (UnityEngine.Object)+18]");
											bool flag3 = (nint)0 == 0;
											obj6 = obj5;
											if (flag3)
											{
												continue;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v27 (UnityEngine.Object)+18]");
											object obj7 = 0;
											object obj8 = 0;
											obj6 = obj5;
											object obj9 = null;
											while (true)
											{
												object obj10 = obj8;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rax_v32+18]");
												if ((nint)obj10 >= 0)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rsi_v20 (UnityEngine.Object)+18]");
												object obj11 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rsi_v20 (UnityEngine.Object)+18]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v35+20+v351 @ r13_v6*8]");
													if (!string.IsNullOrEmpty((string)0))
													{
														nint num2 = (nint)obj6;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v720 @ rax_v52 (Il2CppClass<UnityEngine.Object>)+178] (should have been resolved before IL gen)");
														object obj12 = 0;
														while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
														{
															nint num3 = (nint)obj6;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ r9_v16 (Il2CppClass<UnityEngine.Object>)+190]");
															obj9 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v726 @ r9_v16 (Il2CppClass<UnityEngine.Object>)+188] (should have been resolved before IL gen)");
															bool flag4 = (object)obj14 == null;
															nint num4 = num3;
															if (!flag4)
															{
																bool flag5 = string.IsNullOrEmpty((string)(nint)obj14.m_CachedPtr);
																num4 = num3;
																if (!flag5)
																{
																	nint num5 = (nint)obj14;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v953 @ rax_v59 (Il2CppClass<UnityEngine.Object>)+178] (should have been resolved before IL gen)");
																	bool flag6 = obj15 == null;
																	num4 = num3;
																	if (!flag6)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rsi_v20 (UnityEngine.Object)+18]");
																		object obj16 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rsi_v20 (UnityEngine.Object)+18]");
																		if ((nint)0 == 0)
																		{
																			throw new NullReferenceException();
																		}
																		object obj17 = obj8;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ rdx_v34+18]");
																		if ((nint)obj17 >= 0)
																		{
																			throw new IndexOutOfRangeException();
																		}
																		if (stringBuilder == null)
																		{
																			throw new NullReferenceException();
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ rdx_v34+20+v351 @ r13_v6*8]");
																		StringBuilder stringBuilder2 = stringBuilder.Append((string)0);
																		StringBuilder stringBuilder3 = stringBuilder.Append('/');
																		StringBuilder stringBuilder4 = stringBuilder.Append((string)(nint)obj14.m_CachedPtr);
																		string text = stringBuilder.ToString();
																		stringBuilder.Length = 0;
																		if (_glyphs == null)
																		{
																			throw new NullReferenceException();
																		}
																		if (_glyphs.ContainsKey(text))
																		{
																			string message = "Rewired: Duplicate glyph key found: " + text;
																			Debug.LogError(message);
																			obj12++;
																			obj9 = null;
																			continue;
																		}
																		nint num6 = (nint)obj14;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v985 @ rax_v76 (Il2CppClass<UnityEngine.Object>)+178] (should have been resolved before IL gen)");
																		if (_glyphs == null)
																		{
																			throw new NullReferenceException();
																		}
																		((Dictionary<object, object>)(object)_glyphs).Add((object)text, obj18);
																		num4 = 0;
																		obj6 = obj5;
																		obj9 = obj18;
																	}
																}
															}
															obj12++;
															num3 = num4;
														}
													}
													obj8++;
													continue;
												}
												throw new NullReferenceException();
											}
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							if (obj2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
							}
						}
						num++;
						glyphProvider = this;
						continue;
					}
					glyphProvider._initialized = true;
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public void Reload()
	{
		bool flag = Initialize();
		if (base.isActiveAndEnabled && ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			ReInput.GlyphHelper glyphHelper = ReInput.glyphs;
			IGlyphProvider glyphProvider = glyphHelper.glyphProvider;
			if (glyphProvider == this)
			{
				ReInput.GlyphHelper glyphHelper2 = ReInput.glyphs;
				glyphHelper2.Reload();
			}
		}
	}

	unsafe bool IGlyphProvider.TryGetGlyph(string key, out object result)
	{
		//IL_005d: Expected I4, but got O
		if (_initialized)
		{
			if (_glyphs != null)
			{
				return ((Dictionary<object, object>)(object)_glyphs).TryGetValue((object)key, out result);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		ref object reference = ref *(object*)null;
		return false;
	}

	public GlyphProvider()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		_glyphs = dictionary;
		base._002Ector();
	}
}
