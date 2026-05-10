using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct CreditDataPartenaineStruct
	{
		public List<Sprite> LogoPartenaire;

		[TextArea]
		public string TextPartenaire;

		public bool NeedColor;

		[ShowIf("NeedColor")]
		[AllowNesting]
		public Color Color;

		[ShowIf("NeedColor")]
		[AllowNesting]
		[TextArea]
		public string NameToColorWhite;
	}
}
