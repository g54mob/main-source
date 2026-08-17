using System;
using System.Text.RegularExpressions;
using Cpp2ILInjected;
using Sirenix.OdinInspector;

namespace VampireSurvivors.Framework.DLC;

[Serializable]
public class PlayStationDlcData
{
	private string _ContentLabel;

	private string _ServiceId;

	private string _EntitlementKey;

	private string _IconAssetPath;

	public string ContentLabel => _ContentLabel;

	public string ServiceId => _ServiceId;

	public string EntitlementKey => _EntitlementKey;

	public string IconAssetPath => _IconAssetPath;

	public string ContentId()
	{
		//IL_00d5: Expected O, but got I
		//IL_00e5: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AE0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string serviceId = _ServiceId;
		if (_ServiceId != null && serviceId._stringLength > 0)
		{
			string contentLabel = _ContentLabel;
			if (_ContentLabel != null && contentLabel._stringLength > 0)
			{
				return _ServiceId + "-" + _ContentLabel;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v4+B8]");
		return (string)0;
	}

	public void UpdateEntitlementKey(string newEntitlementKey)
	{
		_EntitlementKey = newEntitlementKey;
	}

	private unsafe bool IsContentLabelValid(string contentLabel, ref string errorMessage, ref InfoMessageType? messageType)
	{
		if (contentLabel != null && contentLabel._stringLength > 0)
		{
			if (contentLabel._stringLength == 16)
			{
				return true;
			}
			ref string reference = ref *(string*)"ContentLabel must be exactly 16 characters long";
		}
		else
		{
			ref string reference = ref *(string*)"ContentLabel must be set";
		}
		ref InfoMessageType? reference2 = ref *(InfoMessageType?*)1;
		return false;
	}

	private unsafe bool IsServiceIdValid(string serviceId, ref string errorMessage, ref InfoMessageType? messageType)
	{
		if (serviceId != null && serviceId._stringLength > 0)
		{
			if (serviceId._stringLength == 19)
			{
				return true;
			}
			ref string reference = ref *(string*)"ServiceId must be exactly 19 characters long";
		}
		else
		{
			ref string reference = ref *(string*)"ServiceId must be set";
		}
		ref InfoMessageType? reference2 = ref *(InfoMessageType?*)1;
		return false;
	}

	private unsafe bool IsEntitlementKeyValid(string entitlementKey, ref string errorMessage, ref InfoMessageType? messageType)
	{
		if (entitlementKey != null && entitlementKey._stringLength > 0)
		{
			if (entitlementKey._stringLength == 32)
			{
				if (Regex.IsMatch(entitlementKey, "\\A\\b[0-9a-fA-F]+\\b\\Z"))
				{
					return true;
				}
				ref string reference = ref *(string*)"EntitlementKey must be a hexadecimal string";
			}
			else
			{
				ref string reference = ref *(string*)"EntitlementKey must be exactly 32 hexadecimal characters long";
			}
		}
		else
		{
			ref string reference = ref *(string*)"EntitlementKey must be set";
		}
		ref InfoMessageType? reference2 = ref *(InfoMessageType?*)1;
		return false;
	}
}
