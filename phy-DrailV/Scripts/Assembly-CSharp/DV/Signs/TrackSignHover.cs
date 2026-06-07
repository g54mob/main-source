using System.Collections.Generic;
using DV.Common;
using TMPro;
using UnityEngine;

namespace DV.Signs
{
	public class TrackSignHover : SignHover
	{
		public TextMeshPro subYardID;

		public TextMeshPro trackID;

		protected override void Start()
		{
			base.Start();
			GameObject prefab = Sign.Config.GetSignReference(SignType.TrackID).uiDisplayElement.gameObject;
			string text = $"{subYardID.text}{'|'}{trackID.text}".Replace("\n", "").Replace("\r", "");
			signTypes = new List<SignDisplayInstance>();
			signTypes.Add(new SignDisplayInstance
			{
				prefab = prefab,
				text = text
			});
		}
	}
}
