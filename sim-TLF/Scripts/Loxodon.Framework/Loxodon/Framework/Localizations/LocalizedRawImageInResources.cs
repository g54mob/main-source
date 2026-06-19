using System;
using System.Collections;
using Loxodon.Log;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Localizations
{
	[AddComponentMenu("Loxodon/Localization/LocalizedRawImageInResources")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RawImage))]
	public class LocalizedRawImageInResources : AbstractLocalized<RawImage>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(LocalizedRawImageInResources));

		protected override void OnValueChanged(object sender, EventArgs e)
		{
			object obj = value.Value;
			if (obj is Texture2D)
			{
				target.texture = (Texture2D)obj;
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
			ResourceRequest result = Resources.LoadAsync<Texture2D>(path);
			yield return result;
			target.texture = (Texture2D)result.asset;
		}
	}
}
