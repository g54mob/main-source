using System;
using Cpp2ILInjected;

namespace VampireSurvivors.App.Framework.Platforms.PlayStation;

public static class PLSCE
{
	public const int SCE_OK = 0;

	public const int k_INVALID_REQUESTID = -666;

	public const int PL_INVALID_SCE_ERROR_CODE = -267581850;

	public const int PL_SAVEDATA_IO_ERROR_UNKNOWN = -267581851;

	public const int PL_SAVEDATA_IO_FILEPATH_NOLEADINGSLASH = -267581852;

	public const int PL_SAVEDATA_IO_FILEPATH_NOT_FOUND = -267581853;

	public const int PL_SAVEDATA_IO_BACKUP_NO_RESPONSE = -267581854;

	public const int SCE_USER_SERVICE_ERROR_INTERNAL = -2137653247;

	public const int SCE_USER_SERVICE_ERROR_NOT_INITIALIZED = -2137653246;

	public const int SCE_USER_SERVICE_ERROR_ALREADY_INITIALIZED = -2137653245;

	public const int SCE_USER_SERVICE_ERROR_NO_MEMORY = -2137653244;

	public const int SCE_USER_SERVICE_ERROR_INVALID_ARGUMENT = -2137653243;

	public const int SCE_USER_SERVICE_ERROR_OPERATION_NOT_SUPPORTED = -2137653242;

	public const int SCE_USER_SERVICE_ERROR_NO_EVENT = -2137653241;

	public const int SCE_USER_SERVICE_ERROR_NOT_LOGGED_IN = -2137653239;

	public const int SCE_USER_SERVICE_ERROR_BUFFER_TOO_SHORT = -2137653238;

	public const int SCE_SAVE_DATA_ERROR_PARAMETER = -2137063424;

	public const int SCE_SAVE_DATA_ERROR_NOT_INITIALIZED = -2137063423;

	public const int SCE_SAVE_DATA_ERROR_OUT_OF_MEMORY = -2137063422;

	public const int SCE_SAVE_DATA_ERROR_BUSY = -2137063421;

	public const int SCE_SAVE_DATA_ERROR_NOT_MOUNTED = -2137063420;

	public const int SCE_SAVE_DATA_ERROR_NO_PERMISSION = -2137063419;

	public const int SCE_SAVE_DATA_ERROR_FINGERPRINT_MISMATCH = -2137063418;

	public const int SCE_SAVE_DATA_ERROR_EXISTS = -2137063417;

	public const int SCE_SAVE_DATA_ERROR_NOT_FOUND = -2137063416;

	public const int SCE_SAVE_DATA_ERROR_NO_SPACE = -2137063415;

	public const int SCE_SAVE_DATA_ERROR_NO_SPACE_FS = -2137063414;

	public const int SCE_SAVE_DATA_ERROR_INTERNAL = -2137063413;

	public const int SCE_SAVE_DATA_ERROR_MOUNT_FULL = -2137063412;

	public const int SCE_SAVE_DATA_ERROR_BAD_MOUNTED = -2137063411;

	public const int SCE_SAVE_DATA_ERROR_FILE_NOT_FOUND = -2137063410;

	public const int SCE_SAVE_DATA_ERROR_BROKEN = -2137063409;

	public const int SCE_SAVE_DATA_ERROR_INVALID_LOGIN_USER = -2137063407;

	public const int SCE_SAVE_DATA_ERROR_MEMORY_NOT_READY = -2137063406;

	public const int SCE_SAVE_DATA_ERROR_BACKUP_BUSY = -2137063405;

	public const int SCE_SAVE_DATA_ERROR_NOT_REGIST_CALLBACK = -2137063403;

	public const int SCE_SAVE_DATA_ERROR_BUSY_FOR_SAVING = -2137063402;

	public const int SCE_SAVE_DATA_ERROR_LIMITATION_OVER = -2137063401;

	public const int SCE_SAVE_DATA_ERROR_EVENT_BUSY = -2137063400;

	public const int SCE_SAVE_DATA_ERROR_PARAMSFO_TRANSFER_TITLE_ID_NOT_FOUND = -2137063399;

	public const int SCE_SAVE_DATA_ERROR_RESOURCE_FULL = -2137063398;

	public const int SCE_SAVE_DATA_ERROR_RESOURCE_BUSY = -2137063397;

	public const int SCE_SAVE_DATA_ERROR_RESOURCE_INVALID = -2137063396;

	private const int SCE_COMMON_DIALOG_ERROR_NOT_SYSTEM_INITIALIZED = -2135425023;

	private const int SCE_COMMON_DIALOG_ERROR_ALREADY_SYSTEM_INITIALIZED = -2135425022;

	private const int SCE_COMMON_DIALOG_ERROR_NOT_INITIALIZED = -2135425021;

	private const int SCE_COMMON_DIALOG_ERROR_ALREADY_INITIALIZED = -2135425020;

	private const int SCE_COMMON_DIALOG_ERROR_NOT_FINISHED = -2135425019;

	private const int SCE_COMMON_DIALOG_ERROR_INVALID_STATE = -2135425018;

	private const int SCE_COMMON_DIALOG_ERROR_RESULT_NONE = -2135425017;

	private const int SCE_COMMON_DIALOG_ERROR_BUSY = -2135425016;

	private const int SCE_COMMON_DIALOG_ERROR_OUT_OF_MEMORY = -2135425015;

	private const int SCE_COMMON_DIALOG_ERROR_PARAM_INVALID = -2135425014;

	private const int SCE_COMMON_DIALOG_ERROR_NOT_RUNNING = -2135425013;

	private const int SCE_COMMON_DIALOG_ERROR_ALREADY_CLOSE = -2135425012;

	private const int SCE_COMMON_DIALOG_ERROR_ARG_NULL = -2135425011;

	private const int SCE_COMMON_DIALOG_ERROR_UNEXPECTED_FATAL = -2135425010;

	private const int SCE_COMMON_DIALOG_ERROR_NOT_SUPPORTED = -2135425009;

	private const int SCE_COMMON_DIALOG_ERROR_INHIBIT_SHAREPLAY_CLIENT = -2135425008;

	public static bool Succeeded(int sceReturnCode)
	{
		bool flag = sceReturnCode < 0;
		return !flag;
	}

	public static int MapFileIOExceptionToError(Exception exceptionDuringFileIO)
	{
		//IL_00a6: Expected I4, but got O
		//IL_0067: Expected O, but got I8
		//IL_0093: Expected I4, but got I8
		//IL_0050: Expected I4, but got I8
		if (exceptionDuringFileIO != null)
		{
			if (exceptionDuringFileIO._HResult == 2147942403L)
			{
				return -267581853;
			}
			object obj = exceptionDuringFileIO._HResult - 2148734216L;
			bool flag = obj == null;
			bool flag2 = !flag;
			return (int)((flag2 ? 1 : 0) + 4027385444L);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static string GetName(int sceReturnCode)
	{
		//IL_0129: Expected O, but got I4
		//IL_0136: Expected O, but got I8
		//IL_0185: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_01d4: Expected O, but got I4
		//IL_016d: Expected O, but got I8
		//IL_01bc: Expected O, but got I8
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_020b: Expected O, but got I8
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E37]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (sceReturnCode > 2159542288L)
		{
			object obj = sceReturnCode + 267581853;
			bool flag = obj == null;
			if (flag)
			{
				return "PL_SAVEDATA_IO_FILEPATH_NOT_FOUND";
			}
			object obj2 = obj - 1;
			if (flag)
			{
				return "PL_SAVEDATA_IO_FILEPATH_NOLEADINGSLASH";
			}
			object obj3 = obj2 - 1;
			if (flag)
			{
				return "PL_SAVEDATA_IO_ERROR_UNKNOWN";
			}
			if ((nint)obj3 == 1)
			{
				return "PL_INVALID_SCE_ERROR_CODE";
			}
			if (sceReturnCode == 4294966630L)
			{
				return "k_INVALID_REQUESTID";
			}
			if (sceReturnCode == 0)
			{
				return "SCE_OK";
			}
		}
		else
		{
			object obj4 = sceReturnCode + 2137653247;
			object obj5 = 6442450944L;
			if ((nint)obj4 <= 9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4+6C26AA4+v59 @ rax_v5*4]");
				object obj6 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ rcx_v10 (should have been resolved before IL gen)");
			}
			object obj7 = sceReturnCode + 2137063424;
			if ((nint)obj7 <= 28)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4+6C26ACC+v83 @ rax_v6*4]");
				object obj8 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ rcx_v8 (should have been resolved before IL gen)");
			}
			object obj9 = sceReturnCode + 2135425023;
			if ((nint)obj9 <= 15)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v4+6C26B40+v194 @ rax_v7*4]");
				object obj10 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v120 @ rcx_v6 (should have been resolved before IL gen)");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		string result = default(string);
		return result;
	}
}
