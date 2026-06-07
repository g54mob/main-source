using System;
using System.Linq;
using UnityEngine;

public class MockPreferencePersistence : IPreferencesPersistence
{
	private readonly IPreferencesStore preferencesStore;

	private readonly PreferencesExclusivity exclusivity;

	public int WrittenPreferencesVersion => 8;

	public MockPreferencePersistence(IPreferencesStore preferencesStore, PreferencesExclusivity exclusivity)
	{
		this.preferencesStore = preferencesStore;
		this.exclusivity = exclusivity;
	}

	public void PurgeWrittenPreferences()
	{
	}

	public void CreateBackupFile(string fileSuffix)
	{
	}

	public string GetIncompatiblePreferenceRawValue(string key)
	{
		return null;
	}

	public void DeleteIncompatiblePreference(string key)
	{
	}

	public bool ReadPreferences()
	{
		object[] overrideCollection = MakePlayerPrefCollection();
		preferencesStore.OverridePreferencesExternally(overrideCollection);
		return true;
	}

	public void WritePreferences()
	{
		preferencesStore.RequestAllPreferences();
		Debug.LogWarning("Write preferences requested. Mock preference doesn't write anything.");
	}

	private object[] MakePlayerPrefCollection()
	{
		object[] array = new object[Enum.GetValues(typeof(Preferences)).GetLength(0)];
		if (exclusivity == PreferencesExclusivity.VR)
		{
			array[10] = RndB();
			array[1] = RndB();
			array[9] = RndF(0f, 2f);
			array[27] = RndB();
			array[28] = RndI(0, 3);
			array[2] = RndB();
			array[7] = RndF(0.5f, 3f);
			array[5] = RndI(0, 5);
			array[11] = RndB();
			array[12] = RndI(0, 4);
			array[13] = RndB();
			array[0] = RndB();
			array[8] = RndF(0.5f, 5f);
			array[3] = RndB();
			array[14] = RndF(1.4f, 1.9f);
			array[15] = RndF(-0.1f, 0.1f);
			array[19] = RndB();
		}
		else if (exclusivity == PreferencesExclusivity.NonVR)
		{
			Vector2Int[] array2 = (from res in Screen.resolutions
				group res by new { res.width, res.height } into g
				select g.FirstOrDefault() into res
				select new Vector2Int(res.width, res.height) into resWidthHeight
				where resWidthHeight.x >= 800
				select resWidthHeight).ToArray();
			int num = RndI(0, array2.Length);
			array[55] = array2[num].x;
			array[56] = array2[num].y;
			array[20] = RndB();
			array[22] = RndF(0f, 3f);
			array[23] = RndI(0, 3);
		}
		array[41] = RndI(0, 4);
		array[47] = RndI(0, 3);
		array[49] = RndI(0, 3);
		array[36] = RndB();
		array[34] = RndB();
		array[35] = RndB();
		array[62] = RndF(0f, 1f);
		array[42] = RndI(0, 3);
		array[43] = RndI(0, 3);
		array[46] = RndI(0, 3);
		array[29] = RndI(0, 2);
		array[30] = RndB();
		return array;
		bool RndB()
		{
			return UnityEngine.Random.Range(0, 100) > 50;
		}
		float RndF(float a, float b)
		{
			return UnityEngine.Random.Range(a, b);
		}
		int RndI(int a, int b)
		{
			return UnityEngine.Random.Range(a, b);
		}
	}

	public bool LoadedAsDefaultValue(Preferences preference)
	{
		return true;
	}
}
