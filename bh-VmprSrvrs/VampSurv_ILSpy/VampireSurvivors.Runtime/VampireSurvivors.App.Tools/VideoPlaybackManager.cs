using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Video;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.Tools;

public class VideoPlaybackManager
{
	private GameObject _videoPlayerPrefab;

	private Dictionary<VideoClip, RenderTexture> _renderTextures;

	private Dictionary<VideoClip, VideoPlayerHelper> _videoPlayerHelpers;

	public VideoPlayerHelper GenerateVideoPlayerForRenderTexture(VideoClip videoClip)
	{
		VideoPlayerHelper videoPlayerHelper;
		if (_videoPlayerHelpers != null)
		{
			int num = _videoPlayerHelpers.FindEntry(videoClip);
			if (num >= 0)
			{
				if (_videoPlayerHelpers != null)
				{
					videoPlayerHelper = _videoPlayerHelpers.get_Item(videoClip);
					goto IL_024f;
				}
			}
			else
			{
				GameObject videoPlayerPrefab = _videoPlayerPrefab;
				if ((object)_videoPlayerPrefab == null || ((UnityEngine.Object)videoPlayerPrefab).m_CachedPtr == (IntPtr)0)
				{
					GameObject videoPlayerPrefab2 = Resources.Load<GameObject>("VideoPlayer");
					_videoPlayerPrefab = videoPlayerPrefab2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C10");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					videoPlayerHelper = gameObject.GetComponent<VideoPlayerHelper>();
					if ((object)videoPlayerHelper != null && (object)videoPlayerHelper._VideoPlayer != null)
					{
						videoPlayerHelper._VideoPlayer.clip = videoClip;
						RenderTexture renderTexture = GenerateRenderTexture(videoClip);
						videoPlayerHelper.SetToRenderTextureMode(renderTexture);
						if (_renderTextures != null)
						{
							bool flag = ((Dictionary<object, object>)(object)_renderTextures).TryInsert((object)videoClip, (object)renderTexture, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							if (_videoPlayerHelpers != null)
							{
								bool flag2 = ((Dictionary<object, object>)(object)_videoPlayerHelpers).TryInsert((object)videoClip, (object)videoPlayerHelper, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								goto IL_024f;
							}
						}
					}
				}
			}
		}
		return (VideoPlayerHelper)(object)new NullReferenceException();
		IL_024f:
		return videoPlayerHelper;
	}

	public unsafe Renderer GenerateQuadForVideoPlayback(VideoClip videoClip, Vector2 spawnPos, Vector3 scale, float alpha = 1f)
	{
		//IL_007c->IL014e: Incompatible stack heights: 1 vs 0
		if ((object)videoClip != null && ((UnityEngine.Object)videoClip).m_CachedPtr != (IntPtr)0)
		{
			bool flag = _renderTextures == null;
			int num = _renderTextures.FindEntry(videoClip);
			if (num >= 0)
			{
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
				bool flag2 = (object)gameObject == null;
				Transform transform = gameObject.transform;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = gameObject.transform;
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				float value2 = default(float);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				Material material = MaterialManager.GetMaterial(MaterialType.Video);
				((Renderer)component).SetMaterial(material);
				Material material2 = ((Renderer)component).GetMaterial();
				RenderTexture mainTexture = _renderTextures.get_Item(videoClip);
				material2.mainTexture = mainTexture;
				Material material3 = ((Renderer)component).GetMaterial();
				float alpha2 = default(float);
				RenderingExtensions.SetAlpha(material3, alpha2);
				return component;
			}
		}
		return null;
	}

	public void ReleaseVideo(VideoClip videoClip)
	{
		int num = _videoPlayerHelpers.FindEntry(videoClip);
		if (num >= 0)
		{
			VideoPlayerHelper videoPlayerHelper = _videoPlayerHelpers.get_Item(videoClip);
			GameObject gameObject = videoPlayerHelper.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
			bool flag = ((Dictionary<object, object>)(object)_videoPlayerHelpers).Remove((object)videoClip);
		}
		int num2 = _renderTextures.FindEntry(videoClip);
		if (num2 >= 0)
		{
			RenderTexture renderTexture = _renderTextures.get_Item(videoClip);
			renderTexture.Release();
			UnityEngine.Object.Destroy(renderTexture, 0f);
			bool flag2 = ((Dictionary<object, object>)(object)_renderTextures).Remove((object)videoClip);
		}
	}

	public void Cleanup()
	{
		//IL_0050: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_0202: Expected O, but got I4
		//IL_01be: Expected I, but got O
		_videoPlayerHelpers.Clear();
		if (_renderTextures == null)
		{
			return;
		}
		Dictionary<VideoClip, RenderTexture> renderTextures = _renderTextures;
		object obj = renderTextures._count - renderTextures._freeCount;
		if ((nint)obj <= 0)
		{
			return;
		}
		Dictionary<VideoClip, RenderTexture>.ValueCollection values = renderTextures.Values;
		if (values != null)
		{
			List<object> list = new List<object>(values);
			bool flag = (nint)list < 0;
			IEnumerable<RenderTexture> enumerable = (IEnumerable<RenderTexture>)(list._size - 1);
			if (flag)
			{
				goto IL_0210;
			}
			RenderTexture renderTexture = default(RenderTexture);
			List<RenderTexture> obj3 = default(List<RenderTexture>);
			while ((nint)enumerable < list._size)
			{
				object[] items = list._items;
				object obj2 = items[(object)enumerable];
				bool flag2 = (nint)items[(object)enumerable] < 0;
				if (items[(object)enumerable] != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v10 (System.Object)+10]");
					flag2 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rsi_v10 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						((List<RenderTexture>)(object)list)._002Ector(enumerable);
						renderTexture.Release();
						((List<RenderTexture>)(object)list)._002Ector(enumerable);
						nint num = (nint)typeof(UnityEngine.Object);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rcx_v33 (Il2CppClass<UnityEngine.Object>)+E4]");
						flag2 = (nint)0 < (nint)0;
						UnityEngine.Object.Destroy((UnityEngine.Object)(object)obj3);
					}
				}
				enumerable = (IEnumerable<RenderTexture>)(enumerable - 1);
				object obj4 = !flag2;
				if (obj4 != null)
				{
					continue;
				}
				goto IL_0210;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
		IL_0210:
		_renderTextures.Clear();
	}

	private GameObject GetVideoPlayerPrefab()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_015f: Expected O, but got I4
		GameObject videoPlayerPrefab = _videoPlayerPrefab;
		GameObject gameObject;
		if ((object)_videoPlayerPrefab == null || ((UnityEngine.Object)videoPlayerPrefab).m_CachedPtr == (IntPtr)0)
		{
			gameObject = Resources.Load<GameObject>("VideoPlayer");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			_videoPlayerPrefab = gameObject;
			if (flag)
			{
				goto IL_012d;
			}
			object obj = this + 16;
			object obj2 = obj >> 12;
			object obj3 = obj2 & 0x1FFFFF;
			object obj4 = obj3 >> 6;
			object obj5 = obj3 & 0x3F;
			object obj6 = obj4 * 8;
			object obj7 = 6603864928L + obj6;
			do
			{
				object obj8 = 1 << (int)obj5;
				object obj9 = obj7 | obj8;
				if (obj7 == obj7)
				{
					obj7 = obj9;
				}
			}
			while (obj7 != obj7);
		}
		gameObject = _videoPlayerPrefab;
		goto IL_012d;
		IL_012d:
		return gameObject;
	}

	private RenderTexture GenerateRenderTexture(VideoClip videoClip)
	{
		if ((object)videoClip == null || ((UnityEngine.Object)videoClip).m_CachedPtr == (IntPtr)0)
		{
			return null;
		}
		bool flag = ((UnityEngine.Object)videoClip).m_CachedPtr == (IntPtr)0;
		int width = (int)VideoClip.get_width_Injected(((UnityEngine.Object)videoClip).m_CachedPtr);
		bool flag2 = ((UnityEngine.Object)videoClip).m_CachedPtr == (IntPtr)0;
		int height = (int)VideoClip.get_height_Injected(((UnityEngine.Object)videoClip).m_CachedPtr);
		RenderTextureFormat format = default(RenderTextureFormat);
		return new RenderTexture(width, height, 0, format);
	}

	public VideoPlaybackManager()
	{
		Dictionary<VideoClip, RenderTexture> renderTextures = new Dictionary<VideoClip, RenderTexture>();
		_renderTextures = renderTextures;
		Dictionary<VideoClip, VideoPlayerHelper> videoPlayerHelpers = new Dictionary<VideoClip, VideoPlayerHelper>();
		_videoPlayerHelpers = videoPlayerHelpers;
	}
}
