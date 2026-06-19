using System;
using System.Collections;
using Loxodon.Log;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Localizations
{
	[AddComponentMenu("Loxodon/Localization/LocalizedImageInResources")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Image))]
	public class LocalizedImageInResources : AbstractLocalized<Image>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(LocalizedImageInResources));

		protected override void OnValueChanged(object sender, EventArgs e)
		{
			object obj = value.Value;
			if (obj is Sprite)
			{
				target.sprite = (Sprite)obj;
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
			ResourceRequest result = Resources.LoadAsync<Sprite>(path);
			yield return result;
			target.sprite = (Sprite)result.asset;
		}
	}
}
