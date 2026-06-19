using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Localization
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class LocalizedString
	{
		public const uint INVALID_VERSION = 0u;

		private uint QWMvQsgAbXkyjFukOGUwSereiFXF;

		private uint HrFHcdEaUROpQxPPGfVgZrIGXiYi;

		private string eIKJOCoGgEbCncqCflGDIlTimFTsA;

		private bool JWPbuVbuRmEiTYsoYtaFNdWlMQVW;

		public bool hasCachedValue => JWPbuVbuRmEiTYsoYtaFNdWlMQVW;

		public string cachedValue
		{
			get
			{
				return eIKJOCoGgEbCncqCflGDIlTimFTsA;
			}
			set
			{
				JWPbuVbuRmEiTYsoYtaFNdWlMQVW = true;
				eIKJOCoGgEbCncqCflGDIlTimFTsA = value;
			}
		}

		public LocalizedString()
		{
			QWMvQsgAbXkyjFukOGUwSereiFXF = 0u;
			HrFHcdEaUROpQxPPGfVgZrIGXiYi = 0u;
		}

		public LocalizedString(LocalizedString P_0)
		{
			QWMvQsgAbXkyjFukOGUwSereiFXF = P_0.QWMvQsgAbXkyjFukOGUwSereiFXF;
			HrFHcdEaUROpQxPPGfVgZrIGXiYi = P_0.HrFHcdEaUROpQxPPGfVgZrIGXiYi;
			eIKJOCoGgEbCncqCflGDIlTimFTsA = P_0.eIKJOCoGgEbCncqCflGDIlTimFTsA;
			JWPbuVbuRmEiTYsoYtaFNdWlMQVW = P_0.JWPbuVbuRmEiTYsoYtaFNdWlMQVW;
		}

		public void Clear()
		{
			QWMvQsgAbXkyjFukOGUwSereiFXF = 0u;
			HrFHcdEaUROpQxPPGfVgZrIGXiYi = 0u;
			eIKJOCoGgEbCncqCflGDIlTimFTsA = null;
			JWPbuVbuRmEiTYsoYtaFNdWlMQVW = false;
		}

		public bool TryGetLocalizedValue(string key, ILocalizedStringProvider localizer, uint localizerVersion, uint userVersion, out bool versionChanged, out string result)
		{
			versionChanged = QWMvQsgAbXkyjFukOGUwSereiFXF != ((localizer != null) ? localizerVersion : 0) || userVersion != HrFHcdEaUROpQxPPGfVgZrIGXiYi;
			if (versionChanged)
			{
				Clear();
				QWMvQsgAbXkyjFukOGUwSereiFXF = localizerVersion;
				HrFHcdEaUROpQxPPGfVgZrIGXiYi = userVersion;
			}
			if (!versionChanged || localizer == null)
			{
				result = (JWPbuVbuRmEiTYsoYtaFNdWlMQVW ? eIKJOCoGgEbCncqCflGDIlTimFTsA : null);
				return JWPbuVbuRmEiTYsoYtaFNdWlMQVW;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				JWPbuVbuRmEiTYsoYtaFNdWlMQVW = localizer.TryGetLocalizedString(key, out eIKJOCoGgEbCncqCflGDIlTimFTsA) && !string.IsNullOrEmpty(eIKJOCoGgEbCncqCflGDIlTimFTsA);
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(ILocalizedStringProvider).Name + ".TryGetLocalizedString", exception);
			}
			result = (JWPbuVbuRmEiTYsoYtaFNdWlMQVW ? eIKJOCoGgEbCncqCflGDIlTimFTsA : null);
			return JWPbuVbuRmEiTYsoYtaFNdWlMQVW;
		}
	}
}
