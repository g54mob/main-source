using System;
using NSEipix.Base;
using NSMedieval.UI;
using UnityEngine;

namespace Models
{
	[Serializable]
	public class NPCCustomWarningMessage : Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string shortInfo;

		[SerializeField]
		private string info;

		[SerializeField]
		private string icon;

		[SerializeField]
		private WarningMessageCategory category;

		public string ShortInfo => shortInfo;

		public string Info => info;

		public string Icon => icon;

		public WarningMessageCategory Category => category;

		public override string GetID()
		{
			return id;
		}
	}
}
