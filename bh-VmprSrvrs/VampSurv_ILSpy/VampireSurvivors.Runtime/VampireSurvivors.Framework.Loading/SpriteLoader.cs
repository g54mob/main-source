using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.Loading;

public static class SpriteLoader
{
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public bool isSuccess;

		public string cacheGroupName;

		public string textureName;

		public Action<bool> onComplete;

		internal void _003CLoadTexture_003Eb__0(bool success)
		{
			if (success)
			{
				isSuccess = true;
				AddressableCache.SaveTexture(cacheGroupName, textureName);
			}
			Action<bool> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v88 @ rax_v3 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string cacheGroupName;

		public string textureName;

		public Action<bool> onComplete;

		internal void _003CLoadTextureAsync_003Eb__0(bool success)
		{
			if (success)
			{
				AddressableCache.SaveTexture(cacheGroupName, textureName);
			}
			Action<bool> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v88 @ rax_v3 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string textureName;

		public string cacheGroupName;

		public DlcType? dlcType;

		public Action<bool> onComplete;

		public bool forceSync;

		public AsyncOperationHandle<IList<IResourceLocation>> locationOp;

		internal unsafe void _003CLoadTextureInternal_003Eb__0(IList<IResourceLocation> result)
		{
			//IL_0017: Expected O, but got Ref
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected Ref, but got Unknown
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected Ref, but got Unknown
			//IL_0169: Expected I8, but got I
			AsyncOperationHandle<object> asyncOperationHandle = default(AsyncOperationHandle<object>);
			if (result != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				IntPtr intPtr = default(IntPtr);
				object obj = (object)(&intPtr);
				ref byte reference = ref *(byte*)null;
				object obj2 = default(object);
				object obj3 = default(object);
				IResourceLocation textureLocation = default(IResourceLocation);
				Action<bool> action = default(Action<bool>);
				bool flag5 = default(bool);
				while (true)
				{
					if (intPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 == null)
						{
							break;
						}
						bool flag = intPtr == (IntPtr)0;
						reference = ref *(byte*)null;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							string text = textureName;
							if (obj3 != textureName)
							{
								bool flag2 = obj3 == null;
								reference = ref *(byte*)7;
								if (flag2)
								{
									continue;
								}
								bool flag3 = textureName == null;
								reference = ref *(byte*)7;
								if (flag3)
								{
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v25+10]");
								bool flag4 = (nint)0 != text._stringLength;
								reference = ref *(byte*)7;
								if (flag4)
								{
									continue;
								}
								reference = ref *(byte*)(obj3 + 20);
								ref byte second = ref *(byte*)(textureName + 20);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v25+10]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v25+10]");
								ulong length = (ulong)(num + 0);
								if (!System.SpanHelpers.SequenceEqual(ref reference, ref second, length))
								{
									continue;
								}
							}
							LoadSpritesFromTexture(textureLocation, cacheGroupName, textureName, dlcType, action, flag5);
							asyncOperationHandle.Release();
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							return;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
			}
			asyncOperationHandle.Release();
			string message = "No resource location results for texture: " + textureName;
			Log(message);
			Action<bool> action2 = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v297 @ rax_v8 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CLoadTextureInternal_003Eb__1(IList<IResourceLocation> _)
		{
			AsyncOperationHandle<object> asyncOperationHandle = default(AsyncOperationHandle<object>);
			asyncOperationHandle.Release();
			string message = "Resource locations error with texture: " + textureName;
			Log(message);
			Action<bool> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rax_v7 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public Action<bool> onComplete;

		public string textureName;

		internal void _003CLoadSpritesFromTexture_003Eb__0(IList<Sprite> result)
		{
			//IL_0092: Expected O, but got I4
			//IL_009b: Expected O, but got I4
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			if (result == null)
			{
				string message = "LoadAssetAsync result was null for texture: " + textureName;
				Log(message);
				Action<bool> action = onComplete;
				if (onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v81 @ rax_v26 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
			System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)result);
			System.Linq.Buffer<Sprite> buffer2 = default(System.Linq.Buffer<Sprite>);
			Sprite[] array = buffer2.ToArray();
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				SpriteManager.RegisterSprite(array[obj]);
				obj++;
				obj2 = obj;
			}
			Action<bool> action2 = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ rax_v13 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public static bool LoadTexture(string textureName, string cacheGroupName, DlcType? dlcType, Action<bool> onComplete = null)
	{
		//IL_0077: Expected I4, but got O
		//IL_0037: Expected I4, but got O
		_003C_003Ec__DisplayClass0_0 obj = new _003C_003Ec__DisplayClass0_0();
		if (obj != null)
		{
			obj.cacheGroupName = cacheGroupName;
			obj.textureName = textureName;
			obj.onComplete = onComplete;
			obj.isSuccess = false;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass0_0)(object)action)._003CLoadTexture_003Eb__0((byte)(int)obj != 0);
			bool forceSync = default(bool);
			LoadTextureInternal(obj.textureName, obj.cacheGroupName, dlcType, action, forceSync);
			return obj.isSuccess;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static void LoadTextureAsync(string textureName, string cacheGroupName, DlcType? dlcType, Action<bool> onComplete = null)
	{
		//IL_0029: Expected I4, but got O
		_003C_003Ec__DisplayClass1_0 obj = new _003C_003Ec__DisplayClass1_0();
		obj.cacheGroupName = cacheGroupName;
		obj.textureName = textureName;
		obj.onComplete = onComplete;
		Action<bool> action = null;
		((_003C_003Ec__DisplayClass1_0)(object)action)._003CLoadTextureAsync_003Eb__0((byte)(int)obj != 0);
		bool forceSync = default(bool);
		LoadTextureInternal(obj.textureName, obj.cacheGroupName, dlcType, action, forceSync);
	}

	private static void Log(string message)
	{
		string message2 = "[SpriteLoader] :: " + message;
		Debug.LogWarning(message2);
	}

	private unsafe static void LoadTextureInternal(string textureName, string cacheGroupName, DlcType? dlcType, Action<bool> onComplete = null, bool forceSync = false)
	{
		//IL_00ae: Expected O, but got Ref
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals25.textureName = textureName;
		CS_0024_003C_003E8__locals25.cacheGroupName = cacheGroupName;
		CS_0024_003C_003E8__locals25.dlcType = dlcType;
		CS_0024_003C_003E8__locals25.onComplete = onComplete;
		bool forceSync2 = default(bool);
		CS_0024_003C_003E8__locals25.forceSync = forceSync2;
		bool flag = SpriteManager.TextureExists(CS_0024_003C_003E8__locals25.textureName);
		if (!flag)
		{
			if ((nint)CS_0024_003C_003E8__locals25.dlcType != (flag ? 1 : 0))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (VampireSurvivors.Framework.Loading.SpriteLoader+<>c__DisplayClass3_0)+24]");
				AddressableLoader.PointAtDlc(DlcType.Moonspell);
			}
			string dynamicLabel = LoaderUtils.GetDynamicLabel(CS_0024_003C_003E8__locals25.dlcType);
			AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle2 = default(AsyncOperationHandle<IList<IResourceLocation>>);
			AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = (CS_0024_003C_003E8__locals25.locationOp = Addressables.LoadResourceLocationsAsync((object)(&asyncOperationHandle2), (Type)(object)dynamicLabel));
			_ = asyncOperationHandle.m_InternalOp;
			Action<IList<IResourceLocation>> action = delegate(IList<IResourceLocation> result)
			{
				//IL_0017: Expected O, but got Ref
				//IL_0137: Unknown result type (might be due to invalid IL or missing references)
				//IL_013c: Expected Ref, but got Unknown
				//IL_0147: Unknown result type (might be due to invalid IL or missing references)
				//IL_014c: Expected Ref, but got Unknown
				//IL_0169: Expected I8, but got I
				AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
				if (result != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					IntPtr intPtr = default(IntPtr);
					object obj = (object)(&intPtr);
					ref byte reference = ref *(byte*)null;
					object obj2 = default(object);
					object obj3 = default(object);
					IResourceLocation textureLocation = default(IResourceLocation);
					Action<bool> onComplete3 = default(Action<bool>);
					bool forceSync3 = default(bool);
					while (true)
					{
						if (intPtr == (IntPtr)0)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 == null)
						{
							break;
						}
						bool flag2 = intPtr == (IntPtr)0;
						reference = ref *(byte*)null;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							string textureName2 = CS_0024_003C_003E8__locals25.textureName;
							if (obj3 != CS_0024_003C_003E8__locals25.textureName)
							{
								bool flag3 = obj3 == null;
								reference = ref *(byte*)7;
								if (flag3)
								{
									continue;
								}
								bool flag4 = CS_0024_003C_003E8__locals25.textureName == null;
								reference = ref *(byte*)7;
								if (flag4)
								{
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v25+10]");
								bool flag5 = (nint)0 != textureName2._stringLength;
								reference = ref *(byte*)7;
								if (flag5)
								{
									continue;
								}
								reference = ref *(byte*)(obj3 + 20);
								ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals25.textureName + 20);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v25+10]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v25+10]");
								ulong length = (ulong)(num + 0);
								if (!System.SpanHelpers.SequenceEqual(ref reference, ref second, length))
								{
									continue;
								}
							}
							LoadSpritesFromTexture(textureLocation, CS_0024_003C_003E8__locals25.cacheGroupName, CS_0024_003C_003E8__locals25.textureName, CS_0024_003C_003E8__locals25.dlcType, onComplete3, forceSync3);
							asyncOperationHandle3.Release();
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							return;
						}
						throw new NullReferenceException();
					}
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
				}
				asyncOperationHandle3.Release();
				string message2 = "No resource location results for texture: " + CS_0024_003C_003E8__locals25.textureName;
				Log(message2);
				Action<bool> onComplete4 = CS_0024_003C_003E8__locals25.onComplete;
				if (CS_0024_003C_003E8__locals25.onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v297 @ rax_v8 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
				}
			};
			Action<IList<IResourceLocation>> action2 = delegate
			{
				AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
				asyncOperationHandle3.Release();
				string message2 = "Resource locations error with texture: " + CS_0024_003C_003E8__locals25.textureName;
				Log(message2);
				Action<bool> onComplete3 = CS_0024_003C_003E8__locals25.onComplete;
				if (CS_0024_003C_003E8__locals25.onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rax_v7 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183091F90");
		}
		else
		{
			string message = "Texture already exists in sprite manager: " + CS_0024_003C_003E8__locals25.textureName;
			Log(message);
			Action<bool> onComplete2 = CS_0024_003C_003E8__locals25.onComplete;
			if (CS_0024_003C_003E8__locals25.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v460 @ rax_v13 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private static void LoadSpritesFromTexture(IResourceLocation textureLocation, string cacheGroupName, string textureName, DlcType? dlcType, Action<bool> onComplete = null, bool forceSync = false)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0173: Expected O, but got I
		//IL_017c: Expected O, but got I4
		//IL_01d8: Expected O, but got I
		//IL_01e1: Expected O, but got I4
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass4_0();
		Action<bool> onComplete2 = default(Action<bool>);
		CS_0024_003C_003E8__locals13.onComplete = onComplete2;
		CS_0024_003C_003E8__locals13.textureName = textureName;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		object obj4 = default(object);
		string message;
		Action<bool> onComplete3;
		if (obj3 != obj4)
		{
			message = "Resource found for texture " + CS_0024_003C_003E8__locals13.textureName + " was not of type Tex2D";
			string text = null;
		}
		else
		{
			object obj5 = default(object);
			if (obj5 == null)
			{
				Action<IList<Sprite>> action = delegate(IList<Sprite> result)
				{
					//IL_0092: Expected O, but got I4
					//IL_009b: Expected O, but got I4
					//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c5: Expected O, but got Unknown
					if (result == null)
					{
						string message2 = "LoadAssetAsync result was null for texture: " + CS_0024_003C_003E8__locals13.textureName;
						Log(message2);
						Action<bool> onComplete4 = CS_0024_003C_003E8__locals13.onComplete;
						if (CS_0024_003C_003E8__locals13.onComplete != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v81 @ rax_v26 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
						}
					}
					else
					{
						System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)result);
						System.Linq.Buffer<Sprite> buffer2 = default(System.Linq.Buffer<Sprite>);
						Sprite[] array = buffer2.ToArray();
						object obj9 = 0;
						object obj10 = 0;
						while ((nint)obj10 < array.Length)
						{
							SpriteManager.RegisterSprite(array[obj9]);
							obj9++;
							obj10 = obj9;
						}
						Action<bool> onComplete5 = CS_0024_003C_003E8__locals13.onComplete;
						if (CS_0024_003C_003E8__locals13.onComplete != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ rax_v13 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
						}
					}
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F962E0");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94DF0");
			object obj6 = default(object);
			string text;
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99AD0");
				Sprite[] rawSprites = default(Sprite[]);
				SpriteManager.RegisterSprites(rawSprites);
				onComplete3 = CS_0024_003C_003E8__locals13.onComplete;
				if (CS_0024_003C_003E8__locals13.onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v11 (System.Action`1<System.Boolean>)+28]");
					object obj7 = 0;
					object obj8 = 1;
					text = cacheGroupName;
					goto IL_0230;
				}
				return;
			}
			message = "LoadAsset result was null for texture: " + CS_0024_003C_003E8__locals13.textureName;
			text = cacheGroupName;
		}
		Log(message);
		onComplete3 = CS_0024_003C_003E8__locals13.onComplete;
		if (CS_0024_003C_003E8__locals13.onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v11 (System.Action`1<System.Boolean>)+28]");
			object obj7 = 0;
			object obj8 = 0;
			goto IL_0230;
		}
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v548 @ rax_v11 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
	}
}
