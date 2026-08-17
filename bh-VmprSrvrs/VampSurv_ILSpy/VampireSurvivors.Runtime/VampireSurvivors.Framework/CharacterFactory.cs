using System;
using System.Collections.Generic;
using System.IO;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Framework;

public class CharacterFactory : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class CharacterDictionary : UnitySerializedDictionary<CharacterType, VampireSurvivors.Objects.Characters.CharacterController>
	{
		public CharacterDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class CharacterRefDictionary : UnitySerializedDictionary<CharacterType, PrefabRefData>
	{
		public CharacterRefDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class PrefabRefData
	{
		private AssetReferenceT<GameObject> _PrefabRef;

		public AssetReferenceT<GameObject> PrefabRef
		{
			get
			{
				return _PrefabRef;
			}
			set
			{
				_PrefabRef = value;
			}
		}
	}

	[Serializable]
	public class PrefabPathData
	{
		private string _PrefabPath;

		public string PrefabPath
		{
			get
			{
				return _PrefabPath;
			}
			set
			{
				_PrefabPath = value;
			}
		}

		public string PathWithoutExtension => Path.ChangeExtension(_PrefabPath, null);

		public string PathWithExtension => _PrefabPath;
	}

	private CharacterDictionary _characters;

	private VampireSurvivors.Objects.Characters.CharacterController _defaultCharacterController;

	private CharacterRefDictionary _CharacterRefs;

	private List<CharacterFactory> _LinkedFactories;

	public unsafe VampireSurvivors.Objects.Characters.CharacterController GetCharacterPrefab(CharacterType characterType)
	{
		//IL_008f: Expected O, but got I4
		//IL_0097: Expected O, but got Ref
		//IL_0387: Expected O, but got I4
		//IL_038f: Expected O, but got Ref
		if (_characters != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_characters).FindEntry((System.Int32Enum)characterType);
			if (_characters == null)
			{
				Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
				if (loadedDlc != null)
				{
					Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
					if (enumerator.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						object obj = 0;
						Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = (Dictionary<DlcType, BundleManifestData>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					if (_LinkedFactories != null)
					{
						List<CharacterFactory>.Enumerator enumerator3 = default(List<CharacterFactory>.Enumerator);
						if (enumerator3.MoveNext())
						{
							object obj2 = 0;
							List<CharacterFactory>.Enumerator enumerator4 = (List<CharacterFactory>.Enumerator)(&enumerator3);
							throw new NullReferenceException();
						}
						return _defaultCharacterController;
					}
				}
			}
			else if (_characters != null)
			{
				return (VampireSurvivors.Objects.Characters.CharacterController)((Dictionary<System.Int32Enum, object>)(object)_characters).get_Item((System.Int32Enum)characterType);
			}
		}
		throw new NullReferenceException();
	}

	public bool ContainsCharacter(CharacterType characterType)
	{
		if (_CharacterRefs == null)
		{
			return false;
		}
		int num = ((Dictionary<System.Int32Enum, object>)(object)_CharacterRefs).FindEntry((System.Int32Enum)characterType);
		int num2 = num >> 31;
		return (byte)(num2 ^ 1) != 0;
	}

	public unsafe List<string> ValidateReferences()
	{
		//IL_0027: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00da: Expected O, but got I
		//IL_006c: Expected O, but got Ref
		//IL_0087: Expected O, but got Ref
		//IL_00ef: Expected O, but got I
		//IL_0162: Expected O, but got Ref
		//IL_017d: Expected O, but got Ref
		List<string> list = new List<string>();
		if (_characters != null)
		{
			Dictionary<CharacterType, VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(Dictionary<CharacterType, VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			IntPtr intPtr = default(IntPtr);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				object obj = 0;
				if (false)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rbx_v16+10]");
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
					nint num = 0;
					continue;
				}
				throw new NullReferenceException();
			}
			if (_CharacterRefs != null)
			{
				Dictionary<CharacterType, PrefabRefData>.Enumerator enumerator2 = default(Dictionary<CharacterType, PrefabRefData>.Enumerator);
				object obj6 = default(object);
				IntPtr intPtr2 = default(IntPtr);
				while (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj3 = 0;
					Enum obj2 = (Enum)0;
					if (false)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v59+10]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v59+10]");
						bool flag2 = (nint)0 == 0;
						obj2 = (Enum)(object)typeof(AddressableLoader);
						if (!flag2)
						{
							object obj5 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1259 @ rdx_v21+248] (should have been resolved before IL gen)");
							if (obj6 == null)
							{
								string item2 = ((Enum)(&intPtr2)).ToString();
								bool flag3 = list == null;
								obj2 = (Enum)(&intPtr2);
								if (flag3)
								{
									throw new NullReferenceException();
								}
								list.Add(item2);
								nint num = 0;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (_LinkedFactories != null)
				{
					List<CharacterFactory>.Enumerator enumerator3 = default(List<CharacterFactory>.Enumerator);
					while (enumerator3.MoveNext())
					{
						CharacterFactory characterFactory = null;
					}
					return list;
				}
			}
		}
		throw new NullReferenceException();
	}

	public CharacterFactory()
	{
		CharacterDictionary characters = (CharacterDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		_characters = characters;
		_CharacterRefs = (CharacterRefDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		((ScriptableObject)this)._002Ector();
	}
}
