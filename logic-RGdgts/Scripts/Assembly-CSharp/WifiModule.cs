using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WifiModule : Module
{
	public class WebResponse_EventData : EventData
	{
		public double RequestHandle;

		public double ResponseCode;

		public bool IsError;

		public string ErrorType;

		public string ErrorMessage;

		public string ContentType;

		public string Text;

		public byte[] Data;

		public WebResponse_EventData()
		{
		}

		public WebResponse_EventData(uint handle, UnityWebRequestAsyncOperation request)
		{
		}

		public WebResponse_EventData(uint handle, uint responseCode, UnityWebRequest.Result result, string errorMessage, string contentType, string text)
		{
		}
	}

	public SpriteRenderer ledLightRenderer;

	private Material ledLightMaterial;

	private Texture2D statusTexture;

	private int ledsCount;

	private ModuleProperty accessDeniedProperty;

	private Dictionary<uint, UnityWebRequestAsyncOperation> webRequestes;

	private float minBlinkTime;

	private List<uint> requestesCompleted;

	private float isUploadingTime;

	private float isDownloadingTime;

	private bool isUploading;

	private bool isDownloading;

	private uint lastId;

	private static HashSet<string> unallowedCustomHeaders;

	public bool IsAccessDenied => false;

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

	protected override void OnSetupFinished()
	{
	}

	private void SetLight(int index, bool state, Color color)
	{
	}

	protected override void UpdateVisuals()
	{
	}

	public override void OnTurnOff()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	private void SendPermissionDeniedEvent(uint handle)
	{
	}

	private void UpdateLeds(bool newRequest = false)
	{
	}

	public override GadgetPermissions.Category[] GetNeededPermissionsCategories()
	{
		return null;
	}

	private uint NewId()
	{
		return 0u;
	}

	private uint AddRequest(UnityWebRequestAsyncOperation request)
	{
		return 0u;
	}

	private bool CheckUrl(string url)
	{
		return false;
	}

	public uint Script_WebGet(string url)
	{
		return 0u;
	}

	public uint Script_WebPutData(string url, byte[] data)
	{
		return 0u;
	}

	public uint Script_WebPostData(string url, byte[] data)
	{
		return 0u;
	}

	public uint Script_WebPostForm(string url, LuaTable form)
	{
		return 0u;
	}

	public uint Script_WebCustomRequest(string url, string method, LuaTable customHeaderFields, string contentType, byte[] contentData)
	{
		return 0u;
	}

	public bool Script_WebAbort(uint handle)
	{
		return false;
	}

	public float GetWebUploadProgress(uint handle)
	{
		return 0f;
	}

	public float GetWebDownloadProgress(uint handle)
	{
		return 0f;
	}

	public void Script_ClearCookieCache()
	{
	}

	public void Script_ClearUrlCookieCache(string url)
	{
	}
}
