using System;
using UnityEngine;

public class LuaModulePropertyWrapper
{
	public static bool GetPropertyBoolCallback(IntPtr propertyPtr)
	{
		return false;
	}

	public static ToLuaString GetPropertyStringCallback(IntPtr propertyPtr)
	{
		return default(ToLuaString);
	}

	public static float GetPropertyNumberCallback(IntPtr propertyPtr)
	{
		return 0f;
	}

	public static LuaSelection GetPropertySelectionCallback(IntPtr propertyPtr)
	{
		return default(LuaSelection);
	}

	public static uint GetPropertyModuleIdCallback(IntPtr propertyPtr)
	{
		return 0u;
	}

	public static LuaAssetReference GetPropertyAssetCallback(IntPtr propertyPtr)
	{
		return null;
	}

	public static Color GetPropertyColorCallback(IntPtr propertyPtr)
	{
		return default(Color);
	}

	public static Vector2 GetPropertyVector2Callback(IntPtr propertyPtr)
	{
		return default(Vector2);
	}

	public static Vector3 GetPropertyVector3Callback(IntPtr propertyPtr)
	{
		return default(Vector3);
	}

	public static ToLuaInputSource GetPropertyInputTypeCallback(IntPtr propertyPtr)
	{
		return null;
	}

	public static void SetPropertyBoolCallback(IntPtr propertyPtr, bool value)
	{
	}

	public static void SetPropertyStringCallback(IntPtr propertyPtr, FromLuaString value)
	{
	}

	public static void SetPropertyNumberCallback(IntPtr propertyPtr, float value)
	{
	}

	public static void SetPropertySelectionCallback(IntPtr propertyPtr, LuaSelection value)
	{
	}

	public static void SetPropertyModuleIdCallback(IntPtr propertyPtr, uint value)
	{
	}

	public static void SetPropertyAssetCallback(IntPtr propertyPtr, LuaAssetReference value)
	{
	}

	public static void SetPropertyColorCallback(IntPtr propertyPtr, Color value)
	{
	}

	public static void SetPropertyVector2Callback(IntPtr propertyPtr, Vector2 value)
	{
	}

	public static void SetPropertyVector3Callback(IntPtr propertyPtr, Vector3 value)
	{
	}

	public static void SetPropertyInputSourceCallback(IntPtr propertyPtr, FromLuaInputSource value)
	{
	}

	public static bool GetPropertyArrayBoolCallback(IntPtr propertyPtr, int index)
	{
		return false;
	}

	public static ToLuaString GetPropertyArrayStringCallback(IntPtr propertyPtr, int index)
	{
		return default(ToLuaString);
	}

	public static float GetPropertyArrayNumberCallback(IntPtr propertyPtr, int index)
	{
		return 0f;
	}

	public static LuaSelection GetPropertyArraySelectionCallback(IntPtr propertyPtr, int index)
	{
		return default(LuaSelection);
	}

	public static uint GetPropertyArrayModuleIdCallback(IntPtr propertyPtr, int index)
	{
		return 0u;
	}

	public static LuaAssetReference GetPropertyArrayAssetCallback(IntPtr propertyPtr, int index)
	{
		return null;
	}

	public static Color GetPropertyArrayColorCallback(IntPtr propertyPtr, int index)
	{
		return default(Color);
	}

	public static Vector2 GetPropertyArrayVector2Callback(IntPtr propertyPtr, int index)
	{
		return default(Vector2);
	}

	public static Vector3 GetPropertyArrayVector3Callback(IntPtr propertyPtr, int index)
	{
		return default(Vector3);
	}

	public static ToLuaInputSource GetPropertyArrayInputSourceCallback(IntPtr propertyPtr, int index)
	{
		return null;
	}

	public static void SetPropertyArrayBoolCallback(IntPtr propertyPtr, int index, uint value)
	{
	}

	public static void SetPropertyArrayStringCallback(IntPtr propertyPtr, int index, FromLuaString value)
	{
	}

	public static void SetPropertyArrayNumberCallback(IntPtr propertyPtr, int index, float value)
	{
	}

	public static void SetPropertyArraySelectionCallback(IntPtr propertyPtr, int index, LuaSelection value)
	{
	}

	public static void SetPropertyArrayModuleIdCallback(IntPtr propertyPtr, int index, uint value)
	{
	}

	public static void SetPropertyArrayAssetCallback(IntPtr propertyPtr, int index, LuaAssetReference value)
	{
	}

	public static void SetPropertyArrayColorCallback(IntPtr propertyPtr, int index, Color value)
	{
	}

	public static void SetPropertyArrayVector2Callback(IntPtr propertyPtr, int index, Vector2 value)
	{
	}

	public static void SetPropertyArrayVector3Callback(IntPtr propertyPtr, int index, Vector3 value)
	{
	}

	public static void SetPropertyArrayInputSourceCallback(IntPtr propertyPtr, int index, FromLuaInputSource value)
	{
	}

	public static int GetPropertyArrayLengthCallback(IntPtr propertyPtr)
	{
		return 0;
	}

	public static bool GetPropertyDictionaryBoolCallback(IntPtr propertyPtr, FromLuaString key)
	{
		return false;
	}

	public static ToLuaString GetPropertyDictionaryStringCallback(IntPtr propertyPtr, FromLuaString key)
	{
		return default(ToLuaString);
	}

	public static float GetPropertyDictionaryNumberCallback(IntPtr propertyPtr, FromLuaString key)
	{
		return 0f;
	}

	public static LuaSelection GetPropertyDictionarySelectionCallback(IntPtr propertyPtr, FromLuaString key)
	{
		return default(LuaSelection);
	}

	public static LuaAssetReference GetPropertyDictionaryAssetCallback(IntPtr propertyPtr, FromLuaString key)
	{
		return null;
	}

	public static Color GetPropertyDictionaryColorCallback(IntPtr propertyPtr, FromLuaString key)
	{
		return default(Color);
	}

	public static Vector2 GetPropertyDictionaryVector2Callback(IntPtr propertyPtr, FromLuaString key)
	{
		return default(Vector2);
	}

	public static Vector3 GetPropertyDictionaryVector3Callback(IntPtr propertyPtr, FromLuaString key)
	{
		return default(Vector3);
	}

	public static ToLuaInputSource GetPropertyDictionaryInputSourceCallback(IntPtr propertyPtr, FromLuaString key)
	{
		return null;
	}

	public static void SetPropertyDictionaryBoolCallback(IntPtr propertyPtr, FromLuaString key, uint value)
	{
	}

	public static void SetPropertyDictionaryStringCallback(IntPtr propertyPtr, FromLuaString key, FromLuaString value)
	{
	}

	public static void SetPropertyDictionaryNumberCallback(IntPtr propertyPtr, FromLuaString key, float value)
	{
	}

	public static void SetPropertyDictionarySelectionCallback(IntPtr propertyPtr, FromLuaString key, LuaSelection value)
	{
	}

	public static void SetPropertyDictionaryAssetCallback(IntPtr propertyPtr, FromLuaString key, LuaAssetReference value)
	{
	}

	public static void SetPropertyDictionaryColorCallback(IntPtr propertyPtr, FromLuaString key, Color value)
	{
	}

	public static void SetPropertyDictionaryVector2Callback(IntPtr propertyPtr, FromLuaString key, Vector2 value)
	{
	}

	public static void SetPropertyDictionaryVector3Callback(IntPtr propertyPtr, FromLuaString key, Vector3 value)
	{
	}

	public static void SetPropertyDictionaryInputSourceCallback(IntPtr propertyPtr, FromLuaString key, FromLuaInputSource value)
	{
	}

	public static int GetPropertyDictionaryCountCallback(IntPtr propertyPtr)
	{
		return 0;
	}

	public static LuaNativeTable GetPropertyDictionaryKeysCallback(IntPtr propertyPtr)
	{
		return default(LuaNativeTable);
	}

	public static bool GetPropertyMatrix2DBoolCallback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return false;
	}

	public static ToLuaString GetPropertyMatrix2DStringCallback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return default(ToLuaString);
	}

	public static float GetPropertyMatrix2DNumberCallback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return 0f;
	}

	public static LuaSelection GetPropertyMatrix2DSelectionCallback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return default(LuaSelection);
	}

	public static Color GetPropertyMatrix2DColorCallback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return default(Color);
	}

	public static Vector2 GetPropertyMatrix2DVector2Callback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return default(Vector2);
	}

	public static Vector3 GetPropertyMatrix2DVector3Callback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return default(Vector3);
	}

	public static ToLuaInputSource GetPropertyMatrix2DInputSourceCallback(IntPtr propertyPtr, int indexX, int indexY)
	{
		return null;
	}

	public static void SetPropertyMatrix2DBoolCallback(IntPtr propertyPtr, int indexX, int indexY, uint value)
	{
	}

	public static void SetPropertyMatrix2DStringCallback(IntPtr propertyPtr, int indexX, int indexY, FromLuaString value)
	{
	}

	public static void SetPropertyMatrix2DNumberCallback(IntPtr propertyPtr, int indexX, int indexY, float value)
	{
	}

	public static void SetPropertyMatrix2DSelectionCallback(IntPtr propertyPtr, int indexX, int indexY, LuaSelection value)
	{
	}

	public static void SetPropertyMatrix2DColorCallback(IntPtr propertyPtr, int indexX, int indexY, Color value)
	{
	}

	public static void SetPropertyMatrix2DVector2Callback(IntPtr propertyPtr, int indexX, int indexY, Vector2 value)
	{
	}

	public static void SetPropertyMatrix2DVector3Callback(IntPtr propertyPtr, int indexX, int indexY, Vector3 value)
	{
	}

	public static void SetPropertyMatrix2DInputSourceCallback(IntPtr propertyPtr, int indexX, int indexY, FromLuaInputSource value)
	{
	}

	public static int GetPropertyMatrix2DWidthCallback(IntPtr propertyPtr)
	{
		return 0;
	}

	public static int GetPropertyMatrix2DHeightCallback(IntPtr propertyPtr)
	{
		return 0;
	}
}
