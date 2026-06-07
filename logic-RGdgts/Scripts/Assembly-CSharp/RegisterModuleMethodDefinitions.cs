using System;
using UnityEngine;

public class RegisterModuleMethodDefinitions
{
	public delegate LuaNativeArray AudioChip_GetSpectrumDataType(IntPtr modulePtr, int channel, int samplesCount);

	public delegate double AudioChip_GetDspTimeType(IntPtr modulePtr);

	public delegate void AudioChip_PlayType(IntPtr modulePtr, LuaAssetReference audioSample, int channel);

	public delegate void AudioChip_PlayScheduledType(IntPtr modulePtr, LuaAssetReference audioSample, int channel, double dspTime);

	public delegate void AudioChip_PlayLoopType(IntPtr modulePtr, LuaAssetReference audioSample, int channel);

	public delegate void AudioChip_PlayLoopScheduledType(IntPtr modulePtr, LuaAssetReference audioSample, int channel, double dspTime);

	public delegate void AudioChip_StopType(IntPtr modulePtr, int channel);

	public delegate void AudioChip_PauseType(IntPtr modulePtr, int channel);

	public delegate void AudioChip_UnPauseType(IntPtr modulePtr, int channel);

	public delegate bool AudioChip_IsPlayingType(IntPtr modulePtr, int channel);

	public delegate bool AudioChip_IsPausedType(IntPtr modulePtr, int channel);

	public delegate float AudioChip_GetPlayTimeType(IntPtr modulePtr, int channel);

	public delegate void AudioChip_SeekPlayTimeType(IntPtr modulePtr, float time, int channel);

	public delegate void AudioChip_SetChannelVolumeType(IntPtr modulePtr, float volume, int channel);

	public delegate float AudioChip_GetChannelVolumeType(IntPtr modulePtr, int channel);

	public delegate void AudioChip_SetChannelPitchType(IntPtr modulePtr, float pitch, int channel);

	public delegate float AudioChip_GetChannelPitchType(IntPtr modulePtr, int channel);

	public delegate bool FlashMemory_SaveType(IntPtr modulePtr, LuaNativeTable table);

	public delegate LuaNativeTable FlashMemory_LoadType(IntPtr modulePtr);

	public delegate ToLuaInputSource GamepadChip_GetButtonType(IntPtr modulePtr, IntPtr name);

	public delegate ToLuaInputSource GamepadChip_GetAxisType(IntPtr modulePtr, IntPtr name);

	public delegate ToLuaInputSource GamepadChip_GetButtonAxisType(IntPtr modulePtr, IntPtr negativeName, IntPtr positiveName);

	public delegate ToLuaInputSource KeyboardChip_GetButtonType(IntPtr modulePtr, IntPtr name);

	public delegate ToLuaInputSource KeyboardChip_GetButtonAxisType(IntPtr modulePtr, IntPtr negativeName, IntPtr positiveName);

	public delegate LuaNativeTable RealityChip_GetDateTimeType(IntPtr modulePtr);

	public delegate LuaNativeTable RealityChip_GetDateTimeUTCType(IntPtr modulePtr);

	public delegate LuaAssetReference RealityChip_LoadAudioSampleType(IntPtr modulePtr, FromLuaString filename);

	public delegate LuaAssetReference RealityChip_LoadSpriteSheetType(IntPtr modulePtr, FromLuaString filename, int spritesWidth, int spritesHeight);

	public delegate void RealityChip_UnloadAssetType(IntPtr modulePtr, FromLuaString filename);

	public delegate LuaNativeTable RealityChip_ListDirectoryType(IntPtr modulePtr, FromLuaString directory);

	public delegate LuaNativeTable RealityChip_GetFileMetadataType(IntPtr modulePtr, FromLuaString filename);

	public delegate void SegmentDisplay_ShowDigitType(IntPtr modulePtr, int groupIndex, int digit);

	public delegate void SegmentDisplay_SetDigitColorType(IntPtr modulePtr, int groupIndex, Color color);

	public delegate void Serial_WriteInt8Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteUInt8Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteInt16Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteUInt16Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteInt32Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteUInt32Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteFloat32Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteFloat64Type(IntPtr modulePtr, double value);

	public delegate void Serial_WriteType(IntPtr modulePtr, FromLuaDataString data);

	public delegate void Serial_PrintType(IntPtr modulePtr, FromLuaDataString text);

	public delegate void Serial_PrintlnType(IntPtr modulePtr, FromLuaDataString text);

	public delegate LuaNativeArray Serial_GetAvailablePortsType(IntPtr modulePtr);

	public delegate void VideoChip_RenderOnScreenType(IntPtr modulePtr);

	public delegate void VideoChip_RenderOnBufferType(IntPtr modulePtr, int index);

	public delegate void VideoChip_SetRenderBufferSizeType(IntPtr modulePtr, int index, int width, int height);

	public delegate void VideoChip_ClearType(IntPtr modulePtr, Color color);

	public delegate void VideoChip_SetPixelType(IntPtr modulePtr, LuaVector position, Color color);

	public delegate void VideoChip_DrawPointGridType(IntPtr modulePtr, LuaVector gridOffset, int dotsDistance, Color color);

	public delegate void VideoChip_DrawLineType(IntPtr modulePtr, LuaVector start, LuaVector end, Color color);

	public delegate void VideoChip_DrawCircleType(IntPtr modulePtr, LuaVector position, int radius, Color color);

	public delegate void VideoChip_FillCircleType(IntPtr modulePtr, LuaVector position, int radius, Color color);

	public delegate void VideoChip_DrawRectType(IntPtr modulePtr, LuaVector position1, LuaVector position2, Color color);

	public delegate void VideoChip_FillRectType(IntPtr modulePtr, LuaVector position1, LuaVector position2, Color color);

	public delegate void VideoChip_DrawTriangleType(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, Color color);

	public delegate void VideoChip_FillTriangleType(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, Color color);

	public delegate void VideoChip_DrawSpriteType(IntPtr modulePtr, LuaVector position, LuaAssetReference spriteSheet, int spriteX, int spriteY, Color tintColor, Color backgroundColor);

	public delegate void VideoChip_DrawCustomSpriteType(IntPtr modulePtr, LuaVector position, LuaAssetReference spriteSheet, LuaVector spriteOffset, LuaVector spriteSize, Color tintColor, Color backgroundColor);

	public delegate void VideoChip_DrawTextType(IntPtr modulePtr, LuaVector position, LuaAssetReference fontSprite, FromLuaString text, Color textColor, Color backgroundColor);

	public delegate void VideoChip_RasterSpriteType(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, LuaVector position4, LuaAssetReference spriteSheet, int spriteX, int spriteY, Color tintColor, Color backgroundColor);

	public delegate void VideoChip_RasterCustomSpriteType(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, LuaVector position4, LuaAssetReference spriteSheet, LuaVector spriteOffset, LuaVector spriteSize, Color tintColor, Color backgroundColor);

	public delegate void VideoChip_DrawRenderBufferType(IntPtr modulePtr, LuaVector position, LuaAssetReference renderBuffer, int width, int height);

	public delegate void VideoChip_RasterRenderBufferType(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, LuaVector position4, LuaAssetReference renderBuffer);

	public delegate void VideoChip_SetPixelDataType(IntPtr modulePtr, LuaPixelData pixelData);

	public delegate void VideoChip_BlitPixelDataType(IntPtr modulePtr, LuaVector position, LuaPixelData pixelData);

	public delegate LuaAssetReference Webcam_GetRenderBufferType(IntPtr modulePtr);

	public delegate uint Wifi_WebGetType(IntPtr modulePtr, FromLuaString url);

	public delegate uint Wifi_WebPutDataType(IntPtr modulePtr, FromLuaString url, FromLuaDataString data);

	public delegate uint Wifi_WebPostDataType(IntPtr modulePtr, FromLuaString url, FromLuaDataString data);

	public delegate uint Wifi_WebPostFormType(IntPtr modulePtr, FromLuaString url, LuaNativeTable form);

	public delegate uint Wifi_WebCustomRequestType(IntPtr modulePtr, FromLuaString url, FromLuaString method, LuaNativeTable customHeaderFields, FromLuaString contentType, FromLuaDataString contentData);

	public delegate bool Wifi_WebAbortType(IntPtr modulePtr, uint handle);

	public delegate float Wifi_GetWebUploadProgressType(IntPtr modulePtr, uint handle);

	public delegate float Wifi_GetWebDownloadProgressType(IntPtr modulePtr, uint handle);

	public delegate void Wifi_ClearCookieCacheType(IntPtr modulePtr);

	public delegate void Wifi_ClearUrlCookieCacheType(IntPtr modulePtr, FromLuaString url);

	public static void Register()
	{
	}

	public static LuaNativeArray AudioChip_GetSpectrumData(IntPtr modulePtr, int channel, int samplesCount)
	{
		return null;
	}

	public static double AudioChip_GetDspTime(IntPtr modulePtr)
	{
		return 0.0;
	}

	public static void AudioChip_Play(IntPtr modulePtr, LuaAssetReference audioSample, int channel)
	{
	}

	public static void AudioChip_PlayScheduled(IntPtr modulePtr, LuaAssetReference audioSample, int channel, double dspTime)
	{
	}

	public static void AudioChip_PlayLoop(IntPtr modulePtr, LuaAssetReference audioSample, int channel)
	{
	}

	public static void AudioChip_PlayLoopScheduled(IntPtr modulePtr, LuaAssetReference audioSample, int channel, double dspTime)
	{
	}

	public static void AudioChip_Stop(IntPtr modulePtr, int channel)
	{
	}

	public static void AudioChip_Pause(IntPtr modulePtr, int channel)
	{
	}

	public static void AudioChip_UnPause(IntPtr modulePtr, int channel)
	{
	}

	public static bool AudioChip_IsPlaying(IntPtr modulePtr, int channel)
	{
		return false;
	}

	public static bool AudioChip_IsPaused(IntPtr modulePtr, int channel)
	{
		return false;
	}

	public static float AudioChip_GetPlayTime(IntPtr modulePtr, int channel)
	{
		return 0f;
	}

	public static void AudioChip_SeekPlayTime(IntPtr modulePtr, float time, int channel)
	{
	}

	public static void AudioChip_SetChannelVolume(IntPtr modulePtr, float volume, int channel)
	{
	}

	public static float AudioChip_GetChannelVolume(IntPtr modulePtr, int channel)
	{
		return 0f;
	}

	public static void AudioChip_SetChannelPitch(IntPtr modulePtr, float pitch, int channel)
	{
	}

	public static float AudioChip_GetChannelPitch(IntPtr modulePtr, int channel)
	{
		return 0f;
	}

	public static bool FlashMemory_Save(IntPtr modulePtr, LuaNativeTable table)
	{
		return false;
	}

	public static LuaNativeTable FlashMemory_Load(IntPtr modulePtr)
	{
		return default(LuaNativeTable);
	}

	public static ToLuaInputSource GamepadChip_GetButton(IntPtr modulePtr, IntPtr name)
	{
		return null;
	}

	public static ToLuaInputSource GamepadChip_GetAxis(IntPtr modulePtr, IntPtr name)
	{
		return null;
	}

	public static ToLuaInputSource GamepadChip_GetButtonAxis(IntPtr modulePtr, IntPtr negativeName, IntPtr positiveName)
	{
		return null;
	}

	public static ToLuaInputSource KeyboardChip_GetButton(IntPtr modulePtr, IntPtr name)
	{
		return null;
	}

	public static ToLuaInputSource KeyboardChip_GetButtonAxis(IntPtr modulePtr, IntPtr negativeName, IntPtr positiveName)
	{
		return null;
	}

	public static LuaNativeTable RealityChip_GetDateTime(IntPtr modulePtr)
	{
		return default(LuaNativeTable);
	}

	public static LuaNativeTable RealityChip_GetDateTimeUTC(IntPtr modulePtr)
	{
		return default(LuaNativeTable);
	}

	public static LuaAssetReference RealityChip_LoadAudioSample(IntPtr modulePtr, FromLuaString filename)
	{
		return null;
	}

	public static LuaAssetReference RealityChip_LoadSpriteSheet(IntPtr modulePtr, FromLuaString filename, int spritesWidth, int spritesHeight)
	{
		return null;
	}

	public static void RealityChip_UnloadAsset(IntPtr modulePtr, FromLuaString filename)
	{
	}

	public static LuaNativeTable RealityChip_ListDirectory(IntPtr modulePtr, FromLuaString directory)
	{
		return default(LuaNativeTable);
	}

	public static LuaNativeTable RealityChip_GetFileMetadata(IntPtr modulePtr, FromLuaString filename)
	{
		return default(LuaNativeTable);
	}

	public static void SegmentDisplay_ShowDigit(IntPtr modulePtr, int groupIndex, int digit)
	{
	}

	public static void SegmentDisplay_SetDigitColor(IntPtr modulePtr, int groupIndex, Color color)
	{
	}

	public static void Serial_WriteInt8(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_WriteUInt8(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_WriteInt16(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_WriteUInt16(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_WriteInt32(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_WriteUInt32(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_WriteFloat32(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_WriteFloat64(IntPtr modulePtr, double value)
	{
	}

	public static void Serial_Write(IntPtr modulePtr, FromLuaDataString data)
	{
	}

	public static void Serial_Print(IntPtr modulePtr, FromLuaDataString text)
	{
	}

	public static void Serial_Println(IntPtr modulePtr, FromLuaDataString text)
	{
	}

	public static LuaNativeArray Serial_GetAvailablePorts(IntPtr modulePtr)
	{
		return null;
	}

	public static void VideoChip_RenderOnScreen(IntPtr modulePtr)
	{
	}

	public static void VideoChip_RenderOnBuffer(IntPtr modulePtr, int index)
	{
	}

	public static void VideoChip_SetRenderBufferSize(IntPtr modulePtr, int index, int width, int height)
	{
	}

	public static void VideoChip_Clear(IntPtr modulePtr, Color color)
	{
	}

	public static void VideoChip_SetPixel(IntPtr modulePtr, LuaVector position, Color color)
	{
	}

	public static void VideoChip_DrawPointGrid(IntPtr modulePtr, LuaVector gridOffset, int dotsDistance, Color color)
	{
	}

	public static void VideoChip_DrawLine(IntPtr modulePtr, LuaVector start, LuaVector end, Color color)
	{
	}

	public static void VideoChip_DrawCircle(IntPtr modulePtr, LuaVector position, int radius, Color color)
	{
	}

	public static void VideoChip_FillCircle(IntPtr modulePtr, LuaVector position, int radius, Color color)
	{
	}

	public static void VideoChip_DrawRect(IntPtr modulePtr, LuaVector position1, LuaVector position2, Color color)
	{
	}

	public static void VideoChip_FillRect(IntPtr modulePtr, LuaVector position1, LuaVector position2, Color color)
	{
	}

	public static void VideoChip_DrawTriangle(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, Color color)
	{
	}

	public static void VideoChip_FillTriangle(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, Color color)
	{
	}

	public static void VideoChip_DrawSprite(IntPtr modulePtr, LuaVector position, LuaAssetReference spriteSheet, int spriteX, int spriteY, Color tintColor, Color backgroundColor)
	{
	}

	public static void VideoChip_DrawCustomSprite(IntPtr modulePtr, LuaVector position, LuaAssetReference spriteSheet, LuaVector spriteOffset, LuaVector spriteSize, Color tintColor, Color backgroundColor)
	{
	}

	public static void VideoChip_DrawText(IntPtr modulePtr, LuaVector position, LuaAssetReference fontSprite, FromLuaString text, Color textColor, Color backgroundColor)
	{
	}

	public static void VideoChip_RasterSprite(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, LuaVector position4, LuaAssetReference spriteSheet, int spriteX, int spriteY, Color tintColor, Color backgroundColor)
	{
	}

	public static void VideoChip_RasterCustomSprite(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, LuaVector position4, LuaAssetReference spriteSheet, LuaVector spriteOffset, LuaVector spriteSize, Color tintColor, Color backgroundColor)
	{
	}

	public static void VideoChip_DrawRenderBuffer(IntPtr modulePtr, LuaVector position, LuaAssetReference renderBuffer, int width, int height)
	{
	}

	public static void VideoChip_RasterRenderBuffer(IntPtr modulePtr, LuaVector position1, LuaVector position2, LuaVector position3, LuaVector position4, LuaAssetReference renderBuffer)
	{
	}

	public static void VideoChip_SetPixelData(IntPtr modulePtr, LuaPixelData pixelData)
	{
	}

	public static void VideoChip_BlitPixelData(IntPtr modulePtr, LuaVector position, LuaPixelData pixelData)
	{
	}

	public static LuaAssetReference Webcam_GetRenderBuffer(IntPtr modulePtr)
	{
		return null;
	}

	public static uint Wifi_WebGet(IntPtr modulePtr, FromLuaString url)
	{
		return 0u;
	}

	public static uint Wifi_WebPutData(IntPtr modulePtr, FromLuaString url, FromLuaDataString data)
	{
		return 0u;
	}

	public static uint Wifi_WebPostData(IntPtr modulePtr, FromLuaString url, FromLuaDataString data)
	{
		return 0u;
	}

	public static uint Wifi_WebPostForm(IntPtr modulePtr, FromLuaString url, LuaNativeTable form)
	{
		return 0u;
	}

	public static uint Wifi_WebCustomRequest(IntPtr modulePtr, FromLuaString url, FromLuaString method, LuaNativeTable customHeaderFields, FromLuaString contentType, FromLuaDataString contentData)
	{
		return 0u;
	}

	public static bool Wifi_WebAbort(IntPtr modulePtr, uint handle)
	{
		return false;
	}

	public static float Wifi_GetWebUploadProgress(IntPtr modulePtr, uint handle)
	{
		return 0f;
	}

	public static float Wifi_GetWebDownloadProgress(IntPtr modulePtr, uint handle)
	{
		return 0f;
	}

	public static void Wifi_ClearCookieCache(IntPtr modulePtr)
	{
	}

	public static void Wifi_ClearUrlCookieCache(IntPtr modulePtr, FromLuaString url)
	{
	}
}
