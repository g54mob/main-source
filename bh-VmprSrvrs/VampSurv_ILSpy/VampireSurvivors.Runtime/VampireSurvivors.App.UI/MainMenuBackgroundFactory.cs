using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.UI;

public class MainMenuBackgroundFactory : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class BackgroundDictionary : UnitySerializedDictionary<AdventureType, GameObject>
	{
		public BackgroundDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class BackgroundRefsDictionary : UnitySerializedDictionary<AdventureType, PrefabRefData>
	{
		public BackgroundRefsDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class PrefabRefData
	{
		private AssetReference _PrefabRef;

		public AssetReference PrefabRef
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

	private BackgroundDictionary _Backgrounds;

	private BackgroundRefsDictionary _BackgroundRefs;

	private List<MainMenuBackgroundFactory> _LinkedFactories;

	private unsafe GameObject LoadFromAddressables(DlcType? dlcType, AdventureType adventureType, MainMenuBackgroundFactory factory)
	{
		//IL_0063: Expected O, but got Ref
		if ((object)factory != null && factory._BackgroundRefs != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)factory._BackgroundRefs).get_Item((System.Int32Enum)adventureType);
			if (obj != null)
			{
				object obj2 = default(object);
				string text = ((Enum)(&obj2)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F948D0");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject result = null;
					if (!flag)
					{
						result = gameObject;
					}
					return result;
				}
				return null;
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public unsafe GameObject GetBackgroundForAdventureType(AdventureType adventureType)
	{
		//IL_01a9: Expected O, but got I4
		//IL_01b1: Expected O, but got Ref
		//IL_04b9: Expected O, but got I4
		bool flag = _LinkedFactories == null;
		Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(object)this;
		if (!flag)
		{
			List<MainMenuBackgroundFactory>.Enumerator enumerator = default(List<MainMenuBackgroundFactory>.Enumerator);
			while (enumerator.MoveNext())
			{
				MainMenuBackgroundFactory mainMenuBackgroundFactory = null;
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			bool flag2 = loadedDlc == null;
			dictionary = null;
			if (!flag2)
			{
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj = 0;
					Dictionary<DlcType, BundleManifestData>.Enumerator enumerator3 = (Dictionary<DlcType, BundleManifestData>.Enumerator)(&enumerator2);
					throw new NullReferenceException();
				}
				dictionary = (Dictionary<System.Int32Enum, object>)(object)_BackgroundRefs;
				if (_BackgroundRefs != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)_BackgroundRefs).FindEntry((System.Int32Enum)adventureType);
					if (num >= 0)
					{
						return LoadFromAddressables((DlcType?)(object)0, adventureType, this);
					}
					dictionary = (Dictionary<System.Int32Enum, object>)(object)_Backgrounds;
					if (_Backgrounds != null)
					{
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)_Backgrounds).FindEntry((System.Int32Enum)adventureType);
						if (num2 < 0)
						{
							return null;
						}
						bool flag3 = _Backgrounds == null;
						dictionary = (Dictionary<System.Int32Enum, object>)(object)_Backgrounds;
						if (!flag3)
						{
							return (GameObject)((Dictionary<System.Int32Enum, object>)(object)_Backgrounds).get_Item((System.Int32Enum)adventureType);
						}
					}
				}
			}
		}
		Dictionary<System.Int32Enum, object> dictionary2 = dictionary;
		throw new NullReferenceException();
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
		if (_Backgrounds != null)
		{
			Dictionary<AdventureType, GameObject>.Enumerator enumerator = default(Dictionary<AdventureType, GameObject>.Enumerator);
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
			if (_BackgroundRefs != null)
			{
				Dictionary<AdventureType, PrefabRefData>.Enumerator enumerator2 = default(Dictionary<AdventureType, PrefabRefData>.Enumerator);
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
					List<MainMenuBackgroundFactory>.Enumerator enumerator3 = default(List<MainMenuBackgroundFactory>.Enumerator);
					while (enumerator3.MoveNext())
					{
						MainMenuBackgroundFactory mainMenuBackgroundFactory = null;
					}
					return list;
				}
			}
		}
		throw new NullReferenceException();
	}

	public MainMenuBackgroundFactory()
	{
		BackgroundDictionary backgrounds = (BackgroundDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		_Backgrounds = backgrounds;
		_BackgroundRefs = (BackgroundRefsDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		((ScriptableObject)this)._002Ector();
	}
}
