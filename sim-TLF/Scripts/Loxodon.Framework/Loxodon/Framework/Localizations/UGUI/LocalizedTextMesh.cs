using System;
using UnityEngine;

namespace Loxodon.Framework.Localizations.UGUI
{
	[AddComponentMenu("Loxodon/Localization/LocalizedTextMesh")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TextMesh))]
	public class LocalizedTextMesh : AbstractLocalized<TextMesh>
	{
		protected override void OnValueChanged(object sender, EventArgs e)
		{
			target.text = (string)Convert.ChangeType(value.Value, typeof(string));
		}
	}
}
