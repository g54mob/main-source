using System;
using System.Collections.Generic;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.Wss.Messages;
using ModIO.Implementation.Wss.Messages.Objects;
using Newtonsoft.Json.Utilities;
using UnityEngine;

namespace ModIO.Implementation.API
{
	internal class AotTypeEnforcer : MonoBehaviour
	{
		public void Awake()
		{
			AotHelper.EnsureList<ModId>();
			AotHelper.EnsureList<ModObject>();
			AotHelper.EnsureList<LogoObject>();
			AotHelper.EnsureList<UserObject>();
			AotHelper.EnsureList<ImageObject>();
			AotHelper.EnsureList<MetadataKVPObject>();
			AotHelper.EnsureList<ModMediaObject>();
			AotHelper.EnsureList<ModfileObject>();
			AotHelper.EnsureList<ModStatsObject>();
			AotHelper.EnsureList<GameTagOptionObject>();
			AotHelper.EnsureList<ModTagObject>();
			AotHelper.EnsureList<TermsObject>();
			AotHelper.EnsureList<TermsButtonObject>();
			AotHelper.EnsureList<TermsLinksObject>();
			AotHelper.EnsureList<DownloadObject>();
			AotHelper.EnsureList<FilehashObject>();
			AotHelper.EnsureList<UserEventObject>();
			AotHelper.EnsureList<ModEventObject>();
			AotHelper.EnsureList<AvatarObject>();
			AotHelper.EnsureList<AccessTokenObject>();
			AotHelper.EnsureList<ErrorObject>();
			AotHelper.EnsureList<Error>();
			AotHelper.EnsureList<ModCollectionRegistry>();
			AotHelper.EnsureList<UserModCollectionData>();
			AotHelper.EnsureList<ModCollectionEntry>();
			AotHelper.EnsureList<ModProfile>();
			AotHelper.EnsureList<DownloadReference>();
			AotHelper.EnsureList<KeyValuePair<string, string>>();
			AotHelper.EnsureList<ModStats>();
			AotHelper.EnsureList<DateTime>();
			AotHelper.EnsureList<RatingObject>();
			AotHelper.EnsureList<ModDependenciesObject>();
			AotHelper.EnsureList<WssMessage>();
			AotHelper.EnsureList<WssMessages>();
			AotHelper.EnsureList<WssLoginSuccess>();
			AotHelper.EnsureList<WssErrorObject>();
			AotHelper.EnsureList<WssDeviceLoginRequest>();
			AotHelper.EnsureList<WssDeviceLoginResponse>();
		}
	}
}
