using System;
using System.Collections.Generic;
using DV.Common;
using UnityEngine;

namespace DV.Signs
{
	[CreateAssetMenu(menuName = "DV/Sign prefabs config asset")]
	public class SignPrefabsConfig : ScriptableObject
	{
		[Serializable]
		public class SignReference
		{
			public SignType type;

			public BaseSign sign;

			public ASignDisplayElement uiDisplayElement;
		}

		public SignGenerator emptyPoleGenerator;

		[Header("Sign references")]
		public SignReference[] signReferences;

		public string Validate()
		{
			List<string> list = new List<string>();
			SignReference[] array = signReferences;
			foreach (SignReference signReference in array)
			{
				if (signReference.sign == null || signReference.uiDisplayElement == null)
				{
					list.Add(signReference.type.ToString());
				}
			}
			if (!emptyPoleGenerator)
			{
				list.Add("emptyPoleGenerator");
			}
			if (list.Count != 0)
			{
				return "Unassigned fields: " + string.Join(", ", list);
			}
			return string.Empty;
		}

		public SignReference GetSignReference(SignType type)
		{
			SignReference[] array = signReferences;
			foreach (SignReference signReference in array)
			{
				if (signReference.type == type)
				{
					return signReference;
				}
			}
			return null;
		}

		public BaseSign GetBaseSign(SignType type)
		{
			return GetSignReference(type)?.sign;
		}
	}
}
