using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SteamControllerExtension : Controller.Extension
	{
		private class yNTFfsidgZkhEydenaejxDxMZFCw : IControllerExtensionSource
		{
			public readonly ISteamControllerInternal hRQQAwbhQZCJKXMaAtEodmYGFDFf;

			public yNTFfsidgZkhEydenaejxDxMZFCw(ISteamControllerInternal internalController)
			{
				hRQQAwbhQZCJKXMaAtEodmYGFDFf = internalController;
			}
		}

		private yNTFfsidgZkhEydenaejxDxMZFCw ahVlanlbOCBOWeBnfSIFVGtHSeq;

		private Joystick joystick => GetController<Joystick>();

		internal ISteamControllerInternal internalController => ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf;

		internal SteamControllerExtension(ISteamControllerInternal internalController)
			: base(new yNTFfsidgZkhEydenaejxDxMZFCw(internalController))
		{
			iDBXctPcOcjjzWbKaCnxuPiVNUc();
		}

		private SteamControllerExtension(SteamControllerExtension source)
			: base(source)
		{
			iDBXctPcOcjjzWbKaCnxuPiVNUc();
		}

		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetActionSetHandle(ref actionSetName);
		}

		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetAnalogActionHandle(ref actionName);
		}

		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetDigitalActionHandle(ref actionName);
		}

		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetActionSetName(actionSetHandle);
		}

		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetAnalogActionName(actionHandle);
		}

		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetDigitalActionName(actionHandle);
		}

		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetAnalogActionValue(ref actionName);
		}

		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector2.zero;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetAnalogActionValue(actionHandle);
		}

		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetDigitalActionValue(ref actionName);
		}

		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetDigitalActionValue(actionHandle);
		}

		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.SetActiveActionSet(actionSetHandle);
		}

		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.SetActiveActionSet(ref actionSetName);
		}

		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetActiveActionSetHandle();
		}

		public string GetActiveActionSetName()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetActiveActionSetName();
		}

		public void ShowBindingPanel()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.ShowBindingPanel();
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.SetHapticPulse(targePad, durationSeconds);
			}
		}

		public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.SetHapticPulse(targePad, durationMicroSeconds);
			}
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return ahVlanlbOCBOWeBnfSIFVGtHSeq.hRQQAwbhQZCJKXMaAtEodmYGFDFf.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			ahVlanlbOCBOWeBnfSIFVGtHSeq = source as yNTFfsidgZkhEydenaejxDxMZFCw;
		}

		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		private void iDBXctPcOcjjzWbKaCnxuPiVNUc()
		{
		}
	}
}
