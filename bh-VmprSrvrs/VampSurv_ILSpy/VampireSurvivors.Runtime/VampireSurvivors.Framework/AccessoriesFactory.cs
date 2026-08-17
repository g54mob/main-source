using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework;

public class AccessoriesFactory : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class AccessoryDictionary : UnitySerializedDictionary<WeaponType, Accessory>
	{
		public AccessoryDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	private AccessoryDictionary _accessories;

	private Accessory _defaultAccessory;

	private List<AccessoriesFactory> _LinkedFactories;

	public unsafe Accessory GetAccessoryPrefab(WeaponType accessoryType)
	{
		//IL_0013: Expected O, but got I4
		//IL_013f: Expected O, but got Ref
		//IL_015d: Expected O, but got I
		//IL_01d1: Expected O, but got I
		//IL_022b: Expected O, but got I
		//IL_024e: Expected O, but got I
		//IL_0270: Expected O, but got I
		//IL_0297: Expected O, but got I
		//IL_02df: Expected O, but got I
		bool flag = _LinkedFactories == null;
		Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(object)this;
		if (!flag)
		{
			List<AccessoriesFactory>.Enumerator enumerator = default(List<AccessoriesFactory>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = 0;
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			bool flag2 = loadedDlc == null;
			dictionary = null;
			if (!flag2)
			{
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
				object obj2 = default(object);
				while (enumerator2.MoveNext())
				{
					bool flag3 = obj2 == null;
					Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&enumerator2);
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ stack_-68+48]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ stack_-68+48]");
						if ((nint)0 == 0)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rdi_v16+10]");
						if ((nint)0 == 0)
						{
							continue;
						}
						bool flag4 = obj2 == null;
						dictionary2 = (Dictionary<System.Int32Enum, object>)(object)typeof(UnityEngine.Object);
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ stack_-68+48]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ stack_-68+48]");
							bool flag5 = (nint)0 == 0;
							dictionary2 = (Dictionary<System.Int32Enum, object>)(object)typeof(UnityEngine.Object);
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v47+58]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v47+58]");
								dictionary2 = (Dictionary<System.Int32Enum, object>)0;
								if (!flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v47+58]");
									int num = ((Dictionary<System.Int32Enum, object>)0).FindEntry((System.Int32Enum)accessoryType);
									if (!flag6)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ stack_-68+48]");
										object obj5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ stack_-68+48]");
										bool flag7 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v47+58]");
										dictionary2 = (Dictionary<System.Int32Enum, object>)0;
										if (!flag7)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v52+58]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v52+58]");
												return (Accessory)((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)accessoryType);
											}
											throw new NullReferenceException();
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
					throw new NullReferenceException();
				}
				bool flag8 = _accessories == null;
				dictionary = (Dictionary<System.Int32Enum, object>)(object)_accessories;
				if (!flag8)
				{
					int num2 = ((Dictionary<System.Int32Enum, object>)(object)_accessories).FindEntry((System.Int32Enum)accessoryType);
					if (num2 < 0)
					{
						return _defaultAccessory;
					}
					dictionary = (Dictionary<System.Int32Enum, object>)(object)_accessories;
					if (_accessories != null)
					{
						return (Accessory)((Dictionary<System.Int32Enum, object>)(object)_accessories).get_Item((System.Int32Enum)accessoryType);
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe List<string> ValidateReferences()
	{
		//IL_0027: Expected O, but got I4
		//IL_006c: Expected O, but got Ref
		//IL_0087: Expected O, but got Ref
		List<string> list = new List<string>();
		if (_accessories != null)
		{
			Dictionary<WeaponType, Accessory>.Enumerator enumerator = default(Dictionary<WeaponType, Accessory>.Enumerator);
			IntPtr intPtr = default(IntPtr);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				object obj = 0;
				if (false)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rbx_v10+10]");
					if ((nint)0 != 0)
					{
						continue;
					}
				}
				string item = ((Enum)(&intPtr)).ToString();
				bool flag = list == null;
				Enum obj2 = (Enum)(&intPtr);
				if (!flag)
				{
					list.Add(item);
					continue;
				}
				throw new NullReferenceException();
			}
			if (_LinkedFactories != null)
			{
				List<AccessoriesFactory>.Enumerator enumerator2 = default(List<AccessoriesFactory>.Enumerator);
				while (enumerator2.MoveNext())
				{
					AccessoriesFactory accessoriesFactory = null;
				}
				return list;
			}
		}
		throw new NullReferenceException();
	}

	public AccessoriesFactory()
	{
		AccessoryDictionary accessories = (AccessoryDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		_accessories = accessories;
		((ScriptableObject)this)._002Ector();
	}
}
