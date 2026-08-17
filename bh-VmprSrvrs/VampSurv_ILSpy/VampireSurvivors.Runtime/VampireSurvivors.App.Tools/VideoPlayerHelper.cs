using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Video;

namespace VampireSurvivors.App.Tools;

public class VideoPlayerHelper : MonoBehaviour
{
	private VideoPlayer _VideoPlayer;

	private Material _videoMat;

	private Action _onFrameReady;

	public Renderer VideoRenderer
	{
		get
		{
			if ((object)_VideoPlayer != null)
			{
				return _VideoPlayer.targetMaterialRenderer;
			}
			return (Renderer)(object)new NullReferenceException();
		}
	}

	private void Awake()
	{
		Renderer targetMaterialRenderer = _VideoPlayer.targetMaterialRenderer;
		Material material = targetMaterialRenderer.GetMaterial();
		_videoMat = material;
		RenderingExtensions.SetAlpha(_videoMat, 0f);
	}

	public void SetClip(VideoClip clip)
	{
		_VideoPlayer.clip = clip;
	}

	public void Play(Action onFrameReady = null)
	{
		//IL_020d: Expected O, but got I4
		//IL_00a1->IL018f: Incompatible stack heights: 1 vs 0
		//IL_0138->IL018f: Incompatible stack heights: 1 vs 0
		//IL_0166->IL018f: Incompatible stack heights: 1 vs 0
		//IL_017b->IL00f8: Incompatible stack heights: 1 vs 0
		//IL_00f8->IL0297: Incompatible stack heights: 2 vs 0
		//IL_00df->IL00f9: Incompatible stack heights: 2 vs 1
		object message;
		if ((object)_VideoPlayer != null)
		{
			VideoClip clip = _VideoPlayer.clip;
			if ((object)clip == null || ((UnityEngine.Object)clip).m_CachedPtr == (IntPtr)0)
			{
				message = "Cannot prepare video as target clip is null";
				goto IL_0297;
			}
			object videoPlayer = _VideoPlayer;
			if ((object)_VideoPlayer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdi_v10 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdi_v10 (System.Object)+10]");
				object obj = VideoPlayer.get_renderMode_Injected((IntPtr)0);
				if ((nint)obj == 2)
				{
					object videoPlayer2 = _VideoPlayer;
					if ((object)_VideoPlayer == null)
					{
						goto IL_018f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdi_v13 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdi_v13 (System.Object)+10]");
					IntPtr gcHandlePtr = VideoPlayer.get_targetTexture_Injected((IntPtr)0);
					RenderTexture renderTexture = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<RenderTexture>(gcHandlePtr);
					if ((object)renderTexture == null || ((UnityEngine.Object)renderTexture).m_CachedPtr == (IntPtr)0)
					{
						message = "Cannot prepare video as target RenderTexture is null";
						goto IL_0297;
					}
				}
				_onFrameReady = onFrameReady;
				VideoPlayer.EventHandler value = OnPrepareCompleted;
				if ((object)_VideoPlayer != null)
				{
					_VideoPlayer.prepareCompleted += value;
					if ((object)_VideoPlayer != null)
					{
						_VideoPlayer.Prepare();
						return;
					}
				}
			}
		}
		goto IL_018f;
		IL_0297:
		Debug.LogWarning(message);
		return;
		IL_018f:
		throw new NullReferenceException();
	}

	public void Stop()
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0178->IL0046: Incompatible stack heights: 1 vs 0
		//IL_01ec->IL01ec: Incompatible stack heights: 1 vs 0
		VideoPlayer videoPlayer = _VideoPlayer;
		VideoPlayer.EventHandler value = OnPrepareCompleted;
		if ((object)_VideoPlayer != null)
		{
			Delegate obj = videoPlayer.prepareCompleted;
			object obj2 = _VideoPlayer + 24;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(VideoPlayer.EventHandler);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					bool flag3 = (object)obj4 == null;
				}
				bool flag4 = obj == obj2;
				Delegate obj5;
				if (obj == obj2)
				{
					obj2 = obj4;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj2;
				}
				Delegate obj6 = obj;
				if (!flag4)
				{
					obj6 = obj5;
				}
				while (true)
				{
					bool flag5 = (object)obj6 != obj;
					obj = obj6;
					if (flag5)
					{
						break;
					}
					object videoPlayer2 = _VideoPlayer;
					if ((object)_VideoPlayer == null)
					{
						goto end_IL_018e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v8 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				}
				continue;
				end_IL_018e:
				break;
			}
		}
		throw new NullReferenceException();
	}

	public void SetDepth(float depth)
	{
		Renderer targetMaterialRenderer = _VideoPlayer.targetMaterialRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
		targetMaterialRenderer.sortingOrder = 0;
	}

	public void SetToRenderTextureMode(RenderTexture renderTexture)
	{
		//IL_0043: Expected O, but got I
		//IL_0201: Expected I, but got O
		//IL_01a5->IL0120: Incompatible stack heights: 1 vs 0
		//IL_021b->IL0120: Incompatible stack heights: 2 vs 0
		//IL_00b1->IL0120: Incompatible stack heights: 2 vs 0
		//IL_00dd->IL0120: Incompatible stack heights: 2 vs 0
		//IL_0107->IL0120: Incompatible stack heights: 2 vs 0
		VideoPlayer videoPlayer = _VideoPlayer;
		if ((object)_VideoPlayer != null)
		{
			bool flag = ((UnityEngine.Object)videoPlayer).m_CachedPtr == (IntPtr)0;
			VideoPlayer.set_renderMode_Injected(((UnityEngine.Object)videoPlayer).m_CachedPtr, VideoRenderMode.RenderTexture);
			Renderer videoPlayer2 = (Renderer)(object)_VideoPlayer;
			if ((object)_VideoPlayer != null)
			{
				bool flag2 = ((UnityEngine.Object)videoPlayer2).m_CachedPtr == (IntPtr)0;
				VideoPlayer.set_targetTexture_Injected(value: (IntPtr)(((object)renderTexture == null) ? null : ((object)(nint)((UnityEngine.Object)renderTexture).m_CachedPtr)), _unity_self: ((UnityEngine.Object)videoPlayer2).m_CachedPtr);
				if ((object)_VideoPlayer != null)
				{
					Renderer targetMaterialRenderer = _VideoPlayer.targetMaterialRenderer;
					if ((object)targetMaterialRenderer == null || ((UnityEngine.Object)targetMaterialRenderer).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					if ((object)_VideoPlayer != null)
					{
						Renderer targetMaterialRenderer2 = _VideoPlayer.targetMaterialRenderer;
						if ((object)targetMaterialRenderer2 != null)
						{
							GameObject gameObject = targetMaterialRenderer2.gameObject;
							if ((object)gameObject != null)
							{
								gameObject.SetActive(value: false);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnPrepareCompleted(VideoPlayer source)
	{
		bool flag = ((UnityEngine.Object)source).m_CachedPtr == (IntPtr)0;
		VideoPlayer.Play_Injected(((UnityEngine.Object)source).m_CachedPtr);
		Action onFrameReady = _onFrameReady;
		if (_onFrameReady != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v137.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public VideoPlayerHelper()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
