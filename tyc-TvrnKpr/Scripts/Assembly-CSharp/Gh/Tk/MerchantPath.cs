using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class MerchantPath : MonoBehaviour
	{
		public List<DOTweenPath> Paths;

		[field: SerializeField]
		public bool IsEntryPath { get; set; }

		public Tween InitPath(MerchantJob job, GameObjectX gox)
		{
			return null;
		}
	}
}
