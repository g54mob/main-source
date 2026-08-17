using System;
using System.IO;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class UIAnimations : ScriptableObject
{
	private const string FILE_NAME = "_UIAnimations";

	public const string DEFAULT_DATABASE_NAME = "Uncategorized";

	public const string DEFAULT_PRESET_NAME = "Default";

	private static UIAnimations s_instance;

	public UIAnimationsDatabase Show;

	public UIAnimationsDatabase Hide;

	public UIAnimationsDatabase Loop;

	public UIAnimationsDatabase Punch;

	public UIAnimationsDatabase State;

	public static UIAnimations Instance
	{
		get
		{
			UIAnimations uIAnimations = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uIAnimations).m_CachedPtr == (IntPtr)0)
			{
				string path = Path.Combine("UIAnimations", "_UIAnimations");
				UIAnimations uIAnimations2 = Resources.Load<UIAnimations>(path);
				s_instance = uIAnimations2;
				UIAnimations uIAnimations3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)uIAnimations3).m_CachedPtr == (IntPtr)0)
				{
					UIAnimations uIAnimations4 = s_instance;
					if ((object)s_instance == null || ((UnityEngine.Object)uIAnimations4).m_CachedPtr == (IntPtr)0)
					{
						goto IL_0151;
					}
					if ((object)s_instance == null)
					{
						goto IL_0157;
					}
					s_instance.SearchForUnregisteredDatabases(saveAssets: true);
				}
				if ((object)s_instance == null)
				{
					goto IL_0157;
				}
				s_instance.Initialize();
			}
			goto IL_0151;
			IL_0157:
			return (UIAnimations)(object)new NullReferenceException();
			IL_0151:
			return s_instance;
		}
	}

	public UIAnimationDatabase CreateDatabase(AnimationType databaseType, string newPresetCategory, bool saveAssets = false)
	{
		//IL_0057: Expected O, but got I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		UIAnimationDatabase uIAnimationDatabase = ScriptableObject.CreateInstance<UIAnimationDatabase>();
		if ((object)uIAnimationDatabase != null)
		{
			uIAnimationDatabase.DatabaseName = newPresetCategory;
			((UnityEngine.Object)uIAnimationDatabase).SetName(uIAnimationDatabase.DatabaseName);
			uIAnimationDatabase.DataType = databaseType;
			uIAnimationDatabase.RefreshDatabase(saveAssets: false);
			object obj = databaseType - 1;
			bool flag = databaseType == AnimationType.Show;
			UIAnimationsDatabase uIAnimationsDatabase;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						object obj4 = obj3 - 1;
						if (!flag)
						{
							if ((nint)obj4 != 1)
							{
								goto IL_0158;
							}
							uIAnimationsDatabase = State;
						}
						else
						{
							uIAnimationsDatabase = Punch;
						}
					}
					else
					{
						uIAnimationsDatabase = Loop;
					}
				}
				else
				{
					uIAnimationsDatabase = Hide;
				}
			}
			else
			{
				uIAnimationsDatabase = Show;
			}
			if (uIAnimationsDatabase != null)
			{
				bool flag2 = uIAnimationsDatabase.AddUIAnimationDatabase(uIAnimationDatabase);
				DoozyUtils.SetDirty(this, saveAssets);
				return uIAnimationDatabase;
			}
		}
		goto IL_0158;
		IL_0158:
		return (UIAnimationDatabase)(object)new NullReferenceException();
	}

	public UIAnimationsDatabase Get(AnimationType databaseType)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		object obj = databaseType - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				object obj4 = obj3 - 1;
				if (obj2 == null)
				{
					object obj5 = obj4 - 1;
					if (obj2 == null)
					{
						if ((nint)obj5 != 1)
						{
							return null;
						}
						return State;
					}
					return Punch;
				}
				return Loop;
			}
			return Hide;
		}
		return Show;
	}

	public UIAnimationData Get(AnimationType databaseType, string databaseName, string animationName)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		object obj = databaseType - 1;
		object obj2 = default(object);
		UIAnimationsDatabase uIAnimationsDatabase;
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				object obj4 = obj3 - 1;
				if (obj2 == null)
				{
					object obj5 = obj4 - 1;
					if (obj2 == null)
					{
						if ((nint)obj5 != 1)
						{
							goto IL_011f;
						}
						uIAnimationsDatabase = State;
					}
					else
					{
						uIAnimationsDatabase = Punch;
					}
				}
				else
				{
					uIAnimationsDatabase = Loop;
				}
			}
			else
			{
				uIAnimationsDatabase = Hide;
			}
		}
		else
		{
			uIAnimationsDatabase = Show;
		}
		if (uIAnimationsDatabase != null)
		{
			UIAnimationDatabase uIAnimationDatabase = uIAnimationsDatabase.Get(databaseName);
			if ((object)uIAnimationDatabase != null)
			{
				return uIAnimationDatabase.Get(animationName);
			}
		}
		goto IL_011f;
		IL_011f:
		return (UIAnimationData)(object)new NullReferenceException();
	}

	public UIAnimationDatabase Get(AnimationType databaseType, string databaseName)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		object obj = databaseType - 1;
		object obj2 = default(object);
		UIAnimationsDatabase uIAnimationsDatabase;
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				object obj4 = obj3 - 1;
				if (obj2 == null)
				{
					object obj5 = obj4 - 1;
					if (obj2 == null)
					{
						if ((nint)obj5 != 1)
						{
							goto IL_00f1;
						}
						uIAnimationsDatabase = State;
					}
					else
					{
						uIAnimationsDatabase = Punch;
					}
				}
				else
				{
					uIAnimationsDatabase = Loop;
				}
			}
			else
			{
				uIAnimationsDatabase = Hide;
			}
		}
		else
		{
			uIAnimationsDatabase = Show;
		}
		if (uIAnimationsDatabase != null)
		{
			return uIAnimationsDatabase.Get(databaseName);
		}
		goto IL_00f1;
		IL_00f1:
		return (UIAnimationDatabase)(object)new NullReferenceException();
	}

	public void Initialize()
	{
		//IL_0415: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		//IL_022b: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		bool flag = Show != null;
		object obj = 0;
		if (!flag)
		{
			UIAnimationsDatabase show = new UIAnimationsDatabase(AnimationType.Show);
			Show = show;
			obj = 1;
		}
		UIAnimationsDatabase show2 = Show;
		if (show2.DatabaseType != AnimationType.Show)
		{
			show2.DatabaseType = AnimationType.Show;
			obj = 1;
		}
		if (Hide == null)
		{
			UIAnimationsDatabase hide = new UIAnimationsDatabase(AnimationType.Hide);
			Hide = hide;
			obj = 1;
		}
		UIAnimationsDatabase hide2 = Hide;
		if (hide2.DatabaseType != AnimationType.Hide)
		{
			hide2.DatabaseType = AnimationType.Hide;
			obj = 1;
		}
		if (Loop == null)
		{
			UIAnimationsDatabase loop = new UIAnimationsDatabase(AnimationType.Loop);
			Loop = loop;
			obj = 1;
		}
		UIAnimationsDatabase loop2 = Loop;
		if (loop2.DatabaseType != AnimationType.Loop)
		{
			loop2.DatabaseType = AnimationType.Loop;
			obj = 1;
		}
		if (Punch == null)
		{
			UIAnimationsDatabase punch = new UIAnimationsDatabase(AnimationType.Punch);
			Punch = punch;
			obj = 1;
		}
		UIAnimationsDatabase punch2 = Punch;
		if (punch2.DatabaseType != AnimationType.Punch)
		{
			punch2.DatabaseType = AnimationType.Punch;
			obj = 1;
		}
		if (State == null)
		{
			UIAnimationsDatabase state = new UIAnimationsDatabase(AnimationType.State);
			State = state;
			obj = 1;
		}
		UIAnimationsDatabase state2 = State;
		if (state2.DatabaseType != AnimationType.State)
		{
			state2.DatabaseType = AnimationType.State;
			obj = 1;
		}
		Show.RemoveEmptyDatabases();
		Show.AddTheDefaultUIAnimationDatabase();
		Show.RenameAssetFileNamesToReflectDatabaseNames();
		Show.Sort();
		Show.UpdateDatabaseNames();
		Show.UpdateDatabases();
		Hide.RemoveEmptyDatabases();
		Hide.AddTheDefaultUIAnimationDatabase();
		Hide.RenameAssetFileNamesToReflectDatabaseNames();
		Hide.Sort();
		Hide.UpdateDatabaseNames();
		Hide.UpdateDatabases();
		Loop.RemoveEmptyDatabases();
		Loop.AddTheDefaultUIAnimationDatabase();
		Loop.RenameAssetFileNamesToReflectDatabaseNames();
		Loop.Sort();
		Loop.UpdateDatabaseNames();
		Loop.UpdateDatabases();
		Punch.RemoveEmptyDatabases();
		Punch.AddTheDefaultUIAnimationDatabase();
		Punch.RenameAssetFileNamesToReflectDatabaseNames();
		Punch.Sort();
		Punch.UpdateDatabaseNames();
		Punch.UpdateDatabases();
		State.RemoveEmptyDatabases();
		State.AddTheDefaultUIAnimationDatabase();
		State.RenameAssetFileNamesToReflectDatabaseNames();
		State.Sort();
		State.UpdateDatabaseNames();
		State.UpdateDatabases();
		if (obj != null)
		{
			DoozyUtils.SetDirty(this, saveAssets: true);
		}
	}

	public void SearchForUnregisteredDatabases(bool saveAssets)
	{
		//IL_03b5: Expected I, but got O
		//IL_0068: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_01d2: Expected O, but got I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		Initialize();
		UIAnimationDatabase[] array = Resources.LoadAll<UIAnimationDatabase>("");
		if (array != null && array.Length != 0)
		{
			object obj = 0;
			object obj2 = 0;
			for (; (nint)obj < array.Length; obj++)
			{
				UIAnimationDatabase uIAnimationDatabase = array[obj];
				bool flag = (object)array[obj] == null;
				object obj3 = uIAnimationDatabase.DataType - 1;
				UIAnimationsDatabase uIAnimationsDatabase;
				if (!flag)
				{
					object obj4 = obj3 - 1;
					if (!flag)
					{
						object obj5 = obj4 - 1;
						if (!flag)
						{
							object obj6 = obj5 - 1;
							if (!flag)
							{
								if ((nint)obj6 != 1)
								{
									continue;
								}
								uIAnimationsDatabase = State;
							}
							else
							{
								uIAnimationsDatabase = Punch;
							}
						}
						else
						{
							uIAnimationsDatabase = Loop;
						}
					}
					else
					{
						uIAnimationsDatabase = Hide;
					}
				}
				else
				{
					uIAnimationsDatabase = Show;
				}
				if (uIAnimationsDatabase != null && !uIAnimationsDatabase.Contains(array[obj]))
				{
					bool flag2 = uIAnimationsDatabase.AddUIAnimationDatabase(array[obj]);
					obj2 = 1;
				}
			}
			if (obj2 != null)
			{
				Show.RemoveEmptyDatabases();
				Show.AddTheDefaultUIAnimationDatabase();
				Show.RenameAssetFileNamesToReflectDatabaseNames();
				Show.Sort();
				Show.UpdateDatabaseNames();
				Show.UpdateDatabases();
				Hide.RemoveEmptyDatabases();
				Hide.AddTheDefaultUIAnimationDatabase();
				Hide.RenameAssetFileNamesToReflectDatabaseNames();
				Hide.Sort();
				Hide.UpdateDatabaseNames();
				Hide.UpdateDatabases();
				Loop.RemoveEmptyDatabases();
				Loop.AddTheDefaultUIAnimationDatabase();
				Loop.RenameAssetFileNamesToReflectDatabaseNames();
				Loop.Sort();
				Loop.UpdateDatabaseNames();
				Loop.UpdateDatabases();
				Punch.RemoveEmptyDatabases();
				Punch.AddTheDefaultUIAnimationDatabase();
				Punch.RenameAssetFileNamesToReflectDatabaseNames();
				Punch.Sort();
				Punch.UpdateDatabaseNames();
				Punch.UpdateDatabases();
				State.RemoveEmptyDatabases();
				State.AddTheDefaultUIAnimationDatabase();
				State.RenameAssetFileNamesToReflectDatabaseNames();
				State.Sort();
				State.UpdateDatabaseNames();
				State.UpdateDatabases();
				DoozyUtils.SetDirty(this, saveAssets);
			}
		}
		else
		{
			nint num = (nint)typeof(DoozyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v6 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public static UIAnimation LoadPreset(AnimationType animationType, string presetCategory, string presetName)
	{
		UIAnimations instance = Instance;
		if ((object)instance != null)
		{
			UIAnimationData uIAnimationData = instance.Get(animationType, presetCategory, presetName);
			if ((object)uIAnimationData == null || ((UnityEngine.Object)uIAnimationData).m_CachedPtr == (IntPtr)0)
			{
				return null;
			}
			if (uIAnimationData.Animation != null)
			{
				return uIAnimationData.Animation.Copy();
			}
		}
		return (UIAnimation)(object)new NullReferenceException();
	}
}
