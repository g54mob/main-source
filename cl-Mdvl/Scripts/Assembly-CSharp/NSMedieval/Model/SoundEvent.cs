using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class SoundEvent : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string path;

		public string Path => path;

		public SoundEvent(string id, string path)
		{
			this.id = id;
			this.path = path;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
