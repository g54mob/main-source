using System;
using NSEipix.Base;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class FactionType : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string nameTextKey;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private IntRange faithRange;

		[SerializeField]
		private bool hideOnMap;

		[SerializeField]
		private FloatRange friendlinessRange;

		public string NameTextKey => nameTextKey;

		public LocKeys[] LocKeys => locKeys;

		public IntRange FaithRange => faithRange;

		public FloatRange FriendlinessRange => friendlinessRange;

		public bool HideOnMap => hideOnMap;

		public override string GetID()
		{
			return id;
		}
	}
}
