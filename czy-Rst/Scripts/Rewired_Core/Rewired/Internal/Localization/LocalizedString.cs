using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint TcrkraXCOBjCgJKCeZuRDgrklTuiA;

		private uint UTkIRlxZrFUoBszxyrBThODQqmtV;

		private string jVtUSKDHFUirkbiaJyLmXGWgqEsg;

		private bool QKsXsPWCsqSKIDqWchMcadVfllkdA;

		public bool hasCachedValue => QKsXsPWCsqSKIDqWchMcadVfllkdA;

		public string cachedValue
		{
			get
			{
				return jVtUSKDHFUirkbiaJyLmXGWgqEsg;
			}
			set
			{
				QKsXsPWCsqSKIDqWchMcadVfllkdA = true;
				jVtUSKDHFUirkbiaJyLmXGWgqEsg = value;
			}
		}

		public LocalizedString()
		{
			TcrkraXCOBjCgJKCeZuRDgrklTuiA = 0u;
			UTkIRlxZrFUoBszxyrBThODQqmtV = 0u;
		}

		public LocalizedString(LocalizedString P_0)
		{
			TcrkraXCOBjCgJKCeZuRDgrklTuiA = P_0.TcrkraXCOBjCgJKCeZuRDgrklTuiA;
			UTkIRlxZrFUoBszxyrBThODQqmtV = P_0.UTkIRlxZrFUoBszxyrBThODQqmtV;
			jVtUSKDHFUirkbiaJyLmXGWgqEsg = P_0.jVtUSKDHFUirkbiaJyLmXGWgqEsg;
			QKsXsPWCsqSKIDqWchMcadVfllkdA = P_0.QKsXsPWCsqSKIDqWchMcadVfllkdA;
		}

		public void Clear()
		{
			TcrkraXCOBjCgJKCeZuRDgrklTuiA = 0u;
			UTkIRlxZrFUoBszxyrBThODQqmtV = 0u;
			jVtUSKDHFUirkbiaJyLmXGWgqEsg = null;
			QKsXsPWCsqSKIDqWchMcadVfllkdA = false;
		}

		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = TcrkraXCOBjCgJKCeZuRDgrklTuiA != ((localizer != null) ? localizerVersion : 0) || userVersion != UTkIRlxZrFUoBszxyrBThODQqmtV;
			if (versionChanged)
			{
				Clear();
				TcrkraXCOBjCgJKCeZuRDgrklTuiA = localizerVersion;
				UTkIRlxZrFUoBszxyrBThODQqmtV = userVersion;
			}
			if (!versionChanged || localizer == null)
			{
				result = (QKsXsPWCsqSKIDqWchMcadVfllkdA ? jVtUSKDHFUirkbiaJyLmXGWgqEsg : null);
				return QKsXsPWCsqSKIDqWchMcadVfllkdA;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				QKsXsPWCsqSKIDqWchMcadVfllkdA = localizer.TryGetLocalizedString(key, out jVtUSKDHFUirkbiaJyLmXGWgqEsg) && !string.IsNullOrEmpty(jVtUSKDHFUirkbiaJyLmXGWgqEsg);
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
			}
			result = (QKsXsPWCsqSKIDqWchMcadVfllkdA ? jVtUSKDHFUirkbiaJyLmXGWgqEsg : null);
			return QKsXsPWCsqSKIDqWchMcadVfllkdA;
		}
	}
}
