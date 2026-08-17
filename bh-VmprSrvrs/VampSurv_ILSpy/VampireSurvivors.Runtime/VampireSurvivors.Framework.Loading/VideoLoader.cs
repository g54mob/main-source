using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.Video;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading;

public static class VideoLoader
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public string videoName;

		public string cacheGroupName;

		public DlcType? dlcType;

		public Action<VideoClip> onComplete;

		public bool forceSync;

		public AsyncOperationHandle<IList<IResourceLocation>> locationOp;

		internal unsafe void _003CLoadVideoInternal_003Eb__0(IList<IResourceLocation> result)
		{
			//IL_0017: Expected O, but got Ref
			AsyncOperationHandle<object> asyncOperationHandle = default(AsyncOperationHandle<object>);
			if (result != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				IntPtr intPtr = default(IntPtr);
				object obj = (object)(&intPtr);
				string text = null;
				object obj2 = default(object);
				IResourceLocation resourceLocation = default(IResourceLocation);
				string text2 = default(string);
				Action<VideoClip> action = default(Action<VideoClip>);
				bool flag3 = default(bool);
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
						text = null;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							bool flag2 = resourceLocation == null;
							text = null;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								if (text2.Contains(videoName))
								{
									LoadVideoFromResourceLocation(resourceLocation, cacheGroupName, videoName, dlcType, action, flag3);
									asyncOperationHandle.Release();
									if (obj != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
									}
									return;
								}
								continue;
							}
							throw new NullReferenceException();
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
			Action<VideoClip> action2 = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v223 @ rax_v6 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CLoadVideoInternal_003Eb__1(IList<IResourceLocation> _)
		{
			AsyncOperationHandle<object> asyncOperationHandle = default(AsyncOperationHandle<object>);
			asyncOperationHandle.Release();
			Action<VideoClip> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v78 @ rax_v5 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public Action<VideoClip> onComplete;

		internal void _003CLoadVideoFromResourceLocation_003Eb__0(VideoClip result)
		{
			VideoClip videoClip = default(VideoClip);
			Action<VideoClip> action;
			if ((object)videoClip != null)
			{
				bool flag = ((UnityEngine.Object)videoClip).m_CachedPtr == (IntPtr)0;
				action = onComplete;
				if (!flag)
				{
					if (onComplete != null)
					{
						goto IL_00b8;
					}
					return;
				}
			}
			else
			{
				action = onComplete;
			}
			if (action != null)
			{
				goto IL_00b8;
			}
			return;
			IL_00b8:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v198 @ rax_v6 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
		}
	}

	public static void LoadVideo(string videoName, string cacheGroupName, DlcType? dlcType, Action<VideoClip> onComplete = null)
	{
		bool forceSync = default(bool);
		LoadVideoInternal(videoName, cacheGroupName, dlcType, onComplete, forceSync);
	}

	public static void LoadVideoAsync(string videoName, string cacheGroupName, DlcType? dlcType, Action<VideoClip> onComplete = null)
	{
		bool forceSync = default(bool);
		LoadVideoInternal(videoName, cacheGroupName, dlcType, onComplete, forceSync);
	}

	private unsafe static void LoadVideoInternal(string videoName, string cacheGroupName, DlcType? dlcType, Action<VideoClip> onComplete = null, bool forceSync = false)
	{
		//IL_008a: Expected O, but got Ref
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals16.videoName = videoName;
		CS_0024_003C_003E8__locals16.cacheGroupName = cacheGroupName;
		CS_0024_003C_003E8__locals16.dlcType = dlcType;
		CS_0024_003C_003E8__locals16.onComplete = onComplete;
		bool forceSync2 = default(bool);
		CS_0024_003C_003E8__locals16.forceSync = forceSync2;
		if ((object)CS_0024_003C_003E8__locals16.dlcType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (VampireSurvivors.Framework.Loading.VideoLoader+<>c__DisplayClass2_0)+24]");
			AddressableLoader.PointAtDlc(DlcType.Moonspell);
		}
		string dynamicLabel = LoaderUtils.GetDynamicLabel(CS_0024_003C_003E8__locals16.dlcType);
		AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle2 = default(AsyncOperationHandle<IList<IResourceLocation>>);
		AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = (CS_0024_003C_003E8__locals16.locationOp = Addressables.LoadResourceLocationsAsync((object)(&asyncOperationHandle2), (Type)(object)dynamicLabel));
		_ = asyncOperationHandle.m_InternalOp;
		Action<IList<IResourceLocation>> action = delegate(IList<IResourceLocation> result)
		{
			//IL_0017: Expected O, but got Ref
			AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
			if (result != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				IntPtr intPtr = default(IntPtr);
				object obj = (object)(&intPtr);
				string text = null;
				object obj2 = default(object);
				IResourceLocation resourceLocation = default(IResourceLocation);
				string text2 = default(string);
				Action<VideoClip> onComplete2 = default(Action<VideoClip>);
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
					bool flag = intPtr == (IntPtr)0;
					text = null;
					if (flag)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					bool flag2 = resourceLocation == null;
					text = null;
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (text2.Contains(CS_0024_003C_003E8__locals16.videoName))
					{
						LoadVideoFromResourceLocation(resourceLocation, CS_0024_003C_003E8__locals16.cacheGroupName, CS_0024_003C_003E8__locals16.videoName, CS_0024_003C_003E8__locals16.dlcType, onComplete2, forceSync3);
						asyncOperationHandle3.Release();
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						return;
					}
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
			}
			asyncOperationHandle3.Release();
			Action<VideoClip> onComplete3 = CS_0024_003C_003E8__locals16.onComplete;
			if (CS_0024_003C_003E8__locals16.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v223 @ rax_v6 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
			}
		};
		Action<IList<IResourceLocation>> action2 = delegate
		{
			AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
			asyncOperationHandle3.Release();
			Action<VideoClip> onComplete2 = CS_0024_003C_003E8__locals16.onComplete;
			if (CS_0024_003C_003E8__locals16.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v78 @ rax_v5 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
			}
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183091F90");
	}

	private static void LoadVideoFromResourceLocation(IResourceLocation videoLocation, string cacheGroupName, string videoName, DlcType? dlcType, Action<VideoClip> onComplete = null, bool forceSync = false)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass3_0();
		Action<VideoClip> onComplete2 = default(Action<VideoClip>);
		CS_0024_003C_003E8__locals8.onComplete = onComplete2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		object obj4 = default(object);
		object obj5 = default(object);
		if (obj3 != obj4)
		{
			Action<VideoClip> onComplete3 = CS_0024_003C_003E8__locals8.onComplete;
			if (CS_0024_003C_003E8__locals8.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v308 @ rax_v20 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
			}
		}
		else if (obj5 == null)
		{
			Action<VideoClip> action = delegate
			{
				VideoClip videoClip = default(VideoClip);
				Action<VideoClip> onComplete5;
				if ((object)videoClip != null)
				{
					bool flag = ((UnityEngine.Object)videoClip).m_CachedPtr == (IntPtr)0;
					onComplete5 = CS_0024_003C_003E8__locals8.onComplete;
					if (!flag)
					{
						if (CS_0024_003C_003E8__locals8.onComplete == null)
						{
							return;
						}
						goto IL_00b8;
					}
				}
				else
				{
					onComplete5 = CS_0024_003C_003E8__locals8.onComplete;
				}
				if (onComplete5 == null)
				{
					return;
				}
				goto IL_00b8;
				IL_00b8:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v198 @ rax_v6 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F962E0");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94DF0");
			Action<VideoClip> onComplete4 = CS_0024_003C_003E8__locals8.onComplete;
			if (CS_0024_003C_003E8__locals8.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v341 @ r9_v3 (System.Action`1<UnityEngine.Video.VideoClip>)+18] (should have been resolved before IL gen)");
			}
		}
	}
}
