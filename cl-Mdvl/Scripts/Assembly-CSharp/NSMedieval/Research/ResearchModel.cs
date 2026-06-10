using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Dictionary;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Research
{
	[Serializable]
	public class ResearchModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private ResearchCategory category;

		[SerializeField]
		private List<ResearchUnlock> unlocks;

		[SerializeField]
		private StringIntDictionary requiredResources = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();

		[SerializeField]
		private List<string> nextNodesIDs;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string iconPath;

		[SerializeField]
		private string iconActive;

		[SerializeField]
		private string iconUnlocked;

		[SerializeField]
		private string iconLocked;

		public LocKeys[] LocKeys => locKeys;

		public string IconPath => iconPath;

		public string IconActive => iconActive;

		public string IconUnlocked => iconUnlocked;

		public string IconLocked => iconLocked;

		public ResearchCategory Category => category;

		public List<ResearchUnlock> Unlocks => unlocks;

		public StringIntDictionary RequiredResources => requiredResources;

		public List<string> NextNodesIDs => nextNodesIDs;

		public override string GetID()
		{
			return id;
		}
	}
}
