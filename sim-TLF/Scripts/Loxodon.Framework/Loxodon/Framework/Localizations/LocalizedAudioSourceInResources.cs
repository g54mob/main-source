using System;
using System.Collections;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[AddComponentMenu("Loxodon/Localization/LocalizedAudioSourceInResources")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(AudioSource))]
	public class LocalizedAudioSourceInResources : AbstractLocalized<AudioSource>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(LocalizedAudioSourceInResources));

		protected override void OnValueChanged(object sender, EventArgs e)
		{
			object obj = value.Value;
			if (obj is AudioClip)
			{
				target.clip = (AudioClip)obj;
			}
			else if (obj is string)
			{
				string path = (string)obj;
				StartCoroutine(DoLoad(path));
			}
			else if (obj != null && log.IsErrorEnabled)
			{
				log.ErrorFormat("There is an invalid localization value \"{0}\" on the GameObject named \"{1}\".", obj, base.name);
			}
		}

		protected virtual IEnumerator DoLoad(string path)
		{
			ResourceRequest result = Resources.LoadAsync<AudioClip>(path);
			yield return result;
			target.clip = (AudioClip)result.asset;
		}
	}
}
